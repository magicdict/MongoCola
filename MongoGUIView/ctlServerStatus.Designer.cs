using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace MongoGUIView
{
    partial class CtlServerStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlServerStatus));
            this.tabSvrStatus = new System.Windows.Forms.TabControl();
            this.tabSvrBasicInfo = new System.Windows.Forms.TabPage();
            this.trvSvrStatus = new MongoGUICtl.CtlTreeViewColumns();
            this.tabDBBasicInfo = new System.Windows.Forms.TabPage();
            this.tabCollectionInfo = new System.Windows.Forms.TabPage();
            this.tabCurrentOprInfo = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RefreshStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExpandAllStripButton = new System.Windows.Forms.ToolStripButton();
            this.CollapseAllStripButton = new System.Windows.Forms.ToolStripButton();
            this.btnSwitch = new System.Windows.Forms.ToolStripButton();
            this.CloseStripButton = new System.Windows.Forms.ToolStripButton();
            this.lstSrvOpr = new System.Windows.Forms.ListView();
            this.trvDBStatus = new MongoGUICtl.CtlTreeViewColumns();
            this.trvColStatus = new MongoGUICtl.CtlTreeViewColumns();
            this.tabSvrStatus.SuspendLayout();
            this.tabSvrBasicInfo.SuspendLayout();
            this.tabDBBasicInfo.SuspendLayout();
            this.tabCollectionInfo.SuspendLayout();
            this.tabCurrentOprInfo.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSvrStatus
            // 
            this.tabSvrStatus.Controls.Add(this.tabSvrBasicInfo);
            this.tabSvrStatus.Controls.Add(this.tabDBBasicInfo);
            this.tabSvrStatus.Controls.Add(this.tabCollectionInfo);
            this.tabSvrStatus.Controls.Add(this.tabCurrentOprInfo);
            this.tabSvrStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSvrStatus.Location = new System.Drawing.Point(0, 25);
            this.tabSvrStatus.Name = "tabSvrStatus";
            this.tabSvrStatus.SelectedIndex = 0;
            this.tabSvrStatus.Size = new System.Drawing.Size(887, 397);
            this.tabSvrStatus.TabIndex = 6;
            // 
            // tabSvrBasicInfo
            // 
            this.tabSvrBasicInfo.Controls.Add(this.trvSvrStatus);
            this.tabSvrBasicInfo.Location = new System.Drawing.Point(4, 22);
            this.tabSvrBasicInfo.Name = "tabSvrBasicInfo";
            this.tabSvrBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSvrBasicInfo.Size = new System.Drawing.Size(879, 371);
            this.tabSvrBasicInfo.TabIndex = 3;
            this.tabSvrBasicInfo.Tag = "ServiceStatus_ServerInfo";
            this.tabSvrBasicInfo.Text = "Server Status[manually Refresh]";
            this.tabSvrBasicInfo.UseVisualStyleBackColor = true;
            // 
            // trvSvrStatus
            // 
            this.trvSvrStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvSvrStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvSvrStatus.Location = new System.Drawing.Point(3, 3);
            this.trvSvrStatus.Name = "trvSvrStatus";
            this.trvSvrStatus.Padding = new System.Windows.Forms.Padding(1);
            this.trvSvrStatus.Size = new System.Drawing.Size(873, 365);
            this.trvSvrStatus.TabIndex = 0;
            // 
            // tabDBBasicInfo
            // 
            this.tabDBBasicInfo.Controls.Add(this.trvDBStatus);
            this.tabDBBasicInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDBBasicInfo.Name = "tabDBBasicInfo";
            this.tabDBBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBBasicInfo.Size = new System.Drawing.Size(879, 371);
            this.tabDBBasicInfo.TabIndex = 0;
            this.tabDBBasicInfo.Tag = "ServiceStatus_DataBaseInfo";
            this.tabDBBasicInfo.Text = "DB Status";
            this.tabDBBasicInfo.UseVisualStyleBackColor = true;
            // 
            // tabCollectionInfo
            // 
            this.tabCollectionInfo.Controls.Add(this.trvColStatus);
            this.tabCollectionInfo.Location = new System.Drawing.Point(4, 22);
            this.tabCollectionInfo.Name = "tabCollectionInfo";
            this.tabCollectionInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCollectionInfo.Size = new System.Drawing.Size(879, 371);
            this.tabCollectionInfo.TabIndex = 2;
            this.tabCollectionInfo.Tag = "ServiceStatus_CollectionInfo";
            this.tabCollectionInfo.Text = "Collection Status";
            this.tabCollectionInfo.UseVisualStyleBackColor = true;
            // 
            // tabCurrentOprInfo
            // 
            this.tabCurrentOprInfo.Controls.Add(this.lstSrvOpr);
            this.tabCurrentOprInfo.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentOprInfo.Name = "tabCurrentOprInfo";
            this.tabCurrentOprInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentOprInfo.Size = new System.Drawing.Size(879, 371);
            this.tabCurrentOprInfo.TabIndex = 1;
            this.tabCurrentOprInfo.Tag = "ServiceStatus_CurrentOperationInfo";
            this.tabCurrentOprInfo.Text = "Current Operation";
            this.tabCurrentOprInfo.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshStripButton,
            this.ExpandAllStripButton,
            this.CollapseAllStripButton,
            this.btnSwitch,
            this.CloseStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(887, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RefreshStripButton
            // 
            this.RefreshStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshStripButton.Image")));
            this.RefreshStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshStripButton.Name = "RefreshStripButton";
            this.RefreshStripButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshStripButton.Tag = "Common_Refresh";
            this.RefreshStripButton.Text = "Refresh";
            this.RefreshStripButton.Click += new System.EventHandler(this.RefreshStripButton_Click);
            // 
            // ExpandAllStripButton
            // 
            this.ExpandAllStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExpandAllStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandAllStripButton.Image")));
            this.ExpandAllStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpandAllStripButton.Name = "ExpandAllStripButton";
            this.ExpandAllStripButton.Size = new System.Drawing.Size(23, 22);
            this.ExpandAllStripButton.Text = "ExpandAll";
            this.ExpandAllStripButton.Click += new System.EventHandler(this.ExpandAllStripButton_Click);
            // 
            // CollapseAllStripButton
            // 
            this.CollapseAllStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CollapseAllStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CollapseAllStripButton.Image")));
            this.CollapseAllStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CollapseAllStripButton.Name = "CollapseAllStripButton";
            this.CollapseAllStripButton.Size = new System.Drawing.Size(23, 22);
            this.CollapseAllStripButton.Text = "CollapseAll";
            this.CollapseAllStripButton.Click += new System.EventHandler(this.CollapseAllStripButton_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSwitch.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitch.Image")));
            this.btnSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(23, 22);
            this.btnSwitch.Tag = "Collection_Resume_AutoRefresh";
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // CloseStripButton
            // 
            this.CloseStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseStripButton.Image")));
            this.CloseStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseStripButton.Name = "CloseStripButton";
            this.CloseStripButton.Size = new System.Drawing.Size(23, 22);
            this.CloseStripButton.Tag = "Common_Close";
            this.CloseStripButton.Text = "Close";
            this.CloseStripButton.Click += new System.EventHandler(this.CloseStripButton_Click);
            // 
            // lstSrvOpr
            // 
            this.lstSrvOpr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSrvOpr.FullRowSelect = true;
            this.lstSrvOpr.GridLines = true;
            this.lstSrvOpr.Location = new System.Drawing.Point(3, 3);
            this.lstSrvOpr.Name = "lstSrvOpr";
            this.lstSrvOpr.Size = new System.Drawing.Size(873, 365);
            this.lstSrvOpr.TabIndex = 3;
            this.lstSrvOpr.UseCompatibleStateImageBehavior = false;
            this.lstSrvOpr.View = System.Windows.Forms.View.Details;
            // 
            // trvDBStatus
            // 
            this.trvDBStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvDBStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDBStatus.Location = new System.Drawing.Point(3, 3);
            this.trvDBStatus.Name = "trvDBStatus";
            this.trvDBStatus.Padding = new System.Windows.Forms.Padding(1);
            this.trvDBStatus.Size = new System.Drawing.Size(873, 365);
            this.trvDBStatus.TabIndex = 1;
            // 
            // trvColStatus
            // 
            this.trvColStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvColStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvColStatus.Location = new System.Drawing.Point(3, 3);
            this.trvColStatus.Name = "trvColStatus";
            this.trvColStatus.Padding = new System.Windows.Forms.Padding(1);
            this.trvColStatus.Size = new System.Drawing.Size(873, 365);
            this.trvColStatus.TabIndex = 1;
            // 
            // CtlServerStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSvrStatus);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CtlServerStatus";
            this.Size = new System.Drawing.Size(887, 422);
            this.Tag = "ServiceStatus_Title";
            this.Load += new System.EventHandler(this.ctlServerStatus_Load);
            this.tabSvrStatus.ResumeLayout(false);
            this.tabSvrBasicInfo.ResumeLayout(false);
            this.tabDBBasicInfo.ResumeLayout(false);
            this.tabCollectionInfo.ResumeLayout(false);
            this.tabCurrentOprInfo.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabSvrStatus;
        private TabPage tabSvrBasicInfo;
        private TabPage tabDBBasicInfo;
        private TabPage tabCollectionInfo;
        private TabPage tabCurrentOprInfo;
        private ToolStrip toolStrip1;
        private ToolStripButton RefreshStripButton;
        private ToolStripButton btnSwitch;
        private ToolStripButton CloseStripButton;
        private CtlTreeViewColumns trvSvrStatus;
        private ToolStripButton CollapseAllStripButton;
        private ToolStripButton ExpandAllStripButton;
        private CtlTreeViewColumns trvDBStatus;
        private CtlTreeViewColumns trvColStatus;
        private ListView lstSrvOpr;
    }
}
