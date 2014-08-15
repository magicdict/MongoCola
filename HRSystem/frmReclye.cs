using System;
using System.Windows.Forms;

namespace HRSystem
{
    public partial class frmReclye : Form
    {
        public frmReclye()
        {
            InitializeComponent();
        }
        /// <summary>
        /// load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReclye_Load(object sender, EventArgs e)
        {
            ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackingDataSet(true));
        }
        /// <summary>
        /// Restore
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (lstHiringTracking.SelectedItems.Count == 1)
            {
                string No = lstHiringTracking.SelectedItems[0].Text;
                var hiring = DataCenter.HiringTrackingDataSet.Find((x) => { return x.No == No; });
                hiring.IsDel = false;
                DataCenter.SaveHiringTrack();
                ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackingDataSet(true));
            }
        }
    }
}
