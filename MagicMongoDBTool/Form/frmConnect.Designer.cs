namespace MagicMongoDBTool
{
    partial class frmConnect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnect));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cmdModifyCon = new System.Windows.Forms.Button();
            this.cmdDelCon = new System.Windows.Forms.Button();
            this.cmdAddCon = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.lstServerce = new System.Windows.Forms.ListBox();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.linkLabel1);
            this.contentPanel.Controls.Add(this.cmdModifyCon);
            this.contentPanel.Controls.Add(this.cmdDelCon);
            this.contentPanel.Controls.Add(this.cmdAddCon);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdConnect);
            this.contentPanel.Controls.Add(this.lstServerce);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(489, 263);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(46, 186);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(303, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "希望大家支持我的好朋友的CMS框架wojilu www.wojilu.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cmdModifyCon
            // 
            this.cmdModifyCon.Location = new System.Drawing.Point(418, 143);
            this.cmdModifyCon.Name = "cmdModifyCon";
            this.cmdModifyCon.Size = new System.Drawing.Size(60, 31);
            this.cmdModifyCon.TabIndex = 9;
            this.cmdModifyCon.Text = "修改";
            this.cmdModifyCon.UseVisualStyleBackColor = true;
            this.cmdModifyCon.Click += new System.EventHandler(this.cmdModifyCon_Click);
            // 
            // cmdDelCon
            // 
            this.cmdDelCon.Location = new System.Drawing.Point(418, 106);
            this.cmdDelCon.Name = "cmdDelCon";
            this.cmdDelCon.Size = new System.Drawing.Size(60, 31);
            this.cmdDelCon.TabIndex = 10;
            this.cmdDelCon.Text = "删除";
            this.cmdDelCon.UseVisualStyleBackColor = true;
            this.cmdDelCon.Click += new System.EventHandler(this.cmdDelCon_Click);
            // 
            // cmdAddCon
            // 
            this.cmdAddCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddCon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdAddCon.BackgroundImage")));
            this.cmdAddCon.Location = new System.Drawing.Point(418, 69);
            this.cmdAddCon.Name = "cmdAddCon";
            this.cmdAddCon.Size = new System.Drawing.Size(60, 31);
            this.cmdAddCon.TabIndex = 8;
            this.cmdAddCon.Text = "添加";
            this.cmdAddCon.UseVisualStyleBackColor = false;
            this.cmdAddCon.Click += new System.EventHandler(this.cmdAddCon_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(215, 222);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 27);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(113, 222);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(82, 27);
            this.cmdConnect.TabIndex = 6;
            this.cmdConnect.Text = "连接";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lstServerce
            // 
            this.lstServerce.FormattingEnabled = true;
            this.lstServerce.Location = new System.Drawing.Point(11, 14);
            this.lstServerce.Name = "lstServerce";
            this.lstServerce.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServerce.Size = new System.Drawing.Size(401, 160);
            this.lstServerce.TabIndex = 5;
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 326);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnect";
            this.ShowSelectSkinButton = false;
            this.Text = "数据库连接";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button cmdModifyCon;
        private System.Windows.Forms.Button cmdDelCon;
        private System.Windows.Forms.Button cmdAddCon;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.ListBox lstServerce;
    }
}