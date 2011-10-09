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
            this.lstServerce = new System.Windows.Forms.ListBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAddCon = new System.Windows.Forms.Button();
            this.cmdDelCon = new System.Windows.Forms.Button();
            this.cmdModifyCon = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lstServerce
            // 
            this.lstServerce.FormattingEnabled = true;
            this.lstServerce.Location = new System.Drawing.Point(7, 20);
            this.lstServerce.Name = "lstServerce";
            this.lstServerce.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServerce.Size = new System.Drawing.Size(401, 160);
            this.lstServerce.TabIndex = 0;
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(220, 208);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(82, 27);
            this.cmdConnect.TabIndex = 1;
            this.cmdConnect.Text = "连接";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(322, 208);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 27);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdAddCon
            // 
            this.cmdAddCon.Location = new System.Drawing.Point(421, 26);
            this.cmdAddCon.Name = "cmdAddCon";
            this.cmdAddCon.Size = new System.Drawing.Size(60, 31);
            this.cmdAddCon.TabIndex = 3;
            this.cmdAddCon.Text = "添加";
            this.cmdAddCon.UseVisualStyleBackColor = true;
            this.cmdAddCon.Click += new System.EventHandler(this.cmdAddCon_Click);
            // 
            // cmdDelCon
            // 
            this.cmdDelCon.Location = new System.Drawing.Point(421, 75);
            this.cmdDelCon.Name = "cmdDelCon";
            this.cmdDelCon.Size = new System.Drawing.Size(60, 31);
            this.cmdDelCon.TabIndex = 3;
            this.cmdDelCon.Text = "删除";
            this.cmdDelCon.UseVisualStyleBackColor = true;
            this.cmdDelCon.Click += new System.EventHandler(this.cmdDelCon_Click);
            // 
            // cmdModifyCon
            // 
            this.cmdModifyCon.Location = new System.Drawing.Point(421, 125);
            this.cmdModifyCon.Name = "cmdModifyCon";
            this.cmdModifyCon.Size = new System.Drawing.Size(60, 31);
            this.cmdModifyCon.TabIndex = 3;
            this.cmdModifyCon.Text = "修改";
            this.cmdModifyCon.UseVisualStyleBackColor = true;
            this.cmdModifyCon.Click += new System.EventHandler(this.cmdModifyCon_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(38, 183);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(303, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "希望大家支持我的好朋友的CMS框架wojilu www.wojilu.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 247);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cmdModifyCon);
            this.Controls.Add(this.cmdDelCon);
            this.Controls.Add(this.cmdAddCon);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.lstServerce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmConnect";
            this.Text = "数据连接";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstServerce;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAddCon;
        private System.Windows.Forms.Button cmdDelCon;
        private System.Windows.Forms.Button cmdModifyCon;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}