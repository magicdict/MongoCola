namespace MagicMongoDBTool
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ConnectionStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SrvStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataBaseStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DosCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataFromAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplicaSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddShardingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据视图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LastPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvsrvlst = new System.Windows.Forms.TreeView();
            this.lstData = new System.Windows.Forms.ListView();
            this.ShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatusToolStripMenuItem,
            this.ToolToolStripMenuItem,
            this.数据视图ToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(863, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ConnectionStatusToolStripMenuItem
            // 
            this.ConnectionStatusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddConnectionToolStripMenuItem,
            this.SrvStatusToolStripMenuItem,
            this.DataBaseStatusToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.ConnectionStatusToolStripMenuItem.Name = "ConnectionStatusToolStripMenuItem";
            this.ConnectionStatusToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.ConnectionStatusToolStripMenuItem.Text = "连接和状态(&S)";
            // 
            // AddConnectionToolStripMenuItem
            // 
            this.AddConnectionToolStripMenuItem.Name = "AddConnectionToolStripMenuItem";
            this.AddConnectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.AddConnectionToolStripMenuItem.Text = "添加数据连接(&A)";
            this.AddConnectionToolStripMenuItem.Click += new System.EventHandler(this.AddConnectionToolStripMenuItem_Click);
            // 
            // SrvStatusToolStripMenuItem
            // 
            this.SrvStatusToolStripMenuItem.Name = "SrvStatusToolStripMenuItem";
            this.SrvStatusToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.SrvStatusToolStripMenuItem.Text = "服务器状态";
            this.SrvStatusToolStripMenuItem.Click += new System.EventHandler(this.SrvStatusToolStripMenuItem_Click);
            // 
            // DataBaseStatusToolStripMenuItem
            // 
            this.DataBaseStatusToolStripMenuItem.Name = "DataBaseStatusToolStripMenuItem";
            this.DataBaseStatusToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.DataBaseStatusToolStripMenuItem.Text = "数据库状态";
            this.DataBaseStatusToolStripMenuItem.Click += new System.EventHandler(this.DataBaseStatusToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.RefreshToolStripMenuItem.Text = "刷新";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ToolToolStripMenuItem
            // 
            this.ToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.DosCommandToolStripMenuItem,
            this.OptionToolStripMenuItem,
            this.ImportDataToolStripMenuItem,
            this.UserToolStripMenuItem,
            this.ReplicaSetToolStripMenuItem,
            this.AddShardingToolStripMenuItem,
            this.ShutDownToolStripMenuItem});
            this.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            this.ToolToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ToolToolStripMenuItem.Text = "工具（&T)";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMongoDBToolStripMenuItem,
            this.CreateMongoCollectionToolStripMenuItem});
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.CreateToolStripMenuItem.Text = "创建";
            // 
            // CreateMongoDBToolStripMenuItem
            // 
            this.CreateMongoDBToolStripMenuItem.Name = "CreateMongoDBToolStripMenuItem";
            this.CreateMongoDBToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.CreateMongoDBToolStripMenuItem.Text = "数据库";
            this.CreateMongoDBToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoDBToolStripMenuItem_Click);
            // 
            // CreateMongoCollectionToolStripMenuItem
            // 
            this.CreateMongoCollectionToolStripMenuItem.Name = "CreateMongoCollectionToolStripMenuItem";
            this.CreateMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.CreateMongoCollectionToolStripMenuItem.Text = "数据集";
            this.CreateMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoCollectionToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelMongoDBToolStripMenuItem,
            this.DelMongoCollectionToolStripMenuItem});
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.DeleteToolStripMenuItem.Text = "删除";
            // 
            // DelMongoDBToolStripMenuItem
            // 
            this.DelMongoDBToolStripMenuItem.Name = "DelMongoDBToolStripMenuItem";
            this.DelMongoDBToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.DelMongoDBToolStripMenuItem.Text = "数据库";
            this.DelMongoDBToolStripMenuItem.Click += new System.EventHandler(this.DelMongoDBToolStripMenuItem_Click);
            // 
            // DelMongoCollectionToolStripMenuItem
            // 
            this.DelMongoCollectionToolStripMenuItem.Name = "DelMongoCollectionToolStripMenuItem";
            this.DelMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.DelMongoCollectionToolStripMenuItem.Text = "数据集";
            this.DelMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.DelMongoCollectionToolStripMenuItem_Click);
            // 
            // DosCommandToolStripMenuItem
            // 
            this.DosCommandToolStripMenuItem.Name = "DosCommandToolStripMenuItem";
            this.DosCommandToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.DosCommandToolStripMenuItem.Text = "DOS操作";
            this.DosCommandToolStripMenuItem.Click += new System.EventHandler(this.DosCommandToolStripMenuItem_Click);
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.OptionToolStripMenuItem.Text = "配置(&O)";
            this.OptionToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // ImportDataToolStripMenuItem
            // 
            this.ImportDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportDataFromAccessToolStripMenuItem});
            this.ImportDataToolStripMenuItem.Name = "ImportDataToolStripMenuItem";
            this.ImportDataToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ImportDataToolStripMenuItem.Text = "导入";
            // 
            // ImportDataFromAccessToolStripMenuItem
            // 
            this.ImportDataFromAccessToolStripMenuItem.Name = "ImportDataFromAccessToolStripMenuItem";
            this.ImportDataFromAccessToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ImportDataFromAccessToolStripMenuItem.Text = "Access";
            this.ImportDataFromAccessToolStripMenuItem.Click += new System.EventHandler(this.ImportDataFromAccessToolStripMenuItem_Click);
            // 
            // UserToolStripMenuItem
            // 
            this.UserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUserToolStripMenuItem,
            this.RemoveUserToolStripMenuItem});
            this.UserToolStripMenuItem.Name = "UserToolStripMenuItem";
            this.UserToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.UserToolStripMenuItem.Text = "用户";
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.AddUserToolStripMenuItem.Text = "添加用户";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // RemoveUserToolStripMenuItem
            // 
            this.RemoveUserToolStripMenuItem.Name = "RemoveUserToolStripMenuItem";
            this.RemoveUserToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.RemoveUserToolStripMenuItem.Text = "删除用户";
            this.RemoveUserToolStripMenuItem.Click += new System.EventHandler(this.RemoveUserToolStripMenuItem_Click);
            // 
            // ReplicaSetToolStripMenuItem
            // 
            this.ReplicaSetToolStripMenuItem.Name = "ReplicaSetToolStripMenuItem";
            this.ReplicaSetToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ReplicaSetToolStripMenuItem.Text = "初始化副本";
            this.ReplicaSetToolStripMenuItem.Click += new System.EventHandler(this.ReplicaSetToolStripMenuItem_Click);
            // 
            // AddShardingToolStripMenuItem
            // 
            this.AddShardingToolStripMenuItem.Name = "AddShardingToolStripMenuItem";
            this.AddShardingToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.AddShardingToolStripMenuItem.Text = "添加副本[路由]";
            this.AddShardingToolStripMenuItem.Click += new System.EventHandler(this.AddShardingToolStripMenuItem_Click);
            // 
            // 数据视图ToolStripMenuItem
            // 
            this.数据视图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrePageToolStripMenuItem,
            this.NextPageToolStripMenuItem,
            this.FirstPageToolStripMenuItem,
            this.LastPageToolStripMenuItem});
            this.数据视图ToolStripMenuItem.Name = "数据视图ToolStripMenuItem";
            this.数据视图ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.数据视图ToolStripMenuItem.Text = "数据视图";
            // 
            // PrePageToolStripMenuItem
            // 
            this.PrePageToolStripMenuItem.Name = "PrePageToolStripMenuItem";
            this.PrePageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.PrePageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.PrePageToolStripMenuItem.Text = "上一页";
            this.PrePageToolStripMenuItem.Click += new System.EventHandler(this.PrePageToolStripMenuItem_Click);
            // 
            // NextPageToolStripMenuItem
            // 
            this.NextPageToolStripMenuItem.Name = "NextPageToolStripMenuItem";
            this.NextPageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.NextPageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.NextPageToolStripMenuItem.Text = "下一页";
            this.NextPageToolStripMenuItem.Click += new System.EventHandler(this.NextPageToolStripMenuItem_Click);
            // 
            // FirstPageToolStripMenuItem
            // 
            this.FirstPageToolStripMenuItem.Name = "FirstPageToolStripMenuItem";
            this.FirstPageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.FirstPageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.FirstPageToolStripMenuItem.Text = "第一页";
            this.FirstPageToolStripMenuItem.Click += new System.EventHandler(this.FirstPageToolStripMenuItem_Click);
            // 
            // LastPageToolStripMenuItem
            // 
            this.LastPageToolStripMenuItem.Name = "LastPageToolStripMenuItem";
            this.LastPageToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.LastPageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.LastPageToolStripMenuItem.Text = "最后一页";
            this.LastPageToolStripMenuItem.Click += new System.EventHandler(this.LastPageToolStripMenuItem_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(863, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripMain.Location = new System.Drawing.Point(0, 334);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(863, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvsrvlst);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstData);
            this.splitContainer1.Size = new System.Drawing.Size(863, 285);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.TabIndex = 3;
            // 
            // trvsrvlst
            // 
            this.trvsrvlst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvsrvlst.Location = new System.Drawing.Point(0, 0);
            this.trvsrvlst.Name = "trvsrvlst";
            this.trvsrvlst.Size = new System.Drawing.Size(287, 285);
            this.trvsrvlst.TabIndex = 0;
            // 
            // lstData
            // 
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.Location = new System.Drawing.Point(0, 0);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(572, 285);
            this.lstData.TabIndex = 0;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // ShutDownToolStripMenuItem
            // 
            this.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem";
            this.ShutDownToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ShutDownToolStripMenuItem.Text = "关闭服务器";
            this.ShutDownToolStripMenuItem.Click += new System.EventHandler(this.ShutDownToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 356);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmMain";
            this.Text = "MagicMongoDB";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripMenuItem ConnectionStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddConnectionToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvsrvlst;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DosCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataBaseStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SrvStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelMongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelMongoCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateMongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateMongoCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportDataFromAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据视图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NextPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LastPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplicaSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddShardingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShutDownToolStripMenuItem;
    }
}

