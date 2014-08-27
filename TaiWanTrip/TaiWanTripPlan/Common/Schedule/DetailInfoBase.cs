using Common.Database;
using System;
using System.Collections.Generic;

namespace Common.Schedule
{
    public class DetailInfoBase : EntityBase
    {
        /// <summary>
        /// 数据集名称
        /// </summary>
        public static string CollectionName = "DetailInfo";
        /// <summary>
        /// 说明
        /// </summary>
        public string Description = string.Empty;
        /// <summary>
        /// 开始日
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// 结束日
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// 是否跨日
        /// </summary>
        public bool IsNextDay
        {
            get
            {
                return StartDate.Date != EndDate.Date;
            }
        }
        /// <summary>
        /// 发生地点
        /// </summary>
        public string Location = string.Empty;
        /// <summary>
        /// 分类
        /// </summary>
        public InfoClassEnum InfoClass = InfoClassEnum.Other;
        /// <summary>
        /// 分类枚举
        /// </summary>
        public enum InfoClassEnum
        {
            /// <summary>
            /// 移动
            /// </summary>
            Traffic,
            /// <summary>
            /// 参观
            /// </summary>
            Visit,
            /// <summary>
            /// 购物
            /// </summary>
            Shopping,
            /// <summary>
            /// 饮食
            /// </summary>
            Catering,
            /// <summary>
            /// 休息
            /// </summary>
            Rest,
            /// <summary>
            /// 手续
            /// </summary>
            Certificates,
            /// <summary>
            /// 其他
            /// </summary>
            Other
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comments = string.Empty;
        /// <summary>
        /// 是否为一个备选方案
        /// </summary>
        public bool IsBack = false;
        /// <summary>
        /// 消费记录
        /// </summary>
        public List<Consumption> ConsumptionList = new List<Consumption>();
        /// <summary>
        /// 添加详细行程
        /// </summary>
        /// <param name="info"></param>
        public static void InsertDetailInfo(DetailInfoBase info)
        {
            Operater.InsertRec(CollectionName, info);
        }
    }
}
