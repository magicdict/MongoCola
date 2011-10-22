using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Driver;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmAddSharding : QLFUI.QLFForm
    {
        public frmAddSharding()
        {
            InitializeComponent();
        }
        MongoServer PrmSrv;
        private void frmAddSharding_Load(object sender, EventArgs e)
        {
            PrmSrv = SystemManager.getCurrentService();
            String strPrmKey = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            foreach (var item in SystemManager.mConfig.ConnectionList.Values)
            {
                if (item.ReplSetName != null)
                {
                    if (!cmbReplsetName.Items.Contains(item.ReplSetName))
                    {
                        cmbReplsetName.Items.Add(item.ReplSetName);
                    }
                }
            }
        }
        private void RefreshSrv()
        {
            lstShard.Items.Clear();
            foreach (var item in SystemManager.mConfig.ConnectionList.Values)
            {
                if (item.ReplSetName != null)
                {
                    if (item.ReplSetName == cmbReplsetName.Text)
                    {
                        lstShard.Items.Add(item.HostName);
                    }
                }
            }
        }
        private void cmdInitReplset_Click(object sender, EventArgs e)
        {
            List<String> srvKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (String item in lstShard.SelectedItems)
                {
                    srvKeys.Add(item);
                }
            }
            MongoDBHelpler.AddSharding(PrmSrv, cmbReplsetName.Text, srvKeys);
        }

        private void cmbReplsetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSrv();
        }
    }
}
