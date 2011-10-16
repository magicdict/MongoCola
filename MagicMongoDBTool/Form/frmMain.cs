using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Collections.Generic;
namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<Control> DataShower = new List<Control>();
        /// <summary>
        /// 数据展示控件
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            DisableAllOpr();
            DataShower.Add(lstData);
            DataShower.Add(trvData);
            DataShower.Add(txtData);
        }
        /// <summary>
        /// 鼠标选中节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lstData.Clear();
            txtData.Text = "";
            trvData.Nodes.Clear();
            if (e.Node.Tag != null)
            {
                //先禁用所有的操作，然后根据选中对象解禁
                DisableAllOpr();
                switch (e.Node.Tag.ToString().Split(":".ToCharArray())[0])
                {
                    case MongoDBHelpler.DocumentTag:
                        //BsonDocument
                        MongoDBHelpler.SkipCnt = 0;
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        MongoDBHelpler.FillDataToControl(SystemManager.SelectObjectTag, DataShower);
                        SetDataNav();
                        statusStripMain.Items[0].Text = "选中数据:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.GridFileSystemTag:
                        //BsonDocument
                        MongoDBHelpler.FillDataToControl(e.Node.Tag.ToString(), DataShower);
                        SetDataNav();
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "文件系统:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.UserListTag:
                        //BsonDocument
                        MongoDBHelpler.FillDataToControl(e.Node.Tag.ToString(), DataShower);
                        SetDataNav();
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "用户列表:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.ServiceTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 创建数据库,关闭服务器
                        this.CreateMongoDBToolStripMenuItem.Enabled = true;
                        this.ImportDataFromAccessToolStripMenuItem.Enabled = true;
                        this.ShutDownToolStripMenuItem.Enabled = true;
                        if (SystemManager.getSelectedSrvProByName().ServerType == ConfigHelper.SrvType.DataSrv)
                        {
                            //Route,Config服务器不能进行这样的操作！
                            this.ReplicaSetToolStripMenuItem.Enabled = true;
                        }
                        if (SystemManager.getSelectedSrvProByName().ServerType == ConfigHelper.SrvType.RouteSrv)
                        {
                            //Route用
                            this.AddShardingToolStripMenuItem.Enabled = true;
                            this.ShardConfigToolStripMenuItem.Enabled = true;
                        }

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Items.Add(this.CreateMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportDataFromAccessToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ReplicaSetToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddShardingToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShardConfigToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShutDownToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelpler.DataBaseTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据库:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据库 创建数据集
                        //TODO:Slave和候补服务器不能进行这样的操作
                        this.DelMongoDBToolStripMenuItem.Enabled = true;
                        this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                        this.AddUserToolStripMenuItem.Enabled = true;
                        this.RemoveUserToolStripMenuItem.Enabled = true;
                        this.DataCollectionOprToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Items.Add(this.DelMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.CreateMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelpler.CollectionTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据集
                        this.DelMongoCollectionToolStripMenuItem.Enabled = true;
                        this.IndexManageToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Items.Add(this.DelMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.IndexManageToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    default:
                        SystemManager.SelectObjectTag = "";
                        break;
                }
            }
        }
        /// <summary>
        /// 禁止所有操作
        /// </summary>
        private void DisableAllOpr()
        {
            this.DelMongoDBToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.CreateMongoCollectionToolStripMenuItem.Enabled = false;
            this.CreateMongoDBToolStripMenuItem.Enabled = false;
            this.AddUserToolStripMenuItem.Enabled = false;
            this.RemoveUserToolStripMenuItem.Enabled = false;
            this.IndexManageToolStripMenuItem.Enabled = false;

            this.ImportDataFromAccessToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripMenuItem.Enabled = false;

            this.FirstPageToolStripMenuItem.Enabled = false;
            this.LastPageToolStripMenuItem.Enabled = false;
            this.NextPageToolStripMenuItem.Enabled = false;
            this.PrePageToolStripMenuItem.Enabled = false;
            this.QueryDataToolStripMenuItem.Enabled = false;

            this.ReplicaSetToolStripMenuItem.Enabled = false;
            this.AddShardingToolStripMenuItem.Enabled = false;
            this.ShardConfigToolStripMenuItem.Enabled = false;
        }

        #region"Connection"
        /// <summary>
        /// 添加数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnect mfrm = new frmConnect();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
            MongoDBHelpler.FillMongoServiceToTreeView(trvsrvlst);
            lstData.Clear();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAllOpr();
            MongoDBHelpler.FillMongoServiceToTreeView(trvsrvlst);
            lstData.Clear();
        }
        private void DataBaseStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataBaseStatus mfrm = new frmDataBaseStatus();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        private void SrvStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiceStatus mfrm = new frmServiceStatus();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region"Tool"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption mfrm = new frmOption();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        /// <summary>
        /// DOS控制台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DosCommandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDosCommand mfrm = new frmDosCommand();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        #endregion

        #region"管理"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strDBName = strPath.Split("/".ToCharArray())[1];
            if (MongoDBHelpler.DataBaseOpration(strPath, strDBName, MongoDBHelpler.Oprcode.Drop, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strCollection = strPath.Split("/".ToCharArray())[2];
            if (MongoDBHelpler.CollectionOpration(strPath, strCollection, MongoDBHelpler.Oprcode.Drop, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strCollection = Microsoft.VisualBasic.Interaction.InputBox("请输入数据集名称：", "创建数据集");
            if (strCollection == string.Empty)
            {
                return;
            }
            if (MongoDBHelpler.CollectionOpration(strPath, strCollection, MongoDBHelpler.Oprcode.Create, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }

        private void CreateMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strDBName = Microsoft.VisualBasic.Interaction.InputBox("请输入数据库名称：", "创建数据库");
            if (strDBName == string.Empty)
            {
                return;
            }
            if (MongoDBHelpler.DataBaseOpration(strPath, strDBName, MongoDBHelpler.Oprcode.Create, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }

        private void ImportDataFromAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            frmImportOleDB mfrm = new frmImportOleDB();
            mfrm.ShowDialog();
            String DBFilename = mfrm.DataBaseFileName;
            if (DBFilename != string.Empty)
            {
                MongoDBHelpler.ImportAccessDataBase(DBFilename, strPath, trvsrvlst.SelectedNode);
            }
            mfrm.Close();
            mfrm.Dispose();
        }
        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "创建用户");
            String strPassword = Microsoft.VisualBasic.Interaction.InputBox("请输入密码：", "创建用户");
            MongoDBHelpler.AddUserForDB(SystemManager.SelectObjectTag, strUserName, strPassword, false);
        }

        private void RemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "移除用户");
            MongoDBHelpler.RemoveUserForDB(SystemManager.SelectObjectTag, strUserName);
        }
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCollectionIndex mfrm = new frmCollectionIndex();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:
            MongoDBHelpler.Shutdown();
            trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
        }
        #endregion

        #region"分布式"
        private void ReplicaSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplset mfrm = new frmReplset();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }

        private void AddShardingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddSharding mfrm = new frmAddSharding();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        private void ShardConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShardingConfig mfrm = new frmShardingConfig();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }

        #endregion

        #region"数据导航"
        private void PrePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.PrePage, SystemManager.SelectObjectTag, DataShower);
            SetDataNav();
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.NextPage, SystemManager.SelectObjectTag, DataShower);
            SetDataNav();
        }

        private void FirstPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.FirstPage, SystemManager.SelectObjectTag, DataShower);
            SetDataNav();
        }

        private void LastPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.LastPage, SystemManager.SelectObjectTag, DataShower);
            SetDataNav();
        }
        private void SetDataNav()
        {
            PrePageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
            NextPageToolStripMenuItem.Enabled = MongoDBHelpler.HasNextPage;
            FirstPageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
            LastPageToolStripMenuItem.Enabled = MongoDBHelpler.HasNextPage;
            this.QueryDataToolStripMenuItem.Enabled = true;
        }
        #endregion

        private void QueryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuery mfrm = new frmQuery();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
            //重新展示数据
            MongoDBHelpler.FillDataToControl(SystemManager.SelectObjectTag, DataShower);
            SetDataNav();
        }


    }
}
