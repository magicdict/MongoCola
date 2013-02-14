using MagicMongoDBTool.Module;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MagicMongoDBTool
{

    public partial class frmAddConnection : Form
    {
        //http://www.mongodb.org/display/DOCS/Connections

        /// <summary>
        /// 连接配置
        /// </summary>
        public ConfigHelper.MongoConnectionConfig ModifyConn = new ConfigHelper.MongoConnectionConfig();
        /// <summary>
        /// 
        /// </summary>
        public String OldConnectionName = String.Empty;
        /// <summary>
        /// 初始化（新建）
        /// </summary>
        public frmAddConnection()
        {
            InitializeComponent();
            OnLoad();
        }
        private void OnLoad()
        {
            cmdCancel.Click += new EventHandler((x, y) => { this.Close(); });
            numPort.GotFocus += new EventHandler((x, y) =>
            {
                numPort.Select(0, 5);
            });
            NumReplPort.GotFocus += new EventHandler((x, y) =>
            {
                this.NumReplPort.Select(0, 5);
            });
            NumSocketTimeOut.GotFocus += new EventHandler((x, y) =>
            {
                this.NumSocketTimeOut.Select(0, 5);
            });
            NumConnectTimeOut.GotFocus += new EventHandler((x, y) =>
            {
                this.NumConnectTimeOut.Select(0, 5);
            });
            NumWTimeoutMS.GotFocus += new EventHandler((x, y) =>
            {
                this.NumWTimeoutMS.Select(0, 5);
            });
            NumWaitQueueSize.GotFocus += new EventHandler((x, y) =>
            {
                this.NumWaitQueueSize.Select(0, 5);
            });

            //读策略
            //http://docs.mongodb.org/manual/reference/connection-string/#read-preference-options
            //https://github.com/mongodb/mongo-csharp-driver/blob/master/MongoDB.Driver/ReadPreference.cs
            cmbReadPreference.Items.Add(ReadPreference.Primary.ToString());
            cmbReadPreference.Items.Add(ReadPreference.PrimaryPreferred.ToString());
            cmbReadPreference.Items.Add(ReadPreference.Secondary.ToString());
            cmbReadPreference.Items.Add(ReadPreference.SecondaryPreferred.ToString());
            cmbReadPreference.Items.Add(ReadPreference.Nearest.ToString());

            //写确认
            //http://docs.mongodb.org/manual/reference/connection-string/#write-concern-options
            //https://github.com/mongodb/mongo-csharp-driver/blob/master/MongoDB.Driver/WriteConcern.cs
            //-1 – The driver will not acknowledge write operations and will suppress all network or socket errors.
            cmbWriteConcern.Items.Add(WriteConcern.Unacknowledged.ToString());
            //1   -  Provides basic acknowledgment of write operations.
            cmbWriteConcern.Items.Add(WriteConcern.Acknowledged.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.W2.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.W3.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.W4.ToString());
            cmbWriteConcern.Items.Add(WriteConcern.WMajority.ToString());


            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Title);
                lblConnectionName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ConnectionName);
                lblHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Host);
                lblPort.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Port);
                lblUsername.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Username);
                lblPassword.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Password);
                lblDataBaseName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_DBName);
                lblConnectionString.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ConnectionString);
                lblAttentionPassword.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Password_Description);


                lblsocketTimeout.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_SocketTimeOut);
                lblConnectTimeout.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_ConnectionTimeOut);


                lblMainReplsetName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_MainReplsetName);
                lblReplHost.Text = lblHost.Text;
                lblReplPort.Text = lblPort.Text;
                cmdAddHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_AddHost);
                cmdRemoveHost.Text = SystemManager.mStringResource.GetText(StringResource.TextType.AddConnection_Region_RemoveHost);

                cmdAdd.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Add);
                cmdCancel.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Cancel);
                cmdTest.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Test);
            }
        }
        /// <summary>
        /// 初始化（修改）
        /// </summary>
        /// <param name="ConnectionName"></param>
        public frmAddConnection(String ConnectionName)
        {
            InitializeComponent();
            OldConnectionName = ConnectionName;
            //Modify Mode
            ModifyConn = SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName];
            OnLoad();

            txtConnectionName.Text = ModifyConn.ConnectionName;

            txtHost.Text = ModifyConn.Host;
            numPort.Text = ModifyConn.Port.ToString();
            txtUsername.Text = ModifyConn.UserName;
            txtPassword.Text = ModifyConn.Password;
            txtDataBaseName.Text = ModifyConn.DataBaseName;
            if (ModifyConn.ReadPreference != string.Empty)
            {
                cmbReadPreference.Text = ModifyConn.ReadPreference;
            }
            if (ModifyConn.WriteConcern != string.Empty)
            {
                cmbWriteConcern.Text = ModifyConn.WriteConcern;
            }
            chkFsync.Checked = ModifyConn.fsync;
            chkJournal.Checked = ModifyConn.journal;

            NumWTimeoutMS.Value = (decimal)ModifyConn.wtimeoutMS;
            NumSocketTimeOut.Value = (decimal)ModifyConn.socketTimeoutMS;
            NumConnectTimeOut.Value = (decimal)ModifyConn.connectTimeoutMS;
            NumWaitQueueSize.Value = ModifyConn.WaitQueueSize;

            txtReplsetName.Text = ModifyConn.ReplSetName;

            txtConnectionString.Text = ModifyConn.ConnectionString;

            foreach (string item in ModifyConn.ReplsetList)
            {
                lstHost.Items.Add(item);
            }

            if (SystemManager.IsUseDefaultLanguage)
            {
                cmdAdd.Text = "Modify";
            }
            else
            {
                cmdAdd.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Modify);
            }
        }
        /// <summary>
        /// 新建或者修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            CreateConnection();
            String NewCollectionName = txtConnectionName.Text;
            if (OldConnectionName != String.Empty)
            {
                //如果有旧名称，说明是修改模式
                if (OldConnectionName != NewCollectionName)
                {
                    //修改了名称,检查一下新的名字是否存在
                    if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(NewCollectionName))
                    {
                        //存在则警告
                        MyMessageBox.ShowMessage("Connection", "Connection Name Already Exist!");
                        return;
                    }
                    else
                    {
                        //不存在则删除旧的记录
                        SystemManager.ConfigHelperInstance.ConnectionList.Remove(OldConnectionName);
                    }
                }
            }
            //保存配置
            if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(NewCollectionName))
            {
                SystemManager.ConfigHelperInstance.ConnectionList[NewCollectionName] = ModifyConn;
            }
            else
            {
                SystemManager.ConfigHelperInstance.ConnectionList.Add(NewCollectionName, ModifyConn);
            }
            this.Close();
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTest_Click(object sender, EventArgs e)
        {
            CreateConnection();
            try
            {
                MongoServer srv = MongoDBHelper.CreateMongoServer(ref ModifyConn);
                srv.Connect();
                srv.Disconnect();
                MyMessageBox.ShowMessage("Connect Test", "Connected OK.");
            }
            catch (MongoAuthenticationException ex)
            {
                //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    MyMessageBox.ShowMessage(SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException),
                                             SystemManager.mStringResource.GetText(StringResource.TextType.Exception_AuthenticationException_Note), ex.ToString(), true);
                }
                else
                {
                    MyMessageBox.ShowMessage("MongoAuthenticationException:", "Please check UserName and Password", ex.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                //暂时不处理任何异常，简单跳过
                //无法连接的理由：
                //1.服务器没有启动
                //2.认证模式不正确
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    MyMessageBox.ShowMessage(SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected),
                                             SystemManager.mStringResource.GetText(StringResource.TextType.Exception_NotConnected_Note), ex.ToString(), true);
                }
                else
                {
                    MyMessageBox.ShowMessage("Exception", "Mongo Server may not Startup or Auth Mode is not correct", ex.ToString(), true);
                }
            }
        }
        /// <summary>
        /// 新建连接
        /// </summary>
        private void CreateConnection()
        {
            ModifyConn.ConnectionName = txtConnectionName.Text;
            ///感谢 呆呆 的Bug 报告，不论txtConnectionString.Text是否存在都进行赋值，防止删除字符后，值还是保留的BUG
            ModifyConn.ConnectionString = txtConnectionString.Text;
            if (txtConnectionString.Text != String.Empty)
            {
                String strException = MongoDBHelper.FillConfigWithConnectionString(ref ModifyConn);
                if (strException != String.Empty)
                {
                    MyMessageBox.ShowMessage("Url Exception", "Url Formation，please check it", strException);
                    return;
                };
            }
            else
            {
                ModifyConn.Host = txtHost.Text;
                if (numPort.Text != String.Empty)
                {
                    ModifyConn.Port = Convert.ToInt32(numPort.Text);
                }
                else
                {
                    ModifyConn.Port = 0;
                }
                ModifyConn.UserName = txtUsername.Text;
                ModifyConn.Password = txtPassword.Text;
                ModifyConn.DataBaseName = txtDataBaseName.Text;

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

                ModifyConn.socketTimeoutMS = (double)NumSocketTimeOut.Value;
                ModifyConn.connectTimeoutMS = (double)NumConnectTimeOut.Value;
                ModifyConn.wtimeoutMS = (double)NumWTimeoutMS.Value;
                ModifyConn.WaitQueueSize = (int)NumWaitQueueSize.Value;

                ModifyConn.journal = chkJournal.Checked;
                ModifyConn.fsync = chkFsync.Checked;
                ModifyConn.WriteConcern = cmbWriteConcern.Text;
                ModifyConn.ReadPreference = cmbReadPreference.Text;

                ModifyConn.ReplSetName = txtReplsetName.Text;
                ModifyConn.ReplsetList = new List<string>();
                foreach (String item in lstHost.Items)
                {
                    ModifyConn.ReplsetList.Add(item);
                }

            }
        }
        /// <summary>
        /// 添加HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            String strHost = String.Empty;
            if (!string.IsNullOrEmpty(strHost))
            {
                strHost = txtReplHost.Text;
                if (NumReplPort.Value != 0)
                {
                    strHost += ":" + NumReplPort.Value.ToString();
                    lstHost.Items.Add(strHost);
                }

            }
        }
        /// <summary>
        /// 移除HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            lstHost.Items.Remove(lstHost.SelectedItem);
        }

        private void lnkReadPreference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://docs.mongodb.org/manual/reference/connection-string/#read-preference-options");
        }

        private void lnkWriteConcern_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://docs.mongodb.org/manual/reference/connection-string/#write-concern-options");
        }

    }
}
