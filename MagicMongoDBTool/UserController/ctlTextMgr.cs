using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlTextMgr : UserControl
    {
        public ctlTextMgr()
        {
            InitializeComponent();
            Load += (x, y) => init();
        }

        /// <summary>
        ///     标题
        /// </summary>
        public String Title
        {
            set { lblTitle.Text = value; }
            get { return lblTitle.Text; }
        }

        /// <summary>
        ///     内容
        /// </summary>
        public String Context
        {
            set { txtContext.Text = value; }
            get { return txtContext.Text; }
        }

        public void init()
        {
            if (!DesignMode)
            {
                foreach (String item in SystemManager.GetJsNameList())
                {
                    cmbJsList.Items.Add(item);
                }
                cmbJsList.SelectedIndexChanged +=
                    (x, y) => { txtContext.Text = MongoDbHelper.LoadJavascript(cmbJsList.Text); };
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    cmdSave.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Save);
                    cmdSaveLocal.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Save_Local);
                    cmdLoadLocal.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Query_Action_Load);
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
            if (txtContext.Text != String.Empty)
            {
                String strJsName = MyMessageBox.ShowInput("please Input Javascript Name：[Save at system.js]",
                    "Save Javascript");
                MongoDbHelper.CreateNewJavascript(strJsName, txtContext.Text);
            }
        }

        /// <summary>
        ///     保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveLocal_Click(object sender, EventArgs e)
        {
            SystemManager.SaveJavascriptFile(txtContext.Text);
        }

        /// <summary>
        ///     读取本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoadLocal_Click(object sender, EventArgs e)
        {
            txtContext.Text = SystemManager.LoadFile();
        }
    }
}