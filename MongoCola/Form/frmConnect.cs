using MongoCola.Module;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            lstConnection.Items.Clear();
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values
                )
            {
                if (item.ReplSetName == String.Empty)
                {
                    ListViewItem t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add((item.Host == String.Empty ? "localhost" : item.Host));
                    t.SubItems.Add((item.Port == 0 ? String.Empty : item.Port.ToString()));
                    t.SubItems.Add(item.UserName);
                    lstConnection.Items.Add(t);
                }
                else
                {
                    ListViewItem t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add((item.Host == String.Empty ? "localhost" : item.Host));
                    t.SubItems.Add((item.Port == 0 ? String.Empty : item.Port.ToString()));
                    String ReplArray = String.Empty;
                    foreach (var Repl in item.ReplsetList)
                    {
                        ReplArray += Repl + ";";
                    }
                    t.SubItems.Add(ReplArray);
                    lstConnection.Items.Add(t);
                }
                Common.Present.Utility.ListViewColumnResize(lstConnection);
                //lstConnection.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            lstConnection.Sort();
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
            if (lstConnection.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lstConnection.CheckedItems)
                {
                    connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList[item.Text]);
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
            foreach (ListViewItem item in lstConnection.CheckedItems)
            {
                String ConnectionName = item.Text;
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
            if (lstConnection.CheckedItems.Count != 1) return;
            String ConnectionName = lstConnection.CheckedItems[0].Text;
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