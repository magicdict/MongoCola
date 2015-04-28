using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MongoGUICtl
{
    partial class CtlUserRolesPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpRoles = new GroupBox();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label4 = new Label();
            this.label1 = new Label();
            this.chkdbAdminAnyDatabase = new CheckBox();
            this.chkuserAdminAnyDatabase = new CheckBox();
            this.chkreadWriteAnyDatabase = new CheckBox();
            this.chkreadAnyDatabase = new CheckBox();
            this.chkclusterAdmin = new CheckBox();
            this.chkuserAdmin = new CheckBox();
            this.chkdbAdmin = new CheckBox();
            this.chkreadWrite = new CheckBox();
            this.chkread = new CheckBox();
            this.grpRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.label3);
            this.grpRoles.Controls.Add(this.label2);
            this.grpRoles.Controls.Add(this.label4);
            this.grpRoles.Controls.Add(this.label1);
            this.grpRoles.Controls.Add(this.chkdbAdminAnyDatabase);
            this.grpRoles.Controls.Add(this.chkuserAdminAnyDatabase);
            this.grpRoles.Controls.Add(this.chkreadWriteAnyDatabase);
            this.grpRoles.Controls.Add(this.chkreadAnyDatabase);
            this.grpRoles.Controls.Add(this.chkclusterAdmin);
            this.grpRoles.Controls.Add(this.chkuserAdmin);
            this.grpRoles.Controls.Add(this.chkdbAdmin);
            this.grpRoles.Controls.Add(this.chkreadWrite);
            this.grpRoles.Controls.Add(this.chkread);
            this.grpRoles.Location = new Point(3, 3);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new Size(348, 176);
            this.grpRoles.TabIndex = 10;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Roles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(21, 74);
            this.label3.Name = "label3";
            this.label3.Size = new Size(151, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Database Administration Roles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(21, 127);
            this.label2.Name = "label2";
            this.label2.Size = new Size(102, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Administrative Roles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(21, 24);
            this.label4.Name = "label4";
            this.label4.Size = new Size(108, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Database User Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(180, 24);
            this.label1.Name = "label1";
            this.label1.Size = new Size(104, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Any Database Roles";
            // 
            // chkdbAdminAnyDatabase
            // 
            this.chkdbAdminAnyDatabase.AutoSize = true;
            this.chkdbAdminAnyDatabase.Location = new Point(194, 109);
            this.chkdbAdminAnyDatabase.Name = "chkdbAdminAnyDatabase";
            this.chkdbAdminAnyDatabase.Size = new Size(131, 17);
            this.chkdbAdminAnyDatabase.TabIndex = 14;
            this.chkdbAdminAnyDatabase.Text = "dbAdminAnyDatabase";
            this.chkdbAdminAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkuserAdminAnyDatabase
            // 
            this.chkuserAdminAnyDatabase.AutoSize = true;
            this.chkuserAdminAnyDatabase.Location = new Point(194, 86);
            this.chkuserAdminAnyDatabase.Name = "chkuserAdminAnyDatabase";
            this.chkuserAdminAnyDatabase.Size = new Size(139, 17);
            this.chkuserAdminAnyDatabase.TabIndex = 13;
            this.chkuserAdminAnyDatabase.Text = "userAdminAnyDatabase";
            this.chkuserAdminAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkreadWriteAnyDatabase
            // 
            this.chkreadWriteAnyDatabase.AutoSize = true;
            this.chkreadWriteAnyDatabase.Location = new Point(194, 63);
            this.chkreadWriteAnyDatabase.Name = "chkreadWriteAnyDatabase";
            this.chkreadWriteAnyDatabase.Size = new Size(136, 17);
            this.chkreadWriteAnyDatabase.TabIndex = 12;
            this.chkreadWriteAnyDatabase.Text = "readWriteAnyDatabase";
            this.chkreadWriteAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkreadAnyDatabase
            // 
            this.chkreadAnyDatabase.AutoSize = true;
            this.chkreadAnyDatabase.Location = new Point(194, 40);
            this.chkreadAnyDatabase.Name = "chkreadAnyDatabase";
            this.chkreadAnyDatabase.Size = new Size(111, 17);
            this.chkreadAnyDatabase.TabIndex = 11;
            this.chkreadAnyDatabase.Text = "readAnyDatabase";
            this.chkreadAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkclusterAdmin
            // 
            this.chkclusterAdmin.AutoSize = true;
            this.chkclusterAdmin.Location = new Point(35, 143);
            this.chkclusterAdmin.Name = "chkclusterAdmin";
            this.chkclusterAdmin.Size = new Size(86, 17);
            this.chkclusterAdmin.TabIndex = 10;
            this.chkclusterAdmin.Text = "clusterAdmin";
            this.chkclusterAdmin.UseVisualStyleBackColor = true;
            // 
            // chkuserAdmin
            // 
            this.chkuserAdmin.AutoSize = true;
            this.chkuserAdmin.Location = new Point(35, 107);
            this.chkuserAdmin.Name = "chkuserAdmin";
            this.chkuserAdmin.Size = new Size(75, 17);
            this.chkuserAdmin.TabIndex = 10;
            this.chkuserAdmin.Text = "userAdmin";
            this.chkuserAdmin.UseVisualStyleBackColor = true;
            // 
            // chkdbAdmin
            // 
            this.chkdbAdmin.AutoSize = true;
            this.chkdbAdmin.Location = new Point(35, 90);
            this.chkdbAdmin.Name = "chkdbAdmin";
            this.chkdbAdmin.Size = new Size(67, 17);
            this.chkdbAdmin.TabIndex = 10;
            this.chkdbAdmin.Text = "dbAdmin";
            this.chkdbAdmin.UseVisualStyleBackColor = true;
            // 
            // chkreadWrite
            // 
            this.chkreadWrite.AutoSize = true;
            this.chkreadWrite.Location = new Point(35, 54);
            this.chkreadWrite.Name = "chkreadWrite";
            this.chkreadWrite.Size = new Size(72, 17);
            this.chkreadWrite.TabIndex = 10;
            this.chkreadWrite.Text = "readWrite";
            this.chkreadWrite.UseVisualStyleBackColor = true;
            // 
            // chkread
            // 
            this.chkread.AutoSize = true;
            this.chkread.Location = new Point(35, 40);
            this.chkread.Name = "chkread";
            this.chkread.Size = new Size(47, 17);
            this.chkread.TabIndex = 10;
            this.chkread.Text = "read";
            this.chkread.UseVisualStyleBackColor = true;
            // 
            // UserRolesPanel
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.grpRoles);
            this.Name = "UserRolesPanel";
            this.Size = new Size(359, 183);
            this.grpRoles.ResumeLayout(false);
            this.grpRoles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpRoles;
        private CheckBox chkclusterAdmin;
        private CheckBox chkuserAdmin;
        private CheckBox chkdbAdmin;
        private CheckBox chkreadWrite;
        private CheckBox chkread;
        private Label label1;
        private CheckBox chkdbAdminAnyDatabase;
        private CheckBox chkuserAdminAnyDatabase;
        private CheckBox chkreadWriteAnyDatabase;
        private CheckBox chkreadAnyDatabase;
        private Label label3;
        private Label label2;
        private Label label4;
    }
}
