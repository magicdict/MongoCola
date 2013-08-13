using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlUserView : UserController.ctlDataView
    {
        public ctlUserView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            InitToolAndMenu();
            mDataViewInfo = _DataViewInfo;
            _dataShower.Add(lstData);
        }
        private void ctlUserView_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.AddUserStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
                this.AddUserToolStripMenuItem.Text = this.AddUserStripButton.Text;
                this.ChangePasswordStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_ChangePassword);
                this.ChangePasswordToolStripMenuItem.Text = this.ChangePasswordStripButton.Text;
                this.RemoveUserStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelUser);
                this.RemoveUserToolStripMenuItem.Text = this.RemoveUserStripButton.Text;
            }
            AddUserStripButton.Enabled = true;
            ChangePasswordStripButton.Enabled = false;
            RemoveUserStripButton.Enabled = false;

        }
        #region"用户"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserStripButton_Click(object sender, EventArgs e)
        {
            if (mDataViewInfo.IsAdminDB)
            {
                SystemManager.OpenForm(new frmUser(true), true, true);
            }
            else
            {
                SystemManager.OpenForm(new frmUser(false), true, true);
            }
            RefreshGUI();
        }
        /// <summary>
        /// 
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
        /// Drop User from Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserFromAdmin()
        {
            String strTitle = "Drop User";
            String strMessage = "Are you sure to delete user(s) from Admin Group?";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User_Confirm);
            }

            //这里也可以使用普通的删除数据的方法来删除用户。
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.RemoveUserFromSystem(item.SubItems[1].Text,true);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.RemoveUserFromSystem(trvData.DatatreeView.SelectedNode.Tag.ToString(),true);
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                RefreshGUI();
            }
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUser()
        {
            String strTitle = "Drop User";
            String strMessage = "Are you sure to delete user(s) from this database";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User);
                strMessage = SystemManager.mStringResource.GetText(StringResource.TextType.Drop_User_Confirm);
            }
            if (MyMessageBox.ShowConfirm(strTitle, strMessage))
            {
                if (tabDataShower.SelectedTab == tabTableView)
                {
                    //lstData
                    foreach (ListViewItem item in lstData.SelectedItems)
                    {
                        MongoDBHelper.RemoveUserFromSystem(item.SubItems[1].Text,false);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.RemoveUserFromSystem(trvData.DatatreeView.SelectedNode.Tag.ToString(), false);
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                RemoveUserToolStripMenuItem.Enabled = false;
                RefreshGUI();

            }
        }
        /// <summary>
        /// 密码变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePasswordStripButton_Click(object sender, EventArgs e)
        {
            if (mDataViewInfo.strDBTag.EndsWith(MongoDBHelper.DATABASE_NAME_ADMIN + "/" + MongoDBHelper.COLLECTION_NAME_USER))
            {
                SystemManager.OpenForm(new frmUser(true, lstData.SelectedItems[0].SubItems[1].Text), true, true);
            }
            else
            {
                SystemManager.OpenForm(new frmUser(false, lstData.SelectedItems[0].SubItems[1].Text), true, true);
            }
            RefreshGUI();

        }
        #endregion

        private void lstData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstData.SelectedItems.Count > 0 && !mDataViewInfo.IsReadOnly)
            {
                this.AddUserToolStripMenuItem.Enabled = true;
                this.AddUserStripButton.Enabled = true;

                this.RemoveUserStripButton.Enabled = true;
                this.RemoveUserToolStripMenuItem.Enabled = true;

                if (this.lstData.SelectedItems.Count == 1)
                {
                    this.ChangePasswordStripButton.Enabled = true;
                    this.ChangePasswordToolStripMenuItem.Enabled = true;
                }
            }

        }
        protected  void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangePasswordStripButton_Click(sender, e);
        }

        protected  void lstData_MouseClick(object sender, MouseEventArgs e)
        {
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            if (lstData.SelectedItems.Count > 0)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    this.contextMenuStripMain = new ContextMenuStrip();
                    this.contextMenuStripMain.Items.Add(this.AddUserToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.ChangePasswordToolStripMenuItem.Clone());
                    this.contextMenuStripMain.Items.Add(this.RemoveUserToolStripMenuItem.Clone());
                    contextMenuStripMain.Show(lstData.PointToScreen(e.Location));
                }
            }
        }
    }
}
