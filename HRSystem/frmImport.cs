using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace HRSystem
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            dynamic excelObj = Interaction.CreateObject("Excel.Application");
            excelObj.Visible = true;
            dynamic workbook;
            workbook = excelObj.Workbooks.Open(ExcelPicker.SelectedPathOrFileName);
            ImportData(workbook);
            workbook.Close();
            excelObj.Quit();
            excelObj = null;
            MessageBox.Show("Import Complete!");
        }
        /// <summary>
        /// Import Data From GOM
        /// </summary>
        /// <param name="workbook"></param>
        private void ImportData(dynamic workbook)
        {
            List<HiringTracking> rawData = new List<HiringTracking>();
            dynamic ActiveSheet = workbook.Sheets(1);
            int rowCount = 4;
            while (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.No).Text))
            {
                HiringTracking Rec = new HiringTracking();
                Rec.No = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.No).Text;
                Rec.Name = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Name).Text;
                Rec.Position = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Position).Text;
                Rec.Position = Rec.Position.Trim();

                Rec.Channel = Utility.GetEnum<HiringTracking.ChannelEnum>(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Channel).Text, HiringTracking.ChannelEnum.Agency);
                Rec.Contact = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.PhoneNumber).Text;
                Rec.University = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.University).Text;

                if (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_EN).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.EN;
                if (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_CN).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.CN;
                if (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_JP).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.JP;
                if (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_KR).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.KR;
                if (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_Other).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.Other;
                Rec.ITBackground = !string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.ITBakcground).Text);
                Rec.MarketBackground = !string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.MarketBackground).Text);

                Rec.ScreenDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.ScreenData));

                Rec.FirstInterviewDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.firstInterviewDate));
                Rec.FirstInterviewer = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.firstInterviewer).Text;
                Rec.FirstInterviewResult = Utility.GetEnum<HiringTracking.InterviewResultEnum>(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.firstInterviewresult).Text, HiringTracking.InterviewResultEnum.NotAvaliable);

                Rec.SecondInterviewDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.secondInterviewDate));
                Rec.SecondInterviewer = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.secondInterviewer).Text;
                Rec.SecondInterviewResult = Utility.GetEnum<HiringTracking.InterviewResultEnum>(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.secondInterviewresult).Text, HiringTracking.InterviewResultEnum.NotAvaliable);

                Rec.ThirdInterviewDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.thirdInterviewDate));
                Rec.ThirdInterviewer = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.thirdInterviewer).Text;
                Rec.ThirdInterviewResult = Utility.GetEnum<HiringTracking.InterviewResultEnum>(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.thirdInterviewresult).Text, HiringTracking.InterviewResultEnum.NotAvaliable);

                Rec.OfferOfferDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.offerofferdate));
                Rec.OnboardDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.onboarddate));
                Rec.RejectOfferReason = ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.rejectofferreason).Text;

                Rec.FinalStatus = Utility.GetEnum<HiringTracking.FinalStatusEnum>(ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.finalstatus).Text, HiringTracking.FinalStatusEnum.UnderScreen);
                rawData.Add(Rec);
                rowCount++;
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<HiringTracking>));
            xml.Serialize(new StreamWriter(SystemManager.HiringTrackingXmlFilename), rawData);
            DataCenter.HiringTrackingDataSet = rawData;
            DataCenter.ReCalulatePositionStatisti((x)=> { return true; });
        }
    }
}
