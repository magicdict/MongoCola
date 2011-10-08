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
    public partial class frmConnect : frmBase
    {
        private Dictionary<String, ConfigHelper.MongoConnectionConfig> ConnectionList = new Dictionary<string, ConfigHelper.MongoConnectionConfig>();

        public frmConnect()
        {
            InitializeComponent();
        }
        private void frmConnect_Load(object sender, EventArgs e)
        {
            RefreshConnection();
        }
        private void RefreshConnection() {
            lstServerce.Items.Clear();
            foreach (var item in SystemManager.mConfig.MongoConnectionlst)
            {
                if (!ConnectionList.ContainsKey(item.HostName))
                {
                    ConnectionList.Add(item.HostName, item);
                }
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
            if (lstServerce.SelectedItems.Count > 0) {
                foreach (String item in lstServerce.SelectedItems)
                {
                    connlst.Add(ConnectionList[item]);
                }
                MongoDBHelpler.AddServer(connlst);
                this.Close();
            }
        }

        private void cmdDelCon_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmdModifyCon_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.wojilu.com");
        }
    }
}
