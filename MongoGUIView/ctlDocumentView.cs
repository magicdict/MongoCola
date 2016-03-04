using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoGUICtl.ClientTree;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoGUIView
{
    public partial class CtlDocumentView : CtlDataView
    {
        #region"UI"

        public CtlDocumentView(DataViewInfo dataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            if (dataViewInfo == null) return;
            MDataViewInfo = dataViewInfo;
            DataShower.Add(lstData);
            DataShower.Add(txtData);
            DataShower.Add(trvData);
        }

        /// <summary>
        ///     增加或者删除元素
        ///     参数frmElement
        /// </summary>
        public Action<bool, TreeNode, bool> ElementOp = (isUpdate, selectedNode, isElement) =>
        {
            var f = new FrmElement(isUpdate, selectedNode, isElement);
            f.ShowDialog();
        };

        private void ctlDocumentView_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                //NewDocumentToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataCollection_AddDocument);
                //DelSelectRecordToolToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataCollection_DropDocument);

                //AddElementToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_AddElement);
                //DropElementToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_DropElement);
                //ModifyElementToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_ModifyElement);

                //NewDocumentStripButton.Text = NewDocumentToolStripMenuItem.Text;
                //OpenDocInEditorStripButton.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_OpenInNativeEditor);
                //DelSelectRecordToolStripButton.Text = DelSelectRecordToolToolStripMenuItem.Text;
                //CopyElementToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_CopyElement);
                //CopyElementStripButton.Text = CopyElementToolStripMenuItem.Text;
                //CutElementToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_CutElement);
                //CutElementStripButton.Text = CutElementToolStripMenuItem.Text;
                //PasteElementToolStripMenuItem.Text =
                //    GUIConfig.MStringResource.GetText(
                //        TextType.Main_Menu_Operation_DataDocument_PasteElement);
                PasteElementStripButton.Text = PasteElementToolStripMenuItem.Text;
            }

            CutElementStripButton.Click += CutElementToolStripMenuItem_Click;
            CopyElementStripButton.Click += CopyElementToolStripMenuItem_Click;
            PasteElementStripButton.Click += PasteElementToolStripMenuItem_Click;
            OpenDocInEditorStripButton.Enabled = true;
            OpenDocInEditorToolStripMenuItem.Enabled = true;
            if (!MDataViewInfo.IsReadOnly)
            {
                NewDocumentStripButton.Enabled = true;
                NewDocumentToolStripMenuItem.Enabled = true;
            }

            trvData.DatatreeView.MouseClick += trvData_MouseClick_Top;
            //Double Click Modify Element
            trvData.DatatreeView.MouseDoubleClick += ModifyElementToolStripMenuItem_Click;
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
                    RefreshGui();
                }
            };
        }

        ///// <summary>
        ///// 数据树形被选择后(非TOP)
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void trvData_AfterSelect_NotTop()
        {
            //非顶层可以删除的节点
            if (!Operater.IsSystemCollection(RuntimeMongoDbContext.GetCurrentCollection()) &&
                !MDataViewInfo.IsReadOnly &&
                !RuntimeMongoDbContext.GetCurrentCollection().IsCapped())
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
                    if (trvData.DatatreeView.SelectedNode.FullPath.EndsWith(ConstMgr.ArrayMark))
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
            RuntimeMongoDbContext.SelectObjectTag = MDataViewInfo.StrDbTag;
            if (trvData.DatatreeView.SelectedNode.Level == 0)
            {
                //顶层可以删除的节点
                if (!MDataViewInfo.IsReadOnly)
                {
                    if (!Operater.IsSystemCollection(RuntimeMongoDbContext.GetCurrentCollection()) &&
                        !RuntimeMongoDbContext.GetCurrentCollection().IsCapped())
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
                trvData_AfterSelect_NotTop();
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
            RuntimeMongoDbContext.SelectObjectTag = MDataViewInfo.StrDbTag;
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
            if (lstData.SelectedItems.Count > 0 && !MDataViewInfo.IsSystemCollection && !MDataViewInfo.IsReadOnly)
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

        public static Func<BsonDocument> _getDocument = null;

        /// <summary>
        ///     Add New Document
        /// </summary>
        private void NewDocumentStripButton_Click(object sender, EventArgs e)
        {
            //居然可以指定_id...
            //这样的话，可能出现同一个数据库里面两个相同的_id的记录
            //Init.SystemManager.GetCurrentCollection().Insert(newdoc, new SafeMode(true));
            var t = _getDocument();
            if (t != null)
            {
                RuntimeMongoDbContext.GetCurrentCollection().Insert(t);
                RefreshGui();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDocInEditorDocStripButton_Click(object sender, EventArgs e)
        {
            Gfs.SaveAndOpenStringAsFile(txtData.Text);
        }

        /// <summary>
        ///     Delete Selected Documents
        /// </summary>
        private void DelSelectRecordToolStripButton_Click(object sender, EventArgs e)
        {
            var strTitle = "Delete Document";
            var strMessage = "Are you sure to delete selected document(s)?";
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.DropData);
                strMessage = GuiConfig.GetText(TextType.DropDataConfirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                string strErrormsg;
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        //如果是自定义主键的情况下,这里IsObjectId就不可能成立
                        if (item.Tag != null)
                            //if (item.Tag != null && ((BsonValue) item.Tag).IsObjectId)
                        {
                            var result = Operater.DropDocument(RuntimeMongoDbContext.GetCurrentCollection(),
                                item.Tag.ToString());
                            if (!string.IsNullOrEmpty(result))
                            {
                                strErrormsg = "Delete Error Key is:" + item.Tag;
                                MyMessageBox.ShowMessage("Delete Error", strErrormsg, result, true);
                                break;
                            }
                        }
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    //如果是自定义主键的情况下,这里IsObjectId就不可能成立
                    if (trvData.DatatreeView.SelectedNode.Tag != null)
                        //if (trvData.DatatreeView.SelectedNode.Tag != null &&
                        //    ((BsonValue) trvData.DatatreeView.SelectedNode.Tag).IsObjectId)
                    {
                        var result = Operater.DropDocument(RuntimeMongoDbContext.GetCurrentCollection(),
                            trvData.DatatreeView.SelectedNode.Tag.ToString());
                        if (!string.IsNullOrEmpty(result))
                        {
                            strErrormsg = "Delete Error Key is:" + trvData.DatatreeView.SelectedNode.Tag;
                            MyMessageBox.ShowMessage("Delete Error", strErrormsg, result, true);
                        }
                    }
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                DelSelectRecordToolToolStripMenuItem.Enabled = false;
                RefreshGui();
            }
        }

        /// <summary>
        ///     添加元素
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isElement = true;
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
                isElement = false;
            }
            ElementOp(false, trvData.DatatreeView.SelectedNode, isElement);
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
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.ArrayMark))
            {
                ElementHelper.DropArrayValue(trvData.DatatreeView.SelectedNode.FullPath,
                    trvData.DatatreeView.SelectedNode.Index, RuntimeMongoDbContext.CurrentDocument,
                    RuntimeMongoDbContext.GetCurrentCollection());
            }
            else
            {
                ElementHelper.DropElement(trvData.DatatreeView.SelectedNode.FullPath,
                    (BsonElement) trvData.DatatreeView.SelectedNode.Tag, RuntimeMongoDbContext.CurrentDocument,
                    RuntimeMongoDbContext.GetCurrentCollection());
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
            if (trvData.DatatreeView.SelectedNode.Parent != null &&
                trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.ArrayMark))
            {
                ElementOp(true, trvData.DatatreeView.SelectedNode, false);
            }
            else
            {
                ElementOp(true, trvData.DatatreeView.SelectedNode, true);
            }
            IsNeedRefresh = true;
        }

        /// <summary>
        ///     Copy Element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElementHelper.ClipElement = trvData.DatatreeView.SelectedNode.Tag;
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.ArrayMark))
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
            if (trvData.DatatreeView.SelectedNode.FullPath.EndsWith(ConstMgr.ArrayMark))
            {
                ElementHelper.PasteValue(trvData.DatatreeView.SelectedNode.FullPath, null, null);
                var newValue = new TreeNode(ViewHelper.ConvertToString((BsonValue) ElementHelper.ClipElement));
                newValue.Tag = ElementHelper.ClipElement;
                trvData.DatatreeView.SelectedNode.Nodes.Add(newValue);
            }
            else
            {
                var pasteMessage = ElementHelper.PasteElement(trvData.DatatreeView.SelectedNode.FullPath, null, null);
                if (string.IsNullOrEmpty(pasteMessage))
                {
                    //GetCurrentDocument()的第一个元素是ID
                    UiHelper.AddBsonDocToTreeNode(trvData.DatatreeView.SelectedNode,
                        new BsonDocument().Add((BsonElement) ElementHelper.ClipElement));
                }
                else
                {
                    MyMessageBox.ShowMessage("Exception", pasteMessage);
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
            if (trvData.DatatreeView.SelectedNode.Parent.Text.EndsWith(ConstMgr.ArrayMark))
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
        private bool _isNeedChangeNode = true;

        /// <summary>
        ///     鼠标动作（非顶层）
        /// </summary>
        /// <param name="e"></param>
        private void trvData_MouseClick_NotTop(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
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

        /// <summary>
        ///     获取树形的根
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static TreeNode FindRootNode(TreeNode node)
        {
            return node.Parent != null ? FindRootNode(node.Parent) : node;
        }

        /// <summary>
        ///     Set Current Document
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="mongoCol"></param>
        private static void SetCurrentDocument(TreeNode currentNode, MongoCollection mongoCol)
        {
            var rootNode = FindRootNode(currentNode);
            //TODO:rootNode.Tag == null ???
            if (rootNode.Tag == null) return;
            var selectDocId = (BsonValue) rootNode.Tag;
            var doc = mongoCol.FindOneAs<BsonDocument>(Query.EQ(ConstMgr.KeyId, selectDocId));
            RuntimeMongoDbContext.CurrentDocument = doc;
        }

        /// <summary>
        ///     展开节点后的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterExpand(object sender, TreeViewEventArgs e)
        {
            trvData.DatatreeView.SelectedNode = e.Node;
            _isNeedChangeNode = false;
            SetCurrentDocument(e.Node, RuntimeMongoDbContext.GetCurrentCollection());
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            trvData.DatatreeView.SelectedNode = e.Node;
            _isNeedChangeNode = false;
            SetCurrentDocument(e.Node, RuntimeMongoDbContext.GetCurrentCollection());
        }

        /// <summary>
        ///     鼠标动作（顶层）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvData_MouseClick_Top(object sender, MouseEventArgs e)
        {
            if (_isNeedChangeNode)
            {
                //在节点展开和关闭后，不能使用这个方法来重新设定SelectedNode
                trvData.DatatreeView.SelectedNode = trvData.DatatreeView.GetNodeAt(e.Location);
            }
            _isNeedChangeNode = true;
            if (trvData.DatatreeView.SelectedNode == null)
            {
                return;
            }
            SetCurrentDocument(trvData.DatatreeView.SelectedNode, RuntimeMongoDbContext.GetCurrentCollection());
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
                trvData_MouseClick_NotTop(e);
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