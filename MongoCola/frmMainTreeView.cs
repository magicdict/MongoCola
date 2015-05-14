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
                    var t1 = DisconnectToolStripMenuItem.Clone();
                    t1.Click += DisconnectToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t1);

                    var t2 = InitReplsetToolStripMenuItem.Clone();
                    t2.Click += InitReplsetToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t2);

                    var t3 = ReplicaSetToolStripMenuItem.Clone();
                    t3.Click += ReplicaSetToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t3);

                    var t4 = ShardingConfigToolStripMenuItem.Clone();
                    t4.Click += ShardingConfigToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t4);

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
                    var t1 = DisconnectToolStripMenuItem.Clone();
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
                    var t1 = CreateMongoDBToolStripMenuItem.Clone();
                    t1.Click += CreateMongoDBToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t1);

                    var t2 = AddUserToAdminToolStripMenuItem.Clone();
                    t2.Click += AddUserToAdminToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t2);

                    var t3 = RestoreMongoToolStripMenuItem.Clone();
                    t3.Click += RestoreMongoToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t3);

                    var t6 = slaveResyncToolStripMenuItem.Clone();
                    t6.Click += slaveResyncToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t6);

                    var t9 = ServePropertyToolStripMenuItem.Clone();
                    t9.Click += ServePropertyToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t9);

                    var t10 = ServerStatusToolStripMenuItem.Clone();
                    t10.Click += SvrStatusToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t10);
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
                    var t1 = DisconnectToolStripMenuItem.Clone();
                    t1.Click += DisconnectToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t1);
                    var t2 = ServerStatusToolStripMenuItem.Clone();
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
                                            RuntimeMongoDbContext.SelectTagData;
        }

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
                    var t1 = DelMongoDBToolStripMenuItem.Clone();
                    t1.Click += DelMongoDBToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t1);

                    var t2 = CreateMongoCollectionToolStripMenuItem.Clone();
                    t2.Click += CreateMongoCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t2);

                    var t3 = AddUserToolStripMenuItem.Clone();
                    t3.Click += AddUserToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t3);

                    var t4 = EvalJSToolStripMenuItem.Clone();
                    t4.Click += evalJSToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t4);

                    var t5 = RepairDBToolStripMenuItem.Clone();
                    t5.Click += RepairDBToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t5);


                    var t6 = InitGFSToolStripMenuItem.Clone();
                    t6.Click += InitGFSToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t6);

                    var t7 = DumpDatabaseToolStripMenuItem.Clone();
                    t7.Click += DumpDatabaseToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t7);

                    var t8 = RestoreMongoToolStripMenuItem.Clone();
                    t8.Click += RestoreMongoToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t8);


                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

                    var t10 = ProfillingLevelToolStripMenuItem.Clone();
                    t10.Click += profillingLevelToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t10);

                    var t11 = DBStatusToolStripMenuItem.Clone();
                    t11.Click += DBStatusToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t11);
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
                    var t1 = DelMongoCollectionToolStripMenuItem.Clone();
                    t1.Click += DelMongoCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t1);

                    var t2 = RenameCollectionToolStripMenuItem.Clone();
                    t2.Click += RenameCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t2);

                    var t3 = DumpCollectionToolStripMenuItem.Clone();
                    t3.Click += DumpCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t3);

                    var t4 = RestoreMongoToolStripMenuItem.Clone();
                    t4.Click += RestoreMongoToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t4);

                    var t5 = ImportCollectionToolStripMenuItem.Clone();
                    t5.Click += ImportCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t5);

                    var t6 = ExportCollectionToolStripMenuItem.Clone();
                    t6.Click += ExportCollectionToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t6);

                    var t7 = CompactToolStripMenuItem.Clone();
                    t7.Click += CompactToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t7);

                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

                    var t8 = ViewDataToolStripMenuItem.Clone();
                    t8.Click += (x, y) => ViewDataObj();
                    contextMenuStripMain.Items.Add(t8);

                    var aggregationMenu = AggregationToolStripMenuItem.Clone();

                    var t9 = countToolStripMenuItem.Clone();
                    t9.Click += countToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(t9);

                    var t10 = distinctToolStripMenuItem.Clone();
                    t10.Click += distinctToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(t10);


                    var t11 = groupToolStripMenuItem.Clone();
                    t11.Click += groupToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(t11);

                    var t12 = mapReduceToolStripMenuItem.Clone();
                    t12.Click += mapReduceToolStripMenuItem_Click;
                    aggregationMenu.DropDownItems.Add(t12);

                    contextMenuStripMain.Items.Add(aggregationMenu);
                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

                    var t13 = IndexManageToolStripMenuItem.Clone();
                    t13.Click += IndexManageToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t13);

                    var t14 = ReIndexToolStripMenuItem.Clone();
                    t14.Click += ReIndexToolStripMenuItem_Click;
                    contextMenuStripMain.Items.Add(t14);

                    contextMenuStripMain.Items.Add(new ToolStripSeparator());

                    var t15 = CollectionStatusToolStripMenuItem.Clone();
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
                if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.CollectionLv)
                {
                    item.Enabled = true;
                }
            }
        }
    }
}