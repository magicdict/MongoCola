using System;
using System.Windows.Forms;
using Common.UI;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;

namespace MongoGUICtl
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
                foreach (var item in Utility.GetJsNameList())
                {
                    cmbJsList.Items.Add(item);
                }
                cmbJsList.SelectedIndexChanged +=
                    (x, y) => { txtContext.Text = OperationHelper.LoadJavascript(cmbJsList.Text, null); };
                if (!configuration.guiConfig.IsUseDefaultLanguage)
                {
                    cmdSave.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
                    cmdSaveLocal.Text =
                        configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save_Local);
                    cmdLoadLocal.Text =
                        configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Query_Action_Load);
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
                var strJsName = MyMessageBox.ShowInput("please Input Javascript Name：[Save at system.js]",
                    "Save Javascript");
                OperationHelper.CreateNewJavascript(strJsName, txtContext.Text, null);
            }
        }

        /// <summary>
        ///     保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveLocal_Click(object sender, EventArgs e)
        {
            Common.Logic.Utility.SaveJavascriptFile(txtContext.Text);
        }

        /// <summary>
        ///     读取本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoadLocal_Click(object sender, EventArgs e)
        {
            txtContext.Text = Common.Logic.Utility.LoadFile();
        }
    }
}