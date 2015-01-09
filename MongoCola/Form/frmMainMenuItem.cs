using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using MongoCola.Module;
using MongoDB.Driver;
using MongoGUICtl;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ExteneralTool;

namespace MongoCola
{
	public partial class frmMain : Form
	{
		#region"数据库连接"

		/// <summary>
		///     Connection Management
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmConnect(), true, true);
			RefreshToolStripMenuItem_Click(sender, e);
		}

		/// <summary>
		///     Disconnect
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MongoUtility.Core.RuntimeMongoDBContext.SelectTagType != ConstMgr.CONNECTION_EXCEPTION_TAG) {
				//关闭相关的Tab
				var CloseList = new List<string>();
				foreach (string item in SystemManager._viewTabList.Keys) {
					if (item.StartsWith(MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName + "/")) {
						CloseList.Add(item);
					}
				}
				foreach (string CloseTabKey in CloseList) {
					tabView.Controls.Remove(SystemManager._viewTabList[CloseTabKey]);
					SystemManager._viewTabList[CloseTabKey] = null;
					SystemManager._viewTabList.Remove(CloseTabKey);
					SystemManager._viewInfoList.Remove(CloseTabKey);
					string MenuKey = string.Empty;
					ToolStripMenuItem CloseMenuItem = null;
					foreach (ToolStripMenuItem menuitem in collectionToolStripMenuItem.DropDownItems) {
						MenuKey = menuitem.Tag.ToString();
						MenuKey = MenuKey.Substring(MenuKey.IndexOf(":", StringComparison.Ordinal) + 1);
						if (CloseTabKey == MenuKey) {
							CloseMenuItem = menuitem;
						}
					}
					if (CloseMenuItem != null) {
						collectionToolStripMenuItem.DropDownItems.Remove(CloseMenuItem);
					}
				}
				MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().Disconnect();
			}
			MongoUtility.Core.RuntimeMongoDBContext._mongoConnSvrLst.Remove(MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName);
			trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
			RefreshToolStripMenuItem_Click(sender, e);
		}

		/// <summary>
		///     Shut Down Server
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!MyMessageBox.ShowConfirm("ShutDown Server", "Are you sure to shutDown the Server?"))
				return;
			MongoServer mongoSvr = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer();
			try {
				//the server will be  shutdown with exception
				MongoUtility.Core.RuntimeMongoDBContext._mongoConnSvrLst.Remove(MongoUtility.Core.RuntimeMongoDBContext.SelectTagData);
				mongoSvr.Shutdown();
			} catch (IOException) {
				//if IOException,ignore it
			} catch (Exception ex) {
				Common.Utility.ExceptionDeal(ex);
			}
			trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
			RefreshToolStripMenuItem_Click(sender, e);
		}

		/// <summary>
		///     初始化ReplSet
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InitReplsetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string ReplSetName = MyMessageBox.ShowInput("Please Fill ReplSetName :",
				                     SystemManager.IsUseDefaultLanguage
                    ? "ReplSetName"
                    : SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Replset_InitReplset));
			if (ReplSetName == string.Empty)
				return;
			CommandResult Result = CommandHelper.InitReplicaSet(ReplSetName,
				                       MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServerConfig().ConnectionName, SystemManager.config.ConnectionList);
			if (Result.Ok) {
				//修改配置
				MongoUtility.Core.MongoConnectionConfig newConfig = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServerConfig();
				newConfig.ReplSetName = ReplSetName;
				newConfig.ReplsetList = new List<string> {
					newConfig.Host +
					(newConfig.Port != 0 ? ":" + newConfig.Port : string.Empty)
				};
				SystemManager.config.ConnectionList[newConfig.ConnectionName] = newConfig;
				ConfigHelper.SaveToConfigFile();
				MongoUtility.Core.RuntimeMongoDBContext._mongoConnSvrLst.Remove(newConfig.ConnectionName);
				MongoUtility.Core.RuntimeMongoDBContext._mongoConnSvrLst.Add(MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName,
					MongoUtility.Core.RuntimeMongoDBContext.CreateMongoServer(ref newConfig));
				ServerStatusCtl.SetEnable(false);
				MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
				ServerStatusCtl.SetEnable(true);
			} else {
				MyMessageBox.ShowMessage("ReplSetName", "Failed", Result.ErrorMessage);
			}
		}

		/// <summary>
		///     副本管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MongoUtility.Core.MongoConnectionConfig newConfig = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServerConfig();
			Common.Utility.OpenForm(new frmReplsetMgr(ref newConfig), true, true);
			SystemManager.config.ConnectionList[newConfig.ConnectionName] = newConfig;
			ConfigHelper.SaveToConfigFile();
			MongoUtility.Core.RuntimeMongoDBContext._mongoConnSvrLst.Remove(newConfig.ConnectionName);
			MongoUtility.Core.RuntimeMongoDBContext._mongoConnSvrLst.Add(MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName, MongoUtility.Core.RuntimeMongoDBContext.CreateMongoServer(ref newConfig));
			ServerStatusCtl.SetEnable(false);
			MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
			ServerStatusCtl.SetEnable(true);
		}

		/// <summary>
		///     分片管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShardingConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmShardingConfig(), true, true);
		}
		/// <summary>
		///     刷新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("RefreshToolStripMenuItem_Click" + Thread.CurrentThread.ManagedThreadId);
			await RefreshConnectionAsync();
			DisableAllOpr();
			statusStripMain.Items[0].Text = !SystemManager.IsUseDefaultLanguage
                ? SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready)
                : "Ready";
		}
		/// <summary>
		/// 使用异步的方法来加载连接
		/// </summary>
		/// <returns></returns>
		async Task<int> RefreshConnectionAsync()
		{
			var ConnectionTreeNodes = new List<TreeNode>();
			await Task.Run(() => {
				ConnectionTreeNodes = UIHelper.GetConnectionNodes(RuntimeMongoDBContext._mongoConnSvrLst, SystemManager.config.ConnectionList);
			});
			ServerStatusCtl.ResetCtl();
			ServerStatusCtl.RefreshStatus(false);
			ServerStatusCtl.RefreshCurrentOpr();
			trvsrvlst.Nodes.Clear();
			foreach (var element in ConnectionTreeNodes) {
				trvsrvlst.Nodes.Add(element);
			}
			return 0;
		}

		/// <summary>
		///     Expand All
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			trvsrvlst.BeginUpdate();
			//trvsrvlst.ExpandAll();
			//全部展开的时候，东西太多了，只展开到Collection
			foreach (TreeNode node in trvsrvlst.Nodes) {
				ExpandNode(node);
			}
			trvsrvlst.EndUpdate();
		}
		private void ExpandNode(TreeNode node)
		{
			if (node.Tag == null)
				return;
			string strNodeType = Common.Utility.GetTagType(node.Tag.ToString());
			if (strNodeType != ConstMgr.COLLECTION_TAG && strNodeType != ConstMgr.GRID_FILE_SYSTEM_TAG) {
				node.Expand();
				if (node.Nodes.Count == 0)
					return;
				foreach (TreeNode item in node.Nodes) {
					ExpandNode(item);
				}
			}
		}
		/// <summary>
		///     Collapse All
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			trvsrvlst.BeginUpdate();
			trvsrvlst.CollapseAll();
			trvsrvlst.EndUpdate();
		}

		/// <summary>
		///     Exit Application
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
		///     建立数据库
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strDBName = string.Empty;
			if (SystemManager.IsUseDefaultLanguage) {
				strDBName = MyMessageBox.ShowInput("Please Input DataBaseName：", "Create Database");
			} else {
				strDBName =
                    MyMessageBox.ShowInput(
					SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Create_New_DataBase_Input),
					SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Create_New_DataBase));
			}
			string ErrMessage;
			MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().IsDatabaseNameValid(strDBName, out ErrMessage);
			if (ErrMessage == null) {
				try {
					string strRusult = MongoDbHelper.DataBaseOpration(MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag, strDBName,
						                   MongoDbHelper.Oprcode.Create, MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer());
					if (string.IsNullOrEmpty(strRusult)) {
						DisableAllOpr();
					} else {
						MyMessageBox.ShowMessage("Error", "Create MongoDatabase", strRusult, true);
					}
				} catch (ArgumentException ex) {
					Common.Utility.ExceptionDeal(ex, "Create MongoDatabase", "Argument Exception");
				}
			} else {
				MyMessageBox.ShowMessage("Create MongoDatabase", "Argument Exception", ErrMessage, true);
			}
		}

		/// <summary>
		///     copyDatabase
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CopyDatabasetoolStripMenuItem_Click(object sender, EventArgs e)
		{
			//MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().CopyDatabase(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name, MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name + "_Backup");
			//MongoDBHelper.ExecuteMongoDBCommand("copyDatabase", MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase());
			//CommandDocument copy = new CommandDocument();
			//MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().RunCommand("copyDatabase");
		}

		/// <summary>
		///     获得用户信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserInfoStripMenuItem_Click(object sender, EventArgs e)
		{
			//foreach (var item in MongoDBHelper._mongoUserLst.Keys)
			//{
			string ConnectionName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServerConfig().ConnectionName;
			string info = RuntimeMongoDBContext._mongoUserLst[ConnectionName].ToString();
			if (!string.IsNullOrEmpty(info)) {
				MyMessageBox.ShowMessage(
					SystemManager.IsUseDefaultLanguage
                        ? "UserInformation"
                        : SystemManager.guiConfig.MStringResource.GetText(
						StringResource.TextType.Main_Menu_Operation_Server_UserInfo),
					"The User Information of：[" +
					SystemManager.config.ConnectionList[ConnectionName].UserName + "]", info, true);
			}
			//}
		}

		/// <summary>
		///     Create User to Admin Group
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmUser(true), true, true);
		}
		/// <summary>
		///  Create A Role
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmAddRole(), true, true);
		}
		/// <summary>
		///     SlaveResync
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void slaveResyncToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommandHelper.ExecuteMongoCommand(CommandHelper.resync_Command);
		}

		/// <summary>
		///     Server Info
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ServePropertyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SystemManager.IsUseDefaultLanguage) {
				MyMessageBox.ShowMessage("Server Property", "Server Property", MongoUtility.Basic.Utility.GetCurrentSvrInfo(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer()), true);
			} else {
				MyMessageBox.ShowMessage(
					SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties),
					SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties),
					MongoUtility.Basic.Utility.GetCurrentSvrInfo(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer()), true);
			}
		}

		/// <summary>
		///     Status
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SvrStatusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmStatus(), true, true);
		}

		#endregion

		#region"管理：数据库"

		/// <summary>
		///     Drop MongoDB
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DelMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strTitle = "Drop Database";
			string strMessage = "Are you really want to Drop current Database?";
			if (!SystemManager.IsUseDefaultLanguage) {
				strTitle = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_DataBase);
				strMessage = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_DataBase_Confirm);
			}
			if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
				return;
			string strPath = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			string strDBName = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.DatabaseLv];
			if (trvsrvlst.SelectedNode == null) {
				trvsrvlst.SelectedNode = null;
			}
			string rtnResult = MongoDbHelper.DataBaseOpration(MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag, strDBName,
				                   MongoDbHelper.Oprcode.Drop, MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer());
			if (string.IsNullOrEmpty(rtnResult)) {
				DisableAllOpr();
				//关闭所有的相关视图
				//foreach不能直接修改，需要一个备份
				var tempTable = new Dictionary<string, TabPage>();
				foreach (string item in SystemManager._viewTabList.Keys) {
					tempTable.Add(item, SystemManager._viewTabList[item]);
				}

				foreach (string KeyItem in tempTable.Keys) {
					//如果有相同的前缀
					if (KeyItem.StartsWith(strPath)) {
						ToolStripMenuItem DataMenuItem = null;
						foreach (ToolStripMenuItem Menuitem in collectionToolStripMenuItem.DropDownItems) {
							//菜单的寻找
							if (Menuitem.Tag == SystemManager._viewTabList[KeyItem].Tag) {
								DataMenuItem = Menuitem;
							}
						}
						if (DataMenuItem != null) {
							//菜单的删除
							collectionToolStripMenuItem.DropDownItems.Remove(DataMenuItem);
						}
						//TabPage的删除
						tabView.Controls.Remove(SystemManager._viewTabList[KeyItem]);
						SystemManager._viewTabList.Remove(KeyItem);
						SystemManager._viewInfoList.Remove(KeyItem);
						SystemManager._viewTabList[KeyItem] = null;
					}
				}
				tempTable = null;
			} else {
				MyMessageBox.ShowMessage("Error", "Error", rtnResult, true);
			}
		}

		/// <summary>
		///     Create Collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CreateMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Advance CreateCollection
			var frm =
				new frmCreateCollection {
					strSvrPathWithTag = MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag,
					treeNode = trvsrvlst.SelectedNode
				};
			Common.Utility.OpenForm(frm, true, true);
			if (frm.Result) {
				DisableAllOpr();
			}
		}

		/// <summary>
		///     Create User
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmUser(false), true, true);
		}
		/// <summary>
		/// CreateRole
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddDBCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmAddRole(), true, true);
		}
		/// <summary>
		///     Eval JS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmEvalJS(), true, true);
		}

		/// <summary>
		///     Repair DataBase
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RepairDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommandHelper.ExecuteMongoCommand(CommandHelper.repairDatabase_Command);
		}

		/// <summary>
		///     Init GFS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InitGFSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MongoUtility.Basic.Utility.InitGFS(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase());
			DisableAllOpr();
			trvsrvlst.Nodes.Clear();
			var t = UIHelper.GetConnectionNodes(
				        RuntimeMongoDBContext._mongoConnSvrLst,
				        SystemManager.config.ConnectionList);
			foreach (var element in t) {
				trvsrvlst.Nodes.Add(element);
			}
		}

		/// <summary>
		///     Profilling Level
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void profillingLevelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmProfilling(), true, true);
		}

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DBStatusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmStatus(), true, true);
		}
		/// <summary>
		///     Create Js
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void creatJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strJsName = MyMessageBox.ShowInput("pls Input Javascript Name", "Save Javascript");
			if (strJsName == string.Empty)
				return;
			MongoCollection jsCol = MongoUtility.Basic.Utility.GetCurrentJsCollection(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase());
			if (QueryHelper.IsExistByKey(jsCol, strJsName)) {
				MyMessageBox.ShowMessage("Error", "javascript is already exist");
			} else {
				string Result = MongoDbHelper.CreateNewJavascript(strJsName, string.Empty, MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection());
				if (string.IsNullOrEmpty(Result)) {
					var jsNode = new TreeNode(strJsName) {
						ImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc,
						SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc
					};
					string jsTag = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
					jsNode.Tag = ConstMgr.JAVASCRIPT_DOC_TAG + ":" + jsTag + "/" + strJsName;
					trvsrvlst.SelectedNode.Nodes.Add(jsNode);
					trvsrvlst.SelectedNode = jsNode;
					MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = jsNode.Tag.ToString();
					ViewJavascript();
				} else {
					MyMessageBox.ShowMessage("Error", "Create Javascript Error", Result, true);
				}
			}
		}

		#endregion

		#region"管理：数据集"

		/// <summary>
		///     删除Mongo数据集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DelMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strTitle = "Drop Collection";
			string strMessage = "Are you sure to drop this Collection?";
			if (!SystemManager.IsUseDefaultLanguage) {
				strTitle = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Collection);
				strMessage = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Collection_Confirm);
			}
			if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
				return;
			if (!MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().DropCollection(trvsrvlst.SelectedNode.Text).Ok)
				return;
			string strNodeData = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			if (SystemManager._viewTabList.ContainsKey(strNodeData)) {
				TabPage DataTab = SystemManager._viewTabList[strNodeData];
				foreach (ToolStripMenuItem item in collectionToolStripMenuItem.DropDownItems) {
					if (item.Tag != DataTab.Tag)
						continue;
					collectionToolStripMenuItem.DropDownItems.Remove(item);
					break;
				}
				tabView.Controls.Remove(DataTab);
				SystemManager._viewTabList.Remove(strNodeData);
				SystemManager._viewInfoList.Remove(strNodeData);
				DataTab = null;
			}
			trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
			DisableAllOpr();
		}

		/// <summary>
		///     重命名数据集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RenameCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strPath = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			string strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.CollectionLv];
			string strNewCollectionName = string.Empty;
			if (SystemManager.IsUseDefaultLanguage) {
				strNewCollectionName = MyMessageBox.ShowInput("Please input new collection name：", "Rename collection",
					strCollection);
			} else {
				strNewCollectionName =
                    MyMessageBox.ShowInput(
					SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Rename_Collection_Input),
					SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Rename_Collection));
			}
			if (string.IsNullOrEmpty(strNewCollectionName) || !MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase()
                .RenameCollection(trvsrvlst.SelectedNode.Text, strNewCollectionName)
                .Ok)
				return;
			string strNodeData = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			string strNewNodeTag = MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag.Substring(0,
				                       MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag.Length - MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Name.Length);
			strNewNodeTag += strNewCollectionName;
			string strNewNodeData = Common.Utility.GetTagData(strNewNodeTag);
			if (SystemManager._viewTabList.ContainsKey(strNodeData)) {
				TabPage DataTab = SystemManager._viewTabList[strNodeData];
				foreach (ToolStripMenuItem item in collectionToolStripMenuItem.DropDownItems) {
					if (item.Tag == DataTab.Tag) {
						item.Text = strNewCollectionName;
						item.Tag = strNewNodeTag;
						break;
					}
				}
				DataTab.Text = strNewCollectionName;
				DataTab.Tag = strNewNodeTag;

				//Change trvsrvlst.SelectedNode
				SystemManager._viewTabList.Add(strNewNodeData, SystemManager._viewTabList[strNodeData]);
				SystemManager._viewTabList.Remove(strNodeData);

				SystemManager._viewInfoList.Add(strNewNodeData, SystemManager._viewInfoList[strNodeData]);
				SystemManager._viewInfoList.Remove(strNodeData);
			}
			DisableAllOpr();
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = strNewNodeTag;
			trvsrvlst.SelectedNode.Text = strNewCollectionName;
			trvsrvlst.SelectedNode.Tag = strNewNodeTag;
			trvsrvlst.SelectedNode.ToolTipText = strNewCollectionName + Environment.NewLine;
			trvsrvlst.SelectedNode.ToolTipText += "IsCapped:" +
			MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().GetStats().IsCapped;

			if (SystemManager.IsUseDefaultLanguage) {
				statusStripMain.Items[0].Text = "selected Collection:" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			} else {
				statusStripMain.Items[0].Text =
                    SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Collection) +
				":" + MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			}
		}

		/// <summary>
		///     索引管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmCollectionIndex(), true, true);
		}

		/// <summary>
		///     ReIndex
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ReIndexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().ReIndex();
		}

		/// <summary>
		///     Compact
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CompactToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CommandHelper.ExecuteMongoCommand(CommandHelper.Compact_Command);
		}

		/// <summary>
		///     Drop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dropJavascriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string Result = MongoDbHelper.DelJavascript(trvsrvlst.SelectedNode.Text, MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection());
			if (string.IsNullOrEmpty(Result)) {
				string strNodeData = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
				if (SystemManager._viewTabList.ContainsKey(strNodeData)) {
					TabPage DataTab = SystemManager._viewTabList[strNodeData];
					foreach (ToolStripMenuItem item in JavaScriptStripMenuItem.DropDownItems) {
						if (item.Tag != DataTab.Tag)
							continue;
						JavaScriptStripMenuItem.DropDownItems.Remove(item);
						break;
					}
					tabView.Controls.Remove(DataTab);
					SystemManager._viewTabList.Remove(strNodeData);
				}
				trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
				DisableAllOpr();
			} else {
				MyMessageBox.ShowMessage("Delete Error", "A error is happened when delete javascript", Result, true);
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void statusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (statusToolStripMenuItem.Checked) {
				//关闭
				tabView.Controls.Remove(tabSvrStatus);
			} else {
				//打开
				tabView.Controls.Add(tabSvrStatus);
				tabView.SelectTab(tabSvrStatus);
			}
			statusToolStripMenuItem.Checked = !statusToolStripMenuItem.Checked;
		}

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void commandShellToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (commandShellToolStripMenuItem.Checked) {
				//关闭
				tabView.Controls.Remove(tabCommandShell);
			} else {
				//打开
				tabView.Controls.Add(tabCommandShell);
				tabView.SelectTab(tabCommandShell);
			}
			commandShellToolStripMenuItem.Checked = !commandShellToolStripMenuItem.Checked;
		}

		/// <summary>
		///     CollectionStatus
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CollectionStatusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmStatus(), true, true);
		}

		/// <summary>
		///     validate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void validateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmValidate(), true, true);
		}

		/// <summary>
		///     导出到Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExportToFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string ColPath = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			Common.Utility.OpenForm(
				!SystemManager._viewInfoList.ContainsKey(ColPath) ? new frmExport() : new frmExport(SystemManager._viewInfoList[ColPath]), true,
				true);
		}

		#endregion

		#region"管理：备份和恢复"

		/// <summary>
		///     检查MongoDB执行目录是否存在
		/// </summary>
		/// <returns></returns>
		private bool MongoPathCheck()
		{
			if (MongodbDosCommand.IsMongoPathExist())
				return true;
			MyMessageBox.ShowMessage("Exception",
				"Mongo Bin Path Can't be found",
				"Mongo Bin Path[" + SystemManager.config.MongoBinPath + "]Can't be found");
			Common.Utility.OpenForm(new frmOption(), true, true);
			return false;
		}

		/// <summary>
		///     执行DOS命令
		/// </summary>
		/// <param name="DosCommand"></param>
		private void RunCommand(string DosCommand)
		{
			var Info = new StringBuilder();
			MongodbDosCommand.RunDosCommand(DosCommand, Info);
			MyMessageBox.ShowMessage("DOS", "Dos Result：", Info.ToString(), true);
		}

		/// <summary>
		///     恢复数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RestoreMongoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strTitle = "Restore";
			string strMessage = "Are you sure to Restore?";
			if (!SystemManager.IsUseDefaultLanguage) {
				strTitle =
                    SystemManager.guiConfig.MStringResource.GetText(
					StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
				strMessage = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Restore_Connection_Confirm);
			}
			if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
				return;
			if (!MongoPathCheck()) {
				return;
			}
			var MongoRestore = new MongodbDosCommand.StruMongoRestore();
			MongoServerInstance Mongosrv = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().Instance;
			MongoRestore.HostAddr = Mongosrv.Address.Host;
			MongoRestore.Port = Mongosrv.Address.Port;
			var dumpFile = new FolderBrowserDialog();
			if (dumpFile.ShowDialog() == DialogResult.OK) {
				MongoRestore.DirectoryPerDB = dumpFile.SelectedPath;
			}
			string DosCommand = MongodbDosCommand.GetMongoRestoreCommandLine(MongoRestore);
			RunCommand(DosCommand);
			RefreshToolStripMenuItem_Click(null, null);
		}

		/// <summary>
		///     Dump Database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DumpDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!MongoPathCheck()) {
				return;
			}
			var MongoDump = new MongodbDosCommand.StruMongoDump();
			MongoServerInstance Mongosrv = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().Instance;
			MongoDump.HostAddr = Mongosrv.Address.Host;
			MongoDump.Port = Mongosrv.Address.Port;
			MongoDump.DBName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name;
			var dumpFile = new FolderBrowserDialog();
			if (dumpFile.ShowDialog() == DialogResult.OK) {
				MongoDump.OutPutPath = dumpFile.SelectedPath;
			}
			string DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
			RunCommand(DosCommand);
		}

		/// <summary>
		///     Dump Collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DumpCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!MongoPathCheck()) {
				return;
			}
			var MongoDump = new MongodbDosCommand.StruMongoDump();
			MongoServerInstance Mongosrv = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().Instance;
			MongoDump.HostAddr = Mongosrv.Address.Host;
			MongoDump.Port = Mongosrv.Address.Port;
			MongoDump.DBName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name;
			MongoDump.CollectionName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Name;
			var dumpFile = new FolderBrowserDialog();
			if (dumpFile.ShowDialog() == DialogResult.OK) {
				MongoDump.OutPutPath = dumpFile.SelectedPath;
			}
			string DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
			RunCommand(DosCommand);
		}

		/// <summary>
		///     Export Collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!MongoPathCheck()) {
				return;
			}
			var MongoImportExport = new MongodbDosCommand.StruImportExport();
			MongoServerInstance Mongosrv = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().Instance;
			MongoImportExport.HostAddr = Mongosrv.Address.Host;
			MongoImportExport.Port = Mongosrv.Address.Port;
			MongoImportExport.DBName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name;
			MongoImportExport.CollectionName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Name;
			var dumpFile = new SaveFileDialog {
				Filter = Common.Utility.TxtFilter,
				CheckFileExists = false
			};
			//if the file not exist,the server will create a new one
			if (dumpFile.ShowDialog() == DialogResult.OK) {
				MongoImportExport.FileName = dumpFile.FileName;
			}
			MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Export;
			string DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
			RunCommand(DosCommand);
		}

		/// <summary>
		///     Import Collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ImportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strTitle = "Import Collection";
			string strMessage = "Are you sure to Import Collection?";
			if (!SystemManager.IsUseDefaultLanguage) {
				strTitle = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Data);
				strMessage = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
			}
			if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
				return;
			if (!MongoPathCheck()) {
				return;
			}
			var MongoImportExport = new MongodbDosCommand.StruImportExport();
			MongoServerInstance Mongosrv = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().Instance;
			MongoImportExport.HostAddr = Mongosrv.Address.Host;
			MongoImportExport.Port = Mongosrv.Address.Port;
			MongoImportExport.DBName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name;
			MongoImportExport.CollectionName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Name;
			var dumpFile = new OpenFileDialog();
			if (dumpFile.ShowDialog() == DialogResult.OK) {
				MongoImportExport.FileName = dumpFile.FileName;
			}
			MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Import;
			string DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
			RunCommand(DosCommand);
		}

		#endregion

		#region"聚合"

		/// <summary>
		///     Count
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void countToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var Query = new DataFilter();
			string ColPath = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			bool IsUseFilter = false;
			if (SystemManager._viewInfoList.ContainsKey(ColPath)) {
				Query = SystemManager._viewInfoList[ColPath].mDataFilter;
				IsUseFilter = SystemManager._viewInfoList[ColPath].IsUseFilter;
			}

			if (Query.QueryConditionList.Count == 0 || !IsUseFilter) {
				MyMessageBox.ShowEasyMessage("Count", "Count Result : " + MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Count());
			} else {
				IMongoQuery mQuery = QueryHelper.GetQuery(Query.QueryConditionList);
				MyMessageBox.ShowMessage("Count",
					"Count[With DataView Filter]:" + MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Count(mQuery),
					mQuery.ToString(), true);
			}
		}

		/// <summary>
		///     Distinct
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var Query = new DataFilter();
			string ColPath = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			bool IsUseFilter = false;
			if (SystemManager._viewInfoList.ContainsKey(ColPath)) {
				Query = SystemManager._viewInfoList[ColPath].mDataFilter;
				IsUseFilter = SystemManager._viewInfoList[ColPath].IsUseFilter;
			}
			Common.Utility.OpenForm(new frmDistinct(Query, IsUseFilter), true, true);
		}

		/// <summary>
		///     Group
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void groupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var Query = new DataFilter();
			string ColPath = MongoUtility.Core.RuntimeMongoDBContext.SelectTagData;
			bool IsUseFilter = false;
			if (SystemManager._viewInfoList.ContainsKey(ColPath)) {
				Query = SystemManager._viewInfoList[ColPath].mDataFilter;
				IsUseFilter = SystemManager._viewInfoList[ColPath].IsUseFilter;
			}
			Common.Utility.OpenForm(new frmGroup(Query, IsUseFilter), true, true);
		}

		/// <summary>
		///     MapReduce
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmMapReduce(), true, true);
		}

		/// <summary>
		///     aggregate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void aggregateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmAggregation(), true, true);
		}

		/// <summary>
		///     TextSearch
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmTextSearch(), true, true);
		}

		#endregion

		#region"工具"

		/// <summary>
		///     Options
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Common.Utility.OpenForm(new frmOption(), true, true);
			SystemManager.InitLanguage();
			if (SystemManager.IsUseDefaultLanguage) {
				MyMessageBox.ShowMessage("Language", "Language will change to \"English\" when you restart this tool");
			} else {
				SetMenuText();
			}
		}
		#endregion

		#region "Help"

		/// <summary>
		///     About
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyMessageBox.ShowMessage("About", "MagicCola",
				GetResource.GetImage(ImageType.Smile),
				new StreamReader("Release Note.txt").ReadToEnd());
		}

		/// <summary>
		///     Thanks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ThanksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strThanks = "感谢皮肤控件的作者：qianlifeng" + Environment.NewLine;
			strThanks += "感谢10gen的C# Driver开发者的技术支持" + Environment.NewLine;
			strThanks += "感谢Dragon同志的测试和代码规范化" + Environment.NewLine;
			strThanks += "感谢MoLing同志的国际化" + Environment.NewLine;
			strThanks += "感谢Cnblogs的各位网友的帮助" + Environment.NewLine;
			strThanks += "Thanks Robert Stam for C# driver support" + Environment.NewLine;
			MyMessageBox.ShowMessage("Thanks", "MagicCola",
				GetResource.GetImage(ImageType.Smile),
				strThanks);
		}

		/// <summary>
		///     userGuide
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string strUrl = @"UserGuide\index.html";
			Process.Start(strUrl);
		}
		#endregion
	}
}