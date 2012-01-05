namespace MagicMongoDBTool
{
    partial class frmQuery
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
            this.cmdAddCondition = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFieldInfo = new System.Windows.Forms.TabPage();
            this.tabCondition = new System.Windows.Forms.TabPage();
            this.panFilter = new System.Windows.Forms.Panel();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddCondition.Location = new System.Drawing.Point(426, 393);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(133, 36);
            this.cmdAddCondition.TabIndex = 14;
            this.cmdAddCondition.Text = "AddFilter";
            this.cmdAddCondition.UseVisualStyleBackColor = false;
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(450, 504);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(133, 33);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFieldInfo);
            this.tabControl.Controls.Add(this.tabCondition);
            this.tabControl.Location = new System.Drawing.Point(16, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(579, 466);
            this.tabControl.TabIndex = 0;
            // 
            // tabFieldInfo
            // 
            this.tabFieldInfo.Location = new System.Drawing.Point(4, 24);
            this.tabFieldInfo.Name = "tabFieldInfo";
            this.tabFieldInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldInfo.Size = new System.Drawing.Size(571, 438);
            this.tabFieldInfo.TabIndex = 0;
            this.tabFieldInfo.Text = "Output Fields";
            this.tabFieldInfo.UseVisualStyleBackColor = true;
            // 
            // tabCondition
            // 
            this.tabCondition.Controls.Add(this.panFilter);
            this.tabCondition.Controls.Add(this.cmdAddCondition);
            this.tabCondition.Location = new System.Drawing.Point(4, 22);
            this.tabCondition.Name = "tabCondition";
            this.tabCondition.Padding = new System.Windows.Forms.Padding(3);
            this.tabCondition.Size = new System.Drawing.Size(571, 440);
            this.tabCondition.TabIndex = 1;
            this.tabCondition.Text = "Condition";
            this.tabCondition.UseVisualStyleBackColor = true;
            // 
            // panFilter
            // 
            this.panFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panFilter.Location = new System.Drawing.Point(3, 3);
            this.panFilter.Name = "panFilter";
            this.panFilter.Size = new System.Drawing.Size(565, 383);
            this.panFilter.TabIndex = 15;
            // 
            // cmdLoad
            // 
            this.cmdLoad.BackColor = System.Drawing.Color.Transparent;
            this.cmdLoad.Location = new System.Drawing.Point(203, 504);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(117, 33);
            this.cmdLoad.TabIndex = 13;
            this.cmdLoad.Text = "Load Query";
            this.cmdLoad.UseVisualStyleBackColor = false;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Location = new System.Drawing.Point(327, 504);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(117, 33);
            this.cmdSave.TabIndex = 14;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 554);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCondition.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdAddCondition;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFieldInfo;
        private System.Windows.Forms.TabPage tabCondition;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Panel panFilter;
    }
}