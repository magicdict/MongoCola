using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;
using ICSharpCode.TextEditor.Document;
using MongoUtility.Basic;

namespace MongoGUIView
{
    public partial class CtlJsEditor : MultiTabControl
    {
        /// <summary>
        /// </summary>
        public string StrDBtag;

        /// <summary>
        /// </summary>
        public CtlJsEditor()
        {
            InitializeComponent();
            //InitProperty(this);
            InitProperty();
        }

        /// <summary>
        ///     Js名称
        /// </summary>
        public string JsName { set; get; }

        /// <summary>
        ///     加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsEditor_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            GuiConfig.Translateform(Controls);
            SaveStripButton.Image = Resources.save.ToBitmap();
            this.txtEvalJavaScript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(ConstMgr.CSharp);
            this.txtEditJavaScript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(ConstMgr.CSharp);

            if (!string.IsNullOrEmpty(JsName))
            {
                txtEditJavaScript.Text = Operater.LoadJavascript(JsName, RuntimeMongoDbContext.GetCurrentCollection());
            }
        }

        /// <summary>
        ///     添加行
        /// </summary>
        /// <param name="strText"></param>
        public void AppendLine(string strText)
        {
            txtEditJavaScript.Text += strText + Environment.NewLine;
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            RaiseCloseTabEvent();
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveStripButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(JsName))
            {
                var str = Operater.SaveEditorJavascript(JsName, txtEditJavaScript.Text,
                    RuntimeMongoDbContext.GetCurrentCollection());
                if (string.IsNullOrEmpty(str))
                    txtEvalJavaScript.Text = "保存成功" + System.Environment.NewLine;
            }
            else
            {
                var mSave = new SaveFileDialog();
                if (mSave.ShowDialog() == DialogResult.OK)
                {
                    var mStreamWriter = new StreamWriter(mSave.FileName, false);
                    try
                    {
                        mStreamWriter.Write(txtEditJavaScript.Text);
                    }
                    catch (Exception exception)
                    {
                        txtEvalJavaScript.Text += exception.Message;
                    }
                    finally
                    {
                        mStreamWriter.Close();
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtFile.Text))
            {
                var mStreamWriter = new StreamWriter(txtFile.Text, false);
                try
                {
                    mStreamWriter.Write(txtEditJavaScript.Text);
                    txtEvalJavaScript.Text += "文件同步成功" + System.Environment.NewLine;
                }
                catch (Exception exception)
                {
                    txtEvalJavaScript.Text += exception.Message;
                }
                finally
                {
                    mStreamWriter.Close();
                }
            }
        }

        /// <summary>
        ///     Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditDocStripButton_Click(object sender, EventArgs e)
        {
            Gfs.SaveAndOpenStringAsFile(txtEditJavaScript.Text);
        }

        public override void RefreshGui()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     打开文件夹路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOpenFile_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog { Filter = Common.Utility.JsFilter };
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = open.FileName;
            }
        }

        /// <summary>
        ///     执行js
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butEval_Click(object sender, EventArgs e)
        {
            var mongoDb = RuntimeMongoDbContext.GetCurrentDataBase();
            var js = new BsonJavaScript(txtParameter.Text);

            try
            {
                var args = new EvalArgs { Code = js };
                var result = mongoDb.Eval(args);
                txtEvalJavaScript.Text = ToJson(result);
            }
            catch (Exception ex)
            {
                txtEvalJavaScript.Text = ex.Message;
            }
        }

        /// <summary>
        ///     快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtlJsEditor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        ///     快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtlJsEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.S | Keys.Control))
                SaveStripButton_Click(null, null);
        }

        #region 格式化json

        public static string ToJson<T>(T obj)
        {
            string result;
            using (var stringWriter = new StringWriter())
            {
                using (var mJsonWriter = new JsonWriter(stringWriter, new JsonWriterSettings()))
                {
                    BsonSerializer.Serialize(mJsonWriter, obj, null);
                }
                result = stringWriter.ToString();
            }
            return result;
        }

        #endregion

        #region 实现窗体内的控件拖动

        //用法：在Form初始化或者Form_Load时先执行
        //DragComponent a = new DragComponent();
        //a.initProperty(groupBox1);
        //将界面groupBox1上的所有控件都绑定MyMouseDown、MyMouseLeave、MyMouseMove事件。 

        private Control control;
        private const int Band = 5;
        private const int MinWidth = 10;
        private const int MinHeight = 10;
        private EnumMousePointPosition m_MousePointPosition;
        private Point p, p1;

        private enum EnumMousePointPosition
        {
            MouseSizeNone = 0, //'无
            MouseSizeRight = 1, //'拉伸右边框
            MouseSizeLeft = 2, //'拉伸左边框
            MouseSizeBottom = 3, //'拉伸下边框
            MouseSizeTop = 4, //'拉伸上边框
            MouseSizeTopLeft = 5, //'拉伸左上角
            MouseSizeTopRight = 6, //'拉伸右上角
            MouseSizeBottomLeft = 7, //'拉伸左下角
            MouseSizeBottomRight = 8, //'拉伸右下角
            MouseDrag = 9 // '鼠标拖动
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            p.X = e.X;
            p.Y = e.Y;
            p1.X = e.X;
            p1.Y = e.Y;
        }

        private void MyMouseLeave(object sender, EventArgs e)
        {
            m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
            control.Cursor = Cursors.Arrow;
        }

        private EnumMousePointPosition MousePointPosition(Size size, MouseEventArgs e)
        {
            return (e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height)
                ? (e.X < Band
                    ? (e.Y < Band
                        ? EnumMousePointPosition.MouseSizeTopLeft
                        : (e.Y > -1 * Band + size.Height
                            ? EnumMousePointPosition.MouseSizeBottomLeft
                            : EnumMousePointPosition.MouseSizeLeft))
                    : (e.X > -1 * Band + size.Width
                        ? (e.Y < Band
                            ? EnumMousePointPosition.MouseSizeTopRight
                            : (e.Y > -1 * Band + size.Height
                                ? EnumMousePointPosition.MouseSizeBottomRight
                                : EnumMousePointPosition.MouseSizeRight))
                        : (e.Y < Band
                            ? EnumMousePointPosition.MouseSizeTop
                            : (e.Y > -1 * Band + size.Height
                                ? EnumMousePointPosition.MouseSizeBottom
                                : EnumMousePointPosition.MouseDrag))))
                : EnumMousePointPosition.MouseSizeNone;
        }

        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            var lCtrl = sender as Control;
            if (e.Button == MouseButtons.Left)
            {
                switch (m_MousePointPosition)
                {
                    case EnumMousePointPosition.MouseDrag:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + e.Y - p.Y;
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        lCtrl.Width = lCtrl.Width + e.X - p1.X;
                        //      lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width + (e.X - p1.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        p1.X = e.X;
                        p1.Y = e.Y; //'记录光标拖动的当前点
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        lCtrl.Left = lCtrl.Left + e.X - p.X;
                        lCtrl.Top = lCtrl.Top + (e.Y - p.Y);
                        lCtrl.Width = lCtrl.Width - (e.X - p.X);
                        lCtrl.Height = lCtrl.Height - (e.Y - p.Y);
                        break;
                    default:
                        break;
                }
                if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
                if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;
            }
            else
            {
                m_MousePointPosition = MousePointPosition(lCtrl.Size, e); //'判断光标的位置状态
                switch (m_MousePointPosition) //'改变光标
                {
                    case EnumMousePointPosition.MouseSizeNone:
                        control.Cursor = Cursors.Arrow; //'箭头
                        break;

                    case EnumMousePointPosition.MouseDrag:
                        control.Cursor = Cursors.SizeAll; //'四方向
                        break;
                    case EnumMousePointPosition.MouseSizeBottom:
                        control.Cursor = Cursors.SizeNS; //'南北
                        break;
                    case EnumMousePointPosition.MouseSizeTop:
                        control.Cursor = Cursors.SizeNS; //'南北
                        break;
                    case EnumMousePointPosition.MouseSizeLeft:
                        control.Cursor = Cursors.SizeWE; //'东西
                        break;
                    case EnumMousePointPosition.MouseSizeRight:
                        control.Cursor = Cursors.SizeWE; //'东西
                        break;
                    case EnumMousePointPosition.MouseSizeBottomLeft:
                        control.Cursor = Cursors.SizeNESW; //'东北到南西
                        break;
                    case EnumMousePointPosition.MouseSizeBottomRight:
                        control.Cursor = Cursors.SizeNWSE; //'东南到西北
                        break;
                    case EnumMousePointPosition.MouseSizeTopLeft:
                        control.Cursor = Cursors.SizeNWSE; //'东南到西北
                        break;
                    case EnumMousePointPosition.MouseSizeTopRight:
                        control.Cursor = Cursors.SizeNESW; //'东北到南西
                        break;
                    default:
                        break;
                }
            }
        }

        public void InitProperty(Control ctl)
        {
            control = ctl;
            for (var i = 0; i < control.Controls.Count; i++)
            {
                control.Controls[i].MouseDown += MyMouseDown;
                control.Controls[i].MouseLeave += MyMouseLeave;
                control.Controls[i].MouseMove += MyMouseMove;
            }
        }

        public void InitProperty()
        {
            control = this;
            groupEditJavaScript.MouseDown += MyMouseDown;
            groupEditJavaScript.MouseLeave += MyMouseLeave;
            groupEditJavaScript.MouseMove += MyMouseMove;
        }

        #endregion
    }
}