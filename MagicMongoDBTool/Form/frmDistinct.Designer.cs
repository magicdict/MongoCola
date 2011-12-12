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
            this.cmdRun = new System.Windows.Forms.Button();
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
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(168, 349);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(100, 32);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblSelectField
            // 
            this.lblSelectField.AutoSize = true;
            this.lblSelectField.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectField.Location = new System.Drawing.Point(11, 16);
            this.lblSelectField.Name = "lblSelectField";
            this.lblSelectField.Size = new System.Drawing.Size(96, 13);
            this.lblSelectField.TabIndex = 0;
            this.lblSelectField.Text = "Pick Distinct Fields";
            // 
            // cmdQuery
            // 
            this.cmdQuery.BackColor = System.Drawing.Color.Transparent;
            this.cmdQuery.Location = new System.Drawing.Point(62, 349);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(100, 32);
            this.cmdQuery.TabIndex = 6;
            this.cmdQuery.Text = "Load Query";
            this.cmdQuery.UseVisualStyleBackColor = false;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // frmDistinct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 395);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.lblSelectField);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.panColumn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDistinct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Distinct";
            this.Load += new System.EventHandler(this.frmSelectKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Panel panColumn;
        private System.Windows.Forms.Label lblSelectField;
        private System.Windows.Forms.Button cmdQuery;
    }
}