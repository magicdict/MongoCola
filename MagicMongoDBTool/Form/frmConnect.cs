using MagicMongoDBTool.Module;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace MagicMongoDBTool
{
    public partial class frmConnect : Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConnect_Load(object sender, EventArgs e)
        {
            RefreshConnection();
            if (SystemManager.IsUseDefaultLanguage) return;
            cmdAddCon.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Add);
            cmdDelCon.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Connect_Action_Del);
            cmdModifyCon.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Modify);
            cmdClose.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Close);
            cmdOK.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_OK);
            Text = SystemManager.MStringResource.GetText(StringResource.TextType.Connect_Title);
        }

        /// <summary>
        ///     刷新连接
        /// </summary>
        private void RefreshConnection()
        {
            lstServerce.Items.Clear();
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values
                )
            {
                if (item.ReplSetName == String.Empty)
                {
                    lstServerce.Items.Add(item.ConnectionName + "@" +
                                          (item.Host == String.Empty ? "localhost" : item.Host)
                                          + (item.Port == 0 ? String.Empty : ":" + item.Port));
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
        ///     添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmAddConnection(), true, true);
            RefreshConnection();
        }

        /// <summary>
        ///     连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            var connLst = new List<ConfigHelper.MongoConnectionConfig>();
            if (lstServerce.SelectedItems.Count > 0)
            {
                foreach (String item in lstServerce.SelectedItems)
                {
                    connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList[item.Split("@".ToCharArray())[0]]);
                }
                MongoDbHelper.AddServer(connLst);
            }
            Close();
        }

        /// <summary>
        ///     删除
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
        ///     修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdModifyCon_Click(object sender, EventArgs e)
        {
            if (lstServerce.SelectedItems.Count != 1) return;
            String ConnectionName = lstServerce.SelectedItem.ToString();
            if (ConnectionName.Contains("@"))
            {
                ConnectionName = ConnectionName.Split("@".ToCharArray())[0];
            }
            SystemManager.OpenForm(new frmAddConnection(ConnectionName), true, true);
            RefreshConnection();
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}