namespace HRSystem
{
    partial class frmPipelineWeekInfo
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
            this.WeekStart = new System.Windows.Forms.DateTimePicker();
            this.WeekEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lstHiringTracking = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // WeekStart
            // 
            this.WeekStart.Location = new System.Drawing.Point(108, 12);
            this.WeekStart.Name = "WeekStart";
            this.WeekStart.Size = new System.Drawing.Size(200, 20);
            this.WeekStart.TabIndex = 0;
            // 
            // WeekEnd
            // 
            this.WeekEnd.Location = new System.Drawing.Point(422, 16);
            this.WeekEnd.Name = "WeekEnd";
            this.WeekEnd.Size = new System.Drawing.Size(200, 20);
            this.WeekEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOK.Location = new System.Drawing.Point(640, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstHiringTracking
            // 
            this.lstHiringTracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHiringTracking.FullRowSelect = true;
            this.lstHiringTracking.GridLines = true;
            this.lstHiringTracking.Location = new System.Drawing.Point(8, 59);
            this.lstHiringTracking.Name = "lstHiringTracking";
            this.lstHiringTracking.Size = new System.Drawing.Size(813, 379);
            this.lstHiringTracking.TabIndex = 6;
            this.lstHiringTracking.UseCompatibleStateImageBehavior = false;
            this.lstHiringTracking.View = System.Windows.Forms.View.Details;
            // 
            // frmPipelineWeekInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(833, 438);
            this.Controls.Add(this.lstHiringTracking);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WeekEnd);
            this.Controls.Add(this.WeekStart);
            this.Name = "frmPipelineWeekInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Week Picker";
            this.Load += new System.EventHandler(this.frmPipelineWeekInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker WeekStart;
        private System.Windows.Forms.DateTimePicker WeekEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListView lstHiringTracking;
    }
}