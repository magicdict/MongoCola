using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Windows.Forms;

namespace MongoGUIView
{
    public partial class CtlUserView : CtlDataView
    {
        public CtlUserView(DataViewInfo dataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            mDataViewInfo = dataViewInfo;
            DataShower.Add(lstData);
        }

        private void ctlUserView_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                AddUserStripButton.Text = GuiConfig.GetText("MainMenu.OperationDatabaseAddUser");
                AddUserToolStripMenuItem.Text = AddUserStripButton.Text;
                ChangePasswordStripButton.Text = GuiConfig.GetText("Change Password", "CommonChangePassword");
                ChangePasswordToolStripMenuItem.Text = ChangePasswordStripButton.Text;
                RemoveUserStripButton.Text = GuiConfig.GetText("MainMenu.OperationDatabaseDelUser");
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
            RuntimeMongoDbContext.SelectObjectTag = mDataViewInfo.strCollectionPath;
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
        public static Action<bool> OpenAddNewUserForm;

        /// <summary>
        ///     更改密码
        /// </summary>
        public static Action<bool, string> OpenChangePasswordForm;

        /// <summary>
        ///     是否为Admin
        /// </summary>
        public bool isAdmin
        {
            get
            {
                return RuntimeMongoDbContext.GetCurrentDataBaseName() == ConstMgr.DatabaseNameAdmin;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserStripButton_Click(object sender, EventArgs e)
        {
            OpenAddNewUserForm(isAdmin);
            RefreshGui();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserStripButton_Click(object sender, EventArgs e)
        {
            if (mDataViewInfo.IsAdminDb)
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
            var strTitle = GuiConfig.GetText("Drop User", "DropUser");
            var strMessage = GuiConfig.GetText("Are you sure to delete user(s) from Admin Group?", "DropUserConfirm");

            //这里也可以使用普通的删除数据的方法来删除用户。
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoUserEx.RemoveUserFromSystem(item.SubItems[1].Text, true);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoUserEx.RemoveUserFromSystem(trvData.DatatreeView.SelectedNode.Tag.ToString(), true);
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
            var strTitle = GuiConfig.GetText("Drop User", "DropUser");
            var strMessage = GuiConfig.GetText("Are you sure to delete user(s) from this database", "DropUserConfirm");
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoUserEx.RemoveUserFromSystem(item.SubItems[1].Text, false);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoUserEx.RemoveUserFromSystem(trvData.DatatreeView.SelectedNode.Tag.ToString(), false);
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
            if (lstData.SelectedItems.Count != 1) return;
            OpenChangePasswordForm(isAdmin, lstData.SelectedItems[0].SubItems[1].Text);
            RefreshGui();
        }

        #endregion
    }
}