using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;

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
            List<CommandResult> Resultlst = new List<CommandResult>();
            CommandResult Result = MongoDBHelper.AddToReplsetServer(SystemManager.GetCurrentService(),
                          txtReplHost.Text.ToString() + ":" + NumReplPort.Value.ToString(), (int)NumPriority.Value, chkArbiterOnly.Checked);
            Resultlst.Add(Result);
            if (Result.Ok)
            {
                _config.ReplsetList.Add(txtReplHost.Text.ToString() + ":" + NumReplPort.Value.ToString());
            }
            MyMessageBox.ShowMessage("Add Memeber", "Result:" + (Result.Ok ? "OK" : "Fail"), MongoDBHelper.ConvertCommandResultlstToString(Resultlst));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            List<CommandResult> Resultlst = new List<CommandResult>();
            CommandResult Result = MongoDBHelper.RemoveFromReplsetServer(SystemManager.GetCurrentService(), lstHost.SelectedItem.ToString());
            Resultlst.Add(Result);
            if (Result.Ok)
            {
                _config.ReplsetList.Remove(lstHost.SelectedItem.ToString());
                lstHost.Items.Remove(lstHost.SelectedItem);
            }
            MyMessageBox.ShowMessage("Remove Member", "Result:" + (Result.Ok ? "OK" : "Fail"), MongoDBHelper.ConvertCommandResultlstToString(Resultlst));
        }

        private void frmReplsetMgr_Load(object sender, EventArgs e)
        {
            MongoServer server = SystemManager.GetCurrentService();
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
