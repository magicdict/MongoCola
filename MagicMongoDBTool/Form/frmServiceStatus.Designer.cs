namespace MagicMongoDBTool
{
    partial class frmServiceStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceStatus));
            this.lstSrvOpr = new System.Windows.Forms.ListView();
            this.lstSrvStatus = new System.Windows.Forms.ListView();
            this.tabSvrStatus = new System.Windows.Forms.TabControl();
            this.tabSvrInfo = new System.Windows.Forms.TabPage();
            this.tabReplInfo = new System.Windows.Forms.TabPage();
            this.tabDBInfo = new System.Windows.Forms.TabPage();
            this.lstDBStatus = new System.Windows.Forms.ListView();
            this.cmdRefresh = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            this.tabSvrStatus.SuspendLayout();
            this.tabSvrInfo.SuspendLayout();
            this.tabReplInfo.SuspendLayout();
            this.tabDBInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdRefresh);
            this.contentPanel.Controls.Add(this.tabSvrStatus);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(806, 404);
            // 
            // lstSrvOpr
            // 
            this.lstSrvOpr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSrvOpr.FullRowSelect = true;
            this.lstSrvOpr.GridLines = true;
            this.lstSrvOpr.Location = new System.Drawing.Point(3, 3);
            this.lstSrvOpr.Name = "lstSrvOpr";
            this.lstSrvOpr.Size = new System.Drawing.Size(778, 339);
            this.lstSrvOpr.TabIndex = 3;
            this.lstSrvOpr.UseCompatibleStateImageBehavior = false;
            this.lstSrvOpr.View = System.Windows.Forms.View.Details;
            // 
            // lstSrvStatus
            // 
            this.lstSrvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSrvStatus.FullRowSelect = true;
            this.lstSrvStatus.GridLines = true;
            this.lstSrvStatus.Location = new System.Drawing.Point(3, 3);
            this.lstSrvStatus.Name = "lstSrvStatus";
            this.lstSrvStatus.Size = new System.Drawing.Size(778, 339);
            this.lstSrvStatus.TabIndex = 2;
            this.lstSrvStatus.UseCompatibleStateImageBehavior = false;
            this.lstSrvStatus.View = System.Windows.Forms.View.Details;
            // 
            // tabSvrStatus
            // 
            this.tabSvrStatus.Controls.Add(this.tabSvrInfo);
            this.tabSvrStatus.Controls.Add(this.tabDBInfo);
            this.tabSvrStatus.Controls.Add(this.tabReplInfo);
            this.tabSvrStatus.Location = new System.Drawing.Point(11, 20);
            this.tabSvrStatus.Name = "tabSvrStatus";
            this.tabSvrStatus.SelectedIndex = 0;
            this.tabSvrStatus.Size = new System.Drawing.Size(792, 371);
            this.tabSvrStatus.TabIndex = 5;
            // 
            // tabSvrInfo
            // 
            this.tabSvrInfo.Controls.Add(this.lstSrvStatus);
            this.tabSvrInfo.Location = new System.Drawing.Point(4, 22);
            this.tabSvrInfo.Name = "tabSvrInfo";
            this.tabSvrInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSvrInfo.Size = new System.Drawing.Size(784, 345);
            this.tabSvrInfo.TabIndex = 0;
            this.tabSvrInfo.Text = "服务器基本信息";
            this.tabSvrInfo.UseVisualStyleBackColor = true;
            // 
            // tabReplInfo
            // 
            this.tabReplInfo.Controls.Add(this.lstSrvOpr);
            this.tabReplInfo.Location = new System.Drawing.Point(4, 22);
            this.tabReplInfo.Name = "tabReplInfo";
            this.tabReplInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabReplInfo.Size = new System.Drawing.Size(784, 345);
            this.tabReplInfo.TabIndex = 1;
            this.tabReplInfo.Text = "集群扩展信息";
            this.tabReplInfo.UseVisualStyleBackColor = true;
            // 
            // tabDBInfo
            // 
            this.tabDBInfo.Controls.Add(this.lstDBStatus);
            this.tabDBInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDBInfo.Name = "tabDBInfo";
            this.tabDBInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBInfo.Size = new System.Drawing.Size(784, 345);
            this.tabDBInfo.TabIndex = 2;
            this.tabDBInfo.Text = "各数据库状态";
            this.tabDBInfo.UseVisualStyleBackColor = true;
            // 
            // lstDBStatus
            // 
            this.lstDBStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDBStatus.FullRowSelect = true;
            this.lstDBStatus.GridLines = true;
            this.lstDBStatus.Location = new System.Drawing.Point(3, 3);
            this.lstDBStatus.Name = "lstDBStatus";
            this.lstDBStatus.Size = new System.Drawing.Size(778, 339);
            this.lstDBStatus.TabIndex = 2;
            this.lstDBStatus.UseCompatibleStateImageBehavior = false;
            this.lstDBStatus.View = System.Windows.Forms.View.Details;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.Location = new System.Drawing.Point(695, 4);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(100, 32);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.Text = "刷新";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // frmServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 467);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmServiceStatus";
            this.ShowSelectSkinButton = false;
            this.Text = "服务器状态";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServiceStatus_FormClosing);
            this.Load += new System.EventHandler(this.frmServiceStatus_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabSvrStatus.ResumeLayout(false);
            this.tabSvrInfo.ResumeLayout(false);
            this.tabReplInfo.ResumeLayout(false);
            this.tabDBInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.ListView lstSrvOpr;
        private System.Windows.Forms.ListView lstSrvStatus;
        private System.Windows.Forms.TabControl tabSvrStatus;
        private System.Windows.Forms.TabPage tabSvrInfo;
        private System.Windows.Forms.TabPage tabReplInfo;
        private System.Windows.Forms.VistaButton cmdRefresh;
        private System.Windows.Forms.TabPage tabDBInfo;
        private System.Windows.Forms.ListView lstDBStatus;
    }
}