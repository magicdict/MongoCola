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
            this.lblPipeline = new System.Windows.Forms.Label();
            this.txtViewName = new System.Windows.Forms.TextBox();
            this.cmbViewOn = new System.Windows.Forms.ComboBox();
            this.btnAggrBuilder = new System.Windows.Forms.Button();
            this.lblCollation = new System.Windows.Forms.Label();
            this.btnCollation = new System.Windows.Forms.Button();
            this.trvNewStage = new MongoGUICtl.CtlTreeViewColumns();
            this.trvCollation = new MongoGUICtl.CtlTreeViewColumns();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(279, 462);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 31);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Tag = "Common.Cancel";
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(173, 462);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 31);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Tag = "Common.OK";
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblViewName
            // 
            this.lblViewName.AutoSize = true;
            this.lblViewName.Location = new System.Drawing.Point(13, 25);
            this.lblViewName.Name = "lblViewName";
            this.lblViewName.Size = new System.Drawing.Size(53, 12);
            this.lblViewName.TabIndex = 8;
            this.lblViewName.Tag = "Common.ViewName";
            this.lblViewName.Text = "ViewName";
            // 
            // lblViewOn
            // 
            this.lblViewOn.AutoSize = true;
            this.lblViewOn.Location = new System.Drawing.Point(254, 25);
            this.lblViewOn.Name = "lblViewOn";
            this.lblViewOn.Size = new System.Drawing.Size(41, 12);
            this.lblViewOn.TabIndex = 9;
            this.lblViewOn.Tag = "Common.ViewOn";
            this.lblViewOn.Text = "ViewOn";
            // 
            // lblPipeline
            // 
            this.lblPipeline.AutoSize = true;
            this.lblPipeline.Location = new System.Drawing.Point(13, 72);
            this.lblPipeline.Name = "lblPipeline";
            this.lblPipeline.Size = new System.Drawing.Size(53, 12);
            this.lblPipeline.TabIndex = 10;
            this.lblPipeline.Tag = "Common.Pipeline";
            this.lblPipeline.Text = "Pipeline";
            // 
            // txtViewName
            // 
            this.txtViewName.Location = new System.Drawing.Point(87, 22);
            this.txtViewName.Name = "txtViewName";
            this.txtViewName.Size = new System.Drawing.Size(135, 21);
            this.txtViewName.TabIndex = 11;
            // 
            // cmbViewOn
            // 
            this.cmbViewOn.FormattingEnabled = true;
            this.cmbViewOn.Location = new System.Drawing.Point(328, 22);
            this.cmbViewOn.Name = "cmbViewOn";
            this.cmbViewOn.Size = new System.Drawing.Size(135, 20);
            this.cmbViewOn.TabIndex = 12;
            // 
            // btnAggrBuilder
            // 
            this.btnAggrBuilder.Location = new System.Drawing.Point(87, 68);
            this.btnAggrBuilder.Name = "btnAggrBuilder";
            this.btnAggrBuilder.Size = new System.Drawing.Size(135, 31);
            this.btnAggrBuilder.TabIndex = 31;
            this.btnAggrBuilder.Text = "Stage Builder";
            this.btnAggrBuilder.UseVisualStyleBackColor = true;
            this.btnAggrBuilder.Click += new System.EventHandler(this.btnAggrBuilder_Click);
            // 
            // lblCollation
            // 
            this.lblCollation.AutoSize = true;
            this.lblCollation.Location = new System.Drawing.Point(13, 310);
            this.lblCollation.Name = "lblCollation";
            this.lblCollation.Size = new System.Drawing.Size(59, 12);
            this.lblCollation.TabIndex = 10;
            this.lblCollation.Tag = "Common.Collation";
            this.lblCollation.Text = "Collation";
            // 
            // btnCollation
            // 
            this.btnCollation.Location = new System.Drawing.Point(87, 301);
            this.btnCollation.Name = "btnCollation";
            this.btnCollation.Size = new System.Drawing.Size(135, 31);
            this.btnCollation.TabIndex = 33;
            this.btnCollation.Tag = "Common.CreateCollation";
            this.btnCollation.Text = "Create Collation";
            this.btnCollation.UseVisualStyleBackColor = true;
            this.btnCollation.Click += new System.EventHandler(this.btnCollation_Click);
            // 
            // trvNewStage
            // 
            this.trvNewStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvNewStage.Location = new System.Drawing.Point(87, 105);
            this.trvNewStage.Margin = new System.Windows.Forms.Padding(4);
            this.trvNewStage.Name = "trvNewStage";
            this.trvNewStage.Padding = new System.Windows.Forms.Padding(1);
            this.trvNewStage.Size = new System.Drawing.Size(409, 171);
            this.trvNewStage.TabIndex = 32;
            // 
            // trvCollation
            // 
            this.trvCollation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(179)))));
            this.trvCollation.Location = new System.Drawing.Point(87, 339);
            this.trvCollation.Margin = new System.Windows.Forms.Padding(4);
            this.trvCollation.Name = "trvCollation";
            this.trvCollation.Padding = new System.Windows.Forms.Padding(1);
            this.trvCollation.Size = new System.Drawing.Size(409, 116);
            this.trvCollation.TabIndex = 34;
            // 
            // frmCreateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(526, 505);
            this.Controls.Add(this.trvCollation);
            this.Controls.Add(this.btnCollation);
            this.Controls.Add(this.trvNewStage);
            this.Controls.Add(this.btnAggrBuilder);
            this.Controls.Add(this.cmbViewOn);
            this.Controls.Add(this.txtViewName);
            this.Controls.Add(this.lblCollation);
            this.Controls.Add(this.lblPipeline);
            this.Controls.Add(this.lblViewOn);
            this.Controls.Add(this.lblViewName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "MainMenuOperationDatabaseAddView";
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
        private System.Windows.Forms.Label lblPipeline;
        private System.Windows.Forms.TextBox txtViewName;
        private System.Windows.Forms.ComboBox cmbViewOn;
        private System.Windows.Forms.Button btnAggrBuilder;
        private MongoGUICtl.CtlTreeViewColumns trvNewStage;
        private System.Windows.Forms.Label lblCollation;
        private System.Windows.Forms.Button btnCollation;
        private MongoGUICtl.CtlTreeViewColumns trvCollation;
    }
}