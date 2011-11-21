using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
namespace MagicMongoDBTool.Module
{
    /// <summary>
    /// 数据过滤器
    /// </summary>
    [Serializable]
    public class DataFilter
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public String DBName = String.Empty;
        /// <summary>
        /// 数据集名称
        /// </summary>
        public String CollectionName = String.Empty;
        /// <summary>
        /// 比较符号
        /// </summary>
        public enum CompareEnum
        {
            /// <summary>
            /// 等于
            /// </summary>
            EQ,
            /// <summary>
            /// 大于
            /// </summary>
            GT,
            /// <summary>
            /// 大于等于
            /// </summary>
            GTE,
            /// <summary>
            /// 小于
            /// </summary>
            LT,
            /// <summary>
            /// 小于等于
            /// </summary>
            LTE,
            /// <summary>
            /// 不等于
            /// </summary>
            NE
        }
        /// <summary>
        /// 排序类型
        /// </summary>
        public enum SortType
        {
            /// <summary>
            /// 不排序
            /// </summary>
            NoSort,
            /// <summary>
            /// 升序
            /// </summary>
            Ascending,
            /// <summary>
            /// 降序
            /// </summary>
            Descending
        }
        /// <summary>
        /// 字段信息
        /// </summary>
        public struct QueryFieldItem
        {
            /// <summary>
            /// 字段名称
            /// </summary>
            public string ColName;
            /// <summary>
            /// 是否表示
            /// </summary>
            public bool IsShow;
            /// <summary>
            /// 排序类型
            /// </summary>
            public SortType sortType;
        }
        /// <summary>
        /// 比较条件[输入]
        /// </summary>
        public struct QueryConditionInputItem
        {
            public string StartMark;
            public string ColName;
            public CompareEnum Comp;
            public string Value;
            public BsonType Type;
            public string EndMark;
        }

        /// <summary>
        /// 输出条件配置
        /// </summary>
        public List<QueryConditionInputItem> QueryConditionList = new List<QueryConditionInputItem>();
        /// <summary>
        /// 输出项目配置
        /// </summary>
        public List<QueryFieldItem> QueryFieldList = new List<QueryFieldItem>();
        /// <summary>
        /// 保存数据过滤器
        /// </summary>
        /// <param name="FileName"></param>
        public void SaveFilter(String FileName)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(DataFilter));
            fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }
        /// <summary>
        /// 载入数据过滤器
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static DataFilter LoadFilter(String FileName)
        {
            FileStream fs = null;
            XmlSerializer xs = new XmlSerializer(typeof(DataFilter));
            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            DataFilter t = (DataFilter)xs.Deserialize(fs);
            fs.Close();
            return (DataFilter)t;
        }
        /// <summary>
        /// 清除过滤器
        /// </summary>
        public void Clear()
        {
            MongoDBHelper.SkipCnt = 0;
            QueryFieldList.Clear();
            QueryConditionList.Clear();
        }
    }

}
