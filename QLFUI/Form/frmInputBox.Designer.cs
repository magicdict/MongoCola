namespace QLFUI
{
    partial class frmInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputBox));
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtResult = new QLFUI.TextBoxEx();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.cmdCancel = new System.Windows.Forms.VistaButton();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.txtResult);
            this.contentPanel.Controls.Add(this.lblMessage);
            this.contentPanel.Controls.Add(this.cmdCancel);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(564, 185);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Location = new System.Drawing.Point(42, 27);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "lblMessage";
            // 
            // textBoxEx1
            // 
            this.txtResult.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtResult.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtResult.BackColor = System.Drawing.Color.Transparent;
            this.txtResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(208)))), ((int)(((byte)(226)))));
            this.txtResult.ForeImage = null;
            this.txtResult.Location = new System.Drawing.Point(45, 56);
            this.txtResult.Multiline = false;
            this.txtResult.Name = "textBoxEx1";
            this.txtResult.Radius = 3;
            this.txtResult.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.txtResult.Size = new System.Drawing.Size(494, 29);
            this.txtResult.TabIndex = 6;
            this.txtResult.UseSystemPasswordChar = false;
            this.txtResult.WaterMark = null;
            this.txtResult.WaterMarkColor = System.Drawing.Color.Silver;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(119, 124);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(100, 32);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.Location = new System.Drawing.Point(349, 124);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 32);
            this.cmdCancel.TabIndex = 6;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 248);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmInputBox";
            this.Text = "frmInputBox";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxEx txtResult;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.VistaButton cmdCancel;
        private System.Windows.Forms.VistaButton cmdOK;
    }
}