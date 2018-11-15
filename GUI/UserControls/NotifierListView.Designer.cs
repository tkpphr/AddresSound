namespace AddresSound.GUI.UserControls
{
	partial class NotifierListView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifierListView));
			this.MainGroupBox = new System.Windows.Forms.GroupBox();
			this.ItemGroupBox = new System.Windows.Forms.GroupBox();
			this.UnselectedNotifierLabel = new System.Windows.Forms.Label();
			this.NotifierItemView = new AddresSound.GUI.UserControls.NotifierItemView();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.PriorityCheckBox = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.AddButton = new System.Windows.Forms.Button();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.UpPriorityButton = new System.Windows.Forms.Button();
			this.DownPriorityButton = new System.Windows.Forms.Button();
			this.NotifierSettingListView = new AddresSound.GUI.CustomControls.SingleSelectListView();
			this.PriorityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ConditionTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SpecifiedValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MainGroupBox.SuspendLayout();
			this.ItemGroupBox.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainGroupBox
			// 
			this.MainGroupBox.Controls.Add(this.ItemGroupBox);
			this.MainGroupBox.Controls.Add(this.tableLayoutPanel2);
			this.MainGroupBox.Controls.Add(this.NotifierSettingListView);
			resources.ApplyResources(this.MainGroupBox, "MainGroupBox");
			this.MainGroupBox.Name = "MainGroupBox";
			this.MainGroupBox.TabStop = false;
			// 
			// ItemGroupBox
			// 
			this.ItemGroupBox.Controls.Add(this.UnselectedNotifierLabel);
			this.ItemGroupBox.Controls.Add(this.NotifierItemView);
			resources.ApplyResources(this.ItemGroupBox, "ItemGroupBox");
			this.ItemGroupBox.Name = "ItemGroupBox";
			this.ItemGroupBox.TabStop = false;
			// 
			// UnselectedNotifierLabel
			// 
			resources.ApplyResources(this.UnselectedNotifierLabel, "UnselectedNotifierLabel");
			this.UnselectedNotifierLabel.Name = "UnselectedNotifierLabel";
			// 
			// NotifierItemView
			// 
			resources.ApplyResources(this.NotifierItemView, "NotifierItemView");
			this.NotifierItemView.Name = "NotifierItemView";
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.PriorityCheckBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// PriorityCheckBox
			// 
			resources.ApplyResources(this.PriorityCheckBox, "PriorityCheckBox");
			this.PriorityCheckBox.Name = "PriorityCheckBox";
			this.PriorityCheckBox.UseVisualStyleBackColor = true;
			this.PriorityCheckBox.CheckedChanged += new System.EventHandler(this.PriorityCheckBox_CheckedChanged);
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.AddButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.RemoveButton, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.UpPriorityButton, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.DownPriorityButton, 3, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			// 
			// AddButton
			// 
			resources.ApplyResources(this.AddButton, "AddButton");
			this.AddButton.Name = "AddButton";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// RemoveButton
			// 
			resources.ApplyResources(this.RemoveButton, "RemoveButton");
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// UpPriorityButton
			// 
			resources.ApplyResources(this.UpPriorityButton, "UpPriorityButton");
			this.UpPriorityButton.Name = "UpPriorityButton";
			this.UpPriorityButton.UseVisualStyleBackColor = true;
			this.UpPriorityButton.Click += new System.EventHandler(this.UpPriorityButton_Click);
			// 
			// DownPriorityButton
			// 
			resources.ApplyResources(this.DownPriorityButton, "DownPriorityButton");
			this.DownPriorityButton.Name = "DownPriorityButton";
			this.DownPriorityButton.UseVisualStyleBackColor = true;
			this.DownPriorityButton.Click += new System.EventHandler(this.DownPriorityButton_Click);
			// 
			// NotifierSettingListView
			// 
			this.NotifierSettingListView.CheckBoxes = true;
			this.NotifierSettingListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PriorityColumnHeader,
            this.ConditionTypeColumnHeader,
            this.SpecifiedValueColumnHeader});
			this.NotifierSettingListView.FullRowSelect = true;
			this.NotifierSettingListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.NotifierSettingListView.HideSelection = false;
			resources.ApplyResources(this.NotifierSettingListView, "NotifierSettingListView");
			this.NotifierSettingListView.MultiSelect = false;
			this.NotifierSettingListView.Name = "NotifierSettingListView";
			this.NotifierSettingListView.UseCompatibleStateImageBehavior = false;
			this.NotifierSettingListView.View = System.Windows.Forms.View.Details;
			this.NotifierSettingListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.NotifierSettingListView_ItemChecked);
			this.NotifierSettingListView.SelectedIndexChanged += new System.EventHandler(this.NotifierSettingListView_SelectedIndexChanged);
			// 
			// PriorityColumnHeader
			// 
			resources.ApplyResources(this.PriorityColumnHeader, "PriorityColumnHeader");
			// 
			// ConditionTypeColumnHeader
			// 
			resources.ApplyResources(this.ConditionTypeColumnHeader, "ConditionTypeColumnHeader");
			// 
			// SpecifiedValueColumnHeader
			// 
			resources.ApplyResources(this.SpecifiedValueColumnHeader, "SpecifiedValueColumnHeader");
			// 
			// NotifierListView
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainGroupBox);
			this.Name = "NotifierListView";
			this.MainGroupBox.ResumeLayout(false);
			this.ItemGroupBox.ResumeLayout(false);
			this.ItemGroupBox.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox MainGroupBox;
		private System.Windows.Forms.CheckBox PriorityCheckBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button DownPriorityButton;
		private System.Windows.Forms.Button UpPriorityButton;
		private System.Windows.Forms.Button RemoveButton;
		private CustomControls.SingleSelectListView NotifierSettingListView;
		private System.Windows.Forms.ColumnHeader ConditionTypeColumnHeader;
		private System.Windows.Forms.ColumnHeader SpecifiedValueColumnHeader;
		private System.Windows.Forms.GroupBox ItemGroupBox;
		private System.Windows.Forms.Label UnselectedNotifierLabel;
		private NotifierItemView NotifierItemView;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.ColumnHeader PriorityColumnHeader;
	}
}
