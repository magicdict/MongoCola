using System;
using System.IO;
using System.Windows.Forms;
using MongoUtility;
using MongoUtility.Core;
using MongoUtility.Operation;
using ResourceLib;
using ResourceLib.Properties;

namespace MongoGUICtl
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
            if (DesignMode) return;
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.ServiceStatus_Title);
                SaveStripButton.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
                EditDocStripButton.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Edit);
                CloseStripButton.Text =
                    configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Close);
            }
            SaveStripButton.Image = Resources.save.ToBitmap();
            if (JsName != null && JsName != String.Empty)
            {
                txtJavaScript.Text = OperationHelper.LoadJavascript(JsName, null);
                txtJavaScript.Select(0, 0);
            }
            txtJavaScript.GotFocus += (x, y) => { RuntimeMongoDBContext.SelectObjectTag = strDBtag; };
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
            GFS.SaveAndOpenStringAsFile(txtJavaScript.Text);
        }
    }
}