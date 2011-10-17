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
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.grpFieldInfo = new System.Windows.Forms.GroupBox();
            this.cmdAddCondition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Location = new System.Drawing.Point(415, 12);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(552, 390);
            this.grpFilter.TabIndex = 6;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "字段过滤条件";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(859, 417);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(108, 23);
            this.cmdOK.TabIndex = 8;
            this.cmdOK.Text = "确定";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // grpFieldInfo
            // 
            this.grpFieldInfo.Location = new System.Drawing.Point(29, 12);
            this.grpFieldInfo.Name = "grpFieldInfo";
            this.grpFieldInfo.Size = new System.Drawing.Size(380, 390);
            this.grpFieldInfo.TabIndex = 9;
            this.grpFieldInfo.TabStop = false;
            this.grpFieldInfo.Text = "字段表示和排序";
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.Location = new System.Drawing.Point(739, 417);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(114, 23);
            this.cmdAddCondition.TabIndex = 10;
            this.cmdAddCondition.Text = "新增过滤条件";
            this.cmdAddCondition.UseVisualStyleBackColor = true;
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 462);
            this.Controls.Add(this.cmdAddCondition);
            this.Controls.Add(this.grpFieldInfo);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.grpFilter);
            this.Name = "frmQuery";
            this.Text = "frmQuery";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.GroupBox grpFieldInfo;
        private System.Windows.Forms.Button cmdAddCondition;

    }
}