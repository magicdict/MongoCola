using System;
using System.Windows.Forms;
using Common;
using MongoCola.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;

namespace MongoCola
{
    public partial class frmReplsetMgr : Form
    {
        private MongoUtility.Core.MongoConnectionConfig _config;

        public frmReplsetMgr(ref MongoUtility.Core.MongoConnectionConfig config)
        {
            InitializeComponent();
            MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig = config;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            try
            {
                CommandResult Result = CommandHelper.AddToReplsetServer(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer(),
                    txtReplHost.Text + ":" + NumReplPort.Value, (int) NumPriority.Value, chkArbiterOnly.Checked);
                if (CommandHelper.IsShellOK(Result))
                {
                    MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ReplsetList.Add(txtReplHost.Text + ":" + NumReplPort.Value);
                    MyMessageBox.ShowMessage("Add Memeber", "Result:OK");
                }
                else
                {
                    MyMessageBox.ShowMessage("Add Memeber", "Result:Fail", Result.Response.ToString());
                }
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex);
            }
        }

        /// <summary>
        ///     移除主机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            //使用修改系统数据集和repleSetReconfig
            MongoCollection replsetCol = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer().
                GetDatabase(ConstMgr.DATABASE_NAME_LOCAL).GetCollection("system.replset");
            var ReplsetDoc = replsetCol.FindOneAs<BsonDocument>();
            BsonArray memberlist = ReplsetDoc.GetElement("members").Value.AsBsonArray;
            String strHost = lstHost.SelectedItem.ToString();
            for (int i = 0; i < memberlist.Count; i++)
            {
                if (memberlist[i].AsBsonDocument.GetElement("host").Value.ToString() != strHost) continue;
                memberlist.RemoveAt(i);
                break;
            }
            try
            {
                CommandHelper.ReconfigReplsetServer(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer(), ReplsetDoc);
                //由于这个命令会触发异常，所以没有Result可以获得
                MongoUtility.Core.RuntimeMongoDBContext._CurrentMongoConnectionconfig.ReplsetList.Remove(strHost);
                lstHost.Items.Remove(lstHost.SelectedItem);
                MyMessageBox.ShowMessage("Remove Memeber", "Please wait one minute and check the server list");
            }
            catch (Exception ex)
            {
                Common.Utility.ExceptionDeal(ex);
            }
        }

        private void frmReplsetMgr_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
                grpAddHost.Text =
                    SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_Region_AddHost);
                grpRemoveHost.Text =
                    SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_Region_RemoveHost);
                cmdClose.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
                cmdAddHost.Text =
                    SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_Region_AddHost);
                cmdRemoveHost.Text =
                    SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_Region_RemoveHost);
                lblpriority.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.AddConnection_Priority);
                lblReplHost.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Host);
                lblReplPort.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Port);
            }

            MongoServer server = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer();
            foreach (MongoServerInstance item in server.Instances)
            {
                lstHost.Items.Add(item.Address.ToString());
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}