using System;
using System.Collections.Generic;
using GUIResource;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmConnect : QLFUI.QLFForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }
        private void frmConnect_Load(object sender, EventArgs e)
        {
            RefreshConnection();
            if (SystemManager.ConfigHelperInstance.currentLanguage != StringResource.Language.Default)
            {
                this.cmdAddCon.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Connect_Action_Add);
                this.cmdDelCon.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Connect_Action_Del);
                this.cmdModifyCon.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Connect_Action_Modify);
                this.cmdCancel.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Connect_Action_Cancel);
                this.cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Connect_Action_OK);
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
                lstServerce.Items.Add(item.ConnectionName);
            }
            SystemManager.ConfigHelperInstance.SaveToConfigFile("config.xml");
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
                foreach (string item in lstServerce.SelectedItems)
                {
                    connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList[item]);
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
            foreach (string item in lstServerce.SelectedItems)
            {
                if (SystemManager.ConfigHelperInstance.ConnectionList.ContainsKey(item))
                {
                    SystemManager.ConfigHelperInstance.ConnectionList.Remove(item);
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
                SystemManager.OpenForm(new frmAddConnection(lstServerce.SelectedItem.ToString()));
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
