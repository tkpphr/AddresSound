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
using AddresSound.Properties;

namespace AddresSound.GUI.UserControls
{
	public partial class NotifierItemView : UserControl
	{
		private Notifier Notifier { get; set; }
		public event Action<Notifier,Condition> ConditionChange;
		public event Action<Notifier,ulong> SpecifiedValueChange;

		public NotifierItemView()
		{
			InitializeComponent();
			ConditionComboBox.Items.AddRange(ConditionUtils.GetConditionNames());
			SpecifiedValueUpDown.Maximum = long.MaxValue;
		}

		public void Reset(Notifier notifier)
		{
			Notifier?.StopAllSound();
			Notifier = notifier;
			ConditionComboBox.SelectedIndexChanged -= ConditionComboBox_SelectedIndexChanged;
			ConditionComboBox.SelectedIndex = (int)Notifier.Condition;
			ConditionComboBox.SelectedIndexChanged += ConditionComboBox_SelectedIndexChanged;
			SpecifiedValueUpDown.ValueChanged -= SpecifiedValueUpDown_ValueChanged;
			SpecifiedValueUpDown.Value = Notifier.SpecifiedValue;
			SpecifiedValueUpDown.ValueChanged += SpecifiedValueUpDown_ValueChanged;
			PlaySoundButton.Enabled = false;
			StopSoundButton.Enabled = false;
			SoundListView.SelectedIndexChanged -= SoundListView_SelectedIndexChanged;
			SoundListView.Items.Clear();
			foreach (string soundPath in Notifier.SoundPaths)
			{
				SoundListView.Items.Add(StringUtils.EllipsisBySeparator(soundPath, "\\", 3));
			}
			SoundListView.SelectedIndexChanged += SoundListView_SelectedIndexChanged;
			if (Notifier.SoundPaths.Count > 0)
			{
				SoundListView.SelectItem(0);
			}
		}

		private void ConditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Notifier.Condition = (Condition)ConditionComboBox.SelectedIndex;
			ConditionChange?.Invoke(Notifier,Notifier.Condition);
		}

		private void SpecifiedValueUpDown_ValueChanged(object sender, EventArgs e)
		{
			Notifier.SpecifiedValue = (ulong)decimal.ToInt64(SpecifiedValueUpDown.Value);
			SpecifiedValueChange?.Invoke(Notifier,Notifier.SpecifiedValue);
		}

		private void AddSoundButton_Click(object sender, EventArgs e)
		{
			Notifier.StopAllSound();
			using (var dialog = new OpenFileDialog())
			{
				dialog.Title = Resources.Open;
				dialog.Filter = Resources.WaveFileFilter;
				dialog.Multiselect = true;
				dialog.RestoreDirectory = true;
				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				foreach (string fileName in dialog.FileNames)
				{
					Notifier.AddSound(fileName);
					SoundListView.Items.Add(StringUtils.EllipsisBySeparator(fileName, "\\", 3));
				}
				SoundListView.SelectItem(SoundListView.Items.Count - 1);
			}
		}

		private void RemoveSoundButton_Click(object sender, EventArgs e)
		{
			Notifier.StopAllSound();
			int selectedIndex = SoundListView.SelectedIndex;
			SoundListView.Items.RemoveAt(selectedIndex);
			Notifier.RemoveSound(selectedIndex);
			if (SoundListView.Items.Count > 0)
			{
				SoundListView.SelectItem(Math.Max(0, selectedIndex - 1));
			}
			else
			{
				RemoveSoundButton.Enabled = false;
			}
		}

		private void PlaySoundButton_Click(object sender, EventArgs e)
		{
			if (SoundListView.IsSelected)
			{
				Notifier.PlaySound(SoundListView.SelectedIndex);
			}
		}

		private void StopSoundButton_Click(object sender, EventArgs e)
		{
			if (SoundListView.IsSelected)
			{
				Notifier.StopSound(SoundListView.SelectedIndex);
			}
		}

		private void SoundListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			Notifier.StopAllSound();
			if (SoundListView.IsSelected)
			{
				RemoveSoundButton.Enabled = true;
				PlaySoundButton.Enabled = true;
				StopSoundButton.Enabled = true;
			}
			else
			{
				RemoveSoundButton.Enabled = false; 
				PlaySoundButton.Enabled = false;
				StopSoundButton.Enabled = false;
			}
		}

		private void SoundListView_DoubleClick(object sender, EventArgs e)
		{
			if (SoundListView.IsSelected)
			{
				Notifier.PlaySound(SoundListView.SelectedIndex);
			}
		}

		
	}
}
