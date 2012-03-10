using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool.UserController
{
    public partial class ctlDataView : UserControl
    {
        #region"Main"

        public ctlDataView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Control for show Data
        /// </summary>
        public List<Control> _dataShower = new List<Control>();
        /// <summary>
        /// Current Connection Config
        /// </summary>
        public ConfigHelper.MongoConnectionConfig config = new ConfigHelper.MongoConnectionConfig();
        private void ctlDataView_Load(object sender, EventArgs e)
        {
            _dataShower.Add(lstData);
            _dataShower.Add(trvData);
            _dataShower.Add(txtData);

            QueryDataToolStripButton = this.QueryDataToolStripMenuItem.CloneFromMenuItem();
            DataFilterToolStripButton = this.DataFilterToolStripMenuItem.CloneFromMenuItem();
            

            this.FirstPageToolStripButton.Enabled = false;
            this.LastPageToolStripButton.Enabled = false;
            this.NextPageToolStripButton.Enabled = false;
            this.PrePageToolStripButton.Enabled = false;

            this.QueryDataToolStripButton.Enabled = false;
            this.DataFilterToolStripButton.Enabled = false;
            this.DataFilterToolStripButton.Checked = false;


            this.lstData.MouseClick += new MouseEventHandler(lstData_MouseClick);
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new EventHandler(lstData_SelectedIndexChanged);
            this.trvData.MouseClick += new MouseEventHandler(trvData_MouseClick_Top);
            this.trvData.AfterSelect += new TreeViewEventHandler(trvData_AfterSelect_Top);
            this.trvData.KeyDown += new KeyEventHandler(trvData_KeyDown);
            this.trvData.AfterExpand += new TreeViewEventHandler(trvData_AfterExpand);
            this.trvData.AfterCollapse += new TreeViewEventHandler(trvData_AfterCollapse);
            this.tabDataShower.SelectedIndexChanged += new EventHandler(
                //If tabpage changed,the selected data in dataview will disappear,set delete selected record to false
                (x, y) =>
                {
                    this.DelSelectRecordToolStripMenuItem.Enabled = false;
                    if (IsNeedRefresh)
                    {
                        RefreshData();
                    }
                }
            );
            if (!SystemManager.IsUseDefaultLanguage())
            {
                //数据显示区
                this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
                this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
                this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);
                this.lnkFile.Text = SystemManager.mStringResource.GetText(StringResource.TextType.OpenInNativeEditor);

                this.PrePage.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Previous);
                this.NextPage.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Next);
                this.FirstPage.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_First);
                this.LastPage.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Last);


                this.AddDocumentToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_AddDocument);
                this.DataDocumentToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument);
                this.AddElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_AddElement);
                this.DropElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_DropElement);
                this.ModifyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_ModifyElement);
                this.CopyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CopyElement);
                this.CutElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CutElement);
                this.PasteElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_PasteElement);
                this.DelSelectRecordToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DropDocument);

            }

            //View ToolTip
            this.ViewtoolStrip.Items.Add(FirstPageToolStripButton);
            this.ViewtoolStrip.Items.Add(PrePageToolStripButton);
            this.ViewtoolStrip.Items.Add(NextPageToolStripButton);
            this.ViewtoolStrip.Items.Add(LastPageToolStripButton);
            this.ViewtoolStrip.Items.Add(QueryDataToolStripButton);
            this.ViewtoolStrip.Items.Add(DataNaviToolStripLabel);
            this.ViewtoolStrip.Items.Add(DataFilterToolStripButton);
        }
        /// <summary>
        /// 
        /// </summary>
        public void clear()
        {
            lstData.Clear();
            txtData.Text = String.Empty;
            trvData.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.ContextMenuStrip = null;
        }
        #endregion

        //GFS
        public ToolStripMenuItem UploadFileToolStripMenuItem;
        public ToolStripMenuItem DownloadFileToolStripMenuItem;
        public ToolStripMenuItem OpenFileToolStripMenuItem;
        public ToolStripMenuItem DelFileToolStripMenuItem;

        //Record
        public ToolStripMenuItem RemoveUserFromAdminToolStripMenuItem;
        public ToolStripMenuItem RemoveUserToolStripMenuItem;

        public ToolStripMenuItem QueryDataToolStripMenuItem;
        public ToolStripMenuItem DataFilterToolStripMenuItem;

        #region"数据展示区操作"
        /// <summary>
        /// 数据列表选中索引变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SystemManager.GetCurrentCollection().Name)
            {
                case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
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
                            if (!config.IsReadOnly)
                            {
                                DelFileToolStripMenuItem.Enabled = true;
                            }
                            DownloadFileToolStripMenuItem.Enabled = true;
                            OpenFileToolStripMenuItem.Enabled = true;
                            break;
                        default:
                            //可以删除多个文件
                            DownloadFileToolStripMenuItem.Enabled = false;
                            OpenFileToolStripMenuItem.Enabled = false;
                            if (!config.IsReadOnly)
                            {
                                DelFileToolStripMenuItem.Enabled = true;
                            }
                            break;
                    }
                    break;
                case MongoDBHelper.COLLECTION_NAME_USER:
                    //用户数据库
                    if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                    {
                        if (lstData.SelectedItems.Count > 0)
                        {
                            if (!config.IsReadOnly)
                            {
                                this.RemoveUserFromAdminToolStripMenuItem.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (lstData.SelectedItems.Count > 0)
                        {
                            if (!config.IsReadOnly)
                            {
                                this.RemoveUserToolStripMenuItem.Enabled = true;
                            }
                        }
                    }
                    break;
                default:
                    //数据系统
                    DelSelectRecordToolStripMenuItem.Enabled = false;
                    if (lstData.SelectedItems.Count > 0)
                    {
                        if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                        {
                            //系统数据禁止删除
                            if (!config.IsReadOnly)
                            {
                                DelSelectRecordToolStripMenuItem.Enabled = true;
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SystemManager.GetCurrentCollection().Name == MongoDBHelper.COLLECTION_NAME_GFS_FILES)
            {
                String strFileName = lstData.SelectedItems[0].Text;
                MongoDBHelper.OpenFile(strFileName);
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

                    switch (SystemManager.GetCurrentCollection().Name)
                    {
                        case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                            //Grid File System
                            this.contextMenuStripMain.Items.Add(this.DownloadFileToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.OpenFileToolStripMenuItem.Clone());
                            this.contextMenuStripMain.Items.Add(this.DelFileToolStripMenuItem.Clone());
                            break;
                        case MongoDBHelper.COLLECTION_NAME_USER:
                            if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserFromAdminToolStripMenuItem.Clone());
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            }
                            break;
                        default:
                            this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                            break;
                    }
                    lstData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }

        /// <summary>
        /// 数据树菜单的禁止
        /// </summary>
        public void DisableDataTreeOpr()
        {
            RemoveUserFromAdminToolStripMenuItem.Enabled = false;
            RemoveUserToolStripMenuItem.Enabled = false;
            DelSelectRecordToolStripMenuItem.Enabled = false;
            DelFileToolStripMenuItem.Enabled = false;
            AddElementToolStripMenuItem.Enabled = false;
            DropElementToolStripMenuItem.Enabled = false;
            ModifyElementToolStripMenuItem.Enabled = false;
            CopyElementToolStripMenuItem.Enabled = false;
            CutElementToolStripMenuItem.Enabled = false;
            PasteElementToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// 数据树形被选择后(TOP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect_Top(object sender, TreeViewEventArgs e)
        {
            DisableDataTreeOpr();
            if (trvData.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                if (!config.IsReadOnly)
                {
                    switch (SystemManager.GetCurrentCollection().Name)
                    {
                        case MongoDBHelper.COLLECTION_NAME_GFS_FILES:

                            DelFileToolStripMenuItem.Enabled = true;
                            break;
                        case MongoDBHelper.COLLECTION_NAME_USER:

                            if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                            {
                                RemoveUserFromAdminToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                RemoveUserToolStripMenuItem.Enabled = true;
                            }
                            break;
                        default:
                            if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()))
                            {
                                //普通数据
                                //在顶层的时候，允许添加元素,不允许删除元素和修改元素(删除选中记录)
                                DelSelectRecordToolStripMenuItem.Enabled = true;
                                AddElementToolStripMenuItem.Enabled = true;
                                if (MongoDBHelper.CanPasteAsElement)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                }
                            }
                            else
                            {
                                DelSelectRecordToolStripMenuItem.Enabled = false;
                            }
                            break;
                    }
                }
            }
            else
            {
                //非顶层元素
                trvData_AfterSelect_NotTop(sender, e);
            }
        }
        /// <summary>
        /// 数据树形被选择后(非TOP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect_NotTop(object sender, TreeViewEventArgs e)
        {
            //非顶层可以删除的节点
            switch (SystemManager.GetCurrentCollection().Name)
            {
                case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                case MongoDBHelper.COLLECTION_NAME_USER:
                default:
                    if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) & !config.IsReadOnly)
                    {
                        //普通数据:允许添加元素,不允许删除元素
                        DropElementToolStripMenuItem.Enabled = true;
                        CopyElementToolStripMenuItem.Enabled = true;
                        CutElementToolStripMenuItem.Enabled = true;
                        if (trvData.SelectedNode.Nodes.Count != 0)
                        {
                            //父节点
                            //1. 以Array_Mark结尾的数组
                            //2. Document
                            if (trvData.SelectedNode.FullPath.EndsWith(MongoDBHelper.Array_Mark))
                            {
                                //列表的父节点
                                if (MongoDBHelper.CanPasteAsValue)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                }
                            }
                            else
                            {
                                //文档的父节点
                                if (MongoDBHelper.CanPasteAsElement)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                }
                            }
                            AddElementToolStripMenuItem.Enabled = true;
                            ModifyElementToolStripMenuItem.Enabled = false;
                        }
                        else
                        {
                            //子节点
                            //1.简单元素
                            //2.空的Array
                            //3.空的文档
                            //4.Array中的Value
                            BsonValue t;
                            if (trvData.SelectedNode.Tag is BsonElement)
                            {
                                //子节点是一个元素，获得子节点的Value
                                t = ((BsonElement)trvData.SelectedNode.Tag).Value;
                                if (t.IsBsonDocument || t.IsBsonArray)
                                {
                                    //2.空的Array
                                    //3.空的文档
                                    ModifyElementToolStripMenuItem.Enabled = false;
                                    AddElementToolStripMenuItem.Enabled = true;
                                    if (t.IsBsonDocument)
                                    {
                                        //3.空的文档
                                        if (MongoDBHelper.CanPasteAsElement)
                                        {
                                            PasteElementToolStripMenuItem.Enabled = true;
                                        }

                                    }
                                    if (t.IsBsonArray)
                                    {
                                        //3.Array
                                        if (MongoDBHelper.CanPasteAsValue)
                                        {
                                            PasteElementToolStripMenuItem.Enabled = true;
                                        }
                                    }
                                }
                                else
                                {
                                    //1.简单元素
                                    ModifyElementToolStripMenuItem.Enabled = true;
                                    AddElementToolStripMenuItem.Enabled = false;
                                }
                            }
                            else
                            {
                                //子节点是一个Array的Value，获得Value
                                //4.Array中的Value
                                t = (BsonValue)trvData.SelectedNode.Tag;
                                ModifyElementToolStripMenuItem.Enabled = true;
                                if (t.IsBsonArray || t.IsBsonDocument)
                                {
                                    //当这个值是一个数组或者文档时候，仍然允许其添加子元素
                                    AddElementToolStripMenuItem.Enabled = true;
                                }
                                else
                                {
                                    AddElementToolStripMenuItem.Enabled = false;
                                }
                            }
                        }
                    }
                    break;
            }
        }

        private Boolean IsNeedChangeNode = true;
        /// <summary>
        /// 展开节点后的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvData_AfterExpand(object sender, TreeViewEventArgs e)
        {
            trvData.SelectedNode = e.Node;
            IsNeedChangeNode = false;
            SystemManager.SetCurrentDocument(e.Node);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvData_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            trvData.SelectedNode = e.Node;
            IsNeedChangeNode = false;
            SystemManager.SetCurrentDocument(e.Node);
        }
        /// <summary>
        /// 鼠标动作（顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_Top(object sender, MouseEventArgs e)
        {
            if (IsNeedChangeNode)
            {
                //在节点展开和关闭后，不能使用这个方法来重新设定SelectedNode
                trvData.SelectedNode = this.trvData.GetNodeAt(e.Location);
            }
            IsNeedChangeNode = true;
            if (trvData.SelectedNode == null)
            {
                return;
            }
            SystemManager.SetCurrentDocument(trvData.SelectedNode);
            if (trvData.SelectedNode.Level == 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();

                    //顶层可以修改的节点
                    switch (SystemManager.GetCurrentCollection().Name)
                    {
                        case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                            this.contextMenuStripMain.Items.Add(this.DelFileToolStripMenuItem.Clone());
                            break;
                        case MongoDBHelper.COLLECTION_NAME_USER:
                            if (SystemManager.GetCurrentDataBase().Name == MongoDBHelper.DATABASE_NAME_ADMIN)
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserFromAdminToolStripMenuItem.Clone());
                            }
                            else
                            {
                                this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                            }
                            break;
                        default:
                            ///允许删除
                            this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                            ///允许添加
                            this.contextMenuStripMain.Items.Add(this.AddElementToolStripMenuItem.Clone());
                            ///允许粘贴
                            this.contextMenuStripMain.Items.Add(this.PasteElementToolStripMenuItem.Clone());
                            break;
                    }
                    trvData.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show(trvData.PointToScreen(e.Location));
                }
            }
            else
            {
                //非顶层元素
                trvData_MouseClick_NotTop(sender, e);
            }
        }
        /// <summary>
        /// 鼠标动作（非顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_NotTop(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextMenuStripMain = new ContextMenuStrip();

                //顶层可以删除的节点
                switch (SystemManager.GetCurrentCollection().Name)
                {
                    case MongoDBHelper.COLLECTION_NAME_GFS_FILES:
                    case MongoDBHelper.COLLECTION_NAME_USER:
                    default:
                        this.contextMenuStripMain.Items.Add(this.AddElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.ModifyElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.DropElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.CopyElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.CutElementToolStripMenuItem.Clone());
                        this.contextMenuStripMain.Items.Add(this.PasteElementToolStripMenuItem.Clone());
                        break;
                }
                trvData.ContextMenuStrip = this.contextMenuStripMain;
                contextMenuStripMain.Show(trvData.PointToScreen(e.Location));
            }
        }
        /// <summary>
        /// 键盘动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (DelSelectRecordToolStripMenuItem.Enabled)
                    {
                        DelSelectRecordToolStripMenuItem_Click(null, null);
                    }
                    else
                    {
                        if (this.DropElementToolStripMenuItem.Enabled)
                        {
                            DropElement();
                        }
                    }
                    break;
                case Keys.F2:
                    if (this.ModifyElementToolStripMenuItem.Enabled)
                    {
                        ModifyElement();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region"管理：元素操作"
        /// <summary>
        /// Is Need Refresh after the element is modify
        /// </summary>
        public Boolean IsNeedRefresh = false;
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelSelectRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Delete Document";
            String strMessage = "Are you sure to delete selected document(s)?";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    String strKey = lstData.Columns[0].Text;
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.DropDocument(SystemManager.GetCurrentCollection(), item.Tag, strKey);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    String strKey = trvData.SelectedNode.Nodes[0].Text.Split(":".ToCharArray())[0];
                    MongoDBHelper.DropDocument(SystemManager.GetCurrentCollection(), trvData.SelectedNode.Tag, strKey);
                    trvData.ContextMenuStrip = null;
                }
                DelSelectRecordToolStripMenuItem.Enabled = false;
                RefreshData();
            }
        }
        /// <summary>
        /// Add Empty Document to Collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BsonValue id = MongoDBHelper.InsertEmptyDocument(SystemManager.GetCurrentCollection(), config.IsSafeMode);
            TreeNode newDoc = new TreeNode(SystemManager.GetCurrentCollection().Name + "[" + (SystemManager.GetCurrentCollection().Count()).ToString() + "]");
            newDoc.Tag = id;
            TreeNode newid = new TreeNode("_id:" + id.ToString());
            newid.Tag = id;
            newDoc.Nodes.Add(newid);
            trvData.Nodes.Add(newDoc);
            tabDataShower.SelectedIndex = 0;
            trvData.SelectedNode = newid;
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddElement()
        {
            Boolean IsElement = true;
            BsonValue t;
            if (trvData.SelectedNode.Tag is BsonElement)
            {
                t = ((BsonElement)trvData.SelectedNode.Tag).Value;
            }
            else
            {
                t = (BsonValue)trvData.SelectedNode.Tag;
            }
            if (t.IsBsonArray)
            {
                IsElement = false;
            }
            SystemManager.OpenForm(new frmElement(false, trvData.SelectedNode, IsElement));
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DropElement()
        {
            if (trvData.SelectedNode.Level == 1 & trvData.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id Can't be delete");
                return;
            }
            if (trvData.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.DropArrayValue(trvData.SelectedNode.FullPath, trvData.SelectedNode.Index);
            }
            else
            {
                MongoDBHelper.DropElement(trvData.SelectedNode.FullPath, (BsonElement)trvData.SelectedNode.Tag);
            }
            trvData.Nodes.Remove(trvData.SelectedNode);
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ModifyElement()
        {
            if (trvData.SelectedNode.Level == 1 & trvData.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id can't be modify");
                return;
            }
            if (trvData.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                SystemManager.OpenForm(new frmElement(true, trvData.SelectedNode, false));
            }
            else
            {
                SystemManager.OpenForm(new frmElement(true, trvData.SelectedNode));
            }
            IsNeedRefresh = true;
        }
        /// <summary>
        /// Copy Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CopyElement()
        {
            MongoDBHelper._ClipElement = trvData.SelectedNode.Tag;
            if (trvData.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.CopyValue((BsonValue)trvData.SelectedNode.Tag);
            }
            else
            {
                MongoDBHelper.CopyElement((BsonElement)trvData.SelectedNode.Tag);
            }
        }
        /// <summary>
        /// Paste Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PasteElement()
        {
            if (trvData.SelectedNode.FullPath.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.PasteValue(trvData.SelectedNode.FullPath);
                TreeNode NewValue = new TreeNode(MongoDBHelper.ConvertToString((BsonValue)MongoDBHelper._ClipElement));
                NewValue.Tag = MongoDBHelper._ClipElement;
                trvData.SelectedNode.Nodes.Add(NewValue);
            }
            else
            {
                String PasteMessage = MongoDBHelper.PasteElement(trvData.SelectedNode.FullPath);
                if (String.IsNullOrEmpty(PasteMessage))
                {
                    //GetCurrentDocument()的第一个元素是ID
                    MongoDBHelper.AddBsonDocToTreeNode(trvData.SelectedNode,
                                                       new BsonDocument().Add((BsonElement)MongoDBHelper._ClipElement));
                }
                else
                {
                    MyMessageBox.ShowMessage("Exception", PasteMessage);
                }
            }
            IsNeedRefresh = true;
        }
        /// <summary>
        /// Cut Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CutElement()
        {
            if (trvData.SelectedNode.Level == 1 & trvData.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id can't be cut");
                return;
            }
            if (trvData.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.CutValue(trvData.SelectedNode.FullPath, trvData.SelectedNode.Index, (BsonValue)trvData.SelectedNode.Tag);
            }
            else
            {
                MongoDBHelper.CutElement(trvData.SelectedNode.FullPath, (BsonElement)trvData.SelectedNode.Tag);
            }
            trvData.Nodes.Remove(trvData.SelectedNode);
            IsNeedRefresh = true;
        }
        #endregion

        #region"管理：GFS"
        /// <summary>
        /// Upload File
        /// </summary>
        public void UploadFile()
        {
            OpenFileDialog upfile = new OpenFileDialog();
            if (upfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.UpLoadFile(upfile.FileName);
            }
            RefreshData();
        }
        /// <summary>
        /// DownLoad File
        /// </summary>
        public void DownloadFile()
        {
            SaveFileDialog downfile = new SaveFileDialog();
            String strFileName = lstData.SelectedItems[0].Text;
            //For Winodws,Linux user DirectorySeparatorChar Replace with @"\"
            downfile.FileName = strFileName.Split(System.IO.Path.DirectorySeparatorChar)[strFileName.Split(System.IO.Path.DirectorySeparatorChar).Length - 1];
            if (downfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MongoDBHelper.DownloadFile(downfile.FileName, strFileName);
            }
        }
        /// <summary>
        /// Open File
        /// </summary>
        public void OpenFile()
        {
            String strFileName = lstData.SelectedItems[0].Text;
            MongoDBHelper.OpenFile(strFileName);
        }
        /// <summary>
        /// Delete File
        /// </summary>
        public void DelFile()
        {
            String strTitle = "Delete Files";
            String strMessage = "Are you sure to delete selected File(s)?";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    String strFileName = lstData.SelectedItems[0].Text;
                    MongoDBHelper.DelFile(strFileName);
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.DelFile(trvData.SelectedNode.Tag.ToString());
                    trvData.ContextMenuStrip = null;
                }
                RefreshData();
            }
        }
        #endregion

        #region"数据导航"
        private void FirstPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.FirstPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void PrePage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.PrePage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void NextPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.NextPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void LastPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.LastPage, SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
        }
        private void ExpandAll_Click(object sender, EventArgs e)
        {
            trvData.ExpandAll();
        }
        private void CollapseAll_Click(object sender, EventArgs e)
        {
            trvData.CollapseAll();
        }
        private void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MongoDBHelper.SaveAndOpenStringAsFile(txtData.Text);
        }
        /// <summary>
        /// 设置导航可用性
        /// </summary>
        private void SetDataNav()
        {
            PrePage.Enabled = MongoDBHelper.HasPrePage;
            NextPage.Enabled = MongoDBHelper.HasNextPage;
            FirstPage.Enabled = MongoDBHelper.HasPrePage;
            LastPage.Enabled = MongoDBHelper.HasNextPage;
            this.QueryDataToolStripMenuItem.Enabled = true;
            String strTitle = "Records";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            }
            if (MongoDBHelper.CurrentCollectionTotalCnt == 0)
            {
                this.DataNaviToolStripLabel.Text = strTitle + "：0/0";
            }
            else
            {
                this.DataNaviToolStripLabel.Text = strTitle + "：" + (MongoDBHelper.SkipCnt + 1).ToString() + "/" + MongoDBHelper.CurrentCollectionTotalCnt.ToString();
            }
        }
        /// <summary>
        /// Refresh Data
        /// </summary>
        private void RefreshData()
        {
            this.clear();
            MongoDBHelper.SkipCnt = 0;
            MongoDBHelper.FillDataToControl(SystemManager.SelectObjectTag, _dataShower);
            SetDataNav();
            IsNeedRefresh = false;
        }

        #endregion

    }
}
