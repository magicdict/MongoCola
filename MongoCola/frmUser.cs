using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Common.UI;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.Properties;
using ResourceLib;
using Common.Logic;


namespace MongoCola
{
    public partial class frmUser : Form
    {
        /// <summary>
        ///     是否作为Admin
        /// </summary>
        private readonly bool _IsAdmin;

        private readonly string _ModifyName = string.Empty;
        private readonly Dictionary<string, BsonElement> _otherDbRolesDict = new Dictionary<string, BsonElement>();

        /// <summary>
        ///     frmUser
        /// </summary>
        /// <param name="isAdmin"></param>
        public frmUser(bool isAdmin)
        {
            InitializeComponent();
            _IsAdmin = isAdmin;
            foreach (var item in RuntimeMongoDBContext.GetCurrentServer().GetDatabaseNames())
            {
                cmbDB.Items.Add(item);
            }
            if (!isAdmin)
            {
                //Admin以外的不能有otherDBRoles
                Width = Width/2;
            }
            userRoles.IsAdmin = isAdmin;
        }

        /// <summary>
        ///     frmUser
        /// </summary>
        /// <param name="isAdmin"></param>
        /// <param name="userName"></param>
        public frmUser(bool isAdmin, string userName)
        {
            InitializeComponent();
            _IsAdmin = isAdmin;
            _ModifyName = userName;
            cmbDB.Items.Clear();
            foreach (var item in RuntimeMongoDBContext.GetCurrentServer().GetDatabaseNames())
            {
                cmbDB.Items.Add(item);
            }
            if (!isAdmin)
            {
                //Admin以外的不能有otherDBRoles
                Width = Width/2;
            }
        }

        /// <summary>
        ///     确定
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
            //MongoUser不能同时具备Password和userSource字段！
            var user = new User
            {
                Username = txtUserName.Text,
                Password = txtUserName.Text,
                roles = userRoles.getRoles()
            };
            var otherDbRoles = new BsonDocument();
            foreach (var item in _otherDbRolesDict.Values)
            {
                otherDbRoles.Add(item);
            }
            user.otherDBRoles = otherDbRoles;
            user.userSource = txtuserSource.Text;
            if (txtUserName.Text == string.Empty)
            {
                MyMessageBox.ShowMessage("Error", "Please fill username!");
                return;
            }
            //2013/08/13 用户结构发生大的变化
            //取消了ReadOnly字段，添加了Roles等字段
            //简化逻辑，不论新建还是修改，AddUser都可以
            try
            {
                User.AddUserToSystem(user, _IsAdmin);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
            Close();
        }

        /// <summary>
        ///     关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            if (_ModifyName != string.Empty)
            {
                Text = "Change User Config";
                txtUserName.Enabled = false;
                txtUserName.Text = _ModifyName;
                var userInfo = RuntimeMongoDBContext.GetCurrentDataBase().GetCollection(ConstMgr.COLLECTION_NAME_USER)
                    .FindOneAs<BsonDocument>(Query.EQ("user", _ModifyName));
                userRoles.setRoles(userInfo["roles"].AsBsonArray);
                _otherDbRolesDict.Clear();
                foreach (var item in userInfo["otherDBRoles"].AsBsonDocument)
                {
                    _otherDbRolesDict.Add(item.Name, item);
                }
                RefreshOtherDbRoles();
            }
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                if (_ModifyName == string.Empty)
                {
                    Text =
                        GUIConfig.GetText(_IsAdmin
                            ? "Main_Menu_Operation_Server_AddUserToAdmin"
                            : "Main_Menu_Operation_Database_AddUser");
                    Icon = GetSystemIcon.ConvertImgToIcon(Resources.AddUserToDB);
                }
                else
                {
                    Icon = GetSystemIcon.ConvertImgToIcon(Resources.DBkey);
                    Text = GUIConfig.GetText(TextType.Common_ChangePassword);
                }
                lblUserName.Text =
                    GUIConfig.GetText(TextType.Common_Username);
                lblPassword.Text =
                    GUIConfig.GetText(TextType.Common_Password);
                lblConfirmPsw.Text =
                    GUIConfig.GetText(TextType.Common_ConfirmPassword);
                //chkReadOnly.Text = GUIConfig.GetText(MongoCola.Module.ResourceLib.Utility.TextType.Common_ReadOnly);
                colRoles.Text = GUIConfig.GetText(TextType.Common_Roles);
                colDataBase.Text =
                    GUIConfig.GetText(TextType.Common_DataBase);
                cmdOK.Text = GUIConfig.GetText(TextType.Common_OK);
                cmdCancel.Text = GUIConfig.GetText(TextType.Common_Cancel);
            }
        }

        /// <summary>
        ///     刷新角色
        /// </summary>
        private void RefreshOtherDbRoles()
        {
            lstOtherRoles.Items.Clear();
            foreach (var item in _otherDbRolesDict.Keys)
            {
                lstOtherRoles.Items.Add(new ListViewItem(new[] {item, _otherDbRolesDict[item].Value.ToString()}));
            }
        }

        /// <summary>
        ///     增加角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddRole_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbDB.Text))
            {
                MyMessageBox.ShowMessage("Error", "Please Select A Database");
                return;
            }
            var mUserRole = new frmUserRole(new BsonArray());
            mUserRole.ShowDialog();
            var otherRole = new BsonElement(cmbDB.Text, mUserRole.Result);
            if (_otherDbRolesDict.ContainsKey(cmbDB.Text))
            {
                _otherDbRolesDict[cmbDB.Text] = otherRole;
            }
            else
            {
                _otherDbRolesDict.Add(cmbDB.Text, otherRole);
            }
            RefreshOtherDbRoles();
        }

        /// <summary>
        ///     删除角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelRole_Click(object sender, EventArgs e)
        {
            if (lstOtherRoles.SelectedItems.Count == 0)
            {
                MyMessageBox.ShowMessage("Error", "Please Select A Database");
            }
            else
            {
                _otherDbRolesDict.Remove(lstOtherRoles.SelectedItems[0].Text);
                RefreshOtherDbRoles();
            }
        }

        /// <summary>
        ///     修改角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdModifyRole_Click(object sender, EventArgs e)
        {
            if (lstOtherRoles.SelectedItems.Count == 0)
            {
                MyMessageBox.ShowMessage("Error", "Please Select A Database");
            }
            else
            {
                var dbName = lstOtherRoles.SelectedItems[0].Text;
                var mUserRole = new frmUserRole(_otherDbRolesDict[dbName].Value.AsBsonArray);
                mUserRole.ShowDialog();
                var otherRole = new BsonElement(cmbDB.Text, mUserRole.Result);
                _otherDbRolesDict[dbName] = otherRole;
                RefreshOtherDbRoles();
            }
        }
    }
}