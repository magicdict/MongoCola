using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;

namespace FunctionForm.Operation
{
    public partial class frmCopyDataBase : Form
    {
        #region 变量

        /// <summary>
        ///     选中的表名
        /// </summary>
        private readonly List<string> _selectCollection = new List<string>();

        #endregion

        public frmCopyDataBase()
        {
            InitializeComponent();
        }

        #region 委托操作

        private delegate void EventsHandlerEnable(bool isEnable);

        /// <summary>
        ///     按钮限制
        /// </summary>
        /// <param name="isEnable"></param>
        private void ChangeEnable(bool isEnable)
        {
            if (InvokeRequired)
                Invoke(new EventsHandlerEnable(ChangeEnable), isEnable);
            else
            {
                cmdCancel.Enabled = isEnable;
                cmdOK.Enabled = isEnable;
                gbSelectCollections.Enabled = isEnable;
                gbSelectDestination.Enabled = isEnable;
            }
        }

        private delegate void EventsHandlerTreeNodeBind(TreeNode treeNode);

        /// <summary>
        ///     来源表数据绑定
        /// </summary>
        /// <param name="treeNode"></param>
        private void TreeNodeBind(TreeNode treeNode)
        {
            if (treeViewCollection.InvokeRequired)
                treeViewCollection.Invoke(new EventsHandlerTreeNodeBind(TreeNodeBind), treeNode);
            else
            {
                treeViewCollection.Nodes.Clear();
                treeViewCollection.Nodes.Add(treeNode);
                treeViewCollection.ExpandAll();
            }
        }

        private delegate void EventsHandlerComboxBind(ComboBox comboBox, object data);

        /// <summary>
        ///     combox数据绑定
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="data"></param>
        private void ComboxBind(ComboBox comboBox, object data)
        {
            if (comboBox.InvokeRequired)
                comboBox.Invoke(new EventsHandlerComboxBind(ComboxBind), comboBox, data);
            else
            {
                var bs = new BindingSource { DataSource = data };
                comboBox.DataSource = bs;
                comboBox.DisplayMember = "Key";
                comboBox.ValueMember = "Value";
                comboBox.SelectedIndex = -1;
            }
        }

        private delegate void EventsHandlerChangeProgress(int value);

        /// <summary>
        ///     进度条显示
        /// </summary>
        /// <param name="value"></param>
        private void ChangeProgress(int value)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(new EventsHandlerChangeProgress(ChangeProgress), value);
            else
                progressBar1.Value = value;
        }

        #endregion

        #region 线程

        /// <summary>
        ///     数据绑定
        /// </summary>
        private void DataBind()
        {
            ChangeEnable(false);

            try
            {
                //数据来源绑定
                var db = RuntimeMongoDbContext.GetCurrentDataBase();
                var treeNode = new TreeNode(db.Name);
                foreach (var name in db.GetCollectionNames())
                {
                    treeNode.Nodes.Add(name);
                }
                TreeNodeBind(treeNode);

                ComboxBind(comboBoxServer, RuntimeMongoDbContext.MongoConnSvrLst);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            ChangeEnable(true);
        }

        /// <summary>
        ///     复制
        /// </summary>
        private void Copy(MongoDatabase toDb)
        {
            ChangeEnable(false);
            try
            {
                //获取选中的表
                for (var index = 0; index < _selectCollection.Count; index++)
                {
                    var name = _selectCollection[index];
                    Operater.CopyCollection(RuntimeMongoDbContext.GetCurrentDataBase(), toDb, name, false);
                    ChangeProgress(index);
                }
                MessageBox.Show(@"OK");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            ChangeEnable(true);
        }

        #endregion

        #region 控件

        private void FrmCopyDataBase_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                lblSelectServer.Text =
                    GuiConfig.GetText("SelectedServer");
                lblSelectDataBase.Text =
                    GuiConfig.GetText("SelectedDataBase");
                gbSelectCollections.Text = GuiConfig.GetText("SelectedCollection");
                gbSelectDestination.Text = GuiConfig.GetText("SelectedData");
                chkCopyIndexes.Text = GuiConfig.GetText("CopyIndex");
                cmdOK.Text = GuiConfig.GetText("Common.Ok");
                cmdCancel.Text = GuiConfig.GetText("Common.Cancel");
            }
            new Thread(DataBind) { IsBackground = true }.Start();
        }

        /// <summary>
        ///     Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewCollection_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
            }
        }

        /// <summary>
        ///     选中子节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="nodeChecked"></param>
        public void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            if (nodeChecked && !_selectCollection.Contains(treeNode.Text) && treeNode.Parent != null)
                _selectCollection.Add(treeNode.Text);
            else if (!nodeChecked)
                _selectCollection.Remove(treeNode.Text);
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (nodeChecked && !_selectCollection.Contains(node.Text))
                    _selectCollection.Add(node.Text);
                else if (!nodeChecked)
                    _selectCollection.Remove(node.Text);
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        /// <summary>
        ///     服务器选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServer.SelectedValue != null)
            {
                var server = comboBoxServer.SelectedValue as MongoServer;
                if (server == null) return;
                var dic = server.GetDatabaseNames().ToDictionary(name => name);
                ComboxBind(comboBoxDataBase, dic);
            }
        }

        /// <summary>
        ///     复制数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            //var server = comboBoxServer.SelectedValue as MongoServer;
            //if (server == null) return;
            //var db = server.GetDatabase(comboBoxDataBase.Text);
            //if(db == null)return;
            //var from = RuntimeMongoDbContext.GetCurrentServer().Instance.GetIPEndPoint().ToString();
            ////获取选中的表
            //foreach (var name in _selectCollection)
            //{
            //    Operater.CopyCollection(db, from, RuntimeMongoDbContext.GetCurrentDataBaseName(), name, chkCopyIndexes.Checked);
            //}
            progressBar1.Maximum = _selectCollection.Count - 1;
            progressBar1.Minimum = 0;
            var server = comboBoxServer.SelectedValue as MongoServer;
            if (server == null) return;
            var db = server.GetDatabase(comboBoxDataBase.Text);
            if (db == null) return;
            ThreadStart ts = () => Copy(db);
            new Thread(ts) { IsBackground = true }.Start();
        }

        #endregion
    }
}