/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/9
 * Time: 13:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Forms;
using PlugInPackage;

namespace MongoCola
{
    /// <summary>
    ///     Description of frmMain_Helper.
    /// </summary>
    public partial class FrmMain : Form
    {
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
            //ShutDownToolStripMenuItem.Enabled = false;
            //ShutDownToolStripButton.Enabled = false;
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
            machineLearningToolStripMenuItem.Enabled = false;

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
    }
}