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
using AddresSound.GUI.Forms;
using AddresSound.Properties;

namespace AddresSound.GUI.UserControls
{
	public partial class NotifierListView : UserControl
	{
		private Observer Observer { get; set; }

		public NotifierListView()
		{
			InitializeComponent();
			NotifierItemView.ConditionChange += NotifierItemView_ConditionChange;
			NotifierItemView.SpecifiedValueChange += NotifierItemView_SpecifiedValueChange;
		}

		public void SetObserver(Observer observer)
		{
			Observer = observer;
			Observer.Started += Observer_Started;
			Observer.Stopped += Observer_Stopped;
			PriorityCheckBox.Checked = Observer.NotifierPriorityEnabled;
			RefreshItems();
			if (Observer.NotifierCount > 0)
			{
				NotifierSettingListView.SelectItem(0);
			}
			else
			{
				UnselectedNotifierLabel.Visible = true;
				NotifierItemView.Visible = false;
			}

		}

		private void Observer_Started(Observer obj)
		{
			PriorityCheckBox.Enabled = false;
			NotifierSettingListView.Enabled = false;
			AddButton.Enabled = false;
			//EditButton.Enabled = false;
			RemoveButton.Enabled = false;
			UpPriorityButton.Enabled = false;
			DownPriorityButton.Enabled = false;
			NotifierItemView.Enabled = false;
		}

		private void Observer_Stopped(Observer obj)
		{
			PriorityCheckBox.Enabled = true;
			NotifierSettingListView.Enabled =true;
			AddButton.Enabled = true;
			//EditButton.Enabled = NotifierSettingListView.IsSelected;
			RemoveButton.Enabled = NotifierSettingListView.IsSelected;
			NotifierItemView.Enabled = true;
			if (RemoveButton.Enabled)
			{
				UpPriorityButton.Enabled = NotifierSettingListView.SelectedIndex > 0;
				DownPriorityButton.Enabled = NotifierSettingListView.SelectedIndex < NotifierSettingListView.Items.Count - 1;
			}
			else
			{
				UpPriorityButton.Enabled = false;
				DownPriorityButton.Enabled = false;
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			var notifier = new Notifier();
			Observer.AddNotifier(notifier);
			RefreshItems();
			NotifierSettingListView.SelectItem(Observer.NotifierCount - 1);
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = NotifierSettingListView.SelectedItems[0].Index;
			Observer.RemoveNotifier(selectedIndex);
			NotifierSettingListView.Items.RemoveAt(selectedIndex);
			RefreshItems();
			if (Observer.NotifierCount > 0)
			{
				selectedIndex = Math.Max(0, selectedIndex - 1);
				NotifierSettingListView.SelectItem(selectedIndex);
			}
		}

		private void UpPriorityButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = NotifierSettingListView.SelectedIndex;
			Observer.SwapNotifierPriority(selectedIndex,selectedIndex - 1);
			RefreshItems();
			NotifierSettingListView.SelectItem(selectedIndex - 1);
		}

		private void DownPriorityButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = NotifierSettingListView.SelectedIndex;
			Observer.SwapNotifierPriority(selectedIndex,selectedIndex + 1);
			RefreshItems();
			NotifierSettingListView.SelectItem(selectedIndex + 1);
		}

		private void NotifierSettingListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			var listView = (ListView)sender;
			if (listView.SelectedItems.Count <= 0)
			{
				//EditButton.Enabled = false;
				RemoveButton.Enabled = false;
				UpPriorityButton.Enabled = false;
				DownPriorityButton.Enabled = false;
				UnselectedNotifierLabel.Visible = true;
				ItemGroupBox.Text = "";
				NotifierItemView.Visible = false;
			}
			else
			{
				int selectedIndex = listView.SelectedItems[0].Index;
				//EditButton.Enabled = true;
				RemoveButton.Enabled = true;
				UpPriorityButton.Enabled = selectedIndex > 0;
				DownPriorityButton.Enabled = selectedIndex < listView.Items.Count - 1;
				UnselectedNotifierLabel.Visible = false;
				ItemGroupBox.Text = Resources.Priority + " : " + selectedIndex.ToString();
				NotifierItemView.Visible = true;
				NotifierItemView.Reset(Observer.GetNotifier(selectedIndex));
			}
		}

		private void NotifierSettingListView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			int selectedIndex = e.Item.Index;
			Observer.GetNotifier(selectedIndex).Enabled = e.Item.Checked;
		}

		private void PriorityCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			Observer.NotifierPriorityEnabled = PriorityCheckBox.Checked;
		}

		private void NotifierItemView_SpecifiedValueChange(Notifier notifier, ulong specifiedValue)
		{
			RefreshItem(notifier);
		}

		private void NotifierItemView_ConditionChange(Notifier notifier, Condition condition)
		{
			RefreshItem(notifier);
		}

		private void RefreshItems()
		{
			NotifierSettingListView.SelectedIndexChanged -= NotifierSettingListView_SelectedIndexChanged;
			int itemCount = NotifierSettingListView.Items.Count;
			int valueNotifiersCount = Observer.NotifierCount;
			if (itemCount != valueNotifiersCount)
			{
				NotifierSettingListView.ItemChecked -= NotifierSettingListView_ItemChecked;
				if (itemCount < valueNotifiersCount)
				{
					while (NotifierSettingListView.Items.Count < valueNotifiersCount)
					{
						NotifierSettingListView.Items.Add(new ListViewItem(new string[3]));
					}
				}
				else
				{
					while (NotifierSettingListView.Items.Count > valueNotifiersCount)
					{
						NotifierSettingListView.Items.RemoveAt(0);
					}
				}
				NotifierSettingListView.ItemChecked += NotifierSettingListView_ItemChecked;
			}

			foreach (var valueNotifier in Observer.Notifiers)
			{
				RefreshItem(valueNotifier);
			}
			NotifierSettingListView.SelectedIndexChanged += NotifierSettingListView_SelectedIndexChanged;
		}

		private void RefreshItem(Notifier notifier)
		{
			int index = Observer.GetNotifierPriority(notifier);
			ListViewItem item = NotifierSettingListView.Items[index];
			item.SubItems[0].Text = index.ToString();
			item.SubItems[1].Text = notifier.Condition.GetConditionName();
			item.SubItems[2].Text = notifier.SpecifiedValue.ToString();
			item.Checked = notifier.Enabled;
		}
	}
}
