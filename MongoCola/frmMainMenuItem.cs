using Common;
using FunctionForm.Aggregation;
using FunctionForm.Connection;
using FunctionForm.Extend;
using FunctionForm.Operation;
using FunctionForm.Status;
using FunctionForm.User;
using MongoCola.Config;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoGUIView;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MongoCola
{
    public partial class frmMain
    {
        #region"工具"

        /// <summary>
        ///     Config File Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigfileMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("ConfigurationFile.exe")) Process.Start("ConfigurationFile.exe");
        }

        /// <summary>
        ///     Multi Language Editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists("MultiLanEditor.exe")) Process.Start("MultiLanEditor.exe");
        }

        /// <summary>
        ///     Options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmOption(), true, true);
            SystemManager.InitLanguage();
            if (GuiConfig.IsUseDefaultLanguage)
            {
                MyMessageBox.ShowMessage("Language", "Language will change to \"English\" when you restart this tool");
            }
            else
            {
                GuiConfig.Translateform(this);
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
            UIAssistant.OpenModalForm(new frmConnect(), true, true);
            RefreshToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        ///     Disconnect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RuntimeMongoDbContext.SelectTagType == ConstMgr.ConnectionExceptionTag) return;
            //关闭相关的Tab
            var connectionTag = trvsrvlst.SelectedNode.Tag.ToString();
            MultiTabManger.SelectObjectTagPrefixDeleted(ConstMgr.CollectionTag + ":" + TagInfo.GetTagPath(connectionTag));
            RuntimeMongoDbContext.RemoveConnectionConfig(
                RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName);
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
            var replSetName = MyMessageBox.ShowInput("Please Fill ReplSetName :",
                GuiConfig.GetText("ReplSetName", "Replset_InitReplset"));
            if (replSetName == string.Empty) return;
            var result = string.Empty;
            if (Operater.InitReplicaSet(replSetName, ref result))
            {
                MyMessageBox.ShowMessage("ReplSetName", "Please refresh connection after one minute.", result);
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
            UIAssistant.OpenModalForm(new FrmReplsetMgr(), true, true);
        }

        /// <summary>
        ///     分片管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShardingConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmShardingConfig(), true, true);
        }

        /// <summary>
        ///     刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAllOpr();
            RefreshToolStripMenuItem.Enabled = false;
            RefreshToolStripButton.Enabled = false;
            trvsrvlst.Nodes.Clear();
            try
            {
                var connectionTreeNodes = UiHelper.GetConnectionNodes();
                foreach (var element in connectionTreeNodes)
                {
                    trvsrvlst.Nodes.Add(element);
                }
                ExpandAllToolStripMenuItem_Click(sender, e);
            }
            catch (Exception)
            {
                trvsrvlst.Nodes.Add("丢失与数据库的连接！");
            }
            RefreshToolStripMenuItem.Enabled = true;
            RefreshToolStripButton.Enabled = true;
            statusStripMain.Items[0].Text = GuiConfig.GetText("Ready", "MainStatusBarTextReady");
            if (trvsrvlst.Nodes.Count > 0) trvsrvlst.SelectedNode = trvsrvlst.Nodes[0];
        }

        /// <summary>
        ///     Expand All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvsrvlst.BeginUpdate();
            //全部展开的时候，东西太多了，只展开到Collection
            foreach (TreeNode node in trvsrvlst.Nodes)
            {
                ExpandNode(node);
            }
            trvsrvlst.EndUpdate();
        }
        /// <summary>
        ///     展开节点
        /// </summary>
        /// <param name="node"></param>
        private void ExpandNode(TreeNode node)
        {
            if (node.Tag == null) return;
            var strNodeType = TagInfo.GetTagType(node.Tag.ToString());
            if (strNodeType != ConstMgr.CollectionTag &&
                strNodeType != ConstMgr.GridFileSystemTag &&
                strNodeType != ConstMgr.ViewTag)
            {
                node.Expand();
                if (node.Nodes.Count == 0) return;
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
            //新版本如果数据库没有数据集，则数据库将被回收？
            string strDbName = MyMessageBox.ShowInput(
                        GuiConfig.GetText("Please Input DataBaseName：", "CreateNewDataBaseInput"),
                        GuiConfig.GetText("Create Database", "CreateNewDataBase"));
            if (string.IsNullOrEmpty(strDbName)) return;
            string strInitColName = MyMessageBox.ShowInput(
                        GuiConfig.GetText("Please Input Init CollectionName：", "CreateNewDataBaseInitCollection"),
                        GuiConfig.GetText("Create Database", "CreateNewDataBase"));
            if (Operater.IsDatabaseNameValid(strDbName, out string errMessage))
            {
                try
                {
                    var strRusult = Operater.CreateDataBaseWithInitCollection(strDbName, strInitColName);
                    if (string.IsNullOrEmpty(strRusult))
                    {
                        RefreshToolStripMenuItem_Click(sender, e);
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
            UIAssistant.OpenModalForm(new frmCopyDataBase(), true, true);
        }

        /// <summary>
        ///     Create User to Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmUser(true), true, true);
        }

        /// <summary>
        ///     Create A Role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmAddRole(), true, true);
        }


        /// <summary>
        ///     Status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.MonoMode)
            {
                UIAssistant.OpenModalForm(new FrmStatusMono(), true, true);
            }
            else
            {
                UIAssistant.OpenModalForm(new FrmStatus(), true, true);
            }
        }

        /// <summary>
        ///     ServerMonitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenForm(new FrmServerMonitor(), true);
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
            var strTitle = GuiConfig.GetText("Drop Database", "DropDataBase");
            var strMessage = GuiConfig.GetText("Are you really want to Drop current Database?", "DropDataBaseConfirm");
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage)) return;
            var strTagPrefix = TagInfo.GetTagPath(ConstMgr.CollectionTag + ":" + RuntimeMongoDbContext.SelectTagData);
            var strDbName = strTagPrefix.Split("/".ToCharArray())[(int)EnumMgr.PathLevel.Database];
            if (trvsrvlst.SelectedNode == null)
            {
                trvsrvlst.SelectedNode = null;
            }
            var rtnResult = Operater.DropDatabase(RuntimeMongoDbContext.SelectObjectTag, strDbName);
            if (string.IsNullOrEmpty(rtnResult))
            {
                RefreshToolStripMenuItem_Click(sender, e);
                //关闭所有的相关视图
                MultiTabManger.SelectObjectTagPrefixDeleted(strTagPrefix);
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
                    StrSvrPathWithTag = RuntimeMongoDbContext.SelectObjectTag,
                    TreeNode = trvsrvlst.SelectedNode
                };
            UIAssistant.OpenModalForm(frm, true, true);
            if (frm.Result)
            {
                //这里表示： Client / Server  一个Client 可能连结复数Server  
                var srvkey = RuntimeMongoDbContext.GetCurrentServerKey() + "/" +
                             RuntimeMongoDbContext.GetCurrentServerKey();
                var newCol =
                    UiHelper.FillCollectionInfoToTreeNode(
                        RuntimeMongoDbContext.GetCurrentIMongoDataBase().GetCollection<BsonDocument>(frm.CollectionName),
                        srvkey);

                if (TagInfo.GetTagType(trvsrvlst.SelectedNode.Tag.ToString()) == ConstMgr.CollectionListTag)
                {
                    //选中CollectionList添加
                    trvsrvlst.SelectedNode.Nodes.Add(newCol);
                }
                else
                {
                    //选中Database添加
                    foreach (TreeNode item in trvsrvlst.SelectedNode.Nodes)
                    {
                        var strNodeType = TagInfo.GetTagType(item.Tag.ToString());
                        if (strNodeType == ConstMgr.CollectionListTag)
                        {
                            //自己添加的Collection不是SystemCollection
                            item.Nodes.Add(newCol);
                            break;
                        }
                    }
                }

                DisableAllOpr();
            }
        }

        /// <summary>
        ///     CreateView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateViewtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmCreateView();
            UIAssistant.OpenModalForm(frm, true, true);
        }

        /// <summary>
        ///     Create User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmUser(false), true, true);
        }

        /// <summary>
        ///     CreateRole
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDBCustomeRoleStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmAddRole(), true, true);
        }

        /// <summary>
        ///     Eval JS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void evalJSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmEvalJs(), true, true);
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
            var connectNodes = UiHelper.GetConnectionNodes();
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
            UIAssistant.OpenModalForm(new FrmProfilling(), true, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.MonoMode)
            {
                UIAssistant.OpenModalForm(new FrmStatusMono(), true, true);
            }
            else
            {
                UIAssistant.OpenModalForm(new FrmStatus(), true, true);
            }
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
                var result = Operater.CreateNewJavascript(strJsName, string.Empty);
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
            var strDelTag = trvsrvlst.SelectedNode.Tag.ToString();
            if (!DropCollection(trvsrvlst.SelectedNode)) return;
            MultiTabManger.SelectObjectTagDeleted(strDelTag);
            trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
            DisableAllOpr();
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool DropCollection(TreeNode node)
        {
            var strTitle = GuiConfig.GetText("Drop Collection", "DropCollection");
            var strMessage = GuiConfig.GetText("Are you sure to drop this Collection?", "DropCollectionConfirm");
            if (!MyMessageBox.ShowConfirm(strTitle, strMessage)) return false;
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLevel.CollectionAndView];
            return Operater.DrapCollection(strCollection);
        }
        /// <summary>
        ///     重命名数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strOldNodeTag = trvsrvlst.SelectedNode.Tag.ToString();
            var strNewCollectionName = RenameCollection(trvsrvlst.SelectedNode);
            if (string.IsNullOrEmpty(strNewCollectionName)) return;
            var strNewNodeTag = TagInfo.ChangeName(trvsrvlst.SelectedNode.Tag.ToString(), strNewCollectionName);
            MultiTabManger.SelectObjectTagChanged(strOldNodeTag, strNewNodeTag, strNewCollectionName);
            DisableAllOpr();
            RuntimeMongoDbContext.SelectObjectTag = strNewNodeTag;
            trvsrvlst.SelectedNode.Text = strNewCollectionName;
            trvsrvlst.SelectedNode.Tag = strNewNodeTag;
            trvsrvlst.SelectedNode.ToolTipText = strNewCollectionName + Environment.NewLine;
            trvsrvlst.SelectedNode.ToolTipText += "IsCapped:" + RuntimeMongoDbContext.GetCurrentCollectionIsCapped();
            statusStripMain.Items[0].Text = GuiConfig.GetText("selected Collection", "SelectedCollection") + ":" +
                                            RuntimeMongoDbContext.SelectTagData;
        }

        /// <summary>
        ///     重命名
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public string RenameCollection(TreeNode node)
        {
            var strPath = RuntimeMongoDbContext.SelectTagData;
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLevel.CollectionAndView];
            var strNewCollectionName = MyMessageBox.ShowInput(
                GuiConfig.GetText("Please input new collection name：", "RenameCollectionInput"),
                GuiConfig.GetText("Rename collection", "RenameCollection"), strCollection);
            if (string.IsNullOrEmpty(strNewCollectionName)) return string.Empty;
            if (Operater.RenameCollection(strCollection, strNewCollectionName))
            {
                return strNewCollectionName;
            }
            return string.Empty;
        }

        /// <summary>
        ///     ConvertToCapped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConvertToCappedtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            var maxSize = MyMessageBox.ShowInput("Please Input MaxSize(Byte)", "MaxSize", "4096");
            if (string.IsNullOrEmpty(maxSize)) return;
            if (long.TryParse(maxSize, out long lngMaxSize))
            {
                var colName = RuntimeMongoDbContext.GetCurrentCollectionName();
                var db = RuntimeMongoDbContext.GetCurrentDataBase();
                var result = DataBaseCommand.convertToCapped(colName, lngMaxSize, db);
                MyMessageBox.ShowEasyMessage("ConvertToCapped", result.Response.ToString());
            }
            else
            {
                MessageBox.Show("Please Input a Number");
            }
        }

        /// <summary>
        ///     索引管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new frmCollectionIndex(), true, true);
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
            var strCollection = strPath.Split("/".ToCharArray())[(int)EnumMgr.PathLevel.CollectionAndView + 1];
            var result = Operater.DelJavascript(strCollection);
            if (string.IsNullOrEmpty(result))
            {
                var strNodeData = RuntimeMongoDbContext.SelectTagData;
                trvsrvlst.SelectedNode.Parent.Nodes.Remove(trvsrvlst.SelectedNode);
                DisableAllOpr();
            }
            else
            {
                MyMessageBox.ShowMessage("Delete Error", "A error is happened when delete javascript", result, true);
            }
        }


        /// <summary>
        ///     CollectionStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectionStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SystemManager.MonoMode)
            {
                UIAssistant.OpenModalForm(new FrmStatusMono(), true, true);
            }
            else
            {
                UIAssistant.OpenModalForm(new FrmStatus(), true, true);
            }
        }

        /// <summary>
        ///     validate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmValidate(), true, true);
        }

        /// <summary>
        ///     导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colPath = RuntimeMongoDbContext.SelectTagData;
            MessageBox.Show("Please Use Export To Excel PlugIn!");
        }


        /// <summary>
        ///     显示这个Pipeline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pipeline = new List<BsonDocument>
            {
                RuntimeMongoDbContext.GetCurrentCollectionInfo()
            };
            var frm = new frmDataView()
            {
                ShowData = pipeline,
                Title = "ViewInfo"
            };
            UIAssistant.OpenModalForm(frm, true, true);
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
            UIAssistant.OpenModalForm(new FrmOption(), true, true);
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
            var strTitle = GuiConfig.GetText("Restore", "MainMenu.OperationBackupAndRestoreRestore");
            var strMessage = GuiConfig.GetText("Are you sure to Restore?", "RestoreConnectionConfirm");
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
            else
            {
                return;
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
            else
            {
                return;
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
            else
            {
                return;
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
            else
            {
                return;
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
                strTitle = GuiConfig.GetText("Import Collection", "Main_Menu_Operation_BackupAndRestore_Import");
                strMessage = GuiConfig.GetText("Are you sure to Import Collection?", "");
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
            else
            {
                return;
            }
            mongoImportExport.Direct = MongoImportExportInfo.ImprotExport.Import;
            var dosCommand = MongoImportExportInfo.GetMongoImportExportCommandLine(mongoImportExport);
            RunCommand(dosCommand);
        }

        #endregion

        #region"聚合"

        /// <summary>
        ///     Distinct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distinctToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmDistinct(), true, true);
        }

        /// <summary>
        ///     MapReduce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmMapReduce(), true, true);
        }

        /// <summary>
        ///     aggregate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aggregateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmAggregation(), true, true);
        }

        /// <summary>
        ///     TextSearch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmTextSearch(), true, true);
        }

        /// <summary>
        ///     GeoNear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void geoNearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new frmGeoNear(), true, true);
        }
        #endregion

        #region "帮助"

        private void ShellReferenceMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.mongodb.com/manual/reference/mongo-shell/");
        }

        private void ShellMethod_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.mongodb.com/manual/reference/method/");
        }

        private void AggregationReference_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.mongodb.com/manual/meta/aggregation-quick-reference/");
        }

        private void MongoDBManualMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.mongodb.com/manual/");
        }


        /// <summary>
        ///     About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyMessageBox.ShowMessage("About", "MongoCola",
                GetResource.GetImage(ImageType.Smile),
                new StreamReader("Release Note_Ver2.0.txt", Encoding.UTF8).ReadToEnd());
        }

        /// <summary>
        ///     Thanks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var strThanks = "感谢 QiQi https://github.com/1354092549" + Environment.NewLine;
            strThanks += "感谢 张鹏 zp11qm12#hotmail.com " + Environment.NewLine;
            strThanks += "感谢10gen的C# Driver开发者的技术支持" + Environment.NewLine;
            strThanks += "感谢Dragon同志的测试和代码规范化" + Environment.NewLine;
            strThanks += "感谢MoLing同志的国际化" + Environment.NewLine;
            strThanks += "感谢Cnblogs的各位网友的帮助" + Environment.NewLine;
            strThanks += "Thanks Robert Stam for C# driver support" + Environment.NewLine;
            MyMessageBox.ShowMessage("Thanks", "MongoCola",
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
            Process.Start("http://www.codesnippet.info/Article/Index?ArticleId=00000062");
        }
        /// <summary>
        ///     Check Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckUpdatetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/magicdict/MongoCola/releases");
        }
        #endregion
    }
}