using System.Windows.Forms;

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
                hiring = CreatePositionReport.HiringTrackingDataSet.Find((x) => { return x.No == No; });
            }
        }

        private void candidateEditor_Load(object sender, System.EventArgs e)
        {
            Utility.FillComberWithEnum(cmbChannel, typeof(HiringTracking.ChannelEnum));
            Utility.FillComberWithEnum(cmbFinalStatus, typeof(HiringTracking.FinalStatusEnum));
            Utility.FillComberWithEnum(cmbFirstInterviewResult, typeof(HiringTracking.InterviewResultEnum));
            Utility.FillComberWithEnum(cmbSecondInterviewResult, typeof(HiringTracking.InterviewResultEnum));
            Utility.FillComberWithEnum(cmbThirdInterviewResult, typeof(HiringTracking.InterviewResultEnum));

            if (!IsCreate)
            {
                txtName.Text = hiring.Name;
                txtContact.Text = hiring.Contact;
                txtUniversity.Text = hiring.University;
                //Language
                chkChinese.Checked = (hiring.Language & HiringTracking.LanguageEnum.CN) == HiringTracking.LanguageEnum.CN;
                chkEnglish.Checked = (hiring.Language & HiringTracking.LanguageEnum.EN) == HiringTracking.LanguageEnum.EN;
                chkJapanese.Checked = (hiring.Language & HiringTracking.LanguageEnum.JP) == HiringTracking.LanguageEnum.JP;
                chkKorea.Checked = (hiring.Language & HiringTracking.LanguageEnum.KR) == HiringTracking.LanguageEnum.KR;
                chkOtherLanguage.Checked = (hiring.Language & HiringTracking.LanguageEnum.Other) == HiringTracking.LanguageEnum.Other;

                txtMajor.Text = hiring.Major;
                txtComments.Text = hiring.Comments;
                txtFirstInterviewer.Text = hiring.FirstInterviewer;
                txtSecondInterviewer.Text = hiring.SecondInterviewer;
                txtThirdInterviewer.Text = hiring.ThirdInterviewer;
            }
        }
    }
}
