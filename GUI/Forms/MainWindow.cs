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
using AddresSound.Core;
using AddresSound.GUI.CustomControls;
using AddresSound.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddresSound.GUI.Forms
{
	public partial class MainWindow : Form
	{
		private ObservedProcess ObservedProcess { get; set; }
		private List<Observer> Observers { get; set; }
		private FileListCache RecentFiles { get; set; }
		private bool IsExistsObserver => Observers.Count > 0;
		private bool IsObservable => IsExistsObserver && ObservedProcess.IsOpened;

		public MainWindow()
		{
			InitializeComponent();
			Text = Application.ProductName;
			Icon = Resources.Icon;
			Observers = new List<Observer>();
			ObservedProcess = new ObservedProcess();
			ObservedProcess.ProcessExited += ObservedProcess_ProcessExited;
			RecentFiles = new FileListCache("recent",8,false);
			RefreshView();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			foreach (Observer observer in Observers)
			{
				observer.Dispose();
			}
			ObservedProcess.Dispose();
		}

		private void ObservedProcess_ProcessExited()
		{
			StopAllButton.PerformClick();
			using (var centerAligner = new DialogCenterAligner(this))
			{
				MessageBox.Show(Resources.ProcessHasExit, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			ProcessLabel.Text = ObservedProcess.ProcessInfo;
			RefreshView();
		}

		private void AddObserversToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new OpenFileDialog())
			{
				dialog.Title = Resources.Open;
				dialog.Filter = Resources.ObserversFileFilter;
				dialog.Multiselect = true;
				dialog.RestoreDirectory = true;
				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				foreach (string fileName in dialog.FileNames)
				{
					AddObserversFromFile(fileName);
				}
				RefreshView();
			}
		}

		private void SaveObserversToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new SaveFileDialog())
			{
				dialog.Title = Resources.Save;
				dialog.Filter = Resources.ObserversFileFilter;
				dialog.RestoreDirectory = true;
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					
					if (ObserversFile.Save(Observers, dialog.FileName))
					{
						if (!RecentFiles.Exists || RecentFiles.CanWrite)
						{
							RecentFiles.Add(dialog.FileName);
						}
					}
					else
					{
						using (var centerAligner = new DialogCenterAligner(this))
						{
							MessageBox.Show(Resources.FailedSaveFile, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
		}

		private void RecentFilesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			if (!RecentFiles.Exists || !RecentFiles.CanRead)
			{
				return;
			}
			RecentFilesToolStripMenuItem.DropDownItems.Clear();
			var files = RecentFiles.GetFiles();
			if (files.Count == 0)
			{
				RecentFilesToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem() { Text = Resources.None, Enabled = false });
			}
			else
			{
				files.Select(file => new ToolStripMenuItem()
				{
					Text = StringUtils.EllipsisBySeparator(file, "\\", 3),
					Enabled = File.Exists(file)
				})
				.ToList()
				.ForEach(menuItem =>
				{
					RecentFilesToolStripMenuItem.DropDownItems.Add(menuItem);
					menuItem.Click += RecentFileToolStripMenuItem_Click;
				});
			}
		}

		private void RecentFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var menuItem = sender as ToolStripMenuItem;
			int index = RecentFilesToolStripMenuItem.DropDownItems.IndexOf(menuItem);
			string filePath = RecentFiles.GetFile(index);
			AddObserversFromFile(filePath);
			RefreshView();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string path = Environment.CurrentDirectory + "/Docs/manual.html";
			if (File.Exists(path))
			{
				Process.Start(path);
			}
			else
			{
				using (var centerAligner = new DialogCenterAligner(this))
				{
					MessageBox.Show(this, Resources.FailedOpenFile, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var dialog = new AboutDialog())
			{
				dialog.ShowDialog();
			}
		}

		private void WrapperPanel_SizeChanged(object sender, EventArgs e)
		{
			var panel = sender as Panel;
			if (panel.Width < 784 || panel.Height < 667)
			{
				tableLayoutPanel1.Size = new Size(Math.Max(panel.Width - 20, 784), Math.Max(panel.Height - 20, 667));
				tableLayoutPanel1.Dock = DockStyle.None;
			}
			else
			{
				tableLayoutPanel1.Dock = DockStyle.Fill;
			}
		}

		private void SelectProcessButton_Click(object sender, EventArgs e)
		{
			using (var dialog=new SelectProcessDialog())
			{
				if(dialog.ShowDialog()!=DialogResult.OK)
				{
					return;
				}
				if(!ObservedProcess.Open(dialog.ProcessId))
				{
					using (var centerAligner = new DialogCenterAligner(this))
					{
						MessageBox.Show(Resources.ProcessOpenError,Resources.Error,MessageBoxButtons.OK,MessageBoxIcon.Error);
					}
				}
				ProcessLabel.Text = ObservedProcess.ProcessInfo;
				RefreshView();
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			var observer = new Observer(ObservedProcess);
			Observers.Add(observer);
			var observerTabPage = new ObserverTabPage(Observers.Count - 1, observer);
			ObserverTabControl.TabPages.Add(observerTabPage);
			ObserverTabControl.SelectedTab = observerTabPage;
			RefreshView();
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = ObserverTabControl.SelectedIndex;
			var selectedTabPage = ObserverTabControl.SelectedTab;
			foreach (Control control in selectedTabPage.Controls)
			{
				control.Dispose();
			}
			selectedTabPage.Dispose();
			ObserverTabControl.TabPages.Remove(selectedTabPage);
			Observers[selectedIndex].Dispose();
			Observers.RemoveAt(selectedIndex);
			if (Observers.Count > 0)
			{ 
				for (int i = 0; i < Observers.Count; i++)
				{
					((ObserverTabPage)ObserverTabControl.TabPages[i]).Index = i;
				}
				ObserverTabControl.SelectedTab = ObserverTabControl.TabPages[Math.Max(0, selectedIndex - 1)];
			}
			RefreshView();
		}

		private void StartAllButton_Click(object sender, EventArgs e)
		{
			foreach (Observer observer in Observers.Where(observer => !observer.IsObserving && observer.IsObservable))
			{
				observer.Start();
			}
		}

		private void StopAllButton_Click(object sender, EventArgs e)
		{
			foreach (Observer observer in Observers.Where(observer => observer.IsObserving))
			{
				observer.Stop();
			}
		}

		private void AddObserversFromFile(string path)
		{
			var observerSettingsList = ObserversFile.Load(path);
			if (observerSettingsList.Count == 0)
			{
				using (var centerAligner = new DialogCenterAligner(this))
				{
					MessageBox.Show(Resources.FailedOpenFile + "\n" + path, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				return;
			}
			if (!RecentFiles.Exists || RecentFiles.CanWrite)
			{
				RecentFiles.Add(path);
			}
			var tabPages = new TabPage[observerSettingsList.Count];
			for (int i = 0; i < observerSettingsList.Count; i++)
			{
				var observer = new Observer(ObservedProcess, observerSettingsList[i]);
				Observers.Add(observer);
				var observerTabPage = new ObserverTabPage(Observers.Count - 1, observer);
				tabPages[i] = observerTabPage;
			}
			ObserverTabControl.TabPages.AddRange(tabPages);
		}

		private void RefreshView()
		{
			bool isObservable = IsObservable;
			bool isExistsObserver = IsExistsObserver;
			StartAllButton.Enabled = isObservable;
			StopAllButton.Enabled = isObservable;
			RemoveButton.Enabled = isExistsObserver;
			ObserverTabControl.Visible = isExistsObserver;
			EmptyMessageLabel.Visible = !isExistsObserver;
			SaveObserversToolStripMenuItem.Enabled = isExistsObserver;
			
			Text = ProductName;
			if(ObservedProcess.IsOpened)
			{
				Text += " - "+ObservedProcess.Process.ProcessName;
			}
		}

		
	}
}
