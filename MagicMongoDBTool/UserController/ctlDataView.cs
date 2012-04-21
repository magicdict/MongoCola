using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using System.IO;
using System.ComponentModel;

namespace MagicMongoDBTool.UserController
{
    public partial class ctlDataView : UserControl
    {

        #region"Main"

        /// <summary>
        /// 这里需要控制3中不同的数据类型，普通的Collection，GFS，USER。
        /// 图标复用方式来处理不同的类型。
        /// </summary>
        public ctlDataView()
        {
            InitializeComponent();
        }

        private Boolean _IsDataView = true;
        [Description("Is used for display a data collection")]
        public Boolean IsDataView
        {
            set
            {
                _IsDataView = value;
                this.tabTextView.Visible = _IsDataView;
                this.tabTreeView.Visible = _IsDataView;
                this.tabQuery.Visible = _IsDataView;
                NewDocumentStripButton.Visible = _IsDataView;
                OpenDocInEditorStripButton.Visible = _IsDataView;
                DelSelectRecordToolStripButton.Visible = _IsDataView;
            }
            get
            {
                return _IsDataView;
            }
        }
        public ctlDataView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            mDataViewInfo = _DataViewInfo;
        }
        /// <summary>
        /// Control for show Data
        /// </summary>
        public List<Control> _dataShower = new List<Control>();
        /// <summary>
        /// DataView信息
        /// </summary>
        public MongoDBHelper.DataViewInfo mDataViewInfo;
        /// <summary>
        /// 关闭Tab事件
        /// </summary>
        public event EventHandler CloseTab;
        /// <summary>
        /// 是否为Admin数据库
        /// </summary>
        protected Boolean IsAdminDB;
        /// <summary>
        /// 是否为系统数据集
        /// </summary>
        private Boolean IsSystemCollection;
        /// <summary>
        /// 节点类型
        /// </summary>
        private String strNodeType;
        /// <summary>
        /// 节点路径
        /// </summary>
        private String strNodeData;
        /// <summary>
        /// 加载数据集控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlDataView_Load(object sender, EventArgs e)
        {
            if (mDataViewInfo == null) { return; }
            this.cmbRecPerPage.SelectedIndex = 1;
            mDataViewInfo.LimitCnt = 100;
            strNodeType = mDataViewInfo.strDBTag.Split(":".ToCharArray())[0];
            strNodeData = mDataViewInfo.strDBTag.Split(":".ToCharArray())[1];

            String[] DataList = strNodeData.Split("/".ToCharArray());
            if (DataList[(int)MongoDBHelper.PathLv.DatabaseLV] == MongoDBHelper.DATABASE_NAME_ADMIN)
            {
                IsAdminDB = true;
            }
            IsSystemCollection = MongoDBHelper.IsSystemCollection(DataList[(int)MongoDBHelper.PathLv.DatabaseLV],
                                                                  DataList[(int)MongoDBHelper.PathLv.CollectionLV]);

            if (strNodeType == MongoDBHelper.COLLECTION_TAG)
            {
                _dataShower.Add(lstData);
                _dataShower.Add(trvData);
                _dataShower.Add(txtData);
            }
            else
            {
                _dataShower.Add(lstData);
                this.tabDataShower.Controls.Remove(tabTreeView);
                this.tabDataShower.Controls.Remove(tabTextView);
            }

            this.lstData.MouseClick += new MouseEventHandler(lstData_MouseClick);
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.lstData.SelectedIndexChanged += new EventHandler(lstData_SelectedIndexChanged);
            this.trvData.DatatreeView.MouseClick += new MouseEventHandler(trvData_MouseClick_Top);
            this.trvData.DatatreeView.AfterSelect += new TreeViewEventHandler(trvData_AfterSelect_Top);
            this.trvData.DatatreeView.KeyDown += new KeyEventHandler(trvData_KeyDown);
            this.trvData.DatatreeView.AfterExpand += new TreeViewEventHandler(trvData_AfterExpand);
            this.trvData.DatatreeView.AfterCollapse += new TreeViewEventHandler(trvData_AfterCollapse);


            this.tabDataShower.SelectedIndexChanged += new EventHandler(
                //If tabpage changed,the selected data in dataview will disappear,set delete selected record to false
                (x, y) =>
                {
                    this.DelSelectRecordToolStripMenuItem.Enabled = false;
                    if (IsNeedRefresh)
                    {
                        RefreshGUI(sender, e);
                    }
                }
            );
            if (!SystemManager.IsUseDefaultLanguage())
            {
                //数据显示区
                this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
                this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
                this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);

                this.NewDocumentToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_AddDocument);
                this.NewDocumentStripButton.Text = this.NewDocumentToolStripMenuItem.Text;
                this.OpenDocInEditorStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_OpenInNativeEditor);
                this.DelSelectRecordToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DropDocument);
                this.DelSelectRecordToolStripButton.Text = this.DelSelectRecordToolStripMenuItem.Text;

                this.PrePageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Previous);
                this.NextPageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Next);
                this.FirstPageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_First);
                this.LastPageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Last);
                this.QueryStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Query);
                this.FilterStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_DataFilter);

                this.AddElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_AddElement);
                this.DropElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_DropElement);
                this.ModifyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_ModifyElement);

                this.CopyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CopyElement);
                this.CopyElementStripButton.Text = this.CopyElementToolStripMenuItem.Text;
                this.CutElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CutElement);
                this.CutElementStripButton.Text = this.CutElementToolStripMenuItem.Text;
                this.PasteElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_PasteElement);
                this.PasteElementStripButton.Text = this.PasteElementToolStripMenuItem.Text;

                this.RefreshStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Refresh);
                this.CloseStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
                this.ExpandAllStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Expansion);
                this.CollapseAllStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collapse);

            }
            InitControlsVisiableAndEvent();
            InitControlsEnable();
            //加载数据
            List<BsonDocument> datalist = MongoDBHelper.GetDataList(ref mDataViewInfo);
            MongoDBHelper.FillDataToControl(datalist, _dataShower, mDataViewInfo);
            //数据导航
            SetDataNav();
            tabDataShower.TabPages.Remove(tabQuery);
        }
        /// <summary>
        /// 将所有的按钮和右键菜单无效化
        /// </summary>
        private void InitControlsVisiableAndEvent()
        {
            foreach (var item in this.contextMenuStripMain.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)item).Visible = false;
                }
            }
            foreach (var item in ViewtoolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    ((ToolStripButton)item).Visible = false;
                }
            }
            NewDocumentStripButton.Visible = true;
            NewDocumentToolStripMenuItem.Visible = true;
            NewDocumentToolStripMenuItem.Click += new EventHandler(NewDocumentStripButton_Click);

            OpenDocInEditorStripButton.Visible = true;
            OpenDocInEditorStripMenuItem.Visible = true;
            OpenDocInEditorStripMenuItem.Click += new EventHandler(OpenDocInEditorDocStripButton_Click);

            DelSelectRecordToolStripButton.Visible = true;
            DelSelectRecordToolStripMenuItem.Visible = true;
            DelSelectRecordToolStripMenuItem.Click += new EventHandler(DelSelectRecordToolStripButton_Click);

            ExpandAllStripButton.Visible = true;
            CollapseAllStripButton.Visible = true;

            CutElementStripButton.Visible = true;
            CutElementStripButton.Click += new EventHandler(CutElementToolStripMenuItem_Click);
            CutElementToolStripMenuItem.Visible = true;

            CopyElementStripButton.Visible = true;
            CopyElementStripButton.Click += new EventHandler(CopyElementToolStripMenuItem_Click);
            CopyElementToolStripMenuItem.Visible = true;

            PasteElementStripButton.Visible = true;
            PasteElementStripButton.Click += new EventHandler(PasteElementToolStripMenuItem_Click);
            PasteElementToolStripMenuItem.Visible = true;

            AddElementToolStripMenuItem.Visible = true;
            DropElementToolStripMenuItem.Visible = true;
            ModifyElementToolStripMenuItem.Visible = true;

            FirstPageStripButton.Visible = true;
            PrePageStripButton.Visible = true;
            NextPageStripButton.Visible = true;
            LastPageStripButton.Visible = true;
            this.FilterStripButton.Visible = true;
            this.QueryStripButton.Visible = true;

            GotoStripButton.Visible = true;
            RefreshStripButton.Visible = true;
            RefreshStripButton.Enabled = true;
            CloseStripButton.Visible = true;
            CloseStripButton.Enabled = true;
        }
        private void InitControlsEnable()
        {
            foreach (var item in this.contextMenuStripMain.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)item).Enabled = false;
                }
            }
            foreach (var item in ViewtoolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    ((ToolStripButton)item).Enabled = false;
                }
            }


            OpenDocInEditorStripButton.Enabled = true;
            OpenDocInEditorStripMenuItem.Enabled = true;
            if (!mDataViewInfo.IsReadOnly)
            {
                this.NewDocumentStripButton.Enabled = true;
                this.NewDocumentToolStripMenuItem.Enabled = true;
            }
            ExpandAllStripButton.Enabled = true;
            CollapseAllStripButton.Enabled = true;


            PrePageStripButton.Enabled = mDataViewInfo.HasPrePage;
            NextPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            FirstPageStripButton.Enabled = mDataViewInfo.HasPrePage;
            LastPageStripButton.Enabled = mDataViewInfo.HasNextPage;

            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            this.FilterStripButton.Enabled = true;
            this.QueryStripButton.Enabled = true;

            GotoStripButton.Enabled = true;
            RefreshStripButton.Enabled = true;
            CloseStripButton.Enabled = true;
        }
        /// <summary>
        /// 关闭本Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            if (CloseTab != null)
            {
                CloseTab(sender, e);
            }
        }

        #endregion

        #region"数据展示区操作"
        /// <summary>
        /// Is Need Refresh after the element is modify
        /// </summary>
        public Boolean IsNeedRefresh = false;
        /// <summary>
        /// 数据列表选中索引变换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstData.SelectedItems.Count > 0 && !IsSystemCollection && !mDataViewInfo.IsReadOnly)
            {
                DelSelectRecordToolStripMenuItem.Enabled = true;
                DelSelectRecordToolStripButton.Enabled = true;
            }
            else
            {
                DelSelectRecordToolStripButton.Enabled = false;
                DelSelectRecordToolStripMenuItem.Enabled = false;
            }
            if (this.lstData.SelectedItems.Count == 1)
            {
                OpenDocInEditorStripButton.Enabled = true;
                OpenDocInEditorStripMenuItem.Enabled = true;
            }

        }
        /// <summary>
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDocInEditorDocStripButton_Click(sender, e);
        }
        /// <summary>
        /// 数据列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Items.Add(this.NewDocumentToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.OpenDocInEditorStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }

        /// <summary>
        /// 数据树形被选择后(TOP)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterSelect_Top(object sender, TreeViewEventArgs e)
        {
            InitControlsEnable();
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            if (trvData.DatatreeView.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                if (!mDataViewInfo.IsReadOnly)
                {
                    if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) && !SystemManager.GetCurrentCollection().IsCapped())
                    {
                        //普通数据
                        //在顶层的时候，允许添加元素,不允许删除元素和修改元素(删除选中记录)
                        DelSelectRecordToolStripMenuItem.Enabled = true;
                        DelSelectRecordToolStripButton.Enabled = true;
                        AddElementToolStripMenuItem.Enabled = true;
                        if (MongoDBHelper.CanPasteAsElement)
                        {
                            PasteElementToolStripMenuItem.Enabled = true;
                            PasteElementStripButton.Enabled = true;
                        }
                    }
                    else
                    {
                        DelSelectRecordToolStripMenuItem.Enabled = false;
                        DelSelectRecordToolStripButton.Enabled = false;
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
                    if (!MongoDBHelper.IsSystemCollection(SystemManager.GetCurrentCollection()) &&
                        !mDataViewInfo.IsReadOnly &&
                        !SystemManager.GetCurrentCollection().IsCapped())
                    {
                        //普通数据:允许添加元素,不允许删除元素
                        DropElementToolStripMenuItem.Enabled = true;
                        CopyElementToolStripMenuItem.Enabled = true;
                        CopyElementStripButton.Enabled = true;
                        CutElementToolStripMenuItem.Enabled = true;
                        CutElementStripButton.Enabled = true;
                        if (trvData.DatatreeView.SelectedNode.Nodes.Count != 0)
                        {
                            //父节点
                            //1. 以Array_Mark结尾的数组
                            //2. Document
                            if (trvData.DatatreeView.SelectedNode.FullPath.EndsWith(MongoDBHelper.Array_Mark))
                            {
                                //列表的父节点
                                if (MongoDBHelper.CanPasteAsValue)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                    PasteElementStripButton.Enabled = true;
                                }
                            }
                            else
                            {
                                //文档的父节点
                                if (MongoDBHelper.CanPasteAsElement)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                    PasteElementStripButton.Enabled = true;
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
                            if (trvData.DatatreeView.SelectedNode.Tag is BsonElement)
                            {
                                //子节点是一个元素，获得子节点的Value
                                t = ((BsonElement)trvData.DatatreeView.SelectedNode.Tag).Value;
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
                                            PasteElementStripButton.Enabled = true;
                                        }

                                    }
                                    if (t.IsBsonArray)
                                    {
                                        //3.Array
                                        if (MongoDBHelper.CanPasteAsValue)
                                        {
                                            PasteElementToolStripMenuItem.Enabled = true;
                                            PasteElementStripButton.Enabled = true;
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
                                t = (BsonValue)trvData.DatatreeView.SelectedNode.Tag;
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
        /// <summary>
        /// 是否需要改变选中节点
        /// </summary>
        private Boolean IsNeedChangeNode = true;
        /// <summary>
        /// 展开节点后的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvData_AfterExpand(object sender, TreeViewEventArgs e)
        {
            trvData.DatatreeView.SelectedNode = e.Node;
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
            trvData.DatatreeView.SelectedNode = e.Node;
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
                trvData.DatatreeView.SelectedNode = this.trvData.DatatreeView.GetNodeAt(e.Location);
            }
            IsNeedChangeNode = true;
            if (trvData.DatatreeView.SelectedNode == null)
            {
                return;
            }
            SystemManager.SetCurrentDocument(trvData.DatatreeView.SelectedNode);
            if (trvData.DatatreeView.SelectedNode.Level == 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    ///允许删除
                    DelSelectRecordToolStripMenuItem.Enabled = true;
                    this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolStripMenuItem.Clone());
                    ///允许添加
                    AddElementToolStripMenuItem.Enabled = true;
                    this.contextMenuStripMain.Items.Add(this.AddElementToolStripMenuItem.Clone());
                    ///允许粘贴
                    PasteElementToolStripMenuItem.Enabled = true;
                    this.contextMenuStripMain.Items.Add(this.PasteElementToolStripMenuItem.Clone());
                    trvData.DatatreeView.ContextMenuStrip = this.contextMenuStripMain;
                    contextMenuStripMain.Show(trvData.DatatreeView.PointToScreen(e.Location));
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
                this.contextMenuStripMain.Items.Add(this.AddElementToolStripMenuItem.Clone());
                this.contextMenuStripMain.Items.Add(this.ModifyElementToolStripMenuItem.Clone());
                this.contextMenuStripMain.Items.Add(this.DropElementToolStripMenuItem.Clone());
                this.contextMenuStripMain.Items.Add(this.CopyElementToolStripMenuItem.Clone());
                this.contextMenuStripMain.Items.Add(this.CutElementToolStripMenuItem.Clone());
                this.contextMenuStripMain.Items.Add(this.PasteElementToolStripMenuItem.Clone());
                trvData.DatatreeView.ContextMenuStrip = this.contextMenuStripMain;
                contextMenuStripMain.Show(trvData.DatatreeView.PointToScreen(e.Location));
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
                        //DelSelectedRecord_Click(sender, e);
                    }
                    else
                    {
                        if (this.DropElementToolStripMenuItem.Enabled)
                        {
                            DropElementToolStripMenuItem_Click(sender, e);
                        }
                    }
                    break;
                case Keys.F2:
                    if (this.ModifyElementToolStripMenuItem.Enabled)
                    {
                        ModifyElementToolStripMenuItem_Click(sender, e);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region"管理：元素操作"

        /// <summary>
        /// Add New Document
        /// </summary>
        private void NewDocumentStripButton_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmNewDocument());
            RefreshGUI(null, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDocInEditorDocStripButton_Click(object sender, EventArgs e)
        {
            MongoDBHelper.SaveAndOpenStringAsFile(txtData.Text);
        }
        /// <summary>
        /// Delete Selected Documents
        /// </summary>
        private void DelSelectRecordToolStripButton_Click(object sender, EventArgs e)
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
                String StrErrormsg = String.Empty;
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        if (item.Tag != null && ((BsonValue)item.Tag).IsObjectId)
                        {
                            if (!MongoDBHelper.DropDocument(SystemManager.GetCurrentCollection(), item.Tag))
                            {
                                StrErrormsg = "Delete Error Key is:" + item.Tag.ToString();
                                MyMessageBox.ShowMessage("Delete Error", StrErrormsg);
                                break;
                            }
                        };
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    if (trvData.DatatreeView.SelectedNode.Tag != null && ((BsonValue)trvData.DatatreeView.SelectedNode.Tag).IsObjectId)
                    {
                        if (!MongoDBHelper.DropDocument(SystemManager.GetCurrentCollection(), trvData.DatatreeView.SelectedNode.Tag))
                        {
                            StrErrormsg = "Delete Error Key is:" + trvData.DatatreeView.SelectedNode.Tag.ToString();
                            MyMessageBox.ShowMessage("Delete Error", StrErrormsg);
                        }
                    }
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                DelSelectRecordToolStripMenuItem.Enabled = false;
                RefreshGUI(null, null);
            }
        }
        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean IsElement = true;
            BsonValue t;
            if (trvData.DatatreeView.SelectedNode.Tag is BsonElement)
            {
                t = ((BsonElement)trvData.DatatreeView.SelectedNode.Tag).Value;
            }
            else
            {
                t = (BsonValue)trvData.DatatreeView.SelectedNode.Tag;
            }
            if (t.IsBsonArray)
            {
                IsElement = false;
            }
            SystemManager.OpenForm(new frmElement(false, trvData.DatatreeView.SelectedNode, IsElement));
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.DatatreeView.SelectedNode.Level == 1 & trvData.DatatreeView.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id Can't be delete");
                return;
            }
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.DropArrayValue(trvData.DatatreeView.SelectedNode.FullPath, trvData.DatatreeView.SelectedNode.Index);
            }
            else
            {
                MongoDBHelper.DropElement(trvData.DatatreeView.SelectedNode.FullPath, (BsonElement)trvData.DatatreeView.SelectedNode.Tag);
            }
            trvData.DatatreeView.Nodes.Remove(trvData.DatatreeView.SelectedNode);
            IsNeedRefresh = true;
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.DatatreeView.SelectedNode.Level == 1 & trvData.DatatreeView.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id can't be modify");
                return;
            }
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                SystemManager.OpenForm(new frmElement(true, trvData.DatatreeView.SelectedNode, false));
            }
            else
            {
                SystemManager.OpenForm(new frmElement(true, trvData.DatatreeView.SelectedNode, true));
            }
            IsNeedRefresh = true;
        }
        /// <summary>
        /// Copy Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MongoDBHelper._ClipElement = trvData.DatatreeView.SelectedNode.Tag;
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.CopyValue((BsonValue)trvData.DatatreeView.SelectedNode.Tag);
            }
            else
            {
                MongoDBHelper.CopyElement((BsonElement)trvData.DatatreeView.SelectedNode.Tag);
            }
        }
        /// <summary>
        /// Paste Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.DatatreeView.SelectedNode.FullPath.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.PasteValue(trvData.DatatreeView.SelectedNode.FullPath);
                TreeNode NewValue = new TreeNode(MongoDBHelper.ConvertToString((BsonValue)MongoDBHelper._ClipElement));
                NewValue.Tag = MongoDBHelper._ClipElement;
                trvData.DatatreeView.SelectedNode.Nodes.Add(NewValue);
            }
            else
            {
                String PasteMessage = MongoDBHelper.PasteElement(trvData.DatatreeView.SelectedNode.FullPath);
                if (String.IsNullOrEmpty(PasteMessage))
                {
                    //GetCurrentDocument()的第一个元素是ID
                    MongoDBHelper.AddBsonDocToTreeNode(trvData.DatatreeView.SelectedNode,
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
        private void CutElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.DatatreeView.SelectedNode.Level == 1 & trvData.DatatreeView.SelectedNode.PrevNode == null)
            {
                MyMessageBox.ShowMessage("Error", "_id can't be cut");
                return;
            }
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(MongoDBHelper.Array_Mark))
            {
                MongoDBHelper.CutValue(trvData.DatatreeView.SelectedNode.FullPath, trvData.DatatreeView.SelectedNode.Index, (BsonValue)trvData.DatatreeView.SelectedNode.Tag);
            }
            else
            {
                MongoDBHelper.CutElement(trvData.DatatreeView.SelectedNode.FullPath, (BsonElement)trvData.DatatreeView.SelectedNode.Tag);
            }
            trvData.DatatreeView.Nodes.Remove(trvData.DatatreeView.SelectedNode);
            IsNeedRefresh = true;
        }
        #endregion

        #region"数据导航"
        /// <summary>
        /// 换页操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbRecPerPage_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (cmbRecPerPage.SelectedIndex)
            {
                case 0:
                    mDataViewInfo.LimitCnt = 50;
                    break;
                case 1:
                    mDataViewInfo.LimitCnt = 100;
                    break;
                case 2:
                    mDataViewInfo.LimitCnt = 200;
                    break;
                default:
                    mDataViewInfo.LimitCnt = 100;
                    break;
            }
            ReloadData();
        }
        /// <summary>
        /// 指定起始位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoStripButton_Click(object sender, EventArgs e)
        {
            if (txtSkip.Text.IsNumeric())
            {
                int skip = Convert.ToInt32(txtSkip.Text);
                skip--;
                if (skip >= 0)
                {
                    if (mDataViewInfo.CurrentCollectionTotalCnt <= skip)
                    {
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt - 1;
                        if (mDataViewInfo.SkipCnt == -1)
                        {
                            ///CurrentCollectionTotalCnt可能为0
                            mDataViewInfo.SkipCnt = 0;
                        }
                    }
                    else
                    {
                        mDataViewInfo.SkipCnt = skip;
                    }
                    ReloadData();
                }
            }
            else
            {
                txtSkip.Text = string.Empty;
            }
        }
        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.FirstPage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrePage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.PrePage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.NextPage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 最后页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.LastPage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 展开所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAll_Click(object sender, EventArgs e)
        {
            trvData.DatatreeView.ExpandAll();
        }
        /// <summary>
        /// 折叠所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAll_Click(object sender, EventArgs e)
        {
            trvData.DatatreeView.CollapseAll();
        }
        /// <summary>
        /// 清除所有数据
        /// </summary>
        private void clear()
        {
            lstData.Clear();
            txtData.Text = String.Empty;
            trvData.DatatreeView.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.DatatreeView.ContextMenuStrip = null;
        }

        /// <summary>
        /// 设置导航可用性
        /// </summary>
        private void SetDataNav()
        {

            PrePageStripButton.Enabled = mDataViewInfo.HasPrePage;
            NextPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            FirstPageStripButton.Enabled = mDataViewInfo.HasPrePage;
            LastPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            this.QueryStripButton.Enabled = true;
            String strTitle = "Records";
            if (!SystemManager.IsUseDefaultLanguage())
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            }
            if (mDataViewInfo.CurrentCollectionTotalCnt == 0)
            {
                this.DataNaviToolStripLabel.Text = strTitle + "：0/0";
            }
            else
            {
                this.DataNaviToolStripLabel.Text = strTitle + "：" + (mDataViewInfo.SkipCnt + 1).ToString() + "/" + mDataViewInfo.CurrentCollectionTotalCnt.ToString();
            }
            txtSkip.Text = (mDataViewInfo.SkipCnt + 1).ToString();
        }
        /// <summary>
        /// Refresh Data
        /// </summary>
        public void RefreshGUI(object sender, EventArgs e)
        {
            this.clear();
            mDataViewInfo.SkipCnt = 0;
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            List<BsonDocument> datalist = MongoDBHelper.GetDataList(ref mDataViewInfo);
            MongoDBHelper.FillDataToControl(datalist, _dataShower, mDataViewInfo);
            InitControlsEnable();
            SetDataNav();
            if (mDataViewInfo.Query != String.Empty)
            {
                txtQuery.Text = mDataViewInfo.Query;
                if (!tabDataShower.TabPages.Contains(tabQuery))
                {
                    tabDataShower.TabPages.Add(tabQuery);
                }
            }
            else
            {
                if (tabDataShower.TabPages.Contains(tabQuery))
                {
                    tabDataShower.TabPages.Remove(tabQuery);
                }
            }
            IsNeedRefresh = false;
        }
        private void ReloadData()
        {
            if (mDataViewInfo == null) { return; }
            this.clear();
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            List<BsonDocument> datalist = MongoDBHelper.GetDataList(ref mDataViewInfo);
            MongoDBHelper.FillDataToControl(datalist, _dataShower, mDataViewInfo);
            SetDataNav();
            IsNeedRefresh = false;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryStripButton_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmQuery(mDataViewInfo));
            this.FilterStripButton.Enabled = mDataViewInfo.IsUseFilter;
            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            //重新展示数据
            RefreshGUI(sender, e);
        }
        /// <summary>
        /// 过滤器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterStripButton_Click(object sender, EventArgs e)
        {
            mDataViewInfo.IsUseFilter = !mDataViewInfo.IsUseFilter;
            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            //过滤变更后，重新刷新
            RefreshGUI(sender, e);
        }
        #endregion

    }
}
