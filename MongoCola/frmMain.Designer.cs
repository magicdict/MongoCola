using System.ComponentModel;
using System.Windows.Forms;

namespace MongoCola
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusSelectedObj = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.ManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.ExpandAllConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollapseAllConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.JavaScriptStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplicaSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShardingConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InitReplsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.DisconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.AddUserToAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddAdminCustomeRoleStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.ServerStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateViewtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyDatabasetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDBCustomeRoleStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.EvalJSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatJavaScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RepairDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InitGFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfillingLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DBStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToCappedtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndexManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.AggregationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distinctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapReduceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggregateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geoNearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropJavascriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CollectionStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ValidateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpAndRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreMongoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DumpCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plugInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigfileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MongoDBManualMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShellReferenceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShellMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.AggregationReference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ThanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckUpdatetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trvsrvlst = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabView = new System.Windows.Forms.TabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.Color.Transparent;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusSelectedObj,
            this.lblUserInfo,
            this.lblAction});
            this.statusStripMain.Location = new System.Drawing.Point(0, 724);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1070, 22);
            this.statusStripMain.TabIndex = 8;
            // 
            // toolStripStatusSelectedObj
            // 
            this.toolStripStatusSelectedObj.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusSelectedObj.Name = "toolStripStatusSelectedObj";
            this.toolStripStatusSelectedObj.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusSelectedObj.Text = "Ready";
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(35, 17);
            this.lblUserInfo.Text = "User";
            // 
            // lblAction
            // 
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(44, 17);
            this.lblAction.Text = "Action";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMain.Location = new System.Drawing.Point(0, 25);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1070, 25);
            this.toolStripMain.TabIndex = 7;
            this.toolStripMain.Text = "工具栏";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.OperationToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1070, 25);
            this.menuStripMain.TabIndex = 6;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // ManagerToolStripMenuItem
            // 
            this.ManagerToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.ManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddConnectionToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.toolStripMenuItem10,
            this.ExpandAllConnectionToolStripMenuItem,
            this.CollapseAllConnectionToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ExitToolStripMenuItem});
            this.ManagerToolStripMenuItem.Name = "ManagerToolStripMenuItem";
            this.ManagerToolStripMenuItem.Size = new System.Drawing.Size(97, 21);
            this.ManagerToolStripMenuItem.Tag = "Main_Menu.Mangt";
            this.ManagerToolStripMenuItem.Text = "&Management";
            // 
            // AddConnectionToolStripMenuItem
            // 
            this.AddConnectionToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.AddConnectionToolStripMenuItem.Name = "AddConnectionToolStripMenuItem";
            this.AddConnectionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.AddConnectionToolStripMenuItem.Tag = "Main_Menu.Mangt_AddConnection";
            this.AddConnectionToolStripMenuItem.Text = "&Connection Manager";
            this.AddConnectionToolStripMenuItem.Click += new System.EventHandler(this.AddConnectionToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.RefreshToolStripMenuItem.Tag = "Main_Menu.Mangt_Refresh";
            this.RefreshToolStripMenuItem.Text = "Refresh Connections";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(213, 6);
            // 
            // ExpandAllConnectionToolStripMenuItem
            // 
            this.ExpandAllConnectionToolStripMenuItem.Name = "ExpandAllConnectionToolStripMenuItem";
            this.ExpandAllConnectionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ExpandAllConnectionToolStripMenuItem.Tag = "Common.Expansion";
            this.ExpandAllConnectionToolStripMenuItem.Text = "Expansion";
            this.ExpandAllConnectionToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
            // 
            // CollapseAllConnectionToolStripMenuItem
            // 
            this.CollapseAllConnectionToolStripMenuItem.Name = "CollapseAllConnectionToolStripMenuItem";
            this.CollapseAllConnectionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.CollapseAllConnectionToolStripMenuItem.Tag = "Common.Collapse";
            this.CollapseAllConnectionToolStripMenuItem.Text = "Collapse";
            this.CollapseAllConnectionToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.ExitToolStripMenuItem.Tag = "Main_Menu.Mangt_Exit";
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusToolStripMenuItem,
            this.commandShellToolStripMenuItem,
            this.CollectionToolStripMenuItem,
            this.JavaScriptStripMenuItem,
            this.toolStripMenuItem9,
            this.ViewRefreshToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.ViewToolStripMenuItem.Tag = "Main_Menu.DataView";
            this.ViewToolStripMenuItem.Text = "&View";
            // 
            // StatusToolStripMenuItem
            // 
            this.StatusToolStripMenuItem.Name = "StatusToolStripMenuItem";
            this.StatusToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.StatusToolStripMenuItem.Tag = "Main_Menu.Mangt_Status";
            this.StatusToolStripMenuItem.Text = "Server Status";
            // 
            // commandShellToolStripMenuItem
            // 
            this.commandShellToolStripMenuItem.Name = "commandShellToolStripMenuItem";
            this.commandShellToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.commandShellToolStripMenuItem.Text = "Command Shell";
            // 
            // CollectionToolStripMenuItem
            // 
            this.CollectionToolStripMenuItem.Name = "CollectionToolStripMenuItem";
            this.CollectionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.CollectionToolStripMenuItem.Tag = "Common.Collection";
            this.CollectionToolStripMenuItem.Text = "Collection Data";
            // 
            // JavaScriptStripMenuItem
            // 
            this.JavaScriptStripMenuItem.Name = "JavaScriptStripMenuItem";
            this.JavaScriptStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.JavaScriptStripMenuItem.Text = "JavaScript";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(164, 6);
            // 
            // ViewRefreshToolStripMenuItem
            // 
            this.ViewRefreshToolStripMenuItem.Name = "ViewRefreshToolStripMenuItem";
            this.ViewRefreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5)));
            this.ViewRefreshToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.ViewRefreshToolStripMenuItem.Tag = "Main_Menu.Mangt_Refresh";
            this.ViewRefreshToolStripMenuItem.Text = "Refresh";
            this.ViewRefreshToolStripMenuItem.Click += new System.EventHandler(this.ViewRefreshToolStripMenuItem_Click);
            // 
            // OperationToolStripMenuItem
            // 
            this.OperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.ServerToolStripMenuItem,
            this.DataBaseToolStripMenuItem,
            this.DataCollectionToolStripMenuItem,
            this.DumpAndRestoreToolStripMenuItem});
            this.OperationToolStripMenuItem.Name = "OperationToolStripMenuItem";
            this.OperationToolStripMenuItem.Size = new System.Drawing.Size(79, 21);
            this.OperationToolStripMenuItem.Tag = "Main_Menu.Operation";
            this.OperationToolStripMenuItem.Text = "&Operation";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReplicaSetToolStripMenuItem,
            this.ShardingConfigToolStripMenuItem,
            this.InitReplsetToolStripMenuItem,
            this.toolStripMenuItem2,
            this.DisconnectToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.connectionToolStripMenuItem.Tag = "Common.Connect";
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // ReplicaSetToolStripMenuItem
            // 
            this.ReplicaSetToolStripMenuItem.Name = "ReplicaSetToolStripMenuItem";
            this.ReplicaSetToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ReplicaSetToolStripMenuItem.Tag = "Main_Menu.Distributed_ReplicaSet";
            this.ReplicaSetToolStripMenuItem.Text = "Replset Manager";
            this.ReplicaSetToolStripMenuItem.Click += new System.EventHandler(this.ReplicaSetToolStripMenuItem_Click);
            // 
            // ShardingConfigToolStripMenuItem
            // 
            this.ShardingConfigToolStripMenuItem.Name = "ShardingConfigToolStripMenuItem";
            this.ShardingConfigToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ShardingConfigToolStripMenuItem.Tag = "Main_Menu.Distributed_ShardingConfig";
            this.ShardingConfigToolStripMenuItem.Text = "&Sharding Config";
            this.ShardingConfigToolStripMenuItem.Click += new System.EventHandler(this.ShardingConfigToolStripMenuItem_Click);
            // 
            // InitReplsetToolStripMenuItem
            // 
            this.InitReplsetToolStripMenuItem.Name = "InitReplsetToolStripMenuItem";
            this.InitReplsetToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.InitReplsetToolStripMenuItem.Tag = "Replset_InitReplset";
            this.InitReplsetToolStripMenuItem.Text = "Initiate Replset";
            this.InitReplsetToolStripMenuItem.Click += new System.EventHandler(this.InitReplsetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
            // 
            // DisconnectToolStripMenuItem
            // 
            this.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
            this.DisconnectToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.DisconnectToolStripMenuItem.Tag = "Main_Menu.Mangt_Disconnect";
            this.DisconnectToolStripMenuItem.Text = "Disconnect";
            this.DisconnectToolStripMenuItem.Click += new System.EventHandler(this.DisconnectToolStripMenuItem_Click);
            // 
            // ServerToolStripMenuItem
            // 
            this.ServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMongoDBToolStripMenuItem,
            this.toolStripMenuItem4,
            this.AddUserToAdminToolStripMenuItem,
            this.AddAdminCustomeRoleStripMenuItem,
            this.toolStripMenuItem3,
            this.ServerStatusToolStripMenuItem,
            this.ServerMonitorToolStripMenuItem});
            this.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem";
            this.ServerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ServerToolStripMenuItem.Tag = "Main_Menu.Operation_Server";
            this.ServerToolStripMenuItem.Text = "Server";
            // 
            // CreateMongoDBToolStripMenuItem
            // 
            this.CreateMongoDBToolStripMenuItem.Name = "CreateMongoDBToolStripMenuItem";
            this.CreateMongoDBToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.CreateMongoDBToolStripMenuItem.Tag = "Main_Menu.Operation_Server_NewDB";
            this.CreateMongoDBToolStripMenuItem.Text = "New Database";
            this.CreateMongoDBToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoDBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(229, 6);
            // 
            // AddUserToAdminToolStripMenuItem
            // 
            this.AddUserToAdminToolStripMenuItem.Name = "AddUserToAdminToolStripMenuItem";
            this.AddUserToAdminToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.AddUserToAdminToolStripMenuItem.Tag = "Main_Menu.Operation_Server_AddUserToAdmin";
            this.AddUserToAdminToolStripMenuItem.Text = "Add User To Admin Group";
            this.AddUserToAdminToolStripMenuItem.Click += new System.EventHandler(this.AddUserToAdminToolStripMenuItem_Click);
            // 
            // AddAdminCustomeRoleStripMenuItem
            // 
            this.AddAdminCustomeRoleStripMenuItem.Name = "AddAdminCustomeRoleStripMenuItem";
            this.AddAdminCustomeRoleStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.AddAdminCustomeRoleStripMenuItem.Tag = "Main_Menu.Operation_Server_AddCustomRole";
            this.AddAdminCustomeRoleStripMenuItem.Text = "Add Custom Role";
            this.AddAdminCustomeRoleStripMenuItem.Click += new System.EventHandler(this.AddCustomeRoleStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(229, 6);
            // 
            // ServerStatusToolStripMenuItem
            // 
            this.ServerStatusToolStripMenuItem.Name = "ServerStatusToolStripMenuItem";
            this.ServerStatusToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ServerStatusToolStripMenuItem.Tag = "Main_Menu.Mangt_Status";
            this.ServerStatusToolStripMenuItem.Text = "Status";
            this.ServerStatusToolStripMenuItem.Click += new System.EventHandler(this.SvrStatusToolStripMenuItem_Click);
            // 
            // ServerMonitorToolStripMenuItem
            // 
            this.ServerMonitorToolStripMenuItem.Name = "ServerMonitorToolStripMenuItem";
            this.ServerMonitorToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ServerMonitorToolStripMenuItem.Tag = "Main_Menu.ServerMonitor";
            this.ServerMonitorToolStripMenuItem.Text = "Server Monitor";
            this.ServerMonitorToolStripMenuItem.Click += new System.EventHandler(this.ServerMonitorToolStripMenuItem_Click);
            // 
            // DataBaseToolStripMenuItem
            // 
            this.DataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMongoCollectionToolStripMenuItem,
            this.CreateViewtoolStripMenuItem,
            this.CopyDatabasetoolStripMenuItem,
            this.DelMongoDBToolStripMenuItem,
            this.toolStripMenuItem5,
            this.AddUserToolStripMenuItem,
            this.AddDBCustomeRoleStripMenuItem,
            this.toolStripMenuItem11,
            this.EvalJSToolStripMenuItem,
            this.creatJavaScriptToolStripMenuItem,
            this.toolStripSeparator1,
            this.RepairDBToolStripMenuItem,
            this.InitGFSToolStripMenuItem,
            this.ProfillingLevelToolStripMenuItem,
            this.DBStatusToolStripMenuItem});
            this.DataBaseToolStripMenuItem.Name = "DataBaseToolStripMenuItem";
            this.DataBaseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.DataBaseToolStripMenuItem.Tag = "Main_Menu.Operation_Database";
            this.DataBaseToolStripMenuItem.Text = "Database";
            // 
            // CreateMongoCollectionToolStripMenuItem
            // 
            this.CreateMongoCollectionToolStripMenuItem.Name = "CreateMongoCollectionToolStripMenuItem";
            this.CreateMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.CreateMongoCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_Database_AddCollection";
            this.CreateMongoCollectionToolStripMenuItem.Text = "New Collection";
            this.CreateMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoCollectionToolStripMenuItem_Click);
            // 
            // CreateViewtoolStripMenuItem
            // 
            this.CreateViewtoolStripMenuItem.Name = "CreateViewtoolStripMenuItem";
            this.CreateViewtoolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.CreateViewtoolStripMenuItem.Tag = "Main_Menu.Operation_Database_AddView";
            this.CreateViewtoolStripMenuItem.Text = "New View";
            this.CreateViewtoolStripMenuItem.Click += new System.EventHandler(this.CreateViewtoolStripMenuItem_Click);
            // 
            // CopyDatabasetoolStripMenuItem
            // 
            this.CopyDatabasetoolStripMenuItem.Name = "CopyDatabasetoolStripMenuItem";
            this.CopyDatabasetoolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.CopyDatabasetoolStripMenuItem.Tag = "Main_Menu.Operation_Database_CopyDB";
            this.CopyDatabasetoolStripMenuItem.Text = "Copy Database";
            this.CopyDatabasetoolStripMenuItem.Click += new System.EventHandler(this.CopyDatabasetoolStripMenuItem_Click);
            // 
            // DelMongoDBToolStripMenuItem
            // 
            this.DelMongoDBToolStripMenuItem.Name = "DelMongoDBToolStripMenuItem";
            this.DelMongoDBToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.DelMongoDBToolStripMenuItem.Tag = "Main_Menu.Operation_Database_DelDB";
            this.DelMongoDBToolStripMenuItem.Text = "Del Database";
            this.DelMongoDBToolStripMenuItem.Click += new System.EventHandler(this.DelMongoDBToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(192, 6);
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.AddUserToolStripMenuItem.Tag = "Main_Menu.Operation_Database_AddUser";
            this.AddUserToolStripMenuItem.Text = "Add User";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
            // 
            // AddDBCustomeRoleStripMenuItem
            // 
            this.AddDBCustomeRoleStripMenuItem.Name = "AddDBCustomeRoleStripMenuItem";
            this.AddDBCustomeRoleStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.AddDBCustomeRoleStripMenuItem.Tag = "Main_Menu.Operation_Server_AddCustomRole";
            this.AddDBCustomeRoleStripMenuItem.Text = "Add Custom Role";
            this.AddDBCustomeRoleStripMenuItem.Click += new System.EventHandler(this.AddDBCustomeRoleStripMenuItem_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(192, 6);
            // 
            // EvalJSToolStripMenuItem
            // 
            this.EvalJSToolStripMenuItem.Name = "EvalJSToolStripMenuItem";
            this.EvalJSToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.EvalJSToolStripMenuItem.Tag = "Main_Menu.Operation_Database_EvalJs";
            this.EvalJSToolStripMenuItem.Text = "Eval Javascript(Shell)";
            this.EvalJSToolStripMenuItem.Click += new System.EventHandler(this.evalJSToolStripMenuItem_Click);
            // 
            // creatJavaScriptToolStripMenuItem
            // 
            this.creatJavaScriptToolStripMenuItem.Name = "creatJavaScriptToolStripMenuItem";
            this.creatJavaScriptToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.creatJavaScriptToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_CreateJavaScript";
            this.creatJavaScriptToolStripMenuItem.Text = "Creat JavaScript";
            this.creatJavaScriptToolStripMenuItem.Click += new System.EventHandler(this.creatJavaScriptToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // RepairDBToolStripMenuItem
            // 
            this.RepairDBToolStripMenuItem.Name = "RepairDBToolStripMenuItem";
            this.RepairDBToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.RepairDBToolStripMenuItem.Tag = "Main_Menu.Operation_Database_RepairDatabase";
            this.RepairDBToolStripMenuItem.Text = "Repair Database";
            this.RepairDBToolStripMenuItem.Click += new System.EventHandler(this.RepairDBToolStripMenuItem_Click);
            // 
            // InitGFSToolStripMenuItem
            // 
            this.InitGFSToolStripMenuItem.Name = "InitGFSToolStripMenuItem";
            this.InitGFSToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.InitGFSToolStripMenuItem.Tag = "Main_Menu.Operation_FileSystem_InitGFS";
            this.InitGFSToolStripMenuItem.Text = "Init GFS";
            // 
            // ProfillingLevelToolStripMenuItem
            // 
            this.ProfillingLevelToolStripMenuItem.Name = "ProfillingLevelToolStripMenuItem";
            this.ProfillingLevelToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.ProfillingLevelToolStripMenuItem.Tag = "Main_Menu.Operation_ProfillingLevel";
            this.ProfillingLevelToolStripMenuItem.Text = "Profilling Level";
            this.ProfillingLevelToolStripMenuItem.Click += new System.EventHandler(this.profillingLevelToolStripMenuItem_Click);
            // 
            // DBStatusToolStripMenuItem
            // 
            this.DBStatusToolStripMenuItem.Name = "DBStatusToolStripMenuItem";
            this.DBStatusToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.DBStatusToolStripMenuItem.Tag = "Main_Menu.Mangt_Status";
            this.DBStatusToolStripMenuItem.Text = "Status";
            this.DBStatusToolStripMenuItem.Click += new System.EventHandler(this.DBStatusToolStripMenuItem_Click);
            // 
            // DataCollectionToolStripMenuItem
            // 
            this.DataCollectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelMongoCollectionToolStripMenuItem,
            this.RenameCollectionToolStripMenuItem,
            this.ConvertToCappedtoolStripMenuItem,
            this.IndexManageToolStripMenuItem,
            this.ReIndexToolStripMenuItem,
            this.CompactToolStripMenuItem,
            this.toolStripMenuItem8,
            this.AggregationToolStripMenuItem,
            this.ViewDataToolStripMenuItem,
            this.dropJavascriptToolStripMenuItem,
            this.CollectionStatusToolStripMenuItem,
            this.ValidateToolStripMenuItem,
            this.ExportToFileToolStripMenuItem});
            this.DataCollectionToolStripMenuItem.Name = "DataCollectionToolStripMenuItem";
            this.DataCollectionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.DataCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection";
            this.DataCollectionToolStripMenuItem.Text = "Collection";
            // 
            // DelMongoCollectionToolStripMenuItem
            // 
            this.DelMongoCollectionToolStripMenuItem.Name = "DelMongoCollectionToolStripMenuItem";
            this.DelMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.DelMongoCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_DelDC";
            this.DelMongoCollectionToolStripMenuItem.Text = "Drop Collection";
            this.DelMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.DelMongoCollectionToolStripMenuItem_Click);
            // 
            // RenameCollectionToolStripMenuItem
            // 
            this.RenameCollectionToolStripMenuItem.Name = "RenameCollectionToolStripMenuItem";
            this.RenameCollectionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.RenameCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_Rename";
            this.RenameCollectionToolStripMenuItem.Text = "Rename Collection";
            this.RenameCollectionToolStripMenuItem.Click += new System.EventHandler(this.RenameCollectionToolStripMenuItem_Click);
            // 
            // ConvertToCappedtoolStripMenuItem
            // 
            this.ConvertToCappedtoolStripMenuItem.Name = "ConvertToCappedtoolStripMenuItem";
            this.ConvertToCappedtoolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ConvertToCappedtoolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_convertToCapped";
            this.ConvertToCappedtoolStripMenuItem.Text = "ConvertToCapped";
            this.ConvertToCappedtoolStripMenuItem.Click += new System.EventHandler(this.ConvertToCappedtoolStripMenuItem_Click);
            // 
            // IndexManageToolStripMenuItem
            // 
            this.IndexManageToolStripMenuItem.Name = "IndexManageToolStripMenuItem";
            this.IndexManageToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.IndexManageToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_Index";
            this.IndexManageToolStripMenuItem.Text = "Index Management";
            this.IndexManageToolStripMenuItem.Click += new System.EventHandler(this.IndexManageToolStripMenuItem_Click);
            // 
            // ReIndexToolStripMenuItem
            // 
            this.ReIndexToolStripMenuItem.Name = "ReIndexToolStripMenuItem";
            this.ReIndexToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ReIndexToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_ReIndex";
            this.ReIndexToolStripMenuItem.Text = "ReIndex";
            this.ReIndexToolStripMenuItem.Click += new System.EventHandler(this.ReIndexToolStripMenuItem_Click);
            // 
            // CompactToolStripMenuItem
            // 
            this.CompactToolStripMenuItem.Name = "CompactToolStripMenuItem";
            this.CompactToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.CompactToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_Compact";
            this.CompactToolStripMenuItem.Text = "Compact";
            this.CompactToolStripMenuItem.Click += new System.EventHandler(this.CompactToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(193, 6);
            // 
            // AggregationToolStripMenuItem
            // 
            this.AggregationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distinctToolStripMenuItem,
            this.mapReduceToolStripMenuItem,
            this.aggregateToolStripMenuItem,
            this.textSearchToolStripMenuItem,
            this.geoNearToolStripMenuItem});
            this.AggregationToolStripMenuItem.Name = "AggregationToolStripMenuItem";
            this.AggregationToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.AggregationToolStripMenuItem.Tag = "Main_Menu.DataView_Aggregation";
            this.AggregationToolStripMenuItem.Text = "Aggregation";
            // 
            // distinctToolStripMenuItem
            // 
            this.distinctToolStripMenuItem.Name = "distinctToolStripMenuItem";
            this.distinctToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.distinctToolStripMenuItem.Text = "Distinct";
            this.distinctToolStripMenuItem.Click += new System.EventHandler(this.distinctToolStripMenuItem_Click);
            // 
            // mapReduceToolStripMenuItem
            // 
            this.mapReduceToolStripMenuItem.Name = "mapReduceToolStripMenuItem";
            this.mapReduceToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.mapReduceToolStripMenuItem.Text = "MapReduce";
            this.mapReduceToolStripMenuItem.Click += new System.EventHandler(this.mapReduceToolStripMenuItem_Click);
            // 
            // aggregateToolStripMenuItem
            // 
            this.aggregateToolStripMenuItem.Name = "aggregateToolStripMenuItem";
            this.aggregateToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aggregateToolStripMenuItem.Text = "Aggregate";
            this.aggregateToolStripMenuItem.Click += new System.EventHandler(this.aggregateToolStripMenuItem_Click);
            // 
            // textSearchToolStripMenuItem
            // 
            this.textSearchToolStripMenuItem.Name = "textSearchToolStripMenuItem";
            this.textSearchToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.textSearchToolStripMenuItem.Text = "TextSearch";
            this.textSearchToolStripMenuItem.Click += new System.EventHandler(this.textSearchToolStripMenuItem_Click);
            // 
            // geoNearToolStripMenuItem
            // 
            this.geoNearToolStripMenuItem.Name = "geoNearToolStripMenuItem";
            this.geoNearToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.geoNearToolStripMenuItem.Text = "GeoNear";
            this.geoNearToolStripMenuItem.Click += new System.EventHandler(this.geoNearToolStripMenuItem_Click);
            // 
            // ViewDataToolStripMenuItem
            // 
            this.ViewDataToolStripMenuItem.Name = "ViewDataToolStripMenuItem";
            this.ViewDataToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ViewDataToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_View";
            this.ViewDataToolStripMenuItem.Text = "ViewData";
            // 
            // dropJavascriptToolStripMenuItem
            // 
            this.dropJavascriptToolStripMenuItem.Name = "dropJavascriptToolStripMenuItem";
            this.dropJavascriptToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.dropJavascriptToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_DropJavaScript";
            this.dropJavascriptToolStripMenuItem.Text = "Drop Javascript";
            this.dropJavascriptToolStripMenuItem.Click += new System.EventHandler(this.dropJavascriptToolStripMenuItem_Click);
            // 
            // CollectionStatusToolStripMenuItem
            // 
            this.CollectionStatusToolStripMenuItem.Name = "CollectionStatusToolStripMenuItem";
            this.CollectionStatusToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.CollectionStatusToolStripMenuItem.Tag = "Main_Menu.Mangt_Status";
            this.CollectionStatusToolStripMenuItem.Text = "Status";
            this.CollectionStatusToolStripMenuItem.Click += new System.EventHandler(this.CollectionStatusToolStripMenuItem_Click);
            // 
            // ValidateToolStripMenuItem
            // 
            this.ValidateToolStripMenuItem.Name = "ValidateToolStripMenuItem";
            this.ValidateToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ValidateToolStripMenuItem.Tag = "Common.Validate";
            this.ValidateToolStripMenuItem.Text = "Validate";
            this.ValidateToolStripMenuItem.Click += new System.EventHandler(this.validateToolStripMenuItem_Click);
            // 
            // ExportToFileToolStripMenuItem
            // 
            this.ExportToFileToolStripMenuItem.Name = "ExportToFileToolStripMenuItem";
            this.ExportToFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ExportToFileToolStripMenuItem.Tag = "Main_Menu.Operation_DataCollection_ExportToFile";
            this.ExportToFileToolStripMenuItem.Text = "ExportImport To File";
            this.ExportToFileToolStripMenuItem.Click += new System.EventHandler(this.ExportToFileToolStripMenuItem_Click);
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
            this.DumpAndRestoreToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.DumpAndRestoreToolStripMenuItem.Tag = "Main_Menu.Operation_BackupAndRestore";
            this.DumpAndRestoreToolStripMenuItem.Text = "Dump And Restore";
            // 
            // RestoreMongoToolStripMenuItem
            // 
            this.RestoreMongoToolStripMenuItem.Name = "RestoreMongoToolStripMenuItem";
            this.RestoreMongoToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.RestoreMongoToolStripMenuItem.Tag = "Main_Menu.Operation_BackupAndRestore_Restore";
            this.RestoreMongoToolStripMenuItem.Text = "Restore";
            this.RestoreMongoToolStripMenuItem.Click += new System.EventHandler(this.RestoreMongoToolStripMenuItem_Click);
            // 
            // DumpDatabaseToolStripMenuItem
            // 
            this.DumpDatabaseToolStripMenuItem.Name = "DumpDatabaseToolStripMenuItem";
            this.DumpDatabaseToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.DumpDatabaseToolStripMenuItem.Tag = "Main_Menu.Operation_BackupAndRestore_BackupDB";
            this.DumpDatabaseToolStripMenuItem.Text = "Dump DataBase";
            this.DumpDatabaseToolStripMenuItem.Click += new System.EventHandler(this.DumpDatabaseToolStripMenuItem_Click);
            // 
            // DumpCollectionToolStripMenuItem
            // 
            this.DumpCollectionToolStripMenuItem.Name = "DumpCollectionToolStripMenuItem";
            this.DumpCollectionToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.DumpCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_BackupAndRestore_BackupDC";
            this.DumpCollectionToolStripMenuItem.Text = "Dump Collection";
            this.DumpCollectionToolStripMenuItem.Click += new System.EventHandler(this.DumpCollectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(239, 6);
            // 
            // ImportCollectionToolStripMenuItem
            // 
            this.ImportCollectionToolStripMenuItem.Name = "ImportCollectionToolStripMenuItem";
            this.ImportCollectionToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.ImportCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_BackupAndRestore_Import";
            this.ImportCollectionToolStripMenuItem.Text = "Import DataCollection";
            this.ImportCollectionToolStripMenuItem.Click += new System.EventHandler(this.ImportCollectionToolStripMenuItem_Click);
            // 
            // ExportCollectionToolStripMenuItem
            // 
            this.ExportCollectionToolStripMenuItem.Name = "ExportCollectionToolStripMenuItem";
            this.ExportCollectionToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.ExportCollectionToolStripMenuItem.Tag = "Main_Menu.Operation_BackupAndRestore_Export";
            this.ExportCollectionToolStripMenuItem.Text = "ExportImport DataCollection";
            this.ExportCollectionToolStripMenuItem.Click += new System.EventHandler(this.ExportCollectionToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plugInToolStripMenuItem,
            this.ConfigfileMenuItem,
            this.MultiLanguageToolStripMenuItem,
            this.toolStripMenuItem7,
            this.OptionsToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.ToolsToolStripMenuItem.Tag = "Main_Menu.Tool";
            this.ToolsToolStripMenuItem.Text = "&Tools";
            // 
            // plugInToolStripMenuItem
            // 
            this.plugInToolStripMenuItem.Name = "plugInToolStripMenuItem";
            this.plugInToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.plugInToolStripMenuItem.Tag = "Common.PlugIn";
            this.plugInToolStripMenuItem.Text = "PlugIn";
            // 
            // ConfigfileMenuItem
            // 
            this.ConfigfileMenuItem.Name = "ConfigfileMenuItem";
            this.ConfigfileMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ConfigfileMenuItem.Text = "ConfigFile";
            this.ConfigfileMenuItem.Click += new System.EventHandler(this.ConfigfileMenuItem_Click);
            // 
            // MultiLanguageToolStripMenuItem
            // 
            this.MultiLanguageToolStripMenuItem.Name = "MultiLanguageToolStripMenuItem";
            this.MultiLanguageToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.MultiLanguageToolStripMenuItem.Text = "MultiLanguage";
            this.MultiLanguageToolStripMenuItem.Click += new System.EventHandler(this.MultiLanguageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(159, 6);
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.OptionsToolStripMenuItem.Tag = "Main_Menu.Tool_Setting";
            this.OptionsToolStripMenuItem.Text = "&Options";
            this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MongoDBManualMenuItem,
            this.ShellReferenceMenuItem,
            this.ShellMethod,
            this.AggregationReference,
            this.toolStripSeparator3,
            this.ThanksToolStripMenuItem,
            this.UserGuideToolStripMenuItem,
            this.toolStripSeparator2,
            this.CheckUpdatetoolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.HelpToolStripMenuItem.Tag = "Main_Menu.Help";
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // MongoDBManualMenuItem
            // 
            this.MongoDBManualMenuItem.Name = "MongoDBManualMenuItem";
            this.MongoDBManualMenuItem.Size = new System.Drawing.Size(361, 22);
            this.MongoDBManualMenuItem.Text = "MongoDB Manual";
            this.MongoDBManualMenuItem.Click += new System.EventHandler(this.MongoDBManualMenuItem_Click);
            // 
            // ShellReferenceMenuItem
            // 
            this.ShellReferenceMenuItem.Name = "ShellReferenceMenuItem";
            this.ShellReferenceMenuItem.Size = new System.Drawing.Size(361, 22);
            this.ShellReferenceMenuItem.Text = "MongoDB Shell Quick Reference";
            this.ShellReferenceMenuItem.Click += new System.EventHandler(this.ShellReferenceMenuItem_Click);
            // 
            // ShellMethod
            // 
            this.ShellMethod.Name = "ShellMethod";
            this.ShellMethod.Size = new System.Drawing.Size(361, 22);
            this.ShellMethod.Text = "MongoDB Shell Methods";
            this.ShellMethod.Click += new System.EventHandler(this.ShellMethod_Click);
            // 
            // AggregationReference
            // 
            this.AggregationReference.Name = "AggregationReference";
            this.AggregationReference.Size = new System.Drawing.Size(361, 22);
            this.AggregationReference.Text = "MongoDB Aggregation Pipeline Quick Reference";
            this.AggregationReference.Click += new System.EventHandler(this.AggregationReference_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(358, 6);
            // 
            // ThanksToolStripMenuItem
            // 
            this.ThanksToolStripMenuItem.Name = "ThanksToolStripMenuItem";
            this.ThanksToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.ThanksToolStripMenuItem.Tag = "Main_Menu.Help_Thanks";
            this.ThanksToolStripMenuItem.Text = "&Thanks";
            this.ThanksToolStripMenuItem.Click += new System.EventHandler(this.ThanksToolStripMenuItem_Click);
            // 
            // UserGuideToolStripMenuItem
            // 
            this.UserGuideToolStripMenuItem.Name = "UserGuideToolStripMenuItem";
            this.UserGuideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.UserGuideToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.UserGuideToolStripMenuItem.Tag = "Main_Menu.Help_UserGuide";
            this.UserGuideToolStripMenuItem.Text = "UserGuide";
            this.UserGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(358, 6);
            // 
            // CheckUpdatetoolStripMenuItem
            // 
            this.CheckUpdatetoolStripMenuItem.Name = "CheckUpdatetoolStripMenuItem";
            this.CheckUpdatetoolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.CheckUpdatetoolStripMenuItem.Tag = "Main_Menu.Help_CheckUpdate";
            this.CheckUpdatetoolStripMenuItem.Text = "Check Update";
            this.CheckUpdatetoolStripMenuItem.Click += new System.EventHandler(this.CheckUpdatetoolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.AboutToolStripMenuItem.Tag = "Main_Menu.Help_About";
            this.AboutToolStripMenuItem.Text = "&About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(61, 4);
            // 
            // trvsrvlst
            // 
            this.trvsrvlst.BackColor = System.Drawing.Color.White;
            this.trvsrvlst.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvsrvlst.Location = new System.Drawing.Point(0, 0);
            this.trvsrvlst.Name = "trvsrvlst";
            this.trvsrvlst.ShowNodeToolTips = true;
            this.trvsrvlst.Size = new System.Drawing.Size(293, 674);
            this.trvsrvlst.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.trvsrvlst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 674);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(296, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(774, 674);
            this.panel2.TabIndex = 2;
            // 
            // tabView
            // 
            this.tabView.AllowDrop = true;
            this.tabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabView.Location = new System.Drawing.Point(0, 0);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.ShowToolTips = true;
            this.tabView.Size = new System.Drawing.Size(774, 674);
            this.tabView.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(293, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 674);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1070, 746);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MongoCola";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusSelectedObj;
        private ToolStrip toolStripMain;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem ManagerToolStripMenuItem;
        private ToolStripMenuItem AddConnectionToolStripMenuItem;
        private ToolStripMenuItem RefreshToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem ViewToolStripMenuItem;
        private ToolStripMenuItem OperationToolStripMenuItem;
        private ToolStripMenuItem DataBaseToolStripMenuItem;
        private ToolStripMenuItem DelMongoDBToolStripMenuItem;
        private ToolStripMenuItem CreateMongoCollectionToolStripMenuItem;
        private ToolStripMenuItem DataCollectionToolStripMenuItem;
        private ToolStripMenuItem DelMongoCollectionToolStripMenuItem;
        private ToolStripMenuItem IndexManageToolStripMenuItem;
        private ToolStripMenuItem AddUserToolStripMenuItem;
        private ToolStripMenuItem RenameCollectionToolStripMenuItem;
        private ToolStripMenuItem ToolsToolStripMenuItem;
        private ToolStripMenuItem OptionsToolStripMenuItem;
        private ContextMenuStrip contextMenuStripMain;
        private ToolStripMenuItem HelpToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private ToolStripMenuItem ThanksToolStripMenuItem;
        private ToolStripMenuItem ExpandAllConnectionToolStripMenuItem;
        private ToolStripMenuItem CollapseAllConnectionToolStripMenuItem;


        private ToolStripButton ExpandAllConnectionToolStripButton;
        private ToolStripButton CollapseAllConnectionToolStripButton;
        private ToolStripButton RefreshToolStripButton;
        private ToolStripButton ExitToolStripButton;
        private ToolStripButton OptionToolStripButton;
        private ToolStripButton UserGuideToolStripButton;
        //private ToolStripButton ShutDownToolStripButton;



        private ToolStripMenuItem DumpAndRestoreToolStripMenuItem;
        private ToolStripMenuItem RestoreMongoToolStripMenuItem;
        private ToolStripMenuItem DumpDatabaseToolStripMenuItem;
        private ToolStripMenuItem DumpCollectionToolStripMenuItem;
        private ToolStripMenuItem ImportCollectionToolStripMenuItem;
        private ToolStripMenuItem ExportCollectionToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem10;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripSeparator toolStripMenuItem8;
        private ToolStripSeparator toolStripMenuItem6;
        private ToolStripSeparator toolStripMenuItem7;
        private ToolStripMenuItem ReIndexToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem11;
        private ToolStripMenuItem EvalJSToolStripMenuItem;
        private ToolStripStatusLabel lblUserInfo;
        private TreeView trvsrvlst;
        private ToolStripMenuItem RepairDBToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Splitter splitter1;
        private ToolStripMenuItem UserGuideToolStripMenuItem;
        private ToolStripMenuItem CompactToolStripMenuItem;
        private ToolStripMenuItem StatusToolStripMenuItem;
        private ToolStripMenuItem commandShellToolStripMenuItem;
        private ToolStripMenuItem CollectionToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem ViewRefreshToolStripMenuItem;
        private ToolStripMenuItem InitGFSToolStripMenuItem;
        private ToolStripMenuItem JavaScriptStripMenuItem;
        private ToolStripMenuItem AggregationToolStripMenuItem;
        private ToolStripMenuItem distinctToolStripMenuItem;
        private ToolStripMenuItem mapReduceToolStripMenuItem;
        private ToolStripMenuItem ViewDataToolStripMenuItem;
        private ToolStripMenuItem ProfillingLevelToolStripMenuItem;
        private ToolStripMenuItem creatJavaScriptToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem dropJavascriptToolStripMenuItem;
        private ToolStripMenuItem DBStatusToolStripMenuItem;
        private ToolStripMenuItem CollectionStatusToolStripMenuItem;
        private ToolStripMenuItem connectionToolStripMenuItem;
        private ToolStripMenuItem ReplicaSetToolStripMenuItem;
        private ToolStripMenuItem ShardingConfigToolStripMenuItem;
        private ToolStripMenuItem DisconnectToolStripMenuItem;
        private ToolStripMenuItem InitReplsetToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem ServerToolStripMenuItem;
        private ToolStripMenuItem CreateMongoDBToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem AddUserToAdminToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem ServerStatusToolStripMenuItem;
        //private ToolStripMenuItem ShutDownToolStripMenuItem;
        private ToolStripStatusLabel lblAction;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem aggregateToolStripMenuItem;
        private ToolStripMenuItem textSearchToolStripMenuItem;
        private ToolStripMenuItem ValidateToolStripMenuItem;
        private ToolStripMenuItem CopyDatabasetoolStripMenuItem;
        private ToolStripMenuItem ExportToFileToolStripMenuItem;
        private ToolStripMenuItem plugInToolStripMenuItem;
        private ToolStripMenuItem AddAdminCustomeRoleStripMenuItem;
        private ToolStripMenuItem AddDBCustomeRoleStripMenuItem;
        private TabControl tabView;
        private ToolStripMenuItem ConfigfileMenuItem;
        private ToolStripMenuItem MultiLanguageToolStripMenuItem;
        private ToolStripMenuItem CreateViewtoolStripMenuItem;
        private ToolStripMenuItem MongoDBManualMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ShellReferenceMenuItem;
        private ToolStripMenuItem ShellMethod;
        private ToolStripMenuItem AggregationReference;
        private ToolStripMenuItem geoNearToolStripMenuItem;
        private ToolStripMenuItem ServerMonitorToolStripMenuItem;
        private ToolStripMenuItem CheckUpdatetoolStripMenuItem;
        private ToolStripMenuItem ConvertToCappedtoolStripMenuItem;
    }
}

