using System;
using System.Collections.Generic;

namespace Common.Schedule
{
    /// <summary>
    /// 事前准备
    /// </summary>
    public class Preparation :Database.EntityBase
    {
        /// <summary>
        /// 数据集名称
        /// </summary>
        [NonSerialized]
        public static string CollectionName = "Preparation";
        /// <summary>
        /// 行程号（备选：如果和行程一起保存，则无需）
        /// </summary>
        [NonSerialized]
        public string OverviewSN;
        /// <summary>
        /// 事前准备开始日
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// 事前准备结束日
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// 消费记录
        /// </summary>
        public List<Consumption> ConsumptionList = new List<Consumption>();
        /// <summary>
        /// 地点
        /// </summary>
        public string Location = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Comments = string.Empty;
    }
}
