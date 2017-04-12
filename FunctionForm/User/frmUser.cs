using Common;
using FunctionForm.Operation;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.Method;
using ResourceLib.Properties;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.User
{
    public partial class FrmUser : Form
    {
        /// <summary>
        ///     是否作为Admin
        /// </summary>
        private bool _isAdmin;
        /// <summary>
        ///     修改用户名
        /// </summary>
        private string _modifyName = string.Empty;

        /// <summary>
        ///     frmUser
        /// </summary>
        /// <param name="isAdmin"></param>
        public FrmUser(bool isAdmin)
        {
            InitializeComponent();
            _isAdmin = isAdmin;
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
        }

        /// <summary>
        ///     Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUser_Load(object sender, EventArgs e)
        {
            if (_modifyName != string.Empty)
            {
                Text = "Change User Config";
                txtUserName.Enabled = false;
                txtUserName.Text = _modifyName;
                var userInfo = RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(ConstMgr.CollectionNameUsers)
                    .FindOneAs<BsonDocument>(Query.EQ("user", _modifyName));

                if (userInfo.TryGetElement("roles", out BsonElement role))
                {
                    var roles = role.Value.AsBsonArray;
                    foreach (var _role in roles)
                    {
                        if (_role.IsBsonDocument)
                        {
                            _roleList.Add(new Role.GrantRole()
                            {
                                Role = _role.AsBsonDocument.GetElement("role").Value.ToString(),
                                Db = _role.AsBsonDocument.GetElement("db").Value.ToString()
                            });
                        }
                        else
                        {
                            _roleList.Add(new Role.GrantRole()
                            {
                                Role = _role.ToString(),
                            });
                        }
                    }
                }
                RefreshRoles();

                if (userInfo.TryGetElement("customData", out BsonElement custom))
                {
                    customData = custom.Value.AsBsonDocument;
                    lblcustomDocument.Text = "Custom Document:" + customData.ToString();
                }

            }

            GuiConfig.Translateform(this);

            if (!GuiConfig.IsUseDefaultLanguage)
            {
                if (_modifyName == string.Empty)
                {
                    if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.AddUserToDB);
                    Text = GuiConfig.GetText(_isAdmin ? "MainMenu.OperationServerAddUserToAdmin" : "MainMenu.OperationDatabaseAddUser");
                }
                else
                {
                    if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(Resources.DBkey);
                    Text = GuiConfig.GetText("CommonChangePassword");
                }
            }
        }

        /// <summary>
        ///     角色
        /// </summary>
        private List<Role.GrantRole> _roleList = new List<Role.GrantRole>();

        /// <summary>
        ///     选择角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickRole_Click(object sender, EventArgs e)
        {
            var mUserRole = new FrmUserRole(_roleList, _isAdmin);
            mUserRole.ShowDialog();
            _roleList = mUserRole.PickedRoles;
            RefreshRoles();
        }

        private void RefreshRoles()
        {
            lstRoles.Items.Clear();
            foreach (var role in _roleList)
            {
                var lst = new ListViewItem(role.Role);
                lst.SubItems.Add(role.Db);
                lstRoles.Items.Add(lst);
            }
        }

        /// <summary>
        ///     用户信息
        /// </summary>
        BsonDocument customData = null;

        private void btnPickDoc_Click(object sender, EventArgs e)
        {
            var frmInsertDoc = new frmCreateDocument();
            UIAssistant.OpenModalForm(frmInsertDoc, false, true);
            if (frmInsertDoc.mBsonDocument == null) return;
            customData = frmInsertDoc.mBsonDocument;
            lblcustomDocument.Text = "Custom Document:" + customData.ToString();
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
            var user = new MongoUserEx
            {
                Username = txtUserName.Text,
                Password = txtUserName.Text,
                Roles = _roleList,
                customData = customData
            };
            if (txtUserName.Text == string.Empty)
            {
                MyMessageBox.ShowMessage("Error", "Please fill username!");
                return;
            }
            try
            {
                CommandResult result = null;
                if (txtUserName.Enabled)
                {
                    result = MongoUserEx.AddUser(user, _isAdmin);
                }
                else
                {
                    result = MongoUserEx.UpdateUser(user, _isAdmin);
                }
                MyMessageBox.ShowMessage("Result:", result.Response.ToString());
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
    }
}