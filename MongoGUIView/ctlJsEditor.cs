using System;
using System.IO;
using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Method;
using ResourceLib.Properties;
using MongoGUIView;

namespace MongoGUICtl
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
        }

        /// <summary>
        ///     Js名称
        /// </summary>
        public string JsName { set; get; }


        private void JsEditor_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            GuiConfig.Translateform(Controls);
            SaveStripButton.Image = Resources.save.ToBitmap();
            if (JsName != null && JsName != string.Empty)
            {
                txtJavaScript.Text = OperationHelper.LoadJavascript(JsName, null);
                txtJavaScript.Select(0, 0);
            }
            txtJavaScript.GotFocus += (x, y) => { RuntimeMongoDbContext.SelectObjectTag = StrDBtag; };
        }

        /// <summary>
        ///     添加行
        /// </summary>
        /// <param name="strText"></param>
        public void AppendLine(string strText)
        {
            txtJavaScript.Text += strText + Environment.NewLine;
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
            if (JsName != null && JsName != string.Empty)
            {
                OperationHelper.SaveEditorJavascript(JsName, txtJavaScript.Text, null);
            }
            else
            {
                var mSave = new SaveFileDialog();
                if (mSave.ShowDialog() == DialogResult.OK)
                {
                    var mStreamWriter = new StreamWriter(mSave.FileName, false);
                    mStreamWriter.Write(txtJavaScript.Text);
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
            Gfs.SaveAndOpenStringAsFile(txtJavaScript.Text);
        }
    }
}