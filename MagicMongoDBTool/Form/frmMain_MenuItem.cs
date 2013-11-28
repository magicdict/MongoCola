using MagicMongoDBTool.Module;
using MagicMongoDBTool.UnitTest;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {
        #region"数据库连接"
        /// <summary>
        /// Connection Management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmConnect(), true, true);
            RefreshToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// Disconnect 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.SelectTagType != MongoDBHelper.CONNECTION_EXCEPTION_TAG)
            {
                //关闭相关的Tab
                List<String> CloseList = new List<string>();
                foreach (var item in ViewTabList.Keys)
                {
                    if (item.StartsWith(config.ConnectionName + "/"))
                    {
                        CloseList.Add(item);
                    }
                }
                foreach (String CloseTabKey in CloseList)
                {
                    tabView.Controls.Remove(ViewTabList[CloseTabKey]);
                    ViewTabList[CloseTabKey] = null;
                    ViewTabList.Remove(CloseTabKey);
                    ViewInfoList.Remove(CloseTabKey);
                    String MenuKey = String.Empty;
                    ToolStripMenuItem CloseMenuItem = null;
                    foreach (ToolStripMenuItem menuitem in collectionToolStripMenuItem.DropDownItems)
                    {
                        MenuKey = menuitem.Tag.ToString();
                        MenuKey = MenuKey.Substring(MenuKey.IndexOf(":") + 1);
                        if (CloseTabKey == MenuKey) { CloseMenuItem = menuitem; }
                    }
                    if (CloseMenuItem != null)
                    {
                        collectionToolStripMenuItem.DropDownItems.Remove(CloseMenuItem);
                    }
                }
                SystemManager.GetCurrentServer().Disconnect();
            }
            MongoDBHelper._mongoConnSvrLst.Remove(config.ConnectionName);
            trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
            RefreshToolStripMenuItem_Click(sender, e);
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
                MongoServer mongoSvr = SystemManager.GetCurrentServer();
                try
                {
                    //the server will be  shutdown with exception
                    MongoDBHelper._mongoConnSvrLst.Remove(SystemManager.SelectTagData);
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
                RefreshToolStripMenuItem_Click(sender, e);
            }
        }
        /// <summary>
        /// 初始化ReplSet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitReplsetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ReplSetName = MyMessageBox.ShowInput("Please Fill ReplSetName :",
                SystemManager.IsUseDefaultLanguage ? "ReplSetName" : SystemManager.mStringResource.GetText(StringResource.TextType.Replset_InitReplset));
            if (ReplSetName != String.Empty)
            {
                CommandResult Result = MongoDBHelper.InitReplicaSet(ReplSetName, SystemManager.GetCurrentServerConfig().ConnectionName);
                if (Result.Ok)
                {
                    //修改配置
                    ConfigHelper.MongoConnectionConfig newConfig = SystemManager.GetCurrentServerConfig();
                    newConfig.ReplSetName = ReplSetName;
                    newConfig.ReplsetList = new List<string>();
                    newConfig.ReplsetList.Add(newConfig.Host +
                                             (newConfig.Port != 0 ? ":" + newConfig.Port.ToString() : String.Empty));
                    SystemManager.ConfigHelperInstance.ConnectionList[newConfig.ConnectionName] = newConfig;
                    SystemManager.ConfigHelperInstance.SaveToConfigFile();
                    MongoDBHelper._mongoConnSvrLst.Remove(newConfig.ConnectionName);
                    MongoDBHelper._mongoConnSvrLst.Add(config.ConnectionName, MongoDBHelper.CreateMongoServer(ref newConfig));
                    this.ServerStatusCtl.SetEnable(false);
                    MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
                    this.ServerStatusCtl.SetEnable(true);
                }
                else
                {
                    MyMessageBox.ShowMessage("ReplSetName", "Failed", Result.ErrorMessage);
                }
            }
        }
        /// <summary>
        /// 副本管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigHelper.MongoConnectionConfig newConfig = SystemManager.GetCurrentServerConfig();
            SystemManager.OpenForm(new frmReplsetMgr(ref newConfig), true, true);
            SystemManager.ConfigHelperInstance.ConnectionList[newConfig.ConnectionName] = newConfig;
            SystemManager.ConfigHelperInstance.SaveToConfigFile();
            MongoDBHelper._mongoConnSvrLst.Remove(newConfig.ConnectionName);
            MongoDBHelper._mongoConnSvrLst.Add(config.ConnectionName, MongoDBHelper.CreateMongoServer(ref newConfig));
            this.ServerStatusCtl.SetEnable(false);
            MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.");
            this.ServerStatusCtl.SetEnable(true);

        }
        /// <summary>
        /// 分片管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShardingConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmShardingConfig(), true, true);
        }
        /// <summary>
        /// Refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper.FillConnectionToTreeView(trvsrvlst);
            this.ServerStatusCtl.ResetCtl();
            this.ServerStatusCtl.RefreshStatus(false);
            this.ServerStatusCtl.RefreshCurrentOpr();

            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            }
            else
            {
                this.statusStripMain.Items[0].Text = "Ready";
            }
            DisableAllOpr();
        }
        /// <summary>
        /// Expand All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.BeginUpdate();
            this.trvsrvlst.ExpandAll();
            this.trvsrvlst.EndUpdate();
        }
        /// <summary>
        /// Collapse All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.BeginUpdate();
            this.trvsrvlst.CollapseAll();
            this.trvsrvlst.EndUpdate();
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

        #region"管理：服务器"
        /// <summary>
        /// 建立数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strDBName = String.Empty;
            if (SystemManager.IsUseDefaultLanguage)
            {
                strDBName = MyMessageBox.ShowInput("Please Input DataBaseName：", "Create Database");
            }
            else
            {
                strDBName = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_DataBase_Input),
                                                                       SystemManager.mStringResource.GetText(StringResource.TextType.Create_New_DataBase));
            }
            String ErrMessage;
            SystemManager.GetCurrentServer().IsDatabaseNameValid(strDBName, out ErrMessage);
            if (ErrMessage == null)
            {
                try
                {
                    String strRusult = MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Create, trvsrvlst.SelectedNode);
                    if (String.IsNullOrEmpty(strRusult))
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
                    SystemManager.ExceptionDeal(ex, "Create MongoDatabase", "Argument Exception");
                }
            }
            else
            {
                MyMessageBox.ShowMessage("Create MongoDatabase", "Argument Exception", ErrMessage, true);
            }
        }
        /// <summary>
        /// copyDatabase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyDatabasetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SystemManager.GetCurrentServer().CopyDatabase(SystemManager.GetCurrentDataBase().Name, SystemManager.GetCurrentDataBase().Name + "_Backup");
            //MongoDBHelper.ExecuteMongoDBCommand("copyDatabase", SystemManager.GetCurrentDataBase());
            //CommandDocument copy = new CommandDocument();
            //SystemManager.GetCurrentDataBase().RunCommand("copyDatabase");
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (var item in MongoDBHelper._mongoUserLst.Keys)
            //{
            String ConnectionName = SystemManager.GetCurrentServerConfig().ConnectionName;
            String info = MongoDBHelper._mongoUserLst[ConnectionName].ToString();
            if (!string.IsNullOrEmpty(info))
            {
                MyMessageBox.ShowMessage(SystemManager.IsUseDefaultLanguage ? "UserInformation" : SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_UserInfo),
                    "The User Information of：[" + SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName].UserName + "]", info, true);
            }
            //}
        }
        /// <summary>
        /// Create User to Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUser(true), true, true);
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
        /// Server Info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.IsUseDefaultLanguage)
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
        /// Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmStatus(), true, true);
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
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_DataBase);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_DataBase_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                String strPath = SystemManager.SelectTagData;
                String strDBName = strPath.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.DatabaseLV];
                if (trvsrvlst.SelectedNode == null)
                {
                    trvsrvlst.SelectedNode = null;
                }
                String rtnResult = MongoDBHelper.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelper.Oprcode.Drop, trvsrvlst.SelectedNode);
                if (String.IsNullOrEmpty(rtnResult))
                {
                    DisableAllOpr();
                    //关闭所有的相关视图
                    //foreach不能直接修改，需要一个备份
                    Dictionary<String, TabPage> tempTable = new Dictionary<string, TabPage>();
                    foreach (String item in ViewTabList.Keys)
                    {
                        tempTable.Add(item, ViewTabList[item]);
                    }

                    foreach (String KeyItem in tempTable.Keys)
                    {
                        //如果有相同的前缀
                        if (KeyItem.StartsWith(strPath))
                        {
                            ToolStripMenuItem DataMenuItem = null;
                            foreach (ToolStripMenuItem Menuitem in collectionToolStripMenuItem.DropDownItems)
                            {
                                //菜单的寻找
                                if (Menuitem.Tag == ViewTabList[KeyItem].Tag)
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
                            tabView.Controls.Remove(ViewTabList[KeyItem]);
                            ViewTabList.Remove(KeyItem);
                            ViewInfoList.Remove(KeyItem);
                            ViewTabList[KeyItem] = null;
                        }
                    }
                    tempTable = null;
                }
                else
                {
                    MyMessageBox.ShowMessage("Error", "Error", rtnResult, true);
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
            SystemManager.OpenForm(frm, true, true);
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
            SystemManager.OpenForm(new frmUser(false), true, true);
        }
        /// <summary>
        /// Eval JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmEvalJS(), true, true);
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
            MongoDBHelper.FillConnectionToTreeView(trvsrvlst);
        }
        /// <summary>
        /// Profilling Level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void profillingLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmProfilling(), true, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmStatus(), true, true);
        }
        /// <summary>
        /// Create Js
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void creatJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strJsName = MyMessageBox.ShowInput("pls Input Javascript Name", "Save Javascript");
            if (strJsName != String.Empty)
            {
                MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
                if (MongoDBHelper.IsExistByKey(jsCol, strJsName))
                {
                    MyMessageBox.ShowMessage("Error", "javascript is already exist");
                }
                else
                {
                    String Result = MongoDBHelper.CreateNewJavascript(strJsName, String.Empty);
                    if (string.IsNullOrEmpty(Result))
                    {
                        TreeNode jsNode = new TreeNode(strJsName);
                        jsNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc;
                        jsNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc;
                        String jsTag = SystemManager.SelectTagData;
                        jsNode.Tag = MongoDBHelper.JAVASCRIPT_DOC_TAG + ":" + jsTag + "/" + strJsName;
                        trvsrvlst.SelectedNode.Nodes.Add(jsNode);
                        trvsrvlst.SelectedNode = jsNode;
                        SystemManager.SelectObjectTag = jsNode.Tag.ToString();
                        ViewJavascript();
                    }
                    else
                    {
                        MyMessageBox.ShowMessage("Error", "Create Javascript Error", Result, true);
                    }
                }
            }
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
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Collection);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Collection_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                String strPath = SystemManager.SelectTagData;
                String strCollection = strPath.Split("/".ToCharArray())[2];
                if (SystemManager.GetCurrentDataBase().DropCollection(trvsrvlst.SelectedNode.Text).Ok)
                {
                    String strNodeData = SystemManager.SelectTagData;
                    if (ViewTabList.ContainsKey(strNodeData))
                    {
                        TabPage DataTab = ViewTabList[strNodeData];
                        foreach (ToolStripMenuItem item in this.collectionToolStripMenuItem.DropDownItems)
                        {
                            if (item.Tag == DataTab.Tag)
                            {
                                collectionToolStripMenuItem.DropDownItems.Remove(item);
                                break;
                            }
                        }
                        tabView.Controls.Remove(DataTab);
                        ViewTabList.Remove(strNodeData);
                        ViewInfoList.Remove(strNodeData);
                        DataTab = null;
                    }
                    this.trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
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
            String strPath = SystemManager.SelectTagData;
            String strCollection = strPath.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.CollectionLV];
            String strNewCollectionName = String.Empty;
            if (SystemManager.IsUseDefaultLanguage)
            {
                strNewCollectionName = MyMessageBox.ShowInput("Please input new collection name：", "Rename collection", strCollection);
            }
            else
            {
                strNewCollectionName = MyMessageBox.ShowInput(SystemManager.mStringResource.GetText(StringResource.TextType.Rename_Collection_Input),
                                                              SystemManager.mStringResource.GetText(StringResource.TextType.Rename_Collection));
            }
            if (!String.IsNullOrEmpty(strNewCollectionName) && SystemManager.GetCurrentDataBase().RenameCollection(trvsrvlst.SelectedNode.Text, strNewCollectionName).Ok)
            {
                String strNodeData = SystemManager.SelectTagData;
                String strNewNodeTag = SystemManager.SelectObjectTag.Substring(0, SystemManager.SelectObjectTag.Length - SystemManager.GetCurrentCollection().Name.Length);
                strNewNodeTag += strNewCollectionName;
                String strNewNodeData = SystemManager.GetTagData(strNewNodeTag);
                if (ViewTabList.ContainsKey(strNodeData))
                {
                    TabPage DataTab = ViewTabList[strNodeData];
                    foreach (ToolStripMenuItem item in this.collectionToolStripMenuItem.DropDownItems)
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
                    ViewTabList.Add(strNewNodeData, ViewTabList[strNodeData]);
                    ViewTabList.Remove(strNodeData);

                    ViewInfoList.Add(strNewNodeData, ViewInfoList[strNodeData]);
                    ViewInfoList.Remove(strNodeData);
                }
                DisableAllOpr();
                SystemManager.SelectObjectTag = strNewNodeTag;
                trvsrvlst.SelectedNode.Text = strNewCollectionName;
                trvsrvlst.SelectedNode.Tag = strNewNodeTag;
                trvsrvlst.SelectedNode.ToolTipText = strNewCollectionName + System.Environment.NewLine;
                trvsrvlst.SelectedNode.ToolTipText += "IsCapped:" + SystemManager.GetCurrentCollection().GetStats().IsCapped.ToString();

                if (SystemManager.IsUseDefaultLanguage)
                {
                    statusStripMain.Items[0].Text = "selected Collection:" + SystemManager.SelectTagData;
                }
                else
                {
                    statusStripMain.Items[0].Text = SystemManager.mStringResource.GetText(StringResource.TextType.Selected_Collection) +
                          ":" + SystemManager.SelectTagData;
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
            SystemManager.OpenForm(new frmCollectionIndex(), true, true);
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
        /// Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dropJavascriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String Result = MongoDBHelper.DelJavascript(trvsrvlst.SelectedNode.Text);
            if (String.IsNullOrEmpty(Result))
            {
                String strNodeData = SystemManager.SelectTagData;
                if (ViewTabList.ContainsKey(strNodeData))
                {
                    TabPage DataTab = ViewTabList[strNodeData];
                    foreach (ToolStripMenuItem item in JavaScriptStripMenuItem.DropDownItems)
                    {
                        if (item.Tag == DataTab.Tag)
                        {
                            JavaScriptStripMenuItem.DropDownItems.Remove(item);
                            break;
                        }
                    }
                    tabView.Controls.Remove(DataTab);
                    ViewTabList.Remove(strNodeData);
                }
                this.trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
                DisableAllOpr();
            }
            else
            {
                MyMessageBox.ShowMessage("Delete Error", "A error is happened when delete javascript", Result, true);
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
        /// <summary>
        /// CollectionStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectionStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmStatus(), true, true);
        }
        /// <summary>
        /// validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmValidate(), true, true);
        }
        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                //
                SystemManager.OpenForm(new frmExport(ViewInfoList[ColPath]), true, true);
            }
            else
            {
                //从菜单中选择，直接导出所有的数据
                SystemManager.OpenForm(new frmExport(), true, true);
            }
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
                SystemManager.OpenForm(new frmOption(), true, true);
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
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Restore_Connection_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruMongoRestore MongoRestore = new MongodbDosCommand.StruMongoRestore();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
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
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
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
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
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
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
            SaveFileDialog dumpFile = new SaveFileDialog();
            dumpFile.Filter = MongoDBHelper.TxtFilter;
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
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (!MongoPathCheck()) { return; }
                MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
                MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentServer().Instance;
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

        #region"聚合"
        /// <summary>
        /// Count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            Boolean IsUseFilter = false;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                Query = ViewInfoList[ColPath].mDataFilter;
                IsUseFilter = ViewInfoList[ColPath].IsUseFilter;
            }

            if (Query.QueryConditionList.Count == 0 || !IsUseFilter)
            {
                MyMessageBox.ShowEasyMessage("Count", "Count Result : " + SystemManager.GetCurrentCollection().Count().ToString());
            }
            else
            {
                MongoDB.Driver.IMongoQuery mQuery = MongoDBHelper.GetQuery(Query.QueryConditionList);
                MyMessageBox.ShowMessage("Count",
                "Count[With DataView Filter]:" + SystemManager.GetCurrentCollection().Count(mQuery).ToString(),
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
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            Boolean IsUseFilter = false;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                Query = ViewInfoList[ColPath].mDataFilter;
                IsUseFilter = ViewInfoList[ColPath].IsUseFilter;
            }
            SystemManager.OpenForm(new frmDistinct(Query, IsUseFilter), true, true);
        }
        /// <summary>
        /// Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataFilter Query = new DataFilter();
            String ColPath = SystemManager.SelectTagData;
            Boolean IsUseFilter = false;
            if (ViewInfoList.ContainsKey(ColPath))
            {
                Query = ViewInfoList[ColPath].mDataFilter;
                IsUseFilter = ViewInfoList[ColPath].IsUseFilter;
            }
            SystemManager.OpenForm(new frmGroup(Query, IsUseFilter), true, true);
        }
        /// <summary>
        /// MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmMapReduce(), true, true);
        }
        /// <summary>
        /// aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aggregateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmAggregation(), true, true);
        }
        /// <summary>
        /// TextSearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmTextSearch(), true, true);
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
            SystemManager.OpenForm(new frmOption(), true, true);
            SystemManager.InitLanguage();
            if (SystemManager.IsUseDefaultLanguage)
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
            if (!SystemManager.MONO_MODE)
            {
                //MONO not support this function
                OpenFileDialog AccessFile = new OpenFileDialog();
                AccessFile.Filter = MongoDBHelper.MdbFilter;
                if (AccessFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MongoDBHelper.ImportAccessPara parm = new MongoDBHelper.ImportAccessPara();
                    parm.accessFileName = AccessFile.FileName;
                    parm.currentTreeNode = trvsrvlst.SelectedNode;
                    parm.strSvrPathWithTag = SystemManager.SelectObjectTag;
                    ParameterizedThreadStart Parmthread = new ParameterizedThreadStart(MongoDBHelper.ImportAccessDataBase);
                    Thread t = new Thread(Parmthread);
                    Parmthread.Invoke(parm);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GernerateConfigtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmGenerateConfigIni(), true, true);
        }
        /// <summary>
        /// DOS控制台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmDosCommand(), true, true);
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
                                     new System.IO.StreamReader("Release Note.txt").ReadToEnd());
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
            strThanks += "感谢Cnblogs的各位网友的帮助" + System.Environment.NewLine;
            strThanks += "Thanks Robert Stam for C# driver support" + System.Environment.NewLine;
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
            String strUrl = @"UserGuide\index.html";
            System.Diagnostics.Process.Start(strUrl);
        }
        /// <summary>
        /// Unit Test Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forMySelfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmUnitTest(), true, true);
        }
        #endregion
    }
}
