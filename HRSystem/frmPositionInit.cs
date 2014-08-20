using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HRSystem
{
    public partial class frmPositionInit : Form
    {
        string Position = string.Empty;
        bool IsCreate = false;
        PositionBasicInfo basic = new PositionBasicInfo();
        public frmPositionInit(string position)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(position))
            {
                IsCreate = false;
                basic = DataCenter.GetBasicPositionInfo(position);
            }
            else
            {
                IsCreate = true;
            }
        }
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPositionInit_Load(object sender, EventArgs e)
        {
            Utility.FillComberWithEnum(cmbHiringType, typeof(PositionBasicInfo.HiringTypeEnum));
            string[] BandArray = new string[] { "6A", "6B", "7A", "7B", "8A", "8B" };
            Utility.FillComberWithArray(cmbLBound, BandArray);
            Utility.FillComberWithArray(cmbHBound, BandArray);
            Utility.FillComberWithArray(cmbHiringManager, SystemManager.HiringManagerArray);
            if (!IsCreate)
            {
                txtPosition.Text = basic.Position;
                txtPosition.Enabled = false;
                cmbHiringManager.Text = basic.HiringManager;
                cmbHiringType.SelectedIndex = basic.HiringType.GetHashCode();
                cmbLBound.SelectedIndex = basic.BandLBound.GetHashCode();
                cmbHBound.SelectedIndex = basic.BandHBound.GetHashCode();
                NumTarget.Value = basic.Target;
                DataPickerApprovedDate.Value = basic.ApprovedDate;
                DataPickerOpenDate.Value = basic.OpenDate;
            }
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            basic.No = (DataCenter.PositionBasicDataSet.Count + 1).ToString();
            basic.Position = txtPosition.Text;
            basic.HiringManager = cmbHiringManager.Text;
            basic.ApprovedDate = DataPickerApprovedDate.Value;
            basic.OpenDate = DataPickerOpenDate.Value;
            basic.Target = (int)NumTarget.Value;
            basic.isOpen = true;
            basic.BandHBound = (PositionBasicInfo.BandEnum)cmbHBound.SelectedIndex;
            basic.BandLBound = (PositionBasicInfo.BandEnum)cmbLBound.SelectedIndex;
            basic.HiringType = (PositionBasicInfo.HiringTypeEnum)cmbHiringType.SelectedIndex;
            if (IsCreate)
            {
                DataCenter.PositionBasicDataSet.Add(basic);
            }
            DataCenter.SaveBasicPosition();
            Close();
        }
    }
}
