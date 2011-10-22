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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ConnectionStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SrvStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataBaseStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataNaviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LastPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataCollectionOprToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndexManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GridFsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DosCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataFromAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShardingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplicaSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddShardingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShardConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapReduceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.trvsrvlst = new System.Windows.Forms.TreeView();
            this.tabDataShower = new System.Windows.Forms.TabControl();
            this.tabTreeView = new System.Windows.Forms.TabPage();
            this.trvData = new System.Windows.Forms.TreeView();
            this.tabTableView = new System.Windows.Forms.TabPage();
            this.lstData = new System.Windows.Forms.ListView();
            this.tabTextView = new System.Windows.Forms.TabPage();
            this.txtData = new System.Windows.Forms.TextBox();
            this.contentPanel.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabDataShower.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabTableView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.splitContainer1);
            this.contentPanel.Controls.Add(this.toolStripMain);
            this.contentPanel.Controls.Add(this.menuStripMain);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(915, 507);
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStripMain.BackgroundImage")));
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStripMain.Location = new System.Drawing.Point(0, 548);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(917, 22);
            this.statusStripMain.TabIndex = 8;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripMain.BackgroundImage")));
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(915, 25);
            this.toolStripMain.TabIndex = 7;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStripMain.BackgroundImage")));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectionStatusToolStripMenuItem,
            this.DataNaviToolStripMenuItem,
            this.ManageToolStripMenuItem,
            this.ToolToolStripMenuItem,
            this.ShardingToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(915, 24);
            this.menuStripMain.TabIndex = 6;
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
            // DataNaviToolStripMenuItem
            // 
            this.DataNaviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrePageToolStripMenuItem,
            this.NextPageToolStripMenuItem,
            this.FirstPageToolStripMenuItem,
            this.LastPageToolStripMenuItem,
            this.QueryDataToolStripMenuItem});
            this.DataNaviToolStripMenuItem.Name = "DataNaviToolStripMenuItem";
            this.DataNaviToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.DataNaviToolStripMenuItem.Text = "数据视图";
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
            // QueryDataToolStripMenuItem
            // 
            this.QueryDataToolStripMenuItem.Name = "QueryDataToolStripMenuItem";
            this.QueryDataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.QueryDataToolStripMenuItem.Text = "数据查询";
            this.QueryDataToolStripMenuItem.Click += new System.EventHandler(this.QueryDataToolStripMenuItem_Click);
            // 
            // ManageToolStripMenuItem
            // 
            this.ManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerToolStripMenuItem,
            this.DataBaseToolStripMenuItem,
            this.DataCollectionOprToolStripMenuItem,
            this.GridFsToolStripMenuItem});
            this.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem";
            this.ManageToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.ManageToolStripMenuItem.Text = "管理";
            // 
            // ServerToolStripMenuItem
            // 
            this.ServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShutDownToolStripMenuItem,
            this.CreateMongoDBToolStripMenuItem});
            this.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem";
            this.ServerToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.ServerToolStripMenuItem.Text = "服务器";
            // 
            // ShutDownToolStripMenuItem
            // 
            this.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem";
            this.ShutDownToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ShutDownToolStripMenuItem.Text = "关闭服务器";
            this.ShutDownToolStripMenuItem.Click += new System.EventHandler(this.ShutDownToolStripMenuItem_Click);
            // 
            // CreateMongoDBToolStripMenuItem
            // 
            this.CreateMongoDBToolStripMenuItem.Name = "CreateMongoDBToolStripMenuItem";
            this.CreateMongoDBToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.CreateMongoDBToolStripMenuItem.Text = "添加数据库";
            this.CreateMongoDBToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoDBToolStripMenuItem_Click);
            // 
            // DataBaseToolStripMenuItem
            // 
            this.DataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelMongoDBToolStripMenuItem,
            this.CreateMongoCollectionToolStripMenuItem});
            this.DataBaseToolStripMenuItem.Name = "DataBaseToolStripMenuItem";
            this.DataBaseToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.DataBaseToolStripMenuItem.Text = "数据库";
            // 
            // DelMongoDBToolStripMenuItem
            // 
            this.DelMongoDBToolStripMenuItem.Name = "DelMongoDBToolStripMenuItem";
            this.DelMongoDBToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DelMongoDBToolStripMenuItem.Text = "删除数据库";
            this.DelMongoDBToolStripMenuItem.Click += new System.EventHandler(this.DelMongoDBToolStripMenuItem_Click);
            // 
            // CreateMongoCollectionToolStripMenuItem
            // 
            this.CreateMongoCollectionToolStripMenuItem.Name = "CreateMongoCollectionToolStripMenuItem";
            this.CreateMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.CreateMongoCollectionToolStripMenuItem.Text = "添加数据集";
            this.CreateMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoCollectionToolStripMenuItem_Click);
            // 
            // DataCollectionOprToolStripMenuItem
            // 
            this.DataCollectionOprToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelMongoCollectionToolStripMenuItem,
            this.IndexManageToolStripMenuItem,
            this.AddUserToolStripMenuItem,
            this.RemoveUserToolStripMenuItem,
            this.DelRecordToolStripMenuItem,
            this.RenameCollectionToolStripMenuItem});
            this.DataCollectionOprToolStripMenuItem.Name = "DataCollectionOprToolStripMenuItem";
            this.DataCollectionOprToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.DataCollectionOprToolStripMenuItem.Text = "数据集";
            // 
            // DelMongoCollectionToolStripMenuItem
            // 
            this.DelMongoCollectionToolStripMenuItem.Name = "DelMongoCollectionToolStripMenuItem";
            this.DelMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.DelMongoCollectionToolStripMenuItem.Text = "删除数据集";
            this.DelMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.DelMongoCollectionToolStripMenuItem_Click);
            // 
            // IndexManageToolStripMenuItem
            // 
            this.IndexManageToolStripMenuItem.Name = "IndexManageToolStripMenuItem";
            this.IndexManageToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.IndexManageToolStripMenuItem.Text = "索引管理";
            this.IndexManageToolStripMenuItem.Click += new System.EventHandler(this.IndexManageToolStripMenuItem_Click);
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.AddUserToolStripMenuItem.Text = "添加用户";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // RemoveUserToolStripMenuItem
            // 
            this.RemoveUserToolStripMenuItem.Name = "RemoveUserToolStripMenuItem";
            this.RemoveUserToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.RemoveUserToolStripMenuItem.Text = "删除用户";
            this.RemoveUserToolStripMenuItem.Click += new System.EventHandler(this.RemoveUserToolStripMenuItem_Click);
            // 
            // DelRecordToolStripMenuItem
            // 
            this.DelRecordToolStripMenuItem.Name = "DelRecordToolStripMenuItem";
            this.DelRecordToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.DelRecordToolStripMenuItem.Text = "删除选中数据";
            this.DelRecordToolStripMenuItem.Click += new System.EventHandler(this.DelRecordToolStripMenuItem_Click);
            // 
            // RenameCollectionToolStripMenuItem
            // 
            this.RenameCollectionToolStripMenuItem.Name = "RenameCollectionToolStripMenuItem";
            this.RenameCollectionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.RenameCollectionToolStripMenuItem.Text = "重命名数据集";
            this.RenameCollectionToolStripMenuItem.Click += new System.EventHandler(this.RenameCollectionToolStripMenuItem_Click);
            // 
            // GridFsToolStripMenuItem
            // 
            this.GridFsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadFileToolStripMenuItem,
            this.DownloadFileToolStripMenuItem,
            this.OpenFileToolStripMenuItem,
            this.DelFileToolStripMenuItem});
            this.GridFsToolStripMenuItem.Name = "GridFsToolStripMenuItem";
            this.GridFsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.GridFsToolStripMenuItem.Text = "文件系统";
            // 
            // UploadFileToolStripMenuItem
            // 
            this.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem";
            this.UploadFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.UploadFileToolStripMenuItem.Text = "上传文件";
            // 
            // DownloadFileToolStripMenuItem
            // 
            this.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem";
            this.DownloadFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.DownloadFileToolStripMenuItem.Text = "下载文件";
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.OpenFileToolStripMenuItem.Text = "打开文件";
            // 
            // DelFileToolStripMenuItem
            // 
            this.DelFileToolStripMenuItem.Name = "DelFileToolStripMenuItem";
            this.DelFileToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.DelFileToolStripMenuItem.Text = "删除文件";
            // 
            // ToolToolStripMenuItem
            // 
            this.ToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DosCommandToolStripMenuItem,
            this.ImportDataFromAccessToolStripMenuItem,
            this.OptionToolStripMenuItem});
            this.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            this.ToolToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ToolToolStripMenuItem.Text = "工具（&T)";
            // 
            // DosCommandToolStripMenuItem
            // 
            this.DosCommandToolStripMenuItem.Name = "DosCommandToolStripMenuItem";
            this.DosCommandToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.DosCommandToolStripMenuItem.Text = "DOS操作";
            this.DosCommandToolStripMenuItem.Click += new System.EventHandler(this.DosCommandToolStripMenuItem_Click);
            // 
            // ImportDataFromAccessToolStripMenuItem
            // 
            this.ImportDataFromAccessToolStripMenuItem.Name = "ImportDataFromAccessToolStripMenuItem";
            this.ImportDataFromAccessToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.ImportDataFromAccessToolStripMenuItem.Text = "导入Access数据库";
            this.ImportDataFromAccessToolStripMenuItem.Click += new System.EventHandler(this.ImportDataFromAccessToolStripMenuItem_Click);
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.OptionToolStripMenuItem.Text = "配置(&O)";
            this.OptionToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // ShardingToolStripMenuItem
            // 
            this.ShardingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReplicaSetToolStripMenuItem,
            this.AddShardingToolStripMenuItem,
            this.ShardConfigToolStripMenuItem,
            this.mapReduceToolStripMenuItem});
            this.ShardingToolStripMenuItem.Name = "ShardingToolStripMenuItem";
            this.ShardingToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.ShardingToolStripMenuItem.Text = "分布式";
            // 
            // ReplicaSetToolStripMenuItem
            // 
            this.ReplicaSetToolStripMenuItem.Name = "ReplicaSetToolStripMenuItem";
            this.ReplicaSetToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ReplicaSetToolStripMenuItem.Text = "初始化副本";
            this.ReplicaSetToolStripMenuItem.Click += new System.EventHandler(this.ReplicaSetToolStripMenuItem_Click);
            // 
            // AddShardingToolStripMenuItem
            // 
            this.AddShardingToolStripMenuItem.Name = "AddShardingToolStripMenuItem";
            this.AddShardingToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.AddShardingToolStripMenuItem.Text = "添加分片";
            this.AddShardingToolStripMenuItem.Click += new System.EventHandler(this.AddShardingToolStripMenuItem_Click);
            // 
            // ShardConfigToolStripMenuItem
            // 
            this.ShardConfigToolStripMenuItem.Name = "ShardConfigToolStripMenuItem";
            this.ShardConfigToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ShardConfigToolStripMenuItem.Text = "配置分片数据";
            this.ShardConfigToolStripMenuItem.Click += new System.EventHandler(this.ShardConfigToolStripMenuItem_Click);
            // 
            // mapReduceToolStripMenuItem
            // 
            this.mapReduceToolStripMenuItem.Name = "mapReduceToolStripMenuItem";
            this.mapReduceToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.mapReduceToolStripMenuItem.Text = "MapReduce";
            this.mapReduceToolStripMenuItem.Click += new System.EventHandler(this.mapReduceToolStripMenuItem_Click);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.YellowGreen;
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
            this.splitContainer1.Panel2.Controls.Add(this.tabDataShower);
            this.splitContainer1.Size = new System.Drawing.Size(915, 458);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 4;
            // 
            // trvsrvlst
            // 
            this.trvsrvlst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvsrvlst.Location = new System.Drawing.Point(0, 0);
            this.trvsrvlst.Name = "trvsrvlst";
            this.trvsrvlst.Size = new System.Drawing.Size(303, 458);
            this.trvsrvlst.TabIndex = 0;
            // 
            // tabDataShower
            // 
            this.tabDataShower.Controls.Add(this.tabTreeView);
            this.tabDataShower.Controls.Add(this.tabTableView);
            this.tabDataShower.Controls.Add(this.tabTextView);
            this.tabDataShower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDataShower.Location = new System.Drawing.Point(0, 0);
            this.tabDataShower.Name = "tabDataShower";
            this.tabDataShower.SelectedIndex = 0;
            this.tabDataShower.Size = new System.Drawing.Size(608, 458);
            this.tabDataShower.TabIndex = 0;
            // 
            // tabTreeView
            // 
            this.tabTreeView.Controls.Add(this.trvData);
            this.tabTreeView.Location = new System.Drawing.Point(4, 22);
            this.tabTreeView.Name = "tabTreeView";
            this.tabTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeView.Size = new System.Drawing.Size(600, 432);
            this.tabTreeView.TabIndex = 0;
            this.tabTreeView.Text = "TreeView";
            this.tabTreeView.UseVisualStyleBackColor = true;
            // 
            // trvData
            // 
            this.trvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvData.Location = new System.Drawing.Point(3, 3);
            this.trvData.Name = "trvData";
            this.trvData.Size = new System.Drawing.Size(594, 426);
            this.trvData.TabIndex = 0;
            // 
            // tabTableView
            // 
            this.tabTableView.Controls.Add(this.lstData);
            this.tabTableView.Location = new System.Drawing.Point(4, 22);
            this.tabTableView.Name = "tabTableView";
            this.tabTableView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableView.Size = new System.Drawing.Size(600, 432);
            this.tabTableView.TabIndex = 1;
            this.tabTableView.Text = "TableView";
            this.tabTableView.UseVisualStyleBackColor = true;
            // 
            // lstData
            // 
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(3, 3);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(594, 426);
            this.lstData.TabIndex = 1;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            // 
            // tabTextView
            // 
            this.tabTextView.Controls.Add(this.txtData);
            this.tabTextView.Location = new System.Drawing.Point(4, 22);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextView.Size = new System.Drawing.Size(600, 432);
            this.tabTextView.TabIndex = 2;
            this.tabTextView.Text = "TextView";
            this.tabTextView.UseVisualStyleBackColor = true;
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Location = new System.Drawing.Point(3, 3);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(594, 426);
            this.txtData.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(917, 570);
            this.Controls.Add(this.statusStripMain);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.contentPanel, 0);
            this.Controls.SetChildIndex(this.statusStripMain, 0);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabDataShower.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabTableView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabTextView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ConnectionStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SrvStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataBaseStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataNaviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NextPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LastPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QueryDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShutDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateMongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelMongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateMongoCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataCollectionOprToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelMongoCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IndexManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GridFsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UploadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DosCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportDataFromAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShardingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplicaSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddShardingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShardConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapReduceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvsrvlst;
        private System.Windows.Forms.TabControl tabDataShower;
        private System.Windows.Forms.TabPage tabTreeView;
        private System.Windows.Forms.TreeView trvData;
        private System.Windows.Forms.TabPage tabTableView;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.TabPage tabTextView;
        private System.Windows.Forms.TextBox txtData;
    }
}