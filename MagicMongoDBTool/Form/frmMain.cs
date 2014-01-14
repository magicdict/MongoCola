using MagicMongoDBTool.Common;
using MagicMongoDBTool.Module;
using MagicMongoDBTool.UserController;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {

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
        
        #region"MainForm"
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            this.trvsrvlst.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler((x, y) => { this.ViewDataObj(); });
            this.ViewDataToolStripMenuItem.Click += new System.EventHandler((x, y) => { this.ViewDataObj(); });
            this.trvsrvlst.KeyDown += new KeyEventHandler(trvsrvlst_KeyDown);

            PlugIn.LoadPlugIn();
            foreach (var plugin in PlugIn.PlugInList)
            {
                ToolStripItem menu = new ToolStripMenuItem(plugin.Value.PlugName);
                menu.ToolTipText = plugin.Value.PlugFunction;
                menu.Tag = plugin.Key;
                menu.Click += new EventHandler(
                (x, y) =>
                    {
                        RunPlugIn(plugin.Key);
                    }
                );
                this.plugInToolStripMenuItem.DropDownItems.Add(menu);
            }

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
        /// 运行插件
        /// </summary>
        /// <param name="PlugInKeyCode"></param>
        private void RunPlugIn(string PlugInKeyCode)
        {
            System.Reflection.Assembly mAssem = Assembly.LoadFile(Application.StartupPath + @"\PlugIn\" + PlugInKeyCode + ".dll");
            String TypeName = PlugInKeyCode;
            Type mType = mAssem.GetType(TypeName + "." + TypeName);
            ConstructorInfo ConstructorInfo = mType.GetConstructor(new System.Type[] { });
            PlugBase mPlug = (PlugBase)ConstructorInfo.Invoke(new object[] { });
            switch (PlugIn.PlugInList[PlugInKeyCode].RunLv)
            {
                case MagicMongoDBTool.Common.PlugBase.PathLv.ConnectionLV:
                    mPlug.PlugObj = SystemManager.GetCurrentServer();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.InstanceLV:
                    mPlug.PlugObj = SystemManager.GetCurrentServer();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.DatabaseLV:
                    mPlug.PlugObj = SystemManager.GetCurrentDataBase();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.CollectionLV:
                    mPlug.PlugObj = SystemManager.GetCurrentCollection();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.DocumentLV:
                    break;
                default:
                    break;
            }
            mPlug.Run();
        }
        /// <summary>
        /// 切换Tab的时候，必须切换当前对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.EvalJSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
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
            this.ValidateToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Validate);
            this.ExportToFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ExportToFile);

            this.DumpAndRestoreToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
            this.RestoreMongoToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
            this.DumpCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
            this.DumpDatabaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
            this.ImportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
            this.ExportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);
            this.creatJavaScriptToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_CreateJavaScript);
            this.ViewDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_View);
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
        /// 
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
                        BsonArray roles = MongoDBHelper.GetCurrentDBRoles();
                        if (SystemManager.IsUseDefaultLanguage)
                        {
                            statusStripMain.Items[0].Text = "Selected DataBase:" + SystemManager.SelectTagData;
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_DataBase) + ":" + SystemManager.SelectTagData;
                        }
                        //系统库不允许修改
                        if (!MongoDBHelper.IsSystemDataBase(SystemManager.GetCurrentDataBase()))
                        {
                            if (config.AuthMode)
                            {
                                //根据Roles确定删除数据库/创建数据集等的权限
                                this.DelMongoDBToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles, MongoDBHelper.MongoOperate.DelMongoDB);
                                this.CreateMongoCollectionToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles, MongoDBHelper.MongoOperate.CreateMongoCollection);
                                this.InitGFSToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles, MongoDBHelper.MongoOperate.InitGFS);
                                this.AddUserToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles, MongoDBHelper.MongoOperate.AddUser);
                                ///If a Slave server can repair database @ Master-Slave is not sure ??
                                this.RepairDBToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles, MongoDBHelper.MongoOperate.RepairDB);
                            }
                            else
                            {
                                this.DelMongoDBToolStripMenuItem.Enabled = true;
                                this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                                this.InitGFSToolStripMenuItem.Enabled = true;
                                this.AddUserToolStripMenuItem.Enabled = true;
                                this.RepairDBToolStripMenuItem.Enabled = true;
                            }
                            this.EvalJSToolStripMenuItem.Enabled = MongoDBHelper.JudgeRightByRole(roles, MongoDBHelper.MongoOperate.EvalJS);
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

                                ToolStripMenuItem t4 = this.EvalJSToolStripMenuItem.Clone();
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
                                this.contextMenuStripMain.Items.Add(this.EvalJSToolStripMenuItem.Clone());
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
                        this.ViewDataToolStripMenuItem.Enabled = true;
                        this.CollectionStatusToolStripMenuItem.Enabled = true;
                        this.ValidateToolStripMenuItem.Enabled = true;
                        this.ExportToFileToolStripMenuItem.Enabled = true;
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

                                ToolStripMenuItem t8 = this.ViewDataToolStripMenuItem.Clone();
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
                                this.contextMenuStripMain.Items.Add(this.ExportToFileToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.CompactToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.ViewDataToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.AggregationToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.IndexManageToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ReIndexToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(new ToolStripSeparator());
                                this.contextMenuStripMain.Items.Add(this.CollectionStatusToolStripMenuItem.Clone());
                                this.contextMenuStripMain.Items.Add(this.ValidateToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        //PlugIn
                        foreach (ToolStripMenuItem item in plugInToolStripMenuItem.DropDownItems)
                        {
                            if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == Common.PlugBase.PathLv.CollectionLV)
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
                        this.ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = this.ViewDataToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(
                                    (x, y) => { ViewDataObj(); }
                                 );
                                this.contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.ViewDataToolStripMenuItem.Clone());
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

                        this.ViewDataToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t8 = this.ViewDataToolStripMenuItem.Clone();
                                t8.Click += new EventHandler(
                                    (x, y) => { ViewDataObj(); }
                                 );
                                this.contextMenuStripMain.Items.Add(t8);
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.ViewDataToolStripMenuItem.Clone());
                            }
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.JAVASCRIPT_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        this.ViewDataToolStripMenuItem.Enabled = true;
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
                        this.ViewDataToolStripMenuItem.Enabled = true;
                        this.dropJavascriptToolStripMenuItem.Enabled = true;

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            if (SystemManager.MONO_MODE)
                            {
                                ToolStripMenuItem t1 = this.ViewDataToolStripMenuItem.Clone();
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
                                this.contextMenuStripMain.Items.Add(this.ViewDataToolStripMenuItem.Clone());
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
            this.EvalJSToolStripMenuItem.Enabled = false;
            this.RepairDBToolStripMenuItem.Enabled = false;
            this.InitGFSToolStripMenuItem.Enabled = false;
            this.DBStatusToolStripMenuItem.Enabled = false;

            //管理-数据集
            this.IndexManageToolStripMenuItem.Enabled = false;
            this.ReIndexToolStripMenuItem.Enabled = false;
            this.RenameCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.CompactToolStripMenuItem.Enabled = false;
            this.ViewDataToolStripMenuItem.Enabled = false;
            this.AggregationToolStripMenuItem.Enabled = false;
            this.creatJavaScriptToolStripMenuItem.Enabled = false;
            this.dropJavascriptToolStripMenuItem.Enabled = false;
            this.CollectionStatusToolStripMenuItem.Enabled = false;
            this.ValidateToolStripMenuItem.Enabled = false;
            this.ExportToFileToolStripMenuItem.Enabled = false;
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
            ///
            foreach (ToolStripItem item in plugInToolStripMenuItem.DropDownItems)
            {
                if (item.Tag != null) item.Enabled = false;
            }
        }
        #endregion

        #region"View Manager"
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
        #endregion

    }
}
