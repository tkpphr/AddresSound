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
using AddrSound.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddresSound.Core
{
	public class Notifier : IDisposable
	{
		public Condition Condition { get; set; }
		public ulong SpecifiedValue { get; set; }
		public bool Enabled { get; set; }
		public List<string> SoundPaths => Sounds.Select(sound=>sound.SoundPath).ToList();
		private List<ALSound> Sounds { get; set; }
		private static readonly Random Random = new Random();

		public Notifier() 
			: this(new NotifierSettings() { Condition=(int)Condition.Equals , SpecifiedValue=0, Enabled=true,SoundPaths=new List<string>()})
		{
		
		}

		public Notifier(NotifierSettings settings)
		{
			Condition = (Condition)settings.Condition;
			SpecifiedValue = settings.SpecifiedValue;
			Enabled = settings.Enabled;
			Sounds = new List<ALSound>();
			foreach (string soundPath in settings.SoundPaths)
			{
				AddSound(soundPath);
			}
		}

		public void Dispose()
		{
			foreach(ALSound sound in Sounds)
			{
				sound.Stop();
				sound.Dispose();
			}
			Sounds.Clear();
		}

		public void AddSound(string path)
		{
			Sounds.Add(new ALSound(path));
		}

		public void RemoveSound(int i)
		{
			Sounds[i].Dispose();
			Sounds.RemoveAt(i);
		}

		public void PlaySound(int i)
		{
			Sounds[i].Play();
		}

		public void StopSound(int i)
		{
			Sounds[i].Stop();
		}

		public void StopAllSound()
		{
			foreach(ALSound sound in Sounds)
			{
				sound.Stop();
			}
		}
		

		public bool CompareValue(ulong oldValue,ulong newValue)
		{
			if(!Enabled)
			{
				return false;
			}

			if(Condition.Compare(oldValue, newValue, SpecifiedValue))
			{
				if(Sounds.Count > 0)
				{
					PlaySound(Random.Next(Sounds.Count));
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public string GetCompareInfo(ulong oldValue, ulong newValue)
		{
			return Condition.GetCompareInfo(oldValue,newValue,SpecifiedValue);
		}


	}
}
