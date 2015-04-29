using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Aggregation
{
    partial class FrmDistinct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.panColumn.AutoScroll = true;
            this.panColumn.BackColor = System.Drawing.Color.Transparent;
            this.panColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panColumn.Location = new System.Drawing.Point(13, 50);
            this.panColumn.Name = "panColumn";
            this.panColumn.Size = new System.Drawing.Size(343, 346);
            this.panColumn.TabIndex = 5;
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(196, 403);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(117, 37);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = false;
            this.cmdRun.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblSelectField
            // 
            this.lblSelectField.AutoSize = true;
            this.lblSelectField.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectField.Location = new System.Drawing.Point(13, 18);
            this.lblSelectField.Name = "lblSelectField";
            this.lblSelectField.Size = new System.Drawing.Size(109, 15);
            this.lblSelectField.TabIndex = 0;
            this.lblSelectField.Text = "Pick Distinct Fields";
            // 
            // cmdQuery
            // 
            this.cmdQuery.BackColor = System.Drawing.Color.Transparent;
            this.cmdQuery.Location = new System.Drawing.Point(72, 403);
            this.cmdQuery.Name = "cmdQuery";
            this.cmdQuery.Size = new System.Drawing.Size(117, 37);
            this.cmdQuery.TabIndex = 6;
            this.cmdQuery.Text = "Load Query";
            this.cmdQuery.UseVisualStyleBackColor = false;
            this.cmdQuery.Click += new System.EventHandler(this.cmdQuery_Click);
            // 
            // frmDistinct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(371, 456);
            this.Controls.Add(this.cmdQuery);
            this.Controls.Add(this.lblSelectField);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.panColumn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDistinct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Distinct";
            this.Load += new System.EventHandler(this.frmSelectKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button cmdRun;
        private Panel panColumn;
        private Label lblSelectField;
        private Button cmdQuery;
    }
}