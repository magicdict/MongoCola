using System.Windows.Forms;
using MongoUtility.Operation;
using MongoGUICtl;

namespace MongoCola
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
        	this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.commandShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.collectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.JavaScriptStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
        	this.ViewRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.OperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ReplicaSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ShardingConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.InitReplsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
        	this.ShutDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.DisconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.CreateMongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
        	this.AddUserToAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.AddAdminCustomeRoleStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.UserInfoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
        	this.slaveResyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ServePropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ServerStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.DataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.CreateMongoCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
        	this.IndexManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ReIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.CompactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
        	this.AggregationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.countToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.distinctToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mapReduceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.aggregateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.textSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
        	this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
        	this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ThanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.UserGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.trvsrvlst = new System.Windows.Forms.TreeView();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.panel2 = new System.Windows.Forms.Panel();
        	this.tabView = new System.Windows.Forms.TabControl();
        	this.tabSvrStatus = new System.Windows.Forms.TabPage();
        	this.ServerStatusCtl = new MongoGUICtl.ctlServerStatus();
        	this.tabCommandShell = new System.Windows.Forms.TabPage();
        	this.ctlShellCommandEditor = new MongoGUICtl.ctlJsEditor();
        	this.splitter1 = new System.Windows.Forms.Splitter();
        	this.statusStripMain.SuspendLayout();
        	this.menuStripMain.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.panel2.SuspendLayout();
        	this.tabView.SuspendLayout();
        	this.tabSvrStatus.SuspendLayout();
        	this.tabCommandShell.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// statusStripMain
        	// 
        	this.statusStripMain.BackColor = System.Drawing.Color.Transparent;
        	this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusSelectedObj,
			this.lblUserInfo,
			this.lblAction});
        	this.statusStripMain.Location = new System.Drawing.Point(0, 680);
        	this.statusStripMain.Name = "statusStripMain";
        	this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
        	this.statusStripMain.Size = new System.Drawing.Size(1223, 22);
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
        	this.toolStripMain.Size = new System.Drawing.Size(1223, 25);
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
        	this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
        	this.menuStripMain.Size = new System.Drawing.Size(1223, 25);
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
        	this.ManagerToolStripMenuItem.Text = "&Management";
        	// 
        	// AddConnectionToolStripMenuItem
        	// 
        	this.AddConnectionToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
        	this.AddConnectionToolStripMenuItem.Name = "AddConnectionToolStripMenuItem";
        	this.AddConnectionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
        	this.AddConnectionToolStripMenuItem.Text = "&Connection Manager";
        	this.AddConnectionToolStripMenuItem.Click += new System.EventHandler(this.AddConnectionToolStripMenuItem_Click);
        	// 
        	// RefreshToolStripMenuItem
        	// 
        	this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
        	this.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
        	this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
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
        	this.ExpandAllConnectionToolStripMenuItem.Text = "Expansion";
        	this.ExpandAllConnectionToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItem_Click);
        	// 
        	// CollapseAllConnectionToolStripMenuItem
        	// 
        	this.CollapseAllConnectionToolStripMenuItem.Name = "CollapseAllConnectionToolStripMenuItem";
        	this.CollapseAllConnectionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
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
        	this.ExitToolStripMenuItem.Text = "Exit";
        	this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
        	// 
        	// ViewToolStripMenuItem
        	// 
        	this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.statusToolStripMenuItem,
			this.commandShellToolStripMenuItem,
			this.collectionToolStripMenuItem,
			this.JavaScriptStripMenuItem,
			this.toolStripMenuItem9,
			this.ViewRefreshToolStripMenuItem});
        	this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
        	this.ViewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
        	this.ViewToolStripMenuItem.Text = "&View";
        	// 
        	// statusToolStripMenuItem
        	// 
        	this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
        	this.statusToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
        	this.statusToolStripMenuItem.Text = "Server Status";
        	this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
        	// 
        	// commandShellToolStripMenuItem
        	// 
        	this.commandShellToolStripMenuItem.Name = "commandShellToolStripMenuItem";
        	this.commandShellToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
        	this.commandShellToolStripMenuItem.Text = "Command Shell";
        	this.commandShellToolStripMenuItem.Click += new System.EventHandler(this.commandShellToolStripMenuItem_Click);
        	// 
        	// collectionToolStripMenuItem
        	// 
        	this.collectionToolStripMenuItem.Name = "collectionToolStripMenuItem";
        	this.collectionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
        	this.collectionToolStripMenuItem.Text = "Collection Data";
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
        	this.OperationToolStripMenuItem.Text = "&Operation";
        	// 
        	// connectionToolStripMenuItem
        	// 
        	this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ReplicaSetToolStripMenuItem,
			this.ShardingConfigToolStripMenuItem,
			this.InitReplsetToolStripMenuItem,
			this.toolStripMenuItem2,
			this.ShutDownToolStripMenuItem,
			this.DisconnectToolStripMenuItem});
        	this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
        	this.connectionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.connectionToolStripMenuItem.Text = "Connection";
        	// 
        	// ReplicaSetToolStripMenuItem
        	// 
        	this.ReplicaSetToolStripMenuItem.Name = "ReplicaSetToolStripMenuItem";
        	this.ReplicaSetToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.ReplicaSetToolStripMenuItem.Text = "Replset Manager";
        	this.ReplicaSetToolStripMenuItem.Click += new System.EventHandler(this.ReplicaSetToolStripMenuItem_Click);
        	// 
        	// ShardingConfigToolStripMenuItem
        	// 
        	this.ShardingConfigToolStripMenuItem.Name = "ShardingConfigToolStripMenuItem";
        	this.ShardingConfigToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.ShardingConfigToolStripMenuItem.Text = "&Sharding Config";
        	this.ShardingConfigToolStripMenuItem.Click += new System.EventHandler(this.ShardingConfigToolStripMenuItem_Click);
        	// 
        	// InitReplsetToolStripMenuItem
        	// 
        	this.InitReplsetToolStripMenuItem.Name = "InitReplsetToolStripMenuItem";
        	this.InitReplsetToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.InitReplsetToolStripMenuItem.Text = "Initiate Replset";
        	this.InitReplsetToolStripMenuItem.Click += new System.EventHandler(this.InitReplsetToolStripMenuItem_Click);
        	// 
        	// toolStripMenuItem2
        	// 
        	this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        	this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 6);
        	// 
        	// ShutDownToolStripMenuItem
        	// 
        	this.ShutDownToolStripMenuItem.Name = "ShutDownToolStripMenuItem";
        	this.ShutDownToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.ShutDownToolStripMenuItem.Text = "ShutDown Server";
        	this.ShutDownToolStripMenuItem.Click += new System.EventHandler(this.ShutDownToolStripMenuItem_Click);
        	// 
        	// DisconnectToolStripMenuItem
        	// 
        	this.DisconnectToolStripMenuItem.Name = "DisconnectToolStripMenuItem";
        	this.DisconnectToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
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
			this.UserInfoStripMenuItem,
			this.toolStripMenuItem3,
			this.slaveResyncToolStripMenuItem,
			this.ServePropertyToolStripMenuItem,
			this.ServerStatusToolStripMenuItem});
        	this.ServerToolStripMenuItem.Name = "ServerToolStripMenuItem";
        	this.ServerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.ServerToolStripMenuItem.Text = "Server";
        	// 
        	// CreateMongoDBToolStripMenuItem
        	// 
        	this.CreateMongoDBToolStripMenuItem.Name = "CreateMongoDBToolStripMenuItem";
        	this.CreateMongoDBToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
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
        	this.AddUserToAdminToolStripMenuItem.Text = "Add User To Admin Group";
        	this.AddUserToAdminToolStripMenuItem.Click += new System.EventHandler(this.AddUserToAdminToolStripMenuItem_Click);
        	// 
        	// AddAdminCustomeRoleStripMenuItem
        	// 
        	this.AddAdminCustomeRoleStripMenuItem.Name = "AddAdminCustomeRoleStripMenuItem";
        	this.AddAdminCustomeRoleStripMenuItem.Size = new System.Drawing.Size(232, 22);
        	this.AddAdminCustomeRoleStripMenuItem.Text = "Add Custom Role";
        	this.AddAdminCustomeRoleStripMenuItem.Click += new System.EventHandler(this.AddCustomeRoleStripMenuItem_Click);
        	// 
        	// UserInfoStripMenuItem
        	// 
        	this.UserInfoStripMenuItem.Name = "UserInfoStripMenuItem";
        	this.UserInfoStripMenuItem.Size = new System.Drawing.Size(232, 22);
        	this.UserInfoStripMenuItem.Text = "User Information";
        	this.UserInfoStripMenuItem.Click += new System.EventHandler(this.UserInfoStripMenuItem_Click);
        	// 
        	// toolStripMenuItem3
        	// 
        	this.toolStripMenuItem3.Name = "toolStripMenuItem3";
        	this.toolStripMenuItem3.Size = new System.Drawing.Size(229, 6);
        	// 
        	// slaveResyncToolStripMenuItem
        	// 
        	this.slaveResyncToolStripMenuItem.Name = "slaveResyncToolStripMenuItem";
        	this.slaveResyncToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
        	this.slaveResyncToolStripMenuItem.Text = "Slave Resync";
        	this.slaveResyncToolStripMenuItem.Click += new System.EventHandler(this.slaveResyncToolStripMenuItem_Click);
        	// 
        	// ServePropertyToolStripMenuItem
        	// 
        	this.ServePropertyToolStripMenuItem.Name = "ServePropertyToolStripMenuItem";
        	this.ServePropertyToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
        	this.ServePropertyToolStripMenuItem.Text = "Serve Info";
        	this.ServePropertyToolStripMenuItem.Click += new System.EventHandler(this.ServePropertyToolStripMenuItem_Click);
        	// 
        	// ServerStatusToolStripMenuItem
        	// 
        	this.ServerStatusToolStripMenuItem.Name = "ServerStatusToolStripMenuItem";
        	this.ServerStatusToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
        	this.ServerStatusToolStripMenuItem.Text = "Status";
        	this.ServerStatusToolStripMenuItem.Click += new System.EventHandler(this.SvrStatusToolStripMenuItem_Click);
        	// 
        	// DataBaseToolStripMenuItem
        	// 
        	this.DataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.CreateMongoCollectionToolStripMenuItem,
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
        	this.DataBaseToolStripMenuItem.Text = "Database";
        	// 
        	// CreateMongoCollectionToolStripMenuItem
        	// 
        	this.CreateMongoCollectionToolStripMenuItem.Name = "CreateMongoCollectionToolStripMenuItem";
        	this.CreateMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.CreateMongoCollectionToolStripMenuItem.Text = "New Collection";
        	this.CreateMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.CreateMongoCollectionToolStripMenuItem_Click);
        	// 
        	// CopyDatabasetoolStripMenuItem
        	// 
        	this.CopyDatabasetoolStripMenuItem.Name = "CopyDatabasetoolStripMenuItem";
        	this.CopyDatabasetoolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.CopyDatabasetoolStripMenuItem.Text = "Copy Database";
        	this.CopyDatabasetoolStripMenuItem.Click += new System.EventHandler(this.CopyDatabasetoolStripMenuItem_Click);
        	// 
        	// DelMongoDBToolStripMenuItem
        	// 
        	this.DelMongoDBToolStripMenuItem.Name = "DelMongoDBToolStripMenuItem";
        	this.DelMongoDBToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.DelMongoDBToolStripMenuItem.Text = "Del Database";
        	this.DelMongoDBToolStripMenuItem.Click += new System.EventHandler(this.DelMongoDBToolStripMenuItem_Click);
        	// 
        	// toolStripMenuItem5
        	// 
        	this.toolStripMenuItem5.Name = "toolStripMenuItem5";
        	this.toolStripMenuItem5.Size = new System.Drawing.Size(175, 6);
        	// 
        	// AddUserToolStripMenuItem
        	// 
        	this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
        	this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.AddUserToolStripMenuItem.Text = "Add User";
        	this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserToolStripMenuItem_Click);
        	// 
        	// AddDBCustomeRoleStripMenuItem
        	// 
        	this.AddDBCustomeRoleStripMenuItem.Name = "AddDBCustomeRoleStripMenuItem";
        	this.AddDBCustomeRoleStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.AddDBCustomeRoleStripMenuItem.Text = "Add Custom Role";
        	this.AddDBCustomeRoleStripMenuItem.Click += new System.EventHandler(this.AddDBCustomeRoleStripMenuItem_Click);
        	// 
        	// toolStripMenuItem11
        	// 
        	this.toolStripMenuItem11.Name = "toolStripMenuItem11";
        	this.toolStripMenuItem11.Size = new System.Drawing.Size(175, 6);
        	// 
        	// EvalJSToolStripMenuItem
        	// 
        	this.EvalJSToolStripMenuItem.Name = "EvalJSToolStripMenuItem";
        	this.EvalJSToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.EvalJSToolStripMenuItem.Text = "Eval Javascript";
        	this.EvalJSToolStripMenuItem.Click += new System.EventHandler(this.evalJSToolStripMenuItem_Click);
        	// 
        	// creatJavaScriptToolStripMenuItem
        	// 
        	this.creatJavaScriptToolStripMenuItem.Name = "creatJavaScriptToolStripMenuItem";
        	this.creatJavaScriptToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.creatJavaScriptToolStripMenuItem.Text = "Creat JavaScript";
        	this.creatJavaScriptToolStripMenuItem.Click += new System.EventHandler(this.creatJavaScriptToolStripMenuItem_Click);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
        	// 
        	// RepairDBToolStripMenuItem
        	// 
        	this.RepairDBToolStripMenuItem.Name = "RepairDBToolStripMenuItem";
        	this.RepairDBToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.RepairDBToolStripMenuItem.Text = "Repair Database";
        	this.RepairDBToolStripMenuItem.Click += new System.EventHandler(this.RepairDBToolStripMenuItem_Click);
        	// 
        	// InitGFSToolStripMenuItem
        	// 
        	this.InitGFSToolStripMenuItem.Name = "InitGFSToolStripMenuItem";
        	this.InitGFSToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.InitGFSToolStripMenuItem.Text = "Init GFS";
        	// 
        	// ProfillingLevelToolStripMenuItem
        	// 
        	this.ProfillingLevelToolStripMenuItem.Name = "ProfillingLevelToolStripMenuItem";
        	this.ProfillingLevelToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.ProfillingLevelToolStripMenuItem.Text = "Profilling Level";
        	this.ProfillingLevelToolStripMenuItem.Click += new System.EventHandler(this.profillingLevelToolStripMenuItem_Click);
        	// 
        	// DBStatusToolStripMenuItem
        	// 
        	this.DBStatusToolStripMenuItem.Name = "DBStatusToolStripMenuItem";
        	this.DBStatusToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
        	this.DBStatusToolStripMenuItem.Text = "Status";
        	this.DBStatusToolStripMenuItem.Click += new System.EventHandler(this.DBStatusToolStripMenuItem_Click);
        	// 
        	// DataCollectionToolStripMenuItem
        	// 
        	this.DataCollectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.DelMongoCollectionToolStripMenuItem,
			this.RenameCollectionToolStripMenuItem,
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
        	this.DataCollectionToolStripMenuItem.Text = "Collection";
        	// 
        	// DelMongoCollectionToolStripMenuItem
        	// 
        	this.DelMongoCollectionToolStripMenuItem.Name = "DelMongoCollectionToolStripMenuItem";
        	this.DelMongoCollectionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.DelMongoCollectionToolStripMenuItem.Text = "Drop Collection";
        	this.DelMongoCollectionToolStripMenuItem.Click += new System.EventHandler(this.DelMongoCollectionToolStripMenuItem_Click);
        	// 
        	// RenameCollectionToolStripMenuItem
        	// 
        	this.RenameCollectionToolStripMenuItem.Name = "RenameCollectionToolStripMenuItem";
        	this.RenameCollectionToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.RenameCollectionToolStripMenuItem.Text = "Rename Collection";
        	this.RenameCollectionToolStripMenuItem.Click += new System.EventHandler(this.RenameCollectionToolStripMenuItem_Click);
        	// 
        	// IndexManageToolStripMenuItem
        	// 
        	this.IndexManageToolStripMenuItem.Name = "IndexManageToolStripMenuItem";
        	this.IndexManageToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.IndexManageToolStripMenuItem.Text = "Index Management";
        	this.IndexManageToolStripMenuItem.Click += new System.EventHandler(this.IndexManageToolStripMenuItem_Click);
        	// 
        	// ReIndexToolStripMenuItem
        	// 
        	this.ReIndexToolStripMenuItem.Name = "ReIndexToolStripMenuItem";
        	this.ReIndexToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.ReIndexToolStripMenuItem.Text = "ReIndex";
        	this.ReIndexToolStripMenuItem.Click += new System.EventHandler(this.ReIndexToolStripMenuItem_Click);
        	// 
        	// CompactToolStripMenuItem
        	// 
        	this.CompactToolStripMenuItem.Name = "CompactToolStripMenuItem";
        	this.CompactToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.CompactToolStripMenuItem.Text = "Compact";
        	this.CompactToolStripMenuItem.Click += new System.EventHandler(this.CompactToolStripMenuItem_Click);
        	// 
        	// toolStripMenuItem8
        	// 
        	this.toolStripMenuItem8.Name = "toolStripMenuItem8";
        	this.toolStripMenuItem8.Size = new System.Drawing.Size(186, 6);
        	// 
        	// AggregationToolStripMenuItem
        	// 
        	this.AggregationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.countToolStripMenuItem,
			this.distinctToolStripMenuItem,
			this.groupToolStripMenuItem,
			this.mapReduceToolStripMenuItem,
			this.aggregateToolStripMenuItem,
			this.textSearchToolStripMenuItem});
        	this.AggregationToolStripMenuItem.Name = "AggregationToolStripMenuItem";
        	this.AggregationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.AggregationToolStripMenuItem.Text = "Aggregation";
        	// 
        	// countToolStripMenuItem
        	// 
        	this.countToolStripMenuItem.Name = "countToolStripMenuItem";
        	this.countToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.countToolStripMenuItem.Text = "Count";
        	this.countToolStripMenuItem.Click += new System.EventHandler(this.countToolStripMenuItem_Click);
        	// 
        	// distinctToolStripMenuItem
        	// 
        	this.distinctToolStripMenuItem.Name = "distinctToolStripMenuItem";
        	this.distinctToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.distinctToolStripMenuItem.Text = "Distinct";
        	this.distinctToolStripMenuItem.Click += new System.EventHandler(this.distinctToolStripMenuItem_Click);
        	// 
        	// groupToolStripMenuItem
        	// 
        	this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
        	this.groupToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
        	this.groupToolStripMenuItem.Text = "Group";
        	this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
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
        	// ViewDataToolStripMenuItem
        	// 
        	this.ViewDataToolStripMenuItem.Name = "ViewDataToolStripMenuItem";
        	this.ViewDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.ViewDataToolStripMenuItem.Text = "ViewData";
        	// 
        	// dropJavascriptToolStripMenuItem
        	// 
        	this.dropJavascriptToolStripMenuItem.Name = "dropJavascriptToolStripMenuItem";
        	this.dropJavascriptToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.dropJavascriptToolStripMenuItem.Text = "Drop Javascript";
        	this.dropJavascriptToolStripMenuItem.Click += new System.EventHandler(this.dropJavascriptToolStripMenuItem_Click);
        	// 
        	// CollectionStatusToolStripMenuItem
        	// 
        	this.CollectionStatusToolStripMenuItem.Name = "CollectionStatusToolStripMenuItem";
        	this.CollectionStatusToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.CollectionStatusToolStripMenuItem.Text = "Status";
        	this.CollectionStatusToolStripMenuItem.Click += new System.EventHandler(this.CollectionStatusToolStripMenuItem_Click);
        	// 
        	// ValidateToolStripMenuItem
        	// 
        	this.ValidateToolStripMenuItem.Name = "ValidateToolStripMenuItem";
        	this.ValidateToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.ValidateToolStripMenuItem.Text = "Validate";
        	this.ValidateToolStripMenuItem.Click += new System.EventHandler(this.validateToolStripMenuItem_Click);
        	// 
        	// ExportToFileToolStripMenuItem
        	// 
        	this.ExportToFileToolStripMenuItem.Name = "ExportToFileToolStripMenuItem";
        	this.ExportToFileToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
        	this.ExportToFileToolStripMenuItem.Text = "Export To File";
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
        	this.DumpAndRestoreToolStripMenuItem.Text = "Dump And Restore";
        	// 
        	// RestoreMongoToolStripMenuItem
        	// 
        	this.RestoreMongoToolStripMenuItem.Name = "RestoreMongoToolStripMenuItem";
        	this.RestoreMongoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
        	this.RestoreMongoToolStripMenuItem.Text = "Restore";
        	this.RestoreMongoToolStripMenuItem.Click += new System.EventHandler(this.RestoreMongoToolStripMenuItem_Click);
        	// 
        	// DumpDatabaseToolStripMenuItem
        	// 
        	this.DumpDatabaseToolStripMenuItem.Name = "DumpDatabaseToolStripMenuItem";
        	this.DumpDatabaseToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
        	this.DumpDatabaseToolStripMenuItem.Text = "Dump DataBase";
        	this.DumpDatabaseToolStripMenuItem.Click += new System.EventHandler(this.DumpDatabaseToolStripMenuItem_Click);
        	// 
        	// DumpCollectionToolStripMenuItem
        	// 
        	this.DumpCollectionToolStripMenuItem.Name = "DumpCollectionToolStripMenuItem";
        	this.DumpCollectionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
        	this.DumpCollectionToolStripMenuItem.Text = "Dump Collection";
        	this.DumpCollectionToolStripMenuItem.Click += new System.EventHandler(this.DumpCollectionToolStripMenuItem_Click);
        	// 
        	// toolStripMenuItem6
        	// 
        	this.toolStripMenuItem6.Name = "toolStripMenuItem6";
        	this.toolStripMenuItem6.Size = new System.Drawing.Size(201, 6);
        	// 
        	// ImportCollectionToolStripMenuItem
        	// 
        	this.ImportCollectionToolStripMenuItem.Name = "ImportCollectionToolStripMenuItem";
        	this.ImportCollectionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
        	this.ImportCollectionToolStripMenuItem.Text = "Import DataCollection";
        	this.ImportCollectionToolStripMenuItem.Click += new System.EventHandler(this.ImportCollectionToolStripMenuItem_Click);
        	// 
        	// ExportCollectionToolStripMenuItem
        	// 
        	this.ExportCollectionToolStripMenuItem.Name = "ExportCollectionToolStripMenuItem";
        	this.ExportCollectionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
        	this.ExportCollectionToolStripMenuItem.Text = "Export DataCollection";
        	this.ExportCollectionToolStripMenuItem.Click += new System.EventHandler(this.ExportCollectionToolStripMenuItem_Click);
        	// 
        	// ToolsToolStripMenuItem
        	// 
        	this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.plugInToolStripMenuItem,
			this.toolStripMenuItem7,
			this.OptionsToolStripMenuItem});
        	this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
        	this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
        	this.ToolsToolStripMenuItem.Text = "&Tools";
        	// 
        	// plugInToolStripMenuItem
        	// 
        	this.plugInToolStripMenuItem.Name = "plugInToolStripMenuItem";
        	this.plugInToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.plugInToolStripMenuItem.Text = "PlugIn";
        	// 
        	// toolStripMenuItem7
        	// 
        	this.toolStripMenuItem7.Name = "toolStripMenuItem7";
        	this.toolStripMenuItem7.Size = new System.Drawing.Size(149, 6);
        	// 
        	// OptionsToolStripMenuItem
        	// 
        	this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
        	this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.OptionsToolStripMenuItem.Text = "&Options";
        	this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionToolStripMenuItem_Click);
        	// 
        	// HelpToolStripMenuItem
        	// 
        	this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ThanksToolStripMenuItem,
			this.UserGuideToolStripMenuItem,
			this.toolStripSeparator2,
			this.AboutToolStripMenuItem});
        	this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
        	this.HelpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
        	this.HelpToolStripMenuItem.Text = "&Help";
        	// 
        	// ThanksToolStripMenuItem
        	// 
        	this.ThanksToolStripMenuItem.Name = "ThanksToolStripMenuItem";
        	this.ThanksToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
        	this.ThanksToolStripMenuItem.Text = "&Thanks";
        	this.ThanksToolStripMenuItem.Click += new System.EventHandler(this.ThanksToolStripMenuItem_Click);
        	// 
        	// UserGuideToolStripMenuItem
        	// 
        	this.UserGuideToolStripMenuItem.Name = "UserGuideToolStripMenuItem";
        	this.UserGuideToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
        	this.UserGuideToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
        	this.UserGuideToolStripMenuItem.Text = "UserGuide";
        	this.UserGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
        	// 
        	// AboutToolStripMenuItem
        	// 
        	this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
        	this.AboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
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
        	this.trvsrvlst.Size = new System.Drawing.Size(334, 630);
        	this.trvsrvlst.TabIndex = 0;
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.panel2);
        	this.panel1.Controls.Add(this.splitter1);
        	this.panel1.Controls.Add(this.trvsrvlst);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel1.Location = new System.Drawing.Point(0, 50);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(1223, 630);
        	this.panel1.TabIndex = 9;
        	// 
        	// panel2
        	// 
        	this.panel2.Controls.Add(this.tabView);
        	this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel2.Location = new System.Drawing.Point(337, 0);
        	this.panel2.Name = "panel2";
        	this.panel2.Size = new System.Drawing.Size(886, 630);
        	this.panel2.TabIndex = 2;
        	// 
        	// tabView
        	// 
        	this.tabView.Controls.Add(this.tabSvrStatus);
        	this.tabView.Controls.Add(this.tabCommandShell);
        	this.tabView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabView.Location = new System.Drawing.Point(0, 0);
        	this.tabView.Name = "tabView";
        	this.tabView.SelectedIndex = 0;
        	this.tabView.ShowToolTips = true;
        	this.tabView.Size = new System.Drawing.Size(886, 630);
        	this.tabView.TabIndex = 3;
        	// 
        	// tabSvrStatus
        	// 
        	this.tabSvrStatus.Controls.Add(this.ServerStatusCtl);
        	this.tabSvrStatus.Location = new System.Drawing.Point(4, 25);
        	this.tabSvrStatus.Name = "tabSvrStatus";
        	this.tabSvrStatus.Padding = new System.Windows.Forms.Padding(3);
        	this.tabSvrStatus.Size = new System.Drawing.Size(878, 601);
        	this.tabSvrStatus.TabIndex = 0;
        	this.tabSvrStatus.Text = "Sever Status";
        	this.tabSvrStatus.UseVisualStyleBackColor = true;
        	// 
        	// ServerStatusCtl
        	// 
        	this.ServerStatusCtl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.ServerStatusCtl.Location = new System.Drawing.Point(3, 3);
        	this.ServerStatusCtl.Margin = new System.Windows.Forms.Padding(5);
        	this.ServerStatusCtl.Name = "ServerStatusCtl";
        	this.ServerStatusCtl.Size = new System.Drawing.Size(872, 595);
        	this.ServerStatusCtl.TabIndex = 2;
        	// 
        	// tabCommandShell
        	// 
        	this.tabCommandShell.Controls.Add(this.ctlShellCommandEditor);
        	this.tabCommandShell.Location = new System.Drawing.Point(4, 25);
        	this.tabCommandShell.Name = "tabCommandShell";
        	this.tabCommandShell.Padding = new System.Windows.Forms.Padding(3);
        	this.tabCommandShell.Size = new System.Drawing.Size(878, 601);
        	this.tabCommandShell.TabIndex = 1;
        	this.tabCommandShell.Text = "Shell Command";
        	this.tabCommandShell.UseVisualStyleBackColor = true;
        	// 
        	// ctlShellCommandEditor
        	// 
        	this.ctlShellCommandEditor.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.ctlShellCommandEditor.JsName = null;
        	this.ctlShellCommandEditor.Location = new System.Drawing.Point(3, 3);
        	this.ctlShellCommandEditor.Margin = new System.Windows.Forms.Padding(4);
        	this.ctlShellCommandEditor.Name = "ctlShellCommandEditor";
        	this.ctlShellCommandEditor.Size = new System.Drawing.Size(872, 595);
        	this.ctlShellCommandEditor.TabIndex = 0;
        	// 
        	// splitter1
        	// 
        	this.splitter1.Location = new System.Drawing.Point(334, 0);
        	this.splitter1.Name = "splitter1";
        	this.splitter1.Size = new System.Drawing.Size(3, 630);
        	this.splitter1.TabIndex = 1;
        	this.splitter1.TabStop = false;
        	// 
        	// frmMain
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.Control;
        	this.ClientSize = new System.Drawing.Size(1223, 702);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.statusStripMain);
        	this.Controls.Add(this.toolStripMain);
        	this.Controls.Add(this.menuStripMain);
        	this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Name = "frmMain";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Mongo-Cola";
        	this.Load += new System.EventHandler(this.frmMain_Load);
        	this.statusStripMain.ResumeLayout(false);
        	this.statusStripMain.PerformLayout();
        	this.menuStripMain.ResumeLayout(false);
        	this.menuStripMain.PerformLayout();
        	this.panel1.ResumeLayout(false);
        	this.panel2.ResumeLayout(false);
        	this.tabView.ResumeLayout(false);
        	this.tabSvrStatus.ResumeLayout(false);
        	this.tabCommandShell.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSelectedObj;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelMongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateMongoCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DataCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelMongoCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IndexManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExpandAllConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CollapseAllConnectionToolStripMenuItem;


        private ToolStripButton ExpandAllConnectionToolStripButton;
        private ToolStripButton CollapseAllConnectionToolStripButton;
        private ToolStripButton RefreshToolStripButton;
        private ToolStripButton ExitToolStripButton;
        private ToolStripButton OptionToolStripButton;
        private ToolStripButton UserGuideToolStripButton;
        private ToolStripButton ShutDownToolStripButton;



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
        private ctlServerStatus ServerStatusCtl;
        private TabControl tabView;
        private TabPage tabSvrStatus;
        private TabPage tabCommandShell;
        private ToolStripMenuItem statusToolStripMenuItem;
        private ToolStripMenuItem commandShellToolStripMenuItem;
        private ToolStripMenuItem collectionToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem9;
        private ToolStripMenuItem ViewRefreshToolStripMenuItem;
        private ToolStripMenuItem InitGFSToolStripMenuItem;
        private ToolStripMenuItem JavaScriptStripMenuItem;
        private ctlJsEditor ctlShellCommandEditor;
        private ToolStripMenuItem AggregationToolStripMenuItem;
        private ToolStripMenuItem countToolStripMenuItem;
        private ToolStripMenuItem distinctToolStripMenuItem;
        private ToolStripMenuItem groupToolStripMenuItem;
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
        private ToolStripMenuItem slaveResyncToolStripMenuItem;
        private ToolStripMenuItem ServePropertyToolStripMenuItem;
        private ToolStripMenuItem ServerStatusToolStripMenuItem;
        private ToolStripMenuItem ShutDownToolStripMenuItem;
        private ToolStripStatusLabel lblAction;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem aggregateToolStripMenuItem;
        private ToolStripMenuItem textSearchToolStripMenuItem;
        private ToolStripMenuItem ValidateToolStripMenuItem;
        private ToolStripMenuItem CopyDatabasetoolStripMenuItem;
        private ToolStripMenuItem UserInfoStripMenuItem;
        private ToolStripMenuItem ExportToFileToolStripMenuItem;
        private ToolStripMenuItem plugInToolStripMenuItem;
        private ToolStripMenuItem AddAdminCustomeRoleStripMenuItem;
        private ToolStripMenuItem AddDBCustomeRoleStripMenuItem;
    }
}

