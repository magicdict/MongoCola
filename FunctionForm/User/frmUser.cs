using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.Properties;
using ResourceLib.UI;

namespace FunctionForm.User
{
    public partial class FrmUser : Form
    {
        /// <summary>
        ///     是否作为Admin
        /// </summary>
        private readonly bool _isAdmin;

        private readonly string _modifyName = string.Empty;
        private readonly Dictionary<string, BsonElement> _otherDbRolesDict = new Dictionary<string, BsonElement>();

        /// <summary>
        ///     frmUser
        /// </summary>
        /// <param name="isAdmin"></param>
        public FrmUser(bool isAdmin)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
            foreach (var item in RuntimeMongoDbContext.GetCurrentServer().GetDatabaseNames())
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
        public FrmUser(bool isAdmin, string userName)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
            _modifyName = userName;
            cmbDB.Items.Clear();
            foreach (var item in RuntimeMongoDbContext.GetCurrentServer().GetDatabaseNames())
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
            var user = new MongoUtility.Security.User
            {
                Username = txtUserName.Text,
                Password = txtUserName.Text,
                Roles = userRoles.GetRoles()
            };
            var otherDbRoles = new BsonDocument();
            foreach (var item in _otherDbRolesDict.Values)
            {
                otherDbRoles.Add(item);
            }
            user.OtherDbRoles = otherDbRoles;
            user.UserSource = txtuserSource.Text;
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
                MongoUtility.Security.User.AddUserToSystem(user, _isAdmin);
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
            if (_modifyName != string.Empty)
            {
                Text = "Change User Config";
                txtUserName.Enabled = false;
                txtUserName.Text = _modifyName;
                var userInfo = RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(ConstMgr.CollectionNameUser)
                    .FindOneAs<BsonDocument>(Query.EQ("user", _modifyName));
                userRoles.SetRoles(userInfo["roles"].AsBsonArray);
                _otherDbRolesDict.Clear();
                foreach (var item in userInfo["otherDBRoles"].AsBsonDocument)
                {
                    _otherDbRolesDict.Add(item.Name, item);
                }
                RefreshOtherDbRoles();
            }
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                if (_modifyName == string.Empty)
                {
                    Text = GuiConfig.GetText(_isAdmin
                        ? TextType.MainMenuOperationServerAddUserToAdmin
                        : TextType.MainMenuOperationDatabaseAddUser);
                    if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.AddUserToDB);
                }
                else
                {
                    if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.DBkey);
                    Text = GuiConfig.GetText(TextType.CommonChangePassword);
                }
                lblUserName.Text =
                    GuiConfig.GetText(TextType.CommonUsername);
                lblPassword.Text =
                    GuiConfig.GetText(TextType.CommonPassword);
                lblConfirmPsw.Text =
                    GuiConfig.GetText(TextType.CommonConfirmPassword);
                //chkReadOnly.Text = GUIConfig.GetText(MongoCola.Module.ResourceLib.MongoHelper.TextType.Common_ReadOnly);
                colRoles.Text = GuiConfig.GetText(TextType.CommonRoles);
                colDataBase.Text =
                    GuiConfig.GetText(TextType.CommonDataBase);
                cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
                cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
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
            var mUserRole = new FrmUserRole(new BsonArray());
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
                var mUserRole = new FrmUserRole(_otherDbRolesDict[dbName].Value.AsBsonArray);
                mUserRole.ShowDialog();
                var otherRole = new BsonElement(cmbDB.Text, mUserRole.Result);
                _otherDbRolesDict[dbName] = otherRole;
                RefreshOtherDbRoles();
            }
        }
    }
}