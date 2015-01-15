/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/9
 * Time: 13:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;
using SystemUtility;
using MongoUtility.Core;
using PlugInPackage;
using ResourceLib.Utility;

namespace MongoCola
{
    /// <summary>
    ///     Description of frmMain_Helper.
    /// </summary>
    public partial class frmMain : Form
    {
        /// <summary>
        ///     Set Menu Text
        /// </summary>
        private void SetMenuText()
        {
            //管理
            ManagerToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt);
            DisconnectToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Disconnect);
            AddConnectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_AddConnection);
            RefreshToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);

            ExpandAllConnectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Expansion);
            CollapseAllConnectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Collapse);
            ExitToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Exit);

            //数据视图
            ViewToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            ViewRefreshToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);
            collectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Collection);
            statusToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);


            //Operation
            OperationToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation);

            connectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Connect);
            ReplicaSetToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
            ShardingConfigToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Distributed_ShardingConfig);
            InitReplsetToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Replset_InitReplset);


            ServerToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
            CreateMongoDBToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
            UserInfoStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Server_UserInfo);
            AddUserToAdminToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
            slaveResyncToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Server_SlaveResync);
            ShutDownToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
            ServePropertyToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Server_Properties);
            ServerStatusToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

            DataBaseToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
            DelMongoDBToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Database_DelDB);
            CreateMongoCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Database_AddDC);
            AddUserToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            EvalJSToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
            RepairDBToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_Database_RepairDatabase);
            DBStatusToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

            DataCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection);
            DelMongoCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
            RenameCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
            IndexManageToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
            ReIndexToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
            CompactToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_Compact);
            CollectionStatusToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
            InitGFSToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_FileSystem_InitGFS);
            ProfillingLevelToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_ProfillingLevel);
            AggregationToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);
            ValidateToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Validate);
            ExportToFileToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_ExportToFile);

            DumpAndRestoreToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
            RestoreMongoToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
            DumpCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
            DumpDatabaseToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
            ImportCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
            ExportCollectionToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);
            creatJavaScriptToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_CreateJavaScript);
            ViewDataToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_View);
            dropJavascriptToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_DropJavaScript);

            //Tool
            ToolsToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Tool);
            OptionsToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Setting);

            //帮助
            HelpToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help);
            AboutToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help_About);
            ThanksToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help_Thanks);
            UserGuideToolStripMenuItem.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help_UserGuide);

            //其他控件
            statusStripMain.Items[0].Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
            tabSvrStatus.Text =
                SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
        }

        /// <summary>
        ///     禁止所有操作
        /// </summary>
        private void DisableAllOpr()
        {
            //管理-服务器
            CreateMongoDBToolStripMenuItem.Enabled = false;
            AddUserToAdminToolStripMenuItem.Enabled = false;
            ServerStatusToolStripMenuItem.Enabled = false;
            ServePropertyToolStripMenuItem.Enabled = false;
            slaveResyncToolStripMenuItem.Enabled = false;
            ShutDownToolStripMenuItem.Enabled = false;
            ShutDownToolStripButton.Enabled = false;
            InitReplsetToolStripMenuItem.Enabled = false;
            ReplicaSetToolStripMenuItem.Enabled = false;
            ShardingConfigToolStripMenuItem.Enabled = false;
            DisconnectToolStripMenuItem.Enabled = false;

            //管理-数据库
            CreateMongoCollectionToolStripMenuItem.Enabled = false;
            CopyDatabasetoolStripMenuItem.Enabled = false;
            DelMongoDBToolStripMenuItem.Enabled = false;
            UserInfoStripMenuItem.Enabled = false;
            AddUserToolStripMenuItem.Enabled = false;
            EvalJSToolStripMenuItem.Enabled = false;
            RepairDBToolStripMenuItem.Enabled = false;
            InitGFSToolStripMenuItem.Enabled = false;
            DBStatusToolStripMenuItem.Enabled = false;

            //管理-数据集
            IndexManageToolStripMenuItem.Enabled = false;
            ReIndexToolStripMenuItem.Enabled = false;
            RenameCollectionToolStripMenuItem.Enabled = false;
            DelMongoCollectionToolStripMenuItem.Enabled = false;
            CompactToolStripMenuItem.Enabled = false;
            ViewDataToolStripMenuItem.Enabled = false;
            AggregationToolStripMenuItem.Enabled = false;
            creatJavaScriptToolStripMenuItem.Enabled = false;
            dropJavascriptToolStripMenuItem.Enabled = false;
            CollectionStatusToolStripMenuItem.Enabled = false;
            ValidateToolStripMenuItem.Enabled = false;
            ExportToFileToolStripMenuItem.Enabled = false;
            ProfillingLevelToolStripMenuItem.Enabled = false;

            //管理-备份和恢复
            DumpDatabaseToolStripMenuItem.Enabled = false;
            RestoreMongoToolStripMenuItem.Enabled = false;
            DumpCollectionToolStripMenuItem.Enabled = false;
            ImportCollectionToolStripMenuItem.Enabled = false;
            ExportCollectionToolStripMenuItem.Enabled = false;

            //插件
            foreach (ToolStripItem item in plugInToolStripMenuItem.DropDownItems)
            {
                if (item.Tag != null)
                {
                    item.Enabled = PlugIn.PlugInList[item.Tag.ToString()].RunLv == PlugInBase.PathLv.Misc;
                }
            }
        }

        /// <summary>
        ///     CommandLog
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void CommandLog(object Sender, RunCommandEventArgs e)
        {
            ctlShellCommandEditor.AppendLine("========================================================");
            ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now + "  CommandName:" + e.Result.CommandName);
            ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now + "  Command:" + e.Result.Command);
            ctlShellCommandEditor.AppendLine("DateTime:" + DateTime.Now + "  OK:" + e.Result.Ok);
            ctlShellCommandEditor.AppendLine("========================================================");
        }
    }
}