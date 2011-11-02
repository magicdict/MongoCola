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
        private MongoServer _prmSvr;
        private void frmAddSharding_Load(object sender, EventArgs e)
        {
            _prmSvr = SystemManager.GetCurrentService();
            string strPrmKey = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
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
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
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
            List<string> srvKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (string item in lstShard.SelectedItems)
                {
                    srvKeys.Add(item);
                }
            }
            MongoDBHelpler.AddSharding(_prmSvr, cmbReplsetName.Text, srvKeys);
        }

        private void cmbReplsetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSrv();
        }
    }
}
