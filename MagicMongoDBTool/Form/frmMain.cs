using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MagicMongoDBTool.Common;
using MagicMongoDBTool.Module;
using MagicMongoDBTool.Properties;
using MagicMongoDBTool.UserController;

namespace MagicMongoDBTool
{
    public partial class frmMain
    {
        /// <summary>
        ///     多文档视图管理
        /// </summary>
        private readonly Dictionary<String, MongoDBHelper.DataViewInfo> _viewInfoList =
            new Dictionary<String, MongoDBHelper.DataViewInfo>();

        /// <summary>
        ///     多文档视图管理
        /// </summary>
        private readonly Dictionary<String, TabPage> _viewTabList = new Dictionary<String, TabPage>();

        /// <summary>
        ///     Current Connection Config
        /// </summary>
        private ConfigHelper.MongoConnectionConfig _config;

        #region"MainForm"

        /// <summary>
        ///     切换Tab的时候，必须切换当前对象
        /// </summary>
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
            Text += "  " + SystemManager.Version;
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (SystemManager.MONO_MODE)
            {
                Text += " MONO";
            }
            //长时间操作时候，实时提示进度在状态栏中
            lblAction.Text = String.Empty;
            MongoDBHelper.ActionDone += (x, y) =>
            {
                //1.lblAction 没有InvokeRequired
                //2.DoEvents必须
                lblAction.Text = y.Message;
                Application.DoEvents();
            };
        }

        /// <summary>
        ///     Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            trvsrvlst.NodeMouseClick += trvsrvlst_NodeMouseClick;
            trvsrvlst.NodeMouseDoubleClick += (x, y) => { ViewDataObj(); };
            ViewDataToolStripMenuItem.Click += (x, y) => { ViewDataObj(); };
            trvsrvlst.KeyDown += trvsrvlst_KeyDown;
            //加载插件信息
            PlugIn.LoadPlugIn();
            foreach (var plugin in PlugIn.PlugInList)
            {
                String PlugInType = String.Empty;
                switch (plugin.Value.RunLv)
                {
                    case PlugBase.PathLv.ConnectionLV:
                        PlugInType = "[Connection]";
                        break;
                    case PlugBase.PathLv.InstanceLV:
                        PlugInType = "[Instance]";
                        break;
                    case PlugBase.PathLv.DatabaseLV:
                        PlugInType = "[Database]";
                        break;
                    case PlugBase.PathLv.CollectionLV:
                        PlugInType = "[Collection]";
                        break;
                    case PlugBase.PathLv.DocumentLV:
                        PlugInType = "[Document]";
                        break;
                    case PlugBase.PathLv.Misc:
                        PlugInType = "[Misc]";
                        break;
                    default:
                        break;
                }
                ToolStripItem menu = new ToolStripMenuItem(plugin.Value.PlugName + PlugInType);
                menu.ToolTipText = plugin.Value.PlugFunction;
                menu.Tag = plugin.Key;
                menu.Click += (x, y) => { PlugIn.RunPlugIn(plugin.Key); };
                plugInToolStripMenuItem.DropDownItems.Add(menu);
            }

            DisableAllOpr();
            //Set Tool bar button enable 
            SetToolBarEnabled();

            //Open ConnectionManagement Form
            SystemManager.OpenForm(new frmConnect(), true, true);
            ServerStatusCtl.SetEnable(true);
            RefreshToolStripMenuItem_Click(sender, e);
            commandShellToolStripMenuItem.Checked = true;

            statusToolStripMenuItem.Checked = true;
            ServerStatusCtl.CloseTab += (x, y) =>
            {
                statusToolStripMenuItem.Checked = false;
                tabView.Controls.Remove(tabSvrStatus);
            };
            ctlShellCommandEditor.CloseTab += (x, y) =>
            {
                commandShellToolStripMenuItem.Checked = false;
                tabView.Controls.Remove(tabCommandShell);
            };
            tabView.SelectedIndexChanged += tabView_SelectedIndexChanged;
            MongoDBHelper.RunCommandComplete += CommandLog;
        }

        /// <summary>
        ///     Set Menu Text
        /// </summary>
        private void SetMenuText()
        {
            //管理
            ManagerToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt);
            DisconnectToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Disconnect);
            AddConnectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_AddConnection);
            RefreshToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);

            ExpandAllConnectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Common_Expansion);
            CollapseAllConnectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collapse);
            ExitToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Exit);

            //数据视图
            ViewToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            ViewRefreshToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);
            collectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collection);
            statusToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);


            //Operation
            OperationToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation);

            connectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Common_Connect);
            ReplicaSetToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
            ShardingConfigToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ShardingConfig);
            InitReplsetToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Replset_InitReplset);


            ServerToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
            CreateMongoDBToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
            UserInfoStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_UserInfo);
            AddUserToAdminToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
            slaveResyncToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_SlaveResync);
            ShutDownToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
            ServePropertyToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties);
            ServerStatusToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

            DataBaseToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
            DelMongoDBToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelDB);
            CreateMongoCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddDC);
            AddUserToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            EvalJSToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
            RepairDBToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Database_RepairDatabase);
            DBStatusToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

            DataCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection);
            DelMongoCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
            RenameCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
            IndexManageToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
            ReIndexToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
            CompactToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Compact);
            CollectionStatusToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            InitGFSToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_InitGFS);
            ProfillingLevelToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_ProfillingLevel);
            AggregationToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);
            ValidateToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);
            ExportToFileToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_ExportToFile);

            DumpAndRestoreToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
            RestoreMongoToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
            DumpCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
            DumpDatabaseToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
            ImportCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
            ExportCollectionToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);
            creatJavaScriptToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_CreateJavaScript);
            ViewDataToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_View);
            dropJavascriptToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_DropJavaScript);

            //Tool
            ToolsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool);
            DosCommandToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_DOS);
            ImportDataFromAccessToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Access);
            OptionsToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Setting);

            //帮助
            HelpToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help);
            AboutToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_About);
            ThanksToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_Thanks);
            UserGuideToolStripMenuItem.Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_UserGuide);

            //其他控件
            statusStripMain.Items[0].Text =
                SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            tabSvrStatus.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabView.SelectedTab != null && tabView.SelectedTab.Tag != null)
            {
                SystemManager.SelectObjectTag = tabView.SelectedTab.Tag.ToString();
            }
        }

        /// <summary>
        ///     CommandLog
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void CommandLog(Object Sender, RunCommandEventArgs e)
        {
            ctlShellCommandEditor.AppendLine("========================================================");
            ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now + "  CommandName:" + e.Result.CommandName);
            ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now + "  Command:" + e.Result.Command);
            ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now + "  OK:" + e.Result.Ok);
            ctlShellCommandEditor.AppendLine("========================================================");
        }

        /// <summary>
        ///     KeyEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    //Del
                    if (DelMongoDBToolStripMenuItem.Enabled)
                    {
                        DelMongoDBToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        if (DelMongoCollectionToolStripMenuItem.Enabled)
                        {
                            DelMongoCollectionToolStripMenuItem_Click(null, null);
                        }
                    }
                    break;
                case Keys.F2:
                    //Rename
                    if (RenameCollectionToolStripMenuItem.Enabled)
                    {
                        RenameCollectionToolStripMenuItem_Click(null, null);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        ///     ConnectionList TreeView Node is clicked by mouse
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
                trvsrvlst.SelectedNode = e.Node;
                String strNodeType = SystemManager.GetTagType(e.Node.Tag.ToString());
                String mongoSvrKey = SystemManager.GetTagData(e.Node.Tag.ToString()).Split("/".ToCharArray())[0];
                _config = SystemManager.ConfigHelperInstance.ConnectionList[mongoSvrKey];
                if (String.IsNullOrEmpty(_config.UserName))
                {
                    lblUserInfo.Text = "UserInfo:Admin";
                }
                else
                {
                    lblUserInfo.Text = "UserInfo:" + _config.UserName;
                }
                if (_config.AuthMode)
                {
                    lblUserInfo.Text += " @AuthMode";
                }
                if (_config.IsReadOnly)
                {
                    lblUserInfo.Text += " [ReadOnly]";
                }
                if (!_config.IsReadOnly)
                {
                    //恢复数据：这个操作可以针对服务器，数据库，数据集，所以可以放在共通
                    RestoreMongoToolStripMenuItem.Enabled = true;
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
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Server) + ":" +
                                SystemManager.SelectTagData;
                        }

                        DisconnectToolStripMenuItem.Enabled = true;
                        ShutDownToolStripMenuItem.Enabled = true;
                        ShutDownToolStripButton.Enabled = true;

                        if (strNodeType == MongoDBHelper.CONNECTION_TAG)
                        {
                            InitReplsetToolStripMenuItem.Enabled = true;
                        }
                        if (strNodeType == MongoDBHelper.CONNECTION_REPLSET_TAG)
                        {
                            ReplicaSetToolStripMenuItem.Enabled = true;
                        }
                        if (strNodeType == MongoDBHelper.CONNECTION_CLUSTER_TAG)
                        {
                            ShardingConfigToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t1 = DisconnectToolStripMenuItem.Clone();
                                t1.Click += DisconnectToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = InitReplsetToolStripMenuItem.Clone();
                                t2.Click += InitReplsetToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = ReplicaSetToolStripMenuItem.Clone();
                                t3.Click += ReplicaSetToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t4 = ShardingConfigToolStripMenuItem.Clone();
                                t4.Click += ShardingConfigToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t4);

                                ToolStripMenuItem t5 = ShutDownToolStripMenuItem.Clone();
                                t5.Click += ShutDownToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t5);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ShutDownToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(InitReplsetToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ReplicaSetToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ShardingConfigToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.CONNECTION_EXCEPTION_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        DisconnectToolStripMenuItem.Enabled = true;
                        RestoreMongoToolStripMenuItem.Enabled = false;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = DisconnectToolStripMenuItem.Clone();
                                t1.Click += DisconnectToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t1);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
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
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Server) + ":" +
                                SystemManager.SelectTagData;
                        }
                        //解禁 创建数据库,关闭服务器
                        if (!_config.IsReadOnly)
                        {
                            CreateMongoDBToolStripMenuItem.Enabled = true;
                            AddUserToAdminToolStripMenuItem.Enabled = true;
                            if (!SystemManager.MONO_MODE)
                            {
                                ImportDataFromAccessToolStripMenuItem.Enabled = true;
                            }
                            if (_config.ServerRole == ConfigHelper.SvrRoleType.MasterSvr ||
                                _config.ServerRole == ConfigHelper.SvrRoleType.SlaveSvr)
                            {
                                //Master，Slave都可以执行
                                slaveResyncToolStripMenuItem.Enabled = true;
                            }
                        }
                        UserInfoStripMenuItem.Enabled = true;
                        ServerStatusToolStripMenuItem.Enabled = true;
                        ServePropertyToolStripMenuItem.Enabled = true;

                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = CreateMongoDBToolStripMenuItem.Clone();
                                t1.Click += CreateMongoDBToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = AddUserToAdminToolStripMenuItem.Clone();
                                t2.Click += AddUserToAdminToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = RestoreMongoToolStripMenuItem.Clone();
                                t3.Click += RestoreMongoToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t6 = slaveResyncToolStripMenuItem.Clone();
                                t6.Click += slaveResyncToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t6);

                                ToolStripMenuItem t9 = ServePropertyToolStripMenuItem.Clone();
                                t9.Click += ServePropertyToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t9);

                                ToolStripMenuItem t10 = ServerStatusToolStripMenuItem.Clone();
                                t10.Click += SvrStatusToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t10);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(CreateMongoDBToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(AddUserToAdminToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(UserInfoStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ImportDataFromAccessToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(RestoreMongoToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(slaveResyncToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ServePropertyToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ServerStatusToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.SINGLE_DB_SERVER_TAG:
                        //单数据库模式,禁止所有服务器操作
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = DisconnectToolStripMenuItem.Clone();
                                t1.Click += DisconnectToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t1);
                                ToolStripMenuItem t2 = ServerStatusToolStripMenuItem.Clone();
                                t2.Click += SvrStatusToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t2);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ServerStatusToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected Server[Single Database]:" +
                                                        SystemManager.SelectTagData;
                        break;
                    case MongoDBHelper.DATABASE_TAG:
                    case MongoDBHelper.SINGLE_DATABASE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        List<String> roles = MongoDBHelper.GetCurrentDBRoles();
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected DataBase:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_DataBase) + ":" +
                                SystemManager.SelectTagData;
                        }
                        //系统库不允许修改
                        if (!MongoDBHelper.IsSystemDataBase(SystemManager.GetCurrentDataBase()))
                        {
                            if (_config.AuthMode)
                            {
                                //根据Roles确定删除数据库/创建数据集等的权限
                                DelMongoDBToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles,
                                    MongoDBHelper.MongoOperate.DelMongoDB);
                                CreateMongoCollectionToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles,
                                    MongoDBHelper.MongoOperate.CreateMongoCollection);
                                InitGFSToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles,
                                    MongoDBHelper.MongoOperate.InitGFS);
                                AddUserToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles,
                                    MongoDBHelper.MongoOperate.AddUser);
                                //If a Slave server can repair database @ Master-Slave is not sure ??
                                RepairDBToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles,
                                    MongoDBHelper.MongoOperate.RepairDB);
                            }
                            else
                            {
                                DelMongoDBToolStripMenuItem.Enabled = true;
                                CreateMongoCollectionToolStripMenuItem.Enabled = true;
                                InitGFSToolStripMenuItem.Enabled = true;
                                AddUserToolStripMenuItem.Enabled = true;
                                RepairDBToolStripMenuItem.Enabled = true;
                            }
                            EvalJSToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles,
                                MongoDBHelper.MongoOperate.EvalJS);
                        }
                        //备份数据库
                        DumpDatabaseToolStripMenuItem.Enabled = true;
                        ProfillingLevelToolStripMenuItem.Enabled = true;
                        if (strNodeType == MongoDBHelper.SINGLE_DATABASE_TAG)
                        {
                            DelMongoDBToolStripMenuItem.Enabled = false;
                        }
                        DBStatusToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = DelMongoDBToolStripMenuItem.Clone();
                                t1.Click += DelMongoDBToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = CreateMongoCollectionToolStripMenuItem.Clone();
                                t2.Click += CreateMongoCollectionToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = AddUserToolStripMenuItem.Clone();
                                t3.Click += AddUserToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t4 = EvalJSToolStripMenuItem.Clone();
                                t4.Click += evalJSToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t4);

                                ToolStripMenuItem t5 = RepairDBToolStripMenuItem.Clone();
                                t5.Click += RepairDBToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t5);


                                ToolStripMenuItem t6 = InitGFSToolStripMenuItem.Clone();
                                t6.Click += InitGFSToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t6);

                                ToolStripMenuItem t7 = DumpDatabaseToolStripMenuItem.Clone();
                                t7.Click += DumpDatabaseToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t7);

                                ToolStripMenuItem t8 = RestoreMongoToolStripMenuItem.Clone();
                                t8.Click += RestoreMongoToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t8);


                                contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t10 = ProfillingLevelToolStripMenuItem.Clone();
                                t10.Click += profillingLevelToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t10);

                                ToolStripMenuItem t11 = DBStatusToolStripMenuItem.Clone();
                                t11.Click += DBStatusToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t11);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(DelMongoDBToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(CreateMongoCollectionToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(AddUserToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(EvalJSToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(RepairDBToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(InitGFSToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(DumpDatabaseToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(RestoreMongoToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                contextMenuStripMain.Items.Add(ProfillingLevelToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(DBStatusToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
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
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Collection) + ":" +
                                SystemManager.SelectTagData;
                        }
                        //解禁 删除数据集
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            //系统数据库无法删除！！
                            if (!_config.IsReadOnly)
                            {
                                DelMongoCollectionToolStripMenuItem.Enabled = true;
                                RenameCollectionToolStripMenuItem.Enabled = true;
                            }
                        }
                        if (!_config.IsReadOnly)
                        {
                            ImportCollectionToolStripMenuItem.Enabled = true;
                            CompactToolStripMenuItem.Enabled = true;
                        }
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) &&
                            !_config.IsReadOnly)
                        {
                            IndexManageToolStripMenuItem.Enabled = true;
                            ReIndexToolStripMenuItem.Enabled = true;
                        }
                        DumpCollectionToolStripMenuItem.Enabled = true;
                        ExportCollectionToolStripMenuItem.Enabled = true;
                        AggregationToolStripMenuItem.Enabled = true;
                        ViewDataToolStripMenuItem.Enabled = true;
                        CollectionStatusToolStripMenuItem.Enabled = true;
                        ValidateToolStripMenuItem.Enabled = true;
                        ExportToFileToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                //悲催MONO不支持
                                ToolStripMenuItem t1 = DelMongoCollectionToolStripMenuItem.Clone();
                                t1.Click += DelMongoCollectionToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t1);

                                ToolStripMenuItem t2 = RenameCollectionToolStripMenuItem.Clone();
                                t2.Click += RenameCollectionToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t2);

                                ToolStripMenuItem t3 = DumpCollectionToolStripMenuItem.Clone();
                                t3.Click += DumpCollectionToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t3);

                                ToolStripMenuItem t4 = RestoreMongoToolStripMenuItem.Clone();
                                t4.Click += RestoreMongoToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t4);

                                ToolStripMenuItem t5 = ImportCollectionToolStripMenuItem.Clone();
                                t5.Click += ImportCollectionToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t5);

                                ToolStripMenuItem t6 = ExportCollectionToolStripMenuItem.Clone();
                                t6.Click += ExportCollectionToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t6);

                                ToolStripMenuItem t7 = CompactToolStripMenuItem.Clone();
                                t7.Click += CompactToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t7);

                                contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t8 = ViewDataToolStripMenuItem.Clone();
                                t8.Click += (x, y) => { ViewDataObj(); };
                                contextMenuStripMain.Items.Add(t8);

                                ToolStripMenuItem AggregationMenu = AggregationToolStripMenuItem.Clone();

                                ToolStripMenuItem t9 = countToolStripMenuItem.Clone();
                                t9.Click += countToolStripMenuItem_Click;
                                AggregationMenu.DropDownItems.Add(t9);

                                ToolStripMenuItem t10 = distinctToolStripMenuItem.Clone();
                                t10.Click += distinctToolStripMenuItem_Click;
                                AggregationMenu.DropDownItems.Add(t10);


                                ToolStripMenuItem t11 = groupToolStripMenuItem.Clone();
                                t11.Click += groupToolStripMenuItem_Click;
                                AggregationMenu.DropDownItems.Add(t11);

                                ToolStripMenuItem t12 = mapReduceToolStripMenuItem.Clone();
                                t12.Click += mapReduceToolStripMenuItem_Click;
                                AggregationMenu.DropDownItems.Add(t12);

                                contextMenuStripMain.Items.Add(AggregationMenu);
                                contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t13 = IndexManageToolStripMenuItem.Clone();
                                t13.Click += IndexManageToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t13);

                                ToolStripMenuItem t14 = ReIndexToolStripMenuItem.Clone();
                                t14.Click += ReIndexToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t14);

                                contextMenuStripMain.Items.Add(new ToolStripSeparator());

                                ToolStripMenuItem t15 = CollectionStatusToolStripMenuItem.Clone();
                                t15.Click += CollectionStatusToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t15);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(DelMongoCollectionToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(RenameCollectionToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(DumpCollectionToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(RestoreMongoToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ImportCollectionToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ExportCollectionToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ExportToFileToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(CompactToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(AggregationToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                contextMenuStripMain.Items.Add(IndexManageToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ReIndexToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                contextMenuStripMain.Items.Add(CollectionStatusToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(ValidateToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        //PlugIn
                        foreach (ToolStripMenuItem item in plugInToolStripMenuItem.DropDownItems)
                        {
                            if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugBase.PathLv.CollectionLV)
                            {
                                item.Enabled = true;
                            }
                        }
                        break;
                    case MongoDBHelper.INDEX_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Index) + ":" +
                                SystemManager.SelectTagData;
                        }
                        break;
                    case MongoDBHelper.INDEXES_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Indexes) + ":" +
                                SystemManager.SelectTagData;
                        }
                        break;
                    case MongoDBHelper.USER_LIST_TAG:
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected UserList:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_UserList) + ":" +
                                SystemManager.SelectTagData;
                        }
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = ViewDataToolStripMenuItem.Clone();
                                t8.Click += (x, y) => { ViewDataObj(); };
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
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
                            statusStripMain.Items[0].Text =
                                SystemManager.mStringResource.GetText(StringResource.TextType.Selected_GFS) + ":" +
                                SystemManager.SelectTagData;
                        }

                        ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = ViewDataToolStripMenuItem.Clone();
                                t8.Click += (x, y) => { ViewDataObj(); };
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.JAVASCRIPT_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        ViewDataToolStripMenuItem.Enabled = true;
                        if (!_config.IsReadOnly)
                        {
                            creatJavaScriptToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = creatJavaScriptToolStripMenuItem.Clone();
                                t8.Click += creatJavaScriptToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(creatJavaScriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected collection Javascript";
                        break;
                    case MongoDBHelper.JAVASCRIPT_DOC_TAG:
                        statusStripMain.Items[0].Text = "Selected JavaScript:" + SystemManager.SelectTagData;
                        ViewDataToolStripMenuItem.Enabled = true;
                        dropJavascriptToolStripMenuItem.Enabled = true;

                        if (e.Button == MouseButtons.Right)
                        {
                            contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t1 = ViewDataToolStripMenuItem.Clone();
                                t1.Click += (x, y) => { ViewDataObj(); };
                                contextMenuStripMain.Items.Add(t1);
                                ToolStripMenuItem t8 = dropJavascriptToolStripMenuItem.Clone();
                                t8.Click += dropJavascriptToolStripMenuItem_Click;
                                contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                contextMenuStripMain.Items.Add(ViewDataToolStripMenuItem.Clone());
                                contextMenuStripMain.Items.Add(dropJavascriptToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = contextMenuStripMain;
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
        ///     设置图标
        /// </summary>
        private void SetMenuImage()
        {
            ExitToolStripMenuItem.Image = Resources.exit.ToBitmap();

            ShutDownToolStripMenuItem.Image = GetResource.GetImage(ImageType.ShutDown);

            DelMongoCollectionToolStripMenuItem.Image = GetResource.GetIcon(IconType.No).ToBitmap();
            DelMongoDBToolStripMenuItem.Image = GetResource.GetIcon(IconType.No).ToBitmap();

            ImportDataFromAccessToolStripMenuItem.Image = GetResource.GetImage(ImageType.AccessDB);
            RefreshToolStripMenuItem.Image = GetResource.GetImage(ImageType.Refresh);
            OptionsToolStripMenuItem.Image = GetResource.GetImage(ImageType.Option);

            ThanksToolStripMenuItem.Image = GetResource.GetImage(ImageType.Smile);
            UserGuideToolStripMenuItem.Image = GetResource.GetIcon(IconType.UserGuide).ToBitmap();

            tabSvrStatus.ImageIndex = 0;
        }

        /// <summary>
        ///     初始化Toolbar
        /// </summary>
        private void InitToolBar()
        {
            ExpandAllConnectionToolStripButton = ExpandAllConnectionToolStripMenuItem.CloneFromMenuItem();
            CollapseAllConnectionToolStripButton = CollapseAllConnectionToolStripMenuItem.CloneFromMenuItem();
            RefreshToolStripButton = RefreshToolStripMenuItem.CloneFromMenuItem();
            ExitToolStripButton = ExitToolStripMenuItem.CloneFromMenuItem();

            ImportDataFromAccessToolStripButton = ImportDataFromAccessToolStripMenuItem.CloneFromMenuItem();
            ShutDownToolStripButton = ShutDownToolStripMenuItem.CloneFromMenuItem();

            OptionToolStripButton = OptionsToolStripMenuItem.CloneFromMenuItem();
            UserGuideToolStripButton = UserGuideToolStripMenuItem.CloneFromMenuItem();
            //暂时不对应MONO
            if (SystemManager.MONO_MODE)
            {
                RefreshToolStripButton.Click += RefreshToolStripMenuItem_Click;
                ShutDownToolStripButton.Click += ShutDownToolStripMenuItem_Click;
                OptionToolStripButton.Click += OptionToolStripMenuItem_Click;
                UserGuideToolStripButton.Click += userGuideToolStripMenuItem_Click;
            }
            //Main ToolTip
            toolStripMain.Items.Add(ExpandAllConnectionToolStripButton);
            toolStripMain.Items.Add(CollapseAllConnectionToolStripButton);
            toolStripMain.Items.Add(RefreshToolStripButton);
            toolStripMain.Items.Add(ExitToolStripButton);

            toolStripMain.Items.Add(new ToolStripSeparator());

            toolStripMain.Items.Add(ImportDataFromAccessToolStripButton);
            toolStripMain.Items.Add(ShutDownToolStripButton);

            toolStripMain.Items.Add(new ToolStripSeparator());

            toolStripMain.Items.Add(OptionToolStripButton);
            toolStripMain.Items.Add(UserGuideToolStripButton);
        }

        /// <summary>
        ///     设定工具栏
        /// </summary>
        private void SetToolBarEnabled()
        {
            UserGuideToolStripButton.Enabled = true;
            RefreshToolStripButton.Enabled = true;
            OptionToolStripButton.Enabled = true;
            ShutDownToolStripButton.Enabled = ShutDownToolStripMenuItem.Enabled;
            if (!SystemManager.MONO_MODE)
            {
                ImportDataFromAccessToolStripButton.Enabled = ImportDataFromAccessToolStripMenuItem.Enabled;
            }
        }

        /// <summary>
        ///     禁止所有操作
        /// </summary>
        private void DisableAllOpr()
        {
            //管理-服务器
            CreateMongoDBToolStripMenuItem.Enabled = false;
            AddUserToAdminToolStripMenuItem.Enabled = false;
            ServerStatusToolStripMenuItem.Enabled = false;
            ServePropertyToolStripMenuItem.Enabled = false;
            slaveResyncToolStripMenuItem.Enabled = false;
            ShutDownToolStripMenuItem.Enabled = false;
            ShutDownToolStripButton.Enabled = false;
            InitReplsetToolStripMenuItem.Enabled = false;
            ReplicaSetToolStripMenuItem.Enabled = false;
            ShardingConfigToolStripMenuItem.Enabled = false;
            DisconnectToolStripMenuItem.Enabled = false;

            //管理-数据库
            CreateMongoCollectionToolStripMenuItem.Enabled = false;
            CopyDatabasetoolStripMenuItem.Enabled = false;
            DelMongoDBToolStripMenuItem.Enabled = false;
            UserInfoStripMenuItem.Enabled = false;
            AddUserToolStripMenuItem.Enabled = false;
            EvalJSToolStripMenuItem.Enabled = false;
            RepairDBToolStripMenuItem.Enabled = false;
            InitGFSToolStripMenuItem.Enabled = false;
            DBStatusToolStripMenuItem.Enabled = false;

            //管理-数据集
            IndexManageToolStripMenuItem.Enabled = false;
            ReIndexToolStripMenuItem.Enabled = false;
            RenameCollectionToolStripMenuItem.Enabled = false;
            DelMongoCollectionToolStripMenuItem.Enabled = false;
            CompactToolStripMenuItem.Enabled = false;
            ViewDataToolStripMenuItem.Enabled = false;
            AggregationToolStripMenuItem.Enabled = false;
            creatJavaScriptToolStripMenuItem.Enabled = false;
            dropJavascriptToolStripMenuItem.Enabled = false;
            CollectionStatusToolStripMenuItem.Enabled = false;
            ValidateToolStripMenuItem.Enabled = false;
            ExportToFileToolStripMenuItem.Enabled = false;
            ProfillingLevelToolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            DumpDatabaseToolStripMenuItem.Enabled = false;
            RestoreMongoToolStripMenuItem.Enabled = false;
            DumpCollectionToolStripMenuItem.Enabled = false;
            ImportCollectionToolStripMenuItem.Enabled = false;
            ExportCollectionToolStripMenuItem.Enabled = false;


            //工具
            if (!SystemManager.MONO_MODE)
            {
                ImportDataFromAccessToolStripMenuItem.Enabled = false;
                ImportDataFromAccessToolStripButton.Enabled = false;
            }
            
            foreach (ToolStripItem item in plugInToolStripMenuItem.DropDownItems)
            {
                if (item.Tag != null) item.Enabled = false;
            }
        }

        #endregion

        #region"View Manager"

        /// <summary>
        ///     ViewData
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
        ///     View Js
        /// </summary>
        private void ViewJavascript()
        {
            String[] DataList = SystemManager.SelectTagData.Split("/".ToCharArray());

            if (_viewTabList.ContainsKey(SystemManager.SelectTagData))
            {
                tabView.SelectTab(_viewTabList[SystemManager.SelectTagData]);
            }
            else
            {
                String JsName = DataList[(int) MongoDBHelper.PathLv.DocumentLV];
                var JsEditor = new ctlJsEditor {strDBtag = SystemManager.SelectObjectTag};
                var DataTab = new TabPage(JsName) {Tag = SystemManager.SelectObjectTag, ImageIndex = 1};

                JsEditor.JsName = JsName;
                DataTab.Controls.Add(JsEditor);
                JsEditor.Dock = DockStyle.Fill;
                tabView.Controls.Add(DataTab);

                var DataMenuItem = new ToolStripMenuItem(JsName)
                {
                    Tag = DataTab.Tag,
                    Image = GetSystemIcon.TabViewImage.Images[1]
                };
                JavaScriptStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += (x, y) => { tabView.SelectTab(DataTab); };
                _viewTabList.Add(SystemManager.SelectTagData, DataTab);
                JsEditor.CloseTab += (x, y) =>
                {
                    tabView.Controls.Remove(DataTab);
                    _viewTabList.Remove(SystemManager.SelectTagData);
                    JavaScriptStripMenuItem.DropDownItems.Remove(DataMenuItem);
                };
                tabView.SelectTab(DataTab);
            }
        }

        /// <summary>
        ///     Create a DataView Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDataRecord()
        {
            //由于Collection 和 Document 都可以触发这个事件，所以，先把Tag以前的标题头去掉
            //Collectiong:XXXX 和 Document:XXXX 都统一成 XXXX
            String DataKey = SystemManager.SelectTagData;
            if (_viewTabList.ContainsKey(DataKey))
            {
                tabView.SelectTab(_viewTabList[DataKey]);
            }
            else
            {
                var mDataViewInfo = new MongoDBHelper.DataViewInfo
                {
                    strDBTag = SystemManager.SelectObjectTag,
                    IsUseFilter = false,
                    IsReadOnly = _config.IsReadOnly,
                    mDataFilter = new DataFilter()
                };

                //mDataViewInfo.IsSafeMode = config.IsSafeMode;

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

                var DataTab = new TabPage(SystemManager.GetCurrentCollection().FullName)
                {
                    Tag = SystemManager.SelectObjectTag,
                    ToolTipText = SystemManager.SelectObjectTag
                };

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

                var DataMenuItem = new ToolStripMenuItem(SystemManager.GetCurrentCollection().Name)
                {
                    Tag = DataTab.Tag,
                    Image = GetSystemIcon.TabViewImage.Images[DataTab.ImageIndex]
                };
                collectionToolStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += (x, y) => { tabView.SelectTab(DataTab); };
                _viewTabList.Add(DataKey, DataTab);
                _viewInfoList.Add(DataKey, mDataViewInfo);
                DataViewctl.CloseTab += (x, y) =>
                {
                    tabView.Controls.Remove(DataTab);
                    _viewTabList.Remove(DataKey);
                    _viewInfoList.Remove(DataKey);
                    collectionToolStripMenuItem.DropDownItems.Remove(DataMenuItem);
                    DataTab = null;
                };
                tabView.SelectTab(DataTab);
            }
        }

        /// <summary>
        ///     Refresh View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabView.SelectedTab == null) return;
            var ctl = tabView.SelectedTab.Controls[0] as ctlDataView;
            if (ctl != null)
            {
                ctl.RefreshGUI();
            }
        }

        #endregion
    }
}