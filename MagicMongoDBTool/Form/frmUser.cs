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
        /// <summary>
        /// frmUser
        /// </summary>
        /// <param name="IsAdmin"></param>
        public frmUser(Boolean IsAdmin)
        {
            InitializeComponent();
            _IsAdmin = IsAdmin;
            foreach (var item in SystemManager.GetCurrentServer().GetDatabaseNames())
            {
                cmbDB.Items.Add(item);
            }
        }
        /// <summary>
        /// frmUser
        /// </summary>
        /// <param name="IsAdmin"></param>
        /// <param name="UserName"></param>
        public frmUser(Boolean IsAdmin, String UserName)
        {
            InitializeComponent();
            _IsAdmin = IsAdmin;
            _ModifyName = UserName;
            cmbDB.Items.Clear();
            foreach (var item in SystemManager.GetCurrentServer().GetDatabaseNames())
            {
                cmbDB.Items.Add(item);
            }
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
            MongoDBHelper.MongoUserEx user = new MongoDBHelper.MongoUserEx();
            user.Username = txtUserName.Text;
            user.Password = txtUserName.Text;
            user.roles = userRoles.getRoles();
            if (_ModifyName == String.Empty)
            {
                //New User

                if (txtUserName.Text == String.Empty)
                {
                    MyMessageBox.ShowMessage("Error", "Please fill username!");
                    return;
                }
                //2013/08/13 用户结构发生大的变化
                //取消了ReadOnly字段，添加了Roles等字段
                MongoDBHelper.AddUserToSystem(user, _IsAdmin);
            }
            else
            {
                //Change Password
                MongoDBHelper.RemoveUserFromSystem(_ModifyName, _IsAdmin);
                MongoDBHelper.AddUserToSystem(user, _IsAdmin);
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
                //chkReadOnly.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_ReadOnly);
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
                cmdCancel.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Cancel);

            }


        }
    }
}
