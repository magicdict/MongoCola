namespace HRSystem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hiringTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCandidateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recylceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AppStatus = new System.Windows.Forms.StatusStrip();
            this.SystemStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnOrgnization = new System.Windows.Forms.Button();
            this.btnHiringTracking = new System.Windows.Forms.Button();
            this.ctlStatisticInfo1 = new HRSystem.UserController.ctlStatisticInfo();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.AppStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hiringTrackingToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.backUpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hiringTrackingToolStripMenuItem
            // 
            this.hiringTrackingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPositionToolStripMenuItem,
            this.viewManagerToolStripMenuItem});
            this.hiringTrackingToolStripMenuItem.Name = "hiringTrackingToolStripMenuItem";
            this.hiringTrackingToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.hiringTrackingToolStripMenuItem.Text = "Hiring Tracking";
            // 
            // newPositionToolStripMenuItem
            // 
            this.newPositionToolStripMenuItem.Name = "newPositionToolStripMenuItem";
            this.newPositionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newPositionToolStripMenuItem.Text = "New Position";
            this.newPositionToolStripMenuItem.Click += new System.EventHandler(this.newPositionToolStripMenuItem_Click);
            // 
            // viewManagerToolStripMenuItem
            // 
            this.viewManagerToolStripMenuItem.Name = "viewManagerToolStripMenuItem";
            this.viewManagerToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.viewManagerToolStripMenuItem.Text = "View Manager";
            this.viewManagerToolStripMenuItem.Click += new System.EventHandler(this.viewManagerToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weeklyInfoToolStripMenuItem,
            this.addCandidateToolStripMenuItem,
            this.recylceToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.viewToolStripMenuItem.Text = "Pipeline";
            // 
            // weeklyInfoToolStripMenuItem
            // 
            this.weeklyInfoToolStripMenuItem.Name = "weeklyInfoToolStripMenuItem";
            this.weeklyInfoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.weeklyInfoToolStripMenuItem.Text = "Weekly Info";
            this.weeklyInfoToolStripMenuItem.Click += new System.EventHandler(this.weeklyInfoToolStripMenuItem_Click);
            // 
            // addCandidateToolStripMenuItem
            // 
            this.addCandidateToolStripMenuItem.Name = "addCandidateToolStripMenuItem";
            this.addCandidateToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addCandidateToolStripMenuItem.Text = "Add Candidate";
            this.addCandidateToolStripMenuItem.Click += new System.EventHandler(this.addCandidateToolStripMenuItem_Click);
            // 
            // recylceToolStripMenuItem
            // 
            this.recylceToolStripMenuItem.Name = "recylceToolStripMenuItem";
            this.recylceToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.recylceToolStripMenuItem.Text = "Recylce";
            this.recylceToolStripMenuItem.Click += new System.EventHandler(this.recylceToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // AppStatus
            // 
            this.AppStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemStatus});
            this.AppStatus.Location = new System.Drawing.Point(0, 349);
            this.AppStatus.Name = "AppStatus";
            this.AppStatus.Size = new System.Drawing.Size(938, 22);
            this.AppStatus.TabIndex = 2;
            this.AppStatus.Text = "statusStrip1";
            // 
            // SystemStatus
            // 
            this.SystemStatus.Name = "SystemStatus";
            this.SystemStatus.Size = new System.Drawing.Size(77, 17);
            this.SystemStatus.Text = "SystemStatus";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(938, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnOrgnization);
            this.splitContainer1.Panel1.Controls.Add(this.btnHiringTracking);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ctlStatisticInfo1);
            this.splitContainer1.Size = new System.Drawing.Size(938, 300);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 4;
            // 
            // btnOrgnization
            // 
            this.btnOrgnization.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOrgnization.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOrgnization.Location = new System.Drawing.Point(0, 40);
            this.btnOrgnization.Name = "btnOrgnization";
            this.btnOrgnization.Size = new System.Drawing.Size(248, 44);
            this.btnOrgnization.TabIndex = 6;
            this.btnOrgnization.Text = "Orgnization";
            this.btnOrgnization.UseVisualStyleBackColor = false;
            // 
            // btnHiringTracking
            // 
            this.btnHiringTracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHiringTracking.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHiringTracking.Location = new System.Drawing.Point(0, 0);
            this.btnHiringTracking.Name = "btnHiringTracking";
            this.btnHiringTracking.Size = new System.Drawing.Size(248, 40);
            this.btnHiringTracking.TabIndex = 5;
            this.btnHiringTracking.Text = "Hiring Tracking";
            this.btnHiringTracking.UseVisualStyleBackColor = false;
            // 
            // ctlStatisticInfo1
            // 
            this.ctlStatisticInfo1.AutoScroll = true;
            this.ctlStatisticInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlStatisticInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctlStatisticInfo1.Name = "ctlStatisticInfo1";
            this.ctlStatisticInfo1.Size = new System.Drawing.Size(682, 298);
            this.ctlStatisticInfo1.TabIndex = 0;
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backUpToolStripMenuItem.Text = "BackUp";
            this.backUpToolStripMenuItem.Click += new System.EventHandler(this.backUpToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 371);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.AppStatus);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "[ApplicationName]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.MainFormResize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.AppStatus.ResumeLayout(false);
            this.AppStatus.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip AppStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel SystemStatus;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private UserController.ctlStatisticInfo ctlStatisticInfo1;
        private System.Windows.Forms.ToolStripMenuItem hiringTrackingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeklyInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCandidateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recylceToolStripMenuItem;
        private System.Windows.Forms.Button btnHiringTracking;
        private System.Windows.Forms.Button btnOrgnization;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
    }
}

