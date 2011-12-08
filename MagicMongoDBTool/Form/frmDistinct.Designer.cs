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
            this.panColumn = new System.Windows.Forms.Panel();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblSelectField = new System.Windows.Forms.Label();
            this.cmdQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // lblSelectField
            // 
            this.lblSelectField.AutoSize = true;
            this.lblSelectField.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectField.Location = new System.Drawing.Point(11, 16);
            this.lblSelectField.Name = "lblSelectField";
            this.lblSelectField.Size = new System.Drawing.Size(102, 13);
            this.lblSelectField.TabIndex = 0;
            this.lblSelectField.Text = "请选择Distinct字段";
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
            this.ClientSize = new System.Drawing.Size(318, 395);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.lblSelectField);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.panColumn);
            this.Name = "frmDistinct";
            this.Text = "Distinct";
            this.Load += new System.EventHandler(this.frmSelectKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Panel panColumn;
        private System.Windows.Forms.Label lblSelectField;
        private System.Windows.Forms.Button cmdQuery;
    }
}