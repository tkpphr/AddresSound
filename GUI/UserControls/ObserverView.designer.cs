namespace AddresSound.GUI.UserControls
{
	partial class ObserverView
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObserverView));
			this.StopButton = new System.Windows.Forms.Button();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.StartButton = new System.Windows.Forms.Button();
			this.LogGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.ClearLogButton = new System.Windows.Forms.Button();
			this.SaveLogButton = new System.Windows.Forms.Button();
			this.WordWrapCheckBox = new System.Windows.Forms.CheckBox();
			this.LogTextBox = new System.Windows.Forms.TextBox();
			this.AddressLabel = new System.Windows.Forms.Label();
			this.UpdateIntervalLabel = new System.Windows.Forms.Label();
			this.ReadValueTypeLabel = new System.Windows.Forms.Label();
			this.ObsrverGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.AddressTextBox = new AddresSound.GUI.CustomControls.HexTextBox();
			this.UpdateIntervalUpDown = new System.Windows.Forms.NumericUpDown();
			this.ReadValueTypeComboBox = new System.Windows.Forms.ComboBox();
			this.NotifierListView = new AddresSound.GUI.UserControls.NotifierListView();
			this.CompareTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.UnitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.LogGroupBox.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.ObsrverGroupBox.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// StopButton
			// 
			resources.ApplyResources(this.StopButton, "StopButton");
			this.StopButton.Name = "StopButton";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// TitleLabel
			// 
			resources.ApplyResources(this.TitleLabel, "TitleLabel");
			this.TitleLabel.Name = "TitleLabel";
			// 
			// StartButton
			// 
			resources.ApplyResources(this.StartButton, "StartButton");
			this.StartButton.Name = "StartButton";
			this.StartButton.UseVisualStyleBackColor = true;
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// LogGroupBox
			// 
			resources.ApplyResources(this.LogGroupBox, "LogGroupBox");
			this.LogGroupBox.Controls.Add(this.tableLayoutPanel3);
			this.LogGroupBox.Name = "LogGroupBox";
			this.LogGroupBox.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.LogTextBox, 0, 1);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.ClearLogButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.SaveLogButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.WordWrapCheckBox, 0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// ClearLogButton
			// 
			resources.ApplyResources(this.ClearLogButton, "ClearLogButton");
			this.ClearLogButton.Name = "ClearLogButton";
			this.ClearLogButton.UseVisualStyleBackColor = true;
			this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
			// 
			// SaveLogButton
			// 
			resources.ApplyResources(this.SaveLogButton, "SaveLogButton");
			this.SaveLogButton.Name = "SaveLogButton";
			this.SaveLogButton.UseVisualStyleBackColor = true;
			this.SaveLogButton.Click += new System.EventHandler(this.SaveLogButton_Click);
			// 
			// WordWrapCheckBox
			// 
			resources.ApplyResources(this.WordWrapCheckBox, "WordWrapCheckBox");
			this.WordWrapCheckBox.Name = "WordWrapCheckBox";
			this.WordWrapCheckBox.UseVisualStyleBackColor = true;
			this.WordWrapCheckBox.CheckedChanged += new System.EventHandler(this.WordWrapCheckBox_CheckedChanged);
			// 
			// LogTextBox
			// 
			resources.ApplyResources(this.LogTextBox, "LogTextBox");
			this.LogTextBox.Name = "LogTextBox";
			// 
			// AddressLabel
			// 
			resources.ApplyResources(this.AddressLabel, "AddressLabel");
			this.AddressLabel.Name = "AddressLabel";
			// 
			// UpdateIntervalLabel
			// 
			resources.ApplyResources(this.UpdateIntervalLabel, "UpdateIntervalLabel");
			this.UpdateIntervalLabel.Name = "UpdateIntervalLabel";
			// 
			// ReadValueTypeLabel
			// 
			resources.ApplyResources(this.ReadValueTypeLabel, "ReadValueTypeLabel");
			this.ReadValueTypeLabel.Name = "ReadValueTypeLabel";
			// 
			// ObsrverGroupBox
			// 
			resources.ApplyResources(this.ObsrverGroupBox, "ObsrverGroupBox");
			this.ObsrverGroupBox.Controls.Add(this.tableLayoutPanel4);
			this.ObsrverGroupBox.Name = "ObsrverGroupBox";
			this.ObsrverGroupBox.TabStop = false;
			// 
			// tableLayoutPanel4
			// 
			resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
			this.tableLayoutPanel4.Controls.Add(this.LogGroupBox, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			// 
			// tableLayoutPanel5
			// 
			resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
			this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.NotifierListView, 0, 1);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			// 
			// panel1
			// 
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Controls.Add(this.StartButton);
			this.panel1.Controls.Add(this.StopButton);
			this.panel1.Controls.Add(this.tableLayoutPanel1);
			this.panel1.Name = "panel1";
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.TitleLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.TitleTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.AddressTextBox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.UpdateIntervalLabel, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.UpdateIntervalUpDown, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.AddressLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.ReadValueTypeLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.ReadValueTypeComboBox, 1, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// TitleTextBox
			// 
			resources.ApplyResources(this.TitleTextBox, "TitleTextBox");
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.TextChanged += new System.EventHandler(this.TitleTextBox_TextChanged);
			// 
			// AddressTextBox
			// 
			resources.ApplyResources(this.AddressTextBox, "AddressTextBox");
			this.AddressTextBox.Name = "AddressTextBox";
			this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
			// 
			// UpdateIntervalUpDown
			// 
			resources.ApplyResources(this.UpdateIntervalUpDown, "UpdateIntervalUpDown");
			this.UpdateIntervalUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.UpdateIntervalUpDown.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.UpdateIntervalUpDown.Name = "UpdateIntervalUpDown";
			this.UpdateIntervalUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.UpdateIntervalUpDown.ValueChanged += new System.EventHandler(this.UpdateIntervalUpDown_ValueChanged);
			// 
			// ReadValueTypeComboBox
			// 
			resources.ApplyResources(this.ReadValueTypeComboBox, "ReadValueTypeComboBox");
			this.ReadValueTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ReadValueTypeComboBox.FormattingEnabled = true;
			this.ReadValueTypeComboBox.Name = "ReadValueTypeComboBox";
			this.ReadValueTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ReadTypeComboBox_SelectedIndexChanged);
			// 
			// NotifierListView
			// 
			resources.ApplyResources(this.NotifierListView, "NotifierListView");
			this.NotifierListView.Name = "NotifierListView";
			// 
			// CompareTypeColumnHeader
			// 
			resources.ApplyResources(this.CompareTypeColumnHeader, "CompareTypeColumnHeader");
			// 
			// ValueColumnHeader
			// 
			resources.ApplyResources(this.ValueColumnHeader, "ValueColumnHeader");
			// 
			// UnitColumnHeader
			// 
			resources.ApplyResources(this.UnitColumnHeader, "UnitColumnHeader");
			// 
			// CountColumnHeader
			// 
			resources.ApplyResources(this.CountColumnHeader, "CountColumnHeader");
			// 
			// ObserverView
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ObsrverGroupBox);
			this.Name = "ObserverView";
			this.LogGroupBox.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ObsrverGroupBox.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.GroupBox LogGroupBox;
		private System.Windows.Forms.TextBox LogTextBox;
		
		private System.Windows.Forms.Label AddressLabel;
		private System.Windows.Forms.Label UpdateIntervalLabel;
		private System.Windows.Forms.Label ReadValueTypeLabel;
		private System.Windows.Forms.Button ClearLogButton;
		private System.Windows.Forms.GroupBox ObsrverGroupBox;
		private System.Windows.Forms.Button SaveLogButton;
		private System.Windows.Forms.CheckBox WordWrapCheckBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox TitleTextBox;
		private CustomControls.HexTextBox AddressTextBox;
		private System.Windows.Forms.NumericUpDown UpdateIntervalUpDown;
		private System.Windows.Forms.ComboBox ReadValueTypeComboBox;
		private System.Windows.Forms.ColumnHeader CompareTypeColumnHeader;
		private System.Windows.Forms.ColumnHeader ValueColumnHeader;
		private System.Windows.Forms.ColumnHeader UnitColumnHeader;
		private System.Windows.Forms.ColumnHeader CountColumnHeader;
		private NotifierListView NotifierListView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
	}
}
