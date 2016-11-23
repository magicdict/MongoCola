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
            this.cmdRun = new System.Windows.Forms.Button();
            this.lblSelectField = new System.Windows.Forms.Label();
            this.cmbFields = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmdRun
            // 
            this.cmdRun.BackColor = System.Drawing.Color.Transparent;
            this.cmdRun.Location = new System.Drawing.Point(99, 82);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(117, 37);
            this.cmdRun.TabIndex = 0;
            this.cmdRun.Tag = "Common.Run";
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
            this.lblSelectField.Tag = "DistinctSelectField";
            this.lblSelectField.Text = "Pick Distinct Fields";
            // 
            // comboBox1
            // 
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new System.Drawing.Point(16, 48);
            this.cmbFields.Name = "comboBox1";
            this.cmbFields.Size = new System.Drawing.Size(297, 23);
            this.cmbFields.TabIndex = 1;
            // 
            // FrmDistinct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 131);
            this.Controls.Add(this.cmbFields);
            this.Controls.Add(this.lblSelectField);
            this.Controls.Add(this.cmdRun);
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
        private Label lblSelectField;
        private ComboBox cmbFields;
    }
}