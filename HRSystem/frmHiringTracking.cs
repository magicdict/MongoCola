using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HRSystem
{
    public partial class frmHiringTracking : Form
    {
        ViewControl.HiringTrackingDelegate condition = (x) => { return true; };
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
                ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackByPosition(Position), condition);
                btnClosePosition.Enabled = DataCenter.GetPositionStatisticInfo(Position).Gap == 0;
            }
            else
            {
                ViewControl.FillHiringTrackingListView(lstHiringTracking, DataCenter.GetHiringTrackingDataSet(), condition);
                btnEditPosition.Enabled = false;
            }
        }
        /// <summary>
        /// cmbFinalStatus Select Index Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFinalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var target = GetTarget();
            if (cmbFinalStatus.SelectedIndex != 0)
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
            }
            ViewControl.FillHiringTrackingListView(lstHiringTracking, target, condition);
        }

        private List<HiringTracking> GetTarget()
        {
            if (cmbFinalStatus.SelectedIndex == 0)
            {
                if (Position != SystemManager.strTotal)
                {
                    return DataCenter.GetHiringTrackByPosition(Position);
                }
                else
                {
                    return DataCenter.GetHiringTrackingDataSet();
                }
            }
            else
            {
                HiringTracking.FinalStatusEnum FinalStatus = (HiringTracking.FinalStatusEnum)cmbFinalStatus.SelectedIndex - 1;
                if (Position != SystemManager.strTotal)
                {
                    return DataCenter.GetHiringTrackByPosition(Position, FinalStatus);
                }
                else
                {
                    return DataCenter.GetHiringTrackByFinalStatus(FinalStatus);
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
        /// <summary>
        /// Close Position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClosePosition_Click(object sender, EventArgs e)
        {
            DataCenter.GetBasicPositionInfo(Position).isOpen = false;
            XmlSerializer xml = new XmlSerializer(typeof(List<PositionBasicInfo>));
            xml.Serialize(new StreamWriter(SystemManager.PositionBasicInfoXmlFilename), DataCenter.PositionBasicDataSet);
            DataCenter.ReCompute();
            Close();
        }
        /// <summary>
        /// Edit Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditPosition_Click(object sender, EventArgs e)
        {
            (new frmPositionInit(Position)).ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string filename = string.Empty;
            FileDialog saver = new SaveFileDialog();
            saver.Filter = "(*.xls)|*.xls";
            if (saver.ShowDialog() == DialogResult.OK)
            {
                filename = saver.FileName;
                Utility.getResource(filename, "Template.xls");
            }else
            {
                return;
            }
            List<HiringTracking> export = GetTarget();
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(filename);
            HiringTracking.ExportData(workbook, export);
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
            MessageBox.Show("Export Complete!");
        }
    }
}
