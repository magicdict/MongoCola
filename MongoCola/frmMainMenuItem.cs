using Common;
using FunctionForm.Aggregation;
using FunctionForm.Misc;
using FunctionForm.Operation;
using FunctionForm.Status;
using MongoCola.Config;
using MongoCola.Connection;
using MongoGUICtl.ClientTree;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoCola
{
    public partial class FrmMain
    {
        #region"工具"

        /// <summary>
        ///     Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmOption(), true, true);
            SystemManager.InitLanguage();
            if (GuiConfig.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Language", "Language will change to \"English\" when you restart this tool");
            }
            else
            {
                GuiConfig.Translateform(this);
                if (!GuiConfig.IsUseDefaultLanguage)
                {
                    //其他控件
                    statusStripMain.Items[0].Text =
                        GuiConfig.GetText(TextType.MainStatusBarTextReady);
                    tabSvrStatus.Text =
                        GuiConfig.GetText(TextType.Main_Menu_Mangt_Status);
                }
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
            Utility.OpenForm(new FrmConnect(), true, true);
            RefreshToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        ///     Disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RuntimeMongoDbContext.SelectTagType != ConstMgr.ConnectionExceptionTag)
            {
                //关闭相关的Tab
                var closeList = new List<string>();
                foreach (var item in MutliTabManger.TabInfo.Keys)
                {
                    if (item.StartsWith(RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName + "/"))
                    {
                        closeList.Add(item);
                    }
                }
                foreach (var closeTabKey in closeList)
                {
                    tabView.Controls.Remove(MutliTabManger.TabInfo[closeTabKey].Tab);
                    MutliTabManger.RemoveTab(closeTabKey);
                    ToolStripMenuItem closeMenuItem = null;
                    foreach (ToolStripMenuItem menuitem in collectionToolStripMenuItem.DropDownItems)
                    {
                        var menuKey = menuitem.Tag.ToString();
                        menuKey = menuKey.Substring(menuKey.IndexOf(":", StringComparison.Ordinal) + 1);
                        if (closeTabKey == menuKey)
                        {
                            closeMenuItem = menuitem;
                        }
                    }
                    if (closeMenuItem != null)
                    {
                        collectionToolStripMenuItem.DropDownItems.Remove(closeMenuItem);
                    }
                }
                //RuntimeMongoDbContext.GetCurrentServer().Disconnect();
            }
            RuntimeMongoDbContext.RemoveConnectionConfig(RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName);
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
            var replSetName = MyMessageBox.ShowInput("Please Fill ReplSetName :", GuiConfig.GetText("ReplSetName", TextType.ReplsetInitReplset));
            if (replSetName == string.Empty) return;
            string result = string.Empty;
            if (Operater.InitReplicaSet(replSetName, ref result))
            {
                ServerStatusCtl.SetEnable(false);
                MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
                ServerStatusCtl.SetEnable(true);
            }
            else
            {
                MyMessageBox.ShowMessage("ReplSetName", "Failed", result);
            }
        }

        /// <summary>
        ///     副本管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newConfig = RuntimeMongoDbContext.GetCurrentServerConfig();
            Utility.OpenForm(new FrmReplsetMgr(ref newConfig), true, true);
            Operater.ReplicaSet(newConfig);
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
            Utility.OpenForm(new FrmShardingConfig(), true, true);
        }

        /// <summary>
        ///     刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAllOpr();
            var result = await RefreshConnectionAsync();
            RefreshToolStripMenuItem.Enabled = false;
            RefreshToolStripButton.Enabled = false;
            if (result == -1)
            {
                trvsrvlst.Nodes.Clear();
                trvsrvlst.Nodes.Add("丢失与数据库的连接！");
            }
            else
            {
                RefreshToolStripMenuItem.Enabled = true;
                RefreshToolStripButton.Enabled = true;
            }
            statusStripMain.Items[0].Text = GuiConfig.GetText("Ready", TextType.MainStatusBarTextReady);
        }

        /// <summary>
        ///     使用异步的方法来加载连接
        /// </summary>
        /// <returns></returns>
        private async Task<int> RefreshConnectionAsync()
        {
            try
            {
                var connectionTreeNodes = new List<TreeNode>();
                await
                    Task.Run(() =>
                    {
                        connectionTreeNodes = UIHelper.GetConnectionNodes();
                    });
                //如果第一个节点的字节点不为空
                if (connectionTreeNodes != null)
                {
                    ServerStatusCtl.ResetCtl();
                    ServerStatusCtl.RefreshStatus(false);
                    //ServerStatusCtl.RefreshCurrentOpr();
                    trvsrvlst.Nodes.Clear();
                    foreach (var element in connectionTreeNodes)
                    {
                        trvsrvlst.Nodes.Add(element);
                    }
                }
                else
                {
                    return -1;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
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
            if (node.Tag == null) return;
            var strNodeType = Utility.GetTagType(node.Tag.ToString());
            if (strNodeType != ConstMgr.CollectionTag && strNodeType != ConstMgr.GridFileSystemTag)
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
            string strDbName;
            if (GuiConfig.IsUseDefaultLanguage)
            {
                strDbName = MyMessageBox.ShowInput("Please Input DataBaseName：", "Create Database");
            }
            else
            {
                strDbName =
                    MyMessageBox.ShowInput(
                        GuiConfig.GetText(TextType.CreateNewDataBaseInput),
                        GuiConfig.GetText(TextType.CreateNewDataBase));
            }
            string errMessage;
            if (Operater.IsDatabaseNameValid(strDbName, out errMessage))
            {
                try
                {
                    var strRusult = OperationHelper.DataBaseOpration(RuntimeMongoDbContext.SelectObjectTag, strDbName, OperationHelper.Oprcode.Create);
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
                MyMessageBox.ShowMessage("Create MongoDatabase", "Argument Exception", errMessage, true);
            }
        }

        /// <summary>
        ///     copyDatabase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyDatabasetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MongoHelper.Core.RuntimeMongoDBContext.GetCurrentServer().CopyDatabase(MongoHelper.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name, MongoHelper.Core.RuntimeMongoDBContext.GetCurrentDataBase().Name + "_Backup");
            //MongoDBHelper.ExecuteMongoDBCommand("copyDatabase", MongoHelper.Core.RuntimeMongoDBContext.GetCurrentDataBase());
            //CommandDocument copy = new CommandDocument();
            //MongoHelper.Core.RuntimeMongoDBContext.GetCurrentDataBase().RunCommand("copyDatabase");
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
            var connectionName = RuntimeMongoDbContext.GetCurrentServerConfig().ConnectionName;
            var info = RuntimeMongoDbContext.MongoUserLst[connectionName].ToString();
            if (!string.IsNullOrEmpty(info))
            {
                MyMessageBox.ShowMessage(
                    GuiConfig.IsUseDefaultLanguage
                        ? "UserInformation"
                        : GuiConfig.GetText(TextType.Main_Menu_Operation_Server_UserInfo),
                    "The User Information of：[" +
                    MongoConnectionConfig.MongoConfig.ConnectionList[connectionName].UserName + "]", info, true);
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
            Utility.OpenForm(new FrmUser(true), true, true);
        }

        /// <summary>
        ///     Create A Role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmAddRole(), true, true);
        }

        /// <summary>
        ///     SlaveResync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slaveResyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operater.ResyncCommand();
        }

        /// <summary>
        ///     Server Info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GuiConfig.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Server Property", "Server Property",
                    MongoHelper.GetCurrentSvrInfo(), true);
            }
            else
            {
                MyMessageBox.ShowMessage(
                    GuiConfig.GetText(TextType.Main_Menu_Operation_Server_Properties),
                    GuiConfig.GetText(TextType.Main_Menu_Operation_Server_Properties),
                    MongoHelper.GetCurrentSvrInfo(), true);
            }
        }

        /// <summary>
        ///     Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmStatus(), true, true);
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
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.DropDataBase);
                strMessage =
                    GuiConfig.GetText(TextType.DropDataBaseConfirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strDbName = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.DatabaseLv];
            if (trvsrvlst.SelectedNode == null)
            {
                trvsrvlst.SelectedNode = null;
            }
            var rtnResult = OperationHelper.DataBaseOpration(RuntimeMongoDbContext.SelectObjectTag, strDbName, OperationHelper.Oprcode.Drop);
            if (string.IsNullOrEmpty(rtnResult))
            {
                DisableAllOpr();
                //关闭所有的相关视图
                //foreach不能直接修改，需要一个备份
                var tempTable = new Dictionary<string, TabPage>();
                foreach (var item in MutliTabManger.TabInfo.Keys)
                {
                    tempTable.Add(item, MutliTabManger.TabInfo[item].Tab);
                }

                foreach (var keyItem in tempTable.Keys)
                {
                    //如果有相同的前缀
                    if (keyItem.StartsWith(strPath))
                    {
                        ToolStripMenuItem dataMenuItem = null;
                        foreach (ToolStripMenuItem menuitem in collectionToolStripMenuItem.DropDownItems)
                        {
                            //菜单的寻找
                            if (menuitem.Tag == MutliTabManger.TabInfo[keyItem].Tab.Tag)
                            {
                                dataMenuItem = menuitem;
                            }
                        }
                        if (dataMenuItem != null)
                        {
                            //菜单的删除
                            collectionToolStripMenuItem.DropDownItems.Remove(dataMenuItem);
                        }
                        //TabPage的删除
                        tabView.Controls.Remove(MutliTabManger.TabInfo[keyItem].Tab);
                        MutliTabManger.TabInfo.Remove(keyItem);
                    }
                }
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
                new FrmCreateCollection
                {
                    StrSvrPathWithTag = RuntimeMongoDbContext.SelectObjectTag,
                    TreeNode = trvsrvlst.SelectedNode
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
            Utility.OpenForm(new FrmUser(false), true, true);
        }

        /// <summary>
        ///     CreateRole
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDBCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmAddRole(), true, true);
        }

        /// <summary>
        ///     Eval JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmEvalJs(), true, true);
        }

        /// <summary>
        ///     Repair DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepairDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operater.RepairDb();
        }

        /// <summary>
        ///     Init GFS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitGFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoHelper.InitGfs();
            DisableAllOpr();
            trvsrvlst.Nodes.Clear();
            var connectNodes = UIHelper.GetConnectionNodes();
            foreach (var element in connectNodes)
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
            Utility.OpenForm(new FrmProfilling(), true, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmStatus(), true, true);
        }

        /// <summary>
        ///     Create Js
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creatJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strJsName = MyMessageBox.ShowInput("pls Input Javascript Name", "Save Javascript");
            if (strJsName == string.Empty) return;
            if (QueryHelper.IsExistByKey(strJsName))
            {
                MyMessageBox.ShowMessage("Error", "javascript is already exist");
            }
            else
            {
                var result = OperationHelper.CreateNewJavascript(strJsName, string.Empty);
                if (string.IsNullOrEmpty(result))
                {
                    var jsNode = new TreeNode(strJsName)
                    {
                        ImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc,
                        SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc
                    };
                    var jsTag = RuntimeMongoDbContext.SelectTagData;
                    jsNode.Tag = ConstMgr.JavascriptDocTag + ":" + jsTag + "/" + strJsName;
                    trvsrvlst.SelectedNode.Nodes.Add(jsNode);
                    trvsrvlst.SelectedNode = jsNode;
                    RuntimeMongoDbContext.SelectObjectTag = jsNode.Tag.ToString();
                    ViewJavascript();
                }
                else
                {
                    MyMessageBox.ShowMessage("Error", "Create Javascript Error", result, true);
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
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.DropCollection);
                strMessage =
                    GuiConfig.GetText(TextType.DropCollectionConfirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage)) return;
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.CollectionLv];
            if (!OperationHelper.DrapCollection(strCollection)) return;
            var strNodeData = RuntimeMongoDbContext.SelectTagData;
            if (MutliTabManger.TabInfo.ContainsKey(strNodeData))
            {
                var dataTab = MutliTabManger.TabInfo[strNodeData].Tab;
                foreach (ToolStripMenuItem item in collectionToolStripMenuItem.DropDownItems)
                {
                    if (item.Tag != dataTab.Tag)
                        continue;
                    collectionToolStripMenuItem.DropDownItems.Remove(item);
                    break;
                }
                tabView.Controls.Remove(dataTab);
                MutliTabManger.RemoveTab(strNodeData);
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
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.CollectionLv];
            string strNewCollectionName;
            if (GuiConfig.IsUseDefaultLanguage)
            {
                strNewCollectionName = MyMessageBox.ShowInput(
                    "Please input new collection name：",
                    "Rename collection", strCollection);
            }
            else
            {
                strNewCollectionName = MyMessageBox.ShowInput(
                    GuiConfig.GetText(TextType.RenameCollectionInput),
                    GuiConfig.GetText(TextType.RenameCollection),
                    strCollection);
            }
            if (string.IsNullOrEmpty(strNewCollectionName)) return;
            if (!OperationHelper.RenameCollection(strCollection, strNewCollectionName)) return;
            var strOldNodeTag = RuntimeMongoDbContext.SelectTagData;
            var strNewNodeTag = RuntimeMongoDbContext.SelectObjectTag.Substring(0,
                RuntimeMongoDbContext.SelectObjectTag.Length - RuntimeMongoDbContext.GetCurrentCollectionName().Length);
            strNewNodeTag += strNewCollectionName;
            var strNewNodeData = Utility.GetTagData(strNewNodeTag);
            if (MutliTabManger.TabInfo.ContainsKey(strOldNodeTag))
            {
                var dataTab = MutliTabManger.TabInfo[strOldNodeTag].Tab;
                foreach (ToolStripMenuItem item in collectionToolStripMenuItem.DropDownItems)
                {
                    if (item.Tag == dataTab.Tag)
                    {
                        item.Text = strNewCollectionName;
                        item.Tag = strNewNodeTag;
                        break;
                    }
                }
                dataTab.Text = strNewCollectionName;
                dataTab.Tag = strNewNodeTag;

                //Change trvsrvlst.SelectedNode
                MutliTabManger.ChangeKey(strNewNodeData, strOldNodeTag);
            }
            DisableAllOpr();
            RuntimeMongoDbContext.SelectObjectTag = strNewNodeTag;
            trvsrvlst.SelectedNode.Text = strNewCollectionName;
            trvsrvlst.SelectedNode.Tag = strNewNodeTag;
            trvsrvlst.SelectedNode.ToolTipText = strNewCollectionName + Environment.NewLine;
            trvsrvlst.SelectedNode.ToolTipText += "IsCapped:" + RuntimeMongoDbContext.GetCurrentCollectionIsCapped();

            if (GuiConfig.IsUseDefaultLanguage)
            {
                statusStripMain.Items[0].Text = "selected Collection:" + RuntimeMongoDbContext.SelectTagData;
            }
            else
            {
                statusStripMain.Items[0].Text =
                    GuiConfig.GetText(TextType.SelectedCollection) +
                    ":" + RuntimeMongoDbContext.SelectTagData;
            }
        }

        /// <summary>
        ///     索引管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmCollectionIndex(), true, true);
        }

        /// <summary>
        ///     ReIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operater.ReIndex();
        }

        /// <summary>
        ///     Compact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operater.Compact();
        }

        /// <summary>
        ///     Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropJavascriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLv.CollectionLv];
            var result = OperationHelper.DelJavascript(strCollection);
            if (string.IsNullOrEmpty(result))
            {
                var strNodeData = RuntimeMongoDbContext.SelectTagData;
                if (MutliTabManger.TabInfo.ContainsKey(strNodeData))
                {
                    var dataTab = MutliTabManger.TabInfo[strNodeData].Tab;
                    foreach (ToolStripMenuItem item in JavaScriptStripMenuItem.DropDownItems)
                    {
                        if (item.Tag != dataTab.Tag)
                            continue;
                        JavaScriptStripMenuItem.DropDownItems.Remove(item);
                        break;
                    }
                    tabView.Controls.Remove(dataTab);
                    MutliTabManger.RemoveTab(strNodeData);
                }
                trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
                DisableAllOpr();
            }
            else
            {
                MyMessageBox.ShowMessage("Delete Error", "A error is happened when delete javascript", result, true);
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
            Utility.OpenForm(new FrmStatus(), true, true);
        }

        /// <summary>
        ///     validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmValidate(), true, true);
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colPath = RuntimeMongoDbContext.SelectTagData;
            Utility.OpenForm(!MutliTabManger.TabInfo.ContainsKey(colPath)
                ? new FrmExport()
                : new FrmExport(MutliTabManger.TabInfo[colPath].Info), true, true);
        }

        #endregion

        #region"管理：备份和恢复"

        /// <summary>
        ///     检查MongoDB执行目录是否存在
        /// </summary>
        /// <returns></returns>
        private bool MongoPathCheck()
        {
            if (Directory.Exists(SystemManager.SystemConfig.MongoBinPath)) return true;
            MyMessageBox.ShowMessage("Exception",
                "Mongo Bin Path Can't be found",
                "Mongo Bin Path[" + SystemManager.SystemConfig.MongoBinPath + "]Can't be found");
            Utility.OpenForm(new FrmOption(), true, true);
            return false;
        }

        /// <summary>
        ///     执行DOS命令
        /// </summary>
        /// <param name="dosCommand"></param>
        private void RunCommand(string dosCommand)
        {
            var info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(dosCommand, info);
            MyMessageBox.ShowMessage("DOS", "Dos Result：", info.ToString(), true);
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
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.Main_Menu_Operation_BackupAndRestore_Restore);
                strMessage = GuiConfig.GetText(TextType.RestoreConnectionConfirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            if (!MongoPathCheck())
            {
                return;
            }
            var mongoRestore = MongoRestoreInfo.GetMongoRestoreInfo();
            var dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                mongoRestore.DirectoryPerDb = dumpFile.SelectedPath;
            }
            var dosCommand = MongoRestoreInfo.GetMongoRestoreCommandLine(mongoRestore);
            RunCommand(dosCommand);
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
            var mongoDump = MongoDumpInfo.GetMongoDump(true);
            var dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                mongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            var dosCommand = MongoDumpInfo.GetMongodumpCommandLine(mongoDump);
            RunCommand(dosCommand);
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
            var mongoDump = MongoDumpInfo.GetMongoDump(false);
            var dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == DialogResult.OK)
            {
                mongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            var dosCommand = MongoDumpInfo.GetMongodumpCommandLine(mongoDump);
            RunCommand(dosCommand);
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
            var mongoImportExport = MongoImportExportInfo.GetImportExportInfo();
            var exportCol = new SaveFileDialog
            {
                Filter = Utility.TxtFilter,
                CheckFileExists = false
            };
            //if the file not exist,the server will create a new one
            if (exportCol.ShowDialog() == DialogResult.OK)
            {
                mongoImportExport.FileName = exportCol.FileName;
            }
            mongoImportExport.Direct = MongoImportExportInfo.ImprotExport.Export;
            var dosCommand = MongoImportExportInfo.GetMongoImportExportCommandLine(mongoImportExport);
            RunCommand(dosCommand);
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
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.DropData);
                strMessage = GuiConfig.GetText(TextType.DropDataConfirm);
            }
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage))
                return;
            if (!MongoPathCheck())
            {
                return;
            }
            var mongoImportExport = MongoImportExportInfo.GetImportExportInfo();
            var importCol = new OpenFileDialog();
            if (importCol.ShowDialog() == DialogResult.OK)
            {
                mongoImportExport.FileName = importCol.FileName;
            }
            mongoImportExport.Direct = MongoImportExportInfo.ImprotExport.Import;
            var dosCommand = MongoImportExportInfo.GetMongoImportExportCommandLine(mongoImportExport);
            RunCommand(dosCommand);
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
            var query = new DataFilter();
            var colPath = RuntimeMongoDbContext.SelectTagData;
            var isUseFilter = false;
            if (MutliTabManger.TabInfo.ContainsKey(colPath))
            {
                query = MutliTabManger.TabInfo[colPath].Info.MDataFilter;
                isUseFilter = MutliTabManger.TabInfo[colPath].Info.IsUseFilter;
            }

            if (query.QueryConditionList.Count == 0 || !isUseFilter)
            {
                MyMessageBox.ShowEasyMessage("Count", "Count Result : " + QueryHelper.GetCurrentCollectionCount(null));
            }
            else
            {
                MyMessageBox.ShowMessage("Count", "Count[With DataView Filter]:" + QueryHelper.GetCurrentCollectionCount(query));
            }
        }

        /// <summary>
        ///     Distinct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = new DataFilter();
            var colPath = RuntimeMongoDbContext.SelectTagData;
            var isUseFilter = false;
            if (MutliTabManger.TabInfo.ContainsKey(colPath))
            {
                query = MutliTabManger.TabInfo[colPath].Info.MDataFilter;
                isUseFilter = MutliTabManger.TabInfo[colPath].Info.IsUseFilter;
            }
            Utility.OpenForm(new FrmDistinct(query, isUseFilter), true, true);
        }

        /// <summary>
        ///     Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var query = new DataFilter();
            var colPath = RuntimeMongoDbContext.SelectTagData;
            var isUseFilter = false;
            if (MutliTabManger.TabInfo.ContainsKey(colPath))
            {
                query = MutliTabManger.TabInfo[colPath].Info.MDataFilter;
                isUseFilter = MutliTabManger.TabInfo[colPath].Info.IsUseFilter;
            }
            Utility.OpenForm(new FrmGroup(query, isUseFilter), true, true);
        }

        /// <summary>
        ///     MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmMapReduce(), true, true);
        }

        /// <summary>
        ///     aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aggregateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmAggregation(), true, true);
        }

        /// <summary>
        ///     TextSearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmTextSearch(), true, true);
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