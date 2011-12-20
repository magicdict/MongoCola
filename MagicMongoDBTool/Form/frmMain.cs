using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Text;
using MongoDB.Bson;
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
            //Set Tool bar button enable 
            SetToolBarEnabled();
            if (SystemManager.DEBUG_MODE)
            {
                //For test
                List<ConfigHelper.MongoConnectionConfig> connLst = new List<ConfigHelper.MongoConnectionConfig>();
                connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList["Master"]);
                MongoDBHelper.AddServer(connLst);
                RefreshToolStripMenuItem_Click(null, null);
            }
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
            this.SrvStatusToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            this.ExpandAllConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Expansion);
            this.CollapseAllConnectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collapse);
            this.ExitToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Exit);

            //数据视图
            this.DataNaviToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            this.PrePageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Previous);
            this.NextPageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Next);
            this.FirstPageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_First);
            this.LastPageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Last);

            this.QueryDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Query);
            this.ConvertSqlToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_ConvertSql);
            this.AggregationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);
            this.DataFilterToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_DataFilter);

            this.CollapseAllDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collapse);
            this.ExpandAllDataToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Expansion);


            //Operation
            this.OperationToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation);

            this.ServerToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
            this.CreateMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
            this.AddUserToAdminToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
            this.RemoveUserFromAdminToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_DelFromAdmin);
            this.slaveResyncToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_SlaveResync);
            this.ShutDownToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
            this.SvrPropertyToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties);

            this.DataBaseToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
            this.DelMongoDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelDB);
            this.CreateMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddDC);
            this.AddUserToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            this.RemoveUserToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelUser);
            this.evalJSToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
            this.RepairDBToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_RepairDatabase);

            this.DataCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection);
            this.DelMongoCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
            this.RenameCollectionToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
            this.IndexManageToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
            this.ReIndexToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
            this.DelSelectRecordToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DropDocument);
            this.AddDocumentToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_AddDocument);

            this.DataDocumentToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument);
            this.AddElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_AddElement);
            this.DropElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_DropElement);
            this.ModifyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_ModifyElement);
            this.CopyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CopyElement);
            this.CutElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CutElement);
            this.PasteElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_PasteElement);

            this.GridFsToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem);
            this.DelFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_DelFile);
            this.UploadFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Upload);
            this.DownloadFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_Download);
            this.OpenFileToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_OpenFile);
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

            //就绪
            this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            //数据显示区
            this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
            this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
            this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);
        }

        /// <summary>
        /// Control for show Data
        /// </summary>
        private List<Control> _dataShower = new List<Control>();
        /// <summary>
        /// Current Connection Config
        /// </summary>
        ConfigHelper.MongoConnectionConfig config = new ConfigHelper.MongoConnectionConfig();

        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {

            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            this.trvsrvlst.KeyDown += new KeyEventHandler(trvsrvlst_KeyDown);
            this.lstData.MouseClick += new MouseEventHandler(lstData_MouseClick);
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new EventHandler(lstData_SelectedIndexChanged);
            this.trvData.MouseClick += new MouseEventHandler(trvData_MouseClick_Top);
            this.trvData.AfterSelect += new TreeViewEventHandler(trvData_AfterSelect_Top);
            this.trvData.KeyDown += new KeyEventHandler(trvData_KeyDown);
            this.tabDataShower.SelectedIndexChanged += new EventHandler(
                //If tabpage changed,the selected data in dataview will disappear,set delete selected record to false
                    (x, y) =>
                    {
                        this.DelSelectRecordToolStripMenuItem.Enabled = false;
                        if (IsNeedRefresh)
                        {
                            RefreshData();
                        }
                    }
                );
            DisableAllOpr();
            DisableDataTreeOpr();
            _dataShower.Add(lstData);
            _dataShower.Add(trvData);
            _dataShower.Add(txtData);
            DataNaviToolStripLabel.Text = String.Empty;
            //Open ConnectionManagement Form
            SystemManager.OpenForm(new frmConnect());
            RefreshToolStripMenuItem_Click(sender, e);
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
            if (this.trvData.SelectedNode != null)
            {
                this.trvData.SelectedNode.ContextMenuStrip = null;
            }
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
                if (!(strNodeType == MongoDBHelper.DOCUMENT_TAG && e.Button == System.Windows.Forms.MouseButtons.Right))
                {
                    clearDataShower();
                }
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
                        this.SvrPropertyToolStripMenuItem.Enabled = true;

                        if (SystemManager.GetSelectedSvrProByName().ServerType == ConfigHelper.SvrType.ReplsetSvr)
                        {
                            //副本服务器专用。
                            //副本初始化的操作 改在连接设置里面完成
                            if (!config.IsReadOnly)
                            {
                                this.ReplicaSetToolStripMenuItem.Enabled = true;
                            }
                        }
                        if (SystemManager.GetSelectedSvrProByName().ServerType == ConfigHelper.SvrType.RouteSvr)
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
                                this.RepairDBToolStripMenuItem.Enabled = true;
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

#else

                            this.contextMenuStripMain.Items.Add(this.DelMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RenameCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RestoreMongoToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ExportCollectionToolStripMenuItem.Clone());
#endif
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.DOCUMENT_TAG:
                        //BsonDocument
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected Document:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Data) +
                                ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        if (!config.IsReadOnly & !MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            this.AddDocumentToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            SetDataNav();
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
                            this.contextMenuStripMain.Items.Add(this.QueryDataToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddDocumentToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            MongoDBHelper.IsUseFilter = false;
                            this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
                            SystemManager.CurrDataFilter.Clear();
                            RefreshData();
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
                        MongoDBHelper.IsUseFilter = false;
                        this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
                        SystemManager.CurrDataFilter.Clear();
                        RefreshData();
                        if (!config.IsReadOnly)
                        {
                            UploadFileToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
#if MONO
                            //悲催MONO不支持
                            ToolStripMenuItem t1 = this.UploadFileToolStripMenuItem.Clone();
                            t1.Click += new EventHandler(UploadFileToolStripMenuItem_Click);
                            this.contextMenuStripMain.Items.Add(t1);
#else
                            this.contextMenuStripMain.Items.Add(this.UploadFileToolStripMenuItem.Clone());
#endif
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                        }
                        break;
                    case MongoDBHelper.USER_LIST_TAG:
                        //BsonDocument
                        MongoDBHelper.FillDataToControl(e.Node.Tag.ToString(), _dataShower);
                        SetDataNav();
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        if (SystemManager.IsUseDefaultLanguage())
                        {
                            statusStripMain.Items[0].Text = "Selected UserList:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
                        else
                        {
                            statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_UserList) +
                                 ":" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        }
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
            if (strNodeType != MongoDBHelper.DOCUMENT_TAG)
            {
                DataNaviToolStripLabel.Text = String.Empty;
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
            this.RemoveUserFromAdminToolStripMenuItem.Enabled = false;
            this.SvrPropertyToolStripMenuItem.Enabled = false;
            this.slaveResyncToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripMenuItem.Enabled = false;
            this.DisconnectToolStripMenuItem.Enabled = false;

            //管理-数据库
            this.CreateMongoCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoDBToolStripMenuItem.Enabled = false;
            this.AddUserToolStripMenuItem.Enabled = false;
            this.RemoveUserToolStripMenuItem.Enabled = false;
            this.evalJSToolStripMenuItem.Enabled = false;
            this.RepairDBToolStripMenuItem.Enabled = false;

            //管理-数据集
            this.IndexManageToolStripMenuItem.Enabled = false;
            this.ReIndexToolStripMenuItem.Enabled = false;
            this.RenameCollectionToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.AddDocumentToolStripMenuItem.Enabled = false;
            this.DelSelectRecordToolStripMenuItem.Enabled = false;

            //管理-GFS
            this.UploadFileToolStripMenuItem.Enabled = false;
            this.DownloadFileToolStripMenuItem.Enabled = false;
            this.OpenFileToolStripMenuItem.Enabled = false;
            this.DelFileToolStripMenuItem.Enabled = false;
            this.InitGFSToolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            this.DumpDatabaseToolStripMenuItem.Enabled = false;
            this.RestoreMongoToolStripMenuItem.Enabled = false;
            this.DumpCollectionToolStripMenuItem.Enabled = false;
            this.ImportCollectionToolStripMenuItem.Enabled = false;
            this.ExportCollectionToolStripMenuItem.Enabled = false;

            //数据导航
            this.FirstPageToolStripMenuItem.Enabled = false;
            this.FirstPageToolStripButton.Enabled = false;
            this.LastPageToolStripMenuItem.Enabled = false;
            this.LastPageToolStripButton.Enabled = false;
            this.NextPageToolStripMenuItem.Enabled = false;
            this.NextPageToolStripButton.Enabled = false;
            this.PrePageToolStripMenuItem.Enabled = false;
            this.PrePageToolStripButton.Enabled = false;
            this.QueryDataToolStripMenuItem.Enabled = false;
            this.QueryDataToolStripButton.Enabled = false;
            this.ConvertSqlToolStripMenuItem.Enabled = false;


            this.ExpandAllDataToolStripMenuItem.Enabled = false;
            this.CollapseAllDataToolStripMenuItem.Enabled = false;
            this.DataFilterToolStripMenuItem.Enabled = false;
            this.DataFilterToolStripMenuItem.Checked = false;
            this.DataFilterToolStripButton.Enabled = false;
            this.DataFilterToolStripButton.Checked = false;
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

        #region"数据展示区操作"
        /// <summary>
        /// 数据列表选中索引变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SystemManager.GetCurrentCollection().Name)
            {
                case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                    //文件系统
                    UploadFileToolStripMenuItem.Enabled = true;
                    switch (lstData.SelectedItems.Count)
                    {
                        case 0:
                            //禁止所有操作
                            DownloadFileToolStripMenuItem.Enabled = false;
                            OpenFileToolStripMenuItem.Enabled = false;
                            DelFileToolStripMenuItem.Enabled = false;
                            lstData.ContextMenuStrip = null;
                            break;
                        case 1:
                            //可以进行所有操作
                            if (!config.IsReadOnly)
                            {
                                DelFileToolStripMenuItem.Enabled = true;
                            }
                            DownloadFileToolStripMenuItem.Enabled = true;
                            OpenFileToolStripMenuItem.Enabled = true;
                            break;
                        default:
                            //可以删除多个文件
                            DownloadFileToolStripMenuItem.Enabled = false;
                            OpenFileToolStripMenuItem.Enabled = false;
                            if (!config.IsReadOnly)
                            {
                                DelFileToolStripMenuItem.Enabled = true;
                            }
                            break;
                    }
                    break;
                case MongoDBHelper.COLLECTION_NAME_USER:
                    //用户数据库
                    if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                    {
                        if (lstData.SelectedItems.Count > 0)
                        {
                            if (!config.IsReadOnly)
                            {
                                this.RemoveUserFromAdminToolStripMenuItem.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (lstData.SelectedItems.Count > 0)
                        {
                            if (!config.IsReadOnly)
                            {
                                this.RemoveUserToolStripMenuItem.Enabled = true;
                            }
                        }
                    }
                    break;
                default:
                    //数据系统
                    DelSelectRecordToolStripMenuItem.Enabled = false;
                    if (lstData.SelectedItems.Count > 0)
                    {
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            //系统数据禁止删除
                            if (!config.IsReadOnly)
                            {
                                DelSelectRecordToolStripMenuItem.Enabled = true;
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SystemManager.GetCurrentCollection().Name == MongoDBHelper.COLLECTION_NAME_GFS_FILES)
            {
                String strFileName = lstData.SelectedItems[0].Text;
                MongoDBHelper.OpenFile(strFileName);
            }
        }
        /// <summary>
        /// 数据列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();

                    switch (SystemManager.GetCurrentCollection().Name)
                    {
                        case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                            //Grid File System
                            this.contextMenuStripMain.Items.Add(this.DownloadFileToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.OpenFileToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DelFileToolStripMenuItem.Clone());
                            break;
                        case MongoDBHelper.COLLECTION_NAME_USER:
                            if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserFromAdminToolStripMenuItem.Clone());
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            }
                            break;
                        default:
                            this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                            break;
                    }
                    lstData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                }
            }
        }

        /// <summary>
        /// 数据树菜单的禁止
        /// </summary>
        private void DisableDataTreeOpr()
        {
            RemoveUserFromAdminToolStripMenuItem.Enabled = false;
            RemoveUserToolStripMenuItem.Enabled = false;
            DelSelectRecordToolStripMenuItem.Enabled = false;
            DelFileToolStripMenuItem.Enabled = false;
            AddElementToolStripMenuItem.Enabled = false;
            DropElementToolStripMenuItem.Enabled = false;
            ModifyElementToolStripMenuItem.Enabled = false;
            CopyElementToolStripMenuItem.Enabled = false;
            CutElementToolStripMenuItem.Enabled = false;
            PasteElementToolStripMenuItem.Enabled = false;
        }
        /// <summary>
        /// 数据树形被选择后(TOP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect_Top(object sender, TreeViewEventArgs e)
        {
            DisableDataTreeOpr();
            SystemManager.SelectDocId = (BsonValue)trvData.SelectedNode.Tag;
            if (trvData.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                if (!config.IsReadOnly)
                {
                    switch (SystemManager.GetCurrentCollection().Name)
                    {
                        case MongoDBHelper.COLLECTION_NAME_GFS_FILES:

                            DelFileToolStripMenuItem.Enabled = true;
                            break;
                        case MongoDBHelper.COLLECTION_NAME_USER:

                            if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                            {
                                RemoveUserFromAdminToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                RemoveUserToolStripMenuItem.Enabled = true;
                            }
                            break;
                        default:
                            if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                            {
                                //普通数据
                                //在顶层的时候，允许添加元素,不允许删除元素和修改元素(删除选中记录)

                                DelSelectRecordToolStripMenuItem.Enabled = true;
                                AddElementToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                DelSelectRecordToolStripMenuItem.Enabled = false;
                            }
                            break;
                    }
                }
            }
            else
            {
                //非顶层元素
                trvData_AfterSelect_NotTop(sender, e);
            }
        }
        /// <summary>
        /// 数据树形被选择后(非TOP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect_NotTop(object sender, TreeViewEventArgs e)
        {
            //非顶层可以删除的节点
            switch (SystemManager.GetCurrentCollection().Name)
            {
                case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                case MongoDBHelper.COLLECTION_NAME_USER:
                default:
                    if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) & !config.IsReadOnly)
                    {
                        //普通数据:允许添加元素,不允许删除元素
                        DropElementToolStripMenuItem.Enabled = true;
                        CopyElementToolStripMenuItem.Enabled = true;
                        CutElementToolStripMenuItem.Enabled = true;
                        if (trvData.SelectedNode.Nodes.Count == 0)
                        {
                            //如果已经是叶子的话允许修改元素
                            ModifyElementToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            //如果已经是非叶子的话允许添加元素
                            if (!trvData.SelectedNode.FullPath.EndsWith(MongoDBHelper.Array_Mark))
                            {
                                //改节点不是数组
                                AddElementToolStripMenuItem.Enabled = true;
                                if (MongoDBHelper.CanPaste)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                }
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// 鼠标动作（顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_Top(object sender, MouseEventArgs e)
        {
            TreeNode node = this.trvData.GetNodeAt(e.Location);
            trvData.SelectedNode = node;
            if (trvData.SelectedNode == null)
            {
                return;
            }
            if (trvData.SelectedNode.Level == 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();

                    //顶层可以删除的节点
                    switch (SystemManager.GetCurrentCollection().Name)
                    {
                        case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                            this.contextMenuStripMain.Items.Add(this.DelFileToolStripMenuItem.Clone());
                            break;
                        case MongoDBHelper.COLLECTION_NAME_USER:
                            if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserFromAdminToolStripMenuItem.Clone());
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            }
                            break;
                        default:
                            this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddElementToolStripMenuItem.Clone());
                            break;
                    }
                    trvData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
                }
            }
            else
            {
                //非顶层元素
                trvData_MouseClick_NotTop(sender, e);
            }
        }
        /// <summary>
        /// 鼠标动作（非顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_NotTop(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextMenuStripMain = new ContextMenuStrip();

                //顶层可以删除的节点
                switch (SystemManager.GetCurrentCollection().Name)
                {
                    case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                    case MongoDBHelper.COLLECTION_NAME_USER:
                    default:
                        this.contextMenuStripMain.Items.Add(this.AddElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.ModifyElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.DropElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.CopyElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.CutElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.PasteElementToolStripMenuItem.Clone());
                        break;
                }
                trvData.ContextMenuStrip = this.contextMenuStripMain;
                contextMenuStripMain.Show(trvData.PointToScreen(e.Location));
            }
        }
        /// <summary>
        /// 键盘动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (DelSelectRecordToolStripMenuItem.Enabled)
                    {
                        DelSelectRecordToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        if (this.DropElementToolStripMenuItem.Enabled)
                        {
                            DropElementToolStripMenuItem_Click(null, null);
                        }
                    }
                    break;
                case Keys.F2:
                    if (this.ModifyElementToolStripMenuItem.Enabled)
                    {
                        ModifyElementToolStripMenuItem_Click(null, null);
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 清除数据显示区
        /// </summary>
        private void clearDataShower()
        {
            lstData.Clear();
            txtData.Text = String.Empty;
            trvData.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.ContextMenuStrip = null;
            this.contextMenuStripMain = null;
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
            DisableAllOpr();
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
            DisableAllOpr();
            clearDataShower();
            MongoDBHelper.FillMongoServiceToTreeView(trvsrvlst);
        }
        /// <summary>
        /// Server Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrvStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmServiceStatus());
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

        #region"Tools"
        /// <summary>
        /// Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmOption());
            SystemManager.InitLanguage();
            if (!SystemManager.IsUseDefaultLanguage())
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
                    lstData.Clear();
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
        /// Drop User from Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserFromAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Drop User";
            String strMessage = "Are you sure to delete user(s) from Admin Group?";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User_Confirm);
            }

            //这里也可以使用普通的删除数据的方法来删除用户。
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.RemoveUserFromSvr(item.SubItems[1].Text);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.RemoveUserFromSvr(trvData.SelectedNode.Tag.ToString());
                    trvData.ContextMenuStrip = null;
                }
                RemoveUserFromAdminToolStripMenuItem.Enabled = false;
                RefreshData();
            }
        }
        /// <summary>
        /// SlaveResync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slaveResyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CommandResult> ResultCommandList = new List<CommandResult>();
            ResultCommandList.Add(MongoDBHelper.RunMongoCommandAtCurrentObj(MongoDBHelper.resync_Command));
            MyMessageBox.ShowMessage("resync", "resync Result", MongoDBHelper.ConvertCommandResultlstToString(ResultCommandList), true);
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
                    throw ex;
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
                    lstData.Clear();
                }
            }
        }
        /// <summary>
        /// 建立数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strCollection = String.Empty;

            if (SystemManager.IsUseDefaultLanguage())
            {
                strCollection = MyMessageBox.ShowInput("Please input the collection Name：", "Create Collection");
            }
            else
            {
                strCollection = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_Collection_Input),
                                                                           SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_Collection));
            }
            if (strCollection != String.Empty)
            {
                if (MongoDBHelper.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelper.Oprcode.Create, trvsrvlst.SelectedNode))
                {
                    DisableAllOpr();
                    lstData.Clear();
                }
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
        /// Delete User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Drop User";
            String strMessage = "Are you sure to delete user(s) from this database";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.RemoveUserFromDB(item.SubItems[1].Text);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.RemoveUserFromDB(trvData.SelectedNode.Tag.ToString());
                    trvData.ContextMenuStrip = null;
                }
                RemoveUserToolStripMenuItem.Enabled = false;
                RefreshData();
            }
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
            List<CommandResult> ResultCommandList = new List<CommandResult>();
            ResultCommandList.Add(MongoDBHelper.RunMongoCommandAtCurrentObj(MongoDBHelper.repairDatabase_Command));
            MyMessageBox.ShowMessage("RepairDataBase", "RepairDataBase Result", MongoDBHelper.ConvertCommandResultlstToString(ResultCommandList), true);
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
                    clearDataShower();
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
                clearDataShower();
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
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelSelectRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String strTitle = "Delete Document";
            String strMessage = "Are you sure to delete selected document(s)?";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    String strKey = lstData.Columns[0].Text;
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.DropDocument(SystemManager.GetCurrentCollection(), item.Tag, strKey);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    String strKey = trvData.SelectedNode.Nodes[0].Text.Split(":".ToCharArray())[0];
                    MongoDBHelper.DropDocument(SystemManager.GetCurrentCollection(), trvData.SelectedNode.Tag, strKey);
                    trvData.ContextMenuStrip = null;
                }
                DelSelectRecordToolStripMenuItem.Enabled = false;
                RefreshData();
            }
        }

        /// <summary>
        /// Add Empty Document to Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BsonValue id = MongoDBHelper.InsertEmptyDocument(SystemManager.GetCurrentCollection(), config.IsSafeMode);
            TreeNode newDoc = new TreeNode(SystemManager.GetCurrentCollection().Name + "[" + (SystemManager.GetCurrentCollection().Count()).ToString() + "]");
            newDoc.Tag = id;
            TreeNode newid = new TreeNode("_id:" + id.ToString());
            newid.Tag = id;
            newDoc.Nodes.Add(newid);
            trvData.Nodes.Add(newDoc);
            tabDataShower.SelectedIndex = 0;
            trvData.SelectedNode = newid;
            IsNeedRefresh = true;
        }

        /// <summary>
        /// Refresh Data
        /// </summary>
        private void RefreshData()
        {
            clearDataShower();
            MongoDBHelper.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
            IsNeedRefresh = false;
        }
        #endregion

        #region"管理：元素操作"
        /// <summary>
        /// Is Need Refresh after the element is modify
        /// </summary>
        private Boolean IsNeedRefresh = false;
        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmElement(false, trvData.SelectedNode));
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.SelectedNode.Level == 1 & trvData.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id Can't be delete");
                return;
            }
            MongoDBHelper.DropElement(trvData.SelectedNode.FullPath);
            trvData.Nodes.Remove(trvData.SelectedNode);
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.SelectedNode.Level == 1 & trvData.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id can't be modify");
                return;
            }
            SystemManager.OpenForm(new frmElement(true, trvData.SelectedNode));
            IsNeedRefresh = true;
        }
        /// <summary>
        /// Copy Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.CopyElement(trvData.SelectedNode.FullPath);
        }
        /// <summary>
        /// Paste Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PasteElement(trvData.SelectedNode.FullPath);
            MongoDBHelper.FillBsonDocToTreeNode(trvData.SelectedNode, new BsonDocument().Add(MongoDBHelper.ClipElement), (BsonValue)trvData.SelectedNode.Tag);
            IsNeedRefresh = true;
        }
        /// <summary>
        /// Cut Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.SelectedNode.Level == 1 & trvData.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id can't be cut");
                return;
            }
            MongoDBHelper.CutElement(trvData.SelectedNode.FullPath);
            trvData.Nodes.Remove(trvData.SelectedNode);
            IsNeedRefresh = true;
        }
        #endregion

        #region"管理：GFS"
        /// <summary>
        /// Upload File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog upfile = new OpenFileDialog();
            if (upfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.UpLoadFile(upfile.FileName);
            }
            RefreshData();
        }
        /// <summary>
        /// DownLoad File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog downfile = new SaveFileDialog();
            String strFileName = lstData.SelectedItems[0].Text;
            downfile.FileName = strFileName.Split(@"\".ToCharArray())[strFileName.Split(@"\".ToCharArray()).Length - 1];
            if (downfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.DownloadFile(downfile.FileName, strFileName);
            }
        }
        /// <summary>
        /// Open File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strFileName = lstData.SelectedItems[0].Text;
            MongoDBHelper.OpenFile(strFileName);
        }
        /// <summary>
        /// Delete File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Delete Files";
            String strMessage = "Are you sure to delete selected File(s)?";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    String strFileName = lstData.SelectedItems[0].Text;
                    MongoDBHelper.DelFile(strFileName);
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.DelFile(trvData.SelectedNode.Tag.ToString());
                    trvData.ContextMenuStrip = null;
                }
                RefreshData();
            }
        }
        private void InitGFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.InitGFS();
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

        #region"数据导航"
        private void PrePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.PrePage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.NextPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void FirstPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.FirstPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void LastPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.LastPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void ExpandAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvData.ExpandAll();
        }

        private void CollapseAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvData.CollapseAll();
        }
        private void QueryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmQuery());
            this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
            //重新展示数据
            MongoDBHelper.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        #region"聚合"
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
        /// <summary>
        /// 过滤切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.IsUseFilter = !MongoDBHelper.IsUseFilter;
            this.DataFilterToolStripMenuItem.Checked = MongoDBHelper.IsUseFilter;
            //过滤变更后，重新刷新
            MongoDBHelper.SkipCnt = 0;
            RefreshData();
        }
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
        /// 设置导航可用性
        /// </summary>
        private void SetDataNav()
        {
            PrePageToolStripMenuItem.Enabled = MongoDBHelper.HasPrePage;
            NextPageToolStripMenuItem.Enabled = MongoDBHelper.HasNextPage;
            FirstPageToolStripMenuItem.Enabled = MongoDBHelper.HasPrePage;
            LastPageToolStripMenuItem.Enabled = MongoDBHelper.HasNextPage;
            this.QueryDataToolStripMenuItem.Enabled = true;

            this.ExpandAllDataToolStripMenuItem.Enabled = true;
            this.CollapseAllDataToolStripMenuItem.Enabled = true;
            this.DataFilterToolStripMenuItem.Enabled = true;
            this.AggregationToolStripMenuItem.Enabled = true;
            SetToolBarEnabled();
            String strTitle = "Records";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            }
            if (MongoDBHelper.CurrentCollectionTotalCnt == 0)
            {
                DataNaviToolStripLabel.Text = strTitle + "：0/0";
            }
            else
            {
                DataNaviToolStripLabel.Text = strTitle + "：" + (MongoDBHelper.SkipCnt + 1).ToString() + "/" + MongoDBHelper.CurrentCollectionTotalCnt.ToString();
            }
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
            String strUrl = "http://www.magicdict.com/userguide/index.htm";
            System.Diagnostics.Process.Start(strUrl);
        }
        #endregion
    }
}
