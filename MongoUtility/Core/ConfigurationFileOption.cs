using System.Collections.Generic;
using MongoUtility.Basic;

namespace MongoUtility.Core
{
    /// <summary>
    ///     Configuration File Option
    /// </summary>
    public class ConfigurationFileOption
    {
        /// <summary>
        ///     元数据类型
        /// </summary>
        public enum MetaType
        {
            /// <summary>
            ///     字符
            /// </summary>
            String,

            /// <summary>
            ///     目录
            /// </summary>
            PathName,

            /// <summary>
            ///     文件
            /// </summary>
            FileName,

            /// <summary>
            ///     整型
            /// </summary>
            Int,

            /// <summary>
            ///     布尔
            /// </summary>
            Boolean,

            /// <summary>
            ///     列表/枚举
            /// </summary>
            List
        }

        //This Class is based the offcal document:
        //http://docs.mongodb.org/manual/reference/configuration-options/

        /// <summary>
        ///     目标数据库版本
        /// </summary>
        public EnumMgr.PrimaryVersion TargetVersion = EnumMgr.PrimaryVersion.V000;

        public struct ConfigValue
        {
            /// <summary>
            ///     层次结构的全路径
            ///     使用#分割
            /// </summary>
            public string Path;

            /// <summary>
            ///     值字面量
            /// </summary>
            public string ValueLiteral;
        }

        /// <summary>
        ///     配置项结构
        /// </summary>
        public struct Define
        {
            /// <summary>
            ///     层次结构的全路径
            ///     使用#分割
            /// </summary>
            public string Path;

            /// <summary>
            ///     从哪个版本开始支持
            /// </summary>
            public EnumMgr.PrimaryVersion NewSinceVersion;

            /// <summary>
            ///     从哪个版本开始过时
            /// </summary>
            public EnumMgr.PrimaryVersion DeprecatedSinceversion;

            /// <summary>
            ///     值的类型
            /// </summary>
            public MetaType ValueType;

            /// <summary>
            ///     可用值列表
            /// </summary>
            public List<string> OptionValueList;

            /// <summary>
            ///     整型上限
            /// </summary>
            public int RangeMax;

            /// <summary>
            ///     整型下限
            /// </summary>
            public int RangeMin;

            /// <summary>
            ///     默认值字面量
            /// </summary>
            public string DefaultValueLiteral;

            /// <summary>
            ///     说明
            /// </summary>
            public string Description;

            /// <summary>
            ///     从路径获得名称
            ///     （非唯一名称）
            /// </summary>
            /// <returns></returns>
            public string GetKey()
            {
                var pathSegment = Path.Split(".".ToCharArray());
                return pathSegment[pathSegment.Length - 1];
            }
        }
    }
}