using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmReplsetMgr : Form
    {
        ConfigHelper.MongoConnectionConfig _config;
        public frmReplsetMgr(ref ConfigHelper.MongoConnectionConfig config)
        {
            InitializeComponent();
            _config = config;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            try
            {
                CommandResult Result = MongoDBHelper.AddToReplsetServer(SystemManager.GetCurrentServer(),
                              txtReplHost.Text.ToString() + ":" + NumReplPort.Value.ToString(), (int)NumPriority.Value, chkArbiterOnly.Checked);
                if (MongoDBHelper.IsShellOK(Result))
                {
                    _config.ReplsetList.Add(txtReplHost.Text.ToString() + ":" + NumReplPort.Value.ToString());
                    MyMessageBox.ShowMessage("Add Memeber", "Result:OK");
                }
                else
                {
                    MyMessageBox.ShowMessage("Add Memeber", "Result:Fail", Result.Response.ToString());
                }
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
            }
        }
        /// <summary>
        /// 移除主机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            //使用修改系统数据集和repleSetReconfig
            MongoCollection replsetCol = SystemManager.GetCurrentServer().
                                      GetDatabase(MongoDBHelper.DATABASE_NAME_LOCAL).GetCollection("system.replset");
            BsonDocument ReplsetDoc = replsetCol.FindOneAs<BsonDocument>();
            BsonArray memberlist = ReplsetDoc.GetElement("members").Value.AsBsonArray;
            String strHost = lstHost.SelectedItem.ToString();
            for (int i = 0; i < memberlist.Count; i++)
            {
                if (memberlist[i].AsBsonDocument.GetElement("host").Value.ToString() == strHost)
                {
                    memberlist.RemoveAt(i);
                    break;
                }
            }
            List<CommandResult> Resultlst = new List<CommandResult>();
            try
            {
                CommandResult Result = MongoDBHelper.ReconfigReplsetServer(SystemManager.GetCurrentServer(), ReplsetDoc);
                ///由于这个命令会触发异常，所以没有Result可以获得
                _config.ReplsetList.Remove(strHost);
                lstHost.Items.Remove(lstHost.SelectedItem);
                MyMessageBox.ShowMessage("Remove Memeber", "Please wait one minute and check the server list");
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
            }
        }

        private void frmReplsetMgr_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Distributed_ReplicaSet);
                grpAddHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_AddHost);
                grpRemoveHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_RemoveHost);
                cmdClose.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
                cmdAddHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_AddHost);
                cmdRemoveHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_RemoveHost);
                lblpriority.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Priority);
                lblReplHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Host);
                lblReplPort.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Port);
            }

            MongoServer server = SystemManager.GetCurrentServer();
            foreach (var item in server.Instances)
            {
                lstHost.Items.Add(item.Address.ToString());
            }
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
