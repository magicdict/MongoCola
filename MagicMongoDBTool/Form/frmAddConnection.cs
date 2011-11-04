using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Collections.Generic;

namespace MagicMongoDBTool
{
    public partial class frmAddConnection : QLFUI.QLFForm
    {
        public ConfigHelper.MongoConnectionConfig ModifyConn = new ConfigHelper.MongoConnectionConfig();
        public frmAddConnection()
        {
            InitializeComponent();
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                lstServerce.Items.Add(item.HostName);
            }
            cmdCancel.Click += new EventHandler((x, y) => { this.Close(); });
        }
        public frmAddConnection(String ConnectionName)
        {

            InitializeComponent();

            //Modify Mode
            ModifyConn = SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName];

            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                lstServerce.Items.Add(item.HostName);

                if (ModifyConn.ServerType == ConfigHelper.SvrType.ReplsetSvr && ModifyConn.ReplsetList.Contains(item.HostName))
                {
                    lstServerce.SetSelected(lstServerce.Items.Count - 1, true); 
                }
            }
            cmdCancel.Click += new EventHandler((x, y) => { this.Close(); });


            txtHostName.Text = ModifyConn.HostName;
            txtHostName.Enabled = false;
            txtIpAddr.Text = ModifyConn.IpAddr;
            txtPort.Text = ModifyConn.Port.ToString();
            txtUsername.Text = ModifyConn.UserName;
            txtPassword.Text = ModifyConn.Password;
            cmdAdd.Text = "修改";
            chkSlaveOk.Checked = ModifyConn.IsSlaveOk;
            txtReplSet.Text = ModifyConn.ReplSetName;


            txtDataBaseName.Text = ModifyConn.DataBaseName;
            chkLoginAsAdmin.Checked = ModifyConn.LoginAsAdmin;

            switch (ModifyConn.ServerType)
            {
                case ConfigHelper.SvrType.ConfigSvr:
                    radConfigSrv.Checked = true;
                    break;
                case ConfigHelper.SvrType.RouteSvr:
                    radRouteSrv.Checked = true;
                    break;
                case ConfigHelper.SvrType.ReplsetSvr:
                    radReplSet.Checked = true;
                    break;
                case ConfigHelper.SvrType.DataSvr:
                default:
                    radDataSrv.Checked = true;
                    break;
            }

        }
        /// <summary>
        /// 新建或者修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ModifyConn.ReplsetList = new List<String>();
            ModifyConn.HostName = txtHostName.Text;
            ModifyConn.IpAddr = txtIpAddr.Text;
            if (txtPort.Text != String.Empty)
            {
                ModifyConn.Port = Convert.ToInt32(txtPort.Text);
            }
            ModifyConn.IsSlaveOk = chkSlaveOk.Checked;
            ModifyConn.ReplSetName = txtReplSet.Text;
            ModifyConn.UserName = txtUsername.Text;
            ModifyConn.Password = txtPassword.Text;
            ModifyConn.DataBaseName = txtDataBaseName.Text;
            ModifyConn.LoginAsAdmin = chkLoginAsAdmin.Checked;
            //仅有用户名或密码
            if (txtUsername.Text != string.Empty && txtPassword.Text == String.Empty)
            {
                MessageBox.Show("请输入密码");
                return;
            }
            if (txtUsername.Text == string.Empty && txtPassword.Text != String.Empty)
            {
                MessageBox.Show("请输入用户名");
                return;
            }
            //数据库名称存在
            if (txtDataBaseName.Text != string.Empty)
            {
                //用户名或者密码为空
                if (txtUsername.Text == string.Empty || txtPassword.Text == String.Empty)
                {
                    MessageBox.Show("请输入用户名或密码");
                    return;
                }
            }

            if (txtDataBaseName.Text != string.Empty)
            {
                //没有数据库的时候，只能以Admin登陆
                ModifyConn.LoginAsAdmin = false;
            }
            else
            {
                //数据库的时候，默认不以Admin登陆
                ModifyConn.LoginAsAdmin = true;
            }
            if (radDataSrv.Checked)
            {
                ModifyConn.ServerType = ConfigHelper.SvrType.DataSvr;
            }
            if (radConfigSrv.Checked)
            {
                ModifyConn.ServerType = ConfigHelper.SvrType.ConfigSvr;
                //Config和Route不能设置为SlaveOK模式,必须设置为Admin模式
                //文件下载的时候也不能使用SlaveOK模式
                ModifyConn.LoginAsAdmin = true;
                ModifyConn.IsSlaveOk = false;
            }
            if (radRouteSrv.Checked)
            {
                //Config和Route不能设置为SlaveOK模式,必须设置为Admin模式
                //文件下载的时候也不能使用SlaveOK模式
                ModifyConn.ServerType = ConfigHelper.SvrType.RouteSvr;
                ModifyConn.LoginAsAdmin = true;
                ModifyConn.IsSlaveOk = false;
            }

            //副本
            if (this.radReplSet.Checked)
            {
                if (lstServerce.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请输入用户名或密码");
                    return;
                }
                foreach (String item in lstServerce.SelectedItems)
                {
                    ModifyConn.ReplsetList.Add(item);
                }
                ModifyConn.ServerType = ConfigHelper.SvrType.ReplsetSvr;
            }

            if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(ModifyConn.HostName))
            {
                SystemManager.ConfigHelperInstance.ConnectionList[ModifyConn.HostName] = ModifyConn;
            }
            else
            {
                SystemManager.ConfigHelperInstance.ConnectionList.Add(ModifyConn.HostName, ModifyConn);
            }

            this.Close();
        }
    }
}
