using MongoCola.Module;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoUtility.Core;
namespace MongoCola
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
            cmdAddCon.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Add);
            cmdDelCon.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Connect_Action_Del);
            cmdModifyCon.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Modify);
            cmdClose.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
            cmdOK.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_OK);
            Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Connect_Title);
        }

        /// <summary>
        ///     刷新连接
        /// </summary>
        private void RefreshConnection()
        {
            lstConnection.Items.Clear();
            foreach (MongoUtility.Core.MongoConnectionConfig item in SystemManager.config.ConnectionList.Values)
            {
                if (item.ReplSetName == string.Empty)
                {
                    var t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add((item.Host == string.Empty ? "localhost" : item.Host));
                    t.SubItems.Add((item.Port == 0 ? string.Empty : item.Port.ToString()));
                    t.SubItems.Add(item.UserName);
                    lstConnection.Items.Add(t);
                }
                else
                {
                    var t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add((item.Host == string.Empty ? "localhost" : item.Host));
                    t.SubItems.Add((item.Port == 0 ? string.Empty : item.Port.ToString()));
                    t.SubItems.Add(string.Empty);
                    string ReplArray = string.Empty;
                    foreach (var Repl in item.ReplsetList)
                    {
                        ReplArray += Repl + ";";
                    }
                    t.SubItems.Add(ReplArray);
                    lstConnection.Items.Add(t);
                }
                Common.Utility.ListViewColumnResize(lstConnection);
            }
            lstConnection.Sort();
            ConfigHelper.SaveToConfigFile();
        }

        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            Common.Utility.OpenForm(new frmAddConnection(), true, true);
            RefreshConnection();
        }

        /// <summary>
        ///     连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            var connLst = new List<MongoUtility.Core.MongoConnectionConfig>();
            if (lstConnection.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lstConnection.CheckedItems)
                {
                    connLst.Add(SystemManager.config.ConnectionList[item.Text]);
                }
                RuntimeMongoDBContext.AddServer(connLst);
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
            foreach (ListViewItem item in lstConnection.CheckedItems)
            {
                string ConnectionName = item.Text;
                if (SystemManager.config.ConnectionList.ContainsKey(ConnectionName))
                {
                    SystemManager.config.ConnectionList.Remove(ConnectionName);
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
            if (lstConnection.CheckedItems.Count != 1) return;
            string ConnectionName = lstConnection.CheckedItems[0].Text;
            Common.Utility.OpenForm(new frmAddConnection(ConnectionName), true, true);
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