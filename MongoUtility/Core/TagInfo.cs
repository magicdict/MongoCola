using System;

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
        public string TagString = string.Empty;
        /// <summary>
        ///     除去表示类别的数据
        /// </summary>
        public string TagData = string.Empty;
        /// <summary>
        ///     对象名称
        /// </summary>
        public string ObjName = string.Empty;
        /// <summary>
        ///     类别
        /// </summary>
        public string TagType = string.Empty;

        /// <summary>
        /// GetMongoObj
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static TagInfo GetMongoObj(string tag)
        {
            var info = new TagInfo
            {
                TagString = tag,
                TagData = GetTagData(tag),
                TagType = GetTagType(tag),
                ObjName = GetNameFromNodeData(tag)
            };
            return info;
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
        public static string GetTagData(string objectTag)
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
        /// <param name="nodeData"></param>
        /// <returns></returns>
        public static string GetNameFromNodeData(string nodeData)
        {
            var arr = nodeData.Split("/".ToCharArray());
            return arr[arr.Length - 1];
        }
    }
}
