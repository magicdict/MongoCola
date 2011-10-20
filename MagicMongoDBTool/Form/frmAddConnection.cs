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
            chkSlaveOk.Checked = ModifyConn.IsSlaveOk;
            txtReplSet.Text = ModifyConn.ReplSetName;


            switch (ModifyConn.ServerType) { 
                case ConfigHelper.SrvType.ConfigSrv:
                    radConfigSrv.Checked = true;
                    break;
                case ConfigHelper.SrvType.RouteSrv:
                    radRouteSrv.Checked = true;
                    break;
                case ConfigHelper.SrvType.DataSrv:
                default:
                    radDataSrv.Checked = true;
                    break;
            }   
               
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ModifyConn.HostName = txtHostName.Text;
            ModifyConn.IpAddr = txtIpAddr.Text;
            ModifyConn.Port = Convert.ToInt32(txtPort.Text);
            ModifyConn.IsSlaveOk = chkSlaveOk.Checked;
            ModifyConn.ReplSetName = txtReplSet.Text;
            if (radDataSrv.Checked) { 
                ModifyConn.ServerType = ConfigHelper.SrvType.DataSrv; 
            }
            if (radConfigSrv.Checked) { 
                ModifyConn.ServerType = ConfigHelper.SrvType.ConfigSrv;
                if (ModifyConn.IsSlaveOk)
                {
                    //Config和Route不能设置为SlaveOK模式
                    //文件下载的时候也不能使用SlaveOK模式
                    ModifyConn.IsSlaveOk = false;
                }
            }
            if (radRouteSrv.Checked) { 
                ModifyConn.ServerType = ConfigHelper.SrvType.RouteSrv;
                if (ModifyConn.IsSlaveOk) {
                    //Config和Route不能设置为SlaveOK模式
                    //文件下载的时候也不能使用SlaveOK模式
                    ModifyConn.IsSlaveOk = false;
                }
            }

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
