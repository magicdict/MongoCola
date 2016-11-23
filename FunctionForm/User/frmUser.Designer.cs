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
            this.btnPickRole = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPickDoc = new System.Windows.Forms.Button();
            this.lblcustomDocument = new System.Windows.Forms.Label();
            this.lstRoles = new System.Windows.Forms.ListView();
            this.colRoles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(74, 421);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(110, 30);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Tag = "Common.Ok";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(190, 421);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(110, 30);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Tag = "Common.Cancel";
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
            this.lblUserName.Size = new System.Drawing.Size(66, 15);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Tag = "Common.Username";
            this.lblUserName.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Location = new System.Drawing.Point(28, 46);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(93, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Tag = "Common.Password";
            this.lblPassword.Text = "New Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(145, 15);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(170, 23);
            this.txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(145, 43);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(170, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPsw
            // 
            this.lblConfirmPsw.AutoSize = true;
            this.lblConfirmPsw.Location = new System.Drawing.Point(28, 73);
            this.lblConfirmPsw.Name = "lblConfirmPsw";
            this.lblConfirmPsw.Size = new System.Drawing.Size(113, 15);
            this.lblConfirmPsw.TabIndex = 8;
            this.lblConfirmPsw.Tag = "Common.ConfirmPassword";
            this.lblConfirmPsw.Text = "Confirm Password";
            // 
            // txtConfirmPsw
            // 
            this.txtConfirmPsw.Location = new System.Drawing.Point(145, 69);
            this.txtConfirmPsw.Name = "txtConfirmPsw";
            this.txtConfirmPsw.Size = new System.Drawing.Size(170, 23);
            this.txtConfirmPsw.TabIndex = 2;
            this.txtConfirmPsw.UseSystemPasswordChar = true;
            // 
            // btnPickRole
            // 
            this.btnPickRole.Location = new System.Drawing.Point(145, 179);
            this.btnPickRole.Name = "btnPickRole";
            this.btnPickRole.Size = new System.Drawing.Size(110, 30);
            this.btnPickRole.TabIndex = 9;
            this.btnPickRole.Text = "Pick Roles";
            this.btnPickRole.UseVisualStyleBackColor = true;
            this.btnPickRole.Click += new System.EventHandler(this.btnPickRole_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 10;
            this.label1.Tag = "Common.Roles";
            this.label1.Text = "Roles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 10;
            this.label2.Tag = "Common.CustomData";
            this.label2.Text = "customData";
            // 
            // btnPickDoc
            // 
            this.btnPickDoc.Location = new System.Drawing.Point(145, 98);
            this.btnPickDoc.Name = "btnPickDoc";
            this.btnPickDoc.Size = new System.Drawing.Size(110, 30);
            this.btnPickDoc.TabIndex = 12;
            this.btnPickDoc.Text = "Pick Document";
            this.btnPickDoc.UseVisualStyleBackColor = true;
            this.btnPickDoc.Click += new System.EventHandler(this.btnPickDoc_Click);
            // 
            // lblcustomDocument
            // 
            this.lblcustomDocument.AutoSize = true;
            this.lblcustomDocument.Location = new System.Drawing.Point(28, 134);
            this.lblcustomDocument.Name = "lblcustomDocument";
            this.lblcustomDocument.Size = new System.Drawing.Size(120, 15);
            this.lblcustomDocument.TabIndex = 11;
            this.lblcustomDocument.Text = "customDocument：";
            // 
            // lstRoles
            // 
            this.lstRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRoles,
            this.colDataBase});
            this.lstRoles.FullRowSelect = true;
            this.lstRoles.GridLines = true;
            this.lstRoles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lstRoles.Location = new System.Drawing.Point(31, 215);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(327, 167);
            this.lstRoles.TabIndex = 28;
            this.lstRoles.UseCompatibleStateImageBehavior = false;
            this.lstRoles.View = System.Windows.Forms.View.Details;
            // 
            // colRoles
            // 
            this.colRoles.Text = "Roles";
            this.colRoles.Width = 130;
            // 
            // colDataBase
            // 
            this.colDataBase.Text = "DataBase";
            this.colDataBase.Width = 275;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 470);
            this.Controls.Add(this.lstRoles);
            this.Controls.Add(this.btnPickDoc);
            this.Controls.Add(this.lblcustomDocument);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPickRole);
            this.Controls.Add(this.txtConfirmPsw);
            this.Controls.Add(this.lblConfirmPsw);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Main_Menu.Operation_Database_AddUser";
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
        private Button btnPickRole;
        private Label label1;
        private Label label2;
        private Button btnPickDoc;
        private Label lblcustomDocument;
        private ListView lstRoles;
        private ColumnHeader colRoles;
        private ColumnHeader colDataBase;
    }
}