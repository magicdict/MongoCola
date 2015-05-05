using System;
using System.Windows.Forms;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.Method;
using ResourceLib.UI;

namespace MongoGUIView
{
    public partial class CtlUserView : CtlDataView
    {
        public CtlUserView(DataViewInfo dataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            MDataViewInfo = dataViewInfo;
            DataShower.Add(lstData);
        }

        private void ctlUserView_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                AddUserStripButton.Text = GuiConfig.GetText(TextType.MainMenuOperationDatabaseAddUser);
                AddUserToolStripMenuItem.Text = AddUserStripButton.Text;
                ChangePasswordStripButton.Text = GuiConfig.GetText(TextType.CommonChangePassword);
                ChangePasswordToolStripMenuItem.Text = ChangePasswordStripButton.Text;
                RemoveUserStripButton.Text = GuiConfig.GetText(TextType.MainMenuOperationDatabaseDelUser);
                RemoveUserToolStripMenuItem.Text = RemoveUserStripButton.Text;
            }
            AddUserStripButton.Enabled = true;
            ChangePasswordStripButton.Enabled = false;
            RemoveUserStripButton.Enabled = false;
        }

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0 && !MDataViewInfo.IsReadOnly)
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
            RuntimeMongoDbContext.SelectObjectTag = MDataViewInfo.StrDbTag;
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
            RefreshGui();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserStripButton_Click(object sender, EventArgs e)
        {
            if (MDataViewInfo.IsAdminDb)
            {
                RemoveUserFromAdmin();
            }
            else
            {
                RemoveUser();
            }
            RefreshGui();
        }

        /// <summary>
        ///     Drop User from Admin Group
        /// </summary>
        private void RemoveUserFromAdmin()
        {
            var strTitle = "Drop User";
            var strMessage = "Are you sure to delete user(s) from Admin Group?";
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.DropUser);
                strMessage = GuiConfig.GetText(TextType.DropUserConfirm);
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
                RefreshGui();
            }
        }

        /// <summary>
        ///     Delete User
        /// </summary>
        private void RemoveUser()
        {
            var strTitle = "Drop User";
            var strMessage = "Are you sure to delete user(s) from this database";
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                strTitle = GuiConfig.GetText(TextType.DropUser);
                strMessage = GuiConfig.GetText(TextType.DropUserConfirm);
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
                RefreshGui();
            }
        }

        /// <summary>
        ///     密码变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePasswordStripButton_Click(object sender, EventArgs e)
        {
            //            Common.MongoHelper.OpenForm(mDataViewInfo.strDBTag.EndsWith(ConstMgr.DATABASE_NAME_ADMIN + "/" +
            //                                                                   ConstMgr.COLLECTION_NAME_USER)
            //                ? new frmUser(true, lstData.SelectedItems[0].SubItems[1].Text)
            //                : new frmUser(false, lstData.SelectedItems[0].SubItems[1].Text), true, true);
            OpenChangePasswordForm();
            RefreshGui();
        }

        #endregion
    }
}