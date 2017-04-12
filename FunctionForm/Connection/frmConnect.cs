using Common;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.Connection
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
            GuiConfig.Translateform(this);
            RefreshConnection();
        }

        /// <summary>
        ///     刷新连接
        /// </summary>
        private void RefreshConnection()
        {
            lstConnection.Items.Clear();
            foreach (var item in MongoConnectionConfig.MongoConfig.ConnectionList.Values)
            {
                if (string.IsNullOrEmpty(item.ReplSetName))
                {
                    var t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add(item.Host == string.Empty ? "localhost" : item.Host);
                    t.SubItems.Add(item.Port == 0 ? string.Empty : item.Port.ToString());
                    t.SubItems.Add(string.Empty);
                    t.SubItems.Add((string.IsNullOrEmpty(item.UserName)) ? string.Empty : (item.UserName + "@" + item.DataBaseName));
                    lstConnection.Items.Add(t);
                }
                else
                {
                    var t = new ListViewItem(item.ConnectionName);
                    t.SubItems.Add(item.Host == string.Empty ? "localhost" : item.Host);
                    t.SubItems.Add(item.Port == 0 ? string.Empty : item.Port.ToString());
                    var replArray = string.Empty;
                    foreach (var repl in item.ReplsetList)
                    {
                        replArray += repl + ";";
                    }
                    t.SubItems.Add(replArray);
                    t.SubItems.Add((string.IsNullOrEmpty(item.UserName)) ? string.Empty : (item.UserName + "@" + item.DataBaseName));
                    lstConnection.Items.Add(t);
                }
            }
            lstConnection.Sort();
            UIAssistant.ListViewColumnResize(lstConnection);
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
        }

        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCon_Click(object sender, EventArgs e)
        {
            UIAssistant.OpenModalForm(new FrmConnectionMgr(), true, true);
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
            UIAssistant.OpenModalForm(new FrmConnectionMgr(connectionName), true, true);
            RefreshConnection();
        }

        /// <summary>
        ///     选中的连接转为URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdToUrlString_Click(object sender, EventArgs e)
        {
            if (lstConnection.CheckedItems.Count == 0) return;
            var uri = string.Empty;
            foreach (ListViewItem item in lstConnection.CheckedItems)
            {
                var config = MongoConnectionConfig.MongoConfig.ConnectionList[item.Text];
                uri += config.ToUri() + System.Environment.NewLine;
            }
            MyMessageBox.ShowMessage("URI", "Uri Connectiong String:", uri);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdFromUriString_Click(object sender, EventArgs e)
        {
            var uri = MyMessageBox.ShowInput("MongoConnectionUri", "Uri");
            MongoConnectionConfig ModifyConn = new MongoConnectionConfig()
            {
                ConnectionString = uri
            };
            var strException = MongoHelper.FillConfigWithConnectionString(ref ModifyConn);
            if (strException != string.Empty)
            {
                MyMessageBox.ShowMessage("Url Exception", "Url Formation，please check it", strException);
                return;
            }
            //这里不能使用 ：，会出现问题
            var ConnectionName = ModifyConn.Host + "_" + ModifyConn.Port;
            ModifyConn.ConnectionName = ConnectionName;
            MongoConnectionConfig.MongoConfig.ConnectionList.Add(ConnectionName, ModifyConn);
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