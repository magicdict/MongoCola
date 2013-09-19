using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// 路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        public enum PathLv : int
        {
            /// <summary>
            /// 连接/服务器
            /// </summary>
            ConnectionLV = 0,
            /// <summary>
            /// 具体的实例
            /// </summary>
            InstanceLV = 1,
            /// <summary>
            /// 数据库
            /// </summary>
            DatabaseLV = 2,
            /// <summary>
            /// 数据集
            /// </summary>
            CollectionLV = 3,
            /// <summary>
            /// 数据文档
            /// </summary>
            DocumentLV = 4
        }
        /// <summary>
        /// 索引类型
        /// </summary>
        public enum IndexType
        {
            /// <summary>
            /// 升序
            /// </summary>
            Ascending,
            /// <summary>
            /// 降序
            /// </summary>
            Descending,
            /// <summary>
            /// Geo
            /// </summary>
            GeoSpatial,
            /// <summary>
            /// 拉丁语的全文检索(Since mongodb 2.2.4)
            /// </summary>
            Text
        }
        /// <summary>
        /// 导出类型
        /// </summary>
        public enum ExportType
        {
            Excel,
            Text,
            XML
        }
        /// <summary>
        /// Text Search 时候能指定的语言枚举
        /// </summary>
        public enum TextSearchLanguage
        {
            danish,
            dutch,
            english,
            finnish,
            french,
            german,
            hungarian,
            italian,
            norwegian,
            portuguese,
            romanian,
            russian,
            spanish,
            swedish,
            turkish
        }
    }
}
