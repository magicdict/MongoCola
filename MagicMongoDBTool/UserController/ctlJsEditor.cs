using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using System.IO;

namespace MagicMongoDBTool
{
    public partial class ctlJsEditor : UserControl
    {
        /// <summary>
        /// Js名称
        /// </summary>
        public String JsName { set; get; }
        /// <summary>
        /// 关闭Tab事件
        /// </summary>
        public event EventHandler CloseTab;
        /// <summary>
        /// 
        /// </summary>
        public String strDBtag;
        /// <summary>
        /// 
        /// </summary>
        public ctlJsEditor()
        {
            InitializeComponent();
            SaveStripButton.Image = MagicMongoDBTool.Properties.Resources.save.ToBitmap();
        }

        private void JsEditor_Load(object sender, EventArgs e)
        {
            if (JsName != null && JsName != String.Empty)
            {
                txtJavaScript.Text = MongoDBHelper.LoadJavascript(JsName);
                txtJavaScript.Select(0, 0);
            }
            this.txtJavaScript.GotFocus += new EventHandler(
                (x, y) => {
                    SystemManager.SelectObjectTag = strDBtag;
                }
            );
        }
        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="strText"></param>
        public void AppendLine(String strText) {
            txtJavaScript.Text += strText + System.Environment.NewLine;
        }
        /// <summary>
        /// 关闭
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveStripButton_Click(object sender, EventArgs e)
        {
            if (JsName != null && JsName != String.Empty)
            {
                MongoDBHelper.SaveEditorJavascript(JsName,txtJavaScript.Text);
            }
            else {
                SaveFileDialog mSave = new SaveFileDialog();
                if (mSave.ShowDialog() == DialogResult.OK) {
                    StreamWriter mStreamWriter = new StreamWriter(mSave.FileName, false);
                    mStreamWriter.Write(this.txtJavaScript.Text);
                    mStreamWriter.Close();
                }
            }
        }
        /// <summary>
        /// Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditDocStripButton_Click(object sender, EventArgs e)
        {
            MongoDBHelper.SaveAndOpenStringAsFile(txtJavaScript.Text);
        }
    }
}
