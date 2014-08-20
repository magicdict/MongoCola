using System.Windows.Forms;

namespace HRSystem
{
    public partial class ctlOrgChart : UserControl
    {
        public ctlOrgChart()
        {
            InitializeComponent();
        }

        private void ctlOrgChart_Load(object sender, System.EventArgs e)
        {
            //GMC MCC  Leader
            GMC_MCC_Leader.imgFace = Properties.Resources.Paul_Ambraz;
            GMC_MCC_Leader.Position = "GMC MCC Leader";
            GMC_MCC_Leader.PersonName = "Paul Ambraz";
            GMC_MCC_Leader.Department = string.Empty;

            //Demand_Programs
            Demand_Programs.imgFace = Properties.Resources.Li_Ling;
            Demand_Programs.Position = "DP Leader";
            Demand_Programs.PersonName = "Li Ling";
            Demand_Programs.Department = "Demand Programs";

            //DBM_Manager
            DBM_Manager.imgFace = Properties.Resources.Li_Bing;
            DBM_Manager.Position = "DBM Manager";
            DBM_Manager.PersonName = "Li Bing";
            DBM_Manager.Department = "Demand Programs";

            //Digital_Manager
            Digital_Manager.imgFace = Properties.Resources.Jiang_Mei_Shan;
            Digital_Manager.Position = "Digital Manager";
            Digital_Manager.PersonName = "Jiang Mei Shan";
            Digital_Manager.Department = "Demand Programs";

            //Marketing & Campaign Specialist 
            //Marketing_Campaign_Specialist.imgFace = Properties.Resources.Li_Ling;
            Marketing_Campaign_Specialist.Position = "Marketing & Campaign Specialist";
            Marketing_Campaign_Specialist.PersonName = string.Empty;
            Marketing_Campaign_Specialist.Department = "Demand Programs";

            //Compain Planner
            //Compain_Planner.imgFace = Properties.Resources.Li_Ling;
            Compain_Planner.Position = "Compain Planner";
            Compain_Planner.PersonName = string.Empty;
            Compain_Planner.Department = "Demand Programs";

            //Market Segment Manager
            Market_Segment_Manager.imgFace = Properties.Resources.Yi_Sang_Min;
            Market_Segment_Manager.Position = "MSM Leader";
            Market_Segment_Manager.PersonName = "Yi Sang Min";
            Market_Segment_Manager.Department = "Market Segment Manager";

            //Market_Comms_Operations
            Market_Comms_Operations.imgFace = Properties.Resources.Hou_Yan;
            Market_Comms_Operations.Position = "MCO Leader";
            Market_Comms_Operations.PersonName = "Hou Yan";
            Market_Comms_Operations.Department = "Market & Comms Operations";
        }
    }
}
