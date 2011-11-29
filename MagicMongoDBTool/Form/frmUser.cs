using System;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmUser : QLFUI.QLFForm
    {
        /// <summary>
        /// 是否作为Admin
        /// </summary>
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
                if (_IsAdmin)
                {
                    this.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
                }
                else
                {
                    this.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Main_Menu_Operation_Database_AddUser);
                }
                lblPassword.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Password);
                lblUserName.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Username);
                chkReadOnly.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_ReadOnly);
                cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Cancel);
            }
        }
    }
}
