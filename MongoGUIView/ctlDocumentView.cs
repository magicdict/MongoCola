using System;
using System.Windows.Forms;
using Common.Logic;
using Common.UI;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;

namespace MongoGUIView
{
    public partial class ctlDocumentView : ctlDataView
    {

        #region"UI"
        public ctlDocumentView(DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            mDataViewInfo = _DataViewInfo;
            _dataShower.Add(lstData);
            _dataShower.Add(txtData);
            _dataShower.Add(trvData);
        }

        /// <summary>
        ///     增加或者删除元素
        ///     参数frmElement
        /// </summary>
        public Action<bool, TreeNode, bool> ElementOp = new Action<bool, TreeNode, bool>(
            (isUpdate, SelectedNode, isElement) =>
            {
                frmElement f = new frmElement(isUpdate, SelectedNode, isElement);
                f.ShowDialog();
            }
        );
        private void ctlDocumentView_Load(object sender, EventArgs e)
        {
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                NewDocumentToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataCollection_AddDocument);
                DelSelectRecordToolToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataCollection_DropDocument);

                AddElementToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_AddElement);
                DropElementToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_DropElement);
                ModifyElementToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_ModifyElement);

                NewDocumentStripButton.Text = NewDocumentToolStripMenuItem.Text;
                OpenDocInEditorStripButton.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_OpenInNativeEditor);
                DelSelectRecordToolStripButton.Text = DelSelectRecordToolToolStripMenuItem.Text;
                CopyElementToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_CopyElement);
                CopyElementStripButton.Text = CopyElementToolStripMenuItem.Text;
                CutElementToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_CutElement);
                CutElementStripButton.Text = CutElementToolStripMenuItem.Text;
                PasteElementToolStripMenuItem.Text =
                    configuration.guiConfig.MStringResource.GetText(
                        StringResource.TextType.Main_Menu_Operation_DataDocument_PasteElement);
                PasteElementStripButton.Text = PasteElementToolStripMenuItem.Text;
            }

            CutElementStripButton.Click += CutElementToolStripMenuItem_Click;
            CopyElementStripButton.Click += CopyElementToolStripMenuItem_Click;
            PasteElementStripButton.Click += PasteElementToolStripMenuItem_Click;
            OpenDocInEditorStripButton.Enabled = true;
            OpenDocInEditorToolStripMenuItem.Enabled = true;
            if (!mDataViewInfo.IsReadOnly)
            {
                NewDocumentStripButton.Enabled = true;
                NewDocumentToolStripMenuItem.Enabled = true;
            }

            trvData.DatatreeView.MouseClick += trvData_MouseClick_Top;
            trvData.DatatreeView.AfterSelect += trvData_AfterSelect_Top;
            trvData.DatatreeView.KeyDown += trvData_KeyDown;
            trvData.DatatreeView.AfterExpand += trvData_AfterExpand;
            trvData.DatatreeView.AfterCollapse += trvData_AfterCollapse;

            NewDocumentToolStripMenuItem.Click += NewDocumentStripButton_Click;
            OpenDocInEditorToolStripMenuItem.Click += OpenDocInEditorDocStripButton_Click;
            DelSelectRecordToolToolStripMenuItem.Click += DelSelectRecordToolStripButton_Click;
            lstData.MouseClick += lstData_MouseClick;
            lstData.MouseDoubleClick += lstData_MouseDoubleClick;
            tabDataShower.SelectedIndexChanged += (x, y) =>
            {
                DelSelectRecordToolToolStripMenuItem.Enabled = false;
                if (IsNeedRefresh)
                {
                    RefreshGUI();
                }
            };
        }

        ///// <summary>
        ///// 数据树形被选择后(非TOP)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void trvData_AfterSelect_NotTop(object sender, TreeViewEventArgs e)
        {
            //非顶层可以删除的节点
            if (!OperationHelper.IsSystemCollection(RuntimeMongoDBContext.GetCurrentCollection()) &&
                !mDataViewInfo.IsReadOnly &&
                !RuntimeMongoDBContext.GetCurrentCollection().IsCapped())
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
                    if (trvData.DatatreeView.SelectedNode.FullPath.EndsWith(ConstMgr.Array_Mark))
                    {
                        //列表的父节点
                        if (ElementHelper.CanPasteAsValue)
                        {
                            PasteElementToolStripMenuItem.Enabled = true;
                            PasteElementStripButton.Enabled = true;
                        }
                    }
                    else
                    {
                        //文档的父节点
                        if (ElementHelper.CanPasteAsElement)
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
                        t = ((BsonElement) trvData.DatatreeView.SelectedNode.Tag).Value;
                        if (t.IsBsonDocument || t.IsBsonArray)
                        {
                            //2.空的Array
                            //3.空的文档
                            ModifyElementToolStripMenuItem.Enabled = false;
                            AddElementToolStripMenuItem.Enabled = true;
                            if (t.IsBsonDocument)
                            {
                                //3.空的文档
                                if (ElementHelper.CanPasteAsElement)
                                {
                                    PasteElementToolStripMenuItem.Enabled = true;
                                    PasteElementStripButton.Enabled = true;
                                }
                            }
                            if (t.IsBsonArray)
                            {
                                //3.Array
                                if (ElementHelper.CanPasteAsValue)
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
                        t = (BsonValue) trvData.DatatreeView.SelectedNode.Tag;
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
            RuntimeMongoDBContext.SelectObjectTag = mDataViewInfo.strDBTag;
            if (trvData.DatatreeView.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                if (!mDataViewInfo.IsReadOnly)
                {
                    if (!OperationHelper.IsSystemCollection(RuntimeMongoDBContext.GetCurrentCollection()) &&
                        !RuntimeMongoDBContext.GetCurrentCollection().IsCapped())
                    {
                        //普通数据
                        //在顶层的时候，允许添加元素,不允许删除元素和修改元素(删除选中记录)
                        DelSelectRecordToolToolStripMenuItem.Enabled = true;
                        DelSelectRecordToolStripButton.Enabled = true;
                        AddElementToolStripMenuItem.Enabled = true;
                        if (ElementHelper.CanPasteAsElement)
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
        ///     双击列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDocInEditorDocStripButton_Click(sender, e);
        }

        /// <summary>
        ///     数据列表右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            RuntimeMongoDBContext.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStripMain = new ContextMenuStrip();
                    contextMenuStripMain.Items.Add(NewDocumentToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(OpenDocInEditorToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(DelSelectRecordToolToolStripMenuItem.Clone());
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
            if (lstData.SelectedItems.Count > 0 && !mDataViewInfo.IsSystemCollection && !mDataViewInfo.IsReadOnly)
            {
                DelSelectRecordToolToolStripMenuItem.Enabled = true;
                DelSelectRecordToolStripButton.Enabled = true;
            }
            else
            {
                DelSelectRecordToolStripButton.Enabled = false;
                DelSelectRecordToolToolStripMenuItem.Enabled = false;
            }
            if (lstData.SelectedItems.Count == 1)
            {
                OpenDocInEditorStripButton.Enabled = true;
                OpenDocInEditorToolStripMenuItem.Enabled = true;
            }
        }
        #endregion

        #region"管理：元素操作"

        private Func<BsonDocument> getDocument;

        /// <summary>
        ///     Add New Document
        /// </summary>
        private void NewDocumentStripButton_Click(object sender, EventArgs e)
        {
            //居然可以指定_id...
            //这样的话，可能出现同一个数据库里面两个相同的_id的记录
            //Init.SystemManager.GetCurrentCollection().Insert(newdoc, new SafeMode(true));
            var t = getDocument();
            if (t != null)
            {
                RuntimeMongoDBContext.GetCurrentCollection().Insert(t);
                RefreshGUI();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDocInEditorDocStripButton_Click(object sender, EventArgs e)
        {
            GFS.SaveAndOpenStringAsFile(txtData.Text);
        }

        /// <summary>
        ///     Delete Selected Documents
        /// </summary>
        private void DelSelectRecordToolStripButton_Click(object sender, EventArgs e)
        {
            var strTitle = "Delete Document";
            var strMessage = "Are you sure to delete selected document(s)?";
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                strTitle = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Data);
                strMessage = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Drop_Data_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                var StrErrormsg = String.Empty;
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        if (item.Tag != null && ((BsonValue) item.Tag).IsObjectId)
                        {
                            var Result = OperationHelper.DropDocument(RuntimeMongoDBContext.GetCurrentCollection(),
                                item.Tag);
                            if (!String.IsNullOrEmpty(Result))
                            {
                                StrErrormsg = "Delete Error Key is:" + item.Tag;
                                MyMessageBox.ShowMessage("Delete Error", StrErrormsg, Result, true);
                                break;
                            }
                        }
                        ;
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    if (trvData.DatatreeView.SelectedNode.Tag != null &&
                        ((BsonValue) trvData.DatatreeView.SelectedNode.Tag).IsObjectId)
                    {
                        var Result = OperationHelper.DropDocument(RuntimeMongoDBContext.GetCurrentCollection(),
                            trvData.DatatreeView.SelectedNode.Tag);
                        if (!String.IsNullOrEmpty(Result))
                        {
                            StrErrormsg = "Delete Error Key is:" + trvData.DatatreeView.SelectedNode.Tag;
                            MyMessageBox.ShowMessage("Delete Error", StrErrormsg, Result, true);
                        }
                    }
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                DelSelectRecordToolToolStripMenuItem.Enabled = false;
                RefreshGUI();
            }
        }

        /// <summary>
        ///     添加元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var IsElement = true;
            BsonValue t;
            if (trvData.DatatreeView.SelectedNode.Tag is BsonElement)
            {
                t = ((BsonElement) trvData.DatatreeView.SelectedNode.Tag).Value;
            }
            else
            {
                t = (BsonValue) trvData.DatatreeView.SelectedNode.Tag;
            }
            if (t.IsBsonArray)
            {
                IsElement = false;
            }
            ElementOp(false, trvData.DatatreeView.SelectedNode, IsElement);
            IsNeedRefresh = true;
        }

        /// <summary>
        ///     删除元素
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
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.Array_Mark))
            {
                ElementHelper.DropArrayValue(trvData.DatatreeView.SelectedNode.FullPath,
                    trvData.DatatreeView.SelectedNode.Index, null, null);
            }
            else
            {
                ElementHelper.DropElement(trvData.DatatreeView.SelectedNode.FullPath,
                    (BsonElement) trvData.DatatreeView.SelectedNode.Tag, null, null);
            }
            trvData.DatatreeView.Nodes.Remove(trvData.DatatreeView.SelectedNode);
            IsNeedRefresh = true;
        }

        /// <summary>
        ///     修改元素
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
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.Array_Mark))
            {
                ElementOp(true, trvData.DatatreeView.SelectedNode, false);
            }
            else
            {
                ElementOp(true, trvData.DatatreeView.SelectedNode, true);
            }
            ;
            IsNeedRefresh = true;
        }

        /// <summary>
        ///     Copy Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElementHelper._ClipElement = trvData.DatatreeView.SelectedNode.Tag;
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.Array_Mark))
            {
                ElementHelper.CopyValue((BsonValue) trvData.DatatreeView.SelectedNode.Tag);
            }
            else
            {
                ElementHelper.CopyElement((BsonElement) trvData.DatatreeView.SelectedNode.Tag);
            }
        }

        /// <summary>
        ///     Paste Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvData.DatatreeView.SelectedNode.FullPath.EndsWith(ConstMgr.Array_Mark))
            {
                ElementHelper.PasteValue(trvData.DatatreeView.SelectedNode.FullPath, null, null);
                var NewValue = new TreeNode(ViewHelper.ConvertToString((BsonValue) ElementHelper._ClipElement));
                NewValue.Tag = ElementHelper._ClipElement;
                trvData.DatatreeView.SelectedNode.Nodes.Add(NewValue);
            }
            else
            {
                var PasteMessage = ElementHelper.PasteElement(trvData.DatatreeView.SelectedNode.FullPath, null, null);
                if (String.IsNullOrEmpty(PasteMessage))
                {
                    //GetCurrentDocument()的第一个元素是ID
                    UIHelper.AddBsonDocToTreeNode(trvData.DatatreeView.SelectedNode,
                        new BsonDocument().Add((BsonElement) ElementHelper._ClipElement));
                }
                else
                {
                    MyMessageBox.ShowMessage("Exception", PasteMessage);
                }
            }
            IsNeedRefresh = true;
        }

        /// <summary>
        ///     Cut Element
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
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.Array_Mark))
            {
                ElementHelper.CutValue(trvData.DatatreeView.SelectedNode.FullPath,
                    trvData.DatatreeView.SelectedNode.Index, (BsonValue) trvData.DatatreeView.SelectedNode.Tag, null,
                    null);
            }
            else
            {
                ElementHelper.CutElement(trvData.DatatreeView.SelectedNode.FullPath,
                    (BsonElement) trvData.DatatreeView.SelectedNode.Tag, null, null);
            }
            trvData.DatatreeView.Nodes.Remove(trvData.DatatreeView.SelectedNode);
            IsNeedRefresh = true;
        }

        #endregion

        #region"数据展示区操作"

        /// <summary>
        ///     是否需要改变选中节点
        /// </summary>
        private Boolean IsNeedChangeNode = true;

        /// <summary>
        ///     鼠标动作（非顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_NotTop(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripMain = new ContextMenuStrip();
                contextMenuStripMain.Items.Add(AddElementToolStripMenuItem.Clone());
                contextMenuStripMain.Items.Add(ModifyElementToolStripMenuItem.Clone());
                contextMenuStripMain.Items.Add(DropElementToolStripMenuItem.Clone());
                contextMenuStripMain.Items.Add(CopyElementToolStripMenuItem.Clone());
                contextMenuStripMain.Items.Add(CutElementToolStripMenuItem.Clone());
                contextMenuStripMain.Items.Add(PasteElementToolStripMenuItem.Clone());
                trvData.DatatreeView.ContextMenuStrip = contextMenuStripMain;
                contextMenuStripMain.Show(trvData.DatatreeView.PointToScreen(e.Location));
            }
        }

        /// <summary>
        ///     获取树形的根
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static TreeNode FindRootNode(TreeNode node)
        {
            if (node.Parent != null)
                return FindRootNode(node.Parent);
            return node;
        }

        /// <summary>
        ///     Set Current Document
        /// </summary>
        /// <param name="currentNode"></param>
        private static void SetCurrentDocument(TreeNode currentNode, MongoCollection mongoCol)
        {
            var rootNode = FindRootNode(currentNode);
            //TODO:rootNode.Tag == null ???
            if (rootNode.Tag == null) return;
            var selectDocId = (BsonValue) rootNode.Tag;
            var doc = mongoCol.FindOneAs<BsonDocument>(Query.EQ(ConstMgr.KEY_ID, selectDocId));
            RuntimeMongoDBContext.CurrentDocument = doc;
        }

        /// <summary>
        ///     展开节点后的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterExpand(object sender, TreeViewEventArgs e)
        {
            trvData.DatatreeView.SelectedNode = e.Node;
            IsNeedChangeNode = false;
            SetCurrentDocument(e.Node, RuntimeMongoDBContext.GetCurrentCollection());
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            trvData.DatatreeView.SelectedNode = e.Node;
            IsNeedChangeNode = false;
            SetCurrentDocument(e.Node, RuntimeMongoDBContext.GetCurrentCollection());
        }

        /// <summary>
        ///     鼠标动作（顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_Top(object sender, MouseEventArgs e)
        {
            if (IsNeedChangeNode)
            {
                //在节点展开和关闭后，不能使用这个方法来重新设定SelectedNode
                trvData.DatatreeView.SelectedNode = trvData.DatatreeView.GetNodeAt(e.Location);
            }
            IsNeedChangeNode = true;
            if (trvData.DatatreeView.SelectedNode == null)
            {
                return;
            }
            SetCurrentDocument(trvData.DatatreeView.SelectedNode, RuntimeMongoDBContext.GetCurrentCollection());
            if (trvData.DatatreeView.SelectedNode.Level == 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStripMain = new ContextMenuStrip();
                    //允许删除
                    DelSelectRecordToolToolStripMenuItem.Enabled = true;
                    contextMenuStripMain.Items.Add(DelSelectRecordToolToolStripMenuItem.Clone());
                    //允许添加
                    AddElementToolStripMenuItem.Enabled = true;
                    contextMenuStripMain.Items.Add(AddElementToolStripMenuItem.Clone());
                    //允许粘贴
                    PasteElementToolStripMenuItem.Enabled = true;
                    contextMenuStripMain.Items.Add(PasteElementToolStripMenuItem.Clone());
                    trvData.DatatreeView.ContextMenuStrip = contextMenuStripMain;
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
        ///     键盘动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_KeyDown(object sender, KeyEventArgs e)
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
                        if (DropElementToolStripMenuItem.Enabled)
                        {
                            DropElementToolStripMenuItem_Click(sender, e);
                        }
                    }
                    break;
                case Keys.F2:
                    if (ModifyElementToolStripMenuItem.Enabled)
                    {
                        ModifyElementToolStripMenuItem_Click(sender, e);
                    }
                    break;
            }
        }

        #endregion
    }
}