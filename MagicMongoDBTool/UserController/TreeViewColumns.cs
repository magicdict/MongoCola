using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using MongoDB.Bson;
using MagicMongoDBTool.Module;

namespace TreeViewColumnsProject
{
    public partial class TreeViewColumns : UserControl
    {
        public TreeViewColumns()
        {
            InitializeComponent();

            this.BackColor = VisualStyleInformation.TextControlBorder;
            this.Padding = new Padding(1);
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.colName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Name);
                this.colValue.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Value);
                this.colType.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Type);
            }
        }

        [Description("TreeView associated with the control"), Category("Behavior")]
        public TreeView TreeView
        {
            get
            {
                return this.DatatreeView;
            }
        }

        [Description("Columns associated with the control"), Category("Behavior")]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return this.listView.Columns;
            }
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.DatatreeView.Focus();
        }

        private void treeView_Click(object sender, EventArgs e)
        {
            Point p = this.DatatreeView.PointToClient(Control.MousePosition);
            TreeNode mTreeNode = this.DatatreeView.GetNodeAt(p);
            if (mTreeNode != null)
                this.DatatreeView.SelectedNode = mTreeNode;
        }

        private void listView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            this.DatatreeView.Focus();
            this.DatatreeView.Invalidate();
        }

        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            this.DatatreeView.Focus();
            this.DatatreeView.Invalidate();
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = false;
            Rectangle rect = e.Bounds;
            if (rect.Height == 0)
            {
                ///在展开节点的时候会出现根节点绘制错误的问题
                return;
            }
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                if ((e.State & TreeNodeStates.Focused) != 0)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, rect);
                }
                else
                {
                    e.Graphics.FillRectangle(SystemBrushes.Control, rect);
                }
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, rect);
            }
            int IndentWidth = DatatreeView.Indent * e.Node.Level + 25;
            e.Graphics.DrawRectangle(SystemPens.Control, rect);
            Rectangle StringRect = new Rectangle(e.Bounds.X + IndentWidth, e.Bounds.Y, colName.Width - IndentWidth, e.Bounds.Height);

            String TreeNameString = e.Node.Text;
            if (TreeNameString.EndsWith(MongoDBHelper.Array_Mark))
            {
                //Array_Mark 在计算路径的时候使用，不过，在表示的时候，则不能表示
                TreeNameString = TreeNameString.Substring(0, TreeNameString.Length - MongoDBHelper.Array_Mark.Length);
            }
            if (TreeNameString.EndsWith(MongoDBHelper.Document_Mark))
            {
                //Document_Mark 在计算路径的时候使用，不过，在表示的时候，则不能表示
                TreeNameString = TreeNameString.Substring(0, TreeNameString.Length - MongoDBHelper.Document_Mark.Length);
            }
            //感谢cyrus的建议，选中节点的文字表示，底色变更
            if ((e.State & TreeNodeStates.Selected) != 0 && (e.State & TreeNodeStates.Focused) != 0)
            {
                e.Graphics.DrawString(TreeNameString, this.Font, new SolidBrush(SystemColors.HighlightText), StringRect);
            }
            else
            {
                e.Graphics.DrawString(TreeNameString, this.Font, new SolidBrush(Color.Black), StringRect);
            }

            BsonElement mElement = e.Node.Tag as BsonElement;
            BsonValue mValue = e.Node.Tag as BsonValue;

            //画框
            if (e.Node.GetNodeCount(true) > 0 || (mElement != null && (mElement.Value.IsBsonDocument || mElement.Value.IsBsonArray)))
            {
                //感谢Cyrus测试出来的问题：RenderWithVisualStyles应该加上去的。
                if (VisualStyleRenderer.IsSupported && Application.RenderWithVisualStyles)
                {
                    int LeftPoint = e.Bounds.X + IndentWidth - 20;
                    //感谢 Shadower http://home.cnblogs.com/u/14697/ 贡献的代码
                    var thisNode = e.Node;
                    var glyph = thisNode.IsExpanded ? VisualStyleElement.TreeView.Glyph.Opened : VisualStyleElement.TreeView.Glyph.Closed;
                    var vsr = new VisualStyleRenderer(glyph);
                    vsr.DrawBackground(e.Graphics, new Rectangle(LeftPoint, e.Bounds.Y + 4, 16, 16));
                }
                else
                {
                    int LeftPoint = e.Bounds.X + IndentWidth - 20;
                    e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(LeftPoint, e.Bounds.Y + 4, 12, 12));
                    Point LeftMid = new Point(LeftPoint + 2, e.Bounds.Y + 10);
                    Point RightMid = new Point(LeftPoint + 10, e.Bounds.Y + 10);
                    Point TopMid = new Point(LeftPoint + 6, e.Bounds.Y + 6);
                    Point BottomMid = new Point(LeftPoint + 6, e.Bounds.Y + 14);
                    e.Graphics.DrawLine(new Pen(Color.Black), LeftMid, RightMid);
                    if (!e.Node.IsExpanded)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), TopMid, BottomMid);
                    }
                }
            }

            for (int intColumn = 1; intColumn < 3; intColumn++)
            {
                rect.Offset(this.listView.Columns[intColumn - 1].Width, 0);
                rect.Width = this.listView.Columns[intColumn].Width;
                e.Graphics.DrawRectangle(SystemPens.Control, rect);
                if (mElement != null || mValue != null)
                {
                    string strColumnText = String.Empty;
                    if (intColumn == 1)
                    {
                        if (mElement != null)
                        {
                            if (!mElement.Value.IsBsonDocument && !mElement.Value.IsBsonArray)
                            {
                                strColumnText = mElement.Value.ToString();
                            }
                        }
                        else
                        {
                            if (mValue != null)
                            {
                                if (!mValue.IsBsonDocument && !mValue.IsBsonArray)
                                {
                                    if (e.Node.Level > 0)
                                    {
                                        //根节点有Value，可能是ID，用来取得选中节点的信息
                                        strColumnText = mValue.ToString();
                                    }
                                }
                                //Type这里已经有表示Type的标识了，这里就不重复显示了。
                                //else
                                //{
                                //if (mValue.IsBsonDocument) { strColumnText = MongoDBHelper.Document_Mark; }
                                //if (mValue.IsBsonArray) { strColumnText = MongoDBHelper.Array_Mark; }
                                //}
                            }
                        }
                    }
                    else
                    {
                        if (mElement != null)
                        {
                            strColumnText = mElement.Value.GetType().Name.Substring(4);
                        }
                        else
                        {
                            strColumnText = mValue.GetType().Name.Substring(4);
                        }
                    }

                    TextFormatFlags flags = TextFormatFlags.EndEllipsis;
                    switch (this.listView.Columns[intColumn].TextAlign)
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
                        TextRenderer.DrawText(e.Graphics, strColumnText, e.Node.NodeFont, rect, SystemColors.HighlightText, flags);
                    else
                        TextRenderer.DrawText(e.Graphics, strColumnText, e.Node.NodeFont, rect, e.Node.ForeColor, e.Node.BackColor, flags);
                    rect.Y--;
                }
            }
        }

        private void Control_SizeChanged(object sender, EventArgs e)
        {
            this.colName.Width = Convert.ToInt32(this.Width * 0.3);
            this.colValue.Width = Convert.ToInt32(this.Width * 0.45);
            this.colType.Width = Convert.ToInt32(this.Width * 0.2);
        }

    }
}
