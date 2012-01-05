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
            this.lstSrvOpr = new System.Windows.Forms.ListView();
            this.lstDBStatus = new System.Windows.Forms.ListView();
            this.tabSvrStatus = new System.Windows.Forms.TabControl();
            this.tabSvrBasicInfo = new System.Windows.Forms.TabPage();
            this.trvSvrStatus = new System.Windows.Forms.TreeView();
            this.tabDBBasicInfo = new System.Windows.Forms.TabPage();
            this.tabCollectionInfo = new System.Windows.Forms.TabPage();
            this.lstCollectionStatus = new System.Windows.Forms.ListView();
            this.tabClusterInfo = new System.Windows.Forms.TabPage();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.tabSvrStatus.SuspendLayout();
            this.tabSvrBasicInfo.SuspendLayout();
            this.tabDBBasicInfo.SuspendLayout();
            this.tabCollectionInfo.SuspendLayout();
            this.tabClusterInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSrvOpr
            // 
            this.lstSrvOpr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSrvOpr.FullRowSelect = true;
            this.lstSrvOpr.GridLines = true;
            this.lstSrvOpr.Location = new System.Drawing.Point(3, 3);
            this.lstSrvOpr.Name = "lstSrvOpr";
            this.lstSrvOpr.Size = new System.Drawing.Size(910, 444);
            this.lstSrvOpr.TabIndex = 3;
            this.lstSrvOpr.UseCompatibleStateImageBehavior = false;
            this.lstSrvOpr.View = System.Windows.Forms.View.Details;
            // 
            // lstDBStatus
            // 
            this.lstDBStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDBStatus.FullRowSelect = true;
            this.lstDBStatus.GridLines = true;
            this.lstDBStatus.Location = new System.Drawing.Point(3, 3);
            this.lstDBStatus.Name = "lstDBStatus";
            this.lstDBStatus.Size = new System.Drawing.Size(910, 446);
            this.lstDBStatus.TabIndex = 2;
            this.lstDBStatus.UseCompatibleStateImageBehavior = false;
            this.lstDBStatus.View = System.Windows.Forms.View.Details;
            // 
            // tabSvrStatus
            // 
            this.tabSvrStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSvrStatus.Controls.Add(this.tabSvrBasicInfo);
            this.tabSvrStatus.Controls.Add(this.tabDBBasicInfo);
            this.tabSvrStatus.Controls.Add(this.tabCollectionInfo);
            this.tabSvrStatus.Controls.Add(this.tabClusterInfo);
            this.tabSvrStatus.Location = new System.Drawing.Point(13, 23);
            this.tabSvrStatus.Name = "tabSvrStatus";
            this.tabSvrStatus.SelectedIndex = 0;
            this.tabSvrStatus.Size = new System.Drawing.Size(924, 478);
            this.tabSvrStatus.TabIndex = 5;
            // 
            // tabSvrBasicInfo
            // 
            this.tabSvrBasicInfo.Controls.Add(this.trvSvrStatus);
            this.tabSvrBasicInfo.Location = new System.Drawing.Point(4, 24);
            this.tabSvrBasicInfo.Name = "tabSvrBasicInfo";
            this.tabSvrBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSvrBasicInfo.Size = new System.Drawing.Size(916, 450);
            this.tabSvrBasicInfo.TabIndex = 3;
            this.tabSvrBasicInfo.Text = "Server Status Information[need manual refresh ]";
            this.tabSvrBasicInfo.UseVisualStyleBackColor = true;
            // 
            // trvSvrStatus
            // 
            this.trvSvrStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvSvrStatus.Location = new System.Drawing.Point(3, 3);
            this.trvSvrStatus.Name = "trvSvrStatus";
            this.trvSvrStatus.Size = new System.Drawing.Size(910, 444);
            this.trvSvrStatus.TabIndex = 0;
            // 
            // tabDBBasicInfo
            // 
            this.tabDBBasicInfo.Controls.Add(this.lstDBStatus);
            this.tabDBBasicInfo.Location = new System.Drawing.Point(4, 24);
            this.tabDBBasicInfo.Name = "tabDBBasicInfo";
            this.tabDBBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBBasicInfo.Size = new System.Drawing.Size(916, 450);
            this.tabDBBasicInfo.TabIndex = 0;
            this.tabDBBasicInfo.Text = "DB Status Information";
            this.tabDBBasicInfo.UseVisualStyleBackColor = true;
            // 
            // tabCollectionInfo
            // 
            this.tabCollectionInfo.Controls.Add(this.lstCollectionStatus);
            this.tabCollectionInfo.Location = new System.Drawing.Point(4, 24);
            this.tabCollectionInfo.Name = "tabCollectionInfo";
            this.tabCollectionInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCollectionInfo.Size = new System.Drawing.Size(916, 450);
            this.tabCollectionInfo.TabIndex = 2;
            this.tabCollectionInfo.Text = "Collection Status Information";
            this.tabCollectionInfo.UseVisualStyleBackColor = true;
            // 
            // lstCollectionStatus
            // 
            this.lstCollectionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCollectionStatus.FullRowSelect = true;
            this.lstCollectionStatus.GridLines = true;
            this.lstCollectionStatus.Location = new System.Drawing.Point(3, 3);
            this.lstCollectionStatus.Name = "lstCollectionStatus";
            this.lstCollectionStatus.Size = new System.Drawing.Size(910, 446);
            this.lstCollectionStatus.TabIndex = 2;
            this.lstCollectionStatus.UseCompatibleStateImageBehavior = false;
            this.lstCollectionStatus.View = System.Windows.Forms.View.Details;
            // 
            // tabClusterInfo
            // 
            this.tabClusterInfo.Controls.Add(this.lstSrvOpr);
            this.tabClusterInfo.Location = new System.Drawing.Point(4, 24);
            this.tabClusterInfo.Name = "tabClusterInfo";
            this.tabClusterInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabClusterInfo.Size = new System.Drawing.Size(916, 450);
            this.tabClusterInfo.TabIndex = 1;
            this.tabClusterInfo.Text = "Cluster Information";
            this.tabClusterInfo.UseVisualStyleBackColor = true;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.Location = new System.Drawing.Point(811, 5);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(117, 37);
            this.cmdRefresh.TabIndex = 5;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // frmServiceStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 522);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.tabSvrStatus);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmServiceStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServiceStatus_FormClosing);
            this.Load += new System.EventHandler(this.frmServiceStatus_Load);
            this.tabSvrStatus.ResumeLayout(false);
            this.tabSvrBasicInfo.ResumeLayout(false);
            this.tabDBBasicInfo.ResumeLayout(false);
            this.tabCollectionInfo.ResumeLayout(false);
            this.tabClusterInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.ListView lstSrvOpr;
        private System.Windows.Forms.ListView lstDBStatus;
        private System.Windows.Forms.TabControl tabSvrStatus;
        private System.Windows.Forms.TabPage tabDBBasicInfo;
        private System.Windows.Forms.TabPage tabClusterInfo;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.TabPage tabCollectionInfo;
        private System.Windows.Forms.ListView lstCollectionStatus;
        private System.Windows.Forms.TabPage tabSvrBasicInfo;
        private System.Windows.Forms.TreeView trvSvrStatus;
    }
}