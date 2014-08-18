using System;
/// <summary>
/// 统计数据
/// </summary>
namespace HRSystem
{
    /// <summary>
    /// Position BasicInfo
    /// </summary>
    public class PositionBasicInfo
    {
        /// <summary>
        /// No
        /// </summary>
        public string No = String.Empty;
        /// <summary>
        /// 招聘经理
        /// </summary>
        public string HiringManager = String.Empty;
        /// <summary>
        /// 招聘职位
        /// </summary>
        public string Position = String.Empty;
        /// <summary>
        /// 招聘种类
        /// </summary>
        public HiringTypeEnum HiringType;
        /// <summary>
        /// 等级(下限)
        /// </summary>
        public BandEnum BandLBound;
        /// <summary>
        /// 等级(上限)
        /// </summary>
        public BandEnum BandHBound;
        /// <summary>
        /// 招聘数量
        /// </summary>
        public int Target;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime OpenDate;
        /// <summary>
        /// 批准时间
        /// </summary>
        public DateTime ApprovedDate;
        /// <summary>
        /// 是否已经关闭
        /// </summary>
        public Boolean isOpen;
        /// <summary>
        /// 招聘种类
        /// </summary>
        public enum HiringTypeEnum
        {
            Regular,
            FixedTerm,
            CIIC,
            CSPContractor,
            Intern,
            AssignIn
        }
        /// <summary>
        /// 等级
        /// </summary>
        public enum BandEnum
        {
            A6,
            B6,
            A7,
            B7,
            A8,
            B8
        }
    }

    public class PositionStatistic
    {
        public PositionBasicInfo BasicInfo;
        /// <summary>
        /// 现有简历数量
        /// </summary>
        public int Pipeline;
        /// <summary>
        /// 简历通过率
        /// </summary>
        public int CVpass;
        /// <summary>
        /// 一面数量
        /// </summary>
        public int FirstInterviewCount;
        /// <summary>
        /// 一面通过通过
        /// </summary>
        public int FirstPass;
        /// <summary>
        /// 一面通过率(%)
        /// </summary>
        public double FirstPassRatio
        {
            get
            {
                if (FirstInterviewCount == 0) return 0;
                return (double)FirstPass / (double)FirstInterviewCount;
            }
        }
        /// <summary>
        /// 二面数量
        /// </summary>
        public int SecondInterviewCount;
        /// <summary>
        /// 二面面试通过
        /// </summary>
        public int SecondPass;
        /// <summary>
        /// 二面通过率(%)
        /// </summary>
        public double SecondPassRatio
        {
            get
            {
                if (SecondInterviewCount == 0) return 0;
                return (double)SecondPass / (double)SecondInterviewCount;
            }
        }
        /// <summary>
        /// 三面数量
        /// </summary>
        public int ThirdInterviewCount;
        /// <summary>
        /// 三面面试通过
        /// </summary>
        public int ThirdPass;
        /// <summary>
        /// 三面通过率(%)
        /// </summary>
        public double ThirdPassRatio
        {
            get
            {
                if (ThirdInterviewCount == 0) return 0;
                return (double)ThirdPass / (double)ThirdInterviewCount;
            }
        }
        /// <summary>
        /// 通过面试
        /// </summary>
        public int OpenOffer;
        /// <summary>
        /// 接受职位
        /// </summary>
        public int ANOB;
        /// <summary>
        /// 拒绝职位
        /// </summary>
        public int RejectOffer;
        /// <summary>
        /// 入职
        /// </summary>
        public int Onboard;
        /// <summary>
        /// 招聘缺口
        /// </summary>
        public int Gap
        {
            get
            {
                return BasicInfo.Target - OpenOffer - ANOB - Onboard;
            }
        }
        /// <summary>
        /// 招聘渠道
        /// </summary>
        public HiringTracking.ChannelEnum ChannelMix;

    }
}
