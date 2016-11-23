using System.ComponentModel;
using System.Windows.Forms;

namespace FunctionForm.Status
{
    partial class FrmProfilling
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
            this.cmbProfillingLv = new System.Windows.Forms.ComboBox();
            this.lblProfilingLevel = new System.Windows.Forms.Label();
            this.lblSlow = new System.Windows.Forms.Label();
            this.NumTime = new System.Windows.Forms.NumericUpDown();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProfillingLv
            // 
            this.cmbProfillingLv.FormattingEnabled = true;
            this.cmbProfillingLv.Location = new System.Drawing.Point(130, 5);
            this.cmbProfillingLv.Name = "cmbProfillingLv";
            this.cmbProfillingLv.Size = new System.Drawing.Size(121, 20);
            this.cmbProfillingLv.TabIndex = 0;
            this.cmbProfillingLv.SelectedIndexChanged += new System.EventHandler(this.cmbProfillingLv_SelectedIndexChanged);
            // 
            // lblProfilingLevel
            // 
            this.lblProfilingLevel.AutoSize = true;
            this.lblProfilingLevel.Location = new System.Drawing.Point(21, 8);
            this.lblProfilingLevel.Name = "lblProfilingLevel";
            this.lblProfilingLevel.Size = new System.Drawing.Size(83, 12);
            this.lblProfilingLevel.TabIndex = 1;
            this.lblProfilingLevel.Text = "Profile Level";
            // 
            // lblSlow
            // 
            this.lblSlow.AutoSize = true;
            this.lblSlow.Location = new System.Drawing.Point(21, 38);
            this.lblSlow.Name = "lblSlow";
            this.lblSlow.Size = new System.Drawing.Size(65, 12);
            this.lblSlow.TabIndex = 2;
            this.lblSlow.Text = "Slow(msec)";
            // 
            // NumTime
            // 
            this.NumTime.Location = new System.Drawing.Point(131, 33);
            this.NumTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumTime.Name = "NumTime";
            this.NumTime.Size = new System.Drawing.Size(120, 21);
            this.NumTime.TabIndex = 3;
            this.NumTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(44, 91);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(153, 91);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Tag = "Common.Close";
            this.cmdCancel.Text = "Close";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmProfilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(303, 124);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.NumTime);
            this.Controls.Add(this.lblSlow);
            this.Controls.Add(this.lblProfilingLevel);
            this.Controls.Add(this.cmbProfillingLv);
            this.Name = "FrmProfilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "Main_Menu_Operation_ProfillingLevel";
            this.Text = "Profilling Level";
            this.Load += new System.EventHandler(this.frmProfilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cmbProfillingLv;
        private Label lblProfilingLevel;
        private Label lblSlow;
        private NumericUpDown NumTime;
        private Button cmdOK;
        private Button cmdCancel;
    }
}