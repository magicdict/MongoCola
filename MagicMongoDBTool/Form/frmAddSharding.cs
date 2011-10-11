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
    public partial class frmAddSharding : frmBase
    {
        public frmAddSharding()
        {
            InitializeComponent();
        }



        MongoServer PrmSrv;
        private void frmAddSharding_Load(object sender, EventArgs e)
        {
            PrmSrv = MongoDBHelpler.GetMongoServerBySvrPath(SystemManager.SelectObjectTag, true);
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
            if (lstShard.SelectedItems.Count > 0)
            {
                foreach (String item in lstShard.SelectedItems)
                {
                    srvKeys.Add(item);
                }
            }
            MongoDBHelpler.AddSharding(PrmSrv,txtReplsetName.Text,srvKeys,txtDBName.Text,txtDBcollection.Text);
        }
    }
}
