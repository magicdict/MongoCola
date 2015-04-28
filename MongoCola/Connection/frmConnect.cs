using Common.Logic;
using MongoUtility.Core;
using ResourceLib.Utility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SystemUtility;
using SystemUtility.Config;

namespace MongoCola.Connection
{
    public partial class frmConnect : Form
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConnect_Load(object sender, EventArgs e)
        {
            RefreshConnection();
            GUIConfig.Translateform(this);
        }

        /// <summary>
        ///     刷新连接
        /// </summary>
        private void RefreshConnection()
        {
            lstConnection.Items.Clear();
            foreach (var item in SystemConfig.config.ConnectionList.Values)
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
                    var ReplArray = string.Empty;
                    foreach (var Repl in item.ReplsetList)
                    {
                        ReplArray += Repl + ";";
                    }
                    t.SubItems.Add(ReplArray);
                    lstConnection.Items.Add(t);
                }
                Utility.ListViewColumnResize(lstConnection);
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
            Utility.OpenForm(new frmAddConnection(), true, true);
            RefreshConnection();
        }

        /// <summary>
        ///     连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            var connLst = new List<MongoConnectionConfig>();
            if (lstConnection.CheckedItems.Count > 0)
            {
                foreach (ListViewItem item in lstConnection.CheckedItems)
                {
                    var config = SystemConfig.config.ConnectionList[item.Text];
                    connLst.Add(config);
                }
                RuntimeMongoDBContext.ResetConnectionList(connLst);
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
                var ConnectionName = item.Text;
                if (SystemConfig.config.ConnectionList.ContainsKey(ConnectionName))
                {
                    SystemConfig.config.ConnectionList.Remove(ConnectionName);
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
            var ConnectionName = lstConnection.CheckedItems[0].Text;
            Utility.OpenForm(new frmAddConnection(ConnectionName), true, true);
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