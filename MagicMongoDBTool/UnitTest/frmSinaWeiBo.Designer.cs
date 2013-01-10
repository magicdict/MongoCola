namespace MagicMongoDBTool.UnitTest
{
    partial class frmSinaWeiBo
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
            this.btnGetMyFriendsAndFollowers = new System.Windows.Forms.Button();
            this.btnGetAllWeiBoUsers = new System.Windows.Forms.Button();
            this.grpAuth = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppSrect = new System.Windows.Forms.TextBox();
            this.txtAppKey = new System.Windows.Forms.TextBox();
            this.txtWeiBoUsr = new System.Windows.Forms.TextBox();
            this.txtWeiBoPsw = new System.Windows.Forms.TextBox();
            this.btnGetFollowers = new System.Windows.Forms.Button();
            this.txtSupperStarID = new System.Windows.Forms.TextBox();
            this.txtSupperStarName = new System.Windows.Forms.TextBox();
            this.grpAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetMyFriendsAndFollowers
            // 
            this.btnGetMyFriendsAndFollowers.Location = new System.Drawing.Point(12, 162);
            this.btnGetMyFriendsAndFollowers.Name = "btnGetMyFriendsAndFollowers";
            this.btnGetMyFriendsAndFollowers.Size = new System.Drawing.Size(340, 23);
            this.btnGetMyFriendsAndFollowers.TabIndex = 0;
            this.btnGetMyFriendsAndFollowers.Text = "GetMyFriendsAndFollowers";
            this.btnGetMyFriendsAndFollowers.UseVisualStyleBackColor = true;
            this.btnGetMyFriendsAndFollowers.Click += new System.EventHandler(this.btnGetMyFriendsAndFollowers_Click);
            // 
            // btnGetAllWeiBoUsers
            // 
            this.btnGetAllWeiBoUsers.Location = new System.Drawing.Point(12, 191);
            this.btnGetAllWeiBoUsers.Name = "btnGetAllWeiBoUsers";
            this.btnGetAllWeiBoUsers.Size = new System.Drawing.Size(340, 23);
            this.btnGetAllWeiBoUsers.TabIndex = 1;
            this.btnGetAllWeiBoUsers.Text = "GetAllWeiBoUsers";
            this.btnGetAllWeiBoUsers.UseVisualStyleBackColor = true;
            this.btnGetAllWeiBoUsers.Click += new System.EventHandler(this.btnGetAllWeiBoUsers_Click);
            // 
            // grpAuth
            // 
            this.grpAuth.Controls.Add(this.label4);
            this.grpAuth.Controls.Add(this.label3);
            this.grpAuth.Controls.Add(this.label2);
            this.grpAuth.Controls.Add(this.label1);
            this.grpAuth.Controls.Add(this.txtAppSrect);
            this.grpAuth.Controls.Add(this.txtAppKey);
            this.grpAuth.Controls.Add(this.txtWeiBoUsr);
            this.grpAuth.Controls.Add(this.txtWeiBoPsw);
            this.grpAuth.Location = new System.Drawing.Point(12, 12);
            this.grpAuth.Name = "grpAuth";
            this.grpAuth.Size = new System.Drawing.Size(340, 125);
            this.grpAuth.TabIndex = 2;
            this.grpAuth.TabStop = false;
            this.grpAuth.Text = "Auth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "AppSecret";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "AppKey";
            // 
            // txtAppSrect
            // 
            this.txtAppSrect.Location = new System.Drawing.Point(138, 44);
            this.txtAppSrect.Name = "txtAppSrect";
            this.txtAppSrect.Size = new System.Drawing.Size(163, 20);
            this.txtAppSrect.TabIndex = 3;
            // 
            // txtAppKey
            // 
            this.txtAppKey.Location = new System.Drawing.Point(138, 18);
            this.txtAppKey.Name = "txtAppKey";
            this.txtAppKey.Size = new System.Drawing.Size(163, 20);
            this.txtAppKey.TabIndex = 4;
            // 
            // txtWeiBoUsr
            // 
            this.txtWeiBoUsr.Location = new System.Drawing.Point(138, 70);
            this.txtWeiBoUsr.Name = "txtWeiBoUsr";
            this.txtWeiBoUsr.Size = new System.Drawing.Size(163, 20);
            this.txtWeiBoUsr.TabIndex = 6;
            // 
            // txtWeiBoPsw
            // 
            this.txtWeiBoPsw.Location = new System.Drawing.Point(138, 93);
            this.txtWeiBoPsw.Name = "txtWeiBoPsw";
            this.txtWeiBoPsw.PasswordChar = '*';
            this.txtWeiBoPsw.Size = new System.Drawing.Size(163, 20);
            this.txtWeiBoPsw.TabIndex = 7;
            // 
            // btnGetFollowers
            // 
            this.btnGetFollowers.Location = new System.Drawing.Point(13, 220);
            this.btnGetFollowers.Name = "btnGetFollowers";
            this.btnGetFollowers.Size = new System.Drawing.Size(170, 23);
            this.btnGetFollowers.TabIndex = 3;
            this.btnGetFollowers.Text = "GetFollowers";
            this.btnGetFollowers.UseVisualStyleBackColor = true;
            this.btnGetFollowers.Click += new System.EventHandler(this.btnGetFollowers_Click);
            // 
            // txtSupperStarID
            // 
            this.txtSupperStarID.Location = new System.Drawing.Point(189, 222);
            this.txtSupperStarID.Name = "txtSupperStarID";
            this.txtSupperStarID.Size = new System.Drawing.Size(95, 20);
            this.txtSupperStarID.TabIndex = 4;
            // 
            // txtSupperStarName
            // 
            this.txtSupperStarName.Location = new System.Drawing.Point(189, 248);
            this.txtSupperStarName.Name = "txtSupperStarName";
            this.txtSupperStarName.Size = new System.Drawing.Size(95, 20);
            this.txtSupperStarName.TabIndex = 4;
            // 
            // frmSinaWeiBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 290);
            this.Controls.Add(this.txtSupperStarName);
            this.Controls.Add(this.txtSupperStarID);
            this.Controls.Add(this.btnGetFollowers);
            this.Controls.Add(this.grpAuth);
            this.Controls.Add(this.btnGetAllWeiBoUsers);
            this.Controls.Add(this.btnGetMyFriendsAndFollowers);
            this.Name = "frmSinaWeiBo";
            this.Text = "SinaWeiBo";
            this.Load += new System.EventHandler(this.frmSinaWeiBo_Load);
            this.grpAuth.ResumeLayout(false);
            this.grpAuth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetMyFriendsAndFollowers;
        private System.Windows.Forms.Button btnGetAllWeiBoUsers;
        private System.Windows.Forms.GroupBox grpAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAppSrect;
        private System.Windows.Forms.TextBox txtAppKey;
        private System.Windows.Forms.TextBox txtWeiBoUsr;
        private System.Windows.Forms.TextBox txtWeiBoPsw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetFollowers;
        private System.Windows.Forms.TextBox txtSupperStarID;
        private System.Windows.Forms.TextBox txtSupperStarName;
    }
}