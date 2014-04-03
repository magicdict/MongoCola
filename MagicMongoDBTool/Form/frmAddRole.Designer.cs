namespace MagicMongoDBTool
{
    partial class frmAddRole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblPrivilege = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddRole
            // 
            this.btnAddRole.Location = new System.Drawing.Point(262, 211);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(75, 23);
            this.btnAddRole.TabIndex = 0;
            this.btnAddRole.Text = "Add Role";
            this.btnAddRole.UseVisualStyleBackColor = true;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(370, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lblPrivilege
            // 
            this.lblPrivilege.AutoSize = true;
            this.lblPrivilege.Location = new System.Drawing.Point(39, 75);
            this.lblPrivilege.Name = "lblPrivilege";
            this.lblPrivilege.Size = new System.Drawing.Size(47, 13);
            this.lblPrivilege.TabIndex = 3;
            this.lblPrivilege.Text = "Privilege";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(134, 100);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(53, 13);
            this.lblResource.TabIndex = 4;
            this.lblResource.Text = "Resource";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(134, 137);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(37, 13);
            this.lblAction.TabIndex = 5;
            this.lblAction.Text = "Action";
            // 
            // frmAddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 247);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.lblPrivilege);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.btnAddRole);
            this.Name = "frmAddRole";
            this.Text = "Add Custom Role";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRole;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblPrivilege;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.Label lblAction;
    }
}