using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmReplset : QLFUI.QLFForm
    {
        public frmReplset()
        {
            InitializeComponent();
        }
        private MongoServer _prmSvr;
        private void frmReplset_Load(object sender, EventArgs e)
        {
            _prmSvr = SystemManager.GetCurrentService();
            ConfigHelper.MongoConnectionConfig prmKeyPro = SystemManager.GetSelectedSvrProByName();
            lblPrmInfo.Text = "主机为:" + prmKeyPro.HostName + "  副本名：" + prmKeyPro.ReplSetName;
            foreach (var item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if ((prmKeyPro.HostName != item.HostName) & (prmKeyPro.ReplSetName == item.ReplSetName))
                {
                    lstShard.Items.Add(item.HostName);
                }
            }
        }

        private void cmdInitReplset_Click(object sender, EventArgs e)
        {
            List<String> svrKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (String item in lstShard.SelectedItems)
                {
                    svrKeys.Add(item);
                }
            }
            MongoDBHelpler.InitReplicaSet(_prmSvr, SystemManager.GetSelectedSvrProByName().ReplSetName, svrKeys);
        }


    }
}
