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
    public partial class frmReplset : frmBase
    {
        public frmReplset()
        {
            InitializeComponent();
        }
        MongoServer PrmSrv;
        private void frmReplset_Load(object sender, EventArgs e)
        {
            PrmSrv = MongoDBHelpler.GetMongoServerBySvrPath(SystemManager.SelectObjectTag,true);
            String strPrmKey = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            foreach (var item in SystemManager.mConfig.ConnectionList)
            {
                if (strPrmKey != item.Key)
                {
                    lstShard.Items.Add(item.Key);
                }
            }
        }

        private void cmdInitReplset_Click(object sender, EventArgs e)
        {
            List<String> srvKeys = new List<string>();
            if (lstShard.SelectedItems.Count > 0) {
                foreach (String item in lstShard.SelectedItems)
                {
                    srvKeys.Add(item);
                }
            
            }
            MongoDBHelpler.SetReplica(PrmSrv, txtReplsetName.Text, srvKeys);
        }
    }
}
