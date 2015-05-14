using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm.Connection
{
    public partial class FrmConnectionMgr : Form
    {
        //http://www.mongodb.org/display/DOCS/Connections

        /// <summary>
        ///     连接配置
        /// </summary>
        public MongoConnectionConfig ModifyConn = new MongoConnectionConfig();

        /// <summary>
        ///     修改模式中，原来的连接
        /// </summary>
        public string OldConnectionName = string.Empty;

        /// <summary>
        ///     初始化（新建）
        /// </summary>
        public FrmConnectionMgr()
        {
            InitializeComponent();

        }

        /// <summary>
        ///     初始化（修改）
        /// </summary>
        /// <param name="connectionName"></param>
        public FrmConnectionMgr(string connectionName)
        {
            InitializeComponent();
            OldConnectionName = connectionName;
            //Modify Mode
            ModifyConn = MongoConnectionConfig.MongoConfig.ConnectionList[connectionName];

            txtConnectionName.Text = ModifyConn.ConnectionName;

            txtHost.Text = ModifyConn.Host;
            numPort.Text = ModifyConn.Port.ToString(CultureInfo.InvariantCulture);
            txtUsername.Text = ModifyConn.UserName;
            txtPassword.Text = ModifyConn.Password;
            txtDataBaseName.Text = ModifyConn.DataBaseName;
            chkFsync.Checked = ModifyConn.Fsync;
            chkJournal.Checked = ModifyConn.Journal;

            NumSocketTimeOut.Value = (decimal) ModifyConn.SocketTimeoutMs;
            NumConnectTimeOut.Value = (decimal) ModifyConn.ConnectTimeoutMs;

            txtReplsetName.Text = ModifyConn.ReplSetName;
            txtConnectionString.Text = ModifyConn.ConnectionString;

            foreach (var item in ModifyConn.ReplsetList)
            {
                lstHost.Items.Add(item);
            }
            cmbStorageEngine.SelectedIndex = ModifyConn.StorageEngine == EnumMgr.StorageEngineType.MmaPv1 ? 0 : 1;
            cmdAdd.Text = GuiConfig.IsUseDefaultLanguage? "Modify": GuiConfig.GetText(TextType.CommonModify);
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddConnection_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof (EnumMgr.StorageEngineType)))
            {
                cmbStorageEngine.Items.Add(item);
                cmbStorageEngine.SelectedIndex = 0;
            }
            cmdCancel.Click += (x, y) => Close();
            numPort.GotFocus += (x, y) => numPort.Select(0, 5);
            NumReplPort.GotFocus += (x, y) => NumReplPort.Select(0, 5);
            NumSocketTimeOut.GotFocus += (x, y) => NumSocketTimeOut.Select(0, 5);
            NumConnectTimeOut.GotFocus += (x, y) => NumConnectTimeOut.Select(0, 5);
            //Color
            cmdTest.BackColor = GuiConfig.ActionColor;
            cmdAdd.BackColor = GuiConfig.SuccessColor;
            cmdCancel.BackColor = GuiConfig.FailColor;
            GuiConfig.Translateform(this);
        }

        /// <summary>
        ///     新建或者修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            CreateConnection();
            var newCollectionName = txtConnectionName.Text;
            if (OldConnectionName != string.Empty)
            {
                //如果有旧名称，说明是修改模式
                if (OldConnectionName != newCollectionName)
                {
                    //修改了名称,检查一下新的名字是否存在
                    if (MongoConnectionConfig.MongoConfig.ConnectionList.ContainsKey(newCollectionName))
                    {
                        //存在则警告
                        MyMessageBox.ShowMessage("Connection", "Connection Name Already Exist!");
                        return;
                    }
                    //不存在则删除旧的记录
                    MongoConnectionConfig.MongoConfig.ConnectionList.Remove(OldConnectionName);
                }
            }
            //保存配置
            if (MongoConnectionConfig.MongoConfig.ConnectionList.ContainsKey(newCollectionName))
            {
                MongoConnectionConfig.MongoConfig.ConnectionList[newCollectionName] = ModifyConn;
            }
            else
            {
                MongoConnectionConfig.MongoConfig.ConnectionList.Add(newCollectionName, ModifyConn);
            }
            Close();
        }

        /// <summary>
        ///     测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTest_Click(object sender, EventArgs e)
        {
            CreateConnection();
            try
            {
                var srv = RuntimeMongoDbContext.CreateMongoServer(ref ModifyConn);
                srv.Connect();
                srv.Disconnect();
                MyMessageBox.ShowMessage("Connect Test", "Connected OK.");
            }
            catch (MongoAuthenticationException ex)
            {
                //需要验证的数据服务器，没有Admin权限无法获得数据库列表
                if (!GuiConfig.IsUseDefaultLanguage)
                {
                    MyMessageBox.ShowMessage(
                        GuiConfig.GetText(
                            TextType.ExceptionAuthenticationException),
                        GuiConfig.GetText(
                            TextType.ExceptionAuthenticationExceptionNote), ex.ToString(), true);
                }
                else
                {
                    MyMessageBox.ShowMessage("MongoAuthenticationException:", "Please check UserName and Password",
                        ex.ToString(), true);
                }
            }
            catch (Exception ex)
            {
                //暂时不处理任何异常，简单跳过
                //无法连接的理由：
                //1.服务器没有启动
                //2.认证模式不正确
                if (!GuiConfig.IsUseDefaultLanguage)
                {
                    MyMessageBox.ShowMessage(
                        GuiConfig.GetText(TextType.ExceptionNotConnected),
                        GuiConfig.GetText(
                            TextType.ExceptionNotConnectedNote),
                        ex.ToString(), true);
                }
                else
                {
                    MyMessageBox.ShowMessage("Exception", "Mongo Server may not Startup or Auth Mode is not correct",
                        ex.ToString(), true);
                }
            }
        }

        /// <summary>
        ///     新建连接
        /// </summary>
        private void CreateConnection()
        {
            ModifyConn.ConnectionName = txtConnectionName.Text;
            //感谢 呆呆 的Bug 报告，不论txtConnectionString.Text是否存在都进行赋值，防止删除字符后，值还是保留的BUG
            ModifyConn.ConnectionString = txtConnectionString.Text;
            if (txtConnectionString.Text != string.Empty)
            {
                var strException = MongoHelper.FillConfigWithConnectionString(ref ModifyConn);
                if (strException != string.Empty)
                {
                    MyMessageBox.ShowMessage("Url Exception", "Url Formation，please check it", strException);
                }
            }
            else
            {
                ModifyConn.Host = txtHost.Text;
                ModifyConn.Port = numPort.Text != string.Empty ? Convert.ToInt32(numPort.Text) : 0;
                ModifyConn.UserName = txtUsername.Text;
                ModifyConn.Password = txtPassword.Text;
                ModifyConn.DataBaseName = txtDataBaseName.Text;

                //仅有用户名或密码
                if (txtUsername.Text != string.Empty && txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Please Input Password");
                    return;
                }
                if (txtUsername.Text == string.Empty && txtPassword.Text != string.Empty)
                {
                    MessageBox.Show("Please Input UserName");
                    return;
                }
                //数据库名称存在，则必须输入用户名和密码
                if (txtDataBaseName.Text != string.Empty)
                {
                    //用户名或者密码为空
                    if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
                    {
                        MessageBox.Show("Please Input UserName or Password");
                        return;
                    }
                }

                //ModifyConn.IsUseDefaultSetting = chkUseDefault.Checked;
                if (ModifyConn.IsUseDefaultSetting)
                {
                    ModifyConn.WtimeoutMs = MongoConnectionConfig.MongoConfig.WtimeoutMs;
                    ModifyConn.WaitQueueSize = MongoConnectionConfig.MongoConfig.WaitQueueSize;
                    ModifyConn.WriteConcern = MongoConnectionConfig.MongoConfig.WriteConcern;
                    ModifyConn.ReadPreference = MongoConnectionConfig.MongoConfig.ReadPreference;
                }
                else
                {
                    //ModifyConn.WtimeoutMs = (double) NumWTimeoutMS.Value;
                    //ModifyConn.WaitQueueSize = (int) NumWaitQueueSize.Value;
                    //ModifyConn.WriteConcern = cmbWriteConcern.Text;
                    //ModifyConn.ReadPreference = cmbReadPreference.Text;
                }

                ModifyConn.SocketTimeoutMs = (double) NumSocketTimeOut.Value;
                ModifyConn.ConnectTimeoutMs = (double) NumConnectTimeOut.Value;
                ModifyConn.Journal = chkJournal.Checked;
                ModifyConn.Fsync = chkFsync.Checked;
                ModifyConn.ReplSetName = txtReplsetName.Text;
                ModifyConn.ReplsetList = new List<string>();
                if (cmbStorageEngine.SelectedIndex == 0)
                {
                    ModifyConn.StorageEngine = EnumMgr.StorageEngineType.MmaPv1;
                }
                else
                {
                    ModifyConn.StorageEngine = EnumMgr.StorageEngineType.WiredTiger;
                }
                foreach (string item in lstHost.Items)
                {
                    ModifyConn.ReplsetList.Add(item);
                }
            }
        }

        /// <summary>
        ///     添加HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            var strHost = string.Empty;
            if (string.IsNullOrEmpty(strHost)) return;
            strHost = txtReplHost.Text;
            if (NumReplPort.Value == 0) return;
            strHost += ":" + NumReplPort.Value;
            lstHost.Items.Add(strHost);
        }

        /// <summary>
        ///     移除HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            lstHost.Items.Remove(lstHost.SelectedItem);
        }
    }
}