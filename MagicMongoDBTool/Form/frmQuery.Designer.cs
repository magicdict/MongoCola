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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery));
            this.cmdAddCondition = new System.Windows.Forms.VistaButton();
            this.cmdOK = new System.Windows.Forms.VistaButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFieldInfo = new System.Windows.Forms.TabPage();
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.cmdLoad = new System.Windows.Forms.VistaButton();
            this.cmdSave = new System.Windows.Forms.VistaButton();
            this.panFilter = new System.Windows.Forms.Panel();
            this.contentPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("contentPanel.BackgroundImage")));
            this.contentPanel.Controls.Add(this.cmdSave);
            this.contentPanel.Controls.Add(this.cmdLoad);
            this.contentPanel.Controls.Add(this.tabControl);
            this.contentPanel.Controls.Add(this.cmdOK);
            this.contentPanel.Location = new System.Drawing.Point(1, 38);
            this.contentPanel.Size = new System.Drawing.Size(531, 465);
            // 
            // cmdAddCondition
            // 
            this.cmdAddCondition.BackColor = System.Drawing.Color.Transparent;
            this.cmdAddCondition.Location = new System.Drawing.Point(365, 341);
            this.cmdAddCondition.Name = "cmdAddCondition";
            this.cmdAddCondition.Size = new System.Drawing.Size(114, 31);
            this.cmdAddCondition.TabIndex = 14;
            this.cmdAddCondition.Text = "新增过滤条件";
            this.cmdAddCondition.Click += new System.EventHandler(this.cmdAddCondition_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Location = new System.Drawing.Point(383, 426);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(114, 29);
            this.cmdOK.TabIndex = 12;
            this.cmdOK.Text = "确定";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFieldInfo);
            this.tabControl.Controls.Add(this.tabFilter);
            this.tabControl.Location = new System.Drawing.Point(14, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(496, 404);
            this.tabControl.TabIndex = 0;
            // 
            // tabFieldInfo
            // 
            this.tabFieldInfo.Location = new System.Drawing.Point(4, 22);
            this.tabFieldInfo.Name = "tabFieldInfo";
            this.tabFieldInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldInfo.Size = new System.Drawing.Size(488, 378);
            this.tabFieldInfo.TabIndex = 0;
            this.tabFieldInfo.Text = "字段表示和排序";
            this.tabFieldInfo.UseVisualStyleBackColor = true;
            // 
            // tabFilter
            // 
            this.tabFilter.Controls.Add(this.panFilter);
            this.tabFilter.Controls.Add(this.cmdAddCondition);
            this.tabFilter.Location = new System.Drawing.Point(4, 22);
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilter.Size = new System.Drawing.Size(488, 378);
            this.tabFilter.TabIndex = 1;
            this.tabFilter.Text = "字段过滤条件";
            this.tabFilter.UseVisualStyleBackColor = true;
            // 
            // cmdLoad
            // 
            this.cmdLoad.BackColor = System.Drawing.Color.Transparent;
            this.cmdLoad.Location = new System.Drawing.Point(171, 426);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(100, 29);
            this.cmdLoad.TabIndex = 13;
            this.cmdLoad.Text = "加载";
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.Transparent;
            this.cmdSave.Location = new System.Drawing.Point(277, 426);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 29);
            this.cmdSave.TabIndex = 14;
            this.cmdSave.Text = "保存";
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // panFilter
            // 
            this.panFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panFilter.Location = new System.Drawing.Point(3, 3);
            this.panFilter.Name = "panFilter";
            this.panFilter.Size = new System.Drawing.Size(482, 332);
            this.panFilter.TabIndex = 15;
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 528);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmQuery";
            this.ShowSelectSkinButton = false;
            this.Text = "数据查询";
            this.Load += new System.EventHandler(this.frmQuery_Load);
            this.contentPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VistaButton cmdAddCondition;
        private System.Windows.Forms.VistaButton cmdOK;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFieldInfo;
        private System.Windows.Forms.TabPage tabFilter;
        private System.Windows.Forms.VistaButton cmdSave;
        private System.Windows.Forms.VistaButton cmdLoad;
        private System.Windows.Forms.Panel panFilter;
    }
}