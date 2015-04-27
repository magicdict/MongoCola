using System;
using System.Windows.Forms;
using SystemUtility;
using Common.UI;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoCola
{
    public partial class frmReplsetMgr : Form
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public frmReplsetMgr(ref MongoConnectionConfig config)
        {
            InitializeComponent();
            RuntimeMongoDBContext._CurrentMongoConnectionconfig = config;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            try
            {
                var Result = CommandHelper.AddToReplsetServer(RuntimeMongoDBContext.GetCurrentServer(),
                    txtReplHost.Text + ":" + NumReplPort.Value, (int) NumPriority.Value, chkArbiterOnly.Checked);
                if (CommandHelper.IsShellOK(Result))
                {
                    RuntimeMongoDBContext._CurrentMongoConnectionconfig.ReplsetList.Add(txtReplHost.Text + ":" +
                                                                                        NumReplPort.Value);
                    MyMessageBox.ShowMessage("Add Memeber", "Result:OK");
                }
                else
                {
                    MyMessageBox.ShowMessage("Add Memeber", "Result:Fail", Result.Response.ToString());
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
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
            MongoCollection replsetCol = RuntimeMongoDBContext.GetCurrentServer().
                GetDatabase(ConstMgr.DATABASE_NAME_LOCAL).GetCollection("system.replset");
            var ReplsetDoc = replsetCol.FindOneAs<BsonDocument>();
            var memberlist = ReplsetDoc.GetElement("members").Value.AsBsonArray;
            var strHost = lstHost.SelectedItem.ToString();
            for (var i = 0; i < memberlist.Count; i++)
            {
                if (memberlist[i].AsBsonDocument.GetElement("host").Value.ToString() != strHost) continue;
                memberlist.RemoveAt(i);
                break;
            }
            try
            {
                CommandHelper.ReconfigReplsetServer(RuntimeMongoDBContext.GetCurrentServer(), ReplsetDoc);
                //由于这个命令会触发异常，所以没有Result可以获得
                RuntimeMongoDBContext._CurrentMongoConnectionconfig.ReplsetList.Remove(strHost);
                lstHost.Items.Remove(lstHost.SelectedItem);
                MyMessageBox.ShowMessage("Remove Memeber", "Please wait one minute and check the server list");
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        private void frmReplsetMgr_Load(object sender, EventArgs e)
        {
            if (!SystemConfig.IsUseDefaultLanguage)
            {
                Text =
                    GUIConfig.GetText(
                        TextType.Main_Menu_Distributed_ReplicaSet);
                grpAddHost.Text =
                    GUIConfig.GetText(TextType.AddConnection_Region_AddHost);
                grpRemoveHost.Text =
                    GUIConfig.GetText(
                        TextType.AddConnection_Region_RemoveHost);
                cmdClose.Text = GUIConfig.GetText(TextType.Common_Close);
                cmdAddHost.Text =
                    GUIConfig.GetText(TextType.AddConnection_Region_AddHost);
                cmdRemoveHost.Text =
                    GUIConfig.GetText(
                        TextType.AddConnection_Region_RemoveHost);
                lblpriority.Text =
                    GUIConfig.GetText(TextType.AddConnection_Priority);
                lblReplHost.Text = GUIConfig.GetText(TextType.Common_Host);
                lblReplPort.Text = GUIConfig.GetText(TextType.Common_Port);
            }

            var server = RuntimeMongoDBContext.GetCurrentServer();
            foreach (var item in server.Instances)
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