/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/9
 * Time: 14:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoCola.Module;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using PlugInPackage;

namespace MongoCola
{
	public partial class frmMain : Form
	{
		/// <summary>
		/// 连接
		/// </summary>
		/// <param name="strNodeType"></param>
		/// <param name="e"></param>
		private void ConnectionHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
		{
			//普通连接
			if (SystemManager.IsUseDefaultLanguage) {
				statusStripMain.Items[0].Text = "Selected Connection:" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			} else {
				statusStripMain.Items[0].Text =
                                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Server) + ":" +
				RuntimeMongoDBContext.SelectTagData;
			}

			DisconnectToolStripMenuItem.Enabled = true;
			ShutDownToolStripMenuItem.Enabled = true;
			ShutDownToolStripButton.Enabled = true;

			switch (strNodeType) {
				case ConstMgr.CONNECTION_TAG:
					InitReplsetToolStripMenuItem.Enabled = true;
					break;
				case ConstMgr.CONNECTION_REPLSET_TAG:
					ReplicaSetToolStripMenuItem.Enabled = true;
					break;
				case ConstMgr.CONNECTION_CLUSTER_TAG:
					ShardingConfigToolStripMenuItem.Enabled = true;
					break;
			}
			if (e.Button == MouseButtons.Right) {
				contextMenuStripMain = new ContextMenuStrip();
				if (SystemManager.MonoMode) {
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
				} else {
					contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
					contextMenuStripMain.Items.Add(ShutDownToolStripMenuItem.Clone());
					contextMenuStripMain.Items.Add(InitReplsetToolStripMenuItem.Clone());
					contextMenuStripMain.Items.Add(ReplicaSetToolStripMenuItem.Clone());
					contextMenuStripMain.Items.Add(ShardingConfigToolStripMenuItem.Clone());
				}
				e.Node.ContextMenuStrip = contextMenuStripMain;
				contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
			}
		}
		/// <summary>
		/// 异常连接
		/// </summary>
		/// <param name="strNodeType"></param>
		/// <param name="e"></param>
		private void ExceptionConnectionHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
		{
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
			DisconnectToolStripMenuItem.Enabled = true;
			RestoreMongoToolStripMenuItem.Enabled = false;
			if (e.Button == MouseButtons.Right) {
				contextMenuStripMain = new ContextMenuStrip();
				if (SystemManager.MonoMode) {
					//悲催MONO不支持
					ToolStripMenuItem t1 = DisconnectToolStripMenuItem.Clone();
					t1.Click += DisconnectToolStripMenuItem_Click;
					contextMenuStripMain.Items.Add(t1);
				} else {
					contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
				}
				e.Node.ContextMenuStrip = contextMenuStripMain;
				contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
			}
			statusStripMain.Items[0].Text = "Selected Server[Exception]:" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
		}
		/// <summary>
		/// Server
		/// </summary>
		/// <param name="strNodeType"></param>
		/// <param name="e"></param>
		private void ServerHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
		{
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
			if (SystemManager.IsUseDefaultLanguage) {
				statusStripMain.Items[0].Text = "Selected Server:" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			} else {
				statusStripMain.Items[0].Text =
                                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Server) + ":" +
				MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			}
			//解禁 创建数据库,关闭服务器
			if (!MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly) {
				CreateMongoDBToolStripMenuItem.Enabled = true;
				AddUserToAdminToolStripMenuItem.Enabled = true;
				if (MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ServerRole == MongoConnectionConfig.SvrRoleType.MasterSvr ||
				    MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ServerRole == MongoConnectionConfig.SvrRoleType.SlaveSvr) {
					//Master，Slave都可以执行
					slaveResyncToolStripMenuItem.Enabled = true;
				}
			}
			UserInfoStripMenuItem.Enabled = true;
			ServerStatusToolStripMenuItem.Enabled = true;
			ServePropertyToolStripMenuItem.Enabled = true;

			if (e.Button == MouseButtons.Right) {
				contextMenuStripMain = new ContextMenuStrip();
				if (SystemManager.MonoMode) {
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
				} else {
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
			foreach (ToolStripMenuItem item in plugInToolStripMenuItem.DropDownItems) {
				if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.ConnectionLV) {
					item.Enabled = true;
				}
			}
		}
		
		private void SingleDBServerHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
		{
			//单数据库模式,禁止所有服务器操作
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
			if (e.Button == MouseButtons.Right) {
				contextMenuStripMain = new ContextMenuStrip();
				if (SystemManager.MonoMode) {
					//悲催MONO不支持
					ToolStripMenuItem t1 = DisconnectToolStripMenuItem.Clone();
					t1.Click += DisconnectToolStripMenuItem_Click;
					contextMenuStripMain.Items.Add(t1);
					ToolStripMenuItem t2 = ServerStatusToolStripMenuItem.Clone();
					t2.Click += SvrStatusToolStripMenuItem_Click;
					contextMenuStripMain.Items.Add(t2);
				} else {
					contextMenuStripMain.Items.Add(DisconnectToolStripMenuItem.Clone());
					contextMenuStripMain.Items.Add(ServerStatusToolStripMenuItem.Clone());
				}
				e.Node.ContextMenuStrip = contextMenuStripMain;
				contextMenuStripMain.Show(trvsrvlst.PointToScreen(e.Location));
			}
			statusStripMain.Items[0].Text = "Selected Server[Single Database]:" +
			MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
		}
		
		private void DataBaseHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
		{
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = e.Node.Tag.ToString();
			List<string> roles = User.GetCurrentDBRoles(RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName, RuntimeMongoDBContext.GetCurrentDataBase().Name);
			if (SystemManager.IsUseDefaultLanguage) {
				statusStripMain.Items[0].Text = "Selected DataBase:" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			} else {
				statusStripMain.Items[0].Text =
                                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_DataBase) + ":" +
				MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			}
			//系统库不允许修改
			if (!MongoDbHelper.IsSystemDataBase(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name)) {
				if (MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.AuthMode) {
					//根据Roles确定删除数据库/创建数据集等的权限
					DelMongoDBToolStripMenuItem.Enabled = MongoUtility.Security.MongoDBAction.JudgeRightByBuildInRole(roles,
						MongoUtility.Security.MongoDBAction.ActionType.ServerAdministrationActions_dropDatabase);
					CreateMongoCollectionToolStripMenuItem.Enabled = MongoUtility.Security.MongoDBAction.JudgeRightByBuildInRole(roles,
						MongoUtility.Security.MongoDBAction.ActionType.DatabaseManagementActions_createCollection);
					InitGFSToolStripMenuItem.Enabled = MongoUtility.Security.MongoDBAction.JudgeRightByBuildInRole(roles,
						MongoUtility.Security.MongoDBAction.ActionType.Misc_InitGFS);
					AddUserToolStripMenuItem.Enabled = MongoUtility.Security.MongoDBAction.JudgeRightByBuildInRole(roles,
						MongoUtility.Security.MongoDBAction.ActionType.DatabaseManagementActions_createUser);
					//If a Slave server can repair database @ Master-Slave is not sure ??
					RepairDBToolStripMenuItem.Enabled = MongoUtility.Security.MongoDBAction.JudgeRightByBuildInRole(roles,
						MongoUtility.Security.MongoDBAction.ActionType.ServerAdministrationActions_repairDatabase);
				} else {
					DelMongoDBToolStripMenuItem.Enabled = true;
					CreateMongoCollectionToolStripMenuItem.Enabled = true;
					InitGFSToolStripMenuItem.Enabled = true;
					AddUserToolStripMenuItem.Enabled = true;
					RepairDBToolStripMenuItem.Enabled = true;
				}
				EvalJSToolStripMenuItem.Enabled = MongoUtility.Security.MongoDBAction.JudgeRightByBuildInRole(roles,
					MongoUtility.Security.MongoDBAction.ActionType.Misc_EvalJS);
			}
			//备份数据库
			DumpDatabaseToolStripMenuItem.Enabled = true;
			ProfillingLevelToolStripMenuItem.Enabled = true;
			if (strNodeType == ConstMgr.SINGLE_DATABASE_TAG) {
				DelMongoDBToolStripMenuItem.Enabled = false;
			}
			DBStatusToolStripMenuItem.Enabled = true;
			if (e.Button == MouseButtons.Right) {
				contextMenuStripMain = new ContextMenuStrip();
				if (SystemManager.MonoMode) {
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
				} else {
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
		
		private void CollectionHandler(string strNodeType, TreeNodeMouseClickEventArgs e)
		{
			if (SystemManager.IsUseDefaultLanguage) {
				statusStripMain.Items[0].Text = "Selected Collection:" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			} else {
				statusStripMain.Items[0].Text =
                                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Collection) + ":" +
				MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			}
			//解禁 删除数据集
			if (!MongoDbHelper.IsSystemCollection(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection())) {
				//系统数据库无法删除！！
				if (!MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly) {
					DelMongoCollectionToolStripMenuItem.Enabled = true;
					RenameCollectionToolStripMenuItem.Enabled = true;
				}
			}
			if (!MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly) {
				ImportCollectionToolStripMenuItem.Enabled = true;
				CompactToolStripMenuItem.Enabled = true;
			}
			if (!MongoDbHelper.IsSystemCollection(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection()) &&
			       !MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.IsReadOnly) {
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
			if (e.Button == MouseButtons.Right) {
				contextMenuStripMain = new ContextMenuStrip();
				if (SystemManager.MonoMode) {
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
					t8.Click += (x, y) => ViewDataObj();
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
				} else {
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
			foreach (ToolStripMenuItem item in plugInToolStripMenuItem.DropDownItems) {
				if (PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.CollectionLV) {
					item.Enabled = true;
				}
			}
		}
	}
}
