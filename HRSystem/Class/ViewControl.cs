using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Xml.Serialization;
using System.IO;

namespace HRSystem
{
    public class ViewControl
    {
        /// <summary>
        /// 自定义视图
        /// </summary>
        public struct Customerview
        {
            /// <summary>
            /// 视图名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 视图列表
            /// </summary>
            public string[] fields;
            /// <summary>
            /// 对于数据集
            /// </summary>
            public string DatasetName;
        }
        /// <summary>
        /// 自定义视图列表
        /// </summary>
        public static List<Customerview> lstCustomerview = new List<Customerview>();
        /// <summary>
        /// 加载列表
        /// </summary>
        public static void LoadlstCustomerview()
        {
            if (File.Exists(SystemManager.CustomViewXmlFilename))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Customerview>));
                lstCustomerview = (List<Customerview>)xml.Deserialize(new StreamReader(SystemManager.CustomViewXmlFilename));
            }
        }
        /// <summary>
        /// 保存列表
        /// </summary>
        public static void SavelstCustomerview()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Customerview>));
            xml.Serialize(new StreamWriter(SystemManager.CustomViewXmlFilename), lstCustomerview);
        }

        #region"Position"
        /// <summary>
        /// 全字段列表
        /// </summary>
        public static string[] FullPositionFields = new string[]
        {
            "No",
            "Hiring Manager",
            "Position",
            "Hiring Type",
            "Band",
            "Target",
            "Gap",
            "Open Date",
            "Approved Date",
            "Pipeline",
            "CV pass",
            "1st Interview",
            "1st Pass",
            "1st PassRatio",
            "2nd Interview",
            "2nd Pass",
            "2nd PassRatio",
            "3rd Interview",
            "3rd Pass",
            "3rd PassRatio",
            "Open Offer",
            "ANOB",
            "Reject Offer",
            "Onboard",
            "Channel Mix"
        };

        /// <summary>
        /// 当前视图Position
        /// </summary>
        public static string[] CurrentPositionViewFields = new string[] { };

        /// <summary>
        /// 重置
        /// </summary>
        public static void ResetPositionField()
        {
            ViewControl.CurrentPositionViewFields = new string[ViewControl.FullPositionFields.Length];
            for (int i = 0; i < ViewControl.FullPositionFields.Length; i++)
            {
                ViewControl.CurrentPositionViewFields[i] = ViewControl.FullPositionFields[i];
            }
        }
        public delegate bool PositionDelegate(PositionBasicInfo pos);
        /// <summary>
        /// 视图设定【核心】
        /// </summary>
        /// <param name="lstView">视图控件</param>
        /// <param name="StatisticRecords">统计数据集</param>
        public static void FillPositionListView(ListView lstView, List<PositionStatistic> StatisticRecords, PositionDelegate condition)
        {
            lstView.Clear();
            for (int i = 0; i < CurrentPositionViewFields.Length; i++)
            {
                //pay attention the order!
                lstView.Columns.Add(CurrentPositionViewFields[i]);
            }
            int cnt = 0;
            foreach (var Record in StatisticRecords)
            {
                if (Record.BasicInfo.Position == SystemManager.strTotal)
                {
                    ListViewItem item = new ListViewItem();
                    cnt++;
                    Record.BasicInfo.No = cnt.ToString();
                    BindPositionListViewItem(item, Record);
                    item.BackColor = Color.LightYellow;
                    lstView.Items.Add(item);
                }
                else
                {
                    if (Record.Gap != 0 && condition(Record.BasicInfo))
                    {
                        ListViewItem item = new ListViewItem();
                        cnt++;
                        Record.BasicInfo.No = cnt.ToString();
                        BindPositionListViewItem(item, Record);
                        lstView.Items.Add(item);
                    }
                }
            }
            foreach (var Record in StatisticRecords)
            {
                if (!condition(Record.BasicInfo)) continue;
                if (Record.Gap == 0 && Record.BasicInfo.Position != SystemManager.strTotal)
                {
                    ListViewItem item = new ListViewItem();
                    cnt++;
                    Record.BasicInfo.No = cnt.ToString();
                    BindPositionListViewItem(item, Record);
                    item.BackColor = Color.LightGray;
                    lstView.Items.Add(item);
                }
            }
            Utility.ListViewColumnResize(lstView);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="item"></param>
        /// <param name="record"></param>
        private static void BindPositionListViewItem(ListViewItem item, PositionStatistic record)
        {
            if (CurrentPositionViewFields.ToList().Contains("No")) item.Text = record.BasicInfo.No;
            if (CurrentPositionViewFields.ToList().Contains("Hiring Manager")) item.SubItems.Add(record.BasicInfo.HiringManager);
            if (CurrentPositionViewFields.ToList().Contains("Position")) item.SubItems.Add(record.BasicInfo.Position.ToString());
            if (CurrentPositionViewFields.ToList().Contains("Hiring Type"))
            {
                if (record.BasicInfo.Position == SystemManager.strTotal)
                {
                    item.SubItems.Add("-");
                }
                else
                {
                    item.SubItems.Add(record.BasicInfo.HiringType.ToString());
                }
            }
            if (CurrentPositionViewFields.ToList().Contains("Band"))
            {
                string strBand = string.Empty;
                if (record.BasicInfo.BandLBound == record.BasicInfo.BandHBound)
                {
                    strBand = record.BasicInfo.BandLBound.ToDisplayString();
                }
                else
                {
                    strBand = record.BasicInfo.BandLBound.ToDisplayString() + " - " + record.BasicInfo.BandHBound.ToDisplayString();
                }
                if (record.BasicInfo.Position == SystemManager.strTotal) strBand = "-";
                item.SubItems.Add(strBand);
            }
            if (CurrentPositionViewFields.ToList().Contains("Target")) item.SubItems.Add(record.BasicInfo.Target.ToString());
            if (CurrentPositionViewFields.ToList().Contains("Gap")) item.SubItems.Add(record.Gap.ToString());

            if (CurrentPositionViewFields.ToList().Contains("Open Date"))
            {
                if (record.BasicInfo.Position == SystemManager.strTotal)
                {
                    item.SubItems.Add("-");
                }
                else
                {
                    item.SubItems.Add(record.BasicInfo.OpenDate.ToString(SystemManager.DataTimeFormat));
                }
            }
            if (CurrentPositionViewFields.ToList().Contains("Approved Date"))
            {
                if (record.BasicInfo.Position == SystemManager.strTotal)
                {
                    item.SubItems.Add("-");
                }
                else
                {
                    item.SubItems.Add(record.BasicInfo.ApprovedDate.ToString(SystemManager.DataTimeFormat));
                }
            }

            if (CurrentPositionViewFields.ToList().Contains("Pipeline")) item.SubItems.Add(record.Pipeline.ToString());
            if (CurrentPositionViewFields.ToList().Contains("CV pass")) item.SubItems.Add(record.CVpass.ToString());
            if (CurrentPositionViewFields.ToList().Contains("1st Interview")) item.SubItems.Add(record.FirstInterviewCount.ToString());
            if (CurrentPositionViewFields.ToList().Contains("1st Pass")) item.SubItems.Add(record.FirstPass.ToString());
            if (CurrentPositionViewFields.ToList().Contains("1st PassRatio"))
            {
                item.SubItems.Add(Math.Round(record.FirstPassRatio * 100, 2) + "%");
            }
            if (CurrentPositionViewFields.ToList().Contains("2nd Interview")) item.SubItems.Add(record.SecondInterviewCount.ToString());
            if (CurrentPositionViewFields.ToList().Contains("2nd Pass")) item.SubItems.Add(record.SecondPass.ToString());
            if (CurrentPositionViewFields.ToList().Contains("2nd PassRatio"))
            {
                item.SubItems.Add(System.Math.Round(record.SecondPassRatio * 100, 2) + "%");
            }
            if (CurrentPositionViewFields.ToList().Contains("3rd Interview")) item.SubItems.Add(record.ThirdInterviewCount.ToString());
            if (CurrentPositionViewFields.ToList().Contains("3rd Pass")) item.SubItems.Add(record.ThirdPass.ToString());
            if (CurrentPositionViewFields.ToList().Contains("3rd PassRatio"))
            {
                item.SubItems.Add(System.Math.Round(record.ThirdPassRatio * 100, 2) + "%");
            }
            if (CurrentPositionViewFields.ToList().Contains("Open Offer")) item.SubItems.Add(record.OpenOffer.ToString());
            if (CurrentPositionViewFields.ToList().Contains("ANOB")) item.SubItems.Add(record.ANOB.ToString());
            if (CurrentPositionViewFields.ToList().Contains("Reject Offer")) item.SubItems.Add(record.RejectOffer.ToString());
            if (CurrentPositionViewFields.ToList().Contains("Onboard")) item.SubItems.Add(record.Onboard.ToString());
            if (CurrentPositionViewFields.ToList().Contains("Channel Mix")) item.SubItems.Add(record.ChannelMix.ToString());
        }
        #endregion

        #region"HiringTracking"
        /// <summary>
        /// 
        /// </summary>
        public static string[] FullHiringTrackingFields = new string[]
        {
            "No",
            "Position",
            "Name",
            "Contact",
            "Language",
            "University",
            "Major",
            "Market Background",
            "IT Background",
            "Comments",
            "Screen Date",
            "1st Interview Date",
            "1st Interviewer",
            "1st interview Result",
            "2nd Interview Date",
            "2nd Interviewer",
            "2nd interview result",
            "3rd Interview Date",
            "3rd Interviewer",
            "3rd Interview result",
            "Final Status",
            "Channel",
            "Resume",
            "Offer offer date",
            "Onboard date",
            "Reject offer reason"
        };
        /// <summary>
        /// 当前视图HiringTracking
        /// </summary>
        public static string[] CurrentHiringTrackingFields = new string[] { };

        /// <summary>
        /// 重置
        /// </summary>
        public static void ResetHiringTrackingField()
        {
            ViewControl.CurrentHiringTrackingFields = new string[ViewControl.FullHiringTrackingFields.Length];
            for (int i = 0; i < ViewControl.FullHiringTrackingFields.Length; i++)
            {
                ViewControl.CurrentHiringTrackingFields[i] = ViewControl.FullHiringTrackingFields[i];
            }
        }
        public delegate bool HiringTrackingDelegate(HiringTracking pos);
        /// <summary>
        /// 视图设定【核心】
        /// </summary>
        /// <param name="lstView">视图控件</param>
        /// <param name="StatisticRecords">统计数据集</param>
        public static void FillHiringTrackingListView(ListView lstView, List<HiringTracking> StatisticRecords, HiringTrackingDelegate condition)
        {
            lstView.Clear();
            for (int i = 0; i < CurrentHiringTrackingFields.Length; i++)
            {
                //pay attention the order!
                lstView.Columns.Add(CurrentHiringTrackingFields[i]);
            }
            foreach (var Record in StatisticRecords)
            {
                if (!condition(Record)) continue;
                if (Record.IsFail()) continue;
                ListViewItem item = new ListViewItem();
                BindHiringTrackingListViewItem(item, Record);
                lstView.Items.Add(item);
            }
            foreach (var Record in StatisticRecords)
            {
                if (!condition(Record)) continue;
                if (!Record.IsFail()) continue;
                ListViewItem item = new ListViewItem();
                BindHiringTrackingListViewItem(item, Record);
                item.BackColor = Color.LightGray;
                lstView.Items.Add(item);
            }
            Utility.ListViewColumnResize(lstView);
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="item"></param>
        /// <param name="record"></param>
        private static void BindHiringTrackingListViewItem(ListViewItem item, HiringTracking record)
        {
            if (CurrentHiringTrackingFields.ToList().Contains("No")) item.Text = record.No;
            if (CurrentHiringTrackingFields.ToList().Contains("Position")) item.SubItems.Add(record.Position);
            if (CurrentHiringTrackingFields.ToList().Contains("Name")) item.SubItems.Add(record.Name);
            if (CurrentHiringTrackingFields.ToList().Contains("Contact")) item.SubItems.Add(record.Contact);
            if (CurrentHiringTrackingFields.ToList().Contains("Language")) item.SubItems.Add(record.Language.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("University")) item.SubItems.Add(record.University.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Major")) item.SubItems.Add(record.Major.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Market Background")) item.SubItems.Add(record.MarketBackground.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("IT Background")) item.SubItems.Add(record.ITBackground.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Comments")) item.SubItems.Add(record.Comments.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Screen Date")) item.SubItems.Add(record.ScreenDate.ToString(SystemManager.DataTimeFormat));
            if (CurrentHiringTrackingFields.ToList().Contains("1st Interview Date")) item.SubItems.Add(record.FirstInterviewDate.ToString(SystemManager.DataTimeFormat));
            if (CurrentHiringTrackingFields.ToList().Contains("1st Interviewer")) item.SubItems.Add(record.FirstInterviewer);
            if (CurrentHiringTrackingFields.ToList().Contains("1st interview Result")) item.SubItems.Add(record.FirstInterviewResult.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("2nd Interview Date")) item.SubItems.Add(record.SecondInterviewDate.ToString(SystemManager.DataTimeFormat));
            if (CurrentHiringTrackingFields.ToList().Contains("2nd Interviewer")) item.SubItems.Add(record.SecondInterviewer.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("2nd interview result")) item.SubItems.Add(record.SecondInterviewResult.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("3rd Interview Date")) item.SubItems.Add(record.ThirdInterviewDate.ToString(SystemManager.DataTimeFormat));
            if (CurrentHiringTrackingFields.ToList().Contains("3rd Interviewer")) item.SubItems.Add(record.ThirdInterviewer.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("3rd Interview result")) item.SubItems.Add(record.ThirdInterviewResult.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Final Status")) item.SubItems.Add(record.FinalStatus.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Channel")) item.SubItems.Add(record.Channel.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Resume")) item.SubItems.Add(record.Resume.ToString());
            if (CurrentHiringTrackingFields.ToList().Contains("Offer offer date")) item.SubItems.Add(record.OfferOfferDate.ToString(SystemManager.DataTimeFormat));
            if (CurrentHiringTrackingFields.ToList().Contains("Onboard date")) item.SubItems.Add(record.OnboardDate.ToString(SystemManager.DataTimeFormat));
            if (CurrentHiringTrackingFields.ToList().Contains("Reject offer reason")) item.SubItems.Add(record.RejectOfferReason.ToString());
        }
        #endregion
    }
}
