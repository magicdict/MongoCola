namespace FunctionForm.Operation
{
    partial class frmCreateView
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblViewName = new System.Windows.Forms.Label();
            this.lblViewOn = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.cmbViewOn = new System.Windows.Forms.ComboBox();
            this.btnAggrBuilder = new System.Windows.Forms.Button();
            this.trvNewStage = new MongoGUICtl.CtlTreeViewColumns();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(248, 353);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 27);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(142, 353);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 27);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblViewName
            // 
            this.lblViewName.AutoSize = true;
            this.lblViewName.Location = new System.Drawing.Point(47, 39);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(53, 12);
            this.lblViewName.TabIndex = 8;
            this.lblViewName.Text = "ViewName";
            // 
            // lblViewOn
            // 
            this.lblViewOn.AutoSize = true;
            this.lblViewOn.Location = new System.Drawing.Point(47, 78);
            this.lblViewOn.Name = "lblViewOn";
            this.lblViewOn.Size = new System.Drawing.Size(65, 12);
            this.lblViewOn.TabIndex = 9;
            this.lblViewOn.Text = "Collection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pipeline";
            // 
            // txtViewName
            // 
            this.txtViewName.Location = new System.Drawing.Point(142, 36);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(282, 21);
            this.txtViewName.TabIndex = 11;
            // 
            // cmbViewOn
            // 
            this.cmbViewOn.FormattingEnabled = true;
            this.cmbViewOn.Location = new System.Drawing.Point(142, 75);
            this.cmbViewOn.Name = "cmbViewOn";
            this.cmbViewOn.Size = new System.Drawing.Size(282, 20);
            this.cmbViewOn.TabIndex = 12;
            // 
            // btnAggrBuilder
            // 
            this.btnAggrBuilder.Location = new System.Drawing.Point(142, 113);
            this.btnAggrBuilder.Name = "btnAggrBuilder";
            this.btnAggrBuilder.Size = new System.Drawing.Size(135, 21);
            this.btnAggrBuilder.TabIndex = 31;
            this.btnAggrBuilder.Text = "Stage Builder";
            this.btnAggrBuilder.UseVisualStyleBackColor = true;
            this.btnAggrBuilder.Click += new System.EventHandler(this.btnAggrBuilder_Click);
            // 
            // trvNewStage
            // 
            this.trvNewStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvNewStage.Location = new System.Drawing.Point(142, 150);
            this.trvNewStage.Margin = new System.Windows.Forms.Padding(4);
            this.trvNewStage.Name = "trvNewStage";
            this.trvNewStage.Padding = new System.Windows.Forms.Padding(1);
            this.trvNewStage.Size = new System.Drawing.Size(282, 171);
            this.trvNewStage.TabIndex = 32;
            // 
            // frmCreateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 405);
            this.Controls.Add(this.trvNewStage);
            this.Controls.Add(this.btnAggrBuilder);
            this.Controls.Add(this.cmbViewOn);
            this.Controls.Add(this.txtViewName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblViewOn);
            this.Controls.Add(this.lblViewName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Name = "frmCreateView";
            this.Text = "Create View";
            this.Load += new System.EventHandler(this.frmCreateView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblViewName;
        private System.Windows.Forms.Label lblViewOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.ComboBox cmbViewOn;
        private System.Windows.Forms.Button btnAggrBuilder;
        private MongoGUICtl.CtlTreeViewColumns trvNewStage;
    }
}