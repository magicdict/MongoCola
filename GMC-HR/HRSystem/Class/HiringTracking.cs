using System;
using System.Collections.Generic;

namespace HRSystem
{
    /// <summary>
    /// Hiring Tracking
    /// </summary>
    public class HiringTracking
    {
        /// <summary>
        /// No
        /// </summary>
        public string No = string.Empty;
        /// <summary>
        /// 招聘职位
        /// </summary>
        public string Position;
        /// <summary>
        /// 名字
        /// </summary>
        public string Name = string.Empty;
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact = string.Empty;
        /// <summary>
        /// 语言
        /// </summary>
        public LanguageEnum Language = 0;
        /// <summary>
        /// 大学
        /// </summary>
        public string University = string.Empty;
        /// <summary>
        /// 专业
        /// </summary>
        public string Major = string.Empty;
        /// <summary>
        /// 市场背景
        /// </summary>
        public bool MarketBackground;
        /// <summary>
        /// 技术背景
        /// </summary>
        public bool ITBackground;
        /// <summary>
        /// 备注
        /// </summary>
        public string Comments = string.Empty;
        /// <summary>
        /// 推荐日期
        /// </summary>
        public DateTime ScreenDate;
        /// <summary>
        /// 一面日期
        /// </summary>
        public DateTime FirstInterviewDate;
        /// <summary>
        /// 一面面试官
        /// </summary>
        public string FirstInterviewer = string.Empty;
        /// <summary>
        /// 一面结果
        /// </summary>
        public InterviewResultEnum FirstInterviewResult;
        /// <summary>
        /// 二面日期
        /// </summary>
        public DateTime SecondInterviewDate;
        /// <summary>
        /// 二面面试官
        /// </summary>
        public string SecondInterviewer = string.Empty;
        /// <summary>
        /// 二面结果
        /// </summary>
        public InterviewResultEnum SecondInterviewResult;
        /// <summary>
        /// 三面日期
        /// </summary>
        public DateTime ThirdInterviewDate;
        /// <summary>
        /// 三面面试官
        /// </summary>
        public string ThirdInterviewer = string.Empty;
        /// <summary>
        /// 三面结果
        /// </summary>
        public InterviewResultEnum ThirdInterviewResult;
        /// <summary>
        /// 招聘状态
        /// </summary>
        public FinalStatusEnum FinalStatus;
        /// <summary>
        /// 招聘渠道
        /// </summary>
        public ChannelEnum Channel;
        /// <summary>
        /// 简历
        /// </summary>
        public string Resume = string.Empty;
        /// <summary>
        /// 确认录用时间
        /// </summary>
        public DateTime OfferOfferDate;
        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime OnboardDate;
        /// <summary>
        /// 拒绝入职的原因
        /// </summary>
        public string RejectOfferReason = string.Empty;
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool IsDel = false;
        [Flags]
        public enum LanguageEnum : short
        {
            None = 0,
            /// <summary>
            /// English
            /// </summary>
            EN = 1,
            /// <summary>
            /// Chinese
            /// </summary>
            CN = 2,
            /// <summary>
            /// Korea
            /// </summary>
            KR = 4,
            /// <summary>
            /// Japanese
            /// </summary>
            JP = 8,
            /// <summary>
            /// Other
            /// </summary>
            Other = 16
        }

        /// <summary>
        /// 招聘渠道枚举
        /// </summary>
        public enum ChannelEnum
        {
            GMCERBP,
            ERBP,
            JobBoard,
            LinkedIn,
            JobFair,
            Agency,
            RPO,
            InternalTransfer,
            CareerPortal,
            Conversion,
            Others
        }
        /// <summary>
        /// 面试结果枚举
        /// </summary>
        public enum InterviewResultEnum
        {
            NotAvaliable,
            Outstanding,
            AboveArravage,
            Acceptable,
            Unacceptable,
            Marginal
        }
        /// <summary>
        /// 是否通过面试
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool InterviewPassCheck(InterviewResultEnum result)
        {
            return result == InterviewResultEnum.Outstanding ||
                   result == InterviewResultEnum.AboveArravage ||
                   result == InterviewResultEnum.Acceptable;
        }
        /// <summary>
        /// 是否面试失败
        /// </summary>
        /// <returns></returns>
        public bool IsFail()
        {
            return FinalStatus == FinalStatusEnum.ScreenFailed ||
                   FinalStatus == FinalStatusEnum.FirstFailed ||
                   FinalStatus == FinalStatusEnum.SecondFailed ||
                   FinalStatus == FinalStatusEnum.ThirdFailed;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="lstHiring"></param>
        public static void ExportData(dynamic workbook, List<HiringTracking> lstHiring)
        {
            List<HiringTracking> rawData = new List<HiringTracking>();
            dynamic ActiveSheet = workbook.Sheets(1);
            int rowCount = 4;
            foreach (var Rec in lstHiring)
            {
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.No).Value = Rec.No;
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Name).Value = Rec.Name;
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Position).Value = Rec.Position;

                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Channel).Value = Rec.Channel.ToString();
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.PhoneNumber).Value = Rec.Contact;
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.University).Value = Rec.University;


                if ((Rec.Language & HiringTracking.LanguageEnum.CN) == HiringTracking.LanguageEnum.CN) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_CN).Value = "○";
                if ((Rec.Language & HiringTracking.LanguageEnum.EN) == HiringTracking.LanguageEnum.EN) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_EN).Value = "○";
                if ((Rec.Language & HiringTracking.LanguageEnum.JP) == HiringTracking.LanguageEnum.JP) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_JP).Value = "○";
                if ((Rec.Language & HiringTracking.LanguageEnum.KR) == HiringTracking.LanguageEnum.KR) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_KR).Value = "○";
                if ((Rec.Language & HiringTracking.LanguageEnum.Other) == HiringTracking.LanguageEnum.Other) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.Language_Other).Value = "○";

                if (Rec.ITBackground) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.ITBakcground).Value = "○";
                if (Rec.MarketBackground) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.MarketBackground).Value = "○";

                if (Rec.ScreenDate != DateTime.MinValue) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.ScreenData).Value = Rec.ScreenDate.ToShortDateString();


                if (Rec.FirstInterviewDate != DateTime.MinValue) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.firstInterviewDate).Value = Rec.FirstInterviewDate.ToShortDateString();
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.firstInterviewer).Value = Rec.FirstInterviewer;
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.firstInterviewresult).Value = Rec.FirstInterviewResult.ToString();

                if (Rec.SecondInterviewDate != DateTime.MinValue) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.secondInterviewDate).Value = Rec.SecondInterviewDate.ToShortDateString();
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.secondInterviewer).Value = Rec.SecondInterviewer;
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.secondInterviewresult).Value = Rec.SecondInterviewResult.ToString();

                if (Rec.ThirdInterviewDate != DateTime.MinValue) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.thirdInterviewDate).Value = Rec.ThirdInterviewDate.ToShortDateString();
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.thirdInterviewer).Value = Rec.ThirdInterviewer;
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.thirdInterviewresult).Value = Rec.ThirdInterviewResult.ToString();

                if (Rec.OfferOfferDate != DateTime.MinValue) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.offerofferdate).Value = Rec.OfferOfferDate.ToShortDateString();
                if (Rec.OnboardDate != DateTime.MinValue) ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.onboarddate).Value = Rec.OnboardDate.ToShortDateString();
                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.rejectofferreason).Value = Rec.RejectOfferReason;

                ActiveSheet.Cells(rowCount, ViewStyleSheet.ColPos.finalstatus).Value = Rec.FinalStatus.ToString();

                rowCount++;
            }
            workbook.Save();
        }
        /// <summary>
        /// 招聘状态枚举
        /// </summary>
        public enum FinalStatusEnum
        {
            UnderScreen,
            ScreenFailed,
            ScreenPending,
            Under1stInterview,
            FirstPass,
            FirstMerginal,
            FirstFailed,
            UnderSecondInterview,
            SecondPass,
            SecondMerginal,
            SecondFailed,
            UnderThirdInterview,
            ThirdPass,
            ThirdMerginal,
            ThirdFailed,
            UnderAdditionalInterview,
            AdditionalInterviewPass,
            AdditionalInterviewMerginal,
            AdditionalInterviewFailed,
            OpenOffer,
            ANOB,
            RejectOffer,
            Onboard,
            HiringPendingHCfreeze,
            HiringPendingInternalrotation,
            HiringPendingOthers
        }
    }
}
