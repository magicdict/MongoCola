using System;
using System.Windows.Forms;
using Common.Logic;
using Common.UI;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib;

namespace MongoGUIView
{
    public partial class ctlUserView : ctlDataView
    {
        public ctlUserView(DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            mDataViewInfo = _DataViewInfo;
            _dataShower.Add(lstData);
        }

        private void ctlUserView_Load(object sender, EventArgs e)
        {
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                AddUserStripButton.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_Database_AddUser");
                AddUserToolStripMenuItem.Text = AddUserStripButton.Text;
                ChangePasswordStripButton.Text =
                    GUIConfig.MStringResource.GetText(TextType.Common_ChangePassword);
                ChangePasswordToolStripMenuItem.Text = ChangePasswordStripButton.Text;
                RemoveUserStripButton.Text =
                    GUIConfig.MStringResource.GetText(
                        "Main_Menu_Operation_Database_DelUser");
                RemoveUserToolStripMenuItem.Text = RemoveUserStripButton.Text;
            }
            AddUserStripButton.Enabled = true;
            ChangePasswordStripButton.Enabled = false;
            RemoveUserStripButton.Enabled = false;
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0 && !mDataViewInfo.IsReadOnly)
            {
                AddUserToolStripMenuItem.Enabled = true;
                AddUserStripButton.Enabled = true;

                RemoveUserStripButton.Enabled = true;
                RemoveUserToolStripMenuItem.Enabled = true;

                if (lstData.SelectedItems.Count == 1)
                {
                    ChangePasswordStripButton.Enabled = true;
                    ChangePasswordToolStripMenuItem.Enabled = true;
                }
            }
        }

        protected void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangePasswordStripButton_Click(sender, e);
        }

        protected void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            RuntimeMongoDBContext.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    contextMenuStripMain = new ContextMenuStrip();
                    contextMenuStripMain.Items.Add(AddUserToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(ChangePasswordToolStripMenuItem.Clone());
                    contextMenuStripMain.Items.Add(RemoveUserToolStripMenuItem.Clone());
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }

        #region"用户"

        /// <summary>
        ///     打开新用户
        /// </summary>
        public Action OpenAddNewUserForm;

        /// <summary>
        ///     更改密码
        /// </summary>
        public Action OpenChangePasswordForm;

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserStripButton_Click(object sender, EventArgs e)
        {
            OpenAddNewUserForm();
            RefreshGUI();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserStripButton_Click(object sender, EventArgs e)
        {
            if (mDataViewInfo.IsAdminDB)
            {
                RemoveUserFromAdmin();
            }
            else
            {
                RemoveUser();
            }
            RefreshGUI();
        }

        /// <summary>
        ///     Drop User from Admin Group
        /// </summary>
        private void RemoveUserFromAdmin()
        {
            var strTitle = "Drop User";
            var strMessage = "Are you sure to delete user(s) from Admin Group?";
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                strTitle = GUIConfig.MStringResource.GetText(TextType.Drop_User);
                strMessage = GUIConfig.MStringResource.GetText(TextType.Drop_User_Confirm);
            }

            //这里也可以使用普通的删除数据的方法来删除用户。
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        User.RemoveUserFromSystem(item.SubItems[1].Text, true);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    User.RemoveUserFromSystem(trvData.DatatreeView.SelectedNode.Tag.ToString(), true);
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                RefreshGUI();
            }
        }

        /// <summary>
        ///     Delete User
        /// </summary>
        private void RemoveUser()
        {
            var strTitle = "Drop User";
            var strMessage = "Are you sure to delete user(s) from this database";
            if (!GUIConfig.IsUseDefaultLanguage)
            {
                strTitle = GUIConfig.MStringResource.GetText(TextType.Drop_User);
                strMessage = GUIConfig.MStringResource.GetText(TextType.Drop_User_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        User.RemoveUserFromSystem(item.SubItems[1].Text, false);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    User.RemoveUserFromSystem(trvData.DatatreeView.SelectedNode.Tag.ToString(), false);
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                RemoveUserToolStripMenuItem.Enabled = false;
                RefreshGUI();
            }
        }

        /// <summary>
        ///     密码变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePasswordStripButton_Click(object sender, EventArgs e)
        {
//            Common.Utility.OpenForm(mDataViewInfo.strDBTag.EndsWith(ConstMgr.DATABASE_NAME_ADMIN + "/" +
//                                                                   ConstMgr.COLLECTION_NAME_USER)
//                ? new frmUser(true, lstData.SelectedItems[0].SubItems[1].Text)
//                : new frmUser(false, lstData.SelectedItems[0].SubItems[1].Text), true, true);
            OpenChangePasswordForm();
            RefreshGUI();
        }

        #endregion
    }
}