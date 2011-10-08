using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            DisableAllOpr();
        }
        void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            lstData.Clear();
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
                        MongoDBHelpler.FillDataToListView(SystemManager.SelectObjectTag, lstData);
                        PrePageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
                        NextPageToolStripMenuItem.Enabled =MongoDBHelpler.HasNextPage;
                        statusStripMain.Items[0].Text = "选中数据:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.GridFileSystemTag:
                        //BsonDocument
                        MongoDBHelpler.FillDataToListView(e.Node.Tag.ToString(), lstData);
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "文件系统:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.UserListTag:
                        statusStripMain.Items[0].Text = "用户列表:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.ServiceTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 创建数据库
                        this.CreateMongoDBToolStripMenuItem.Enabled = true;
                        this.ImportDataFromAccessToolStripMenuItem.Enabled = true;
                        break;
                    case MongoDBHelpler.DataBaseTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据库:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据库 创建数据集
                        this.DelMongoDBToolStripMenuItem.Enabled = true;
                        this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                        break;
                    case MongoDBHelpler.CollectionTag:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据集
                        this.DelMongoCollectionToolStripMenuItem.Enabled = true;
                        break;
                    default:
                        SystemManager.SelectObjectTag = "";
                        break;
                }
            }
        }
        private void DisableAllOpr() {
            this.DelMongoDBToolStripMenuItem.Enabled = false;
            this.DelMongoCollectionToolStripMenuItem.Enabled = false;
            this.CreateMongoCollectionToolStripMenuItem.Enabled = false;
            this.CreateMongoDBToolStripMenuItem.Enabled = false;
            this.ImportDataFromAccessToolStripMenuItem.Enabled = false;
        }
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
            MongoDBHelpler.FillMongodbToTreeView(trvsrvlst);
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
            MongoDBHelpler.FillMongodbToTreeView(trvsrvlst);
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
            if (MongoDBHelpler.CollectionOpration(strPath, strCollection, MongoDBHelpler.Oprcode.Drop,trvsrvlst.SelectedNode))
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
            if (strDBName == string.Empty) {
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

        private void PrePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(false,SystemManager.SelectObjectTag, lstData);
            PrePageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
            NextPageToolStripMenuItem.Enabled = MongoDBHelpler.HasNextPage;
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(true, SystemManager.SelectObjectTag, lstData);
            PrePageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
            NextPageToolStripMenuItem.Enabled = MongoDBHelpler.HasNextPage;
        }
    }
}
