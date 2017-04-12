using System;
using MongoUtility.Basic;

namespace MongoUtility.Core
{
    /// <summary>
    ///     TagInfo
    /// </summary>
    public class TagInfo
    {
        /// <summary>
        ///     全路径
        /// </summary>
        private string _tagString = string.Empty;

        /// <summary>
        ///     对象名称
        /// </summary>
        public string ObjName = string.Empty;

        /// <summary>
        ///     类别(Enum)
        /// </summary>
        public EnumMgr.PathLevel PathLevel = EnumMgr.PathLevel.Document;

        /// <summary>
        ///     除去表示类别的数据
        /// </summary>
        public string TagPath = string.Empty;

        /// <summary>
        ///     类别(String)
        /// </summary>
        public string TagType = string.Empty;

        /// <summary>
        ///     CreateTagInfo
        /// </summary>
        /// <param name="config"></param>
        public static TagInfo CreateTagInfo(MongoConnectionConfig config)
        {
            var tagString = ConstMgr.ConnectionTag + ":" + config.ConnectionName;
            switch (config.ServerRole)
            {
                case MongoConnectionConfig.SvrRoleType.ReplsetSvr:
                    tagString = ConstMgr.ConnectionReplsetTag + ":" + config.ConnectionName;
                    break;
                case MongoConnectionConfig.SvrRoleType.ShardSvr:
                    tagString = ConstMgr.ConnectionClusterTag + ":" + config.ConnectionName;
                    break;
                default:
                    tagString = ConstMgr.ConnectionTag + ":" + config.ConnectionName;
                    break;
            }

            return GetMongoObj(tagString);
        }

        /// <summary>
        ///     CreateTagInfo
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static TagInfo CreateTagInfo(string connectionName, string dataBaseName)
        {
            var tagString = ConstMgr.DatabaseTag + ":" + connectionName + "/" + dataBaseName;
            return GetMongoObj(tagString);
        }

        /// <summary>
        ///     CreateTagInfo
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataBase"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static TagInfo CreateTagInfo(string connectionName, string dataBase, string collectionName)
        {
            var tagString = ConstMgr.CollectionTag + ":" + connectionName + "/" + dataBase + "/" + collectionName;
            return GetMongoObj(tagString);
        }

        /// <summary>
        ///     ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _tagString;
        }

        /// <summary>
        ///     GetMongoObj
        /// </summary>
        /// <param name="strTag"></param>
        /// <returns></returns>
        private static TagInfo GetMongoObj(string strTag)
        {
            var info = new TagInfo
            {
                _tagString = strTag,
                TagPath = GetTagPath(strTag),
                TagType = GetTagType(strTag),
                ObjName = GetNameFromTag(strTag),
                PathLevel = TagType2PathLevel(GetTagType(strTag))
            };
            return info;
        }

        /// <summary>
        ///     根据标签类型计算层级
        /// </summary>
        /// <param name="strTagType"></param>
        /// <returns></returns>
        private static EnumMgr.PathLevel TagType2PathLevel(string strTagType)
        {
            var level = EnumMgr.PathLevel.Document;
            switch (strTagType)
            {
                case ConstMgr.ConnectionTag:
                    level = EnumMgr.PathLevel.Connection;
                    break;
                case ConstMgr.DatabaseTag:
                    level = EnumMgr.PathLevel.Database;
                    break;
                case ConstMgr.CollectionTag:
                case ConstMgr.ViewTag:
                    level = EnumMgr.PathLevel.CollectionAndView;
                    break;
            }
            return level;
        }

        /// <summary>
        ///     获得对象的种类
        /// </summary>
        /// <returns></returns>
        public static string GetTagType(string objectTag)
        {
            return objectTag == string.Empty ? string.Empty : objectTag.Split(":".ToCharArray())[0];
        }

        /// <summary>
        ///     获得对象的路径
        /// </summary>
        /// <returns></returns>
        public static string GetTagPath(string objectTag)
        {
            if (objectTag == string.Empty)
            {
                return string.Empty;
            }
            return objectTag.Split(":".ToCharArray()).Length == 2 ? objectTag.Split(":".ToCharArray())[1] : string.Empty;
        }

        /// <summary>
        ///     获得NodeData的名字
        /// </summary>
        /// <param name="strTag"></param>
        /// <returns></returns>
        public static string GetNameFromTag(string strTag)
        {
            var arr = strTag.Split("/".ToCharArray());
            return arr[arr.Length - 1]; 
        }

        /// <summary>
        ///     修改最末节名称
        /// </summary>
        /// <param name="strOldTag"></param>
        /// <param name="strNewName"></param>
        /// <returns></returns>
        public static string ChangeName(string strOldTag, string strNewName)
        {
            return strOldTag.Substring(0, strOldTag.LastIndexOf("/", StringComparison.Ordinal) + 1) + strNewName;
        }
    }
}