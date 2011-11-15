using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.Text;

namespace MagicMongoDBTool
{
    public partial class frmMain : QLFUI.QLFForm
    {
        public frmMain()
        {
            InitializeComponent();
            GetSystemIcon.InitMainTreeImage();
            trvsrvlst.ImageList = GetSystemIcon.MainTreeImage;
            SetMenuImage();
            SetMenuText();
            SetToolBar();
        }
        /// <summary>
        /// 数据展示
        /// </summary>
        private List<Control> _dataShower = new List<Control>();
        /// <summary>
        /// 数据展示控件
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.menuStripMain.Renderer = new CRD.WinUI.Misc.ToolStripRenderer(new ProfessionalColorTable());

            this.trvsrvlst.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvsrvlst_NodeMouseClick);
            this.lstData.MouseClick += new MouseEventHandler(lstData_MouseClick);
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new EventHandler(lstData_SelectedIndexChanged);
            this.trvData.MouseClick += new MouseEventHandler(trvData_MouseClick);
            this.trvData.AfterSelect += new TreeViewEventHandler(trvData_AfterSelect);
            this.tabDataShower.SelectedIndexChanged += new EventHandler(
                //变换TAB时候，选中项目自动消失，所以删除数据也消失
                    (x, y) =>
                    {
                        this.DelRecordToolStripMenuItem.Enabled = false;
                    }
                );
            DisableAllOpr();
            _dataShower.Add(lstData);
            _dataShower.Add(trvData);
            _dataShower.Add(txtData);
            statusStripMain.Items[1].Text = string.Empty;
        }
        /// <summary>
        /// 清除数据显示区
        /// </summary>
        private void clearDataShower()
        {
            lstData.Clear();
            txtData.Text = "";
            trvData.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.ContextMenuStrip = null;
            this.contextMenuStripMain = null;
            statusStripMain.Items[0].Text = string.Empty;
            statusStripMain.Items[1].Text = string.Empty;
        }
        /// <summary>
        /// 鼠标选中节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvsrvlst_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            clearDataShower();
            if (this.trvData.SelectedNode != null)
            {
                this.trvData.SelectedNode.ContextMenuStrip = null;
            }
            if (e.Node.Tag != null)
            {
                //选中节点的设置
                this.trvsrvlst.SelectedNode = e.Node;
                //先禁用所有的操作，然后根据选中对象解禁
                DisableAllOpr();
                //恢复数据：这个操作可以针对服务器，数据库，数据集，所以可以放在共通
                this.RestoreMongoToolStripMenuItem.Enabled = true;
                string strNodeType = e.Node.Tag.ToString().Split(":".ToCharArray())[0];
                switch (strNodeType)
                {
                    case MongoDBHelpler.DOCUMENT_TAG:
                        //BsonDocument
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        RefreshData();
                        break;
                    case MongoDBHelpler.GRID_FILE_SYSTEM_TAG:
                        //GridFileSystem
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "文件系统:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        RefreshData();
                        UploadFileToolStripMenuItem.Enabled = true;
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.UploadFileToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelpler.USER_LIST_TAG:
                        //BsonDocument
                        MongoDBHelpler.FillDataToControl(e.Node.Tag.ToString(), _dataShower);
                        SetDataNav();
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "用户列表:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.SINGLE_DB_SERVICE_TAG:
                        //单数据库模式,禁止所有服务器操作
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器[单数据库]:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        break;
                    case MongoDBHelpler.SERVICE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中服务器:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 创建数据库,关闭服务器
                        this.CreateMongoDBToolStripMenuItem.Enabled = true;
                        this.ImportDataFromAccessToolStripMenuItem.Enabled = true;
                        this.ShutDownToolStripMenuItem.Enabled = true;
                        this.AddUserToAdminToolStripMenuItem.Enabled = true;
                        this.RemoveUserFromAdminToolStripMenuItem.Enabled = true;
                        this.SvrPropertyToolStripMenuItem.Enabled = true;

                        if (SystemManager.GetSelectedSvrProByName().ServerType == ConfigHelper.SvrType.ReplsetSvr)
                        {
                            //副本服务器专用。
                            //副本初始化的操作 改在连接设置里面完成
                            this.ReplicaSetToolStripMenuItem.Enabled = true;
                        }
                        if (SystemManager.GetSelectedSvrProByName().ServerType == ConfigHelper.SvrType.RouteSvr)
                        {
                            //Route用
                            this.ShardConfigToolStripMenuItem.Enabled = true;
                        }
                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.CreateMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToAdminToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RemoveUserFromAdminToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportDataFromAccessToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ReplicaSetToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShardConfigToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ShutDownToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.SvrPropertyToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelpler.DATABASE_TAG:
                    case MongoDBHelpler.SINGLE_DATABASE_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据库:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据库 创建数据集
                        if (!MongoDBHelpler.IsSystemDataBase(SystemManager.GetCurrentDataBase()))
                        {
                            //系统库不允许修改
                            this.DelMongoDBToolStripMenuItem.Enabled = true;
                            this.CreateMongoCollectionToolStripMenuItem.Enabled = true;
                            this.AddUserToolStripMenuItem.Enabled = true;
                            this.RemoveUserToolStripMenuItem.Enabled = true;
                            this.InitGFSToolStripMenuItem.Enabled = true;
                        }
                        //备份数据库
                        this.DumpDatabaseToolStripMenuItem.Enabled = true;

                        if (strNodeType == MongoDBHelpler.SINGLE_DATABASE_TAG)
                        {
                            //单一数据库模式
                            this.DelMongoDBToolStripMenuItem.Enabled = false;
                        }

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.DelMongoDBToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.CreateMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.AddUserToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.InitGFSToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpDatabaseToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    case MongoDBHelpler.COLLECTION_TAG:
                        SystemManager.SelectObjectTag = e.Node.Tag.ToString();
                        statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
                        //解禁 删除数据集
                        if (!MongoDBHelpler.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            //系统数据库无法删除！！
                            this.DelMongoCollectionToolStripMenuItem.Enabled = true;
                            this.RenameCollectionToolStripMenuItem.Enabled = true;
                            this.IndexManageToolStripMenuItem.Enabled = true;
                            this.mapReduceToolStripMenuItem.Enabled = true;
                        }
                        this.DumpCollectionToolStripMenuItem.Enabled = true;
                        this.ImportCollectionToolStripMenuItem.Enabled = true;
                        this.ExportCollectionToolStripMenuItem.Enabled = true;

                        if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            this.contextMenuStripMain = new ContextMenuStrip();
                            this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                            this.contextMenuStripMain.Items.Add(this.DelMongoCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.RenameCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.IndexManageToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.mapReduceToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DumpCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ImportCollectionToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.ExportCollectionToolStripMenuItem.Clone());
                            e.Node.ContextMenuStrip = this.contextMenuStripMain;
                            contextMenuStripMain.Show();
                        }
                        break;
                    default:
                        SystemManager.SelectObjectTag = "";
                        break;
                }
            }
            //重新Reset工具栏
            SetToolBar();
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
            this.SvrPropertyToolStripMenuItem.Enabled = false;
            this.ShutDownToolStripMenuItem.Enabled = false;

            this.AddUserToolStripMenuItem.Enabled = false;
            this.RemoveUserToolStripMenuItem.Enabled = false;
            this.AddUserToAdminToolStripMenuItem.Enabled = false;
            this.RemoveUserFromAdminToolStripMenuItem.Enabled = false;
            this.DumpDatabaseToolStripMenuItem.Enabled = false;
            this.RestoreMongoToolStripMenuItem.Enabled = false;

            this.IndexManageToolStripMenuItem.Enabled = false;
            this.DelRecordToolStripMenuItem.Enabled = false;
            this.RenameCollectionToolStripMenuItem.Enabled = false;
            this.DumpCollectionToolStripMenuItem.Enabled = false;
            this.ImportCollectionToolStripMenuItem.Enabled = false;
            this.ExportCollectionToolStripMenuItem.Enabled = false;

            this.UploadFileToolStripMenuItem.Enabled = false;
            this.DownloadFileToolStripMenuItem.Enabled = false;
            this.OpenFileToolStripMenuItem.Enabled = false;
            this.DelFileToolStripMenuItem.Enabled = false;
            this.InitGFSToolStripMenuItem.Enabled = false;

            this.ImportDataFromAccessToolStripMenuItem.Enabled = false;
            this.ImportDataFromAccessToolStripButton.Enabled = false;


            this.FirstPageToolStripMenuItem.Enabled = false;
            this.FirstPageToolStripButton.Enabled = false;
            this.LastPageToolStripMenuItem.Enabled = false;
            this.LastPageToolStripButton.Enabled = false;
            this.NextPageToolStripMenuItem.Enabled = false;
            this.NextPageToolStripButton.Enabled = false;
            this.PrePageToolStripMenuItem.Enabled = false;
            this.PrePageToolStripButton.Enabled = false;
            this.QueryDataToolStripMenuItem.Enabled = false;
            this.QueryDataToolStripButton.Enabled = false;
            this.ExpandAllDataToolStripMenuItem.Enabled = false;
            this.CollapseAllDataToolStripMenuItem.Enabled = false;

            this.ReplicaSetToolStripMenuItem.Enabled = false;
            this.ShardConfigToolStripMenuItem.Enabled = false;
            this.mapReduceToolStripMenuItem.Enabled = false;
        }

        #region"数据展示区操作"
        /// <summary>
        /// 数据列表选中索引变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SystemManager.GetCurrentCollection().Name == MongoDBHelpler.COLLECTION_NAME_GFS_FILES)
            {
                //文件系统
                UploadFileToolStripMenuItem.Enabled = true;
                switch (lstData.SelectedItems.Count)
                {
                    case 0:
                        //禁止所有操作
                        DownloadFileToolStripMenuItem.Enabled = false;
                        OpenFileToolStripMenuItem.Enabled = false;
                        DelFileToolStripMenuItem.Enabled = false;
                        lstData.ContextMenuStrip = null;
                        break;
                    case 1:
                        //可以进行所有操作
                        DownloadFileToolStripMenuItem.Enabled = true;
                        OpenFileToolStripMenuItem.Enabled = true;
                        DelFileToolStripMenuItem.Enabled = true;
                        break;
                    default:
                        //可以删除多个文件
                        DownloadFileToolStripMenuItem.Enabled = false;
                        OpenFileToolStripMenuItem.Enabled = false;
                        DelFileToolStripMenuItem.Enabled = true;
                        break;
                }
            }
            else
            {
                //数据系统
                if (lstData.SelectedItems.Count > 0)
                {
                    if (!MongoDBHelpler.IsSystemCollection(SystemManager.GetCurrentCollection()))
                    {
                        //系统数据禁止删除
                        DelRecordToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        DelRecordToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    DelRecordToolStripMenuItem.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SystemManager.GetCurrentCollection().Name == MongoDBHelpler.COLLECTION_NAME_GFS_FILES)
            {
                String strFileName = lstData.SelectedItems[0].Text;
                MongoDBHelpler.OpenFile(strFileName);
            }
        }
        /// <summary>
        /// 数据列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                    if (SystemManager.GetCurrentCollection().Name == MongoDBHelpler.COLLECTION_NAME_GFS_FILES)
                    {
                        //文件系统
                        this.contextMenuStripMain.Items.Add(this.DownloadFileToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.OpenFileToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.DelFileToolStripMenuItem.Clone());
                    }
                    else
                    {
                        this.contextMenuStripMain.Items.Add(this.DelRecordToolStripMenuItem.Clone());
                    }
                    lstData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvData.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                DelRecordToolStripMenuItem.Enabled = true;
            }
            else
            {
                DelRecordToolStripMenuItem.Enabled = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode node = this.trvData.GetNodeAt(e.Location);
            trvData.SelectedNode = node;
            if (trvData.SelectedNode != null && trvData.SelectedNode.Level == 0)
            {
                DelRecordToolStripMenuItem.Enabled = true;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Renderer = menuStripMain.Renderer;
                    this.contextMenuStripMain.Items.Add(this.DelRecordToolStripMenuItem.Clone());
                    trvData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show();
                }
            }
        }

        #endregion

        #region"数据库连接"
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
            RefreshToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableAllOpr();
            clearDataShower();
            MongoDBHelpler.FillMongoServiceToTreeView(trvsrvlst);
        }
        /// <summary>
        /// 服务器状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SrvStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiceStatus mfrm = new frmServiceStatus();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        /// <summary>
        /// 展开所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.ExpandAll();
        }
        /// <summary>
        /// 折叠所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.trvsrvlst.CollapseAll();
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

        #region"工具"
        /// <summary>
        /// 配置
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
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportDataFromAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportOleDB mfrm = new frmImportOleDB();
            mfrm.Icon = GetSystemIcon.ConvertImgToIcon(ImportDataFromAccessToolStripMenuItem.Image);
            mfrm.ShowDialog();
            String DBFilename = mfrm.DataBaseFileName;
            if (DBFilename != string.Empty)
            {
                MongoDBHelpler.ImportAccessDataBase(DBFilename, SystemManager.SelectObjectTag, trvsrvlst.SelectedNode);
            }
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

        #region"管理：服务器"
        /// <summary>
        /// 建立数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strDBName = Microsoft.VisualBasic.Interaction.InputBox("请输入数据库名称：", "创建数据库");
            if (strDBName == string.Empty)
            {
                return;
            }
            if (MongoDBHelpler.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelpler.Oprcode.Create, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }
        /// <summary>
        /// 建立Admin用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "创建用户");
            String strPassword = Microsoft.VisualBasic.Interaction.InputBox("请输入密码：", "创建用户");
            MongoDBHelpler.AddUserToSvr(SystemManager.SelectObjectTag, strUserName, strPassword, false);
        }
        /// <summary>
        /// 删除Admin用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelUserFromAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "移除用户");
            MongoDBHelpler.RemoveUserFromSvr(SystemManager.SelectObjectTag, strUserName);
        }
        /// <summary>
        /// 服务器属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SvrPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MongoDBHelpler.GetCurrentSvrInfo(), "服务器属性");
        }
        /// <summary>
        /// 关闭服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShutDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO:可能有异常
            MongoDBHelpler.Shutdown();
            trvsrvlst.Nodes.Remove(trvsrvlst.SelectedNode);
        }
        #endregion

        #region"管理：数据集"
        /// <summary>
        /// 删除Mongo数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strCollection = strPath.Split("/".ToCharArray())[2];
            if (trvsrvlst.SelectedNode == null)
            {
                trvsrvlst.SelectedNode = null;
            }
            if (MongoDBHelpler.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelpler.Oprcode.Drop, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                clearDataShower();
            }
        }
        /// <summary>
        /// 索引管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IndexManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCollectionIndex mfrm = new frmCollectionIndex();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabDataShower.SelectedTab == tabTableView)
            {
                //lstData
                String strKey = lstData.Columns[0].Text;
                foreach (ListViewItem item in lstData.SelectedItems)
                {
                    MongoDBHelpler.DropRecord(SystemManager.GetCurrentCollection(), item.Tag, strKey);
                }
                lstData.ContextMenuStrip = null;
            }
            else
            {
                String strKey = trvData.SelectedNode.Text.Split(":".ToCharArray())[0];
                MongoDBHelpler.DropRecord(SystemManager.GetCurrentCollection(), trvData.SelectedNode.Tag, strKey);
                trvData.ContextMenuStrip = null;
            }
            DelRecordToolStripMenuItem.Enabled = false;
            RefreshData();
        }
        /// <summary>
        /// 重命名数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strCollection = strPath.Split("/".ToCharArray())[2];
            String strNewCollectionName = Microsoft.VisualBasic.Interaction.InputBox("请输入新数据集名称：", "数据集改名");
            if (MongoDBHelpler.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelpler.Oprcode.Rename, trvsrvlst.SelectedNode, strNewCollectionName))
            {
                DisableAllOpr();
                clearDataShower();
                SystemManager.SelectObjectTag = trvsrvlst.SelectedNode.Tag.ToString();
                statusStripMain.Items[0].Text = "选中数据集:" + SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            MongoDBHelpler.ClearFilter();
            clearDataShower();
            MongoDBHelpler.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        #endregion

        #region"管理：GFS"
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog upfile = new OpenFileDialog();
            if (upfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelpler.UpLoadFile(upfile.FileName);
            }
            RefreshData();
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog downfile = new SaveFileDialog();
            String strFileName = lstData.SelectedItems[0].Text;
            downfile.FileName = strFileName.Split(@"\".ToCharArray())[strFileName.Split(@"\".ToCharArray()).Length - 1];
            if (downfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelpler.DownloadFile(downfile.FileName, strFileName);
            }
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strFileName = lstData.SelectedItems[0].Text;
            MongoDBHelpler.OpenFile(strFileName);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strFileName = lstData.SelectedItems[0].Text;
            MongoDBHelpler.DelFile(strFileName);
            RefreshData();
        }
        private void InitGFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.InitGFS();
        }
        #endregion

        #region"管理：数据库"

        /// <summary>
        /// 删除MongoDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelMongoDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strPath = SystemManager.SelectObjectTag.Split(":".ToCharArray())[1];
            String strDBName = strPath.Split("/".ToCharArray())[1];
            if (trvsrvlst.SelectedNode == null) {
                trvsrvlst.SelectedNode = null;
            }
            if (MongoDBHelpler.DataBaseOpration(SystemManager.SelectObjectTag, strDBName, MongoDBHelpler.Oprcode.Drop, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }
        /// <summary>
        /// 建立数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateMongoCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strCollection = Microsoft.VisualBasic.Interaction.InputBox("请输入数据集名称：", "创建数据集");
            if (strCollection == string.Empty)
            {
                return;
            }
            if (MongoDBHelpler.CollectionOpration(SystemManager.SelectObjectTag, strCollection, MongoDBHelpler.Oprcode.Create, trvsrvlst.SelectedNode))
            {
                DisableAllOpr();
                lstData.Clear();
            }
        }
        /// <summary>
        /// 建立用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "创建用户");
            String strPassword = Microsoft.VisualBasic.Interaction.InputBox("请输入密码：", "创建用户");
            MongoDBHelpler.AddUserToDB(SystemManager.SelectObjectTag, strUserName, strPassword, false);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strUserName = Microsoft.VisualBasic.Interaction.InputBox("请输入用户名：", "移除用户");
            MongoDBHelpler.RemoveUserFromDB(SystemManager.SelectObjectTag, strUserName);
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

        private void ShardConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShardingConfig mfrm = new frmShardingConfig();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        private void mapReduceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMapReduce mfrm = new frmMapReduce();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        #endregion

        #region"数据导航"
        private void PrePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.PrePage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void NextPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.NextPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void FirstPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.FirstPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void LastPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelpler.PageChanged(MongoDBHelpler.PageChangeOpr.LastPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void ExpandAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvData.ExpandAll();
        }

        private void CollapseAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvData.CollapseAll();
        }
        private void QueryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuery mfrm = new frmQuery();
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
            //重新展示数据
            MongoDBHelpler.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }

        private void SetDataNav()
        {
            PrePageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
            NextPageToolStripMenuItem.Enabled = MongoDBHelpler.HasNextPage;
            FirstPageToolStripMenuItem.Enabled = MongoDBHelpler.HasPrePage;
            LastPageToolStripMenuItem.Enabled = MongoDBHelpler.HasNextPage;
            this.QueryDataToolStripMenuItem.Enabled = true;
            this.ExpandAllDataToolStripMenuItem.Enabled = true;
            this.CollapseAllDataToolStripMenuItem.Enabled = true;
            SetToolBar();
            statusStripMain.Items[1].Text = "数据视图：" + (MongoDBHelpler.SkipCnt + 1).ToString() + "/" + MongoDBHelpler.CurrentCollectionTotalCnt.ToString();
        }
        #endregion

        #region "帮助"
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strThanks = "MagicMongoDBTool 开发者：MagicHu";
            MessageBox.Show(strThanks, "关于");
        }

        private void ThanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strThanks = "感谢皮肤控件的作者：qianlifeng\r\n感谢10gen的C# Driver开发者的技术支持\r\n感谢Dragon同志的测试";
            MessageBox.Show(strThanks, "感谢");
        }
        #endregion

        #region"管理：备份和恢复"
        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestoreMongoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                SystemManager.ShowErrMsg("Mongo目录没有找到，请确认", "Mongo目录[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]没有找到，请重新设置。");
                return;
            }
            MongodbDosCommand.StruMongoRestore MongoRestore = new MongodbDosCommand.StruMongoRestore();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoRestore.HostAddr = Mongosrv.Address.Host;
            MongoRestore.Port = Mongosrv.Address.Port;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoRestore.DirectoryPerDB = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongoRestoreCommandLine(MongoRestore);
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            SystemManager.ShowErrMsg("执行结果", Info.ToString());
            RefreshToolStripMenuItem_Click(null, null);
        }
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                SystemManager.ShowErrMsg("Mongo目录没有找到，请确认", "Mongo目录[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]没有找到，请重新设置。");
                return;
            }
            MongodbDosCommand.StruMongoDump MongoDump = new MongodbDosCommand.StruMongoDump();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = SystemManager.GetCurrentDataBase().Name;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            SystemManager.ShowErrMsg("执行结果", Info.ToString());
        }
        /// <summary>
        /// 备份数据集
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DumpCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                SystemManager.ShowErrMsg("Mongo目录没有找到，请确认", "Mongo目录[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]没有找到，请重新设置。");
                return;
            }
            MongodbDosCommand.StruMongoDump MongoDump = new MongodbDosCommand.StruMongoDump();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoDump.HostAddr = Mongosrv.Address.Host;
            MongoDump.Port = Mongosrv.Address.Port;
            MongoDump.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoDump.CollectionName = SystemManager.GetCurrentCollection().Name;
            FolderBrowserDialog dumpFile = new FolderBrowserDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDump.OutPutPath = dumpFile.SelectedPath;
            }
            String DosCommand = MongodbDosCommand.GetMongodumpCommandLine(MongoDump);
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            SystemManager.ShowErrMsg("执行结果", Info.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                SystemManager.ShowErrMsg("Mongo目录没有找到，请确认", "Mongo目录[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]没有找到，请重新设置。");
                return;
            }
            MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
            OpenFileDialog dumpFile = new OpenFileDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoImportExport.FileName = dumpFile.FileName;
            }
            MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Export;
            String DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            SystemManager.ShowErrMsg("执行结果", Info.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MongodbDosCommand.IsMongoPathExist())
            {
                SystemManager.ShowErrMsg("Mongo目录没有找到，请确认", "Mongo目录[" + SystemManager.ConfigHelperInstance.MongoBinPath + "]没有找到，请重新设置。");
                return;
            }
            MongodbDosCommand.StruImportExport MongoImportExport = new MongodbDosCommand.StruImportExport();
            MongoDB.Driver.MongoServerInstance Mongosrv = SystemManager.GetCurrentService().Instance;
            MongoImportExport.HostAddr = Mongosrv.Address.Host;
            MongoImportExport.Port = Mongosrv.Address.Port;
            MongoImportExport.DBName = SystemManager.GetCurrentDataBase().Name;
            MongoImportExport.CollectionName = SystemManager.GetCurrentCollection().Name;
            OpenFileDialog dumpFile = new OpenFileDialog();
            if (dumpFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoImportExport.FileName = dumpFile.FileName;
            }
            MongoImportExport.Direct = MongodbDosCommand.ImprotExport.Import;
            String DosCommand = MongodbDosCommand.GetMongoImportExportCommandLine(MongoImportExport);
            StringBuilder Info = new StringBuilder();
            MongodbDosCommand.RunDosCommand(DosCommand, Info);
            SystemManager.ShowErrMsg("执行结果", Info.ToString());
        }
        #endregion
    }
}
