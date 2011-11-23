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
            this.cmdModifyCon = new System.Windows.Forms.VistaButton();
            this.cmdDelCon = new System.Windows.Forms.VistaButton();
            this.cmdAddCon = new System.Windows.Forms.VistaButton();
            this.cmdCancel = new System.Windows.Forms.VistaButton();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.lstServerce = new System.Windows.Forms.ListBox();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdModifyCon);
            this.contentPanel.Controls.Add(this.cmdDelCon);
            this.contentPanel.Controls.Add(this.cmdAddCon);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Controls.Add(this.lstServerce);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(445, 232);
            // 
            // cmdModifyCon
            // 
            this.cmdModifyCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdModifyCon.Location = new System.Drawing.Point(371, 128);
            this.cmdModifyCon.Name = "cmdModifyCon";
            this.cmdModifyCon.Size = new System.Drawing.Size(60, 31);
            this.cmdModifyCon.TabIndex = 9;
            this.cmdModifyCon.Text = "修改";
            this.cmdModifyCon.Click += new System.EventHandler(this.cmdModifyCon_Click);
            // 
            // cmdDelCon
            // 
            this.cmdDelCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelCon.Location = new System.Drawing.Point(371, 79);
            this.cmdDelCon.Name = "cmdDelCon";
            this.cmdDelCon.Size = new System.Drawing.Size(60, 31);
            this.cmdDelCon.TabIndex = 10;
            this.cmdDelCon.Text = "删除";
            this.cmdDelCon.Click += new System.EventHandler(this.cmdDelCon_Click);
            // 
            // cmdAddCon
            // 
            this.cmdAddCon.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddCon.Location = new System.Drawing.Point(371, 32);
            this.cmdAddCon.Name = "cmdAddCon";
            this.cmdAddCon.Size = new System.Drawing.Size(60, 31);
            this.cmdAddCon.TabIndex = 8;
            this.cmdAddCon.Text = "添加";
            this.cmdAddCon.Click += new System.EventHandler(this.cmdAddCon_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(217, 180);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(60, 31);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(109, 180);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(60, 31);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lstServerce
            // 
            this.lstServerce.FormattingEnabled = true;
            this.lstServerce.Location = new System.Drawing.Point(11, 14);
            this.lstServerce.Name = "lstServerce";
            this.lstServerce.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstServerce.Size = new System.Drawing.Size(354, 160);
            this.lstServerce.TabIndex = 5;
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 295);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmConnect";
            this.Text = "数据库连接";
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdModifyCon;
        private System.Windows.Forms.VistaButton cmdDelCon;
        private System.Windows.Forms.VistaButton cmdAddCon;
        private System.Windows.Forms.VistaButton cmdCancel;
        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.ListBox lstServerce;
    }
}