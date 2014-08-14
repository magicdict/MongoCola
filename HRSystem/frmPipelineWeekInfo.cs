using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HRSystem
{
    public partial class frmPipelineWeekInfo : Form
    {
        public frmPipelineWeekInfo()
        {
            InitializeComponent();
        }

        private void frmPipelineWeekInfo_Load(object sender, EventArgs e)
        {
            ViewControl.FillHiringTrackingListView(lstHiringTracking, CreatePositionReport.GetHiringTrackByScreenDate(System.DateTime.Now,System.DateTime.Now));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ViewControl.FillHiringTrackingListView(lstHiringTracking, CreatePositionReport.GetHiringTrackByScreenDate(WeekStart.Value, WeekEnd.Value));
        }
    }
}
