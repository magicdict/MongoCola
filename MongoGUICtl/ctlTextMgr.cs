using System;
using System.Windows.Forms;
using Common;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoGUICtl
{
    public partial class CtlTextMgr : UserControl
    {
        public CtlTextMgr()
        {
            InitializeComponent();
            Load += (x, y) => Init();
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
            set { txtContext.Text = value; }
            get { return txtContext.Text; }
        }

        public void Init()
        {
            if (!DesignMode)
            {
                foreach (var item in MongoHelper.GetJsNameList())
                {
                    cmbJsList.Items.Add(item);
                }
                cmbJsList.SelectedIndexChanged +=
                    (x, y) =>
                    {
                        txtContext.Text = Operater.LoadJavascript(cmbJsList.Text,
                            RuntimeMongoDbContext.GetCurrentJavaScript());
                    };
                if (!GuiConfig.IsUseDefaultLanguage)
                {
                    cmdSave.Text = GuiConfig.GetText(TextType.CommonSave);
                    cmdSaveLocal.Text =
                        GuiConfig.GetText(TextType.CommonSaveLocal);
                    cmdLoadLocal.Text =
                        GuiConfig.GetText(TextType.QueryActionLoad);
                }
            }
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtContext.Text != string.Empty)
            {
                var strJsName = MyMessageBox.ShowInput("please Input Javascript Name：[Save at system.js]",
                    "Save Javascript");
                Operater.CreateNewJavascript(strJsName, txtContext.Text);
            }
        }

        /// <summary>
        ///     保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveLocal_Click(object sender, EventArgs e)
        {
            Utility.SaveJavascriptFile(txtContext.Text);
        }

        /// <summary>
        ///     读取本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoadLocal_Click(object sender, EventArgs e)
        {
            txtContext.Text = Utility.LoadFile();
        }
    }
}