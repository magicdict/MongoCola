using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl.Aggregation;

namespace FunctionForm.Aggregation
{
    partial class FrmStageBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabAggregation = new System.Windows.Forms.TabControl();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.btnClearMatch = new System.Windows.Forms.Button();
            this.btnAddMatch = new System.Windows.Forms.Button();
            this.tabGroup1 = new System.Windows.Forms.TabPage();
            this.lblID = new System.Windows.Forms.Label();
            this.tabGroup2 = new System.Windows.Forms.TabPage();
            this.btnClearGroupItem = new System.Windows.Forms.Button();
            this.cmdAddGroupItem = new System.Windows.Forms.Button();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkIndexStats = new System.Windows.Forms.CheckBox();
            this.chkSortByCount = new System.Windows.Forms.CheckBox();
            this.QueryFieldPicker = new MongoGUICtl.Aggregation.FieldPicker();
            this.MatchListPanel = new MongoGUICtl.Aggregation.MatchPanel();
            this.GroupFieldPicker = new MongoGUICtl.Aggregation.FieldPicker();
            this.groupPanelCreator = new MongoGUICtl.Aggregation.GroupPanel();
            this.cmbSortByCount = new System.Windows.Forms.ComboBox();
            this.tabAggregation.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.tabMatch.SuspendLayout();
            this.tabGroup1.SuspendLayout();
            this.tabGroup2.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAggregation
            // 
            this.tabAggregation.Controls.Add(this.tabProject);
            this.tabAggregation.Controls.Add(this.tabMatch);
            this.tabAggregation.Controls.Add(this.tabGroup1);
            this.tabAggregation.Controls.Add(this.tabGroup2);
            this.tabAggregation.Controls.Add(this.tabOption);
            this.tabAggregation.Location = new System.Drawing.Point(12, 11);
            this.tabAggregation.Name = "tabAggregation";
            this.tabAggregation.SelectedIndex = 0;
            this.tabAggregation.Size = new System.Drawing.Size(612, 327);
            this.tabAggregation.TabIndex = 0;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.QueryFieldPicker);
            this.tabProject.Location = new System.Drawing.Point(4, 22);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabProject.Size = new System.Drawing.Size(604, 301);
            this.tabProject.TabIndex = 0;
            this.tabProject.Text = "$project(Basic)";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // tabMatch
            // 
            this.tabMatch.Controls.Add(this.MatchListPanel);
            this.tabMatch.Controls.Add(this.btnClearMatch);
            this.tabMatch.Controls.Add(this.btnAddMatch);
            this.tabMatch.Location = new System.Drawing.Point(4, 22);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatch.Size = new System.Drawing.Size(604, 301);
            this.tabMatch.TabIndex = 2;
            this.tabMatch.Text = "$match";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // btnClearMatch
            // 
            this.btnClearMatch.Location = new System.Drawing.Point(101, 18);
            this.btnClearMatch.Name = "btnClearMatch";
            this.btnClearMatch.Size = new System.Drawing.Size(75, 21);
            this.btnClearMatch.TabIndex = 1;
            this.btnClearMatch.Text = "Clear";
            this.btnClearMatch.UseVisualStyleBackColor = true;
            this.btnClearMatch.Click += new System.EventHandler(this.btnClearMatch_Click);
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Location = new System.Drawing.Point(20, 18);
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(75, 21);
            this.btnAddMatch.TabIndex = 0;
            this.btnAddMatch.Text = "Add";
            this.btnAddMatch.UseVisualStyleBackColor = true;
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // tabGroup1
            // 
            this.tabGroup1.Controls.Add(this.GroupFieldPicker);
            this.tabGroup1.Controls.Add(this.lblID);
            this.tabGroup1.Location = new System.Drawing.Point(4, 22);
            this.tabGroup1.Name = "tabGroup1";
            this.tabGroup1.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup1.Size = new System.Drawing.Size(604, 301);
            this.tabGroup1.TabIndex = 3;
            this.tabGroup1.Text = "$group1";
            this.tabGroup1.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(24, 15);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(161, 12);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID (group by fields below)";
            // 
            // tabGroup2
            // 
            this.tabGroup2.Controls.Add(this.btnClearGroupItem);
            this.tabGroup2.Controls.Add(this.cmdAddGroupItem);
            this.tabGroup2.Controls.Add(this.groupPanelCreator);
            this.tabGroup2.Location = new System.Drawing.Point(4, 22);
            this.tabGroup2.Name = "tabGroup2";
            this.tabGroup2.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup2.Size = new System.Drawing.Size(604, 301);
            this.tabGroup2.TabIndex = 4;
            this.tabGroup2.Text = "$group2";
            this.tabGroup2.UseVisualStyleBackColor = true;
            // 
            // btnClearGroupItem
            // 
            this.btnClearGroupItem.Location = new System.Drawing.Point(451, 6);
            this.btnClearGroupItem.Name = "btnClearGroupItem";
            this.btnClearGroupItem.Size = new System.Drawing.Size(116, 32);
            this.btnClearGroupItem.TabIndex = 7;
            this.btnClearGroupItem.Text = "Clear";
            this.btnClearGroupItem.UseVisualStyleBackColor = true;
            this.btnClearGroupItem.Click += new System.EventHandler(this.btnClearGroupItem_Click);
            // 
            // cmdAddGroupItem
            // 
            this.cmdAddGroupItem.Location = new System.Drawing.Point(316, 6);
            this.cmdAddGroupItem.Name = "cmdAddGroupItem";
            this.cmdAddGroupItem.Size = new System.Drawing.Size(129, 32);
            this.cmdAddGroupItem.TabIndex = 6;
            this.cmdAddGroupItem.Text = "Add GroupItem";
            this.cmdAddGroupItem.UseVisualStyleBackColor = true;
            this.cmdAddGroupItem.Click += new System.EventHandler(this.cmdAddGroupItem_Click);
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.cmbSortByCount);
            this.tabOption.Controls.Add(this.chkSortByCount);
            this.tabOption.Controls.Add(this.chkIndexStats);
            this.tabOption.Controls.Add(this.txtSkip);
            this.tabOption.Controls.Add(this.txtLimit);
            this.tabOption.Controls.Add(this.chkSkip);
            this.tabOption.Controls.Add(this.chkLimit);
            this.tabOption.Location = new System.Drawing.Point(4, 22);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(604, 301);
            this.tabOption.TabIndex = 1;
            this.tabOption.Text = "$Options";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // txtSkip
            // 
            this.txtSkip.Location = new System.Drawing.Point(134, 37);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(91, 21);
            this.txtSkip.TabIndex = 29;
            this.txtSkip.Text = "1";
            this.txtSkip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(134, 14);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(91, 21);
            this.txtLimit.TabIndex = 28;
            this.txtLimit.Text = "1";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Location = new System.Drawing.Point(26, 40);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(54, 16);
            this.chkSkip.TabIndex = 1;
            this.chkSkip.Text = "$skip";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // chkLimit
            // 
            this.chkLimit.AutoSize = true;
            this.chkLimit.Location = new System.Drawing.Point(26, 16);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(60, 16);
            this.chkLimit.TabIndex = 0;
            this.chkLimit.Text = "$limit";
            this.chkLimit.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 354);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 35);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(332, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkIndexStats
            // 
            this.chkIndexStats.AutoSize = true;
            this.chkIndexStats.Location = new System.Drawing.Point(26, 62);
            this.chkIndexStats.Name = "chkIndexStats";
            this.chkIndexStats.Size = new System.Drawing.Size(90, 16);
            this.chkIndexStats.TabIndex = 30;
            this.chkIndexStats.Text = "$indexStats";
            this.chkIndexStats.UseVisualStyleBackColor = true;
            // 
            // chkSortByCount
            // 
            this.chkSortByCount.AutoSize = true;
            this.chkSortByCount.Location = new System.Drawing.Point(26, 85);
            this.chkSortByCount.Name = "chkSortByCount";
            this.chkSortByCount.Size = new System.Drawing.Size(96, 16);
            this.chkSortByCount.TabIndex = 31;
            this.chkSortByCount.Text = "$sortByCount";
            this.chkSortByCount.UseVisualStyleBackColor = true;
            // 
            // QueryFieldPicker
            // 
            this.QueryFieldPicker.AutoScroll = true;
            this.QueryFieldPicker.BackColor = System.Drawing.Color.White;
            this.QueryFieldPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryFieldPicker.FieldListMode = MongoGUICtl.Aggregation.CtlFieldInfo.FieldMode.Aggregation;
            this.QueryFieldPicker.IsIdProtect = false;
            this.QueryFieldPicker.Location = new System.Drawing.Point(3, 3);
            this.QueryFieldPicker.Name = "QueryFieldPicker";
            this.QueryFieldPicker.Size = new System.Drawing.Size(598, 295);
            this.QueryFieldPicker.TabIndex = 1;
            // 
            // MatchListPanel
            // 
            this.MatchListPanel.AutoScroll = true;
            this.MatchListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MatchListPanel.Location = new System.Drawing.Point(3, 43);
            this.MatchListPanel.Name = "MatchListPanel";
            this.MatchListPanel.Size = new System.Drawing.Size(598, 255);
            this.MatchListPanel.TabIndex = 2;
            // 
            // GroupFieldPicker
            // 
            this.GroupFieldPicker.AutoScroll = true;
            this.GroupFieldPicker.BackColor = System.Drawing.Color.White;
            this.GroupFieldPicker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupFieldPicker.FieldListMode = MongoGUICtl.Aggregation.CtlFieldInfo.FieldMode.Aggregation;
            this.GroupFieldPicker.IsIdProtect = false;
            this.GroupFieldPicker.Location = new System.Drawing.Point(3, 31);
            this.GroupFieldPicker.Name = "GroupFieldPicker";
            this.GroupFieldPicker.Size = new System.Drawing.Size(598, 267);
            this.GroupFieldPicker.TabIndex = 3;
            // 
            // groupPanelCreator
            // 
            this.groupPanelCreator.AutoScroll = true;
            this.groupPanelCreator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanelCreator.Location = new System.Drawing.Point(3, 44);
            this.groupPanelCreator.Name = "groupPanelCreator";
            this.groupPanelCreator.Size = new System.Drawing.Size(598, 254);
            this.groupPanelCreator.TabIndex = 3;
            // 
            // cmbSortByCount
            // 
            this.cmbSortByCount.FormattingEnabled = true;
            this.cmbSortByCount.Location = new System.Drawing.Point(134, 83);
            this.cmbSortByCount.Name = "cmbSortByCount";
            this.cmbSortByCount.Size = new System.Drawing.Size(121, 20);
            this.cmbSortByCount.TabIndex = 32;
            // 
            // FrmStageBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 401);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabAggregation);
            this.Name = "FrmStageBuilder";
            this.Text = "Stage Builder";
            this.Load += new System.EventHandler(this.frmAggregationCondition_Load);
            this.tabAggregation.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.tabMatch.ResumeLayout(false);
            this.tabGroup1.ResumeLayout(false);
            this.tabGroup1.PerformLayout();
            this.tabGroup2.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.tabOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabAggregation;
        private TabPage tabProject;
        private FieldPicker QueryFieldPicker;
        private TabPage tabOption;
        private TabPage tabMatch;
        private Button btnOK;
        private CheckBox chkSkip;
        private CheckBox chkLimit;
        private TextBox txtSkip;
        private TextBox txtLimit;
        private TabPage tabGroup1;
        private Label lblID;
        private FieldPicker GroupFieldPicker;
        private Button btnClearMatch;
        private Button btnAddMatch;
        private MatchPanel MatchListPanel;
        private Button btnCancel;
        private TabPage tabGroup2;
        private Button btnClearGroupItem;
        private Button cmdAddGroupItem;
        private GroupPanel groupPanelCreator;
        private CheckBox chkIndexStats;
        private CheckBox chkSortByCount;
        private ComboBox cmbSortByCount;
    }
}