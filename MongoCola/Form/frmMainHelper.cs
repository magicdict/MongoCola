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
using MongoCola.Module;
using PlugInPackage;

namespace MongoCola
{
	/// <summary>
	/// Description of frmMain_Helper.
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
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt);
			DisconnectToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Disconnect);
			AddConnectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_AddConnection);
			RefreshToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);

			ExpandAllConnectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Expansion);
			CollapseAllConnectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Collapse);
			ExitToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Exit);

			//数据视图
			ViewToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
			ViewRefreshToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Refresh);
			collectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Collection);
			statusToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);


			//Operation
			OperationToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation);

			connectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Connect);
			ReplicaSetToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
			ShardingConfigToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ShardingConfig);
			InitReplsetToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Replset_InitReplset);


			ServerToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server);
			CreateMongoDBToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_NewDB);
			UserInfoStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_UserInfo);
			AddUserToAdminToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
			slaveResyncToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_SlaveResync);
			ShutDownToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_CloseServer);
			ServePropertyToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Server_Properties);
			ServerStatusToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

			DataBaseToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database);
			DelMongoDBToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelDB);
			CreateMongoCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddDC);
			AddUserToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
			EvalJSToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_EvalJs);
			RepairDBToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_Database_RepairDatabase);
			DBStatusToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);

			DataCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection);
			DelMongoCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DelDC);
			RenameCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Rename);
			IndexManageToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Index);
			ReIndexToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_ReIndex);
			CompactToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_Compact);
			CollectionStatusToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
			InitGFSToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_FileSystem_InitGFS);
			ProfillingLevelToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_ProfillingLevel);
			AggregationToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Aggregation);
			ValidateToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Validate);
			ExportToFileToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_DataCollection_ExportToFile);

			DumpAndRestoreToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_BackupAndRestore);
			RestoreMongoToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Restore);
			DumpCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDC);
			DumpDatabaseToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_BackupAndRestore_BackupDB);
			ImportCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Import);
			ExportCollectionToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_BackupAndRestore_Export);
			creatJavaScriptToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_DataCollection_CreateJavaScript);
			ViewDataToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_View);
			dropJavascriptToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_DataCollection_DropJavaScript);

			//Tool
			ToolsToolStripMenuItem.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Tool);
			OptionsToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Tool_Setting);

			//帮助
			HelpToolStripMenuItem.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help);
			AboutToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help_About);
			ThanksToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help_Thanks);
			UserGuideToolStripMenuItem.Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Help_UserGuide);

			//其他控件
			statusStripMain.Items[0].Text =
                SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_StatusBar_Text_Ready);
			tabSvrStatus.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Mangt_Status);
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
			foreach (ToolStripItem item in plugInToolStripMenuItem.DropDownItems) {
				if (item.Tag != null) {
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
