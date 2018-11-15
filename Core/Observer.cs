/*
Copyright 2018 tkpphr

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using AddresSound.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddresSound.Core
{
	public class Observer : IDisposable
	{
		private List<Notifier> _Notifiers;
		private Timer UpdateTimer { get; set; }
		private StringBuilder LogBuilder { get; set; }
		private ObservedProcess ObservedProcess { get; set; }
		private byte[] ReadBuffer { get; set; }
		public IReadOnlyCollection<Notifier> Notifiers => _Notifiers.AsReadOnly();
		public int NotifierCount => _Notifiers.Count;
		public string Title { get; set; }
		public string TargetAddress { get; set; }
		public int ValueType { get; set; }
		public int UpdateInterval { get; set; }
		public bool NotifierPriorityEnabled { get; set; }
		public bool IsObserving { get; private set; }
		public ulong ReadValue { get; private set; }
		public string Log => LogBuilder.ToString();
		public bool IsObservable => IsValidTargetAddress && ObservedProcess.IsOpened;
		public bool IsValidTargetAddress
		{
			get
			{
				if(!ObservedProcess.IsOpened)
				{
					return false;
				}
				if(Regex.IsMatch(TargetAddress,"[a-fA-F0-9]+"))
				{
					if (ObservedProcess.Is64BitProcess)
					{
						return TargetAddress.Length <= 16;
					}
					else
					{
						return TargetAddress.Length <= 8;
					}
					
				}
				else
				{
					return false;
				}
			}
		}
		public event Action<Observer> Started;
		public event Action<Observer> Stopped;
		public event Action<Observer, ulong, ulong> ValueUpdated;
		public event Action<Observer,Process,IntPtr> ProcessOpened;
		public event Action<Observer> ProcessExited;
		
		public Observer(ObservedProcess observedProcess)
			: this(observedProcess,new ObserverSettings() { Title = "", TargetAddress = "", ValueType = (int)ReadValueType.Byte, UpdateInterval =60 , NotifierPriorityEnabled = true,NotifierSettingsList=new List<NotifierSettings>()})
		{
			
		}

		public Observer(ObservedProcess observedProcess,ObserverSettings settings)
		{
			ObservedProcess = observedProcess;
			ObservedProcess.ProcessOpened += ObservedProcess_ProcessOpened;
			ObservedProcess.ProcessExited += ObservedProcess_ProcessExited;
			Title = settings.Title;
			TargetAddress = settings.TargetAddress;
			ValueType = settings.ValueType;
			UpdateInterval = settings.UpdateInterval;
			NotifierPriorityEnabled = settings.NotifierPriorityEnabled;
			LogBuilder = new StringBuilder();
			UpdateTimer = new Timer();
			UpdateTimer.Tick += Timer_Tick;
			_Notifiers = new List<Notifier>();
			foreach(NotifierSettings notifierSettings in settings.NotifierSettingsList)
			{
				_Notifiers.Add(new Notifier(notifierSettings));
			}
		}

		public void Dispose()
		{
			Stop();
			foreach(Notifier notifier in Notifiers)
			{
				notifier.Dispose();
			}
			ObservedProcess.ProcessOpened -= ObservedProcess_ProcessOpened;
			ObservedProcess.ProcessExited -= ObservedProcess_ProcessExited;
			UpdateTimer.Dispose();
		}

		public void Start()
		{
			if (IsObserving)
			{
				return;
			}
			foreach (Notifier notifier in Notifiers)
			{
				notifier.StopAllSound();
			}
			ReadBuffer = new byte[8];
			UpdateTimer.Interval = UpdateInterval;
			UpdateTimer.Start();
			LogBuilder.AppendLine(string.Format("[{0}] : {1}", DateTime.Now.ToString(), Resources.StartObserve));
			IsObserving = true;
			Started?.Invoke(this);
			byte[] result = TryReadProcessMemory(ObservedProcess.ProcessHandle, ObservedProcess.Process.MainModule.BaseAddress.ToInt64(), Convert.ToInt64(TargetAddress, 16));
			if (result != null)
			{
				ReadValue = ((ReadValueType)ValueType).ToValue(result);
			}
		}

		public void Stop()
		{
			if (!IsObserving)
			{
				return;
			}
			foreach (Notifier notifier in Notifiers)
			{
				notifier.StopAllSound();
			}
			UpdateTimer.Stop();
			LogBuilder.AppendLine(string.Format("[{0}] : {1}", DateTime.Now.ToString(), Resources.StopObserve));
			IsObserving = false;
			Stopped?.Invoke(this);
		}

		public void ClearLog()
		{
			LogBuilder.Clear();
		}

		public void AddNotifier(Notifier notifier)
		{
			_Notifiers.Add(notifier);
		}

		public void RemoveNotifier(int i)
		{
			_Notifiers.RemoveAt(i);
		}

		public Notifier GetNotifier(int i)
		{
			return _Notifiers[i];
		}

		public int GetNotifierPriority(Notifier notifier)
		{
			return _Notifiers.IndexOf(notifier);
		}

		public void SwapNotifierPriority(int a,int b)
		{
			var temp =_Notifiers[a];
			_Notifiers[a] = _Notifiers[b];
			_Notifiers[b] = temp;
		}

		private void ObservedProcess_ProcessOpened(Process process,IntPtr processHandle)
		{
			
			ProcessOpened?.Invoke(this, process, processHandle);
		}

		private void ObservedProcess_ProcessExited()
		{
			ProcessExited?.Invoke(this);
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (ObservedProcess.Process.HasExited)
			{
				return;
			}
			byte[] result = TryReadProcessMemory(ObservedProcess.ProcessHandle, ObservedProcess.Process.MainModule.BaseAddress.ToInt64(), Convert.ToInt64(TargetAddress, 16));
			if (result == null)
			{
				return;
			}
			ulong oldValue = ReadValue;
			ReadValue = ((ReadValueType)ValueType).ToValue(result);
			if(ReadValue==oldValue)
			{
				return;
			}
			foreach (Notifier notifier in Notifiers)
			{
				if(notifier.CompareValue(oldValue,ReadValue))
				{
					LogBuilder.AppendLine(string.Format("[{0}] : {1}", DateTime.Now.ToString(), notifier.GetCompareInfo(oldValue,ReadValue)));
					if(NotifierPriorityEnabled)
					{
						break;
					}
				}
			}
			ValueUpdated?.Invoke(this, oldValue,ReadValue);
		}

		private byte[] TryReadProcessMemory(IntPtr processHandle, long baseAddress, long targetAddress)
		{
			int outByteSize;

			if (Environment.Is64BitProcess)
			{
				var offset = baseAddress + (targetAddress - baseAddress);
				if (ReadProcessMemory(processHandle, offset, ReadBuffer, ReadBuffer.Length, out outByteSize))
				{
					return ReadBuffer;
				}
				else
				{
					return null;
				}
			}
			else
			{
				var offset = IntPtr.Add(new IntPtr(targetAddress - baseAddress), (int)baseAddress);
				if (ReadProcessMemory(processHandle, offset, ReadBuffer, ReadBuffer.Length, out outByteSize))
				{
					return ReadBuffer;
				}
				else
				{
					return null;
				}
			}
		}

		[DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		[DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, Int64 lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

	}
}
