using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            intPort.Value = ConstMgr.MongodDefaultPort;
            foreach (var item in Enum.GetValues(typeof(EnumMgr.StorageEngineType)))
            {
                cmbStorageEngine.Items.Add(item);
                cmbStorageEngine.SelectedIndex = 0;
            }
        }

        /// <summary>
        ///     初始化（修改）
        /// </summary>
        /// <param name="connectionName"></param>
        public FrmConnectionMgr(string connectionName)
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(EnumMgr.StorageEngineType)))
            {
                cmbStorageEngine.Items.Add(item);
                cmbStorageEngine.SelectedIndex = 0;
            }
            OldConnectionName = connectionName;
            //Modify Mode
            ModifyConn = MongoConnectionConfig.MongoConfig.ConnectionList[connectionName];
            UiBinding.TryUpdateForm(ModifyConn, Controls);
            if (ModifyConn.AuthMechanism == ConstMgr.MONGODB_CR) radMONGODB_CR.Checked = true;
            if (ModifyConn.AuthMechanism == ConstMgr.MONGODB_X509) radMONGODB_X509.Checked = true;
            if (ModifyConn.AuthMechanism == ConstMgr.SCRAM_SHA_1) radSCRAM_SHA_1.Checked = true;
            foreach (var item in ModifyConn.ReplsetList)
            {
                lstHost.Items.Add(item);
            }
            cmbStorageEngine.SelectedIndex = ModifyConn.StorageEngine == EnumMgr.StorageEngineType.MmaPv1 ? 0 : 1;
            cmdAdd.Text = GuiConfig.IsUseDefaultLanguage ? "Modify" : GuiConfig.GetText("Common.Modify");
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddConnection_Load(object sender, EventArgs e)
        {
            cmdCancel.Click += (x, y) => Close();
            intPort.GotFocus += (x, y) => intPort.Select(0, 5);
            intReplPort.GotFocus += (x, y) => intReplPort.Select(0, 5);
            dblSocketTimeOut.GotFocus += (x, y) => dblSocketTimeOut.Select(0, 5);
            dblConnectTimeOut.GotFocus += (x, y) => dblConnectTimeOut.Select(0, 5);
            //Color
            cmdTest.BackColor = GuiConfig.ActionColor;
            cmdAdd.BackColor = GuiConfig.SuccessColor;
            cmdCancel.BackColor = GuiConfig.FailColor;
            GuiConfig.Translateform(this);
            //修改模式
            if (!string.IsNullOrEmpty(OldConnectionName))
            {
                cmdAdd.Text = GuiConfig.IsUseDefaultLanguage ? "Modify" : GuiConfig.GetText("Common.Modify");
            }
            //MonoUI兼容性对应
            GuiConfig.MonoCompactControl(Controls);
        }

        /// <summary>
        ///     新建或者修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var newCollectionName = txtConnectionName.Text;
            if (string.IsNullOrEmpty(newCollectionName))
            {
                MyMessageBox.ShowMessage("Connection", "Please Input ConnectionName");
                return;
            }
            if (newCollectionName.Contains(":"))
            {
                MyMessageBox.ShowMessage("Connection", "Please Remove : from ConnectionName");
                return;
            }
            if (!CreateConnection()) return;
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
            if (!CreateConnection()) return;
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
                if (!GuiConfig.IsUseDefaultLanguage && !GuiConfig.IsMono)
                {
                    MyMessageBox.ShowMessage(GuiConfig.GetText("ExceptionAuthenticationException"), GuiConfig.GetText("ExceptionAuthenticationExceptionNote"), ex.ToString(), true);
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
                if (!GuiConfig.IsUseDefaultLanguage && !GuiConfig.IsMono)
                {
                    MyMessageBox.ShowMessage(GuiConfig.GetText("ExceptionNotConnected"), GuiConfig.GetText("ExceptionNotConnectedNote"), ex.ToString(), true);
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
        private bool CreateConnection()
        {
            //更新数据模型
            UiBinding.TryUpdateModel(ModifyConn, Controls);
            if (radMONGODB_CR.Checked) ModifyConn.AuthMechanism = ConstMgr.MONGODB_CR;
            if (radMONGODB_X509.Checked) ModifyConn.AuthMechanism = ConstMgr.MONGODB_X509;
            if (radSCRAM_SHA_1.Checked) ModifyConn.AuthMechanism = ConstMgr.SCRAM_SHA_1;
            //感谢 呆呆 的Bug 报告，不论txtConnectionString.Text是否存在都进行赋值，防止删除字符后，值还是保留的BUG
            ModifyConn.ConnectionString = txtConnectionString.Text;
            if (txtConnectionString.Text != string.Empty)
            {
                var strException = MongoHelper.FillConfigWithConnectionString(ref ModifyConn);
                if (strException != string.Empty)
                {
                    MyMessageBox.ShowMessage("Url Exception", "Url Formation，please check it", strException);
                    return false;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text) && !chkInputPasswordOnConnect.Checked)
                {
                    //仅有用户名，没有密码，也没有设置为连接时输入
                    MessageBox.Show("Please Input Password");
                    return false;
                }
                if (string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
                    //仅有密码
                    MessageBox.Show("Please Input UserName");
                    return false;
                }
                //清空密码，不论是否输入
                if (chkInputPasswordOnConnect.Checked) ModifyConn.Password = string.Empty;
                //数据库名称存在，则必须输入用户名和密码
                if (!string.IsNullOrEmpty(txtDataBaseName.Text))
                {
                    //用户名为空或者（密码为空且不是连接时输入）
                    if (string.IsNullOrEmpty(txtUsername.Text) || (string.IsNullOrEmpty(txtPassword.Text) && !chkInputPasswordOnConnect.Checked))
                    {
                        MessageBox.Show("Please Input UserName or Password");
                        return false;
                    }
                }
                if (ModifyConn.IsUseDefaultSetting)
                {
                    ModifyConn.WtimeoutMs = MongoConnectionConfig.MongoConfig.WtimeoutMs;
                    ModifyConn.WaitQueueSize = MongoConnectionConfig.MongoConfig.WaitQueueSize;
                    ModifyConn.WriteConcern = MongoConnectionConfig.MongoConfig.WriteConcern;
                    ModifyConn.ReadPreference = MongoConnectionConfig.MongoConfig.ReadPreference;
                }
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
            return true;
        }

        /// <summary>
        ///     添加HostList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            var strHost = string.Empty;
            strHost = txtReplHost.Text;
            if (string.IsNullOrEmpty(strHost)) return;
            if (intReplPort.Value == 0) return;
            strHost += ":" + intReplPort.Value;
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