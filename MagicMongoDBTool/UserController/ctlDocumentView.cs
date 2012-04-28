using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class ctlDocumentView : UserController.ctlDataView
    {
        public ctlDocumentView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            mDataViewInfo = _DataViewInfo;
            this.cmbListViewStyle.Visible = false;
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
        private void ctlDocumentView_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.NewDocumentToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_AddDocument);
                this.DelSelectRecordToolToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataCollection_DropDocument);

                this.AddElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_AddElement);
                this.DropElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_DropElement);
                this.ModifyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_ModifyElement);

                this.NewDocumentStripButton.Text = this.NewDocumentToolStripMenuItem.Text;
                this.OpenDocInEditorStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_OpenInNativeEditor);
                this.DelSelectRecordToolStripButton.Text = this.DelSelectRecordToolToolStripMenuItem.Text;
                this.CopyElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CopyElement);
                this.CopyElementStripButton.Text = this.CopyElementToolStripMenuItem.Text;
                this.CutElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_CutElement);
                this.CutElementStripButton.Text = this.CutElementToolStripMenuItem.Text;
                this.PasteElementToolStripMenuItem.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_DataDocument_PasteElement);
                this.PasteElementStripButton.Text = this.PasteElementToolStripMenuItem.Text;
            }

            CutElementStripButton.Click += new EventHandler(CutElementToolStripMenuItem_Click);
            CopyElementStripButton.Click += new EventHandler(CopyElementToolStripMenuItem_Click);
            PasteElementStripButton.Click += new EventHandler(PasteElementToolStripMenuItem_Click);
            OpenDocInEditorStripButton.Enabled = true;
            OpenDocInEditorToolStripMenuItem.Enabled = true;
            if (!mDataViewInfo.IsReadOnly)
            {
                this.NewDocumentStripButton.Enabled = true;
                this.NewDocumentToolStripMenuItem.Enabled = true;
            }
            
            this.trvData.DatatreeView.MouseClick += new MouseEventHandler(trvData_MouseClick_Top);
            this.trvData.DatatreeView.AfterSelect += new TreeViewEventHandler(trvData_AfterSelect_Top);
            this.trvData.DatatreeView.KeyDown += new KeyEventHandler(trvData_KeyDown);
            this.trvData.DatatreeView.AfterExpand += new TreeViewEventHandler(trvData_AfterExpand);
            this.trvData.DatatreeView.AfterCollapse += new TreeViewEventHandler(trvData_AfterCollapse);

            NewDocumentToolStripMenuItem.Click += new EventHandler(NewDocumentStripButton_Click);
            OpenDocInEditorToolStripMenuItem.Click += new EventHandler(OpenDocInEditorDocStripButton_Click);
            DelSelectRecordToolToolStripMenuItem.Click += new EventHandler(DelSelectRecordToolStripButton_Click);
            this.lstData.MouseClick += new MouseEventHandler(lstData_MouseClick);
            this.lstData.MouseDoubleClick += new MouseEventHandler(lstData_MouseDoubleClick);
            this.tabDataShower.SelectedIndexChanged += new EventHandler(
            //If tabpage changed,the selected data in dataview will disappear,set delete selected record to false
                (x, y) =>
                {
                    this.DelSelectRecordToolToolStripMenuItem.Enabled = false;
                    if (IsNeedRefresh)
                    {
                        RefreshGUI();
                    }
                }
            );
        }

        #region"数据展示区操作"

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
                    DelSelectRecordToolToolStripMenuItem.Enabled = true;
                    this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolToolStripMenuItem.Clone());
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
        /// 键盘动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void trvData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (DelSelectRecordToolToolStripMenuItem.Enabled)
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
        ///// <summary>
        ///// 数据树形被选择后(非TOP)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void trvData_AfterSelect_NotTop(object sender, TreeViewEventArgs e)
        {
            //非顶层可以删除的节点
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
        }

        ///// <summary>
        ///// 数据树形被选择后(TOP)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void trvData_AfterSelect_Top(object sender, TreeViewEventArgs e)
        {
            //InitControlsEnable();
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
                        DelSelectRecordToolToolStripMenuItem.Enabled = true;
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
                        DelSelectRecordToolToolStripMenuItem.Enabled = false;
                        //DelSelectRecordToolStripButton.Enabled = false;
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
        /// 双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDocInEditorDocStripButton_Click(sender, e);
        }
        /// <summary>
        /// 数据列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Items.Add(this.NewDocumentToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.OpenDocInEditorToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.DelSelectRecordToolToolStripMenuItem.Clone());
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }
        //<summary>
        //数据列表选中索引变换
        //</summary>
        //<param name="sender"></param>
        //<param name="e"></param>
        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstData.SelectedItems.Count > 0 && !IsSystemCollection && !mDataViewInfo.IsReadOnly)
            {
                DelSelectRecordToolToolStripMenuItem.Enabled = true;
                DelSelectRecordToolStripButton.Enabled = true;
            }
            else
            {
                DelSelectRecordToolStripButton.Enabled = false;
                DelSelectRecordToolToolStripMenuItem.Enabled = false;
            }
            if (this.lstData.SelectedItems.Count == 1)
            {
                OpenDocInEditorStripButton.Enabled = true;
                OpenDocInEditorToolStripMenuItem.Enabled = true;
            }

        }
        #region"管理：元素操作"

        /// <summary>
        /// Add New Document
        /// </summary>
        private void NewDocumentStripButton_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmNewDocument());
            RefreshGUI();

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
            if (!SystemManager.IsUseDefaultLanguage)
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
                DelSelectRecordToolToolStripMenuItem.Enabled = false;
                RefreshGUI();
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


    }
}
