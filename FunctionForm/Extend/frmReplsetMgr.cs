using System;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm.Extend
{
    public partial class FrmReplsetMgr : Form
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public FrmReplsetMgr(ref MongoConnectionConfig config)
        {
            InitializeComponent();
            RuntimeMongoDbContext.CurrentMongoConnectionconfig = config;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            try
            {
                var result = CommandHelper.AddToReplsetServer(RuntimeMongoDbContext.GetCurrentServer(),
                    txtReplHost.Text + ":" + NumReplPort.Value, (int) NumPriority.Value, chkArbiterOnly.Checked);
                if (CommandHelper.IsShellOk(result))
                {
                    RuntimeMongoDbContext.CurrentMongoConnectionconfig.ReplsetList.Add(txtReplHost.Text + ":" +
                                                                                       NumReplPort.Value);
                    MyMessageBox.ShowMessage("Add Memeber", "Result:OK");
                }
                else
                {
                    MyMessageBox.ShowMessage("Add Memeber", "Result:Fail", result.Response.ToString());
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
            MongoCollection replsetCol = RuntimeMongoDbContext.GetCurrentServer().
                GetDatabase(ConstMgr.DatabaseNameLocal).GetCollection("system.replset");
            var replsetDoc = replsetCol.FindOneAs<BsonDocument>();
            var memberlist = replsetDoc.GetElement("members").Value.AsBsonArray;
            var strHost = lstHost.SelectedItem.ToString();
            for (var i = 0; i < memberlist.Count; i++)
            {
                if (memberlist[i].AsBsonDocument.GetElement("host").Value.ToString() != strHost) continue;
                memberlist.RemoveAt(i);
                break;
            }
            try
            {
                CommandHelper.ReconfigReplsetServer(RuntimeMongoDbContext.GetCurrentServer(), replsetDoc);
                //由于这个命令会触发异常，所以没有Result可以获得
                RuntimeMongoDbContext.CurrentMongoConnectionconfig.ReplsetList.Remove(strHost);
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
            GuiConfig.Translateform(this);
            var server = RuntimeMongoDbContext.GetCurrentServer();
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