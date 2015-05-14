using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.User
{
    partial class FrmAddRole
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
            this.btnAddRole = new System.Windows.Forms.Button();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.txtRolename = new System.Windows.Forms.TextBox();
            this.lblPrivilege = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddPriviege = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbActionGroup = new System.Windows.Forms.ComboBox();
            this.chklstAction = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbResourceType = new System.Windows.Forms.ComboBox();
            this.lblResourceType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstPriviege = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(479, 451);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(174, 23);
            this.btnAddRole.TabIndex = 0;
            this.btnAddRole.Text = "Add Role";
            this.btnAddRole.UseVisualStyleBackColor = true;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Location = new System.Drawing.Point(39, 41);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(60, 13);
            this.lblRoleName.TabIndex = 1;
            this.lblRoleName.Text = "Role Name";
            // 
            // txtRolename
            // 
            this.txtRolename.Location = new System.Drawing.Point(137, 38);
            this.txtRolename.Name = "txtRolename";
            this.txtRolename.Size = new System.Drawing.Size(428, 20);
            this.txtRolename.TabIndex = 2;
            // 
            // lblPrivilege
            // 
            this.lblPrivilege.AutoSize = true;
            this.lblPrivilege.Location = new System.Drawing.Point(39, 65);
            this.lblPrivilege.Name = "lblPrivilege";
            this.lblPrivilege.Size = new System.Drawing.Size(47, 13);
            this.lblPrivilege.TabIndex = 3;
            this.lblPrivilege.Text = "Privilege";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(26, 30);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(53, 13);
            this.lblResource.TabIndex = 4;
            this.lblResource.Text = "Resource";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(26, 159);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(37, 13);
            this.lblAction.TabIndex = 5;
            this.lblAction.Text = "Action";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(162, 85);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(116, 21);
            this.cmbDatabase.TabIndex = 6;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddPriviege);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbActionGroup);
            this.groupBox1.Controls.Add(this.chklstAction);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbCollection);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbResourceType);
            this.groupBox1.Controls.Add(this.lblResourceType);
            this.groupBox1.Controls.Add(this.lblResource);
            this.groupBox1.Controls.Add(this.cmbDatabase);
            this.groupBox1.Controls.Add(this.lblAction);
            this.groupBox1.Location = new System.Drawing.Point(137, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 347);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick Privilege";
            // 
            // btnAddPriviege
            // 
            this.btnAddPriviege.Location = new System.Drawing.Point(162, 318);
            this.btnAddPriviege.Name = "btnAddPriviege";
            this.btnAddPriviege.Size = new System.Drawing.Size(145, 23);
            this.btnAddPriviege.TabIndex = 15;
            this.btnAddPriviege.Text = "Add Priviege";
            this.btnAddPriviege.UseVisualStyleBackColor = true;
            this.btnAddPriviege.Click += new System.EventHandler(this.btnAddPriviege_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Action Type Group";
            // 
            // cmbActionGroup
            // 
            this.cmbActionGroup.FormattingEnabled = true;
            this.cmbActionGroup.Location = new System.Drawing.Point(213, 169);
            this.cmbActionGroup.Name = "cmbActionGroup";
            this.cmbActionGroup.Size = new System.Drawing.Size(180, 21);
            this.cmbActionGroup.TabIndex = 13;
            this.cmbActionGroup.SelectedIndexChanged += new System.EventHandler(this.cmbActionGroup_SelectedIndexChanged);
            // 
            // chklstAction
            // 
            this.chklstAction.FormattingEnabled = true;
            this.chklstAction.Location = new System.Drawing.Point(89, 196);
            this.chklstAction.Name = "chklstAction";
            this.chklstAction.Size = new System.Drawing.Size(304, 109);
            this.chklstAction.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Collection";
            // 
            // cmbCollection
            // 
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(162, 112);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(116, 21);
            this.cmbCollection.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DataBase";
            // 
            // cmbResourceType
            // 
            this.cmbResourceType.FormattingEnabled = true;
            this.cmbResourceType.Location = new System.Drawing.Point(162, 54);
            this.cmbResourceType.Name = "cmbResourceType";
            this.cmbResourceType.Size = new System.Drawing.Size(116, 21);
            this.cmbResourceType.TabIndex = 8;
            // 
            // lblResourceType
            // 
            this.lblResourceType.AutoSize = true;
            this.lblResourceType.Location = new System.Drawing.Point(86, 60);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(31, 13);
            this.lblResourceType.TabIndex = 7;
            this.lblResourceType.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(617, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Priviege Added";
            // 
            // lstPriviege
            // 
            this.lstPriviege.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstPriviege.FullRowSelect = true;
            this.lstPriviege.GridLines = true;
            this.lstPriviege.Location = new System.Drawing.Point(614, 95);
            this.lstPriviege.Name = "lstPriviege";
            this.lstPriviege.Size = new System.Drawing.Size(401, 133);
            this.lstPriviege.TabIndex = 9;
            this.lstPriviege.UseCompatibleStateImageBehavior = false;
            this.lstPriviege.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Resource";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Action";
            this.columnHeader2.Width = 276;
            // 
            // frmAddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1049, 486);
            this.Controls.Add(this.lstPriviege);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblPrivilege);
            this.Controls.Add(this.txtRolename);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.btnAddRole);
            this.Name = "FrmAddRole";
            this.Text = "Add Custom Role";
            this.Load += new System.EventHandler(this.frmAddRole_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAddRole;
        private Label lblRoleName;
        private TextBox txtRolename;
        private Label lblPrivilege;
        private Label lblResource;
        private Label lblAction;
        private ComboBox cmbDatabase;
        private GroupBox groupBox1;
        private ComboBox cmbResourceType;
        private Label lblResourceType;
        private Label label1;
        private Label label2;
        private ComboBox cmbCollection;
        private Label label3;
        private ComboBox cmbActionGroup;
        private CheckedListBox chklstAction;
        private Button btnAddPriviege;
        private Label label4;
        private ListView lstPriviege;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}