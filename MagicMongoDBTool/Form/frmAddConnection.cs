using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
namespace MagicMongoDBTool
{
    public partial class frmAddConnection : Form
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
            OnLoad();
        }
        private void OnLoad() {
            cmdCancel.Click += new EventHandler((x, y) => { this.Close(); });
            numPort.GotFocus += new EventHandler((x, y) =>
            {
                numPort.Select(0, 5);
            });
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
            lblConnectionName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ConnectionName);
            lblHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Host);
            lblPort.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Port);
            lblUsername.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Username);
            lblPassword.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Password);
            lblDataBaseName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_DBName);
            lblMainReplsetName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_MainReplsetName);
            lblpriority.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Priority);
            chkSlaveOk.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_MasterSlave);
            chkSafeMode.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_SafeMode);
            lblTimeOut.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_TimeOut);
            lblAttentionPassword.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Password_Description);
            grpServerRole.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ShardingSvrType);
            radArbiters.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Arbitration);
            radConfigSrv.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Configuration);
            radDataSrv.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Data);
            radRouteSrv.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ServerType_Route);

            grpReplset.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSet);
            lblReplsetName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetName);
            cmdInitReplset.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetInit);
            lblReplsetList.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_ReplaceSetList);
            lblConnectionString.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ConnectionString);

            cmdAdd.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Add);
            cmdCancel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Cancel);
            lblAttentionPriority.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Attention_Description)
                    + System.Environment.NewLine + SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Attention2_Description);
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
                    if (ModifyConn.ServerRole == ConfigHelper.SvrRoleType.ReplsetSvr && ModifyConn.ReplsetList.Contains(item.ConnectionName))
                    {
                        lstServerce.SetSelected(lstServerce.Items.Count - 1, true);
                    }
                }
            }
            OnLoad();
            txtConnectionName.Text = ModifyConn.ConnectionName;
            txtConnectionName.Enabled = false;
            txtHost.Text = ModifyConn.Host;
            txtMainReplsetName.Text = ModifyConn.MainReplSetName;
            numPort.Text = ModifyConn.Port.ToString();
            txtUsername.Text = ModifyConn.UserName;
            txtPassword.Text = ModifyConn.Password;
            if (SystemManager.IsUseDefaultLanguage())
            {
                cmdAdd.Text = "Modify";
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
            numTimeOut.Value = ModifyConn.SocketTimeOut;
            txtConnectionString.Text = ModifyConn.ConnectionString;
            switch (ModifyConn.ServerRole)
            {
                case ConfigHelper.SvrRoleType.ConfigSvr:
                    radConfigSrv.Checked = true;
                    break;
                case ConfigHelper.SvrRoleType.RouteSvr:
                    radRouteSrv.Checked = true;
                    break;
                case ConfigHelper.SvrRoleType.ArbiterSvr:
                    radArbiters.Checked = true;
                    break;
                case ConfigHelper.SvrRoleType.DataSvr:
                    radDataSrv.Checked = true;
                    break;
                case ConfigHelper.SvrRoleType.MasterSvr:
                    radMaster.Checked = true;
                    break;
                case ConfigHelper.SvrRoleType.SlaveSvr:
                    radSlave.Checked = true;
                    break;
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

            ModifyConn.ConnectionName = txtConnectionName.Text;
            ///感谢 呆呆 的Bug 报告，不论txtConnectionString.Text是否存在都进行赋值，防止删除字符后，值还是保留的BUG
            ModifyConn.ConnectionString = txtConnectionString.Text;
            if (txtConnectionString.Text != String.Empty)
            {
                if (!MongoDBHelper.FillConfigWithConnectionString(ref ModifyConn))
                {
                    MyMessageBox.ShowMessage("Url Exception", "Url Formation，please check it");
                    return;
                };
                if (!String.IsNullOrEmpty(ModifyConn.DataBaseName))
                {
                    ModifyConn.LoginAsAdmin = true;
                }
            }
            else
            {
                ModifyConn.ReplsetList = new List<String>();
                ModifyConn.Host = txtHost.Text;
                if (numPort.Text != String.Empty)
                {
                    ModifyConn.Port = Convert.ToInt32(numPort.Text);
                }
                ModifyConn.IsSlaveOk = chkSlaveOk.Checked;
                ModifyConn.IsSafeMode = chkSafeMode.Checked;
                ModifyConn.ReplSetName = txtReplSetName.Text;
                ModifyConn.UserName = txtUsername.Text;
                ModifyConn.Password = txtPassword.Text;
                ModifyConn.DataBaseName = txtDataBaseName.Text;
                ModifyConn.MainReplSetName = txtMainReplsetName.Text;
                ModifyConn.Priority = (int)numPriority.Value;
                ModifyConn.SocketTimeOut = (int)numTimeOut.Value;

                //仅有用户名或密码
                if (txtUsername.Text != String.Empty && txtPassword.Text == String.Empty)
                {
                    MessageBox.Show("Please Input Password");
                    return;
                }
                if (txtUsername.Text == String.Empty && txtPassword.Text != String.Empty)
                {
                    MessageBox.Show("Please Input UserName");
                    return;
                }

                //数据库名称存在，则必须输入用户名和密码
                if (txtDataBaseName.Text != String.Empty)
                {
                    //用户名或者密码为空
                    if (txtUsername.Text == String.Empty || txtPassword.Text == String.Empty)
                    {
                        MessageBox.Show("Please Input UserName or Password");
                        return;
                    }
                }
                //是否用户是Admin
                if (txtDataBaseName.Text != String.Empty)
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
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.DataSvr;
                }
                //配置服务器
                if (radConfigSrv.Checked)
                {
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.ConfigSvr;
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
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.RouteSvr;
                    ModifyConn.LoginAsAdmin = true;
                    ModifyConn.IsSlaveOk = false;
                }
                //仲裁服务器
                if (this.radArbiters.Checked)
                {
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.ArbiterSvr;
                }

                if (this.radMaster.Checked)
                {
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.MasterSvr;
                }

                if (this.radSlave.Checked)
                {
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.SlaveSvr;
                    ModifyConn.IsSlaveOk = true;
                }

                //如果输入了副本名称
                if (this.txtReplSetName.Text != String.Empty)
                {
                    if (lstServerce.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Pls Input ReplsetName");
                        return;
                    }
                    foreach (String item in lstServerce.SelectedItems)
                    {
                        ModifyConn.ReplsetList.Add(item);
                    }
                    //这里将自动选择为副本服务器
                    ModifyConn.ServerRole = ConfigHelper.SvrRoleType.ReplsetSvr;
                }
                if (ModifyConn.MainReplSetName != String.Empty && ModifyConn.Priority == 0)
                {
                    MessageBox.Show("If Priority is 0,then it can't be the ReplaceSet server");
                }
            }
            //保存配置
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
        void txtReplSetName_TextChanged(object sender, System.EventArgs e)
        {
            lstServerce.Items.Clear();
            if (txtReplSetName.Text == String.Empty) { return; }
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.MainReplSetName == txtReplSetName.Text)
                {
                    lstServerce.Items.Add(item.ConnectionName);
                    if (ModifyConn.ServerRole == ConfigHelper.SvrRoleType.ReplsetSvr && ModifyConn.ReplsetList.Contains(item.ConnectionName))
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
            List<String> svrKeys = new List<String>();
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
                MyMessageBox.ShowMessage("InitReplicaSet", "InitReplicaSet Succeed, Please wait a minute", rtn.Response.ToString(), true);
            }
            else
            {
                MyMessageBox.ShowMessage("InitReplicaSet", "InitReplicaSet Failed", rtn.Response.ToString(), true);
            }
        }
    }
}
