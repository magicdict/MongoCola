using System;

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
        public HiringTracking.LanguageEnum Language = 0;
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
        [FlagsAttribute]
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
            CareerProtal,
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
