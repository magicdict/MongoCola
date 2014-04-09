namespace UnitTest
{
    partial class UserRoleTest
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
            this.btnGetAllCustomRole = new System.Windows.Forms.Button();
            this.treeViewColumns1 = new TreeViewColumnsProject.TreeViewColumns();
            this.SuspendLayout();
            // 
            // btnGetAllCustomRole
            // 
            this.btnGetAllCustomRole.Location = new System.Drawing.Point(53, 25);
            this.btnGetAllCustomRole.Name = "btnGetAllCustomRole";
            this.btnGetAllCustomRole.Size = new System.Drawing.Size(185, 23);
            this.btnGetAllCustomRole.TabIndex = 0;
            this.btnGetAllCustomRole.Text = "GetAllCustomRole";
            this.btnGetAllCustomRole.UseVisualStyleBackColor = true;
            this.btnGetAllCustomRole.Click += new System.EventHandler(this.btnGetAllCustomRole_Click);
            // 
            // treeViewColumns1
            // 
            this.treeViewColumns1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewColumns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.treeViewColumns1.Location = new System.Drawing.Point(53, 54);
            this.treeViewColumns1.Name = "treeViewColumns1";
            this.treeViewColumns1.Padding = new System.Windows.Forms.Padding(1);
            this.treeViewColumns1.Size = new System.Drawing.Size(586, 184);
            this.treeViewColumns1.TabIndex = 1;
            // 
            // UserRoleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 267);
            this.Controls.Add(this.treeViewColumns1);
            this.Controls.Add(this.btnGetAllCustomRole);
            this.Name = "UserRoleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserRoleTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllCustomRole;
        private TreeViewColumnsProject.TreeViewColumns treeViewColumns1;
    }
}