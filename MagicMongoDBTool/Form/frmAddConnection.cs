using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using QLFUI;

namespace MagicMongoDBTool
{
    public partial class frmAddConnection : QLFUI.QLFForm
    {
        /// <summary>
        /// 连接配置
        /// </summary>
        public ConfigHelper.MongoConnectionConfig ModifyConn = new ConfigHelper.MongoConnectionConfig();
        /// <summary>
        /// 初始化（新建）
        /// </summary>
        public frmAddConnection()
        {
            InitializeComponent();
            cmdCancel.Click += new EventHandler((x, y) => { this.Close(); });
        }
        /// <summary>
        /// 初始化（修改）
        /// </summary>
        /// <param name="ConnectionName"></param>
        public frmAddConnection(String ConnectionName)
        {

            InitializeComponent();
            //Modify Mode
            ModifyConn = SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName];

            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.MainReplSetName == ModifyConn.ReplSetName)
                {
                    lstServerce.Items.Add(item.ConnectionName);
                    if (ModifyConn.ServerType == ConfigHelper.SvrType.ReplsetSvr && ModifyConn.ReplsetList.Contains(item.ConnectionName))
                    {
                        lstServerce.SetSelected(lstServerce.Items.Count - 1, true);
                    }
                }
            }
            cmdCancel.Click += new EventHandler((x, y) => { this.Close(); });


            txtHostName.Text = ModifyConn.ConnectionName;
            txtHostName.Enabled = false;
            txtIpAddr.Text = ModifyConn.IpAddr;
            txtMainReplsetName.Text = ModifyConn.MainReplSetName;
            txtPort.Text = ModifyConn.Port.ToString();
            txtUsername.Text = ModifyConn.UserName;
            txtPassword.Text = ModifyConn.Password;
            cmdAdd.Text = "修改";
            chkSlaveOk.Checked = ModifyConn.IsSlaveOk;
            chkSafeMode.Checked = ModifyConn.IsSafeMode;
            txtReplSet.Text = ModifyConn.ReplSetName;
            txtDataBaseName.Text = ModifyConn.DataBaseName;
            numPriority.Value = ModifyConn.Priority;

            switch (ModifyConn.ServerType)
            {
                case ConfigHelper.SvrType.ConfigSvr:
                    radConfigSrv.Checked = true;
                    break;
                case ConfigHelper.SvrType.RouteSvr:
                    radRouteSrv.Checked = true;
                    break;
                case ConfigHelper.SvrType.ArbiterSvr:
                    radArbiters.Checked = true;
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
            ModifyConn.ConnectionName = txtHostName.Text;
            ModifyConn.IpAddr = txtIpAddr.Text;
            if (txtPort.Text != String.Empty)
            {
                ModifyConn.Port = Convert.ToInt32(txtPort.Text);
            }
            ModifyConn.IsSlaveOk = chkSlaveOk.Checked;
            ModifyConn.IsSafeMode = chkSafeMode.Checked;
            ModifyConn.ReplSetName = txtReplSet.Text;
            ModifyConn.UserName = txtUsername.Text;
            ModifyConn.Password = txtPassword.Text;
            ModifyConn.DataBaseName = txtDataBaseName.Text;
            ModifyConn.MainReplSetName = txtMainReplsetName.Text;
            ModifyConn.Priority = (int)numPriority.Value;
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

            //数据库名称存在，则必须输入用户名和密码
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
                //没有数据库名称的时候，只能以Admin登陆
                ModifyConn.LoginAsAdmin = false;
            }
            else
            {
                //有数据库的时候，不能以Admin登陆
                ModifyConn.LoginAsAdmin = true;
            }

            //普通服务器
            if (radDataSrv.Checked)
            {
                ModifyConn.ServerType = ConfigHelper.SvrType.DataSvr;
            }
            //配置服务器
            if (radConfigSrv.Checked)
            {
                ModifyConn.ServerType = ConfigHelper.SvrType.ConfigSvr;
                //Config和Route不能设置为SlaveOK模式,必须设置为Admin模式
                //文件下载的时候也不能使用SlaveOK模式
                ModifyConn.LoginAsAdmin = true;
                ModifyConn.IsSlaveOk = false;
            }
            //路由服务器
            if (radRouteSrv.Checked)
            {
                //Config和Route不能设置为SlaveOK模式,必须设置为Admin模式
                //文件下载的时候也不能使用SlaveOK模式
                ModifyConn.ServerType = ConfigHelper.SvrType.RouteSvr;
                ModifyConn.LoginAsAdmin = true;
                ModifyConn.IsSlaveOk = false;
            }
            //仲裁服务器
            if (this.radArbiters.Checked)
            {
                ModifyConn.ServerType = ConfigHelper.SvrType.ArbiterSvr;
            }
            //如果输入了副本名称
            if (this.txtReplSet.Text != String.Empty)
            {
                if (lstServerce.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择副本服务器");
                    return;
                }
                foreach (String item in lstServerce.SelectedItems)
                {
                    ModifyConn.ReplsetList.Add(item);
                }
                //这里将自动选择为副本服务器
                ModifyConn.ServerType = ConfigHelper.SvrType.ReplsetSvr;
            }
            if (ModifyConn.MainReplSetName != String.Empty && ModifyConn.Priority == 0)
            {
                MessageBox.Show("由于优先度为 0 ，所以当前服务器无法成为Primary服务器！");
            }
            if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(ModifyConn.ConnectionName))
            {
                SystemManager.ConfigHelperInstance.ConnectionList[ModifyConn.ConnectionName] = ModifyConn;
            }
            else
            {
                SystemManager.ConfigHelperInstance.ConnectionList.Add(ModifyConn.ConnectionName, ModifyConn);
            }
            this.Close();
        }
        /// <summary>
        /// 动态更新主副本为指定副本的服务器列表
        /// </summary>
        /// <param name="strNewText"></param>
        private void txtReplSet_TextChanged(string strNewText)
        {
            lstServerce.Items.Clear();
            if (txtReplSet.Text == String.Empty) { return; }
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.MainReplSetName == txtReplSet.Text)
                {
                    lstServerce.Items.Add(item.ConnectionName);
                    if (ModifyConn.ServerType == ConfigHelper.SvrType.ReplsetSvr && ModifyConn.ReplsetList.Contains(item.ConnectionName))
                    {
                        lstServerce.SetSelected(lstServerce.Items.Count - 1, true);
                    }
                }
            }
        }
        /// <summary>
        /// 初始化副本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdInitReplset_Click(object sender, EventArgs e)
        {
            List<String> svrKeys = new List<string>();
            if (lstServerce.SelectedItems.Count > 0)
            {
                foreach (String item in lstServerce.SelectedItems)
                {
                    svrKeys.Add(item);
                }
            }
            //初始化副本，将多个服务器组合成一个副本组
            CommandResult rtn = MongoDBHelper.InitReplicaSet(txtReplSet.Text, svrKeys);
            if (rtn.Ok)
            {
                MyMessageBox.ShowMessage("初始化成功,请稍等片刻后连接服务器", rtn.Response.ToString());
            }
            else
            {
                MyMessageBox.ShowMessage("初始化失败", rtn.Response.ToString());
            }
        }
    }
}
