using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl.Aggregation;

namespace FunctionForm.Aggregation
{
    partial class FrmAggregationCondition
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
            this.QueryFieldPicker = new FieldPicker();
            this.tabMatch = new System.Windows.Forms.TabPage();
            this.btnClearMatch = new System.Windows.Forms.Button();
            this.btnAddMatch = new System.Windows.Forms.Button();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmdAddGroupItem = new System.Windows.Forms.Button();
            this.GroupFieldPicker = new FieldPicker();
            this.groupPanelCreator = new GroupPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.txtSkip = new System.Windows.Forms.TextBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.MatchListPanel = new MatchPanel();
            this.tabAggregation.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.tabMatch.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabAggregation
            // 
            this.tabAggregation.Controls.Add(this.tabProject);
            this.tabAggregation.Controls.Add(this.tabMatch);
            this.tabAggregation.Controls.Add(this.tabGroup);
            this.tabAggregation.Controls.Add(this.tabOption);
            this.tabAggregation.Location = new System.Drawing.Point(12, 12);
            this.tabAggregation.Name = "tabAggregation";
            this.tabAggregation.SelectedIndex = 0;
            this.tabAggregation.Size = new System.Drawing.Size(612, 354);
            this.tabAggregation.TabIndex = 0;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.QueryFieldPicker);
            this.tabProject.Location = new System.Drawing.Point(4, 22);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabProject.Size = new System.Drawing.Size(604, 328);
            this.tabProject.TabIndex = 0;
            this.tabProject.Text = "$project(Basic)";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // QueryFieldPicker
            // 
            this.QueryFieldPicker.AutoScroll = true;
            this.QueryFieldPicker.BackColor = System.Drawing.Color.White;
            this.QueryFieldPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryFieldPicker.FieldListMode = CtlFieldInfo.FieldMode.FieldProject;
            this.QueryFieldPicker.IsIdProtect = false;
            this.QueryFieldPicker.Location = new System.Drawing.Point(3, 3);
            this.QueryFieldPicker.Name = "QueryFieldPicker";
            this.QueryFieldPicker.Size = new System.Drawing.Size(598, 322);
            this.QueryFieldPicker.TabIndex = 1;
            // 
            // tabMatch
            // 
            this.tabMatch.Controls.Add(this.MatchListPanel);
            this.tabMatch.Controls.Add(this.btnClearMatch);
            this.tabMatch.Controls.Add(this.btnAddMatch);
            this.tabMatch.Location = new System.Drawing.Point(4, 22);
            this.tabMatch.Name = "tabMatch";
            this.tabMatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatch.Size = new System.Drawing.Size(604, 328);
            this.tabMatch.TabIndex = 2;
            this.tabMatch.Text = "$match";
            this.tabMatch.UseVisualStyleBackColor = true;
            // 
            // btnClearMatch
            // 
            this.btnClearMatch.Location = new System.Drawing.Point(101, 20);
            this.btnClearMatch.Name = "btnClearMatch";
            this.btnClearMatch.Size = new System.Drawing.Size(75, 23);
            this.btnClearMatch.TabIndex = 1;
            this.btnClearMatch.Text = "Clear";
            this.btnClearMatch.UseVisualStyleBackColor = true;
            this.btnClearMatch.Click += new System.EventHandler(this.btnClearMatch_Click);
            // 
            // btnAddMatch
            // 
            this.btnAddMatch.Location = new System.Drawing.Point(20, 20);
            this.btnAddMatch.Name = "btnAddMatch";
            this.btnAddMatch.Size = new System.Drawing.Size(75, 23);
            this.btnAddMatch.TabIndex = 0;
            this.btnAddMatch.Text = "Add";
            this.btnAddMatch.UseVisualStyleBackColor = true;
            this.btnAddMatch.Click += new System.EventHandler(this.btnAddMatch_Click);
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.btnClear);
            this.tabGroup.Controls.Add(this.cmdAddGroupItem);
            this.tabGroup.Controls.Add(this.GroupFieldPicker);
            this.tabGroup.Controls.Add(this.groupPanelCreator);
            this.tabGroup.Controls.Add(this.lblID);
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(604, 328);
            this.tabGroup.TabIndex = 3;
            this.tabGroup.Text = "$group";
            this.tabGroup.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(134, 173);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmdAddGroupItem
            // 
            this.cmdAddGroupItem.Location = new System.Drawing.Point(40, 173);
            this.cmdAddGroupItem.Name = "cmdAddGroupItem";
            this.cmdAddGroupItem.Size = new System.Drawing.Size(88, 23);
            this.cmdAddGroupItem.TabIndex = 4;
            this.cmdAddGroupItem.Text = "Add GroupItem";
            this.cmdAddGroupItem.UseVisualStyleBackColor = true;
            this.cmdAddGroupItem.Click += new System.EventHandler(this.cmdAddGroupItem_Click);
            // 
            // GroupFieldPicker
            // 
            this.GroupFieldPicker.AutoScroll = true;
            this.GroupFieldPicker.BackColor = System.Drawing.Color.White;
            this.GroupFieldPicker.FieldListMode = CtlFieldInfo.FieldMode.FieldProject;
            this.GroupFieldPicker.IsIdProtect = false;
            this.GroupFieldPicker.Location = new System.Drawing.Point(6, 30);
            this.GroupFieldPicker.Name = "GroupFieldPicker";
            this.GroupFieldPicker.Size = new System.Drawing.Size(592, 137);
            this.GroupFieldPicker.TabIndex = 3;
            // 
            // groupPanelCreator
            // 
            this.groupPanelCreator.AutoScroll = true;
            this.groupPanelCreator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanelCreator.Location = new System.Drawing.Point(3, 196);
            this.groupPanelCreator.Name = "groupPanelCreator";
            this.groupPanelCreator.Size = new System.Drawing.Size(598, 129);
            this.groupPanelCreator.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 14);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(126, 13);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID (group by fields below)";
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.txtSkip);
            this.tabOption.Controls.Add(this.txtLimit);
            this.tabOption.Controls.Add(this.chkSkip);
            this.tabOption.Controls.Add(this.chkLimit);
            this.tabOption.Location = new System.Drawing.Point(4, 22);
            this.tabOption.Name = "tabOption";
            this.tabOption.Padding = new System.Windows.Forms.Padding(3);
            this.tabOption.Size = new System.Drawing.Size(604, 328);
            this.tabOption.TabIndex = 1;
            this.tabOption.Text = "Options";
            this.tabOption.UseVisualStyleBackColor = true;
            // 
            // txtSkip
            // 
            this.txtSkip.Location = new System.Drawing.Point(81, 37);
            this.txtSkip.Name = "txtSkip";
            this.txtSkip.Size = new System.Drawing.Size(135, 20);
            this.txtSkip.TabIndex = 29;
            this.txtSkip.Text = "1";
            this.txtSkip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(81, 15);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(135, 20);
            this.txtLimit.TabIndex = 28;
            this.txtLimit.Text = "1";
            this.txtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Location = new System.Drawing.Point(26, 40);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(51, 17);
            this.chkSkip.TabIndex = 1;
            this.chkSkip.Text = "$skip";
            this.chkSkip.UseVisualStyleBackColor = true;
            // 
            // chkLimit
            // 
            this.chkLimit.AutoSize = true;
            this.chkLimit.Location = new System.Drawing.Point(26, 17);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(49, 17);
            this.chkLimit.TabIndex = 0;
            this.chkLimit.Text = "$limit";
            this.chkLimit.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(542, 377);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // MatchListPanel
            // 
            this.MatchListPanel.AutoScroll = true;
            this.MatchListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MatchListPanel.Location = new System.Drawing.Point(3, 49);
            this.MatchListPanel.Name = "MatchListPanel";
            this.MatchListPanel.Size = new System.Drawing.Size(598, 276);
            this.MatchListPanel.TabIndex = 2;
            // 
            // frmAggregationCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(636, 412);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabAggregation);
            this.Name = "FrmAggregationCondition";
            this.Text = "Aggregation Condition Builder";
            this.Load += new System.EventHandler(this.frmAggregationCondition_Load);
            this.tabAggregation.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.tabMatch.ResumeLayout(false);
            this.tabGroup.ResumeLayout(false);
            this.tabGroup.PerformLayout();
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
        private TabPage tabGroup;
        private Label lblID;
        private GroupPanel groupPanelCreator;
        private FieldPicker GroupFieldPicker;
        private Button btnClear;
        private Button cmdAddGroupItem;
        private Button btnClearMatch;
        private Button btnAddMatch;
        private MatchPanel MatchListPanel;


    }
}