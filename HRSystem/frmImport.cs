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
        /// <summary>
        /// Column 
        /// </summary>
        private enum ColPos
        {
            No = 2,
            Name,
            Position,
            Channel,
            PhoneNumber,
            University,
            Language_EN,
            Language_CN,
            Language_JP,
            Language_KR,
            Language_Other,
            MarketBackground,
            ITBakcground,
            ScreenData,

            firstInterviewDate,
            firstInterviewer,
            firstInterviewresult,

            secondInterviewDate,
            secondInterviewer,
            secondnterviewresult,

            thirdInterviewDate,
            thirdInterviewer,
            thirdnterviewresult,

            offerofferdate,
            onboarddate,
            rejectofferreason,
            finalstatus

        }
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
            while (!string.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.No).Text))
            {
                HiringTracking Rec = new HiringTracking();
                Rec.No = ActiveSheet.Cells(rowCount, ColPos.No).Text;
                Rec.Name = ActiveSheet.Cells(rowCount, ColPos.Name).Text;
                Rec.Position = ActiveSheet.Cells(rowCount, ColPos.Position).Text;
                Rec.Position = Rec.Position.Trim();

                Rec.Channel = Utility.GetEnum<HiringTracking.ChannelEnum>(ActiveSheet.Cells(rowCount, ColPos.Channel).Text, HiringTracking.ChannelEnum.Agency);
                Rec.Contact = ActiveSheet.Cells(rowCount, ColPos.PhoneNumber).Text;
                Rec.University = ActiveSheet.Cells(rowCount, ColPos.University).Text;

                if (!String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.Language_EN).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.EN;
                if (!String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.Language_CN).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.CN;
                if (!String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.Language_JP).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.JP;
                if (!String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.Language_KR).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.KR;
                if (!String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.Language_Other).Text)) Rec.Language = Rec.Language | HiringTracking.LanguageEnum.Other;
                Rec.ITBackground = !String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.ITBakcground).Text);
                Rec.MarketBackground = !String.IsNullOrEmpty(ActiveSheet.Cells(rowCount, ColPos.MarketBackground).Text);

                Rec.ScreenDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ColPos.ScreenData));

                Rec.FirstInterviewDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ColPos.firstInterviewDate));
                Rec.FirstInterviewer = ActiveSheet.Cells(rowCount, ColPos.firstInterviewer).Text;
                Rec.FirstInterviewResult = Utility.GetEnum<HiringTracking.InterviewResultEnum>(ActiveSheet.Cells(rowCount, ColPos.firstInterviewresult).Text, HiringTracking.InterviewResultEnum.NotAvaliable);

                Rec.SecondInterviewDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ColPos.secondInterviewDate));
                Rec.SecondInterviewer = ActiveSheet.Cells(rowCount, ColPos.secondInterviewer).Text;
                Rec.SecondInterviewResult = Utility.GetEnum<HiringTracking.InterviewResultEnum>(ActiveSheet.Cells(rowCount,ColPos.secondnterviewresult).Text, HiringTracking.InterviewResultEnum.NotAvaliable);

                Rec.ThirdInterviewDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ColPos.thirdInterviewDate));
                Rec.ThirdInterviewer = ActiveSheet.Cells(rowCount, ColPos.thirdInterviewer).Text;
                Rec.ThirdInterviewResult = Utility.GetEnum<HiringTracking.InterviewResultEnum>(ActiveSheet.Cells(rowCount, ColPos.thirdnterviewresult).Text, HiringTracking.InterviewResultEnum.NotAvaliable);

                Rec.OfferOfferDate = Utility.GetDate(ActiveSheet.Cells(rowCount,ColPos.offerofferdate));
                Rec.OnboardDate = Utility.GetDate(ActiveSheet.Cells(rowCount, ColPos.onboarddate));
                Rec.RejectOfferReason = ActiveSheet.Cells(rowCount, ColPos.rejectofferreason).Text;

                Rec.FinalStatus = Utility.GetEnum<HiringTracking.FinalStatusEnum>(ActiveSheet.Cells(rowCount, ColPos.rejectofferreason).Text, HiringTracking.FinalStatusEnum.UnderScreen);
                rawData.Add(Rec);
                rowCount++;
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<HiringTracking>));
            xml.Serialize(new StreamWriter(SystemManager.HiringTrackingXmlFilename), rawData);
            CreatePositionReport.HiringTrackingDataSet = rawData;
            CreatePositionReport.ReCompute();
        }
    }
}
