using MagicMongoDBTool.Module;
using System;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class ctlTextMgr : UserControl
    {
        public ctlTextMgr()
        {
            InitializeComponent();
            this.Load += (x, y) => init();
        }
        public void init()
        {
            if (!this.DesignMode)
            {
                foreach (String item in SystemManager.GetJsNameList())
                {
                    cmbJsList.Items.Add(item);
                }
                cmbJsList.SelectedIndexChanged += new EventHandler(
                    (x, y) => { txtContext.Text = MongoDBHelper.LoadJavascript(cmbJsList.Text); }
                );
                if (!SystemManager.IsUseDefaultLanguage)
                {
                    cmdSave.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save);
                    cmdSaveLocal.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save_Local);
                    cmdLoadLocal.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Query_Action_Load);
                }
            }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public String Title
        {
            set
            {
                lblTitle.Text = value;
            }
            get
            {
                return lblTitle.Text;
            }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public String Context
        {
            set
            {
                txtContext.Text = value;
            }
            get
            {
                return txtContext.Text;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (txtContext.Text != String.Empty)
            {
                String strJsName = MyMessageBox.ShowInput("pls Input Javascript Name：[Save at system.js]", "Save Javascript");
                MongoDBHelper.CreateNewJavascript(strJsName, txtContext.Text);
            }

        }
        /// <summary>
        /// 保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveLocal_Click(object sender, EventArgs e)
        {
            SystemManager.SaveJavascriptFile(txtContext.Text);
        }
        /// <summary>
        /// 读取本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoadLocal_Click(object sender, EventArgs e)
        {
            txtContext.Text = SystemManager.LoadFile();
        }
    }
}
