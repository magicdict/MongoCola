using System;
using MongoUtility.Basic;

namespace MongoUtility.Core
{
    /// <summary>
    /// TagInfo
    /// </summary>
    public class TagInfo
    {
        /// <summary>
        ///     全路径
        /// </summary>
        string TagString = string.Empty;
        /// <summary>
        ///     除去表示类别的数据
        /// </summary>
        public string TagPath = string.Empty;
        /// <summary>
        ///     对象名称
        /// </summary>
        public string ObjName = string.Empty;
        /// <summary>
        ///     类别(String)
        /// </summary>
        public string TagType = string.Empty;
        /// <summary>
        ///     类别(Enum)
        /// </summary>
        public EnumMgr.PathLevel PathLevel = EnumMgr.PathLevel.Document;
        /// <summary>
        ///     CreateTagInfo
        /// </summary>
        /// <param name="ConnectionName"></param>
        public static TagInfo CreateTagInfo(string ConnectionName)
        {
            var TagString = ConstMgr.ConnectionTag + ":" + ConnectionName;
            return GetMongoObj(TagString);
        }
        /// <summary>
        /// CreateTagInfo
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <param name="DataBaseName"></param>
        /// <returns></returns>
        public static TagInfo CreateTagInfo(string ConnectionName, string DataBaseName)
        {
            var TagString = ConstMgr.DatabaseTag + ":" + ConnectionName + "/" + DataBaseName;
            return GetMongoObj(TagString);
        }
        /// <summary>
        /// CreateTagInfo
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <param name="DataBase"></param>
        /// <param name="CollectionName"></param>
        /// <returns></returns>
        public static TagInfo CreateTagInfo(string ConnectionName, string DataBase, string CollectionName)
        {
            var TagString = ConstMgr.CollectionTag + ":" + ConnectionName + "/" + DataBase + "/" + CollectionName;
            return GetMongoObj(TagString);
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return TagString;
        }

        /// <summary>
        ///     GetMongoObj
        /// </summary>
        /// <param name="strTag"></param>
        /// <returns></returns>
        static TagInfo GetMongoObj(string strTag)
        {
            var info = new TagInfo
            {
                TagString = strTag,
                TagPath = GetTagPath(strTag),
                TagType = GetTagType(strTag),
                ObjName = GetNameFromTag(strTag),
                PathLevel = TagType2PathLevel(GetTagType(strTag))
            };
            return info;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strTagType"></param>
        /// <returns></returns>
        static EnumMgr.PathLevel TagType2PathLevel(string strTagType)
        {
            EnumMgr.PathLevel Level = EnumMgr.PathLevel.Document;
            switch (strTagType)
            {
                case ConstMgr.ConnectionTag:
                    Level = EnumMgr.PathLevel.Connection;
                    break;
                case ConstMgr.DatabaseTag:
                    Level = EnumMgr.PathLevel.Database;
                    break;
                case ConstMgr.CollectionTag:
                    Level = EnumMgr.PathLevel.Collection;
                    break;
                default:
                    break;
            }
            return Level;
        }

        /// <summary>
        ///     获得对象的种类
        /// </summary>
        /// <returns></returns>
        public static string GetTagType(string objectTag)
        {
            return objectTag == String.Empty ? String.Empty : objectTag.Split(":".ToCharArray())[0];
        }

        /// <summary>
        ///     获得对象的路径
        /// </summary>
        /// <returns></returns>
        public static string GetTagPath(string objectTag)
        {
            if (objectTag == String.Empty)
            {
                return String.Empty;
            }
            return objectTag.Split(":".ToCharArray()).Length == 2 ? objectTag.Split(":".ToCharArray())[1] : String.Empty;
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
