using System;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmUser : System.Windows.Forms.Form
    {
        /// <summary>
        /// 是否作为Admin
        /// </summary>
        private Boolean _IsAdmin = false;
        private String _ModifyName = String.Empty;
        public frmUser(Boolean IsAdmin)
        {
            InitializeComponent();
            _IsAdmin = IsAdmin;
        }
        public frmUser(Boolean IsAdmin, String UserName)
        {
            InitializeComponent();
            _IsAdmin = IsAdmin;
            _ModifyName = UserName;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtConfirmPsw.Text != txtPassword.Text)
            {
                MyMessageBox.ShowMessage("Error", "Password and Confirm Password not match!");
                return;
            }
            if (_ModifyName == String.Empty)
            {
                //New User

                if (txtUserName.Text == String.Empty)
                {
                    MyMessageBox.ShowMessage("Error", "Please fill username!");
                    return;
                }
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
            }
            else
            {
                //Change Password
                if (_IsAdmin)
                {
                    MongoDBHelper.RemoveUserFromSvr(_ModifyName);
                    MongoDBHelper.AddUserToSvr(txtUserName.Text, txtPassword.Text, chkReadOnly.Checked);
                }
                else
                {
                    MongoDBHelper.RemoveUserFromDB(_ModifyName);
                    MongoDBHelper.AddUserToDB(txtUserName.Text, txtPassword.Text, chkReadOnly.Checked);
                }
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

            if (_ModifyName != String.Empty)
            {
                this.Text = "Change Password";
                txtUserName.Enabled = false;
                txtUserName.Text = _ModifyName;
            }
            if (!SystemManager.IsUseDefaultLanguage)
            {
                if (_ModifyName == String.Empty)
                {
                    if (_IsAdmin)
                    {
                        this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Main_Menu_Operation_Server_AddUserToAdmin);
                    }
                    else
                    {
                        this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Main_Menu_Operation_Database_AddUser);
                    }
                    this.Icon = GetSystemIcon.ConvertImgToIcon(MagicMongoDBTool.Properties.Resources.AddUserToDB);
                }
                else
                {
                    this.Icon = GetSystemIcon.ConvertImgToIcon(MagicMongoDBTool.Properties.Resources.DBkey);
                    //this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Main_Menu_Operation_Database_ChangePassword);
                }
                lblUserName.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Username);
                lblPassword.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Password);
                lblConfirmPsw.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_ConfirmPassword);
                chkReadOnly.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_ReadOnly);
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Cancel);

            }


        }
    }
}
