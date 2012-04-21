using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlUserView :  UserController.ctlDataView
    {
        public ctlUserView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            this.AddUserStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_AddUser);
            this.AddUserToolStripMenuItem.Text = this.AddUserStripButton.Text;
            this.ChangePasswordStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_ChangePassword);
            this.ChangePasswordToolStripMenuItem.Text = this.ChangePasswordStripButton.Text;
            this.RemoveUserStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_Operation_Database_DelUser);
            this.RemoveUserToolStripMenuItem.Text = this.RemoveUserStripButton.Text;

            AddUserStripButton.Enabled = true;
            ChangePasswordStripButton.Enabled = false;
            RemoveUserStripButton.Enabled = false;

            mDataViewInfo = _DataViewInfo;

        }

        #region"用户"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserStripButton_Click(object sender, EventArgs e)
        {
            if (IsAdminDB)
            {
                SystemManager.OpenForm(new frmUser(true));
            }
            else
            {
                SystemManager.OpenForm(new frmUser(false));
            }
            RefreshGUI(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserStripButton_Click(object sender, EventArgs e)
        {
            if (IsAdminDB)
            {
                RemoveUserFromAdminToolStripMenuItem_Click(sender, e);
            }
            else
            {
                RemoveUserToolStripMenuItem_Click(sender, e);
            }
            RefreshGUI(sender, e);
        }
        /// <summary>
        /// Drop User from Admin Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserFromAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Drop User";
            String strMessage = "Are you sure to delete user(s) from Admin Group?";
            if (!SystemManager.IsUseDefaultLanguage())
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
                        MongoDBHelper.RemoveUserFromSvr(item.SubItems[1].Text);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.RemoveUserFromSvr(trvData.DatatreeView.SelectedNode.Tag.ToString());
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                RefreshGUI(sender, e);
            }
        }
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String strTitle = "Drop User";
            String strMessage = "Are you sure to delete user(s) from this database";
            if (!SystemManager.IsUseDefaultLanguage())
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
                        MongoDBHelper.RemoveUserFromDB(item.SubItems[1].Text);
                    }
                    lstData.ContextMenuStrip = null;
                }
                else
                {
                    MongoDBHelper.RemoveUserFromDB(trvData.DatatreeView.SelectedNode.Tag.ToString());
                    trvData.DatatreeView.ContextMenuStrip = null;
                }
                RemoveUserToolStripMenuItem.Enabled = false;
                RefreshGUI(sender, e);
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
                SystemManager.OpenForm(new frmUser(true, lstData.SelectedItems[0].SubItems[1].Text));
            }
            else
            {
                SystemManager.OpenForm(new frmUser(false, lstData.SelectedItems[0].SubItems[1].Text));
            }
            RefreshGUI(sender, e);
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

        private void lstData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangePasswordStripButton_Click(sender, e);
        }
    }
}
