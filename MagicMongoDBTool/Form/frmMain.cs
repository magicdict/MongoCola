using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MagicMongoDBTool.UserController;
using MongoDB.Driver;

namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {

        #region"Main Program"
        public frmMain()
        {
            InitializeComponent();
            GetSystemIcon.InitMainTreeImage();
            trvsrvlst.ImageList = GetSystemIcon.MainTreeImage;
            SetMenuImage();
            if (!SystemManager.IsUseDefaultLanguage())
            {
                //Set Menu Text
                SetMenuText();
            }
            //Init ToolBar
            InitToolBar();

            if (SystemManager.DEBUG_MODE)
            {
                //For test
                List<ConfigHelper.MongoConnectionConfig> connLst = new List<ConfigHelper.MongoConnectionConfig>();
                connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList["Master"]);
                MongoDBHelper.AddServer(connLst);
                RefreshToolStripMenuItem_Click(null, null);
            }
            this.Text += SystemManager.Version;
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            if (SystemManager.MONO_MODE)
            {
                this.Text += " MONO";
            }
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
            this.DataNaviToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);

            this.ConvertSqlToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_ConvertSql);
            this.AggregationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);

            //Operation
            this.OperationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation);

            this.ServerToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
            this.CreateMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
            this.AddUserToAdminToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
            this.slaveResyncToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_SlaveResync);
            this.ShutDownToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
            this.SvrPropertyToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties);

            this.DataBaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
            this.DelMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelDB);
            this.CreateMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddDC);
            this.AddUserToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            this.evalJSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
            this.RepairDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_RepairDatabase);

            this.DataCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection);
            this.DelMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
            this.RenameCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
            this.IndexManageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
            this.ReIndexToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
            this.CompactToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Compact);


            this.InitGFSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_InitGFS);

            this.DumpAndRestoreToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
            this.RestoreMongoToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
            this.DumpCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
            this.DumpDatabaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
            this.ImportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
            this.ExportCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);

            //Tool
            this.ToolsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool);
            this.DosCommandToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_DOS);
            this.ImportDataFromAccessToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Access);
            this.OptionsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Setting);


            //分布式
            this.DistributedToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed);
            this.ReplicaSetToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
            this.ShardingConfigToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ShardingConfig);

            //帮助
            this.HelpToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help);
            this.AboutToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_About);
            this.ThanksToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_Thanks);
            this.UserGuideToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Help_UserGuide);

            //其他控件
            this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            this.statusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            this.collectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName);
            this.tabSvrStatus.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
        }

        /// <summary>
        /// Current Connection Config
        /// </summary>
        ConfigHelper.MongoConnectionConfig config = new ConfigHelper.MongoConnectionConfig();
        /// <summary>
        /// 多文档视图管理
        /// </summary>
        Dictionary<String, TabPage> ViewList = new Dictionary<String, TabPage>();

        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            this.trvsrvlst.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseDoubleClick);
            this.trvsrvlst.KeyDown += new KeyEventHandler(trvsrvlst_KeyDown);
            DisableAllOpr();
            //Set Tool bar button enable 
            SetToolBarEnabled();

            //Open ConnectionManagement Form
            SystemManager.OpenForm(new frmConnect());

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
            //Load Status
            this.ServerStatusCtl.RefreshStatus(false);
            this.ServerStatusCtl.RefreshCurrentOpr();

            RefreshToolStripMenuItem_Click(sender, e);
            MongoDBHelper.RunCommandComplete += new EventHandler<RunCommandEventArgs>(CommandLog);

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

            String strNodeType = String.Empty;
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
                strNodeType = e.Node.Tag.ToString().Split(":".ToCharArray())[0];
                String mongoSvrKey = e.Node.Tag.ToString().Split(":".ToCharArray())[1].Split("/".ToCharArray())[0];
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
                switch (strNodeType)
                {
                    case MongoDBHelper.SERVICE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected Server:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Server) +
                                  ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        this.DisconnectToolStripMenuItem.Enabled = true;
                        //解禁 创建数据库,关闭服务器
                        if (!config.IsReadOnly)
                        {
                            this.CreateMongoDBToolStripMenuItem.Enabled = true;
#if !MONO
                            this.ImportDataFromAccessToolStripMenuItem.Enabled = true;
#endif
                            this.AddUserToAdminToolStripMenuItem.Enabled = true;
                            if (!(SystemManager.GetCurrentService().Instance.IsPrimary))
                            {
                                this.slaveResyncToolStripMenuItem.Enabled = true;
                            }
                        }

                        this.ShutDownToolStripMenuItem.Enabled = true;
                        this.ShutDownToolStripButton.Enabled = true;

                        this.SvrPropertyToolStripMenuItem.Enabled = true;

                        if (SystemManager.GetSelectedSvrProByName().ServerRole == ConfigHelper.SvrRoleType.ReplsetSvr)
                        {
                            //副本服务器专用。
                            //副本初始化的操作 改在连接设置里面完成
                            if (!config.IsReadOnly)
                            {
                                this.ReplicaSetToolStripMenuItem.Enabled = true;
                            }
                        }
                        if (SystemManager.GetSelectedSvrProByName().ServerRole == ConfigHelper.SvrRoleType.RouteSvr)
                        {
                            //Route用
                            if (!config.IsReadOnly)
                            {
                                this.ShardingConfigToolStripMenuItem.Enabled = true;
                            }
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
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

                            ToolStripMenuItem t4 = this.ReplicaSetToolStripMenuItem.Clone();
                            t4.Click += new EventHandler(ReplicaSetToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t4);

                            ToolStripMenuItem t5 = this.ShardingConfigToolStripMenuItem.Clone();
                            t5.Click += new EventHandler(ShardingConfigToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t5);

                            ToolStripMenuItem t51 = this.slaveResyncToolStripMenuItem.Clone();
                            t51.Click += new EventHandler(slaveResyncToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t51);

                            ToolStripMenuItem t6 = this.DisconnectToolStripMenuItem.Clone();
                            t6.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t6);

                            ToolStripMenuItem t7 = this.ShutDownToolStripMenuItem.Clone();
                            t7.Click += new EventHandler(ShutDownToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t7);

                            ToolStripMenuItem t8 = this.SvrPropertyToolStripMenuItem.Clone();
                            t8.Click += new EventHandler(SvrPropertyToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t8);

#else
                            this.contextMenuStripMain.Items.Add(this.CreateMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToAdminToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportDataFromAccessToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ReplicaSetToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShardingConfigToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.slaveResyncToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DisconnectToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShutDownToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.SvrPropertyToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.SINGLE_DB_SERVICE_TAG:
                        //单数据库模式,禁止所有服务器操作
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        this.DisconnectToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
                            //悲催MONO不支持
                            ToolStripMenuItem t1 = this.DisconnectToolStripMenuItem.Clone();
                            t1.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t1);
                            ToolStripMenuItem t8 = this.SvrPropertyToolStripMenuItem.Clone();
                            t8.Click += new EventHandler(SvrPropertyToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t8);
#else
                            this.contextMenuStripMain.Items.Add(this.DisconnectToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.SvrPropertyToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected Server[Single Database]:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelper.SERVICE_TAG_EXCEPTION:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        this.DisconnectToolStripMenuItem.Enabled = true;
                        this.RestoreMongoToolStripMenuItem.Enabled = false;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
                            //悲催MONO不支持
                            ToolStripMenuItem t1 = this.DisconnectToolStripMenuItem.Clone();
                            t1.Click += new EventHandler(DisconnectToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t1);
#else
                            this.contextMenuStripMain.Items.Add(this.DisconnectToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        statusStripMain.Items[0].Text = "Selected Server[Exception]:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelper.DATABASE_TAG:
                    case MongoDBHelper.SINGLE_DATABASE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected DataBase:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_DataBase) +
                                  ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        //解禁 删除数据库 创建数据集
                        if (!MongoDBHelper.IsSystemDataBase(SystemManager.GetCurrentDataBase()))
                        {
                            if (!config.IsReadOnly)
                            {
                                //系统库不允许修改
                                this.DelMongoDBToolStripMenuItem.Enabled = true;
                                this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                                this.AddUserToolStripMenuItem.Enabled = true;
                                this.InitGFSToolStripMenuItem.Enabled = true;
                                //if (config.ServerRole == ConfigHelper.SvrRoleType.SlaveSvr)
                                //{
                                ///Slave server @ Master-Slave
                                this.RepairDBToolStripMenuItem.Enabled = true;
                                //}
                            }
                            this.evalJSToolStripMenuItem.Enabled = true;
                            this.ConvertSqlToolStripMenuItem.Enabled = true;
                        }
                        //备份数据库
                        this.DumpDatabaseToolStripMenuItem.Enabled = true;

                        if (strNodeType == MongoDBHelper.SINGLE_DATABASE_TAG)
                        {
                            this.DelMongoDBToolStripMenuItem.Enabled = false;
                        }

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();

#if MONO
                            //悲催MONO不支持
                            ToolStripMenuItem t0 = this.DelMongoDBToolStripMenuItem.Clone();
                            t0.Click += new EventHandler(DelMongoDBToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t0);

                            ToolStripMenuItem t1 = this.CreateMongoCollectionToolStripMenuItem.Clone();
                            t1.Click += new EventHandler(CreateMongoCollectionToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t1);

                            ToolStripMenuItem t2 = this.AddUserToolStripMenuItem.Clone();
                            t2.Click += new EventHandler(AddUserToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t2);

                            ToolStripMenuItem t3 = this.evalJSToolStripMenuItem.Clone();
                            t3.Click += new EventHandler(evalJSToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t3);

                            ToolStripMenuItem t31 = this.RepairDBToolStripMenuItem.Clone();
                            t31.Click += new EventHandler(RepairDBToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t31);
                            

                            ToolStripMenuItem t4 = this.InitGFSToolStripMenuItem.Clone();
                            t4.Click += new EventHandler(InitGFSToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t4);

                            ToolStripMenuItem t5 = this.DumpDatabaseToolStripMenuItem.Clone();
                            t5.Click += new EventHandler(DumpDatabaseToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t5);

                            ToolStripMenuItem t6 = this.RestoreMongoToolStripMenuItem.Clone();
                            t6.Click += new EventHandler(RestoreMongoToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t6);

                            ToolStripMenuItem t7 = this.ConvertSqlToolStripMenuItem.Clone();
                            t7.Click += new EventHandler(ConvertSqlToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t7);

#else

                            this.contextMenuStripMain.Items.Add(this.DelMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.CreateMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.evalJSToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RepairDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.InitGFSToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpDatabaseToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ConvertSqlToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.COLLECTION_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected Collection:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Collection) +
                                  ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
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

                        this.DumpCollectionToolStripMenuItem.Enabled = true;
                        this.ExportCollectionToolStripMenuItem.Enabled = true;

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
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

#else

                            this.contextMenuStripMain.Items.Add(this.DelMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RenameCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ExportCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.CompactToolStripMenuItem.Clone());
#endif
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.DOCUMENT_TAG:
                    case MongoDBHelper.USER_LIST_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();

                        this.viewDataToolStripMenuItem.Enabled = true;

                        if (strNodeType == MongoDBHelper.USER_LIST_TAG)
                        {
                            if (SystemManager.IsUseDefaultLanguage())
                            {
                                statusStripMain.Items[0].Text = "Selected UserList:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                            }
                            else
                            {
                                statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_UserList) +
                                     ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                            }
                        }
                        else
                        {
                            if (SystemManager.IsUseDefaultLanguage())
                            {
                                statusStripMain.Items[0].Text = "Selected Document:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                            }
                            else
                            {
                                statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Data) +
                                    ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                            }
                        }

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {

                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
                            //悲催MONO不支持
                            ToolStripMenuItem t1 = this.countToolStripMenuItem.Clone();
                            t1.Click += new EventHandler(countToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t1);

                            ToolStripMenuItem t2 = this.distinctToolStripMenuItem.Clone();
                            t2.Click += new EventHandler(distinctToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t2);

                            ToolStripMenuItem t3 = this.groupToolStripMenuItem.Clone();
                            t3.Click += new EventHandler(groupToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t3);

                            ToolStripMenuItem t4 = this.mapReduceToolStripMenuItem.Clone();
                            t4.Click += new EventHandler(mapReduceToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t4);

                            ToolStripMenuItem t5 = this.QueryDataToolStripMenuItem.Clone();
                            t5.Click += new EventHandler(QueryDataToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t5);

                            ToolStripMenuItem t6 = this.AddDocumentToolStripMenuItem.Clone();
                            t6.Click += new EventHandler(AddDocumentToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t6);

#else
                            this.contextMenuStripMain.Items.Add(this.countToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.distinctToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.groupToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.mapReduceToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.viewDataToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.INDEX_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Index) +
                                ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        break;
                    case MongoDBHelper.INDEXES_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected Index:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Indexes) +
                                ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) & !config.IsReadOnly)
                        {
                            this.IndexManageToolStripMenuItem.Enabled = true;
                            this.ReIndexToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
                            //悲催MONO不支持
                            ToolStripMenuItem t1 = this.IndexManageToolStripMenuItem.Clone();
                            t1.Click += new EventHandler(IndexManageToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t1);

                            ToolStripMenuItem t2 = this.ReIndexToolStripMenuItem.Clone();
                            t2.Click += new EventHandler(ReIndexToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t2);
#else
                            this.contextMenuStripMain.Items.Add(this.IndexManageToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ReIndexToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.GRID_FILE_SYSTEM_TAG:
                        //GridFileSystem
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected GFS:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_GFS) +
                                ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        SystemManager.CurrDataFilter.Clear();
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.GRID_JAVASCRIPT_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "Selected JavaScript:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    default:
                        SystemManager.SelectObjectTag = "";
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
        /// 双击打开数据视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvsrvlst_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String strNodeType = String.Empty;
            String strNodeData = String.Empty;
            if (e.Node.Tag != null)
            {
                strNodeType = e.Node.Tag.ToString().Split(":".ToCharArray())[0];
                strNodeData = e.Node.Tag.ToString().Split(":".ToCharArray())[1];

                switch (strNodeType)
                {
                    case MongoDBHelper.USER_LIST_TAG:
                        MongoDBHelper.InitDBUser();
                        viewDataToolStripMenuItem_Click(sender, e);
                        break;
                    case MongoDBHelper.GRID_FILE_SYSTEM_TAG:
                        MongoDBHelper.InitGFS();
                        viewDataToolStripMenuItem_Click(sender, e);
                        break;
                    case MongoDBHelper.GRID_JAVASCRIPT_TAG:
                        MongoDBHelper.InitJavascript();
                        String[] DataList = strNodeData.Split("/".ToCharArray());
                        if (DataList.Length == 4)
                        {
                            if (ViewList.ContainsKey(strNodeData))
                            {
                                tabView.SelectTab(ViewList[strNodeData]);
                            }
                            else
                            {
                                ctlJsEditor JsEditor = new ctlJsEditor();
                                TabPage DataTab = new TabPage(DataList[3]);
                                JsEditor.JsName = DataList[3];
                                DataTab.Controls.Add(JsEditor);
                                JsEditor.Dock = DockStyle.Fill;
                                tabView.Controls.Add(DataTab);

                                ToolStripMenuItem DataMenuItem = new ToolStripMenuItem(DataList[3]);
                                JavaScriptStripMenuItem.DropDownItems.Add(DataMenuItem);
                                DataMenuItem.Click += new EventHandler(
                                     (x, y) => { tabView.SelectTab(DataTab); }
                                );
                                ViewList.Add(strNodeData, DataTab);
                                JsEditor.CloseTab += new System.EventHandler(
                                    (x, y) =>
                                    {
                                        tabView.Controls.Remove(DataTab);
                                        ViewList.Remove(strNodeData);
                                        JavaScriptStripMenuItem.DropDownItems.Remove(DataMenuItem);
                                    }
                                );
                                tabView.SelectTab(DataTab);
                            }
                        }
                        break;
                    case MongoDBHelper.COLLECTION_TAG:
                    case MongoDBHelper.DOCUMENT_TAG:
                        viewDataToolStripMenuItem_Click(sender, e);
                        break;
                    default:
                        break;
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
            this.SvrPropertyToolStripMenuItem.Enabled = false;
            this.slaveResyncToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripButton.Enabled = false;

            this.DisconnectToolStripMenuItem.Enabled = false;

            //管理-数据库
            this.CreateMongoCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoDBToolStripMenuItem.Enabled = false;
            this.AddUserToolStripMenuItem.Enabled = false;
            this.evalJSToolStripMenuItem.Enabled = false;
            this.RepairDBToolStripMenuItem.Enabled = false;
            this.InitGFSToolStripMenuItem.Enabled = false;

            //管理-数据集
            this.IndexManageToolStripMenuItem.Enabled = false;
            this.ReIndexToolStripMenuItem.Enabled = false;
            this.RenameCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.CompactToolStripMenuItem.Enabled = false;
            this.viewDataToolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            this.DumpDatabaseToolStripMenuItem.Enabled = false;
            this.RestoreMongoToolStripMenuItem.Enabled = false;
            this.DumpCollectionToolStripMenuItem.Enabled = false;
            this.ImportCollectionToolStripMenuItem.Enabled = false;
            this.ExportCollectionToolStripMenuItem.Enabled = false;

            this.ConvertSqlToolStripMenuItem.Enabled = false;
            this.AggregationToolStripMenuItem.Enabled = false;


            //工具
#if !MONO
            this.ImportDataFromAccessToolStripMenuItem.Enabled = false;
            this.ImportDataFromAccessToolStripButton.Enabled = false;
#endif
            //分布式
            this.ReplicaSetToolStripMenuItem.Enabled = false;
            this.ShardingConfigToolStripMenuItem.Enabled = false;
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
            SystemManager.OpenForm(new frmConnect());
            RefreshToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// Disconnect 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.GetCurrentService().Disconnect();
            MongoDBHelper._mongoSrvLst.Remove(config.ConnectionName);
            trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
            RefreshToolStripMenuItem_Click(sender, e);
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            }
            else
            {
                this.statusStripMain.Items[0].Text = "Ready";
            }
        }
        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ServerStatusCtl.RefreshStatus(false);
            this.ServerStatusCtl.RefreshCurrentOpr();

            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.collectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName); ;
            }
            else
            {
                this.collectionToolStripMenuItem.Text = "Collection";
            }
            DisableAllOpr();
            MongoDBHelper.FillMongoServerToTreeView(trvsrvlst);
        }
        /// <summary>
        /// Expand All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.ExpandAll();
        }
        /// <summary>
        /// Collapse All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.CollapseAll();
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

        #region"工具"
        /// <summary>
        /// Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmOption());
            SystemManager.InitLanguage();
            if (SystemManager.IsUseDefaultLanguage())
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
#if !MONO
            //MONO not support this function
            OpenFileDialog AccessFile = new OpenFileDialog();
            AccessFile.Filter = MongoDBHelper.MdbFilter;
            if (AccessFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.ImportAccessDataBase(AccessFile.FileName, SystemManager.SelectObjectTag, trvsrvlst.SelectedNode);
            }
#endif
        }
        /// <summary>
        /// DOS控制台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmDosCommand());
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
            if (SystemManager.IsUseDefaultLanguage())
            {
                strDBName = MyMessageBox.ShowInput("Please Input DataBaseName：", "Create Database");
            }
            else
            {
                strDBName = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_DataBase_Input),
                                                                       SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_DataBase));
            }
            if (strDBName != String.Empty)
            {
                if (MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Create, trvsrvlst.SelectedNode))
                {
                    DisableAllOpr();
                }
            }
        }
        /// <summary>
        /// Create User to Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUser(true));
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
        /// Server Property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.IsUseDefaultLanguage())
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
        /// Shut Down Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.ShowConfirm("ShutDown Server", "Are you sure to shutDown the Server?"))
            {
                MongoServer mongoSvr = SystemManager.GetCurrentService();
                try
                {
                    //the server will be  shutdown with exception
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
            }
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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_DataBase);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_DataBase_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                String strDBName = strPath.Split("/".ToCharArray())[1];
                if (trvsrvlst.SelectedNode == null)
                {
                    trvsrvlst.SelectedNode = null;
                }
                if (MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Drop, trvsrvlst.SelectedNode))
                {
                    DisableAllOpr();
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
            SystemManager.OpenForm(frm);
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
            SystemManager.OpenForm(new frmUser(false));
        }
        /// <summary>
        /// Eval JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmevalJS());
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
            MongoDBHelper.FillMongoServerToTreeView(trvsrvlst);
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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Collection);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Collection_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                String strCollection = strPath.Split("/".ToCharArray())[2];
                if (trvsrvlst.SelectedNode == null)
                {
                    trvsrvlst.SelectedNode = null;
                }
                if (MongoDBHelper.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelper.Oprcode.Drop, trvsrvlst.SelectedNode))
                {
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
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strCollection = strPath.Split("/".ToCharArray())[2];
            String strNewCollectionName = String.Empty;
            if (SystemManager.IsUseDefaultLanguage())
            {
                strNewCollectionName = MyMessageBox.ShowInput("Please input new collection name：", "Rename collection");
            }
            else
            {
                strNewCollectionName = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Rename_Collection_Input),
                                                                                  SystemManager.mStringResource.GetText(StringResource.TextType.Rename_Collection));
            }
            if (String.IsNullOrEmpty(strNewCollectionName))
            {
                return;
            }
            if (MongoDBHelper.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelper.Oprcode.Rename, trvsrvlst.SelectedNode, strNewCollectionName))
            {
                DisableAllOpr();
                SystemManager.SelectObjectTag = trvsrvlst.SelectedNode.Tag.ToString();
                if (SystemManager.IsUseDefaultLanguage())
                {
                    statusStripMain.Items[0].Text = "selected Collection:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                }
                else
                {
                    statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Collection) +
                          ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
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
            SystemManager.OpenForm(new frmCollectionIndex());
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
        /// Create a DataView Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //由于Collection 和 Document 都可以触发这个事件，所以，先把Tag以前的标题头去掉
            //Collectiong:XXXX 和 Document:XXXX 都统一成 XXXX
            String DataType = SystemManager.SelectObjectTag.Split(":".ToCharArray())[0];
            String DataKey = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            if (ViewList.ContainsKey(DataKey))
            {
                tabView.SelectTab(ViewList[DataKey]);
            }
            else
            {
                SystemManager.CurrDataFilter.Clear();
                ctlDataView DataViewctl = new ctlDataView();
                DataViewctl.config = this.config;
                MongoDBHelper.DataViewInfo mDataViewInfo = new MongoDBHelper.DataViewInfo();
                mDataViewInfo.strDBTag = SystemManager.SelectObjectTag;
                mDataViewInfo.IsUseFilter = false;
                DataViewctl.mDataViewInfo = mDataViewInfo;
                DataViewctl.DisableDataTreeOpr();

                TabPage DataTab = new TabPage(SystemManager.GetCurrentCollection().Name);
                DataTab.Controls.Add(DataViewctl);
                DataViewctl.Dock = DockStyle.Fill;
                tabView.Controls.Add(DataTab);

                ToolStripMenuItem DataMenuItem = new ToolStripMenuItem(SystemManager.GetCurrentCollection().Name);
                collectionToolStripMenuItem.DropDownItems.Add(DataMenuItem);
                DataMenuItem.Click += new EventHandler(
                     (x, y) => { tabView.SelectTab(DataTab); }
                );
                ViewList.Add(DataKey, DataTab);
                DataViewctl.CloseTab += new System.EventHandler(
                    (x, y) =>
                    {
                        tabView.Controls.Remove(DataTab);
                        ViewList.Remove(DataKey);
                        collectionToolStripMenuItem.DropDownItems.Remove(DataMenuItem);
                    }
                );
                tabView.SelectTab(DataTab);
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
                SystemManager.OpenForm(new frmOption());
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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruMongoRestore MongoRestore = new MongodbDosCommand.StruMongoRestore();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
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
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
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
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
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
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
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

        #region"分布式"
        /// <summary>
        /// 副本管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmReplset());
        }
        /// <summary>
        /// 分片管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShardingConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmShardingConfig());
        }

        #endregion

        #region"聚合"
        /// <summary>
        /// 转换Sql到Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmConvertSql());
        }
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.CurrDataFilter.QueryConditionList.Count == 0)
            {
                MyMessageBox.ShowMessage("Count", "Count:" + SystemManager.GetCurrentCollection().Count().ToString());
            }
            else
            {
                MongoDB.Driver.IMongoQuery mQuery = MongoDBHelper.GetQuery(SystemManager.CurrDataFilter.QueryConditionList);
                MyMessageBox.ShowMessage("Count",
                "Count:" + SystemManager.GetCurrentCollection().Count(mQuery).ToString(),
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
            SystemManager.OpenForm(new frmDistinct());
        }
        /// <summary>
        /// Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmGroup());
        }
        /// <summary>
        /// MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmMapReduce());
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
                                     "GitHub： https://github.com/magicdict/MagicMongoDBTool");
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
            String strUrl = @"UserGuide\index.htm";
            System.Diagnostics.Process.Start(strUrl);
        }
        #endregion

    }
}
