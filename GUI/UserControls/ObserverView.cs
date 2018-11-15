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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddresSound.Core;
using System.Diagnostics;
using AddresSound.Properties;
using System.IO;

namespace AddresSound.GUI.UserControls
{
	public partial class ObserverView : UserControl
	{
		private Observer Observer { get; set; }
		public event Action<string> TitleChanged;

		private ObserverView()
		{
			InitializeComponent();
			ReadValueTypeComboBox.Items.AddRange(ReadValueTypeConstants.ValueTypeNames);
		}

		public ObserverView(Observer observer)
			: this()
		{
			Observer = observer;
			Observer.Started += Observer_Started;
			Observer.Stopped += Observer_Stopped;
			Observer.ValueUpdated += Observer_ValueUpdated;
			Observer.ProcessOpened += Observer_ProcessOpened;
			Observer.ProcessExited += Observer_ProcessExited;
			NotifierListView.SetObserver(observer);
			RefreshView();
		}

		private void Observer_Started(Observer observer)
		{
			RefreshView();
			UpdateLog();
		}

		private void Observer_Stopped(Observer observer)
		{
			RefreshView();
			UpdateLog();
		}

		private void Observer_ValueUpdated(Observer arg1, ulong oldValue, ulong newValue)
		{
			UpdateLog();
		}

		private void Observer_ProcessOpened(Observer observer, Process process, IntPtr processHandle)
		{
			StartButton.Enabled = Observer.IsObservable;
		}

		private void Observer_ProcessExited(Observer observer)
		{
			StartButton.Enabled = Observer.IsObservable;
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			Observer.Start();
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			Observer.Stop();
		}

		private void TitleTextBox_TextChanged(object sender, EventArgs e)
		{
			Observer.Title = TitleTextBox.Text;
			TitleChanged?.Invoke(TitleTextBox.Text);
		}

		private void AddressTextBox_TextChanged(object sender, EventArgs e)
		{
			Observer.TargetAddress = AddressTextBox.Text;
			StartButton.Enabled = Observer.IsValidTargetAddress;
		}

		private void ReadTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Observer.ValueType = ReadValueTypeComboBox.SelectedIndex;
			
		}

		private void UpdateIntervalUpDown_ValueChanged(object sender, EventArgs e)
		{
			Observer.UpdateInterval = decimal.ToInt32(UpdateIntervalUpDown.Value);
		}

		private void WordWrapCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			LogTextBox.WordWrap = WordWrapCheckBox.Checked;
		}

		private void SaveLogButton_Click(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog())
			{
				dialog.Title = Resources.Save;
				dialog.Filter = Resources.LogFileFilter;
				dialog.RestoreDirectory = true;
				dialog.FileName = Observer.Title;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					try
					{
						File.WriteAllText(dialog.FileName, Observer.Log);
					}
					catch (Exception exception)
					{
						Console.WriteLine(exception);
						using (var centerAligner = new DialogCenterAligner(ParentForm))
						{
							MessageBox.Show(Resources.FailedSaveFile, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void ClearLogButton_Click(object sender, EventArgs e)
		{
			Observer.ClearLog();
			UpdateLog();
		}

		private void RefreshView()
		{
			if(Observer.IsObserving)
			{
				StopButton.Enabled = true;
				StartButton.Enabled = false;
				TitleTextBox.Enabled = false;
				AddressTextBox.Enabled = false;
				ReadValueTypeComboBox.Enabled = false;
				UpdateIntervalUpDown.Enabled = false;
			}
			else
			{
				StopButton.Enabled = false;
				StartButton.Enabled = true;
				TitleTextBox.Enabled = true;
				AddressTextBox.Enabled = true;
				ReadValueTypeComboBox.Enabled = true;
				UpdateIntervalUpDown.Enabled = true;
				TitleTextBox.Text = Observer.Title;
				AddressTextBox.Text = Observer.TargetAddress;
				ReadValueTypeComboBox.SelectedIndex = Observer.ValueType;
				UpdateIntervalUpDown.Value = Observer.UpdateInterval;
				if (Observer.IsObservable)
				{
					StartButton.Enabled = true;
					StopButton.Enabled = false;
				}
				else
				{
					StartButton.Enabled = false;
					StopButton.Enabled = false;
				}
			}
		}

		private void UpdateLog()
		{
			LogTextBox.Text = Observer.Log;
			LogTextBox.SelectionStart = LogTextBox.TextLength;
			LogTextBox.ScrollToCaret();
		}

		
	}
}
