using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmConnect : QLFUI.QLFForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }
        private void frmConnect_Load(object sender, EventArgs e)
        {
            RefreshConnection();
        }
        private void RefreshConnection()
        {
            lstServerce.Items.Clear();
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                lstServerce.Items.Add(item.ConnectionName);
            }
            SystemManager.ConfigHelperInstance.SaveToConfigFile("config.xml");
        }

        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            frmAddConnection frmAddCon = new frmAddConnection();
            frmAddCon.ShowDialog();
            frmAddCon.Close();
            frmAddCon.Dispose();
            RefreshConnection();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            List<ConfigHelper.MongoConnectionConfig> connLst = new List<ConfigHelper.MongoConnectionConfig>();
            if (lstServerce.SelectedItems.Count > 0)
            {
                foreach (string item in lstServerce.SelectedItems)
                {
                    connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList[item]);
                }
                MongoDBHelpler.AddServer(connLst);
                this.Close();
            }
        }
        private void cmdDelCon_Click(object sender, EventArgs e)
        {
            foreach (string item in lstServerce.SelectedItems)
            {
                if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(item))
                {
                    SystemManager.ConfigHelperInstance.ConnectionList.Remove(item);
                }
            }
            RefreshConnection();
        }

        private void cmdModifyCon_Click(object sender, EventArgs e)
        {
            if (lstServerce.SelectedItems.Count == 1)
            {
                frmAddConnection mfrm = new frmAddConnection(lstServerce.SelectedItem.ToString());
                mfrm.ShowDialog();
                mfrm.Close();
                mfrm.Dispose();
                RefreshConnection();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
