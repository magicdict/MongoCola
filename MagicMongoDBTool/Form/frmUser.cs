using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLFUI;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmUser : QLFUI.QLFForm
    {
        private Boolean _IsAdmin = false;
        public frmUser(Boolean IsAdmin)
        {
            InitializeComponent();
            _IsAdmin = IsAdmin;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (_IsAdmin)
            {
                //添加到服务器，作为Admin用户
                MongoDBHelper.AddUserToSvr(txtUserName.Text, txtPassword.Text, chkReadOnly.Checked);
            }
            else
            {
                //添加到数据库
                MongoDBHelper.AddUserToDB(txtUserName.Text, txtPassword.Text, chkReadOnly.Checked);
            }
            this.Close();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lblPassword.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Password);
                lblUserName.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Username);
                chkReadOnly.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_ReadOnly);
                cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Cancel);
            }
        }
    }
}
