using System.Windows.Forms;
using MagicMongoDBTool.Module;
using GUIResource;
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
            this.toolStripStatusSelectedObj = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SrvStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.ExpandAllConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollapseAllConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataNaviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FirstPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LastPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AggregationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distinctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapReduceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExpandAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollapseAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddUserToAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserFromAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SvrPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.evalJSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataCollectionOprToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndexManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.DelRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GridFsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InitGFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpAndRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreMongoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DosCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDataFromAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DistributedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplicaSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShardConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripStatusSelectedObj});
            this.statusStripMain.Location = new System.Drawing.Point(0, 548);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(917, 22);
            this.statusStripMain.TabIndex = 8;
            // 
            // toolStripStatusSelectedObj
            // 
            this.toolStripStatusSelectedObj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(130)))));
            this.toolStripStatusSelectedObj.Name = "toolStripStatusSelectedObj";
            this.toolStripStatusSelectedObj.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusSelectedObj.Text = "就绪";
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripMain.BackgroundImage")));
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(915, 25);
            this.toolStripMain.TabIndex = 7;
            this.toolStripMain.Text = "工具栏";
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStripMain.BackgroundImage")));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerToolStripMenuItem,
            this.DataNaviToolStripMenuItem,
            this.OperationToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.DistributedToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(915, 24);
            this.menuStripMain.TabIndex = 6;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ManagerToolStripMenuItem
            // 
            this.ManagerToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddConnectionToolStripMenuItem,
            this.SrvStatusToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.toolStripMenuItem10,
            this.ExpandAllConnectionToolStripMenuItem,
            this.CollapseAllConnectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.ManagerToolStripMenuItem.Name = "ManagerToolStripMenuItem";
            this.ManagerToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ManagerToolStripMenuItem.Text = "管理(&S)";
            // 
            // AddConnectionToolStripMenuItem
            // 
            this.AddConnectionToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
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
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.RefreshToolStripMenuItem.Text = "刷新";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(158, 6);
            // 
            // ExpandAllConnectionToolStripMenuItem
            // 
            this.ExpandAllConnectionToolStripMenuItem.Name = "ExpandAllConnectionToolStripMenuItem";
            this.ExpandAllConnectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.ExpandAllConnectionToolStripMenuItem.Text = "展开";
            this.ExpandAllConnectionToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
            // 
            // CollapseAllConnectionToolStripMenuItem
            // 
            this.CollapseAllConnectionToolStripMenuItem.Name = "CollapseAllConnectionToolStripMenuItem";
            this.CollapseAllConnectionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.CollapseAllConnectionToolStripMenuItem.Text = "折叠";
            this.CollapseAllConnectionToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
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
            this.toolStripMenuItem9,
            this.QueryDataToolStripMenuItem,
            this.ConvertSqlToolStripMenuItem,
            this.AggregationToolStripMenuItem,
            this.DataFilterToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ExpandAllDataToolStripMenuItem,
            this.CollapseAllDataToolStripMenuItem});
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
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(144, 6);
            // 
            // QueryDataToolStripMenuItem
            // 
            this.QueryDataToolStripMenuItem.Name = "QueryDataToolStripMenuItem";
            this.QueryDataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.QueryDataToolStripMenuItem.Text = "设置数据查询";
            this.QueryDataToolStripMenuItem.Click += new System.EventHandler(this.QueryDataToolStripMenuItem_Click);
            // 
            // ConvertSqlToolStripMenuItem
            // 
            this.ConvertSqlToolStripMenuItem.Name = "ConvertSqlToolStripMenuItem";
            this.ConvertSqlToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ConvertSqlToolStripMenuItem.Text = "Sql语句转换";
            this.ConvertSqlToolStripMenuItem.Click += new System.EventHandler(this.ConvertSqlToolStripMenuItem_Click);
            // 
            // AggregationToolStripMenuItem
            // 
            this.AggregationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countToolStripMenuItem,
            this.distinctToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.mapReduceToolStripMenuItem});
            this.AggregationToolStripMenuItem.Name = "AggregationToolStripMenuItem";
            this.AggregationToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.AggregationToolStripMenuItem.Text = "聚合函数";
            // 
            // countToolStripMenuItem
            // 
            this.countToolStripMenuItem.Name = "countToolStripMenuItem";
            this.countToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.countToolStripMenuItem.Text = "Count";
            this.countToolStripMenuItem.Click += new System.EventHandler(this.countToolStripMenuItem_Click);
            // 
            // distinctToolStripMenuItem
            // 
            this.distinctToolStripMenuItem.Name = "distinctToolStripMenuItem";
            this.distinctToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.distinctToolStripMenuItem.Text = "Distinct";
            this.distinctToolStripMenuItem.Click += new System.EventHandler(this.distinctToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.groupToolStripMenuItem.Text = "Group";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
            // 
            // mapReduceToolStripMenuItem
            // 
            this.mapReduceToolStripMenuItem.Name = "mapReduceToolStripMenuItem";
            this.mapReduceToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.mapReduceToolStripMenuItem.Text = "MapReduce";
            this.mapReduceToolStripMenuItem.Click += new System.EventHandler(this.mapReduceToolStripMenuItem_Click);
            // 
            // DataFilterToolStripMenuItem
            // 
            this.DataFilterToolStripMenuItem.Name = "DataFilterToolStripMenuItem";
            this.DataFilterToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.DataFilterToolStripMenuItem.Text = "过滤";
            this.DataFilterToolStripMenuItem.Click += new System.EventHandler(this.DataFilterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 6);
            // 
            // ExpandAllDataToolStripMenuItem
            // 
            this.ExpandAllDataToolStripMenuItem.Name = "ExpandAllDataToolStripMenuItem";
            this.ExpandAllDataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.ExpandAllDataToolStripMenuItem.Text = "展开";
            this.ExpandAllDataToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllDataToolStripMenuItem_Click);
            // 
            // CollapseAllDataToolStripMenuItem
            // 
            this.CollapseAllDataToolStripMenuItem.Name = "CollapseAllDataToolStripMenuItem";
            this.CollapseAllDataToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.CollapseAllDataToolStripMenuItem.Text = "折叠";
            this.CollapseAllDataToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllDataToolStripMenuItem_Click);
            // 
            // OperationToolStripMenuItem
            // 
            this.OperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerToolStripMenuItem,
            this.DataBaseToolStripMenuItem,
            this.DataCollectionOprToolStripMenuItem,
            this.GridFsToolStripMenuItem,
            this.DumpAndRestoreToolStripMenuItem});
            this.OperationToolStripMenuItem.Name = "OperationToolStripMenuItem";
            this.OperationToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.OperationToolStripMenuItem.Text = "操作";
            // 
            // ServerToolStripMenuItem
            // 
            this.ServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMongoDBToolStripMenuItem,
            this.toolStripMenuItem4,
            this.AddUserToAdminToolStripMenuItem,
            this.RemoveUserFromAdminToolStripMenuItem,
            this.toolStripMenuItem3,
            this.ShutDownToolStripMenuItem,
            this.SvrPropertyToolStripMenuItem});
            this.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem";
            this.ServerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ServerToolStripMenuItem.Text = "服务器";
            // 
            // CreateMongoDBToolStripMenuItem
            // 
            this.CreateMongoDBToolStripMenuItem.Name = "CreateMongoDBToolStripMenuItem";
            this.CreateMongoDBToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.CreateMongoDBToolStripMenuItem.Text = "新建数据库";
            this.CreateMongoDBToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoDBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 6);
            // 
            // AddUserToAdminToolStripMenuItem
            // 
            this.AddUserToAdminToolStripMenuItem.Name = "AddUserToAdminToolStripMenuItem";
            this.AddUserToAdminToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AddUserToAdminToolStripMenuItem.Text = "添加用户到Admin";
            this.AddUserToAdminToolStripMenuItem.Click += new System.EventHandler(this.AddUserToAdminToolStripMenuItem_Click);
            // 
            // RemoveUserFromAdminToolStripMenuItem
            // 
            this.RemoveUserFromAdminToolStripMenuItem.Name = "RemoveUserFromAdminToolStripMenuItem";
            this.RemoveUserFromAdminToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.RemoveUserFromAdminToolStripMenuItem.Text = "从Admin删除用户";
            this.RemoveUserFromAdminToolStripMenuItem.Click += new System.EventHandler(this.DelUserFromAdminToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // ShutDownToolStripMenuItem
            // 
            this.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem";
            this.ShutDownToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ShutDownToolStripMenuItem.Text = "关闭服务器";
            this.ShutDownToolStripMenuItem.Click += new System.EventHandler(this.ShutDownToolStripMenuItem_Click);
            // 
            // SvrPropertyToolStripMenuItem
            // 
            this.SvrPropertyToolStripMenuItem.Name = "SvrPropertyToolStripMenuItem";
            this.SvrPropertyToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SvrPropertyToolStripMenuItem.Text = "属性";
            this.SvrPropertyToolStripMenuItem.Click += new System.EventHandler(this.SvrPropertyToolStripMenuItem_Click);
            // 
            // DataBaseToolStripMenuItem
            // 
            this.DataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelMongoDBToolStripMenuItem,
            this.CreateMongoCollectionToolStripMenuItem,
            this.toolStripMenuItem5,
            this.AddUserToolStripMenuItem,
            this.RemoveUserToolStripMenuItem,
            this.toolStripMenuItem11,
            this.evalJSToolStripMenuItem});
            this.DataBaseToolStripMenuItem.Name = "DataBaseToolStripMenuItem";
            this.DataBaseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
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
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(131, 6);
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.AddUserToolStripMenuItem.Text = "添加用户";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // RemoveUserToolStripMenuItem
            // 
            this.RemoveUserToolStripMenuItem.Name = "RemoveUserToolStripMenuItem";
            this.RemoveUserToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.RemoveUserToolStripMenuItem.Text = "删除用户";
            this.RemoveUserToolStripMenuItem.Click += new System.EventHandler(this.RemoveUserToolStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(131, 6);
            // 
            // evalJSToolStripMenuItem
            // 
            this.evalJSToolStripMenuItem.Name = "evalJSToolStripMenuItem";
            this.evalJSToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.evalJSToolStripMenuItem.Text = "执行JS";
            this.evalJSToolStripMenuItem.Click += new System.EventHandler(this.evalJSToolStripMenuItem_Click);
            // 
            // DataCollectionOprToolStripMenuItem
            // 
            this.DataCollectionOprToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelMongoCollectionToolStripMenuItem,
            this.RenameCollectionToolStripMenuItem,
            this.IndexManageToolStripMenuItem,
            this.ReIndexToolStripMenuItem,
            this.toolStripMenuItem8,
            this.DelRecordToolStripMenuItem});
            this.DataCollectionOprToolStripMenuItem.Name = "DataCollectionOprToolStripMenuItem";
            this.DataCollectionOprToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DataCollectionOprToolStripMenuItem.Text = "数据集";
            // 
            // DelMongoCollectionToolStripMenuItem
            // 
            this.DelMongoCollectionToolStripMenuItem.Name = "DelMongoCollectionToolStripMenuItem";
            this.DelMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.DelMongoCollectionToolStripMenuItem.Text = "删除数据集";
            this.DelMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.DelMongoCollectionToolStripMenuItem_Click);
            // 
            // RenameCollectionToolStripMenuItem
            // 
            this.RenameCollectionToolStripMenuItem.Name = "RenameCollectionToolStripMenuItem";
            this.RenameCollectionToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.RenameCollectionToolStripMenuItem.Text = "重命名数据集";
            this.RenameCollectionToolStripMenuItem.Click += new System.EventHandler(this.RenameCollectionToolStripMenuItem_Click);
            // 
            // IndexManageToolStripMenuItem
            // 
            this.IndexManageToolStripMenuItem.Name = "IndexManageToolStripMenuItem";
            this.IndexManageToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.IndexManageToolStripMenuItem.Text = "索引管理";
            this.IndexManageToolStripMenuItem.Click += new System.EventHandler(this.IndexManageToolStripMenuItem_Click);
            // 
            // ReIndexToolStripMenuItem
            // 
            this.ReIndexToolStripMenuItem.Name = "ReIndexToolStripMenuItem";
            this.ReIndexToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ReIndexToolStripMenuItem.Text = "重新索引";
            this.ReIndexToolStripMenuItem.Click += new System.EventHandler(this.ReIndexToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(143, 6);
            // 
            // DelRecordToolStripMenuItem
            // 
            this.DelRecordToolStripMenuItem.Name = "DelRecordToolStripMenuItem";
            this.DelRecordToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.DelRecordToolStripMenuItem.Text = "删除选中数据";
            this.DelRecordToolStripMenuItem.Click += new System.EventHandler(this.DelRecordToolStripMenuItem_Click);
            // 
            // GridFsToolStripMenuItem
            // 
            this.GridFsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadFileToolStripMenuItem,
            this.DownloadFileToolStripMenuItem,
            this.OpenFileToolStripMenuItem,
            this.DelFileToolStripMenuItem,
            this.InitGFSToolStripMenuItem});
            this.GridFsToolStripMenuItem.Name = "GridFsToolStripMenuItem";
            this.GridFsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.GridFsToolStripMenuItem.Text = "文件系统";
            // 
            // UploadFileToolStripMenuItem
            // 
            this.UploadFileToolStripMenuItem.Name = "UploadFileToolStripMenuItem";
            this.UploadFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.UploadFileToolStripMenuItem.Text = "上传文件";
            this.UploadFileToolStripMenuItem.Click += new System.EventHandler(this.UploadFileToolStripMenuItem_Click);
            // 
            // DownloadFileToolStripMenuItem
            // 
            this.DownloadFileToolStripMenuItem.Name = "DownloadFileToolStripMenuItem";
            this.DownloadFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.DownloadFileToolStripMenuItem.Text = "下载文件";
            this.DownloadFileToolStripMenuItem.Click += new System.EventHandler(this.DownloadFileToolStripMenuItem_Click);
            // 
            // OpenFileToolStripMenuItem
            // 
            this.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem";
            this.OpenFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.OpenFileToolStripMenuItem.Text = "打开文件";
            this.OpenFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItem_Click);
            // 
            // DelFileToolStripMenuItem
            // 
            this.DelFileToolStripMenuItem.Name = "DelFileToolStripMenuItem";
            this.DelFileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.DelFileToolStripMenuItem.Text = "删除文件";
            this.DelFileToolStripMenuItem.Click += new System.EventHandler(this.DelFileToolStripMenuItem_Click);
            // 
            // InitGFSToolStripMenuItem
            // 
            this.InitGFSToolStripMenuItem.Name = "InitGFSToolStripMenuItem";
            this.InitGFSToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.InitGFSToolStripMenuItem.Text = "初始化GFS";
            this.InitGFSToolStripMenuItem.Click += new System.EventHandler(this.InitGFSToolStripMenuItem_Click);
            // 
            // DumpAndRestoreToolStripMenuItem
            // 
            this.DumpAndRestoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestoreMongoToolStripMenuItem,
            this.DumpDatabaseToolStripMenuItem,
            this.DumpCollectionToolStripMenuItem,
            this.toolStripMenuItem6,
            this.ImportCollectionToolStripMenuItem,
            this.ExportCollectionToolStripMenuItem});
            this.DumpAndRestoreToolStripMenuItem.Name = "DumpAndRestoreToolStripMenuItem";
            this.DumpAndRestoreToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DumpAndRestoreToolStripMenuItem.Text = "备份和恢复";
            // 
            // RestoreMongoToolStripMenuItem
            // 
            this.RestoreMongoToolStripMenuItem.Name = "RestoreMongoToolStripMenuItem";
            this.RestoreMongoToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.RestoreMongoToolStripMenuItem.Text = "恢复数据";
            this.RestoreMongoToolStripMenuItem.Click += new System.EventHandler(this.RestoreMongoToolStripMenuItem_Click);
            // 
            // DumpDatabaseToolStripMenuItem
            // 
            this.DumpDatabaseToolStripMenuItem.Name = "DumpDatabaseToolStripMenuItem";
            this.DumpDatabaseToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DumpDatabaseToolStripMenuItem.Text = "备份数据库";
            this.DumpDatabaseToolStripMenuItem.Click += new System.EventHandler(this.DumpDatabaseToolStripMenuItem_Click);
            // 
            // DumpCollectionToolStripMenuItem
            // 
            this.DumpCollectionToolStripMenuItem.Name = "DumpCollectionToolStripMenuItem";
            this.DumpCollectionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DumpCollectionToolStripMenuItem.Text = "备份数据集";
            this.DumpCollectionToolStripMenuItem.Click += new System.EventHandler(this.DumpCollectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(131, 6);
            // 
            // ImportCollectionToolStripMenuItem
            // 
            this.ImportCollectionToolStripMenuItem.Name = "ImportCollectionToolStripMenuItem";
            this.ImportCollectionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ImportCollectionToolStripMenuItem.Text = "导入数据集";
            this.ImportCollectionToolStripMenuItem.Click += new System.EventHandler(this.ImportCollectionToolStripMenuItem_Click);
            // 
            // ExportCollectionToolStripMenuItem
            // 
            this.ExportCollectionToolStripMenuItem.Name = "ExportCollectionToolStripMenuItem";
            this.ExportCollectionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ExportCollectionToolStripMenuItem.Text = "导出数据集";
            this.ExportCollectionToolStripMenuItem.Click += new System.EventHandler(this.ExportCollectionToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DosCommandToolStripMenuItem,
            this.ImportDataFromAccessToolStripMenuItem,
            this.toolStripMenuItem7,
            this.OptionToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.ToolsToolStripMenuItem.Text = "工具（&T)";
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
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(164, 6);
            // 
            // OptionToolStripMenuItem
            // 
            this.OptionToolStripMenuItem.Name = "OptionToolStripMenuItem";
            this.OptionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.OptionToolStripMenuItem.Text = "配置(&O)";
            this.OptionToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // DistributedToolStripMenuItem
            // 
            this.DistributedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReplicaSetToolStripMenuItem,
            this.ShardConfigToolStripMenuItem});
            this.DistributedToolStripMenuItem.Name = "DistributedToolStripMenuItem";
            this.DistributedToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.DistributedToolStripMenuItem.Text = "分布式";
            // 
            // ReplicaSetToolStripMenuItem
            // 
            this.ReplicaSetToolStripMenuItem.Name = "ReplicaSetToolStripMenuItem";
            this.ReplicaSetToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ReplicaSetToolStripMenuItem.Text = "副本设定";
            this.ReplicaSetToolStripMenuItem.Click += new System.EventHandler(this.ReplicaSetToolStripMenuItem_Click);
            // 
            // ShardConfigToolStripMenuItem
            // 
            this.ShardConfigToolStripMenuItem.Name = "ShardConfigToolStripMenuItem";
            this.ShardConfigToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ShardConfigToolStripMenuItem.Text = "配置分片数据";
            this.ShardConfigToolStripMenuItem.Click += new System.EventHandler(this.ShardConfigToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.ThanksToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.helpToolStripMenuItem.Text = "帮助";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.AboutToolStripMenuItem.Text = "关于";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ThanksToolStripMenuItem
            // 
            this.ThanksToolStripMenuItem.Name = "ThanksToolStripMenuItem";
            this.ThanksToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.ThanksToolStripMenuItem.Text = "感谢";
            this.ThanksToolStripMenuItem.Click += new System.EventHandler(this.ThanksToolStripMenuItem_Click);
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
            this.trvsrvlst.BackColor = System.Drawing.Color.White;
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
            this.tabTreeView.BackColor = System.Drawing.Color.Orange;
            this.tabTreeView.Controls.Add(this.trvData);
            this.tabTreeView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTreeView.Location = new System.Drawing.Point(4, 22);
            this.tabTreeView.Name = "tabTreeView";
            this.tabTreeView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeView.Size = new System.Drawing.Size(600, 432);
            this.tabTreeView.TabIndex = 0;
            this.tabTreeView.Text = "树形视图";
            // 
            // trvData
            // 
            this.trvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvData.Location = new System.Drawing.Point(3, 3);
            this.trvData.Name = "trvData";
            this.trvData.Size = new System.Drawing.Size(594, 426);
            this.trvData.TabIndex = 0;
            // 
            // tabTableView
            // 
            this.tabTableView.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabTableView.Controls.Add(this.lstData);
            this.tabTableView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTableView.Location = new System.Drawing.Point(4, 22);
            this.tabTableView.Name = "tabTableView";
            this.tabTableView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableView.Size = new System.Drawing.Size(600, 432);
            this.tabTableView.TabIndex = 1;
            this.tabTableView.Text = "表格视图";
            // 
            // lstData
            // 
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabTextView.BackColor = System.Drawing.Color.Yellow;
            this.tabTextView.Controls.Add(this.txtData);
            this.tabTextView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabTextView.Location = new System.Drawing.Point(4, 22);
            this.tabTextView.Name = "tabTextView";
            this.tabTextView.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextView.Size = new System.Drawing.Size(600, 432);
            this.tabTextView.TabIndex = 2;
            this.tabTextView.Text = "文本视图";
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(3, 3);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
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
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmMain";
            this.ShowSelectSkinButton = true;
            this.SizeAble = true;
            this.Text = "MagicMongoDBTool-Beta2";
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
        /// <summary>
        /// 设置图标
        /// </summary>
        private void SetMenuImage()
        {
            this.PrePageToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.PrePage);
            this.NextPageToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.NextPage);
            this.FirstPageToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.FirstPage);
            this.LastPageToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.LastPage);
            this.QueryDataToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.Query);
            this.DataFilterToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.Filter);

            this.ImportDataFromAccessToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.AccessDB);
            this.RefreshToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.Refresh);
            this.OptionToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.Option);

            this.ThanksToolStripMenuItem.Image = GUIResource.GetResource.GetImage(GUIResource.ImageType.Smile);

        }
        /// <summary>
        /// 初始化Toolbar
        /// </summary>
        private void InitToolBar() {
            FirstPageToolStripButton = this.FirstPageToolStripMenuItem.CloneFromMenuItem();
            PrePageToolStripButton = this.PrePageToolStripMenuItem.CloneFromMenuItem();
            NextPageToolStripButton = this.NextPageToolStripMenuItem.CloneFromMenuItem();
            LastPageToolStripButton = this.LastPageToolStripMenuItem.CloneFromMenuItem();
            QueryDataToolStripButton = this.QueryDataToolStripMenuItem.CloneFromMenuItem();
            DataFilterToolStripButton = this.DataFilterToolStripMenuItem.CloneFromMenuItem();
            DataNaviToolStripLabel = new ToolStripLabel();
            RefreshToolStripButton = this.RefreshToolStripMenuItem.CloneFromMenuItem();
            ImportDataFromAccessToolStripButton = this.ImportDataFromAccessToolStripMenuItem.CloneFromMenuItem();
            OptionToolStripButton = this.OptionToolStripMenuItem.CloneFromMenuItem();

            this.toolStripMain.Items.Add(FirstPageToolStripButton);
            this.toolStripMain.Items.Add(PrePageToolStripButton);
            this.toolStripMain.Items.Add(NextPageToolStripButton);
            this.toolStripMain.Items.Add(LastPageToolStripButton);
            this.toolStripMain.Items.Add(QueryDataToolStripButton);
            this.toolStripMain.Items.Add(DataNaviToolStripLabel);
            this.toolStripMain.Items.Add(DataFilterToolStripButton);
            this.toolStripMain.Items.Add(new ToolStripSeparator());
            this.toolStripMain.Items.Add(RefreshToolStripButton);
            this.toolStripMain.Items.Add(ImportDataFromAccessToolStripButton);
            this.toolStripMain.Items.Add(OptionToolStripButton);
        }
        /// <summary>
        /// 设定工具栏
        /// </summary>
        private void SetToolBarEnabled()
        {
            FirstPageToolStripButton.Enabled = this.FirstPageToolStripMenuItem.Enabled;
            PrePageToolStripButton.Enabled = this.PrePageToolStripMenuItem.Enabled;
            NextPageToolStripButton.Enabled = this.NextPageToolStripMenuItem.Enabled;
            LastPageToolStripButton.Enabled = this.LastPageToolStripMenuItem.Enabled;
            QueryDataToolStripButton.Enabled = this.QueryDataToolStripMenuItem.Enabled;
            DataFilterToolStripButton.Enabled = this.DataFilterToolStripMenuItem.Enabled;
            DataFilterToolStripButton.Checked = this.DataFilterToolStripMenuItem.Checked;
            RefreshToolStripButton.Enabled = this.RefreshToolStripMenuItem.Enabled;
            ImportDataFromAccessToolStripButton.Enabled = this.ImportDataFromAccessToolStripMenuItem.Enabled;
            OptionToolStripButton.Enabled = this.OptionToolStripMenuItem.Enabled;
        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSelectedObj;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SrvStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataNaviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NextPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FirstPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LastPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QueryDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OperationToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DosCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportDataFromAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DistributedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReplicaSetToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem AddUserToAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveUserFromAdminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InitGFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandAllConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollapseAllConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SvrPropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandAllDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollapseAllDataToolStripMenuItem;

        private ToolStripButton ImportDataFromAccessToolStripButton;
        private ToolStripButton RefreshToolStripButton;
        private ToolStripButton OptionToolStripButton;

        private ToolStripButton NextPageToolStripButton;
        private ToolStripButton PrePageToolStripButton;
        private ToolStripButton FirstPageToolStripButton;
        private ToolStripButton LastPageToolStripButton;
        private ToolStripButton QueryDataToolStripButton;
        private ToolStripButton DataFilterToolStripButton;
        private ToolStripLabel DataNaviToolStripLabel;
        private ToolStripMenuItem DumpAndRestoreToolStripMenuItem;
        private ToolStripMenuItem RestoreMongoToolStripMenuItem;
        private ToolStripMenuItem DumpDatabaseToolStripMenuItem;
        private ToolStripMenuItem DumpCollectionToolStripMenuItem;
        private ToolStripMenuItem ImportCollectionToolStripMenuItem;
        private ToolStripMenuItem ExportCollectionToolStripMenuItem;
        private ToolStripMenuItem DataFilterToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem10;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem ReIndexToolStripMenuItem;
        private ToolStripMenuItem AggregationToolStripMenuItem;
        private ToolStripMenuItem countToolStripMenuItem;
        private ToolStripMenuItem distinctToolStripMenuItem;
        private ToolStripMenuItem groupToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem11;
        private ToolStripMenuItem evalJSToolStripMenuItem;
        private ToolStripMenuItem ConvertSqlToolStripMenuItem;
    }
}