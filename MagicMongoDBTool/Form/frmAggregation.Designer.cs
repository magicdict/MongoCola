namespace MagicMongoDBTool
{
    partial class frmAggregation
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
            this.trvResult = new TreeViewColumnsProject.TreeViewColumns();
            this.cmbForAggregate = new System.Windows.Forms.ComboBox();
            this.cmdSaveAggregate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblAggregate = new System.Windows.Forms.Label();
            this.txtAggregate = new System.Windows.Forms.TextBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trvResult
            // 
            this.trvResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvResult.Location = new System.Drawing.Point(380, 45);
            this.trvResult.Name = "trvResult";
            this.trvResult.Padding = new System.Windows.Forms.Padding(1);
            this.trvResult.Size = new System.Drawing.Size(438, 374);
            this.trvResult.TabIndex = 0;
            // 
            // cmbForMap
            // 
            this.cmbForAggregate.FormattingEnabled = true;
            this.cmbForAggregate.Location = new System.Drawing.Point(96, 14);
            this.cmbForAggregate.Name = "cmbForMap";
            this.cmbForAggregate.Size = new System.Drawing.Size(175, 21);
            this.cmbForAggregate.TabIndex = 16;
            // 
            // cmdSaveAggregate
            // 
            this.cmdSaveAggregate.BackColor = System.Drawing.Color.Transparent;
            this.cmdSaveAggregate.Location = new System.Drawing.Point(279, 14);
            this.cmdSaveAggregate.Name = "cmdSaveAggregate";
            this.cmdSaveAggregate.Size = new System.Drawing.Size(82, 25);
            this.cmdSaveAggregate.TabIndex = 17;
            this.cmdSaveAggregate.Text = "Save";
            this.cmdSaveAggregate.UseVisualStyleBackColor = false;
            this.cmdSaveAggregate.Click += new System.EventHandler(this.cmdSaveAggregate_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Location = new System.Drawing.Point(380, 20);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 20;
            this.lblResult.Text = "Result";
            // 
            // lblAggregate
            // 
            this.lblAggregate.AutoSize = true;
            this.lblAggregate.BackColor = System.Drawing.Color.Transparent;
            this.lblAggregate.Location = new System.Drawing.Point(17, 17);
            this.lblAggregate.Name = "lblAggregate";
            this.lblAggregate.Size = new System.Drawing.Size(56, 13);
            this.lblAggregate.TabIndex = 19;
            this.lblAggregate.Text = "Aggregate";
            // 
            // txtAggregate
            // 
            this.txtAggregate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAggregate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAggregate.Location = new System.Drawing.Point(12, 45);
            this.txtAggregate.Multiline = true;
            this.txtAggregate.Name = "txtAggregate";
            this.txtAggregate.Size = new System.Drawing.Size(348, 333);
            this.txtAggregate.TabIndex = 18;
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(258, 384);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(103, 35);
            this.cmdRun.TabIndex = 21;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // frmAggregation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(872, 444);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.cmbForAggregate);
            this.Controls.Add(this.cmdSaveAggregate);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblAggregate);
            this.Controls.Add(this.txtAggregate);
            this.Controls.Add(this.trvResult);
            this.Name = "frmAggregation";
            this.Text = "frmAggregation";
            this.Load += new System.EventHandler(this.frmAggregation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeViewColumnsProject.TreeViewColumns trvResult;
        private System.Windows.Forms.ComboBox cmbForAggregate;
        private System.Windows.Forms.Button cmdSaveAggregate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblAggregate;
        private System.Windows.Forms.TextBox txtAggregate;
        private System.Windows.Forms.Button cmdRun;
    }
}