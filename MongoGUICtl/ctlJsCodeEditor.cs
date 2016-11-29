using Common;
using ICSharpCode.TextEditor.Document;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Windows.Forms;

namespace MongoGUICtl
{
    public partial class ctlJsCodeEditor : UserControl
    {
        public ctlJsCodeEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     标题
        /// </summary>
        public string Title
        {
            set { lblTitle.Text = value; }
            get { return lblTitle.Text; }
        }

        /// <summary>
        ///     内容
        /// </summary>
        public string Context
        {
            set { txtEditJavaScript.Text = value; }
            get { return txtEditJavaScript.Text; }
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtEditJavaScript.Text != string.Empty)
            {
                var strJsName = MyMessageBox.ShowInput("Please input Javascript name：[Save at system.js]",
                    "Save Javascript");
                Operater.CreateNewJavascript(strJsName, txtEditJavaScript.Text);
            }
        }

        /// <summary>
        ///     保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveLocal_Click(object sender, EventArgs e)
        {
            Utility.SaveJavascriptFile(txtEditJavaScript.Text);
        }

        /// <summary>
        ///     读取本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoadLocal_Click(object sender, EventArgs e)
        {
            txtEditJavaScript.Text = Utility.LoadFile();
        }

        /// <summary>
        ///     Load方法，属性设定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlJsCodeEditor_Load(object sender, EventArgs e)
        {
            txtEditJavaScript.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(ConstMgr.CSharp);
            if (DesignMode) return;
            foreach (var item in MongoHelper.GetJsNameList())
            {
                cmbJsList.Items.Add(item);
            }
            cmbJsList.SelectedIndexChanged += (x, y) =>
            {
                txtEditJavaScript.Text = Operater.LoadJavascript(cmbJsList.Text,
                    RuntimeMongoDbContext.GetCurrentJavaScript());
            };
            GuiConfig.Translateform(Controls);
        }
    }
}