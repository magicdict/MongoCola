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
            ViewControl.FillHiringTrackingListView(lstHiringTracking, CreatePositionReport.GetHiringTrackByPosition(Position));
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
                ViewControl.FillHiringTrackingListView(lstHiringTracking, CreatePositionReport.GetHiringTrackByPosition(Position));

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
                ViewControl.FillHiringTrackingListView(lstHiringTracking, CreatePositionReport.GetHiringTrackByPosition(Position, FinalStatus));
            }
        }
    }
}
