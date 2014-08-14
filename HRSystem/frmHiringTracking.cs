using System;
using System.Windows.Forms;

namespace HRSystem
{
    public partial class frmHiringTracking : Form
    {
        /// <summary>
        /// Position
        /// </summary>
        private string Position;
        /// <summary>
        /// New Method
        /// </summary>
        /// <param name="_position"></param>
        public frmHiringTracking(String _position)
        {
            InitializeComponent();
            Position = _position;
            Text = "Position:" + Position;
            Utility.FillComberWithEnum(cmbFinalStatus, typeof(HiringTracking.FinalStatusEnum),false);
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHiringTracking_Load(object sender, EventArgs e)
        {
            if (Position != SystemManager.strTotal)
            {
                ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByPosition(Position));
            }
            else
            {
                ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackingDataSet());
            }
        }
        /// <summary>
        /// cmbFinalStatus Select Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFinalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFinalStatus.SelectedIndex == 0)
            {
                if (Position != SystemManager.strTotal)
                {
                    ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByPosition(Position));
                }
                else
                {
                    ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackingDataSet());
                }
            }
            else
            {
                HiringTracking.FinalStatusEnum FinalStatus = (HiringTracking.FinalStatusEnum)cmbFinalStatus.SelectedIndex - 1;
                ViewControl.ResetHiringTrackingField();
                switch (FinalStatus)
                {
                    case HiringTracking.FinalStatusEnum.OpenOffer:
                    case HiringTracking.FinalStatusEnum.ANOB:
                    case HiringTracking.FinalStatusEnum.Onboard:
                        ViewControl.CurrentHiringTrackingFields = ViewStyleSheet.HiringTracking_OnboardSytle;
                        break;
                    case HiringTracking.FinalStatusEnum.RejectOffer:
                        ViewControl.CurrentHiringTrackingFields = ViewStyleSheet.HiringTracking_RejectOfferSytle;
                        break;
                }
                if (Position != SystemManager.strTotal)
                {
                    ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByPosition(Position, FinalStatus));
                }
                else
                {
                    ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByFinalStatus(FinalStatus));
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstHiringTracking.SelectedItems.Count == 1)
            {
                string No = lstHiringTracking.SelectedItems[0].Text;
                var hiring = DataCenter.HiringTrackingDataSet.Find((x) => { return x.No == No; });
                hiring.IsDel = true;
                DataCenter.SaveHiringTrack();
                cmbFinalStatus_SelectedIndexChanged(null, null);
            }
        }
        private void lstHiringTracking_DoubleClick(object sender, EventArgs e)
        {
            if (lstHiringTracking.SelectedItems.Count == 1)
            {
                string No = lstHiringTracking.SelectedItems[0].Text;
                (new frmCandidateEditor(No)).ShowDialog();
                cmbFinalStatus_SelectedIndexChanged(null, null);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditor_Click(object sender, EventArgs e)
        {
            string No = lstHiringTracking.SelectedItems[0].Text;
            (new frmCandidateEditor(No)).ShowDialog();
        }
    }
}
