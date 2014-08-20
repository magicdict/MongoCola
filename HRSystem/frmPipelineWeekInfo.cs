using System;
using System.Windows.Forms;

namespace HRSystem
{
    public partial class frmPipelineWeekInfo : Form
    {
        ViewControl.HiringTrackingDelegate condition = (x) => { return true; };

        public frmPipelineWeekInfo()
        {
            InitializeComponent();
        }

        private void frmPipelineWeekInfo_Load(object sender, EventArgs e)
        {
            cmbPosition.Items.Add("<All>");
            foreach (var pos in DataCenter.PositionBasicDataSet)
            {
                if (pos.isOpen) cmbPosition.Items.Add(pos.Position);
            }
            ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByScreenDate(DateTime.Now, DateTime.Now), condition);
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPosition.SelectedIndex == 0)
            {
                condition = (x) => { return true; };
            }
            else
            {
                condition = (x) => { return x.Position == cmbPosition.Text; };
            }
            ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByScreenDate(WeekStart.Value, WeekEnd.Value), condition);
        }

        private void WeekStart_ValueChanged(object sender, EventArgs e)
        {
            ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByScreenDate(WeekStart.Value, WeekEnd.Value), condition);
        }

        private void WeekEnd_ValueChanged(object sender, EventArgs e)
        {
            ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByScreenDate(WeekStart.Value, WeekEnd.Value), condition);
        }
    }
}
