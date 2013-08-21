using MagicMongoDBTool.Module;
using MagicMongoDBTool.UnitTest;
using MagicMongoDBTool.UserController;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {

        #region"Main Program"
        public frmMain()
        {
            InitializeComponent();
            GetSystemIcon.InitMainTreeImage();
            GetSystemIcon.InitTabViewImage();
            trvsrvlst.ImageList = GetSystemIcon.MainTreeImage;
            tabView.ImageList = GetSystemIcon.TabViewImage;
            SetMenuImage();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                //Set Menu Text
                SetMenuText();
            }
            //Init ToolBar
            InitToolBar();

            if (!SystemManager.DEBUG_MODE)
            {
                //非Debug模式的时候,UT菜单不可使用
                toolStripMenuItem12.Visible = false;
                ForMySelfToolStripMenuItem.Visible = false;
            }
            this.Text += "  " + SystemManager.Version;
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (SystemManager.MONO_MODE)
            {
                this.Text += " MONO";
            }
            //长时间操作时候，实时提示进度在状态栏中
            lblAction.Text = String.Empty;
            MongoDBHelper.ActionDone += new EventHandler<ActionDoneEventArgs>(
                (x, y) =>
                {
                    //1.lblAction 没有InvokeRequired
                    //2.DoEvents必须
                    lblAction.Text = y.Message;
                    Application.DoEvents();
                }
            );
        }
        /// <summary>
        /// Set Menu Text
        /// </summary>
        private void SetMenuText()
        {
            //管理
            this.ManagerToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt);
            this.DisconnectToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Disconnect);
            this.AddConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_AddConnection);
            this.RefreshToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);

            this.ExpandAllConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Expansion);
            this.CollapseAllConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collapse);
            this.ExitToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Exit);

            //数据视图
            this.ViewToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            this.ViewRefreshToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);
            this.collectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collection);
            this.statusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);


            //Operation
            this.OperationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation);

            this.connectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Connect);
            this.ReplicaSetToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
            this.ShardingConfigToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ShardingConfig);
            this.InitReplsetToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Replset_InitReplset);


            this.ServerToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
            this.CreateMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
            this.UserInfoStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_UserInfo);
            this.AddUserToAdminToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
            this.slaveResyncToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_SlaveResync);
            this.ShutDownToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
            this.ServePropertyToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties);
            this.ServerStatusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

            this.DataBaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
            this.DelMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelDB);
            this.CreateMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddDC);
            this.AddUserToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            this.evalJSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
            this.RepairDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_RepairDatabase);
            this.DBStatusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

            this.DataCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection);
            this.DelMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
            this.RenameCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
            this.IndexManageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
            this.ReIndexToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
            this.CompactToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Compact);
            this.CollectionStatusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            this.InitGFSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_InitGFS);
            this.ProfillingLevelToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_ProfillingLevel);
            this.AggregationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);
            this.validateToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);


            this.DumpAndRestoreToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
            this.RestoreMongoToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
            this.DumpCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
            this.DumpDatabaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
            this.ImportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
            this.ExportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);
            this.creatJavaScriptToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_CreateJavaScript);
            this.viewDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_View);
            this.dropJavascriptToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DropJavaScript);

            //Tool
            this.ToolsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool);
            this.DosCommandToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_DOS);
            this.ImportDataFromAccessToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Access);
            this.OptionsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Setting);

            //帮助
            this.HelpToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help);
            this.AboutToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_About);
            this.ThanksToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_Thanks);
            this.UserGuideToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_UserGuide);

            //其他控件
            this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            this.tabSvrStatus.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
        }

        /// <summary>
        /// Current Connection Config
        /// </summary>
        ConfigHelper.MongoConnectionConfig config = new ConfigHelper.MongoConnectionConfig();
        /// <summary>
        /// 多文档视图管理
        /// </summary>
        Dictionary<String, TabPage> ViewTabList = new Dictionary<String, TabPage>();
        /// <summary>
        /// 多文档视图管理
        /// </summary>
        Dictionary<String, MongoDBHelper.DataViewInfo> ViewInfoList = new Dictionary<String, MongoDBHelper.DataViewInfo>();
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            this.trvsrvlst.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler((x, y) => { this.ViewDataObj(); });
            this.viewDataToolStripMenuItem.Click += new System.EventHandler((x, y) => { this.ViewDataObj(); });
            this.trvsrvlst.KeyDown += new KeyEventHandler(trvsrvlst_KeyDown);
            DisableAllOpr();
            //Set Tool bar button enable 
            SetToolBarEnabled();

            //Open ConnectionManagement Form
            SystemManager.OpenForm(new frmConnect(), true, true);
            ServerStatusCtl.SetEnable(true);
            RefreshToolStripMenuItem_Click(sender, e);
            this.commandShellToolStripMenuItem.Checked = true;

            this.statusToolStripMenuItem.Checked = true;
            this.ServerStatusCtl.CloseTab += new EventHandler(
                (x, y) =>
                {
                    statusToolStripMenuItem.Checked = false;
                    tabView.Controls.Remove(tabSvrStatus);
                }
            );
            this.ctlShellCommandEditor.CloseTab += new EventHandler(
                (x, y) =>
                {
                    this.commandShellToolStripMenuItem.Checked = false;
                    tabView.Controls.Remove(tabCommandShell);
                }
            );
            this.tabView.SelectedIndexChanged += new EventHandler(tabView_SelectedIndexChanged);
            MongoDBHelper.RunCommandComplete += new EventHandler<RunCommandEventArgs>(CommandLog);

        }
        /// <summary>
        /// 切换Tab的时候，必须切换当前对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tabView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabView.SelectedTab != null && tabView.SelectedTab.Tag != null)
            {
                SystemManager.SelectObjectTag = tabView.SelectedTab.Tag.ToString();
            }
        }
        /// <summary>
        /// CommandLog
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void CommandLog(Object Sender, RunCommandEventArgs e)
        {
            this.ctlShellCommandEditor.AppendLine("========================================================");
            this.ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now.ToString() + "  CommandName:" + e.Result.CommandName);
            this.ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now.ToString() + "  Command:" + e.Result.Command);
            this.ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now.ToString() + "  OK:" + e.Result.Ok);
            this.ctlShellCommandEditor.AppendLine("========================================================");
        }
        /// <summary>
        /// KeyEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvsrvlst_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    //Del
                    if (this.DelMongoDBToolStripMenuItem.Enabled)
                    {
                        DelMongoDBToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        if (this.DelMongoCollectionToolStripMenuItem.Enabled)
                        {
                            DelMongoCollectionToolStripMenuItem_Click(null, null);
                        }
                    }
                    break;
                case Keys.F2:
                    //Rename
                    if (this.RenameCollectionToolStripMenuItem.Enabled)
                    {
                        RenameCollectionToolStripMenuItem_Click(null, null);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ConnectionList TreeView Node is clicked by mouse 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ImageIndex != -1)
            {
                statusStripMain.Items[0].Image = GetSystemIcon.MainTreeImage.Images[e.Node.ImageIndex];
            }
            //First , set Every MenuItem to disable
            DisableAllOpr();
            if (e.Node.Tag != null)
            {
                //选中节点的设置
                this.trvsrvlst.SelectedNode = e.Node;
                String strNodeType = SystemManager.GetTagType(e.Node.Tag.ToString());
                String mongoSvrKey = SystemManager.GetTagData(e.Node.Tag.ToString()).Split("/".ToCharArray())[0];
                config = SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey];
                if (String.IsNullOrEmpty(config.UserName))
                {
                    lblUserInfo.Text = "UserInfo:Admin";
                }
                else
                {
                    lblUserInfo.Text = "UserInfo:" + config.UserName;
                }
                if (config.AuthMode)
                {
                    lblUserInfo.Text += " @AuthMode";
                }
                if (config.IsReadOnly)
                {
                    lblUserInfo.Text += " [ReadOnly]";
                }
                if (!config.IsReadOnly)
                {
                    //恢复数据：这个操作可以针对服务器，数据库，数据集，所以可以放在共通
                    this.RestoreMongoToolStripMenuItem.Enabled = true;
                }
                SystemManager.SelectObjectTag = String.Empty;
                if (SystemManager.SelectObjectTag != null)
                {
                    SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                }
                switch (strNodeType)
                {
                    case MongoDBHelper.CONNECTION_TAG:
                    case MongoDBHelper.CONNECTION_REPLSET_TAG:
                    case MongoDBHelper.CONNECTION_CLUSTER_TAG:
                        //普通连接
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Connection:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Server) + ":" + SystemManager.SelectTagData;
                        }

                        this.DisconnectToolStripMenuItem.Enabled = true;
                        this.ShutDownToolStripMenuItem.Enabled = true;
                        this.ShutDownToolStripButton.Enabled = true;

                        if (strNodeType == MongoDBHelper.CONNECTION_TAG)
                        {
                            this.InitReplsetToolStripMenuItem.Enabled = true;
                        }
                        if (strNodeType == MongoDBHelper.CONNECTION_REPLSET_TAG)
                        {
                            this.ReplicaSetToolStripMenuItem.Enabled = true;
                        }
                        if (strNodeType == MongoDBHelper.CONNECTION_CLUSTER_TAG)
                        {
                            this.ShardingConfigToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t1 = this.DisconnectToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = this.InitReplsetToolStripMenuItem.Clone();
                                t2.Click += new EventHandler(InitReplsetToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = this.ReplicaSetToolStripMenuItem.Clone();
                                t3.Click += new EventHandler(ReplicaSetToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t4 = this.ShardingConfigToolStripMenuItem.Clone();
                                t4.Click += new EventHandler(ShardingConfigToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t4);

                                ToolStripMenuItem t5 = this.ShutDownToolStripMenuItem.Clone();
                                t5.Click += new EventHandler(ShutDownToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t5);

                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.DisconnectToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ShutDownToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.InitReplsetToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ReplicaSetToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ShardingConfigToolStripMenuItem.Clone());

                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.CONNECTION_EXCEPTION_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        this.DisconnectToolStripMenuItem.Enabled = true;
                        this.RestoreMongoToolStripMenuItem.Enabled = false;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = this.DisconnectToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t1);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.DisconnectToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected Server[Exception]:" + SystemManager.SelectTagData;
                        break;
                    case MongoDBHelper.SERVER_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Server:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Server) + ":" + SystemManager.SelectTagData;
                        }
                        //解禁 创建数据库,关闭服务器
                        if (!config.IsReadOnly)
                        {
                            this.CreateMongoDBToolStripMenuItem.Enabled = true;
                            this.AddUserToAdminToolStripMenuItem.Enabled = true;
                            if (!SystemManager.MONO_MODE)
                            {
                                this.ImportDataFromAccessToolStripMenuItem.Enabled = true;
                            }
                            if (config.ServerRole == ConfigHelper.SvrRoleType.MasterSvr ||
                                config.ServerRole == ConfigHelper.SvrRoleType.SlaveSvr)
                            {
                                //Master，Slave都可以执行
                                this.slaveResyncToolStripMenuItem.Enabled = true;
                            }
                        }
                        this.UserInfoStripMenuItem.Enabled = true;
                        this.ServerStatusToolStripMenuItem.Enabled = true;
                        this.ServePropertyToolStripMenuItem.Enabled = true;

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = this.CreateMongoDBToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(CreateMongoDBToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = this.AddUserToAdminToolStripMenuItem.Clone();
                                t2.Click += new EventHandler(AddUserToAdminToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = this.RestoreMongoToolStripMenuItem.Clone();
                                t3.Click += new EventHandler(RestoreMongoToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t6 = this.slaveResyncToolStripMenuItem.Clone();
                                t6.Click += new EventHandler(slaveResyncToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t6);

                                ToolStripMenuItem t9 = this.ServePropertyToolStripMenuItem.Clone();
                                t9.Click += new EventHandler(ServePropertyToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t9);

                                ToolStripMenuItem t10 = this.ServerStatusToolStripMenuItem.Clone();
                                t10.Click += new EventHandler(SvrStatusToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t10);

                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.CreateMongoDBToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.AddUserToAdminToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.UserInfoStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ImportDataFromAccessToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.slaveResyncToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ServePropertyToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ServerStatusToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.SINGLE_DB_SERVER_TAG:
                        //单数据库模式,禁止所有服务器操作
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = this.DisconnectToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t1);
                                ToolStripMenuItem t2 = this.ServerStatusToolStripMenuItem.Clone();
                                t2.Click += new EventHandler(SvrStatusToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t2);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.DisconnectToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ServerStatusToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected Server[Single Database]:" + SystemManager.SelectTagData;
                        break;
                    case MongoDBHelper.DATABASE_TAG:
                    case MongoDBHelper.SINGLE_DATABASE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected DataBase:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_DataBase) + ":" + SystemManager.SelectTagData;
                        }
                        //解禁 删除数据库 创建数据集
                        if (!MongoDBHelper.IsSystemDataBase(SystemManager.GetCurrentDataBase()))
                        {
                            //系统库不允许修改
                            if (!config.IsReadOnly)
                            {
                                this.DelMongoDBToolStripMenuItem.Enabled = true;
                                this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                                this.AddUserToolStripMenuItem.Enabled = true;
                                this.InitGFSToolStripMenuItem.Enabled = true;
                                ///If a Slave server can repair database @ Master-Slave is not sure ??
                                this.RepairDBToolStripMenuItem.Enabled = true;
                            }
                            this.evalJSToolStripMenuItem.Enabled = true;
                        }
                        //备份数据库
                        this.DumpDatabaseToolStripMenuItem.Enabled = true;
                        this.ProfillingLevelToolStripMenuItem.Enabled = true;
                        if (strNodeType == MongoDBHelper.SINGLE_DATABASE_TAG)
                        {
                            this.DelMongoDBToolStripMenuItem.Enabled = false;
                        }
                        this.DBStatusToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = this.DelMongoDBToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(DelMongoDBToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = this.CreateMongoCollectionToolStripMenuItem.Clone();
                                t2.Click += new EventHandler(CreateMongoCollectionToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = this.AddUserToolStripMenuItem.Clone();
                                t3.Click += new EventHandler(AddUserToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t4 = this.evalJSToolStripMenuItem.Clone();
                                t4.Click += new EventHandler(evalJSToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t4);

                                ToolStripMenuItem t5 = this.RepairDBToolStripMenuItem.Clone();
                                t5.Click += new EventHandler(RepairDBToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t5);


                                ToolStripMenuItem t6 = this.InitGFSToolStripMenuItem.Clone();
                                t6.Click += new EventHandler(InitGFSToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t6);

                                ToolStripMenuItem t7 = this.DumpDatabaseToolStripMenuItem.Clone();
                                t7.Click += new EventHandler(DumpDatabaseToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t7);

                                ToolStripMenuItem t8 = this.RestoreMongoToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(RestoreMongoToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t8);


                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t10 = this.ProfillingLevelToolStripMenuItem.Clone();
                                t10.Click += new EventHandler(profillingLevelToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t10);

                                ToolStripMenuItem t11 = this.DBStatusToolStripMenuItem.Clone();
                                t11.Click += new EventHandler(DBStatusToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t11);

                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.DelMongoDBToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.CreateMongoCollectionToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.AddUserToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.evalJSToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.RepairDBToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.InitGFSToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.DumpDatabaseToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.ProfillingLevelToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.DBStatusToolStripMenuItem.Clone());

                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.SYSTEM_COLLECTION_LIST_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "System Collection List ";
                        break;
                    case MongoDBHelper.COLLECTION_LIST_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "Collection List ";
                        break;
                    case MongoDBHelper.COLLECTION_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Collection:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Collection) + ":" + SystemManager.SelectTagData;
                        }
                        //解禁 删除数据集
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            //系统数据库无法删除！！
                            if (!config.IsReadOnly)
                            {
                                this.DelMongoCollectionToolStripMenuItem.Enabled = true;
                                this.RenameCollectionToolStripMenuItem.Enabled = true;
                            }
                        }
                        if (!config.IsReadOnly)
                        {
                            this.ImportCollectionToolStripMenuItem.Enabled = true;
                            this.CompactToolStripMenuItem.Enabled = true;
                        }
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) && !config.IsReadOnly)
                        {
                            this.IndexManageToolStripMenuItem.Enabled = true;
                            this.ReIndexToolStripMenuItem.Enabled = true;
                        }
                        this.DumpCollectionToolStripMenuItem.Enabled = true;
                        this.ExportCollectionToolStripMenuItem.Enabled = true;
                        this.AggregationToolStripMenuItem.Enabled = true;
                        this.viewDataToolStripMenuItem.Enabled = true;
                        this.CollectionStatusToolStripMenuItem.Enabled = true;
                        this.validateToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = this.DelMongoCollectionToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(DelMongoCollectionToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = this.RenameCollectionToolStripMenuItem.Clone();
                                t2.Click += new EventHandler(RenameCollectionToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = this.DumpCollectionToolStripMenuItem.Clone();
                                t3.Click += new EventHandler(DumpCollectionToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t4 = this.RestoreMongoToolStripMenuItem.Clone();
                                t4.Click += new EventHandler(RestoreMongoToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t4);

                                ToolStripMenuItem t5 = this.ImportCollectionToolStripMenuItem.Clone();
                                t5.Click += new EventHandler(ImportCollectionToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t5);

                                ToolStripMenuItem t6 = this.ExportCollectionToolStripMenuItem.Clone();
                                t6.Click += new EventHandler(ExportCollectionToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t6);

                                ToolStripMenuItem t7 = this.CompactToolStripMenuItem.Clone();
                                t7.Click += new EventHandler(CompactToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t7);

                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t8 = this.viewDataToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(
                                    (x, y) => { ViewDataObj(); }
                                 );
                                this.contextMenuStripMain.Items.Add(t8);

                                ToolStripMenuItem AggregationMenu = this.AggregationToolStripMenuItem.Clone();

                                ToolStripMenuItem t9 = this.countToolStripMenuItem.Clone();
                                t9.Click += new EventHandler(countToolStripMenuItem_Click);
                                AggregationMenu.DropDownItems.Add(t9);

                                ToolStripMenuItem t10 = this.distinctToolStripMenuItem.Clone();
                                t10.Click += new EventHandler(distinctToolStripMenuItem_Click);
                                AggregationMenu.DropDownItems.Add(t10);


                                ToolStripMenuItem t11 = this.groupToolStripMenuItem.Clone();
                                t11.Click += new EventHandler(groupToolStripMenuItem_Click);
                                AggregationMenu.DropDownItems.Add(t11);

                                ToolStripMenuItem t12 = this.mapReduceToolStripMenuItem.Clone();
                                t12.Click += new EventHandler(mapReduceToolStripMenuItem_Click);
                                AggregationMenu.DropDownItems.Add(t12);

                                this.contextMenuStripMain.Items.Add(AggregationMenu);
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t13 = this.IndexManageToolStripMenuItem.Clone();
                                t13.Click += new EventHandler(IndexManageToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t13);

                                ToolStripMenuItem t14 = this.ReIndexToolStripMenuItem.Clone();
                                t14.Click += new EventHandler(ReIndexToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t14);

                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t15 = this.CollectionStatusToolStripMenuItem.Clone();
                                t15.Click += new EventHandler(CollectionStatusToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t15);

                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.DelMongoCollectionToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.RenameCollectionToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.DumpCollectionToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ImportCollectionToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ExportCollectionToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.CompactToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.viewDataToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.AggregationToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.IndexManageToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ReIndexToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.CollectionStatusToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.validateToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.INDEX_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Index) + ":" + SystemManager.SelectTagData;
                        }
                        break;
                    case MongoDBHelper.INDEXES_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Indexes) + ":" + SystemManager.SelectTagData;
                        }
                        break;
                    case MongoDBHelper.USER_LIST_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected UserList:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_UserList) + ":" + SystemManager.SelectTagData;
                        }
                        this.viewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = this.viewDataToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(
                                    (x, y) => { ViewDataObj(); }
                                 );
                                this.contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.viewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.GRID_FILE_SYSTEM_TAG:
                        //GridFileSystem
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected GFS:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_GFS) + ":" + SystemManager.SelectTagData;
                        }

                        this.viewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = this.viewDataToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(
                                    (x, y) => { ViewDataObj(); }
                                 );
                                this.contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.viewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.JAVASCRIPT_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        this.viewDataToolStripMenuItem.Enabled = true;
                        if (!config.IsReadOnly)
                        {
                            creatJavaScriptToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = this.creatJavaScriptToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(creatJavaScriptToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.creatJavaScriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected collection Javascript";
                        break;
                    case MongoDBHelper.JAVASCRIPT_DOC_TAG:
                        statusStripMain.Items[0].Text = "Selected JavaScript:" + SystemManager.SelectTagData;
                        this.viewDataToolStripMenuItem.Enabled = true;
                        this.dropJavascriptToolStripMenuItem.Enabled = true;

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t1 = this.viewDataToolStripMenuItem.Clone();
                                t1.Click += new EventHandler(
                                    (x, y) => { ViewDataObj(); }
                                 );
                                this.contextMenuStripMain.Items.Add(t1);
                                ToolStripMenuItem t8 = this.dropJavascriptToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(dropJavascriptToolStripMenuItem_Click);
                                this.contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.viewDataToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.dropJavascriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    default:
                        statusStripMain.Items[0].Text = "Selected Object:" + e.Node.Text;
                        break;
                }
            }
            else
            {
                statusStripMain.Items[0].Text = "Selected Object:" + e.Node.Text;
            }
            //重新Reset工具栏
            SetToolBarEnabled();
        }
        /// <summary>
        /// 设置图标
        /// </summary>
        private void SetMenuImage()
        {
            this.ExitToolStripMenuItem.Image = MagicMongoDBTool.Properties.Resources.exit.ToBitmap();

            this.ShutDownToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.ShutDown);

            this.DelMongoCollectionToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetIcon(IconType.No).ToBitmap();
            this.DelMongoDBToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetIcon(IconType.No).ToBitmap();

            this.ImportDataFromAccessToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.AccessDB);
            this.RefreshToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.Refresh);
            this.OptionsToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.Option);

            this.ThanksToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.Smile);
            this.UserGuideToolStripMenuItem.Image = MagicMongoDBTool.Module.GetResource.GetIcon(MagicMongoDBTool.Module.IconType.UserGuide).ToBitmap();

            this.tabSvrStatus.ImageIndex = 0;
        }
        /// <summary>
        /// 初始化Toolbar
        /// </summary>
        private void InitToolBar()
        {

            ExpandAllConnectionToolStripButton = this.ExpandAllConnectionToolStripMenuItem.CloneFromMenuItem();
            CollapseAllConnectionToolStripButton = this.CollapseAllConnectionToolStripMenuItem.CloneFromMenuItem();
            RefreshToolStripButton = this.RefreshToolStripMenuItem.CloneFromMenuItem();
            ExitToolStripButton = this.ExitToolStripMenuItem.CloneFromMenuItem();

            ImportDataFromAccessToolStripButton = this.ImportDataFromAccessToolStripMenuItem.CloneFromMenuItem();
            ShutDownToolStripButton = this.ShutDownToolStripMenuItem.CloneFromMenuItem();

            OptionToolStripButton = this.OptionsToolStripMenuItem.CloneFromMenuItem();
            UserGuideToolStripButton = this.UserGuideToolStripMenuItem.CloneFromMenuItem();
            //暂时不对应MONO
            if (SystemManager.MONO_MODE)
            {
                RefreshToolStripButton.Click += new System.EventHandler(RefreshToolStripMenuItem_Click);
                ShutDownToolStripButton.Click += new System.EventHandler(ShutDownToolStripMenuItem_Click);
                OptionToolStripButton.Click += new System.EventHandler(OptionToolStripMenuItem_Click);
                UserGuideToolStripButton.Click += new System.EventHandler(userGuideToolStripMenuItem_Click);
            }
            //Main ToolTip
            this.toolStripMain.Items.Add(ExpandAllConnectionToolStripButton);
            this.toolStripMain.Items.Add(CollapseAllConnectionToolStripButton);
            this.toolStripMain.Items.Add(RefreshToolStripButton);
            this.toolStripMain.Items.Add(ExitToolStripButton);

            this.toolStripMain.Items.Add(new ToolStripSeparator());
 
            this.toolStripMain.Items.Add(ImportDataFromAccessToolStripButton);
            this.toolStripMain.Items.Add(ShutDownToolStripButton);

            this.toolStripMain.Items.Add(new ToolStripSeparator());

            this.toolStripMain.Items.Add(OptionToolStripButton);
            this.toolStripMain.Items.Add(UserGuideToolStripButton);

        }
        /// <summary>
        /// 设定工具栏
        /// </summary>
        private void SetToolBarEnabled()
        {
            UserGuideToolStripButton.Enabled = true;
            RefreshToolStripButton.Enabled = true;
            OptionToolStripButton.Enabled = true;
            ShutDownToolStripButton.Enabled = this.ShutDownToolStripMenuItem.Enabled;
            if (!SystemManager.MONO_MODE)
            {
                ImportDataFromAccessToolStripButton.Enabled = this.ImportDataFromAccessToolStripMenuItem.Enabled;
            }
        }
        /// <summary>
        /// ViewData
        /// </summary>
        private void ViewDataObj()
        {
            switch (SystemManager.SelectTagType)
            {
                case MongoDBHelper.USER_LIST_TAG:
                    MongoDBHelper.InitDBUser();
                    ViewDataRecord();
                    break;
                case MongoDBHelper.GRID_FILE_SYSTEM_TAG:
                    MongoDBHelper.InitGFS();
                    ViewDataRecord();
                    break;
                case MongoDBHelper.JAVASCRIPT_TAG:
                    MongoDBHelper.InitJavascript();
                    break;
                case MongoDBHelper.JAVASCRIPT_DOC_TAG:
                    ViewJavascript();
                    break;
                case MongoDBHelper.COLLECTION_TAG:
                case MongoDBHelper.DOCUMENT_TAG:
                    ViewDataRecord();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// View Js
        /// </summary>
        private void ViewJavascript()
        {
            String[] DataList = SystemManager.SelectTagData.Split("/".ToCharArray());

            if (ViewTabList.ContainsKey(SystemManager.SelectTagData))
            {
                tabView.SelectTab(ViewTabList[SystemManager.SelectTagData]);
            }
            else
            {
                String JsName = DataList[(int)MongoDBHelper.PathLv.DocumentLV];
                ctlJsEditor JsEditor = new ctlJsEditor();
                JsEditor.strDBtag = SystemManager.SelectObjectTag;
                TabPage DataTab = new TabPage(JsName);
                DataTab.Tag = SystemManager.SelectObjectTag;
                DataTab.ImageIndex = 1;

                JsEditor.JsName = JsName;
                DataTab.Controls.Add(JsEditor);
                JsEditor.Dock = DockStyle.Fill;
                tabView.Controls.Add(DataTab);

                ToolStripMenuItem DataMenuItem = new ToolStripMenuItem(JsName);
                DataMenuItem.Tag = DataTab.Tag;
                DataMenuItem.Image = GetSystemIcon.TabViewImage.Images[1];
                JavaScriptStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += new EventHandler(
                     (x, y) => { tabView.SelectTab(DataTab); }
                );
                ViewTabList.Add(SystemManager.SelectTagData, DataTab);
                JsEditor.CloseTab += new System.EventHandler(
                    (x, y) =>
                    {
                        tabView.Controls.Remove(DataTab);
                        ViewTabList.Remove(SystemManager.SelectTagData);
                        JavaScriptStripMenuItem.DropDownItems.Remove(DataMenuItem);
                    }
                );
                tabView.SelectTab(DataTab);
            }
        }
        /// <summary>
        /// Create a DataView Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDataRecord()
        {
            //由于Collection 和 Document 都可以触发这个事件，所以，先把Tag以前的标题头去掉
            //Collectiong:XXXX 和 Document:XXXX 都统一成 XXXX
            String DataKey = SystemManager.SelectTagData;
            if (ViewTabList.ContainsKey(DataKey))
            {
                tabView.SelectTab(ViewTabList[DataKey]);
            }
            else
            {
                MongoDBHelper.DataViewInfo mDataViewInfo = new MongoDBHelper.DataViewInfo();
                mDataViewInfo.strDBTag = SystemManager.SelectObjectTag;
                mDataViewInfo.IsUseFilter = false;

                mDataViewInfo.IsReadOnly = config.IsReadOnly;
                //mDataViewInfo.IsSafeMode = config.IsSafeMode;
                mDataViewInfo.mDataFilter = new DataFilter();

                ctlDataView DataViewctl;
                switch (SystemManager.SelectTagType)
                {
                    case MongoDBHelper.GRID_FILE_SYSTEM_TAG:
                        DataViewctl = new ctlGFSView(mDataViewInfo);
                        break;
                    case MongoDBHelper.USER_LIST_TAG:
                        DataViewctl = new ctlUserView(mDataViewInfo);
                        break;
                    default:
                        DataViewctl = new ctlDocumentView(mDataViewInfo);
                        break;
                }


                DataViewctl.mDataViewInfo = mDataViewInfo;

                TabPage DataTab = new TabPage(SystemManager.GetCurrentCollection().FullName);
                DataTab.Tag = SystemManager.SelectObjectTag;
                DataTab.ToolTipText = SystemManager.SelectObjectTag;

                switch (SystemManager.SelectTagType)
                {
                    case MongoDBHelper.COLLECTION_TAG:
                        DataTab.ImageIndex = 2;
                        break;
                    case MongoDBHelper.USER_LIST_TAG:
                        DataTab.ImageIndex = 3;
                        break;
                    default:
                        DataTab.ImageIndex = 4;
                        break;
                }

                DataTab.Controls.Add(DataViewctl);
                DataViewctl.Dock = DockStyle.Fill;
                tabView.Controls.Add(DataTab);

                ToolStripMenuItem DataMenuItem = new ToolStripMenuItem(SystemManager.GetCurrentCollection().Name);
                DataMenuItem.Tag = DataTab.Tag;
                DataMenuItem.Image = GetSystemIcon.TabViewImage.Images[DataTab.ImageIndex];
                collectionToolStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += new EventHandler(
                     (x, y) => { tabView.SelectTab(DataTab); }
                );
                ViewTabList.Add(DataKey, DataTab);
                ViewInfoList.Add(DataKey, mDataViewInfo);
                DataViewctl.CloseTab += new System.EventHandler(
                    (x, y) =>
                    {
                        tabView.Controls.Remove(DataTab);
                        ViewTabList.Remove(DataKey);
                        ViewInfoList.Remove(DataKey);
                        collectionToolStripMenuItem.DropDownItems.Remove(DataMenuItem);
                        DataTab = null;
                    }
                );
                tabView.SelectTab(DataTab);
            }
        }
        /// <summary>
        /// Refresh View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabView.SelectedTab != null)
            {
                ctlDataView ctl = tabView.SelectedTab.Controls[0] as ctlDataView;
                if (ctl != null)
                {
                    ctl.RefreshGUI();
                }
            }
        }
        /// <summary>
        /// 禁止所有操作
        /// </summary>
        private void DisableAllOpr()
        {

            //管理-服务器
            this.CreateMongoDBToolStripMenuItem.Enabled = false;
            this.AddUserToAdminToolStripMenuItem.Enabled = false;
            this.ServerStatusToolStripMenuItem.Enabled = false;
            this.ServePropertyToolStripMenuItem.Enabled = false;
            this.slaveResyncToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripButton.Enabled = false;
            this.InitReplsetToolStripMenuItem.Enabled = false;
            this.ReplicaSetToolStripMenuItem.Enabled = false;
            this.ShardingConfigToolStripMenuItem.Enabled = false;
            this.DisconnectToolStripMenuItem.Enabled = false;

            //管理-数据库
            this.CreateMongoCollectionToolStripMenuItem.Enabled = false;
            this.CopyDatabasetoolStripMenuItem.Enabled = false;
            this.DelMongoDBToolStripMenuItem.Enabled = false;
            this.UserInfoStripMenuItem.Enabled = false;
            this.AddUserToolStripMenuItem.Enabled = false;
            this.evalJSToolStripMenuItem.Enabled = false;
            this.RepairDBToolStripMenuItem.Enabled = false;
            this.InitGFSToolStripMenuItem.Enabled = false;
            this.DBStatusToolStripMenuItem.Enabled = false;

            //管理-数据集
            this.IndexManageToolStripMenuItem.Enabled = false;
            this.ReIndexToolStripMenuItem.Enabled = false;
            this.RenameCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.CompactToolStripMenuItem.Enabled = false;
            this.viewDataToolStripMenuItem.Enabled = false;
            this.AggregationToolStripMenuItem.Enabled = false;
            this.creatJavaScriptToolStripMenuItem.Enabled = false;
            this.dropJavascriptToolStripMenuItem.Enabled = false;
            this.CollectionStatusToolStripMenuItem.Enabled = false;
            this.validateToolStripMenuItem.Enabled = false;
            this.ProfillingLevelToolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            this.DumpDatabaseToolStripMenuItem.Enabled = false;
            this.RestoreMongoToolStripMenuItem.Enabled = false;
            this.DumpCollectionToolStripMenuItem.Enabled = false;
            this.ImportCollectionToolStripMenuItem.Enabled = false;
            this.ExportCollectionToolStripMenuItem.Enabled = false;


            //工具
            if (!SystemManager.MONO_MODE)
            {
                this.ImportDataFromAccessToolStripMenuItem.Enabled = false;
                this.ImportDataFromAccessToolStripButton.Enabled = false;
            }

        }
        #endregion

        #region"数据库连接"
        /// <summary>
        /// Connection Management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmConnect(), true, true);
            RefreshToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// Disconnect 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.SelectTagType != MongoDBHelper.CONNECTION_EXCEPTION_TAG)
            {
                SystemManager.GetCurrentServer().Disconnect();
            }
            MongoDBHelper._mongoConnSvrLst.Remove(config.ConnectionName);
            trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
            RefreshToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// Shut Down Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.ShowConfirm("ShutDown Server", "Are you sure to shutDown the Server?"))
            {
                MongoServer mongoSvr = SystemManager.GetCurrentServer();
                try
                {
                    //the server will be  shutdown with exception
                    MongoDBHelper._mongoConnSvrLst.Remove(SystemManager.SelectTagData);
                    mongoSvr.Shutdown();
                }
                catch (System.IO.IOException)
                {
                    //if IOException,ignore it
                }
                catch (Exception ex)
                {
                    SystemManager.ExceptionDeal(ex);
                }
                trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
                RefreshToolStripMenuItem_Click(sender, e);
            }
        }
        /// <summary>
        /// 初始化ReplSet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitReplsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ReplSetName = MyMessageBox.ShowInput("Please Fill ReplSetName :",
                SystemManager.IsUseDefaultLanguage ? "ReplSetName" : SystemManager.mStringResource.GetText(StringResource.TextType.Replset_InitReplset));
            if (ReplSetName != String.Empty)
            {
                CommandResult Result = MongoDBHelper.InitReplicaSet(ReplSetName, SystemManager.GetCurrentServerConfig().ConnectionName);
                if (Result.Ok)
                {
                    //修改配置
                    ConfigHelper.MongoConnectionConfig newConfig = SystemManager.GetCurrentServerConfig();
                    newConfig.ReplSetName = ReplSetName;
                    newConfig.ReplsetList = new List<string>();
                    newConfig.ReplsetList.Add(newConfig.Host +
                                             (newConfig.Port != 0 ? ":" + newConfig.Port.ToString() : String.Empty));
                    SystemManager.ConfigHelperInstance.ConnectionList[newConfig.ConnectionName] = newConfig;
                    SystemManager.ConfigHelperInstance.SaveToConfigFile();
                    MongoDBHelper._mongoConnSvrLst.Remove(newConfig.ConnectionName);
                    MongoDBHelper._mongoConnSvrLst.Add(config.ConnectionName, MongoDBHelper.CreateMongoServer(ref newConfig));
                    this.ServerStatusCtl.SetEnable(false);
                    MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
                    this.ServerStatusCtl.SetEnable(true);
                }
                else
                {
                    MyMessageBox.ShowMessage("ReplSetName", "Failed", Result.ErrorMessage);
                }
            }
        }
        /// <summary>
        /// 副本管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigHelper.MongoConnectionConfig newConfig = SystemManager.GetCurrentServerConfig();
            SystemManager.OpenForm(new frmReplsetMgr(ref newConfig), true, true);
            SystemManager.ConfigHelperInstance.ConnectionList[newConfig.ConnectionName] = newConfig;
            SystemManager.ConfigHelperInstance.SaveToConfigFile();
            MongoDBHelper._mongoConnSvrLst.Remove(newConfig.ConnectionName);
            MongoDBHelper._mongoConnSvrLst.Add(config.ConnectionName, MongoDBHelper.CreateMongoServer(ref newConfig));
            this.ServerStatusCtl.SetEnable(false);
            MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
            this.ServerStatusCtl.SetEnable(true);

        }
        /// <summary>
        /// 分片管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShardingConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmShardingConfig(), true, true);
        }
        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.FillConnectionToTreeView(trvsrvlst);
            this.ServerStatusCtl.ResetCtl();
            this.ServerStatusCtl.RefreshStatus(false);
            this.ServerStatusCtl.RefreshCurrentOpr();

            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            }
            else
            {
                this.statusStripMain.Items[0].Text = "Ready";
            }
            DisableAllOpr();
        }
        /// <summary>
        /// Expand All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.BeginUpdate();
            this.trvsrvlst.ExpandAll();
            this.trvsrvlst.EndUpdate();
        }
        /// <summary>
        /// Collapse All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.BeginUpdate();
            this.trvsrvlst.CollapseAll();
            this.trvsrvlst.EndUpdate();
        }
        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region"管理：服务器"
        /// <summary>
        /// 建立数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strDBName = String.Empty;
            if (SystemManager.IsUseDefaultLanguage)
            {
                strDBName = MyMessageBox.ShowInput("Please Input DataBaseName：", "Create Database");
            }
            else
            {
                strDBName = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_DataBase_Input),
                                                                       SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_DataBase));
            }
            String ErrMessage;
            SystemManager.GetCurrentServer().IsDatabaseNameValid(strDBName, out ErrMessage);
            if (ErrMessage == null)
            {
                try
                {
                    String strRusult = MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Create, trvsrvlst.SelectedNode);
                    if (String.IsNullOrEmpty(strRusult))
                    {
                        DisableAllOpr();
                    }
                    else {
                        MyMessageBox.ShowMessage("Error", "Create MongoDatabase", strRusult, true);
                    }
                }
                catch (ArgumentException ex)
                {
                    SystemManager.ExceptionDeal(ex, "Create MongoDatabase", "Argument Exception");
                }
            }
            else
            {
                MyMessageBox.ShowMessage("Create MongoDatabase", "Argument Exception", ErrMessage, true);
            }
        }
        /// <summary>
        /// copyDatabase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyDatabasetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SystemManager.GetCurrentServer().CopyDatabase(SystemManager.GetCurrentDataBase().Name, SystemManager.GetCurrentDataBase().Name + "_Backup");
            //MongoDBHelper.ExecuteMongoDBCommand("copyDatabase", SystemManager.GetCurrentDataBase());
            //CommandDocument copy = new CommandDocument();
            //SystemManager.GetCurrentDataBase().RunCommand("copyDatabase");
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (var item in MongoDBHelper._mongoUserLst.Keys)
            //{
                String ConnectionName = SystemManager.GetCurrentServerConfig().ConnectionName;
                String info = MongoDBHelper._mongoUserLst[ConnectionName].ToString();
                if (!string.IsNullOrEmpty(info))
                {
                    MyMessageBox.ShowMessage(SystemManager.IsUseDefaultLanguage?"UserInformation":SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_UserInfo),
                        "The User Information of：[" + SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName].UserName + "]", info, true);
                }
            //}
        }
        /// <summary>
        /// Create User to Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUser(true), true, true);
        }
        /// <summary>
        /// SlaveResync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slaveResyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ExecuteMongoCommand(MongoDBHelper.resync_Command);
        }
        /// <summary>
        /// Server Info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Server Property", "Server Property", MongoDBHelper.GetCurrentSvrInfo(), true);
            }
            else
            {
                MyMessageBox.ShowMessage(SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties),
                                         SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties),
                                         MongoDBHelper.GetCurrentSvrInfo(), true);
            }
        }
        /// <summary>
        /// Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmStatus(), true, true);
        }
        #endregion

        #region"管理：数据库"

        /// <summary>
        /// Drop MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Drop Database";
            String strMessage = "Are you really want to Drop current Database?";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_DataBase);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_DataBase_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                String strPath = SystemManager.SelectTagData;
                String strDBName = strPath.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.DatabaseLV];
                if (trvsrvlst.SelectedNode == null)
                {
                    trvsrvlst.SelectedNode = null;
                }
                String rtnResult = MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Drop, trvsrvlst.SelectedNode);
                if (String.IsNullOrEmpty(rtnResult))
                {
                    DisableAllOpr();
                    //关闭所有的相关视图
                    //foreach不能直接修改，需要一个备份
                    Dictionary<String, TabPage> tempTable = new Dictionary<string, TabPage>();
                    foreach (String item in ViewTabList.Keys)
                    {
                        tempTable.Add(item, ViewTabList[item]);
                    }

                    foreach (String KeyItem in tempTable.Keys)
                    {
                        //如果有相同的前缀
                        if (KeyItem.StartsWith(strPath))
                        {
                            ToolStripMenuItem DataMenuItem = null;
                            foreach (ToolStripMenuItem Menuitem in collectionToolStripMenuItem.DropDownItems)
                            {
                                //菜单的寻找
                                if (Menuitem.Tag == ViewTabList[KeyItem].Tag)
                                {
                                    DataMenuItem = Menuitem;
                                }
                            }
                            if (DataMenuItem != null)
                            {
                                //菜单的删除
                                collectionToolStripMenuItem.DropDownItems.Remove(DataMenuItem);
                            }
                            //TabPage的删除
                            tabView.Controls.Remove(ViewTabList[KeyItem]);
                            ViewTabList.Remove(KeyItem);
                            ViewInfoList.Remove(KeyItem);
                            ViewTabList[KeyItem] = null;
                        }
                    }
                    tempTable = null;
                }
                else {
                    MyMessageBox.ShowMessage("Error", "Error", rtnResult, true);
                }
            }
        }
        /// <summary>
        /// Create Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Advance CreateCollection
            frmCreateCollection frm =
                new frmCreateCollection()
                {
                    strSvrPathWithTag = SystemManager.SelectObjectTag,
                    treeNode = trvsrvlst.SelectedNode
                };
            SystemManager.OpenForm(frm, true, true);
            if (frm.Result)
            {
                DisableAllOpr();
            }
        }
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUser(false), true, true);
        }
        /// <summary>
        /// Eval JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmevalJS(), true, true);
        }
        /// <summary>
        /// Repair DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepairDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ExecuteMongoCommand(MongoDBHelper.repairDatabase_Command);
        }
        /// <summary>
        /// Init GFS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitGFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.InitGFS();
            DisableAllOpr();
            MongoDBHelper.FillConnectionToTreeView(trvsrvlst);
        }
        /// <summary>
        /// Profilling Level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profillingLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmProfilling(), true, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmStatus(), true, true);
        }
        /// <summary>
        /// Create Js
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creatJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strJsName = MyMessageBox.ShowInput("pls Input Javascript Name", "Save Javascript");
            if (strJsName != String.Empty)
            {
                MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
                if (MongoDBHelper.IsExistByKey(jsCol, strJsName))
                {
                    MyMessageBox.ShowMessage("Error", "javascript is already exist");
                }
                else
                {
                    String Result = MongoDBHelper.CreateNewJavascript(strJsName, String.Empty);
                    if (string.IsNullOrEmpty(Result))
                    {
                        TreeNode jsNode = new TreeNode(strJsName);
                        jsNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc;
                        jsNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc;
                        String jsTag = SystemManager.SelectTagData;
                        jsNode.Tag = MongoDBHelper.JAVASCRIPT_DOC_TAG + ":" + jsTag + "/" + strJsName;
                        trvsrvlst.SelectedNode.Nodes.Add(jsNode);
                        trvsrvlst.SelectedNode = jsNode;
                        SystemManager.SelectObjectTag = jsNode.Tag.ToString();
                        ViewJavascript();
                    }
                    else {
                        MyMessageBox.ShowMessage("Error", "Create Javascript Error", Result, true);
                    }
                }
            }
        }
        #endregion

        #region"管理：数据集"

        /// <summary>
        /// 删除Mongo数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Drop Collection";
            String strMessage = "Are you sure to drop this Collection?";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Collection);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Collection_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                String strPath = SystemManager.SelectTagData;
                String strCollection = strPath.Split("/".ToCharArray())[2];
                if (SystemManager.GetCurrentDataBase().DropCollection(trvsrvlst.SelectedNode.Text).Ok)
                {
                    String strNodeData = SystemManager.SelectTagData;
                    if (ViewTabList.ContainsKey(strNodeData))
                    {
                        TabPage DataTab = ViewTabList[strNodeData];
                        foreach (ToolStripMenuItem item in this.collectionToolStripMenuItem.DropDownItems)
                        {
                            if (item.Tag == DataTab.Tag)
                            {
                                collectionToolStripMenuItem.DropDownItems.Remove(item);
                                break;
                            }
                        }
                        tabView.Controls.Remove(DataTab);
                        ViewTabList.Remove(strNodeData);
                        ViewInfoList.Remove(strNodeData);
                        DataTab = null;
                    }
                    this.trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
                    DisableAllOpr();
                }
            }
        }
        /// <summary>
        /// 重命名数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectTagData;
            String strCollection = strPath.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.CollectionLV];
            String strNewCollectionName = String.Empty;
            if (SystemManager.IsUseDefaultLanguage)
            {
                strNewCollectionName = MyMessageBox.ShowInput("Please input new collection name：", "Rename collection", strCollection);
            }
            else
            {
                strNewCollectionName = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Rename_Collection_Input),
                                                              SystemManager.mStringResource.GetText(StringResource.TextType.Rename_Collection));
            }
            if (!String.IsNullOrEmpty(strNewCollectionName) && SystemManager.GetCurrentDataBase().RenameCollection(trvsrvlst.SelectedNode.Text, strNewCollectionName).Ok)
            {
                String strNodeData = SystemManager.SelectTagData;
                String strNewNodeTag = SystemManager.SelectObjectTag.Substring(0, SystemManager.SelectObjectTag.Length - SystemManager.GetCurrentCollection().Name.Length);
                strNewNodeTag += strNewCollectionName;
                String strNewNodeData = SystemManager.GetTagData(strNewNodeTag);
                if (ViewTabList.ContainsKey(strNodeData))
                {
                    TabPage DataTab = ViewTabList[strNodeData];
                    foreach (ToolStripMenuItem item in this.collectionToolStripMenuItem.DropDownItems)
                    {
                        if (item.Tag == DataTab.Tag)
                        {
                            item.Text = strNewCollectionName;
                            item.Tag = strNewNodeTag;
                            break;
                        }
                    }
                    DataTab.Text = strNewCollectionName;
                    DataTab.Tag = strNewNodeTag;

                    //Change trvsrvlst.SelectedNode
                    ViewTabList.Add(strNewNodeData, ViewTabList[strNodeData]);
                    ViewTabList.Remove(strNodeData);

                    ViewInfoList.Add(strNewNodeData, ViewInfoList[strNodeData]);
                    ViewInfoList.Remove(strNodeData);
                }
                DisableAllOpr();
                SystemManager.SelectObjectTag = strNewNodeTag;
                trvsrvlst.SelectedNode.Text = strNewCollectionName;
                trvsrvlst.SelectedNode.Tag = strNewNodeTag;
                trvsrvlst.SelectedNode.ToolTipText = strNewCollectionName + System.Environment.NewLine;
                trvsrvlst.SelectedNode.ToolTipText += "IsCapped:" + SystemManager.GetCurrentCollection().GetStats().IsCapped.ToString();

                if (SystemManager.IsUseDefaultLanguage)
                {
                    statusStripMain.Items[0].Text = "selected Collection:" + SystemManager.SelectTagData;
                }
                else
                {
                    statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Collection) +
                          ":" + SystemManager.SelectTagData;
                }
            }
        }
        /// <summary>
        /// 索引管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmCollectionIndex(), true, true);
        }
        /// <summary>
        /// ReIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.GetCurrentCollection().ReIndex();
        }
        /// <summary>
        /// Compact 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ExecuteMongoCommand(MongoDBHelper.Compact_Command);
        }
        /// <summary>
        /// Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropJavascriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Result = MongoDBHelper.DelJavascript(trvsrvlst.SelectedNode.Text);
            if (String.IsNullOrEmpty(Result))
            {
                String strNodeData = SystemManager.SelectTagData;
                if (ViewTabList.ContainsKey(strNodeData))
                {
                    TabPage DataTab = ViewTabList[strNodeData];
                    foreach (ToolStripMenuItem item in JavaScriptStripMenuItem.DropDownItems)
                    {
                        if (item.Tag == DataTab.Tag)
                        {
                            JavaScriptStripMenuItem.DropDownItems.Remove(item);
                            break;
                        }
                    }
                    tabView.Controls.Remove(DataTab);
                    ViewTabList.Remove(strNodeData);
                }
                this.trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
                DisableAllOpr();
            }
            else {
                MyMessageBox.ShowMessage("Delete Error", "A error is happened when delete javascript", Result, true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusToolStripMenuItem.Checked)
            {
                //关闭
                tabView.Controls.Remove(tabSvrStatus);
            }
            else
            {
                //打开
                tabView.Controls.Add(tabSvrStatus);
                tabView.SelectTab(tabSvrStatus);
            }
            statusToolStripMenuItem.Checked = !statusToolStripMenuItem.Checked;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commandShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (commandShellToolStripMenuItem.Checked)
            {
                //关闭
                tabView.Controls.Remove(tabCommandShell);
            }
            else
            {
                //打开
                tabView.Controls.Add(tabCommandShell);
                tabView.SelectTab(tabCommandShell);
            }
            commandShellToolStripMenuItem.Checked = !commandShellToolStripMenuItem.Checked;
        }
        /// <summary>
        /// CollectionStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectionStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmStatus(), true, true);
        }
        /// <summary>
        /// validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmValidate(), true, true);
        }
        #endregion

        #region"管理：备份和恢复"
        /// <summary>
        /// 检查MongoDB执行目录是否存在
        /// </summary>
        /// <returns></returns>
        private Boolean MongoPathCheck()
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                MyMessageBox.ShowMessage("Exception",
                                         "Mongo Bin Path Can't be found",
                                         "Mongo Bin Path[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]Can't be found");
                SystemManager.OpenForm(new frmOption(), true, true);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 执行DOS命令
        /// </summary>
        /// <param name="DosCommand"></param>
        private void RunCommand(String DosCommand)
        {
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            MyMessageBox.ShowMessage("DOS", "Dos Result：", Info.ToString(), true);
        }
        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestoreMongoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Restore";
            String strMessage = "Are you sure to Restore?";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruMongoRestore MongoRestore = new MongodbDosCommand.StruMongoRestore();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
                MongoRestore.HostAddr = Mongosrv.Address.Host;
                MongoRestore.Port = Mongosrv.Address.Port;
                FolderBrowserDialog dumpFile = new FolderBrowserDialog();
                if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MongoRestore.DirectoryPerDB = dumpFile.SelectedPath;
                }
                String DosCommand = MongodbDosCommand.GetMongoRestoreCommandLine(MongoRestore);
                RunCommand(DosCommand);
                RefreshToolStripMenuItem_Click(null, null);
            }
        }
        /// <summary>
        /// Dump Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck()) { return; }
            MongodbDosCommand.StruMongoDump MongoDump = new MongodbDosCommand.StruMongoDump();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = SystemManager.GetCurrentDataBase().Name;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            RunCommand(DosCommand);
        }
        /// <summary>
        /// Dump Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck()) { return; }
            MongodbDosCommand.StruMongoDump MongoDump = new MongodbDosCommand.StruMongoDump();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoDump.CollectionName = SystemManager.GetCurrentCollection().Name;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            RunCommand(DosCommand);
        }
        /// <summary>
        /// Export Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck()) { return; }
            MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
            OpenFileDialog dumpFile = new OpenFileDialog();
            //if the file not exist,the server will create a new one
            dumpFile.CheckFileExists = false;
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoImportExport.FileName = dumpFile.FileName;
            }
            MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Export;
            String DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
            RunCommand(DosCommand);
        }
        /// <summary>
        /// Import Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Import Collection";
            String strMessage = "Are you sure to Import Collection?";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
                MongoImportExport.HostAddr = Mongosrv.Address.Host;
                MongoImportExport.Port = Mongosrv.Address.Port;
                MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
                MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
                OpenFileDialog dumpFile = new OpenFileDialog();
                if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MongoImportExport.FileName = dumpFile.FileName;
                }
                MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Import;
                String DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
                RunCommand(DosCommand);
            }
        }
        #endregion

        #region"聚合"
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            Boolean IsUseFilter = false;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                Query = ViewInfoList[ColPath].mDataFilter;
                IsUseFilter = ViewInfoList[ColPath].IsUseFilter;
            }

            if (Query.QueryConditionList.Count == 0 || !IsUseFilter)
            {
                MyMessageBox.ShowEasyMessage("Count", "Count Result : " + SystemManager.GetCurrentCollection().Count().ToString());
            }
            else
            {
                MongoDB.Driver.IMongoQuery mQuery = MongoDBHelper.GetQuery(Query.QueryConditionList);
                MyMessageBox.ShowMessage("Count",
                "Count[With DataView Filter]:" + SystemManager.GetCurrentCollection().Count(mQuery).ToString(),
                mQuery.ToString(), true);
            }
        }
        /// <summary>
        /// Distinct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            Boolean IsUseFilter = false;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                Query = ViewInfoList[ColPath].mDataFilter;
                IsUseFilter = ViewInfoList[ColPath].IsUseFilter;
            }
            SystemManager.OpenForm(new frmDistinct(Query, IsUseFilter), true, true);
        }
        /// <summary>
        /// Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            Boolean IsUseFilter = false;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                Query = ViewInfoList[ColPath].mDataFilter;
                IsUseFilter = ViewInfoList[ColPath].IsUseFilter;
            }
            SystemManager.OpenForm(new frmGroup(Query, IsUseFilter), true, true);
        }
        /// <summary>
        /// MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmMapReduce(), true, true);
        }
        /// <summary>
        /// aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aggregateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmAggregation(), true, true);
        }
        /// <summary>
        /// TextSearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmTextSearch(), true, true);
        }
        #endregion

        #region"工具"
        /// <summary>
        /// Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmOption(), true, true);
            SystemManager.InitLanguage();
            if (SystemManager.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Language", "Language will change to \"English\" when you restart this tool");
            }
            else
            {
                SetMenuText();
            }
        }
        /// <summary>
        /// Import data from access
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportDataFromAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SystemManager.MONO_MODE)
            {
                //MONO not support this function
                OpenFileDialog AccessFile = new OpenFileDialog();
                AccessFile.Filter = MongoDBHelper.MdbFilter;
                if (AccessFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MongoDBHelper.ImportAccessPara parm = new MongoDBHelper.ImportAccessPara();
                    parm.accessFileName = AccessFile.FileName;
                    parm.currentTreeNode = trvsrvlst.SelectedNode;
                    parm.strSvrPathWithTag = SystemManager.SelectObjectTag;
                    ParameterizedThreadStart Parmthread = new ParameterizedThreadStart(MongoDBHelper.ImportAccessDataBase);
                    Thread t = new Thread(Parmthread);
                    Parmthread.Invoke(parm);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GernerateConfigtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmGenerateConfigIni(), true, true);
        }
        /// <summary>
        /// DOS控制台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmDosCommand(), true, true);
        }
        #endregion

        #region "Help"
        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MyMessageBox.ShowMessage("About", "MagicCola",
                                     MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.Smile),
                                     new System.IO.StreamReader("Release Note.txt").ReadToEnd());
        }
        /// <summary>
        /// Thanks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strThanks = "感谢皮肤控件的作者：qianlifeng" + System.Environment.NewLine;
            strThanks += "感谢10gen的C# Driver开发者的技术支持" + System.Environment.NewLine;
            strThanks += "感谢Dragon同志的测试和代码规范化" + System.Environment.NewLine;
            strThanks += "感谢MoLing同志的国际化" + System.Environment.NewLine;
            strThanks += "感谢Cnblogs的各位网友的帮助" + System.Environment.NewLine;
            strThanks += "Thanks Robert Stam for C# driver support" + System.Environment.NewLine;
            MyMessageBox.ShowMessage("Thanks", "MagicCola",
                                     MagicMongoDBTool.Module.GetResource.GetImage(MagicMongoDBTool.Module.ImageType.Smile),
                                     strThanks);
        }
        /// <summary>
        /// userGuide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUrl = @"UserGuide\index.html";
            System.Diagnostics.Process.Start(strUrl);
        }
        /// <summary>
        /// Unit Test Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forMySelfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUnitTest(), true, true);
        }
        #endregion



    }
}
