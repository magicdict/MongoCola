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
    public partial class frmAddConnection : frmBase
    {
        public ConfigHelper.MongoConnectionConfig ModifyConn = new ConfigHelper.MongoConnectionConfig();
        public frmAddConnection()
        {
            InitializeComponent();
        }
        public frmAddConnection(String ConnectionName)
        {
            InitializeComponent();
            //Modify Mode
            ModifyConn = SystemManager.mConfig.ConnectionList[ConnectionName];
            txtHostName.Text = ModifyConn.HostName;
            txtHostName.Enabled = false;
            txtIpAddr.Text = ModifyConn.IpAddr;
            txtPort.Text = ModifyConn.Port.ToString();
            cmdAdd.Text = "修改";
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ModifyConn.HostName = txtHostName.Text;
            ModifyConn.IpAddr = txtIpAddr.Text;
            ModifyConn.Port = Convert.ToInt32(txtPort.Text);
            if (SystemManager.mConfig.ConnectionList.ContainsKey(ModifyConn.HostName))
            {
                SystemManager.mConfig.ConnectionList[ModifyConn.HostName] = ModifyConn;
            }
            else
            {
                SystemManager.mConfig.ConnectionList.Add(ModifyConn.HostName, ModifyConn);
            }
            this.Close();
        }
    }
}
