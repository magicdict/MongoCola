using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Windows.Forms;

namespace FunctionForm.Extend
{
    public partial class FrmReplsetMgr : Form
    {
        /// <summary>
        /// </summary>
        public FrmReplsetMgr()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            try
            {
                var result = ShellMethod.AddToReplsetServer(RuntimeMongoDbContext.GetCurrentServer(),
                    txtReplHost.Text + ":" + NumReplPort.Value, (int)NumPriority.Value, chkArbiterOnly.Checked);
                if (CommandExecute.IsShellOk(result))
                {
                    RuntimeMongoDbContext.CurrentMongoConnectionconfig.ReplsetList.Add(txtReplHost.Text + ":" + NumReplPort.Value);
                    Operater.RefreshConnectionConfig(RuntimeMongoDbContext.CurrentMongoConnectionconfig);
                    MyMessageBox.ShowMessage("Add Memeber OK", "Please refresh connection after one minute.");
                }
                else
                {
                    MyMessageBox.ShowMessage("Add Memeber", "Add Memeber Failed", result.Response.ToString());
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
                DataBaseCommand.ReconfigReplsetServer(RuntimeMongoDbContext.GetCurrentServer(), replsetDoc);
                //由于这个命令会触发异常，所以没有Result可以获得
                RuntimeMongoDbContext.CurrentMongoConnectionconfig.ReplsetList.Remove(strHost);
                lstHost.Items.Remove(lstHost.SelectedItem);
                Operater.RefreshConnectionConfig(RuntimeMongoDbContext.CurrentMongoConnectionconfig);
                MyMessageBox.ShowMessage("Remove Memeber OK", "Please refresh connection after one minute.");
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        private void frmReplsetMgr_Load(object sender, EventArgs e)
        {
            GuiConfig.Translateform(this);
            RuntimeMongoDbContext.CurrentMongoConnectionconfig = RuntimeMongoDbContext.GetCurrentServerConfig();
            var server = RuntimeMongoDbContext.GetCurrentServer();
            foreach (var item in server.Instances)
            {
                lstHost.Items.Add(item.Address.ToString());
            }
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}