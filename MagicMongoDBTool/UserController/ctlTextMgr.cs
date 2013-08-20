using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

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

        private void cmdSaveLocal_Click(object sender, EventArgs e)
        {
            SystemManager.SaveJavascriptFile(txtContext.Text);
        }
    }
}
