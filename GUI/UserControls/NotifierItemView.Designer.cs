namespace AddresSound.GUI.UserControls
{
	partial class NotifierItemView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifierItemView));
			this.SoundsGroupBox = new System.Windows.Forms.GroupBox();
			this.StopSoundButton = new System.Windows.Forms.Button();
			this.PlaySoundButton = new System.Windows.Forms.Button();
			this.SoundListView = new AddresSound.GUI.CustomControls.SingleSelectListView();
			this.PathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.AddSoundButton = new System.Windows.Forms.Button();
			this.RemoveSoundButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ConditionLabel = new System.Windows.Forms.Label();
			this.ConditionComboBox = new System.Windows.Forms.ComboBox();
			this.SpecifiedValueLabel = new System.Windows.Forms.Label();
			this.SpecifiedValueUpDown = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.SoundsGroupBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpecifiedValueUpDown)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// SoundsGroupBox
			// 
			this.SoundsGroupBox.Controls.Add(this.StopSoundButton);
			this.SoundsGroupBox.Controls.Add(this.PlaySoundButton);
			this.SoundsGroupBox.Controls.Add(this.SoundListView);
			this.SoundsGroupBox.Controls.Add(this.AddSoundButton);
			this.SoundsGroupBox.Controls.Add(this.RemoveSoundButton);
			resources.ApplyResources(this.SoundsGroupBox, "SoundsGroupBox");
			this.SoundsGroupBox.Name = "SoundsGroupBox";
			this.SoundsGroupBox.TabStop = false;
			// 
			// StopSoundButton
			// 
			resources.ApplyResources(this.StopSoundButton, "StopSoundButton");
			this.StopSoundButton.Name = "StopSoundButton";
			this.StopSoundButton.UseVisualStyleBackColor = true;
			this.StopSoundButton.Click += new System.EventHandler(this.StopSoundButton_Click);
			// 
			// PlaySoundButton
			// 
			resources.ApplyResources(this.PlaySoundButton, "PlaySoundButton");
			this.PlaySoundButton.Name = "PlaySoundButton";
			this.PlaySoundButton.UseVisualStyleBackColor = true;
			this.PlaySoundButton.Click += new System.EventHandler(this.PlaySoundButton_Click);
			// 
			// SoundListView
			// 
			this.SoundListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PathColumnHeader});
			this.SoundListView.FullRowSelect = true;
			this.SoundListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.SoundListView.HideSelection = false;
			resources.ApplyResources(this.SoundListView, "SoundListView");
			this.SoundListView.MultiSelect = false;
			this.SoundListView.Name = "SoundListView";
			this.SoundListView.UseCompatibleStateImageBehavior = false;
			this.SoundListView.View = System.Windows.Forms.View.Details;
			this.SoundListView.SelectedIndexChanged += new System.EventHandler(this.SoundListView_SelectedIndexChanged);
			// 
			// PathColumnHeader
			// 
			resources.ApplyResources(this.PathColumnHeader, "PathColumnHeader");
			// 
			// AddSoundButton
			// 
			resources.ApplyResources(this.AddSoundButton, "AddSoundButton");
			this.AddSoundButton.Name = "AddSoundButton";
			this.AddSoundButton.UseVisualStyleBackColor = true;
			this.AddSoundButton.Click += new System.EventHandler(this.AddSoundButton_Click);
			// 
			// RemoveSoundButton
			// 
			resources.ApplyResources(this.RemoveSoundButton, "RemoveSoundButton");
			this.RemoveSoundButton.Name = "RemoveSoundButton";
			this.RemoveSoundButton.UseVisualStyleBackColor = true;
			this.RemoveSoundButton.Click += new System.EventHandler(this.RemoveSoundButton_Click);
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.ConditionLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.ConditionComboBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.SpecifiedValueLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.SpecifiedValueUpDown, 1, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// ConditionLabel
			// 
			resources.ApplyResources(this.ConditionLabel, "ConditionLabel");
			this.ConditionLabel.Name = "ConditionLabel";
			// 
			// ConditionComboBox
			// 
			this.ConditionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ConditionComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.ConditionComboBox, "ConditionComboBox");
			this.ConditionComboBox.Name = "ConditionComboBox";
			this.ConditionComboBox.SelectedIndexChanged += new System.EventHandler(this.ConditionComboBox_SelectedIndexChanged);
			// 
			// SpecifiedValueLabel
			// 
			resources.ApplyResources(this.SpecifiedValueLabel, "SpecifiedValueLabel");
			this.SpecifiedValueLabel.Name = "SpecifiedValueLabel";
			// 
			// SpecifiedValueUpDown
			// 
			resources.ApplyResources(this.SpecifiedValueUpDown, "SpecifiedValueUpDown");
			this.SpecifiedValueUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.SpecifiedValueUpDown.Name = "SpecifiedValueUpDown";
			this.SpecifiedValueUpDown.ValueChanged += new System.EventHandler(this.SpecifiedValueUpDown_ValueChanged);
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.SoundsGroupBox, 0, 1);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// NotifierItemView
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel2);
			this.Name = "NotifierItemView";
			this.SoundsGroupBox.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpecifiedValueUpDown)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox SoundsGroupBox;
		private CustomControls.SingleSelectListView SoundListView;
		private System.Windows.Forms.ColumnHeader PathColumnHeader;
		private System.Windows.Forms.Button AddSoundButton;
		private System.Windows.Forms.Button RemoveSoundButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label ConditionLabel;
		private System.Windows.Forms.ComboBox ConditionComboBox;
		private System.Windows.Forms.Label SpecifiedValueLabel;
		private System.Windows.Forms.NumericUpDown SpecifiedValueUpDown;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button StopSoundButton;
		private System.Windows.Forms.Button PlaySoundButton;
	}
}
