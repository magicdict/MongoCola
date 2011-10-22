using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.mConfig.ConnectionList.Values)
            {
                lstServerce.Items.Add(item.HostName);
            }
            SystemManager.mConfig.SaveToConfigFile("config.xml");
        }

        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            frmAddConnection mfrm = new frmAddConnection();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
            RefreshConnection();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            List<ConfigHelper.MongoConnectionConfig> connlst = new List<ConfigHelper.MongoConnectionConfig>();
            if (lstServerce.SelectedItems.Count > 0)
            {
                foreach (String item in lstServerce.SelectedItems)
                {
                    connlst.Add(SystemManager.mConfig.ConnectionList[item]);
                }
                MongoDBHelpler.AddServer(connlst);
                this.Close();
            }
        }
        private void cmdDelCon_Click(object sender, EventArgs e)
        {
            foreach (String item in lstServerce.SelectedItems)
            {
                if (SystemManager.mConfig.ConnectionList.ContainsKey(item))
                {
                    SystemManager.mConfig.ConnectionList.Remove(item);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.wojilu.com");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

        }


    }
}
