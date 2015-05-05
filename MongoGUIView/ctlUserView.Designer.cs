using System.ComponentModel;
using System.Windows.Forms;

namespace MongoGUIView
{
    partial class CtlUserView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddUserStripButton = new System.Windows.Forms.ToolStripButton();
            this.ChangePasswordStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveUserStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabDataShower.SuspendLayout();
            this.tabTreeView.SuspendLayout();
            this.tabTableView.SuspendLayout();
            this.tabTextView.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDataShower
            // 
            this.tabDataShower.Size = new System.Drawing.Size(917, 391);
            // 
            // tabTreeView
            // 
            this.tabTreeView.Size = new System.Drawing.Size(909, 366);
            // 
            // tabTableView
            // 
            this.tabTableView.Size = new System.Drawing.Size(909, 366);
            // 
            // trvData
            // 
            this.trvData.Size = new System.Drawing.Size(903, 360);
            // 
            // lstData
            // 
            this.lstData.Size = new System.Drawing.Size(903, 360);
            this.lstData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstData_MouseDoubleClick);
            this.lstData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstData_MouseClick);
            this.lstData.SelectedIndexChanged += new System.EventHandler(this.lstData_SelectedIndexChanged);
            // 
            // tabTextView
            // 
            this.tabTextView.Size = new System.Drawing.Size(909, 366);
            // 
            // txtData
            // 
            this.txtData.Size = new System.Drawing.Size(903, 360);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(917, 391);
            // 
            // AddUserToolStripMenuItem
            // 
            this.AddUserToolStripMenuItem.Image = global::ResourceLib.Properties.Resources.AddUserToDB;
            this.AddUserToolStripMenuItem.Name = "AddUserToolStripMenuItem";
            this.AddUserToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.AddUserToolStripMenuItem.Text = "Create User";
            this.AddUserToolStripMenuItem.Click += new System.EventHandler(this.AddUserStripButton_Click);
            // 
            // ChangePasswordToolStripMenuItem
            // 
            this.ChangePasswordToolStripMenuItem.Image = global::ResourceLib.Properties.Resources.UserPassword;
            this.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem";
            this.ChangePasswordToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ChangePasswordToolStripMenuItem.Text = "Change Password";
            this.ChangePasswordToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordStripButton_Click);
            // 
            // RemoveUserToolStripMenuItem
            // 
            this.RemoveUserToolStripMenuItem.Image = global::ResourceLib.Properties.Resources.DelUser;
            this.RemoveUserToolStripMenuItem.Name = "RemoveUserToolStripMenuItem";
            this.RemoveUserToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.RemoveUserToolStripMenuItem.Text = "Remove User";
            this.RemoveUserToolStripMenuItem.Click += new System.EventHandler(this.RemoveUserStripButton_Click);
            // 
            // AddUserStripButton
            // 
            this.AddUserStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddUserStripButton.Image = global::ResourceLib.Properties.Resources.AddUserToDB;
            this.AddUserStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddUserStripButton.Name = "AddUserStripButton";
            this.AddUserStripButton.Size = new System.Drawing.Size(23, 22);
            this.AddUserStripButton.Text = "Add User";
            this.AddUserStripButton.Click += new System.EventHandler(this.AddUserStripButton_Click);
            // 
            // ChangePasswordStripButton
            // 
            this.ChangePasswordStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChangePasswordStripButton.Image = global::ResourceLib.Properties.Resources.UserPassword;
            this.ChangePasswordStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChangePasswordStripButton.Name = "ChangePasswordStripButton";
            this.ChangePasswordStripButton.Size = new System.Drawing.Size(23, 22);
            this.ChangePasswordStripButton.Text = "ChangePassword";
            this.ChangePasswordStripButton.Click += new System.EventHandler(this.ChangePasswordStripButton_Click);
            // 
            // RemoveUserStripButton
            // 
            this.RemoveUserStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveUserStripButton.Image = global::ResourceLib.Properties.Resources.DelUser;
            this.RemoveUserStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveUserStripButton.Name = "RemoveUserStripButton";
            this.RemoveUserStripButton.Size = new System.Drawing.Size(23, 22);
            this.RemoveUserStripButton.Text = "RemoveUser";
            this.RemoveUserStripButton.Click += new System.EventHandler(this.RemoveUserStripButton_Click);
            // 
            // ctlUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsDocumentView = false;
            this.Name = "CtlUserView";
            this.Load += new System.EventHandler(this.ctlUserView_Load);
            this.Controls.SetChildIndex(this.toolStripContainer1, 0);
            this.tabDataShower.ResumeLayout(false);
            this.tabTreeView.ResumeLayout(false);
            this.tabTableView.ResumeLayout(false);
            this.tabTextView.ResumeLayout(false);
            this.tabTextView.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitToolAndMenu(){
            this.CustomtoolStrip.Items.Insert(0, RemoveUserStripButton);
            this.CustomtoolStrip.Items.Insert(0, ChangePasswordStripButton);
            this.CustomtoolStrip.Items.Insert(0, AddUserStripButton);

            this.tabDataShower.TabPages.Remove(tabTextView);
            this.tabDataShower.TabPages.Remove(tabTreeView);

            this.contextMenuStripMain.Items.Insert(0,RemoveUserToolStripMenuItem);
            this.contextMenuStripMain.Items.Insert(0,ChangePasswordToolStripMenuItem);
            this.contextMenuStripMain.Items.Insert(0,AddUserToolStripMenuItem);
        }

        private ToolStripMenuItem AddUserToolStripMenuItem;
        private ToolStripMenuItem RemoveUserToolStripMenuItem;
        private ToolStripMenuItem ChangePasswordToolStripMenuItem;
        
        private ToolStripButton AddUserStripButton;
        private ToolStripButton ChangePasswordStripButton;
        private ToolStripButton RemoveUserStripButton;
        #endregion
    }
}
