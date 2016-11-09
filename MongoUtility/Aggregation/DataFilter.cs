using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MongoUtility.Basic;

namespace MongoUtility.Aggregation
{
    /// <summary>
    ///     数据过滤器
    /// </summary>
    public class DataFilter
    {
        /// <summary>
        ///     比较符号
        /// </summary>
        public enum CompareEnum
        {
            /// <summary>
            ///     等于
            /// </summary>
            Eq,

            /// <summary>
            ///     大于
            /// </summary>
            Gt,

            /// <summary>
            ///     大于等于
            /// </summary>
            Gte,

            /// <summary>
            ///     小于
            /// </summary>
            Lt,

            /// <summary>
            ///     小于等于
            /// </summary>
            Lte,

            /// <summary>
            ///     不等于
            /// </summary>
            Ne
        }

        /// <summary>
        ///     排序类型
        /// </summary>
        public enum SortType
        {
            /// <summary>
            ///     不排序
            /// </summary>
            NoSort,

            /// <summary>
            ///     升序
            /// </summary>
            Ascending,

            /// <summary>
            ///     降序
            /// </summary>
            Descending,

            /// <summary>
            ///     TextScore降序
            /// </summary>
            TextScore
        }

        /// <summary>
        ///     数据集名称
        /// </summary>
        public string CollectionName = string.Empty;

        /// <summary>
        ///     数据库名称
        /// </summary>
        public string DbName = string.Empty;

        /// <summary>
        ///     输出条件配置
        /// </summary>
        public List<QueryConditionInputItem> QueryConditionList = new List<QueryConditionInputItem>();

        /// <summary>
        ///     输出项目配置
        /// </summary>
        public List<QueryFieldItem> QueryFieldList = new List<QueryFieldItem>();

        /// <summary>
        ///     保存数据过滤器
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveFilter(string fileName)
        {
            var xs = new XmlSerializer(typeof(DataFilter));
            var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Flush();
        }

        /// <summary>
        ///     载入数据过滤器
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataFilter LoadFilter(string fileName)
        {
            var xs = new XmlSerializer(typeof(DataFilter));
            var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var t = (DataFilter)xs.Deserialize(fs);
            fs.Flush();
            return t;
        }

        /// <summary>
        ///     清除过滤器
        /// </summary>
        public void Clear()
        {
            //SkipCnt = 0;
            QueryFieldList.Clear();
            QueryConditionList.Clear();
        }

        /// <summary>
        ///     比较条件[输入]
        /// </summary>
        public struct QueryConditionInputItem
        {
            /// <summary>
            ///     字段名称
            /// </summary>
            public string ColName;

            /// <summary>
            ///     比较子
            /// </summary>
            public CompareEnum Compare;

            /// <summary>
            ///     结束标志
            /// </summary>
            public string EndMark;

            /// <summary>
            ///     开始标志
            /// </summary>
            public string StartMark;

            /// <summary>
            ///     比较值
            /// </summary>
            public BsonValueEx Value;
        }

        /// <summary>
        ///     字段信息
        /// </summary>
        public struct QueryFieldItem
        {
            /// <summary>
            ///     字段名称
            /// </summary>
            public string ColName;

            /// <summary>
            ///     是否表示
            /// </summary>
            public bool IsShow;

            /// <summary>
            ///     重命名
            /// </summary>
            public string ProjectName;

            /// <summary>
            ///     排序类型
            /// </summary>
            public SortType SortType;

            /// <summary>
            ///     排序顺位
            /// </summary>
            public int SortOrder;

            /// <summary>
            ///     构造器
            /// </summary>
            /// <param name="mColName"></param>
            public QueryFieldItem(string mColName)
            {
                ProjectName = string.Empty;
                ColName = mColName;
                IsShow = false;
                SortType = SortType.NoSort;
                SortOrder = 0;
            }
        }
    }
}