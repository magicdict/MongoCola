namespace MagicMongoDBTool
{
    partial class frmDistinct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDistinct));
            this.panColumn = new System.Windows.Forms.Panel();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdQuery = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdQuery);
            this.contentPanel.Controls.Add(this.label1);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Controls.Add(this.panColumn);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(316, 392);
            // 
            // panColumn
            // 
            this.panColumn.BackColor = System.Drawing.Color.Transparent;
            this.panColumn.Location = new System.Drawing.Point(11, 43);
            this.panColumn.Name = "panColumn";
            this.panColumn.Size = new System.Drawing.Size(294, 300);
            this.panColumn.TabIndex = 5;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(168, 349);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 32);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Distinct字段";
            // 
            // cmdQuery
            // 
            this.cmdQuery.BackColor = System.Drawing.Color.Transparent;
            this.cmdQuery.Location = new System.Drawing.Point(62, 349);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(100, 32);
            this.cmdQuery.TabIndex = 6;
            this.cmdQuery.Text = "载入查询条件";
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // frmDistinct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 455);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmDistinct";
            this.ShowSelectSkinButton = false;
            this.Text = "Distinct";
            this.Load += new System.EventHandler(this.frmSelectKey_Load);
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.Panel panColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VistaButton cmdQuery;
    }
}