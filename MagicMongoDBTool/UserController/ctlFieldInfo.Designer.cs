namespace MagicMongoDBTool
{
    partial class ctlFieldInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFieldName = new System.Windows.Forms.Label();
            this.chkIsShow = new System.Windows.Forms.CheckBox();
            this.radNoSort = new System.Windows.Forms.RadioButton();
            this.radSortAcs = new System.Windows.Forms.RadioButton();
            this.radSortDes = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(7, 4);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(57, 13);
            this.lblFieldName.TabIndex = 0;
            this.lblFieldName.Text = "FieldName";
            // 
            // chkIsShow
            // 
            this.chkIsShow.AutoSize = true;
            this.chkIsShow.Location = new System.Drawing.Point(116, 3);
            this.chkIsShow.Name = "chkIsShow";
            this.chkIsShow.Size = new System.Drawing.Size(60, 17);
            this.chkIsShow.TabIndex = 1;
            this.chkIsShow.Text = "Display";
            this.chkIsShow.UseVisualStyleBackColor = true;
            // 
            // radNoSort
            // 
            this.radNoSort.AutoSize = true;
            this.radNoSort.Location = new System.Drawing.Point(182, 2);
            this.radNoSort.Name = "radNoSort";
            this.radNoSort.Size = new System.Drawing.Size(39, 17);
            this.radNoSort.TabIndex = 2;
            this.radNoSort.TabStop = true;
            this.radNoSort.Text = "No";
            this.radNoSort.UseVisualStyleBackColor = true;
            // 
            // radSortAcs
            // 
            this.radSortAcs.AutoSize = true;
            this.radSortAcs.Location = new System.Drawing.Point(237, 3);
            this.radSortAcs.Name = "radSortAcs";
            this.radSortAcs.Size = new System.Drawing.Size(43, 17);
            this.radSortAcs.TabIndex = 3;
            this.radSortAcs.TabStop = true;
            this.radSortAcs.Text = "Asc";
            this.radSortAcs.UseVisualStyleBackColor = true;
            // 
            // radSortDes
            // 
            this.radSortDes.AutoSize = true;
            this.radSortDes.Location = new System.Drawing.Point(288, 3);
            this.radSortDes.Name = "radSortDes";
            this.radSortDes.Size = new System.Drawing.Size(44, 17);
            this.radSortDes.TabIndex = 4;
            this.radSortDes.TabStop = true;
            this.radSortDes.Text = "Des";
            this.radSortDes.UseVisualStyleBackColor = true;
            // 
            // ctlFieldInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radSortDes);
            this.Controls.Add(this.radSortAcs);
            this.Controls.Add(this.radNoSort);
            this.Controls.Add(this.chkIsShow);
            this.Controls.Add(this.lblFieldName);
            this.Name = "ctlFieldInfo";
            this.Size = new System.Drawing.Size(342, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.CheckBox chkIsShow;
        private System.Windows.Forms.RadioButton radNoSort;
        private System.Windows.Forms.RadioButton radSortAcs;
        private System.Windows.Forms.RadioButton radSortDes;
    }
}
