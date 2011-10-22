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
        MongoServer PrmSrv;
        private void frmReplset_Load(object sender, EventArgs e)
        {
            PrmSrv = SystemManager.getCurrentService();
            ConfigHelper.MongoConnectionConfig PrmKeyPro = SystemManager.getSelectedSrvProByName();
            lblPrmInfo.Text = "主机为:" + PrmKeyPro.HostName + "  副本名：" + PrmKeyPro.ReplSetName;
            foreach (var item in SystemManager.mConfig.ConnectionList.Values)
            {
                if ((PrmKeyPro.HostName != item.HostName) & (PrmKeyPro.ReplSetName == item.ReplSetName))
                {
                    lstShard.Items.Add(item.HostName);
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
            MongoDBHelpler.InitReplicaSet(PrmSrv, SystemManager.getSelectedSrvProByName().ReplSetName, srvKeys);
        }


    }
}
