using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using System.Windows.Forms;
using System.Threading;

namespace MagicMongoDBTool
{
    public partial class frmConnect : System.Windows.Forms.Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }
        private void frmConnect_Load(object sender, EventArgs e)
        {
            RefreshConnection();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.cmdAddCon.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Add);
                this.cmdDelCon.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Connect_Action_Del);
                this.cmdModifyCon.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Modify);
                this.cmdClose.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Close);
                this.cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                this.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Connect_Title);
            }
        }
        /// <summary>
        /// 刷新连接
        /// </summary>
        private void RefreshConnection()
        {
            lstServerce.Items.Clear();
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.ReplSetName == String.Empty)
                {
                    lstServerce.Items.Add(item.ConnectionName + "@" + (item.Host == String.Empty ? "localhost" : item.Host)
                                                              + (item.Port == 0 ? String.Empty : ":" + item.Port.ToString()));
                }
                else
                {
                    lstServerce.Items.Add(item.ConnectionName);
                }
            }
            lstServerce.Sorted = true;
            SystemManager.ConfigHelperInstance.SaveToConfigFile(ConfigHelper._configFilename);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmAddConnection(), true, true);
            RefreshConnection();
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            List<ConfigHelper.MongoConnectionConfig> connLst = new List<ConfigHelper.MongoConnectionConfig>();
            if (lstServerce.SelectedItems.Count > 0)
            {
                foreach (String item in lstServerce.SelectedItems)
                {
                    connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList[item.Split("@".ToCharArray())[0]]);
                }
                MongoDBHelper.AddServer(connLst);
            }
            this.Close();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelCon_Click(object sender, EventArgs e)
        {
            foreach (String item in lstServerce.SelectedItems)
            {
                String ConnectionName = item;
                if (ConnectionName.Contains("@"))
                {
                    ConnectionName = ConnectionName.Split("@".ToCharArray())[0];
                }
                if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(ConnectionName))
                {
                    SystemManager.ConfigHelperInstance.ConnectionList.Remove(ConnectionName);
                }
            }
            RefreshConnection();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdModifyCon_Click(object sender, EventArgs e)
        {
            if (lstServerce.SelectedItems.Count == 1)
            {
                String ConnectionName = lstServerce.SelectedItem.ToString();
                if (ConnectionName.Contains("@"))
                {
                    ConnectionName = ConnectionName.Split("@".ToCharArray())[0];
                }
                SystemManager.OpenForm(new frmAddConnection(ConnectionName), true, true);
                RefreshConnection();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClosel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Message"></param>
        delegate void WriteInfo(String Info, byte Message);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Info"></param>
        /// <param name="Message"></param>
        private void Write(String Info,byte Message)
        {
            txtInfo.Text += Info + System.Environment.NewLine;
        }
        /// <summary>
        /// Entry Of MongoCola@Browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkWebFormEntry_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            this.Height = 500;
            HTTP.HTTPServer.ServerPath = Application.StartupPath + "\\HTML";
            HTTP.HTTPServer svr = new HTTP.HTTPServer();
            svr.LogInfo += new EventHandler<HTTP.HTTPServer.LogOutEvent>(
                 (x, y) =>
                 {
                     if (txtInfo.InvokeRequired)
                     {
                         WriteInfo t = new WriteInfo(Write);
                         object[] o = new object[2] { y.Info,y.Level };
                         ((Control)this).Invoke(t, o);
                         return;
                     }
                     else
                     {
                         Write(y.Info,y.Level);
                     }
                 });
            Thread q = new Thread(new ThreadStart(svr.Start));
            q.Start();
            System.Diagnostics.Process.Start("http://localhost:13000/");
        }
    }
}
