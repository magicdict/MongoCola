using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using QLFUI;
using GUIResource;

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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                SetText();
            }
        }
        /// <summary>
        /// 国际化
        /// </summary>
        private void SetText()
        {
            this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Title);
            lblHostName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Name);
            txtHostName.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Name_Description);
            lblIpAddr.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Address);
            txtIpAddr.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Address_Description);
            lblPort.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Port);
            txtPort.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Port_Description);
            lblUsername.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_UserName);
            txtUsername.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_UserName_Description);
            lblPassword.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Password);
            txtPassword.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Password_Description);
            lblDataBaseName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_DBName);
            txtDataBaseName.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_DBName_Description);
            lblMainReplsetName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_MainReplsetName);
            txtMainReplsetName.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_MainReplsetName_Description);
            lblpriority.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Priority);
            chkSlaveOk.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_MasterSlave);
            chkSafeMode.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_SafeMode);
            lblTimeOut.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_TimeOut);

            grpShardingSvrType.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ShardingSvrType);
            radArbiters.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Arbitration);
            radConfigSrv.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Configuration);
            radDataSrv.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Data);
            radRouteSrv.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Route);

            grpReplset.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSet);
            lblReplsetName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetName);
            txtReplSetName.WaterMark = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetName_Description);
            cmdInitReplset.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetInit);
            lblReplsetList.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetList);


            cmdAdd.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Add);
            cmdCancel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Cancel);
            lblAttention.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Attention_Description)
                    + "\r\n"  + SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Attention2_Description);
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

            if (!SystemManager.IsUseDefaultLanguage())
            {
                SetText();
            }
            txtHostName.Text = ModifyConn.ConnectionName;
            txtHostName.Enabled = false;
            txtIpAddr.Text = ModifyConn.IpAddr;
            txtMainReplsetName.Text = ModifyConn.MainReplSetName;
            txtPort.Text = ModifyConn.Port.ToString();
            txtUsername.Text = ModifyConn.UserName;
            txtPassword.Text = ModifyConn.Password;
            if (!SystemManager.IsUseDefaultLanguage())
            {
                cmdAdd.Text = "修改";
            }
            else
            {
                cmdAdd.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Modify);
            }
            chkSlaveOk.Checked = ModifyConn.IsSlaveOk;
            chkSafeMode.Checked = ModifyConn.IsSafeMode;
            txtReplSetName.Text = ModifyConn.ReplSetName;
            txtDataBaseName.Text = ModifyConn.DataBaseName;
            numPriority.Value = ModifyConn.Priority;
            numTimeOut.Value = ModifyConn.TimeOut;

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
            ModifyConn.ReplSetName = txtReplSetName.Text;
            ModifyConn.UserName = txtUsername.Text;
            ModifyConn.Password = txtPassword.Text;
            ModifyConn.DataBaseName = txtDataBaseName.Text;
            ModifyConn.MainReplSetName = txtMainReplsetName.Text;
            ModifyConn.Priority = (int)numPriority.Value;
            ModifyConn.TimeOut = (int)numTimeOut.Value;

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
            if (this.txtReplSetName.Text != String.Empty)
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
            if (txtReplSetName.Text == String.Empty) { return; }
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.MainReplSetName == txtReplSetName.Text)
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
            CommandResult rtn = MongoDBHelper.InitReplicaSet(txtReplSetName.Text, svrKeys);
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
