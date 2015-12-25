/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/9
 * Time: 14:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.Security;
using PlugInPackage;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoCola
{
    public partial class FrmMain : Form
    {
        /// <summary>
        ///     连接
        /// </summary>
        /// <param name="strNodeType"></param>
        /// <param name="e"></param>
        private void ConnectionHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
        {
            //普通连接
            if (GuiConfig.IsUseDefaultLanguage)
            {
                statusStripMain.Items[0].Text = "Selected Connection:" + RuntimeMongoDbContext.SelectTagData;
            }
            else
            {
                statusStripMain.Items[0].Text =
                    GuiConfig.GetText(TextType.SelectedServer) + ":" +
                    RuntimeMongoDbContext.SelectTagData;
            }

            DisconnectToolStripMenuItem.Enabled = true;
            //ShutDownToolStripMenuItem.Enabled = true;
            //ShutDownToolStripButton.Enabled = true;

            switch (strNodeType)
            {
                case ConstMgr.ConnectionTag:
                    InitReplsetToolStripMenuItem.Enabled = true;
                    break;
                case ConstMgr.ConnectionReplsetTag:
                    ReplicaSetToolStripMenuItem.Enabled = true;
                    break;
                case ConstMgr.ConnectionClusterTag:
                    ShardingConfigToolStripMenuItem.Enabled = true;
                    break;
            }
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripMain = new ContextMenuStrip();
                if (SystemManager.MonoMode)
                {
					var Disconnect = DisconnectToolStripMenuItem.Clone();
                    Disconnect.Click += DisconnectToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(Disconnect);

					var InitReplset = InitReplsetToolStripMenuItem.Clone();
                    InitReplset.Click += InitReplsetToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(InitReplset);

					var ReplicaSet = ReplicaSetToolStripMenuItem.Clone();
                    ReplicaSet.Click += ReplicaSetToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ReplicaSet);

					var ShardingConfig = ShardingConfigToolStripMenuItem.Clone();
                    ShardingConfig.Click += ShardingConfigToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ShardingConfig);

                    //var t5 = ShutDownToolStripMenuItem.Clone();
                    //t5.Click += ShutDownToolStripMenuItem_Click;
                    //contextMenuStripMain.Items.Add(t5);
                }
                else
                {
                    contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
                    //contextMenuStripMain.Items.Add(ShutDownToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(InitReplsetToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(ReplicaSetToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(ShardingConfigToolStripMenuItem.Clone());
                }
                e.Node.ContextMenuStrip = contextMenuStripMain;
                contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
            }
        }

        /// <summary>
        ///     异常连接
        /// </summary>
        /// <param name="e"></param>
        private void ExceptionConnectionHandler(TreeNodeMouseClickEventArgs e)
        {
            RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
            DisconnectToolStripMenuItem.Enabled = true;
            RestoreMongoToolStripMenuItem.Enabled = false;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripMain = new ContextMenuStrip();
                if (SystemManager.MonoMode)
                {
                    //悲催MONO不支持
					var Disconnect = DisconnectToolStripMenuItem.Clone();
                    Disconnect.Click += DisconnectToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(Disconnect);
                }
                else
                {
                    contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
                }
                e.Node.ContextMenuStrip = contextMenuStripMain;
                contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
            }
            statusStripMain.Items[0].Text = "Selected Server[Exception]:" + RuntimeMongoDbContext.SelectTagData;
        }

        /// <summary>
        ///     Server
        /// </summary>
        /// <param name="e"></param>
        private void ServerHandler(TreeNodeMouseClickEventArgs e)
        {
            RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
            if (GuiConfig.IsUseDefaultLanguage)
            {
                statusStripMain.Items[0].Text = "Selected Server:" + RuntimeMongoDbContext.SelectTagData;
            }
            else
            {
                statusStripMain.Items[0].Text =
                    GuiConfig.GetText(TextType.SelectedServer) + ":" +
                    RuntimeMongoDbContext.SelectTagData;
            }
            //解禁 创建数据库,关闭服务器
            if (!RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
            {
                CreateMongoDBToolStripMenuItem.Enabled = true;
                AddUserToAdminToolStripMenuItem.Enabled = true;
                if (RuntimeMongoDbContext.CurrentMongoConnectionconfig.ServerRole ==
                    MongoConnectionConfig.SvrRoleType.MasterSvr ||
                    RuntimeMongoDbContext.CurrentMongoConnectionconfig.ServerRole ==
                    MongoConnectionConfig.SvrRoleType.SlaveSvr)
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
                if (SystemManager.MonoMode)
                {
                    //悲催MONO不支持
					var CreateMongoDB = CreateMongoDBToolStripMenuItem.Clone();
                    CreateMongoDB.Click += CreateMongoDBToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(CreateMongoDB);

					var AddUserToAdmin = AddUserToAdminToolStripMenuItem.Clone();
                    AddUserToAdmin.Click += AddUserToAdminToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(AddUserToAdmin);

					var RestoreMongo = RestoreMongoToolStripMenuItem.Clone();
                    RestoreMongo.Click += RestoreMongoToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(RestoreMongo);

					var slaveResync = slaveResyncToolStripMenuItem.Clone();
                    slaveResync.Click += slaveResyncToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(slaveResync);

					var ServeProperty = ServePropertyToolStripMenuItem.Clone();
                    ServeProperty.Click += ServePropertyToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ServeProperty);

					var ServerStatus = ServerStatusToolStripMenuItem.Clone();
                    ServerStatus.Click += SvrStatusToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ServerStatus);
                }
                else
                {
                    contextMenuStripMain.Items.Add(CreateMongoDBToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(AddUserToAdminToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(AddAdminCustomeRoleStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(UserInfoStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(RestoreMongoToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(slaveResyncToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(ServePropertyToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(ServerStatusToolStripMenuItem.Clone());
                }
                e.Node.ContextMenuStrip = contextMenuStripMain;
                contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
            }
            //PlugIn
            foreach (ToolStripMenuItem item in plugInToolStripMenuItem.DropDownItems)
            {
                if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.ConnectionLv)
                {
                    item.Enabled = true;
                }
            }
        }
		/// <summary>
		/// Singles the DB server handler.
		/// </summary>
		/// <param name="e">E.</param>
        private void SingleDBServerHandler(TreeNodeMouseClickEventArgs e)
        {
            //单数据库模式,禁止所有服务器操作
            RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripMain = new ContextMenuStrip();
                if (SystemManager.MonoMode)
                {
                    //悲催MONO不支持
					var Disconnect = DisconnectToolStripMenuItem.Clone();
                    Disconnect.Click += DisconnectToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(Disconnect);
					var ServerStatus = ServerStatusToolStripMenuItem.Clone();
                    ServerStatus.Click += SvrStatusToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ServerStatus);
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
                                            RuntimeMongoDbContext.SelectTagData;
        }
		/// <summary>
		/// Datas the base handler.
		/// </summary>
		/// <param name="strNodeType">String node type.</param>
		/// <param name="e">E.</param>
        private void DataBaseHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
        {
            RuntimeMongoDbContext.SelectObjectTag = e.Node.Tag.ToString();
            var roles = User.GetCurrentDbRoles(RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName,
                RuntimeMongoDbContext.GetCurrentDataBaseName());
            if (GuiConfig.IsUseDefaultLanguage)
            {
                statusStripMain.Items[0].Text = "Selected DataBase:" + RuntimeMongoDbContext.SelectTagData;
            }
            else
            {
                statusStripMain.Items[0].Text =
                    GuiConfig.GetText(TextType.SelectedDataBase) + ":" +
                    RuntimeMongoDbContext.SelectTagData;
            }
            //系统库不允许修改
            if (!Operater.IsSystemDataBase(RuntimeMongoDbContext.GetCurrentDataBaseName()))
            {
                if (RuntimeMongoDbContext.CurrentMongoConnectionconfig.AuthMode)
                {
                    //根据Roles确定删除数据库/创建数据集等的权限
                    DelMongoDBToolStripMenuItem.Enabled = MongoDbAction.JudgeRightByBuildInRole(roles,
                        MongoDbAction.ActionType.ServerAdministrationActionsDropDatabase);
                    CreateMongoCollectionToolStripMenuItem.Enabled = MongoDbAction.JudgeRightByBuildInRole(roles,
                        MongoDbAction.ActionType.DatabaseManagementActionsCreateCollection);
                    InitGFSToolStripMenuItem.Enabled = MongoDbAction.JudgeRightByBuildInRole(roles,
                        MongoDbAction.ActionType.MiscInitGfs);
                    AddUserToolStripMenuItem.Enabled = MongoDbAction.JudgeRightByBuildInRole(roles,
                        MongoDbAction.ActionType.DatabaseManagementActionsCreateUser);
                    //If a Slave server can repair database @ Master-Slave is not sure ??
                    RepairDBToolStripMenuItem.Enabled = MongoDbAction.JudgeRightByBuildInRole(roles,
                        MongoDbAction.ActionType.ServerAdministrationActionsRepairDatabase);
                }
                else
                {
                    DelMongoDBToolStripMenuItem.Enabled = true;
                    CreateMongoCollectionToolStripMenuItem.Enabled = true;
                    InitGFSToolStripMenuItem.Enabled = true;
                    AddUserToolStripMenuItem.Enabled = true;
                    RepairDBToolStripMenuItem.Enabled = true;
                }
                EvalJSToolStripMenuItem.Enabled = MongoDbAction.JudgeRightByBuildInRole(roles,
                    MongoDbAction.ActionType.MiscEvalJs);
            }
            //备份数据库
            DumpDatabaseToolStripMenuItem.Enabled = true;
            ProfillingLevelToolStripMenuItem.Enabled = true;
            if (strNodeType == ConstMgr.SingleDatabaseTag)
            {
                DelMongoDBToolStripMenuItem.Enabled = false;
            }
            DBStatusToolStripMenuItem.Enabled = true;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripMain = new ContextMenuStrip();
                if (SystemManager.MonoMode)
                {
                    //悲催MONO不支持
					var DelMongoDB = DelMongoDBToolStripMenuItem.Clone();
                    DelMongoDB.Click += DelMongoDBToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(DelMongoDB);

					var CreateMongoCollection = CreateMongoCollectionToolStripMenuItem.Clone();
                    CreateMongoCollection.Click += CreateMongoCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(CreateMongoCollection);

					var AddUser = AddUserToolStripMenuItem.Clone();
                    AddUser.Click += AddUserToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(AddUser);

					var EvalJS = EvalJSToolStripMenuItem.Clone();
                    EvalJS.Click += evalJSToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(EvalJS);

					var RepairDB = RepairDBToolStripMenuItem.Clone();
                    RepairDB.Click += RepairDBToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(RepairDB);


					var InitGFS = InitGFSToolStripMenuItem.Clone();
                    InitGFS.Click += InitGFSToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(InitGFS);

					var DumpDatabase = DumpDatabaseToolStripMenuItem.Clone();
                    DumpDatabase.Click += DumpDatabaseToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(DumpDatabase);

					var RestoreMongo = RestoreMongoToolStripMenuItem.Clone();
                    RestoreMongo.Click += RestoreMongoToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(RestoreMongo);


                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

					var ProfillingLevel = ProfillingLevelToolStripMenuItem.Clone();
                    ProfillingLevel.Click += profillingLevelToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ProfillingLevel);

					var DBStatus = DBStatusToolStripMenuItem.Clone();
                    DBStatus.Click += DBStatusToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(DBStatus);
                }
                else
                {
                    contextMenuStripMain.Items.Add(DelMongoDBToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(CreateMongoCollectionToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(AddUserToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(AddDBCustomeRoleStripMenuItem.Clone());
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
        }
		/// <summary>
		/// Collections the handler.
		/// </summary>
		/// <param name="e">E.</param>
        private void CollectionHandler(TreeNodeMouseClickEventArgs e)
        {
            if (GuiConfig.IsUseDefaultLanguage)
            {
                statusStripMain.Items[0].Text = "Selected Collection:" + RuntimeMongoDbContext.SelectTagData;
            }
            else
            {
                statusStripMain.Items[0].Text =
                    GuiConfig.GetText(TextType.SelectedCollection) + ":" +
                    RuntimeMongoDbContext.SelectTagData;
            }
            //解禁 删除数据集
            if (!Operater.IsSystemCollection())
            {
                //系统数据库无法删除！！
                if (!RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
                {
                    DelMongoCollectionToolStripMenuItem.Enabled = true;
                    RenameCollectionToolStripMenuItem.Enabled = true;
                }
            }
            if (!RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
            {
                ImportCollectionToolStripMenuItem.Enabled = true;
                CompactToolStripMenuItem.Enabled = true;
            }
            if (!Operater.IsSystemCollection() &&
                !RuntimeMongoDbContext.CurrentMongoConnectionconfig.IsReadOnly)
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
                if (SystemManager.MonoMode)
                {
                    //悲催MONO不支持
					var DelMongoCollection = DelMongoCollectionToolStripMenuItem.Clone();
                    DelMongoCollection.Click += DelMongoCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(DelMongoCollection);

					var RenameCollection = RenameCollectionToolStripMenuItem.Clone();
                    RenameCollection.Click += RenameCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(RenameCollection);

					var DumpCollection = DumpCollectionToolStripMenuItem.Clone();
                    DumpCollection.Click += DumpCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(DumpCollection);

					var RestoreMongo = RestoreMongoToolStripMenuItem.Clone();
                    RestoreMongo.Click += RestoreMongoToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(RestoreMongo);

					var ImportCollection = ImportCollectionToolStripMenuItem.Clone();
                    ImportCollection.Click += ImportCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ImportCollection);

					var ExportCollection = ExportCollectionToolStripMenuItem.Clone();
                    ExportCollection.Click += ExportCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ExportCollection);

					var Compact = CompactToolStripMenuItem.Clone();
                    Compact.Click += CompactToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(Compact);

                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

					var ViewData = ViewDataToolStripMenuItem.Clone();
                    ViewData.Click += (x, y) => ViewDataObj();
                    contextMenuStripMain.Items.Add(ViewData);

                    var aggregationMenu = AggregationToolStripMenuItem.Clone();

					var count = countToolStripMenuItem.Clone();
                    count.Click += countToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(count);

					var distinct = distinctToolStripMenuItem.Clone();
                    distinct.Click += distinctToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(distinct);


					var group = groupToolStripMenuItem.Clone();
                    group.Click += groupToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(group);

					var mapReduce = mapReduceToolStripMenuItem.Clone();
                    mapReduce.Click += mapReduceToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(mapReduce);

                    contextMenuStripMain.Items.Add(aggregationMenu);
                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

					var IndexManage = IndexManageToolStripMenuItem.Clone();
                    IndexManage.Click += IndexManageToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(IndexManage);

					var ReIndex = ReIndexToolStripMenuItem.Clone();
                    ReIndex.Click += ReIndexToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(ReIndex);

                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

					var CollectionStatus = CollectionStatusToolStripMenuItem.Clone();
                    CollectionStatus.Click += CollectionStatusToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(CollectionStatus);
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
                if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.CollectionLv)
                {
                    item.Enabled = true;
                }
            }
        }
    }
}