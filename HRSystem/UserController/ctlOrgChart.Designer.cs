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
            this.Digital_Manager = new HRSystem.UserController.ctlPersonal();
            this.DBM_Manager = new HRSystem.UserController.ctlPersonal();
            this.Market_Comms_Operations = new HRSystem.UserController.ctlPersonal();
            this.Market_Segment_Manager = new HRSystem.UserController.ctlPersonal();
            this.Demand_Programs = new HRSystem.UserController.ctlPersonal();
            this.GMC_MCC_Leader = new HRSystem.UserController.ctlPersonal();
            this.Marketing_Campaign_Specialist = new HRSystem.UserController.ctlPersonal();
            this.Compain_Planner = new HRSystem.UserController.ctlPersonal();
            this.SuspendLayout();
            // 
            // Digital_Manager
            // 
            this.Digital_Manager.BackColor = System.Drawing.Color.White;
            this.Digital_Manager.Location = new System.Drawing.Point(20, 369);
            this.Digital_Manager.Name = "Digital_Manager";
            this.Digital_Manager.Size = new System.Drawing.Size(311, 91);
            this.Digital_Manager.TabIndex = 5;
            // 
            // DBM_Manager
            // 
            this.DBM_Manager.BackColor = System.Drawing.Color.White;
            this.DBM_Manager.Location = new System.Drawing.Point(20, 272);
            this.DBM_Manager.Name = "DBM_Manager";
            this.DBM_Manager.Size = new System.Drawing.Size(311, 91);
            this.DBM_Manager.TabIndex = 4;
            // 
            // Market_Comms_Operations
            // 
            this.Market_Comms_Operations.BackColor = System.Drawing.Color.White;
            this.Market_Comms_Operations.Location = new System.Drawing.Point(828, 162);
            this.Market_Comms_Operations.Name = "Market_Comms_Operations";
            this.Market_Comms_Operations.Size = new System.Drawing.Size(311, 91);
            this.Market_Comms_Operations.TabIndex = 3;
            // 
            // Market_Segment_Manager
            // 
            this.Market_Segment_Manager.BackColor = System.Drawing.Color.White;
            this.Market_Segment_Manager.Location = new System.Drawing.Point(413, 162);
            this.Market_Segment_Manager.Name = "Market_Segment_Manager";
            this.Market_Segment_Manager.Size = new System.Drawing.Size(311, 91);
            this.Market_Segment_Manager.TabIndex = 2;
            // 
            // Demand_Programs
            // 
            this.Demand_Programs.BackColor = System.Drawing.Color.White;
            this.Demand_Programs.Location = new System.Drawing.Point(20, 162);
            this.Demand_Programs.Name = "Demand_Programs";
            this.Demand_Programs.Size = new System.Drawing.Size(311, 91);
            this.Demand_Programs.TabIndex = 1;
            // 
            // GMC_MCC_Leader
            // 
            this.GMC_MCC_Leader.BackColor = System.Drawing.Color.White;
            this.GMC_MCC_Leader.Location = new System.Drawing.Point(413, 25);
            this.GMC_MCC_Leader.Name = "GMC_MCC_Leader";
            this.GMC_MCC_Leader.Size = new System.Drawing.Size(311, 91);
            this.GMC_MCC_Leader.TabIndex = 0;
            // 
            // Marketing_Campaign
            // 
            this.Marketing_Campaign_Specialist.BackColor = System.Drawing.Color.White;
            this.Marketing_Campaign_Specialist.Location = new System.Drawing.Point(20, 466);
            this.Marketing_Campaign_Specialist.Name = "Marketing_Campaign";
            this.Marketing_Campaign_Specialist.Size = new System.Drawing.Size(311, 91);
            this.Marketing_Campaign_Specialist.TabIndex = 6;
            // 
            // ctlPersonal2
            // 
            this.Compain_Planner.BackColor = System.Drawing.Color.White;
            this.Compain_Planner.Location = new System.Drawing.Point(20, 563);
            this.Compain_Planner.Name = "ctlPersonal2";
            this.Compain_Planner.Size = new System.Drawing.Size(311, 91);
            this.Compain_Planner.TabIndex = 7;
            // 
            // ctlOrgChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Compain_Planner);
            this.Controls.Add(this.Marketing_Campaign_Specialist);
            this.Controls.Add(this.Digital_Manager);
            this.Controls.Add(this.DBM_Manager);
            this.Controls.Add(this.Market_Comms_Operations);
            this.Controls.Add(this.Market_Segment_Manager);
            this.Controls.Add(this.Demand_Programs);
            this.Controls.Add(this.GMC_MCC_Leader);
            this.Name = "ctlOrgChart";
            this.Size = new System.Drawing.Size(1379, 667);
            this.Load += new System.EventHandler(this.ctlOrgChart_Load);
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
    }
}
