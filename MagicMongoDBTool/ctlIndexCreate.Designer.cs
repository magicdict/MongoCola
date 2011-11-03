namespace MagicMongoDBTool
{
    partial class ctlIndexCreate
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
            this.txtKeyName = new System.Windows.Forms.TextBox();
            this.radAscendingKey = new System.Windows.Forms.RadioButton();
            this.radDescendingKey = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtKeyName
            // 
            this.txtKeyName.Location = new System.Drawing.Point(3, 2);
            this.txtKeyName.Name = "txtKeyName";
            this.txtKeyName.Size = new System.Drawing.Size(289, 20);
            this.txtKeyName.TabIndex = 0;
            // 
            // radAscendingKey
            // 
            this.radAscendingKey.AutoSize = true;
            this.radAscendingKey.Checked = true;
            this.radAscendingKey.Location = new System.Drawing.Point(301, 3);
            this.radAscendingKey.Name = "radAscendingKey";
            this.radAscendingKey.Size = new System.Drawing.Size(49, 17);
            this.radAscendingKey.TabIndex = 1;
            this.radAscendingKey.TabStop = true;
            this.radAscendingKey.Text = "升序";
            this.radAscendingKey.UseVisualStyleBackColor = true;
            // 
            // radDescendingKey
            // 
            this.radDescendingKey.AutoSize = true;
            this.radDescendingKey.Location = new System.Drawing.Point(356, 3);
            this.radDescendingKey.Name = "radDescendingKey";
            this.radDescendingKey.Size = new System.Drawing.Size(49, 17);
            this.radDescendingKey.TabIndex = 2;
            this.radDescendingKey.Text = "降序";
            this.radDescendingKey.UseVisualStyleBackColor = true;
            // 
            // ctlIndexCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.radDescendingKey);
            this.Controls.Add(this.radAscendingKey);
            this.Controls.Add(this.txtKeyName);
            this.Name = "ctlIndexCreate";
            this.Size = new System.Drawing.Size(412, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKeyName;
        private System.Windows.Forms.RadioButton radAscendingKey;
        private System.Windows.Forms.RadioButton radDescendingKey;
    }
}
