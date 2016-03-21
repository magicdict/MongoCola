using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Common;
using MongoDB.Bson;
using MongoUtility.Basic;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace MongoGUICtl
{
    /// <summary>
    ///     BsonDoc 展示控件
    /// </summary>
    public partial class CtlTreeViewColumns : UserControl
    {
        /// <summary>
        ///     展示文档
        /// </summary>
        public List<BsonDocument> ContentData = null;

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="GUIConfig">UIPackage</param>
        public CtlTreeViewColumns()
        {
            InitializeComponent();
            BackColor = VisualStyleInformation.TextControlBorder;
            Padding = new Padding(1);
        }

        /// <summary>
        ///     是否实用UTC表示时间
        /// </summary>
        public static bool IsUtc { get; set; }

        /// <summary>
        ///     是否使用千，百万系统表示数字
        /// </summary>
        public static bool IsDisplayNumberWithKSystem { get; set; }


        [Description("TreeView associated with the control"), Category("Behavior")]
        public TreeView TreeView
        {
            get { return DatatreeView; }
        }

        [Description("Columns associated with the control"), Category("Behavior")]
        public ListView.ColumnHeaderCollection Columns
        {
            get { return listView.Columns; }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            DatatreeView.Focus();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_Click(object sender, EventArgs e)
        {
            var p = DatatreeView.PointToClient(MousePosition);
            var mTreeNode = DatatreeView.GetNodeAt(p);
            if (mTreeNode != null)
                DatatreeView.SelectedNode = mTreeNode;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            DatatreeView.Focus();
            DatatreeView.Invalidate();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            DatatreeView.Focus();
            DatatreeView.Invalidate();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = false;
            var rect = e.Bounds;
            if (rect.Height == 0)
            {
                //在展开节点的时候会出现根节点绘制错误的问题
                return;
            }
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(
                    (e.State & TreeNodeStates.Focused) != 0 ? SystemBrushes.Highlight : SystemBrushes.Control, rect);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, rect);
            }
            var indentWidth = DatatreeView.Indent*e.Node.Level + 25;
            e.Graphics.DrawRectangle(SystemPens.Control, rect);
            var stringRect = new Rectangle(e.Bounds.X + indentWidth, e.Bounds.Y, colName.Width - indentWidth,
                e.Bounds.Height);

            var treeNameString = e.Node.Text;
            if (treeNameString.EndsWith(ConstMgr.ArrayMark))
            {
                //Array_Mark 在计算路径的时候使用，不过，在表示的时候，则不能表示
                treeNameString = treeNameString.Substring(0, treeNameString.Length - ConstMgr.ArrayMark.Length);
            }
            if (treeNameString.EndsWith(ConstMgr.DocumentMark))
            {
                //Document_Mark 在计算路径的时候使用，不过，在表示的时候，则不能表示
                treeNameString = treeNameString.Substring(0, treeNameString.Length - ConstMgr.DocumentMark.Length);
            }
            //感谢cyrus的建议，选中节点的文字表示，底色变更
            if ((e.State & TreeNodeStates.Selected) != 0 && (e.State & TreeNodeStates.Focused) != 0)
            {
                e.Graphics.DrawString(treeNameString, Font, new SolidBrush(SystemColors.HighlightText), stringRect);
            }
            else
            {
                e.Graphics.DrawString(treeNameString, Font, new SolidBrush(Color.Black), stringRect);
            }
            //CSHARP-1066: Change BsonElement from a class to a struct. 
            var mElement = new BsonElement();
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag.GetType() != typeof (BsonElement))
                {
                    mElement = new BsonElement("", (BsonValue) e.Node.Tag);
                }
                else
                {
                    mElement = (BsonElement) e.Node.Tag;
                }
            }
            var mValue = e.Node.Tag as BsonValue;
            //画框
            if (e.Node.GetNodeCount(true) > 0 ||
                (mElement.Value != null && (mElement.Value.IsBsonDocument || mElement.Value.IsBsonArray)))
            {
                //感谢Cyrus测试出来的问题：RenderWithVisualStyles应该加上去的。
                if (VisualStyleRenderer.IsSupported && Application.RenderWithVisualStyles)
                {
                    var leftPoint = e.Bounds.X + indentWidth - 20;
                    //感谢 Shadower http://home.cnblogs.com/u/14697/ 贡献的代码
                    var thisNode = e.Node;
                    var glyph = thisNode.IsExpanded
                        ? VisualStyleElement.TreeView.Glyph.Opened
                        : VisualStyleElement.TreeView.Glyph.Closed;
                    var vsr = new VisualStyleRenderer(glyph);
                    vsr.DrawBackground(e.Graphics, new Rectangle(leftPoint, e.Bounds.Y + 4, 16, 16));
                }
                else
                {
                    var leftPoint = e.Bounds.X + indentWidth - 20;
                    e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(leftPoint, e.Bounds.Y + 4, 12, 12));
                    var leftMid = new Point(leftPoint + 2, e.Bounds.Y + 10);
                    var rightMid = new Point(leftPoint + 10, e.Bounds.Y + 10);
                    var topMid = new Point(leftPoint + 6, e.Bounds.Y + 6);
                    var bottomMid = new Point(leftPoint + 6, e.Bounds.Y + 14);
                    e.Graphics.DrawLine(new Pen(Color.Black), leftMid, rightMid);
                    if (!e.Node.IsExpanded)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), topMid, bottomMid);
                    }
                }
            }

            for (var intColumn = 1; intColumn < 3; intColumn++)
            {
                rect.Offset(listView.Columns[intColumn - 1].Width, 0);
                rect.Width = listView.Columns[intColumn].Width;
                e.Graphics.DrawRectangle(SystemPens.Control, rect);
                if (mElement.Value != null || mValue != null)
                {
                    var strColumnText = string.Empty;
                    if (intColumn == 1)
                    {
                        if (mElement.Value != null)
                        {
                            if (!mElement.Value.IsBsonDocument && !mElement.Value.IsBsonArray)
                            {
                                strColumnText = GetDisplayString(ref mElement);
                            }
                        }
                        else
                        {
                            if (mValue != null)
                            {
                                //Type这里已经有表示Type的标识了，这里就不重复显示了。
                                if (!mValue.IsBsonDocument && !mValue.IsBsonArray)
                                {
                                    if (e.Node.Level > 0)
                                    {
                                        //根节点有Value，可能是ID，用来取得选中节点的信息
                                        strColumnText = GetDisplayString(ref mElement);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        strColumnText = mElement.Value != null
                            ? mElement.Value.GetType().Name.Substring(4)
                            : mValue.GetType().Name.Substring(4);
                    }

                    var flags = TextFormatFlags.EndEllipsis;
                    switch (listView.Columns[intColumn].TextAlign)
                    {
                        case HorizontalAlignment.Center:
                            flags |= TextFormatFlags.HorizontalCenter;
                            break;
                        case HorizontalAlignment.Left:
                            flags |= TextFormatFlags.Left;
                            break;
                        case HorizontalAlignment.Right:
                            flags |= TextFormatFlags.Right;
                            break;
                        default:
                            break;
                    }

                    rect.Y++;
                    if ((e.State & TreeNodeStates.Selected) != 0 &&
                        (e.State & TreeNodeStates.Focused) != 0)
                        TextRenderer.DrawText(e.Graphics, strColumnText, e.Node.NodeFont, rect,
                            SystemColors.HighlightText, flags);
                    else
                        TextRenderer.DrawText(e.Graphics, strColumnText, e.Node.NodeFont, rect, e.Node.ForeColor,
                            e.Node.BackColor, flags);
                    rect.Y--;
                }
            }
        }

        /// <summary>
        ///     获得值的表示文字
        /// </summary>
        /// <param name="mElement"></param>
        /// <returns></returns>
        private static string GetDisplayString(ref BsonElement mElement)
        {
            string strColumnText;
            try
            {
                strColumnText = mElement.Value.ToString();
                //日期型处理
                if (mElement.Value.IsValidDateTime)
                {
                    if (IsUtc)
                    {
                        strColumnText = mElement.Value.AsBsonDateTime.ToUniversalTime().ToString();
                    }
                    else
                    {
                        strColumnText = mElement.Value.AsBsonDateTime.ToLocalTime().ToString();
                    }
                    return strColumnText;
                }
                //数字型处理
                if (mElement.Value.IsNumeric)
                {
                    if (IsDisplayNumberWithKSystem)
                    {
                        if (mElement.Value.IsInt32)
                        {
                            strColumnText = Utility.GetKSystemInt32(mElement.Value.AsInt32);
                        }
                        if (mElement.Value.IsInt64)
                        {
                            strColumnText = Utility.GetKSystemInt64(mElement.Value.AsInt64);
                        }
                        if (mElement.Value.IsDouble)
                        {
                            strColumnText = Utility.GetKSystemDouble(mElement.Value.AsDouble);
                        }
                    }
                    else
                    {
                        strColumnText = mElement.Value.ToString();
                    }
                    return strColumnText;
                }
            }
            catch (Exception)
            {
                strColumnText = mElement.Value.ToString();
            }
            return strColumnText;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_SizeChanged(object sender, EventArgs e)
        {
            colName.Width = Convert.ToInt32(Width*0.3);
            colValue.Width = Convert.ToInt32(Width*0.45);
            colType.Width = Convert.ToInt32(Width*0.2);
        }

        private void CtlTreeViewColumnsLoad(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                colName.Text = GuiConfig.GetText(TextType.CommonName);
                colValue.Text = GuiConfig.GetText(TextType.CommonValue);
                colType.Text = GuiConfig.GetText(TextType.CommonType);
            }
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            var writer = new StreamWriter(fileName, false);
            writer.Write(ContentData.ToJson(MongoHelper.JsonWriterSettings));
            writer.Close();
        }
    }
}