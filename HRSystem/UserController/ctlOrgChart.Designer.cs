namespace HRSystem
{
    partial class ctlOrgChart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbHiringType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHiringManager = new System.Windows.Forms.ComboBox();
            this.lstPosition = new System.Windows.Forms.ListView();
            this.GMC_MCC_Leader = new HRSystem.UserController.ctlPersonal();
            this.Digital_Manager = new HRSystem.UserController.ctlPersonal();
            this.Compain_Planner = new HRSystem.UserController.ctlPersonal();
            this.Marketing_Campaign_Specialist = new HRSystem.UserController.ctlPersonal();
            this.Demand_Programs = new HRSystem.UserController.ctlPersonal();
            this.DBM_Manager = new HRSystem.UserController.ctlPersonal();
            this.Market_Segment_Manager = new HRSystem.UserController.ctlPersonal();
            this.Market_Comms_Operations = new HRSystem.UserController.ctlPersonal();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GMC_MCC_Leader);
            this.splitContainer1.Panel1.Controls.Add(this.Digital_Manager);
            this.splitContainer1.Panel1.Controls.Add(this.Compain_Planner);
            this.splitContainer1.Panel1.Controls.Add(this.Marketing_Campaign_Specialist);
            this.splitContainer1.Panel1.Controls.Add(this.Demand_Programs);
            this.splitContainer1.Panel1.Controls.Add(this.DBM_Manager);
            this.splitContainer1.Panel1.Controls.Add(this.Market_Segment_Manager);
            this.splitContainer1.Panel1.Controls.Add(this.Market_Comms_Operations);
            this.splitContainer1.Panel1MinSize = 350;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.cmbHiringType);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.cmbHiringManager);
            this.splitContainer1.Panel2.Controls.Add(this.lstPosition);
            this.splitContainer1.Size = new System.Drawing.Size(1379, 524);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 8;
            // 
            // cmbHiringType
            // 
            this.cmbHiringType.FormattingEnabled = true;
            this.cmbHiringType.Location = new System.Drawing.Point(333, 5);
            this.cmbHiringType.Name = "cmbHiringType";
            this.cmbHiringType.Size = new System.Drawing.Size(97, 21);
            this.cmbHiringType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hiring Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Hiring Manager";
            // 
            // cmbHiringManager
            // 
            this.cmbHiringManager.FormattingEnabled = true;
            this.cmbHiringManager.Location = new System.Drawing.Point(98, 5);
            this.cmbHiringManager.Name = "cmbHiringManager";
            this.cmbHiringManager.Size = new System.Drawing.Size(121, 21);
            this.cmbHiringManager.TabIndex = 9;
            // 
            // lstPosition
            // 
            this.lstPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPosition.FullRowSelect = true;
            this.lstPosition.GridLines = true;
            this.lstPosition.Location = new System.Drawing.Point(17, 43);
            this.lstPosition.Name = "lstPosition";
            this.lstPosition.Size = new System.Drawing.Size(1345, 91);
            this.lstPosition.TabIndex = 8;
            this.lstPosition.UseCompatibleStateImageBehavior = false;
            this.lstPosition.View = System.Windows.Forms.View.Details;
            // 
            // GMC_MCC_Leader
            // 
            this.GMC_MCC_Leader.BackColor = System.Drawing.Color.White;
            this.GMC_MCC_Leader.Location = new System.Drawing.Point(322, 0);
            this.GMC_MCC_Leader.Name = "GMC_MCC_Leader";
            this.GMC_MCC_Leader.Size = new System.Drawing.Size(311, 91);
            this.GMC_MCC_Leader.TabIndex = 0;
            // 
            // Digital_Manager
            // 
            this.Digital_Manager.BackColor = System.Drawing.Color.White;
            this.Digital_Manager.Location = new System.Drawing.Point(652, 111);
            this.Digital_Manager.Name = "Digital_Manager";
            this.Digital_Manager.Size = new System.Drawing.Size(311, 91);
            this.Digital_Manager.TabIndex = 5;
            // 
            // Compain_Planner
            // 
            this.Compain_Planner.BackColor = System.Drawing.Color.White;
            this.Compain_Planner.Location = new System.Drawing.Point(652, 200);
            this.Compain_Planner.Name = "Compain_Planner";
            this.Compain_Planner.Size = new System.Drawing.Size(311, 91);
            this.Compain_Planner.TabIndex = 7;
            // 
            // Marketing_Campaign_Specialist
            // 
            this.Marketing_Campaign_Specialist.BackColor = System.Drawing.Color.White;
            this.Marketing_Campaign_Specialist.Location = new System.Drawing.Point(322, 200);
            this.Marketing_Campaign_Specialist.Name = "Marketing_Campaign_Specialist";
            this.Marketing_Campaign_Specialist.Size = new System.Drawing.Size(311, 91);
            this.Marketing_Campaign_Specialist.TabIndex = 6;
            // 
            // Demand_Programs
            // 
            this.Demand_Programs.BackColor = System.Drawing.Color.White;
            this.Demand_Programs.Location = new System.Drawing.Point(5, 111);
            this.Demand_Programs.Name = "Demand_Programs";
            this.Demand_Programs.Size = new System.Drawing.Size(311, 91);
            this.Demand_Programs.TabIndex = 1;
            // 
            // DBM_Manager
            // 
            this.DBM_Manager.BackColor = System.Drawing.Color.White;
            this.DBM_Manager.Location = new System.Drawing.Point(322, 111);
            this.DBM_Manager.Name = "DBM_Manager";
            this.DBM_Manager.Size = new System.Drawing.Size(311, 91);
            this.DBM_Manager.TabIndex = 4;
            // 
            // Market_Segment_Manager
            // 
            this.Market_Segment_Manager.BackColor = System.Drawing.Color.White;
            this.Market_Segment_Manager.Location = new System.Drawing.Point(5, 286);
            this.Market_Segment_Manager.Name = "Market_Segment_Manager";
            this.Market_Segment_Manager.Size = new System.Drawing.Size(311, 91);
            this.Market_Segment_Manager.TabIndex = 2;
            // 
            // Market_Comms_Operations
            // 
            this.Market_Comms_Operations.BackColor = System.Drawing.Color.White;
            this.Market_Comms_Operations.Location = new System.Drawing.Point(5, 374);
            this.Market_Comms_Operations.Name = "Market_Comms_Operations";
            this.Market_Comms_Operations.Size = new System.Drawing.Size(311, 91);
            this.Market_Comms_Operations.TabIndex = 3;
            // 
            // ctlOrgChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ctlOrgChart";
            this.Size = new System.Drawing.Size(1379, 524);
            this.Load += new System.EventHandler(this.ctlOrgChart_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.ctlPersonal GMC_MCC_Leader;
        private UserController.ctlPersonal Demand_Programs;
        private UserController.ctlPersonal Market_Segment_Manager;
        private UserController.ctlPersonal Market_Comms_Operations;
        private UserController.ctlPersonal DBM_Manager;
        private UserController.ctlPersonal Digital_Manager;
        private UserController.ctlPersonal Marketing_Campaign_Specialist;
        private UserController.ctlPersonal Compain_Planner;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbHiringType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHiringManager;
        private System.Windows.Forms.ListView lstPosition;
    }
}
