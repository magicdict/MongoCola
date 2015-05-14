using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.User
{
    partial class FrmUser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUser));
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPsw = new System.Windows.Forms.Label();
            this.txtConfirmPsw = new System.Windows.Forms.TextBox();
            this.lbluserSource = new System.Windows.Forms.Label();
            this.txtuserSource = new System.Windows.Forms.TextBox();
            this.lblotherDBRoles = new System.Windows.Forms.Label();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.cmdAddRole = new System.Windows.Forms.Button();
            this.lstOtherRoles = new System.Windows.Forms.ListView();
            this.colDataBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRoles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userRoles = new CtlUserRolesPanel();
            this.cmdDelRole = new System.Windows.Forms.Button();
            this.cmdModifyRole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(85, 363);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(96, 26);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(222, 363);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(117, 26);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Location = new System.Drawing.Point(28, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 15);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(28, 46);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(89, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "New Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(136, 15);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(170, 21);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 43);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(170, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPsw
            // 
            this.lblConfirmPsw.AutoSize = true;
            this.lblConfirmPsw.Location = new System.Drawing.Point(28, 73);
            this.lblConfirmPsw.Name = "lblConfirmPsw";
            this.lblConfirmPsw.Size = new System.Drawing.Size(107, 15);
            this.lblConfirmPsw.TabIndex = 8;
            this.lblConfirmPsw.Text = "Confirm Password";
            // 
            // txtConfirmPsw
            // 
            this.txtConfirmPsw.Location = new System.Drawing.Point(136, 69);
            this.txtConfirmPsw.Name = "txtConfirmPsw";
            this.txtConfirmPsw.Size = new System.Drawing.Size(170, 21);
            this.txtConfirmPsw.TabIndex = 2;
            this.txtConfirmPsw.UseSystemPasswordChar = true;
            // 
            // lbluserSource
            // 
            this.lbluserSource.AutoSize = true;
            this.lbluserSource.Location = new System.Drawing.Point(28, 325);
            this.lbluserSource.Name = "lbluserSource";
            this.lbluserSource.Size = new System.Drawing.Size(70, 15);
            this.lbluserSource.TabIndex = 10;
            this.lbluserSource.Text = "userSource";
            // 
            // txtuserSource
            // 
            this.txtuserSource.Location = new System.Drawing.Point(136, 319);
            this.txtuserSource.Name = "txtuserSource";
            this.txtuserSource.Size = new System.Drawing.Size(170, 21);
            this.txtuserSource.TabIndex = 11;
            // 
            // lblotherDBRoles
            // 
            this.lblotherDBRoles.AutoSize = true;
            this.lblotherDBRoles.Location = new System.Drawing.Point(433, 18);
            this.lblotherDBRoles.Name = "lblotherDBRoles";
            this.lblotherDBRoles.Size = new System.Drawing.Size(84, 15);
            this.lblotherDBRoles.TabIndex = 12;
            this.lblotherDBRoles.Text = "otherDBRoles";
            // 
            // cmbDB
            // 
            this.cmbDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(470, 64);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(152, 23);
            this.cmbDB.TabIndex = 13;
            // 
            // cmdAddRole
            // 
            this.cmdAddRole.Location = new System.Drawing.Point(628, 64);
            this.cmdAddRole.Name = "cmdAddRole";
            this.cmdAddRole.Size = new System.Drawing.Size(92, 24);
            this.cmdAddRole.TabIndex = 14;
            this.cmdAddRole.Text = "Add Role";
            this.cmdAddRole.UseVisualStyleBackColor = true;
            this.cmdAddRole.Click += new System.EventHandler(this.cmdAddRole_Click);
            // 
            // lstOtherRoles
            // 
            this.lstOtherRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDataBase,
            this.colRoles});
            this.lstOtherRoles.FullRowSelect = true;
            this.lstOtherRoles.GridLines = true;
            this.lstOtherRoles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lstOtherRoles.Location = new System.Drawing.Point(436, 108);
            this.lstOtherRoles.Name = "lstOtherRoles";
            this.lstOtherRoles.Size = new System.Drawing.Size(426, 225);
            this.lstOtherRoles.TabIndex = 15;
            this.lstOtherRoles.UseCompatibleStateImageBehavior = false;
            this.lstOtherRoles.View = System.Windows.Forms.View.Details;
            // 
            // colDataBase
            // 
            this.colDataBase.Text = "DataBase";
            this.colDataBase.Width = 105;
            // 
            // colRoles
            // 
            this.colRoles.Text = "Roles";
            this.colRoles.Width = 229;
            // 
            // userRoles
            // 
            this.userRoles.Location = new System.Drawing.Point(12, 96);
            this.userRoles.Name = "userRoles";
            this.userRoles.Size = new System.Drawing.Size(418, 217);
            this.userRoles.TabIndex = 9;
            // 
            // cmdDelRole
            // 
            this.cmdDelRole.Location = new System.Drawing.Point(611, 339);
            this.cmdDelRole.Name = "cmdDelRole";
            this.cmdDelRole.Size = new System.Drawing.Size(92, 24);
            this.cmdDelRole.TabIndex = 14;
            this.cmdDelRole.Text = "Delete Role";
            this.cmdDelRole.UseVisualStyleBackColor = true;
            this.cmdDelRole.Click += new System.EventHandler(this.cmdDelRole_Click);
            // 
            // cmdModifyRole
            // 
            this.cmdModifyRole.Location = new System.Drawing.Point(709, 340);
            this.cmdModifyRole.Name = "cmdModifyRole";
            this.cmdModifyRole.Size = new System.Drawing.Size(109, 23);
            this.cmdModifyRole.TabIndex = 16;
            this.cmdModifyRole.Text = "Modify Role";
            this.cmdModifyRole.UseVisualStyleBackColor = true;
            this.cmdModifyRole.Click += new System.EventHandler(this.cmdModifyRole_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 405);
            this.Controls.Add(this.cmdModifyRole);
            this.Controls.Add(this.lstOtherRoles);
            this.Controls.Add(this.cmdDelRole);
            this.Controls.Add(this.cmdAddRole);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.lblotherDBRoles);
            this.Controls.Add(this.txtuserSource);
            this.Controls.Add(this.lbluserSource);
            this.Controls.Add(this.userRoles);
            this.Controls.Add(this.txtConfirmPsw);
            this.Controls.Add(this.lblConfirmPsw);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdOK;
        private Label lblPassword;
        private Label lblUserName;
        private Button cmdCancel;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label lblConfirmPsw;
        private TextBox txtConfirmPsw;
        private CtlUserRolesPanel userRoles;
        private Label lbluserSource;
        private TextBox txtuserSource;
        private Label lblotherDBRoles;
        private ComboBox cmbDB;
        private Button cmdAddRole;
        private ListView lstOtherRoles;
        private ColumnHeader colDataBase;
        private ColumnHeader colRoles;
        private Button cmdDelRole;
        private Button cmdModifyRole;
    }
}