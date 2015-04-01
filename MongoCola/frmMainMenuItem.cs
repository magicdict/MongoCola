using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemUtility;
using SystemUtility.Config;
using Common.UI;
using MongoCola.Aggregation;
using MongoCola.Connection;
using MongoCola.Operation;
using MongoCola.Status;
using MongoGUICtl;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoCola
{
    public partial class frmMain : Form
    {
        #region"工具"

        /// <summary>
        ///     Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmOption(), true, true);
            SystemConfig.InitLanguage();
            if (SystemConfig.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Language", "Language will change to \"English\" when you restart this tool");
            }
            else
            {
                SetMenuText();
            }
        }

        #endregion

        #region"数据库连接"

        /// <summary>
        ///     Connection Management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmConnect(), true, true);
            RefreshToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        ///     Disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RuntimeMongoDBContext.SelectTagType != ConstMgr.CONNECTION_EXCEPTION_TAG)
            {
                //关闭相关的Tab
                var CloseList = new List<string>();
                foreach (var item in _viewTabList.Keys)
                {
                    if (item.StartsWith(RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName + "/"))
                    {
                        CloseList.Add(item);
                    }
                }
                foreach (var CloseTabKey in CloseList)
                {
                    tabView.Controls.Remove(_viewTabList[CloseTabKey]);
                    _viewTabList[CloseTabKey] = null;
                    _viewTabList.Remove(CloseTabKey);
                    _viewInfoList.Remove(CloseTabKey);
                    var MenuKey = string.Empty;
                    ToolStripMenuItem CloseMenuItem = null;
                    foreach (ToolStripMenuItem menuitem in collectionToolStripMenuItem.DropDownItems)
                    {
                        MenuKey = menuitem.Tag.ToString();
                        MenuKey = MenuKey.Substring(MenuKey.IndexOf(":", StringComparison.Ordinal) + 1);
                        if (CloseTabKey == MenuKey)
                        {
                            CloseMenuItem = menuitem;
                        }
                    }
                    if (CloseMenuItem != null)
                    {
                        collectionToolStripMenuItem.DropDownItems.Remove(CloseMenuItem);
                    }
                }
                RuntimeMongoDBContext.GetCurrentServer().Disconnect();
            }
            RuntimeMongoDBContext._mongoConnSvrLst.Remove(
                RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName);
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
            var ReplSetName = MyMessageBox.ShowInput("Please Fill ReplSetName :",
                SystemConfig.IsUseDefaultLanguage
                    ? "ReplSetName"
                    : SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Replset_InitReplset));
            if (ReplSetName == string.Empty)
                return;
            var Result = CommandHelper.InitReplicaSet(ReplSetName,
                RuntimeMongoDBContext.GetCurrentServerConfig().ConnectionName, SystemConfig.config.ConnectionList);
            if (Result.Ok)
            {
                //修改配置
                var newConfig = RuntimeMongoDBContext.GetCurrentServerConfig();
                newConfig.ReplSetName = ReplSetName;
                newConfig.ReplsetList = new List<string>
                {
                    newConfig.Host +
                    (newConfig.Port != 0 ? ":" + newConfig.Port : string.Empty)
                };
                SystemConfig.config.ConnectionList[newConfig.ConnectionName] = newConfig;
                ConfigHelper.SaveToConfigFile();
                RuntimeMongoDBContext._mongoConnSvrLst.Remove(newConfig.ConnectionName);
                RuntimeMongoDBContext._mongoConnSvrLst.Add(
                    RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName,
                    RuntimeMongoDBContext.CreateMongoServer(ref newConfig));
                ServerStatusCtl.SetEnable(false);
                MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
                ServerStatusCtl.SetEnable(true);
            }
            else
            {
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
            var newConfig = RuntimeMongoDBContext.GetCurrentServerConfig();
            Utility.OpenForm(new frmReplsetMgr(ref newConfig), true, true);
            SystemConfig.config.ConnectionList[newConfig.ConnectionName] = newConfig;
            ConfigHelper.SaveToConfigFile();
            RuntimeMongoDBContext._mongoConnSvrLst.Remove(newConfig.ConnectionName);
            RuntimeMongoDBContext._mongoConnSvrLst.Add(
                RuntimeMongoDBContext._CurrentMongoConnectionconfig.ConnectionName,
                RuntimeMongoDBContext.CreateMongoServer(ref newConfig));
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
            Utility.OpenForm(new frmShardingConfig(), true, true);
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
            statusStripMain.Items[0].Text = !SystemConfig.IsUseDefaultLanguage
                ? SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready)
                : "Ready";
        }

        /// <summary>
        ///     使用异步的方法来加载连接
        /// </summary>
        /// <returns></returns>
        private async Task<int> RefreshConnectionAsync()
        {
            var ConnectionTreeNodes = new List<TreeNode>();
            await
                Task.Run(
                    () =>
                    {
                        ConnectionTreeNodes = UIHelper.GetConnectionNodes(RuntimeMongoDBContext._mongoConnSvrLst,
                            SystemConfig.config.ConnectionList);
                    });
            ServerStatusCtl.ResetCtl();
            ServerStatusCtl.RefreshStatus(false);
            //ServerStatusCtl.RefreshCurrentOpr();
            trvsrvlst.Nodes.Clear();
            foreach (var element in ConnectionTreeNodes)
            {
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
            foreach (TreeNode node in trvsrvlst.Nodes)
            {
                ExpandNode(node);
            }
            trvsrvlst.EndUpdate();
        }

        private void ExpandNode(TreeNode node)
        {
            if (node.Tag == null)
                return;
            var strNodeType = Utility.GetTagType(node.Tag.ToString());
            if (strNodeType != ConstMgr.COLLECTION_TAG && strNodeType != ConstMgr.GRID_FILE_SYSTEM_TAG)
            {
                node.Expand();
                if (node.Nodes.Count == 0)
                    return;
                foreach (TreeNode item in node.Nodes)
                {
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
            var strDBName = string.Empty;
            if (SystemConfig.IsUseDefaultLanguage)
            {
                strDBName = MyMessageBox.ShowInput("Please Input DataBaseName：", "Create Database");
            }
            else
            {
                strDBName =
                    MyMessageBox.ShowInput(
                        SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Create_New_DataBase_Input),
                        SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Create_New_DataBase));
            }
            string ErrMessage;
            RuntimeMongoDBContext.GetCurrentServer().IsDatabaseNameValid(strDBName, out ErrMessage);
            if (ErrMessage == null)
            {
                try
                {
                    var strRusult = OperationHelper.DataBaseOpration(RuntimeMongoDBContext.SelectObjectTag, strDBName,
                        OperationHelper.Oprcode.Create, RuntimeMongoDBContext.GetCurrentServer());
                    if (string.IsNullOrEmpty(strRusult))
                    {
                        DisableAllOpr();
                    }
                    else
                    {
                        MyMessageBox.ShowMessage("Error", "Create MongoDatabase", strRusult, true);
                    }
                }
                catch (ArgumentException ex)
                {
                    Utility.ExceptionDeal(ex, "Create MongoDatabase", "Argument Exception");
                }
            }
            else
            {
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
            var ConnectionName = RuntimeMongoDBContext.GetCurrentServerConfig().ConnectionName;
            var info = RuntimeMongoDBContext._mongoUserLst[ConnectionName].ToString();
            if (!string.IsNullOrEmpty(info))
            {
                MyMessageBox.ShowMessage(
                    SystemConfig.IsUseDefaultLanguage
                        ? "UserInformation"
                        : SystemConfig.guiConfig.MStringResource.GetText(
                            StringResource.TextType.Main_Menu_Operation_Server_UserInfo),
                    "The User Information of：[" +
                    SystemConfig.config.ConnectionList[ConnectionName].UserName + "]", info, true);
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
            Utility.OpenForm(new frmUser(true), true, true);
        }

        /// <summary>
        ///     Create A Role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmAddRole(), true, true);
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
            if (SystemConfig.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Server Property", "Server Property",
                    MongoUtility.Basic.Utility.GetCurrentSvrInfo(RuntimeMongoDBContext.GetCurrentServer()), true);
            }
            else
            {
                MyMessageBox.ShowMessage(
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_Server_Properties),
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_Server_Properties),
                    MongoUtility.Basic.Utility.GetCurrentSvrInfo(RuntimeMongoDBContext.GetCurrentServer()), true);
            }
        }

        /// <summary>
        ///     Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmStatus(), true, true);
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
            var strTitle = "Drop Database";
            var strMessage = "Are you really want to Drop current Database?";
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                strTitle = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_DataBase);
                strMessage =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_DataBase_Confirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            var strPath = RuntimeMongoDBContext.SelectTagData;
            var strDBName = strPath.Split("/".ToCharArray())[(int) EnumMgr.PathLv.DatabaseLv];
            if (trvsrvlst.SelectedNode == null)
            {
                trvsrvlst.SelectedNode = null;
            }
            var rtnResult = OperationHelper.DataBaseOpration(RuntimeMongoDBContext.SelectObjectTag, strDBName,
                OperationHelper.Oprcode.Drop, RuntimeMongoDBContext.GetCurrentServer());
            if (string.IsNullOrEmpty(rtnResult))
            {
                DisableAllOpr();
                //关闭所有的相关视图
                //foreach不能直接修改，需要一个备份
                var tempTable = new Dictionary<string, TabPage>();
                foreach (var item in _viewTabList.Keys)
                {
                    tempTable.Add(item, _viewTabList[item]);
                }

                foreach (var KeyItem in tempTable.Keys)
                {
                    //如果有相同的前缀
                    if (KeyItem.StartsWith(strPath))
                    {
                        ToolStripMenuItem DataMenuItem = null;
                        foreach (ToolStripMenuItem Menuitem in collectionToolStripMenuItem.DropDownItems)
                        {
                            //菜单的寻找
                            if (Menuitem.Tag == _viewTabList[KeyItem].Tag)
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
                        tabView.Controls.Remove(_viewTabList[KeyItem]);
                        _viewTabList.Remove(KeyItem);
                        _viewInfoList.Remove(KeyItem);
                        _viewTabList[KeyItem] = null;
                    }
                }
                tempTable = null;
            }
            else
            {
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
                new frmCreateCollection
                {
                    strSvrPathWithTag = RuntimeMongoDBContext.SelectObjectTag,
                    treeNode = trvsrvlst.SelectedNode
                };
            Utility.OpenForm(frm, true, true);
            if (frm.Result)
            {
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
            Utility.OpenForm(new frmUser(false), true, true);
        }

        /// <summary>
        ///     CreateRole
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDBCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmAddRole(), true, true);
        }

        /// <summary>
        ///     Eval JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmEvalJS(), true, true);
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
            MongoUtility.Basic.Utility.InitGFS(RuntimeMongoDBContext.GetCurrentDataBase());
            DisableAllOpr();
            trvsrvlst.Nodes.Clear();
            var t = UIHelper.GetConnectionNodes(
                RuntimeMongoDBContext._mongoConnSvrLst,
                SystemConfig.config.ConnectionList);
            foreach (var element in t)
            {
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
            Utility.OpenForm(new frmProfilling(), true, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmStatus(), true, true);
        }

        /// <summary>
        ///     Create Js
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creatJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strJsName = MyMessageBox.ShowInput("pls Input Javascript Name", "Save Javascript");
            if (strJsName == string.Empty)
                return;
            var jsCol = MongoUtility.Basic.Utility.GetCurrentJsCollection(RuntimeMongoDBContext.GetCurrentDataBase());
            if (QueryHelper.IsExistByKey(jsCol, strJsName))
            {
                MyMessageBox.ShowMessage("Error", "javascript is already exist");
            }
            else
            {
                var Result = OperationHelper.CreateNewJavascript(strJsName, string.Empty,
                    RuntimeMongoDBContext.GetCurrentCollection());
                if (string.IsNullOrEmpty(Result))
                {
                    var jsNode = new TreeNode(strJsName)
                    {
                        ImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc,
                        SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc
                    };
                    var jsTag = RuntimeMongoDBContext.SelectTagData;
                    jsNode.Tag = ConstMgr.JAVASCRIPT_DOC_TAG + ":" + jsTag + "/" + strJsName;
                    trvsrvlst.SelectedNode.Nodes.Add(jsNode);
                    trvsrvlst.SelectedNode = jsNode;
                    RuntimeMongoDBContext.SelectObjectTag = jsNode.Tag.ToString();
                    ViewJavascript();
                }
                else
                {
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
            var strTitle = "Drop Collection";
            var strMessage = "Are you sure to drop this Collection?";
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                strTitle = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Collection);
                strMessage =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Collection_Confirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            if (!RuntimeMongoDBContext.GetCurrentDataBase().DropCollection(trvsrvlst.SelectedNode.Text).Ok)
                return;
            var strNodeData = RuntimeMongoDBContext.SelectTagData;
            if (_viewTabList.ContainsKey(strNodeData))
            {
                var DataTab = _viewTabList[strNodeData];
                foreach (ToolStripMenuItem item in collectionToolStripMenuItem.DropDownItems)
                {
                    if (item.Tag != DataTab.Tag)
                        continue;
                    collectionToolStripMenuItem.DropDownItems.Remove(item);
                    break;
                }
                tabView.Controls.Remove(DataTab);
                _viewTabList.Remove(strNodeData);
                _viewInfoList.Remove(strNodeData);
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
            var strPath = RuntimeMongoDBContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int) EnumMgr.PathLv.CollectionLv];
            var strNewCollectionName = string.Empty;
            if (SystemConfig.IsUseDefaultLanguage)
            {
                strNewCollectionName = MyMessageBox.ShowInput(
                    "Please input new collection name：",
                    "Rename collection", strCollection);
            }
            else
            {
                strNewCollectionName = MyMessageBox.ShowInput(
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Rename_Collection_Input),
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Rename_Collection),
                    strCollection);
            }
            if (string.IsNullOrEmpty(strNewCollectionName)) return;
            var result =
                RuntimeMongoDBContext.GetCurrentDataBase()
                    .RenameCollection(trvsrvlst.SelectedNode.Text, strNewCollectionName)
                    .Ok;
            if (!result) return;
            var strNodeData = RuntimeMongoDBContext.SelectTagData;
            var strNewNodeTag = RuntimeMongoDBContext.SelectObjectTag.Substring(0,
                RuntimeMongoDBContext.SelectObjectTag.Length - RuntimeMongoDBContext.GetCurrentCollection().Name.Length);
            strNewNodeTag += strNewCollectionName;
            var strNewNodeData = Utility.GetTagData(strNewNodeTag);
            if (_viewTabList.ContainsKey(strNodeData))
            {
                var DataTab = _viewTabList[strNodeData];
                foreach (ToolStripMenuItem item in collectionToolStripMenuItem.DropDownItems)
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
                _viewTabList.Add(strNewNodeData, _viewTabList[strNodeData]);
                _viewTabList.Remove(strNodeData);

                _viewInfoList.Add(strNewNodeData, _viewInfoList[strNodeData]);
                _viewInfoList.Remove(strNodeData);
            }
            DisableAllOpr();
            RuntimeMongoDBContext.SelectObjectTag = strNewNodeTag;
            trvsrvlst.SelectedNode.Text = strNewCollectionName;
            trvsrvlst.SelectedNode.Tag = strNewNodeTag;
            trvsrvlst.SelectedNode.ToolTipText = strNewCollectionName + Environment.NewLine;
            trvsrvlst.SelectedNode.ToolTipText += "IsCapped:" +
                                                  RuntimeMongoDBContext.GetCurrentCollection().GetStats().IsCapped;

            if (SystemConfig.IsUseDefaultLanguage)
            {
                statusStripMain.Items[0].Text = "selected Collection:" + RuntimeMongoDBContext.SelectTagData;
            }
            else
            {
                statusStripMain.Items[0].Text =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Selected_Collection) +
                    ":" + RuntimeMongoDBContext.SelectTagData;
            }
        }

        /// <summary>
        ///     索引管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmCollectionIndex(), true, true);
        }

        /// <summary>
        ///     ReIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RuntimeMongoDBContext.GetCurrentCollection().ReIndex();
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
            var Result = OperationHelper.DelJavascript(trvsrvlst.SelectedNode.Text,
                RuntimeMongoDBContext.GetCurrentCollection());
            if (string.IsNullOrEmpty(Result))
            {
                var strNodeData = RuntimeMongoDBContext.SelectTagData;
                if (_viewTabList.ContainsKey(strNodeData))
                {
                    var DataTab = _viewTabList[strNodeData];
                    foreach (ToolStripMenuItem item in JavaScriptStripMenuItem.DropDownItems)
                    {
                        if (item.Tag != DataTab.Tag)
                            continue;
                        JavaScriptStripMenuItem.DropDownItems.Remove(item);
                        break;
                    }
                    tabView.Controls.Remove(DataTab);
                    _viewTabList.Remove(strNodeData);
                }
                trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
                DisableAllOpr();
            }
            else
            {
                MyMessageBox.ShowMessage("Delete Error", "A error is happened when delete javascript", Result, true);
            }
        }

        /// <summary>
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
        ///     CollectionStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectionStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmStatus(), true, true);
        }

        /// <summary>
        ///     validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmValidate(), true, true);
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ColPath = RuntimeMongoDBContext.SelectTagData;
            Utility.OpenForm(
                !_viewInfoList.ContainsKey(ColPath) ? new frmExport() : new frmExport(_viewInfoList[ColPath]), true,
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
            if (Directory.Exists(SystemConfig.config.MongoBinPath)) return true;
            MyMessageBox.ShowMessage("Exception",
                "Mongo Bin Path Can't be found",
                "Mongo Bin Path[" + SystemConfig.config.MongoBinPath + "]Can't be found");
            Utility.OpenForm(new frmOption(), true, true);
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
            var strTitle = "Restore";
            var strMessage = "Are you sure to Restore?";
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                strTitle =
                    SystemConfig.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
                strMessage =
                    SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Restore_Connection_Confirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            if (!MongoPathCheck())
            {
                return;
            }
            var MongoRestore = new MongodbDosCommand.StruMongoRestore();
            var Mongosrv = RuntimeMongoDBContext.GetCurrentServer().Instance;
            MongoRestore.HostAddr = Mongosrv.Address.Host;
            MongoRestore.Port = Mongosrv.Address.Port;
            var dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                MongoRestore.DirectoryPerDB = dumpFile.SelectedPath;
            }
            var DosCommand = MongodbDosCommand.GetMongoRestoreCommandLine(MongoRestore);
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
            if (!MongoPathCheck())
            {
                return;
            }
            var MongoDump = new MongodbDosCommand.StruMongoDump();
            var Mongosrv = RuntimeMongoDBContext.GetCurrentServer().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = RuntimeMongoDBContext.GetCurrentDataBase().Name;
            var dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            var DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            RunCommand(DosCommand);
        }

        /// <summary>
        ///     Dump Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck())
            {
                return;
            }
            var MongoDump = new MongodbDosCommand.StruMongoDump();
            var Mongosrv = RuntimeMongoDBContext.GetCurrentServer().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = RuntimeMongoDBContext.GetCurrentDataBase().Name;
            MongoDump.CollectionName = RuntimeMongoDBContext.GetCurrentCollection().Name;
            var dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            var DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            RunCommand(DosCommand);
        }

        /// <summary>
        ///     ExportImport Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongoPathCheck())
            {
                return;
            }
            var MongoImportExport = new MongodbDosCommand.StruImportExport();
            var Mongosrv = RuntimeMongoDBContext.GetCurrentServer().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = RuntimeMongoDBContext.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = RuntimeMongoDBContext.GetCurrentCollection().Name;
            var dumpFile = new SaveFileDialog
            {
                Filter = Utility.TxtFilter,
                CheckFileExists = false
            };
            //if the file not exist,the server will create a new one
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                MongoImportExport.FileName = dumpFile.FileName;
            }
            MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Export;
            var DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
            RunCommand(DosCommand);
        }

        /// <summary>
        ///     Import Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strTitle = "Import Collection";
            var strMessage = "Are you sure to Import Collection?";
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                strTitle = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            if (!MongoPathCheck())
            {
                return;
            }
            var MongoImportExport = new MongodbDosCommand.StruImportExport();
            var Mongosrv = RuntimeMongoDBContext.GetCurrentServer().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = RuntimeMongoDBContext.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = RuntimeMongoDBContext.GetCurrentCollection().Name;
            var dumpFile = new OpenFileDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                MongoImportExport.FileName = dumpFile.FileName;
            }
            MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Import;
            var DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
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
            var ColPath = RuntimeMongoDBContext.SelectTagData;
            var IsUseFilter = false;
            if (_viewInfoList.ContainsKey(ColPath))
            {
                Query = _viewInfoList[ColPath].mDataFilter;
                IsUseFilter = _viewInfoList[ColPath].IsUseFilter;
            }

            if (Query.QueryConditionList.Count == 0 || !IsUseFilter)
            {
                MyMessageBox.ShowEasyMessage("Count",
                    "Count Result : " + RuntimeMongoDBContext.GetCurrentCollection().Count());
            }
            else
            {
                var mQuery = QueryHelper.GetQuery(Query.QueryConditionList);
                MyMessageBox.ShowMessage("Count",
                    "Count[With DataView Filter]:" + RuntimeMongoDBContext.GetCurrentCollection().Count(mQuery),
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
            var ColPath = RuntimeMongoDBContext.SelectTagData;
            var IsUseFilter = false;
            if (_viewInfoList.ContainsKey(ColPath))
            {
                Query = _viewInfoList[ColPath].mDataFilter;
                IsUseFilter = _viewInfoList[ColPath].IsUseFilter;
            }
            Utility.OpenForm(new frmDistinct(Query, IsUseFilter), true, true);
        }

        /// <summary>
        ///     Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Query = new DataFilter();
            var ColPath = RuntimeMongoDBContext.SelectTagData;
            var IsUseFilter = false;
            if (_viewInfoList.ContainsKey(ColPath))
            {
                Query = _viewInfoList[ColPath].mDataFilter;
                IsUseFilter = _viewInfoList[ColPath].IsUseFilter;
            }
            Utility.OpenForm(new frmGroup(Query, IsUseFilter), true, true);
        }

        /// <summary>
        ///     MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmMapReduce(), true, true);
        }

        /// <summary>
        ///     aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aggregateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmAggregation(), true, true);
        }

        /// <summary>
        ///     TextSearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new frmTextSearch(), true, true);
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
            var strThanks = "感谢皮肤控件的作者：qianlifeng" + Environment.NewLine;
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
            var strUrl = @"UserGuide\index.html";
            Process.Start(strUrl);
        }

        #endregion
    }
}