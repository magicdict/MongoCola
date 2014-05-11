namespace 炉边传说
{
    partial class frmStartGame
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
            this.btnCreateGame = new System.Windows.Forms.Button();
            this.lstWaitGuest = new System.Windows.Forms.ListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnJoinGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateGame
            // 
            this.btnCreateGame.Location = new System.Drawing.Point(12, 13);
            this.btnCreateGame.Name = "btnCreateGame";
            this.btnCreateGame.Size = new System.Drawing.Size(119, 23);
            this.btnCreateGame.TabIndex = 0;
            this.btnCreateGame.Text = "新建一局游戏";
            this.btnCreateGame.UseVisualStyleBackColor = true;
            this.btnCreateGame.Click += new System.EventHandler(this.btnCreateGame_Click);
            // 
            // lstWaitGuest
            // 
            this.lstWaitGuest.FormattingEnabled = true;
            this.lstWaitGuest.Location = new System.Drawing.Point(12, 80);
            this.lstWaitGuest.Name = "lstWaitGuest";
            this.lstWaitGuest.Size = new System.Drawing.Size(333, 95);
            this.lstWaitGuest.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(296, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(49, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnJoinGame
            // 
            this.btnJoinGame.Location = new System.Drawing.Point(12, 51);
            this.btnJoinGame.Name = "btnJoinGame";
            this.btnJoinGame.Size = new System.Drawing.Size(119, 23);
            this.btnJoinGame.TabIndex = 3;
            this.btnJoinGame.Text = "加入一局游戏";
            this.btnJoinGame.UseVisualStyleBackColor = true;
            this.btnJoinGame.Click += new System.EventHandler(this.btnJoinGame_Click);
            // 
            // frmStartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 187);
            this.Controls.Add(this.btnJoinGame);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstWaitGuest);
            this.Controls.Add(this.btnCreateGame);
            this.Name = "frmStartGame";
            this.Text = "开始游戏";
            this.Load += new System.EventHandler(this.frmStartGame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGame;
        private System.Windows.Forms.ListBox lstWaitGuest;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnJoinGame;
    }
}