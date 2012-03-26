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
    public partial class frmAddReplsetMember : Form
    {
        ConfigHelper.MongoConnectionConfig _config;
        public frmAddReplsetMember(ref ConfigHelper.MongoConnectionConfig config)
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
            MyMessageBox.ShowMessage("Add Server", "Result", MongoDBHelper.ConvertCommandResultlstToString(Resultlst));

        }
    }
}
