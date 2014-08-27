using Common.Database;
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Common.Schedule
{
    /// <summary>
    /// 行程总览
    /// </summary>
    public class Overview : EntityBase
    {
        /// <summary>
        /// 数据集名称
        /// </summary>
        public static string CollectionName = "Overview";
        /// <summary>
        /// 创建用户
        /// </summary>
        [BsonIgnore]
        public string CreateUserName = string.Empty;
        /// <summary>
        /// 序列号
        /// </summary>
        public string ScheduleSN = string.Empty;
        /// <summary>
        /// 行程开始日
        /// </summary>
        public DateTime StartDate = DateTime.MinValue;
        /// <summary>
        /// 行程结束日
        /// </summary>
        public DateTime EndDate = DateTime.MinValue;
        /// <summary>
        /// 人数
        /// </summary>
        public int MemberCount = 0;
        /// <summary>
        /// 出发地点
        /// </summary>
        public string DepartLocation = string.Empty;
        /// <summary>
        /// 返回地点
        /// </summary>
        public string ReturnLocation = string.Empty;
        /// <summary>
        /// 入境地点
        /// </summary>
        public string EntryLocation = string.Empty;
        /// <summary>
        /// 出境地点
        /// </summary>
        public string ExitLocation = string.Empty;
        /// <summary>
        /// 事前准备
        /// </summary>
        public List<Preparation> PreparationList = new List<Preparation>();
        /// <summary>
        /// 预算
        /// </summary>
        public double Budget = 0;
        /// <summary>
        /// 添加行程
        /// </summary>
        /// <param name="overview"></param>
        public static void InsertOverview(Overview overview)
        {
            overview.ScheduleSN = (Operater.GetCollectionRecordCount(CollectionName) + 1).ToString("D8");
            Operater.InsertRec(CollectionName, overview, overview.CreateUserName);
        }
    }
}
