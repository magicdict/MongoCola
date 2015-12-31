using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoUtility.Core;
using ResourceLib.Method;

namespace FunctionForm.Connection
{
    public partial class FrmConnect : Form
    {
        public FrmConnect()
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
            GuiConfig.Translateform(this);
        }

        /// <summary>
        ///     刷新连接
        /// </summary>
        private void RefreshConnection()
        {
            lstConnection.Items.Clear();
            foreach (var item in MongoConnectionConfig.MongoConfig.ConnectionList.Values)
            {
                if (item.ReplSetName == string.Empty)
                {
                    var t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add(item.Host == string.Empty ? "localhost" : item.Host);
                    t.SubItems.Add(item.Port == 0 ? string.Empty : item.Port.ToString());
                    t.SubItems.Add(item.UserName);
                    lstConnection.Items.Add(t);
                }
                else
                {
                    var t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add(item.Host == string.Empty ? "localhost" : item.Host);
                    t.SubItems.Add(item.Port == 0 ? string.Empty : item.Port.ToString());
                    t.SubItems.Add(string.Empty);
                    var replArray = string.Empty;
                    foreach (var repl in item.ReplsetList)
                    {
                        replArray += repl + ";";
                    }
                    t.SubItems.Add(replArray);
                    lstConnection.Items.Add(t);
                }
                Utility.ListViewColumnResize(lstConnection);
            }
            lstConnection.Sort();
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
        }

        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            Utility.OpenForm(new FrmConnectionMgr(), true, true);
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
                    var config = MongoConnectionConfig.MongoConfig.ConnectionList[item.Text];
                    connLst.Add(config);
                }
                RuntimeMongoDbContext.ResetConnectionList(connLst);
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
                var connectionName = item.Text;
                if (MongoConnectionConfig.MongoConfig.ConnectionList.ContainsKey(connectionName))
                {
                    MongoConnectionConfig.MongoConfig.ConnectionList.Remove(connectionName);
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
            var connectionName = lstConnection.CheckedItems[0].Text;
            Utility.OpenForm(new FrmConnectionMgr(connectionName), true, true);
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