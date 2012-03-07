using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;

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
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.cmdAddCon.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Add);
                this.cmdDelCon.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Connect_Action_Del);
                this.cmdModifyCon.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Modify);
                this.cmdCancel.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Cancel);
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
                lstServerce.Items.Add(item.ConnectionName + "@" + 
                    (item.Host==null?"localhost":item.Host) + (item.Port==0?String.Empty:":" + item.Port.ToString()));
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
            SystemManager.OpenForm(new frmAddConnection());
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
                this.Close();
            }
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
                    SystemManager.OpenForm(new frmAddConnection(ConnectionName));
                }
                RefreshConnection();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
