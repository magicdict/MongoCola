namespace MagicMongoDBTool
{
    partial class frmQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery));
            this.cmdAddCondition = new System.Windows.Forms.VistaButton();
            this.grpFieldInfo = new System.Windows.Forms.GroupBox();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdAddCondition);
            this.contentPanel.Controls.Add(this.grpFieldInfo);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Controls.Add(this.grpFilter);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(947, 459);
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.Location = new System.Drawing.Point(688, 426);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(114, 23);
            this.cmdAddCondition.TabIndex = 14;
            this.cmdAddCondition.Text = "新增过滤条件";
            //this.cmdAddCondition.UseVisualStyleBackColor = true;
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // grpFieldInfo
            // 
            this.grpFieldInfo.BackColor = System.Drawing.Color.Transparent;
            this.grpFieldInfo.Location = new System.Drawing.Point(4, 17);
            this.grpFieldInfo.Name = "grpFieldInfo";
            this.grpFieldInfo.Size = new System.Drawing.Size(380, 390);
            this.grpFieldInfo.TabIndex = 13;
            this.grpFieldInfo.TabStop = false;
            this.grpFieldInfo.Text = "字段表示和排序";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(808, 426);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(108, 23);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "确定";
            //this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // grpFilter
            // 
            this.grpFilter.BackColor = System.Drawing.Color.Transparent;
            this.grpFilter.Location = new System.Drawing.Point(390, 17);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(552, 390);
            this.grpFilter.TabIndex = 11;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "字段过滤条件";
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 522);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmQuery";
            this.Text = "frmQuery";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdAddCondition;
        private System.Windows.Forms.GroupBox grpFieldInfo;
        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.GroupBox grpFilter;
    }
}