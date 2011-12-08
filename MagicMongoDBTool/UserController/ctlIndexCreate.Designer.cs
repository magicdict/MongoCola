using System.Windows.Forms;
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
            this.radAscendingKey = new System.Windows.Forms.RadioButton();
            this.radDescendingKey = new System.Windows.Forms.RadioButton();
            this.lblKeyName = new System.Windows.Forms.Label();
            this.txtKeyName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // radAscendingKey
            // 
            this.radAscendingKey.AutoSize = true;
            this.radAscendingKey.Checked = true;
            this.radAscendingKey.Location = new System.Drawing.Point(301, 6);
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
            this.radDescendingKey.Location = new System.Drawing.Point(356, 6);
            this.radDescendingKey.Name = "radDescendingKey";
            this.radDescendingKey.Size = new System.Drawing.Size(49, 17);
            this.radDescendingKey.TabIndex = 2;
            this.radDescendingKey.Text = "降序";
            this.radDescendingKey.UseVisualStyleBackColor = true;
            // 
            // lblKeyName
            // 
            this.lblKeyName.AutoSize = true;
            this.lblKeyName.Location = new System.Drawing.Point(8, 7);
            this.lblKeyName.Name = "lblKeyName";
            this.lblKeyName.Size = new System.Drawing.Size(55, 13);
            this.lblKeyName.TabIndex = 3;
            this.lblKeyName.Text = "索引字段";
            // 
            // txtKeyName
            // 
            this.txtKeyName.Location = new System.Drawing.Point(69, 4);
            this.txtKeyName.Name = "txtKeyName";
            this.txtKeyName.Size = new System.Drawing.Size(226, 20);
            this.txtKeyName.TabIndex = 4;
            // 
            // ctlIndexCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtKeyName);
            this.Controls.Add(this.lblKeyName);
            this.Controls.Add(this.radDescendingKey);
            this.Controls.Add(this.radAscendingKey);
            this.Name = "ctlIndexCreate";
            this.Size = new System.Drawing.Size(412, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radAscendingKey;
        private System.Windows.Forms.RadioButton radDescendingKey;
        private System.Windows.Forms.Label lblKeyName;
        private TextBox txtKeyName;
    }
}
