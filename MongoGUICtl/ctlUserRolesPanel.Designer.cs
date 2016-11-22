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
            this.grpRoles = new System.Windows.Forms.GroupBox();
            this.chkroot = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkrestore = new System.Windows.Forms.CheckBox();
            this.chkbackup = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkdbOwner = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkdbAdminAnyDatabase = new System.Windows.Forms.CheckBox();
            this.chkuserAdminAnyDatabase = new System.Windows.Forms.CheckBox();
            this.chkreadWriteAnyDatabase = new System.Windows.Forms.CheckBox();
            this.chkreadAnyDatabase = new System.Windows.Forms.CheckBox();
            this.chkhostManager = new System.Windows.Forms.CheckBox();
            this.chkclusterMonitor = new System.Windows.Forms.CheckBox();
            this.chkclusterManager = new System.Windows.Forms.CheckBox();
            this.chkclusterAdmin = new System.Windows.Forms.CheckBox();
            this.chkuserAdmin = new System.Windows.Forms.CheckBox();
            this.chkdbAdmin = new System.Windows.Forms.CheckBox();
            this.chkreadWrite = new System.Windows.Forms.CheckBox();
            this.chkread = new System.Windows.Forms.CheckBox();
            this.grpRoles.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRoles
            // 
            this.grpRoles.Controls.Add(this.chkroot);
            this.grpRoles.Controls.Add(this.label6);
            this.grpRoles.Controls.Add(this.chkrestore);
            this.grpRoles.Controls.Add(this.chkbackup);
            this.grpRoles.Controls.Add(this.label5);
            this.grpRoles.Controls.Add(this.chkdbOwner);
            this.grpRoles.Controls.Add(this.label3);
            this.grpRoles.Controls.Add(this.label2);
            this.grpRoles.Controls.Add(this.label4);
            this.grpRoles.Controls.Add(this.label1);
            this.grpRoles.Controls.Add(this.chkdbAdminAnyDatabase);
            this.grpRoles.Controls.Add(this.chkuserAdminAnyDatabase);
            this.grpRoles.Controls.Add(this.chkreadWriteAnyDatabase);
            this.grpRoles.Controls.Add(this.chkreadAnyDatabase);
            this.grpRoles.Controls.Add(this.chkhostManager);
            this.grpRoles.Controls.Add(this.chkclusterMonitor);
            this.grpRoles.Controls.Add(this.chkclusterManager);
            this.grpRoles.Controls.Add(this.chkclusterAdmin);
            this.grpRoles.Controls.Add(this.chkuserAdmin);
            this.grpRoles.Controls.Add(this.chkdbAdmin);
            this.grpRoles.Controls.Add(this.chkreadWrite);
            this.grpRoles.Controls.Add(this.chkread);
            this.grpRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoles.Location = new System.Drawing.Point(0, 0);
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Size = new System.Drawing.Size(398, 265);
            this.grpRoles.TabIndex = 10;
            this.grpRoles.TabStop = false;
            this.grpRoles.Text = "Roles";
            // 
            // chkroot
            // 
            this.chkroot.AutoSize = true;
            this.chkroot.Location = new System.Drawing.Point(35, 237);
            this.chkroot.Name = "chkroot";
            this.chkroot.Size = new System.Drawing.Size(48, 16);
            this.chkroot.TabIndex = 21;
            this.chkroot.Text = "root";
            this.chkroot.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "Superuser Roles";
            // 
            // chkrestore
            // 
            this.chkrestore.AutoSize = true;
            this.chkrestore.Location = new System.Drawing.Point(35, 180);
            this.chkrestore.Name = "chkrestore";
            this.chkrestore.Size = new System.Drawing.Size(66, 16);
            this.chkrestore.TabIndex = 18;
            this.chkrestore.Text = "restore";
            this.chkrestore.UseVisualStyleBackColor = true;
            // 
            // chkbackup
            // 
            this.chkbackup.AutoSize = true;
            this.chkbackup.Location = new System.Drawing.Point(35, 165);
            this.chkbackup.Name = "chkbackup";
            this.chkbackup.Size = new System.Drawing.Size(60, 16);
            this.chkbackup.TabIndex = 19;
            this.chkbackup.Text = "backup";
            this.chkbackup.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "Backup and Restoration Roles";
            // 
            // chkdbOwner
            // 
            this.chkdbOwner.AutoSize = true;
            this.chkdbOwner.Location = new System.Drawing.Point(35, 106);
            this.chkdbOwner.Name = "chkdbOwner";
            this.chkdbOwner.Size = new System.Drawing.Size(66, 16);
            this.chkdbOwner.TabIndex = 16;
            this.chkdbOwner.Text = "dbOwner";
            this.chkdbOwner.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Database Administration Roles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Administrative Roles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "Database User Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "Any Database Roles";
            // 
            // chkdbAdminAnyDatabase
            // 
            this.chkdbAdminAnyDatabase.AutoSize = true;
            this.chkdbAdminAnyDatabase.Location = new System.Drawing.Point(239, 102);
            this.chkdbAdminAnyDatabase.Name = "chkdbAdminAnyDatabase";
            this.chkdbAdminAnyDatabase.Size = new System.Drawing.Size(132, 16);
            this.chkdbAdminAnyDatabase.TabIndex = 14;
            this.chkdbAdminAnyDatabase.Text = "dbAdminAnyDatabase";
            this.chkdbAdminAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkuserAdminAnyDatabase
            // 
            this.chkuserAdminAnyDatabase.AutoSize = true;
            this.chkuserAdminAnyDatabase.Location = new System.Drawing.Point(239, 80);
            this.chkuserAdminAnyDatabase.Name = "chkuserAdminAnyDatabase";
            this.chkuserAdminAnyDatabase.Size = new System.Drawing.Size(144, 16);
            this.chkuserAdminAnyDatabase.TabIndex = 13;
            this.chkuserAdminAnyDatabase.Text = "userAdminAnyDatabase";
            this.chkuserAdminAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkreadWriteAnyDatabase
            // 
            this.chkreadWriteAnyDatabase.AutoSize = true;
            this.chkreadWriteAnyDatabase.Location = new System.Drawing.Point(239, 59);
            this.chkreadWriteAnyDatabase.Name = "chkreadWriteAnyDatabase";
            this.chkreadWriteAnyDatabase.Size = new System.Drawing.Size(144, 16);
            this.chkreadWriteAnyDatabase.TabIndex = 12;
            this.chkreadWriteAnyDatabase.Text = "readWriteAnyDatabase";
            this.chkreadWriteAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkreadAnyDatabase
            // 
            this.chkreadAnyDatabase.AutoSize = true;
            this.chkreadAnyDatabase.Location = new System.Drawing.Point(239, 38);
            this.chkreadAnyDatabase.Name = "chkreadAnyDatabase";
            this.chkreadAnyDatabase.Size = new System.Drawing.Size(114, 16);
            this.chkreadAnyDatabase.TabIndex = 11;
            this.chkreadAnyDatabase.Text = "readAnyDatabase";
            this.chkreadAnyDatabase.UseVisualStyleBackColor = true;
            // 
            // chkhostManager
            // 
            this.chkhostManager.AutoSize = true;
            this.chkhostManager.Location = new System.Drawing.Point(239, 198);
            this.chkhostManager.Name = "chkhostManager";
            this.chkhostManager.Size = new System.Drawing.Size(90, 16);
            this.chkhostManager.TabIndex = 10;
            this.chkhostManager.Text = "hostManager";
            this.chkhostManager.UseVisualStyleBackColor = true;
            // 
            // chkclusterMonitor
            // 
            this.chkclusterMonitor.AutoSize = true;
            this.chkclusterMonitor.Location = new System.Drawing.Point(239, 180);
            this.chkclusterMonitor.Name = "chkclusterMonitor";
            this.chkclusterMonitor.Size = new System.Drawing.Size(108, 16);
            this.chkclusterMonitor.TabIndex = 10;
            this.chkclusterMonitor.Text = "clusterMonitor";
            this.chkclusterMonitor.UseVisualStyleBackColor = true;
            // 
            // chkclusterManager
            // 
            this.chkclusterManager.AutoSize = true;
            this.chkclusterManager.Location = new System.Drawing.Point(239, 159);
            this.chkclusterManager.Name = "chkclusterManager";
            this.chkclusterManager.Size = new System.Drawing.Size(108, 16);
            this.chkclusterManager.TabIndex = 10;
            this.chkclusterManager.Text = "clusterManager";
            this.chkclusterManager.UseVisualStyleBackColor = true;
            // 
            // chkclusterAdmin
            // 
            this.chkclusterAdmin.AutoSize = true;
            this.chkclusterAdmin.Location = new System.Drawing.Point(239, 139);
            this.chkclusterAdmin.Name = "chkclusterAdmin";
            this.chkclusterAdmin.Size = new System.Drawing.Size(96, 16);
            this.chkclusterAdmin.TabIndex = 10;
            this.chkclusterAdmin.Text = "clusterAdmin";
            this.chkclusterAdmin.UseVisualStyleBackColor = true;
            // 
            // chkuserAdmin
            // 
            this.chkuserAdmin.AutoSize = true;
            this.chkuserAdmin.Location = new System.Drawing.Point(35, 125);
            this.chkuserAdmin.Name = "chkuserAdmin";
            this.chkuserAdmin.Size = new System.Drawing.Size(78, 16);
            this.chkuserAdmin.TabIndex = 10;
            this.chkuserAdmin.Text = "userAdmin";
            this.chkuserAdmin.UseVisualStyleBackColor = true;
            // 
            // chkdbAdmin
            // 
            this.chkdbAdmin.AutoSize = true;
            this.chkdbAdmin.Location = new System.Drawing.Point(35, 88);
            this.chkdbAdmin.Name = "chkdbAdmin";
            this.chkdbAdmin.Size = new System.Drawing.Size(66, 16);
            this.chkdbAdmin.TabIndex = 10;
            this.chkdbAdmin.Text = "dbAdmin";
            this.chkdbAdmin.UseVisualStyleBackColor = true;
            // 
            // chkreadWrite
            // 
            this.chkreadWrite.AutoSize = true;
            this.chkreadWrite.Location = new System.Drawing.Point(35, 52);
            this.chkreadWrite.Name = "chkreadWrite";
            this.chkreadWrite.Size = new System.Drawing.Size(78, 16);
            this.chkreadWrite.TabIndex = 10;
            this.chkreadWrite.Text = "readWrite";
            this.chkreadWrite.UseVisualStyleBackColor = true;
            // 
            // chkread
            // 
            this.chkread.AutoSize = true;
            this.chkread.Location = new System.Drawing.Point(35, 37);
            this.chkread.Name = "chkread";
            this.chkread.Size = new System.Drawing.Size(48, 16);
            this.chkread.TabIndex = 10;
            this.chkread.Text = "read";
            this.chkread.UseVisualStyleBackColor = true;
            // 
            // CtlUserRolesPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpRoles);
            this.Name = "CtlUserRolesPanel";
            this.Size = new System.Drawing.Size(398, 265);
            this.Load += new System.EventHandler(this.CtlUserRolesPanel_Load);
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
        private CheckBox chkdbOwner;
        private CheckBox chkhostManager;
        private CheckBox chkclusterMonitor;
        private CheckBox chkclusterManager;
        private CheckBox chkrestore;
        private CheckBox chkbackup;
        private Label label5;
        private Label label6;
        private CheckBox chkroot;
    }
}
