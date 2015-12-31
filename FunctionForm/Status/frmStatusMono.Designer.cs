using System.ComponentModel;
using System.Windows.Forms;
using MongoGUICtl;

namespace FunctionForm.Status
{
	partial class FrmStatusMono
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
            this.cmdClose = new System.Windows.Forms.Button();
            this.trvStatus = new MongoGUICtl.CtlTreeViewColumns();
            this.SuspendLayout();
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(358, 240);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(125, 28);
            this.cmdClose.TabIndex = 1;
            this.cmdClose.Tag = "Common_Close";
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // trvStatus
            // 
            this.trvStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(172)))), ((int)(((byte)(178)))));
            this.trvStatus.Location = new System.Drawing.Point(14, 14);
            this.trvStatus.Name = "trvStatus";
            this.trvStatus.Padding = new System.Windows.Forms.Padding(1);
            this.trvStatus.Size = new System.Drawing.Size(469, 202);
            this.trvStatus.TabIndex = 2;
            // 
            // frmStatusMono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 287);
            this.Controls.Add(this.trvStatus);
            this.Controls.Add(this.cmdClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmStatusMono";
            this.Tag = "Main_Menu_Mangt_Status";
            this.Text = "Status";
            this.Load += new System.EventHandler(this.frmStatus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdClose;
        private CtlTreeViewColumns trvStatus;
    }
}