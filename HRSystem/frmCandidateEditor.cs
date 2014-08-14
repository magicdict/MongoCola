using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HRSystem
{
    public partial class frmCandidateEditor : Form
    {
        HiringTracking hiring = new HiringTracking();
        bool IsCreate = false;
        public frmCandidateEditor(string No)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(No))
            {
                IsCreate = false;
                hiring = DataCenter.HiringTrackingDataSet.Find((x) => { return x.No == No; });
            }
            else
            {
                IsCreate = true;
            }
        }

        private void candidateEditor_Load(object sender, System.EventArgs e)
        {
            Utility.FillComberWithEnum(cmbChannel, typeof(HiringTracking.ChannelEnum));
            Utility.FillComberWithEnum(cmbFinalStatus, typeof(HiringTracking.FinalStatusEnum));
            Utility.FillComberWithEnum(cmbFirstInterviewResult, typeof(HiringTracking.InterviewResultEnum));
            Utility.FillComberWithEnum(cmbSecondInterviewResult, typeof(HiringTracking.InterviewResultEnum));
            Utility.FillComberWithEnum(cmbThirdInterviewResult, typeof(HiringTracking.InterviewResultEnum));
            foreach (var pos in DataCenter.PositionBasicDataSet)
            {
                if (pos.isOpen) cmbPosition.Items.Add(pos.Position);
            }
            if (!IsCreate)
            {
                txtName.Text = hiring.Name;
                txtContact.Text = hiring.Contact;
                txtUniversity.Text = hiring.University;
                txtMajor.Text = hiring.Major;
                txtComments.Text = hiring.Comments;
                txtFirstInterviewer.Text = hiring.FirstInterviewer;
                txtSecondInterviewer.Text = hiring.SecondInterviewer;
                txtThirdInterviewer.Text = hiring.ThirdInterviewer;
                //Language
                chkChinese.Checked = (hiring.Language & HiringTracking.LanguageEnum.CN) == HiringTracking.LanguageEnum.CN;
                chkEnglish.Checked = (hiring.Language & HiringTracking.LanguageEnum.EN) == HiringTracking.LanguageEnum.EN;
                chkJapanese.Checked = (hiring.Language & HiringTracking.LanguageEnum.JP) == HiringTracking.LanguageEnum.JP;
                chkKorea.Checked = (hiring.Language & HiringTracking.LanguageEnum.KR) == HiringTracking.LanguageEnum.KR;
                chkOtherLanguage.Checked = (hiring.Language & HiringTracking.LanguageEnum.Other) == HiringTracking.LanguageEnum.Other;
                chkITBackground.Checked = hiring.ITBackground;
                chkMarketBackground.Checked = hiring.MarketBackground;

                dateScreen.Value = hiring.ScreenDate;
                dateFirstInterview.Value = hiring.FirstInterviewDate;
                dateSecondInterview.Value = hiring.SecondInterviewDate;
                dateThirdInterview.Value = hiring.ThirdInterviewDate;

                cmbChannel.SelectedIndex = hiring.Channel.GetHashCode();
                cmbFinalStatus.SelectedIndex = hiring.FinalStatus.GetHashCode();
                cmbFirstInterviewResult.SelectedIndex = hiring.FirstInterviewResult.GetHashCode();
                cmbSecondInterviewResult.SelectedIndex = hiring.SecondInterviewResult.GetHashCode();
                cmbThirdInterviewResult.SelectedIndex = hiring.ThirdInterviewResult.GetHashCode();

                cmbPosition.Text = hiring.Position;
                ListResume();

            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            //Set Data
            hiring.Name = txtName.Text;
            hiring.Contact = txtContact.Text;
            hiring.University = txtUniversity.Text;
            hiring.Major = txtMajor.Text;
            hiring.Comments = txtComments.Text;
            hiring.FirstInterviewer = txtFirstInterviewer.Text;
            hiring.SecondInterviewer = txtSecondInterviewer.Text;
            hiring.ThirdInterviewer = txtThirdInterviewer.Text;
            //Language
            hiring.Language = HiringTracking.LanguageEnum.None;
            if (chkChinese.Checked) hiring.Language |= HiringTracking.LanguageEnum.CN;
            if (chkEnglish.Checked) hiring.Language |= HiringTracking.LanguageEnum.EN;
            if (chkJapanese.Checked) hiring.Language |= HiringTracking.LanguageEnum.JP;
            if (chkKorea.Checked) hiring.Language |= HiringTracking.LanguageEnum.KR;
            if (chkOtherLanguage.Checked) hiring.Language |= HiringTracking.LanguageEnum.Other;
            hiring.ITBackground = chkITBackground.Checked;
            hiring.MarketBackground = chkMarketBackground.Checked;

            hiring.ScreenDate = dateScreen.Value;
            hiring.FirstInterviewDate = dateFirstInterview.Value;
            hiring.SecondInterviewDate = dateSecondInterview.Value;
            hiring.ThirdInterviewDate = dateThirdInterview.Value;

            hiring.Channel = (HiringTracking.ChannelEnum)cmbChannel.SelectedIndex;
            hiring.FinalStatus = (HiringTracking.FinalStatusEnum)cmbFinalStatus.SelectedIndex;
            hiring.FirstInterviewResult = (HiringTracking.InterviewResultEnum)cmbFirstInterviewResult.SelectedIndex;
            hiring.SecondInterviewResult = (HiringTracking.InterviewResultEnum)cmbSecondInterviewResult.SelectedIndex;
            hiring.ThirdInterviewResult = (HiringTracking.InterviewResultEnum)cmbThirdInterviewResult.SelectedIndex;

            hiring.Position = cmbPosition.Text;

            if (IsCreate)
            {
                hiring.No = "C" + (DataCenter.HiringTrackingDataSet.Count + 1).ToString("D6");
                DataCenter.HiringTrackingDataSet.Add(hiring);
            }
            DataCenter.SaveHiringTrack();
            Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, System.EventArgs e)
        {
            if (IsCreate)
            {
                hiring.No = "C" + (DataCenter.HiringTrackingDataSet.Count + 1).ToString("D6");
            }
            if (!Directory.Exists(Application.StartupPath + "\\Resume\\" + hiring.No)) Directory.CreateDirectory(Application.StartupPath + "\\Resume\\" + hiring.No);

            FileInfo sourcefile = new FileInfo(ctlResumeFilePicker.SelectedPathOrFileName);
            string targetFilename = Application.StartupPath + "\\Resume\\" + hiring.No + "\\" + sourcefile.Name;
            if (File.Exists(targetFilename))
            {
                File.Move(targetFilename, targetFilename + "_backup_" + System.DateTime.Now.ToString("yyyyMMddHHmmss"));
            }
            File.Copy(sourcefile.FullName, targetFilename);
            ListResume();
        }

        private void ListResume()
        {
            if (IsCreate)
            {
                hiring.No = "C" + (DataCenter.HiringTrackingDataSet.Count + 1).ToString("D6");
            }
            lstResume.Items.Clear();
            if (Directory.Exists(Application.StartupPath + "\\Resume\\" + hiring.No))
            {
                foreach (var resumefile in Directory.GetFiles(Application.StartupPath + "\\Resume\\" + hiring.No))
                {
                  if (!resumefile.Contains("_backup_"))  lstResume.Items.Add(resumefile);
                }
            }

        }
        /// <summary>
        /// 打开简历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstResume_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstResume.SelectedItems.Count == 1)
            {
                System.Diagnostics.Process.Start(lstResume.SelectedItems[0].ToString());
            }
        }
        /// <summary>
        /// 删除简历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (lstResume.SelectedItems.Count == 1)
            {
                File.Move(lstResume.SelectedItems[0].ToString(), lstResume.SelectedItems[0].ToString() + "_backup_" + System.DateTime.Now.ToString("yyyyMMddHHmmss"));
                ListResume();
            }
        }
    }
}
