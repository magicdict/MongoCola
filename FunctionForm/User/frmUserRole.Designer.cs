using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.User
{
    partial class FrmUserRole
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdModifyRole = new System.Windows.Forms.Button();
            this.lstRoles = new System.Windows.Forms.ListView();
            this.colRoles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdDelRole = new System.Windows.Forms.Button();
            this.cmdAddRole = new System.Windows.Forms.Button();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.otherDBRolesPanel = new MongoGUICtl.CtlUserRolesPanel();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(252, 600);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 30);
            this.cmdOK.TabIndex = 1;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(345, 600);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 30);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Tag = "Common.Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "DataBase";
            // 
            // cmdModifyRole
            // 
            this.cmdModifyRole.Location = new System.Drawing.Point(39, 600);
            this.cmdModifyRole.Name = "cmdModifyRole";
            this.cmdModifyRole.Size = new System.Drawing.Size(109, 32);
            this.cmdModifyRole.TabIndex = 28;
            this.cmdModifyRole.Text = "Modify Role";
            this.cmdModifyRole.UseVisualStyleBackColor = true;
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
            this.lstRoles.Location = new System.Drawing.Point(17, 420);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(449, 167);
            this.lstRoles.TabIndex = 27;
            this.lstRoles.UseCompatibleStateImageBehavior = false;
            this.lstRoles.View = System.Windows.Forms.View.Details;
            // 
            // colRoles
            // 
            this.colRoles.Text = "Roles";
            this.colRoles.Width = 312;
            // 
            // colDataBase
            // 
            this.colDataBase.Text = "DataBase";
            this.colDataBase.Width = 105;
            // 
            // cmdDelRole
            // 
            this.cmdDelRole.Location = new System.Drawing.Point(154, 600);
            this.cmdDelRole.Name = "cmdDelRole";
            this.cmdDelRole.Size = new System.Drawing.Size(92, 33);
            this.cmdDelRole.TabIndex = 25;
            this.cmdDelRole.Text = "Delete Role";
            this.cmdDelRole.UseVisualStyleBackColor = true;
            // 
            // cmdAddRole
            // 
            this.cmdAddRole.Location = new System.Drawing.Point(357, 380);
            this.cmdAddRole.Name = "cmdAddRole";
            this.cmdAddRole.Size = new System.Drawing.Size(92, 27);
            this.cmdAddRole.TabIndex = 26;
            this.cmdAddRole.Text = "Add Role";
            this.cmdAddRole.UseVisualStyleBackColor = true;
            this.cmdAddRole.Click += new System.EventHandler(this.cmdAddRole_Click);
            // 
            // cmbDB
            // 
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(102, 381);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(249, 25);
            this.cmbDB.TabIndex = 24;
            // 
            // otherDBRolesPanel
            // 
            this.otherDBRolesPanel.Location = new System.Drawing.Point(17, 7);
            this.otherDBRolesPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.otherDBRolesPanel.Name = "otherDBRolesPanel";
            this.otherDBRolesPanel.Size = new System.Drawing.Size(449, 366);
            this.otherDBRolesPanel.TabIndex = 0;
            // 
            // FrmUserRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(478, 644);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdModifyRole);
            this.Controls.Add(this.lstRoles);
            this.Controls.Add(this.cmdDelRole);
            this.Controls.Add(this.cmdAddRole);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.otherDBRolesPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmUserRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserRole";
            this.Load += new System.EventHandler(this.FrmUserRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtlUserRolesPanel otherDBRolesPanel;
        private Button cmdOK;
        private Button cmdCancel;
        private Label label4;
        private Button cmdModifyRole;
        private ListView lstRoles;
        private ColumnHeader colRoles;
        private ColumnHeader colDataBase;
        private Button cmdDelRole;
        private Button cmdAddRole;
        private ComboBox cmbDB;
    }
}