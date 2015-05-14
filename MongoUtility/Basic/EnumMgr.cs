using System.Linq;
using MongoDB.Driver;

namespace MongoUtility.Basic
{
    public static class EnumMgr
    {
        /// <summary>
        ///     导出类型
        /// </summary>
        public enum ExportType
        {
            Excel,
            Text,
            Xml
        }

        /// <summary>
        ///     索引类型
        /// </summary>
        public enum IndexType
        {
            /// <summary>
            ///     升序
            /// </summary>
            Ascending,

            /// <summary>
            ///     降序
            /// </summary>
            Descending,

            /// <summary>
            ///     Geo
            /// </summary>
            GeoSpatial,

            /// <summary>
            ///     拉丁语的全文检索(Since mongodb 2.2.4)
            /// </summary>
            Text
        }

        /// <summary>
        ///     路径阶层[考虑到以后可能阶层会变换]
        /// </summary>
        public enum PathLevel
        {
            /// <summary>
            ///     连接/服务器
            /// </summary>
            Connection = 0,

            /// <summary>
            ///     具体的实例
            /// </summary>
            Instance = 1,

            /// <summary>
            ///     数据库
            /// </summary>
            Database = 2,

            /// <summary>
            ///     数据集
            /// </summary>
            Collection = 3,

            /// <summary>
            ///     数据文档
            /// </summary>
            Document = 4
        }

        /// <summary>
        ///     存储引擎
        /// </summary>
        public enum StorageEngineType
        {
            /// <summary>
            ///     MMAPv1
            /// </summary>
            MmaPv1,

            /// <summary>
            ///     WiredTiger
            /// </summary>
            WiredTiger
        }

        /// <summary>
        ///     Text Search 时候能指定的语言枚举
        /// </summary>
        public enum TextSearchLanguage
        {
            Danish,
            Dutch,
            English,
            Finnish,
            French,
            German,
            Hungarian,
            Italian,
            Norwegian,
            Portuguese,
            Romanian,
            Russian,
            Spanish,
            Swedish,
            Turkish
        }

        /// <summary>
        ///     Key String
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GetKeyString(IndexKeysDocument keys)
        {
            var keyString = string.Empty;
            foreach (var key in keys.Elements)
            {
                keyString += key.Name + ":";
                switch (key.Value.ToString())
                {
                    case "1":
                        keyString += IndexType.Ascending.ToString();
                        break;
                    case "-1":
                        keyString += IndexType.Descending.ToString();
                        break;
                    case "2d":
                        keyString += IndexType.GeoSpatial.ToString();
                        break;
                    case "text":
                        keyString += IndexType.Text.ToString();
                        break;
                    default:
                        break;
                }
                keyString += ";";
            }
            keyString = "[" + keyString.TrimEnd(";".ToArray()) + "]";
            return keyString;
        }
    }
}