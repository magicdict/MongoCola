using System;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MagicMongoDBTool.Properties;

namespace MagicMongoDBTool
{
    public partial class ctlJsEditor : UserControl
    {
        /// <summary>
        /// </summary>
        public String strDBtag;

        /// <summary>
        /// </summary>
        public ctlJsEditor()
        {
            InitializeComponent();

            if (!SystemManager.IsUseDefaultLanguage)
            {
                Text = SystemManager.mStringResource.GetText(StringResource.TextType.ServiceStatus_Title);
                SaveStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Save);
                EditDocStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Edit);
                CloseStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
            }

            SaveStripButton.Image = Resources.save.ToBitmap();
        }

        /// <summary>
        ///     Js名称
        /// </summary>
        public String JsName { set; get; }

        /// <summary>
        ///     关闭Tab事件
        /// </summary>
        public event EventHandler CloseTab;

        private void JsEditor_Load(object sender, EventArgs e)
        {
            if (JsName != null && JsName != String.Empty)
            {
                txtJavaScript.Text = MongoDBHelper.LoadJavascript(JsName);
                txtJavaScript.Select(0, 0);
            }
            txtJavaScript.GotFocus += (x, y) => { SystemManager.SelectObjectTag = strDBtag; };
        }

        /// <summary>
        ///     添加行
        /// </summary>
        /// <param name="strText"></param>
        public void AppendLine(String strText)
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
            if (CloseTab != null)
            {
                CloseTab(sender, e);
            }
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveStripButton_Click(object sender, EventArgs e)
        {
            if (JsName != null && JsName != String.Empty)
            {
                MongoDBHelper.SaveEditorJavascript(JsName, txtJavaScript.Text);
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
            MongoDBHelper.SaveAndOpenStringAsFile(txtJavaScript.Text);
        }
    }
}