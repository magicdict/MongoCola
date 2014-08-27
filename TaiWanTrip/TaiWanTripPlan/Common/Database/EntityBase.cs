using System;
using MongoDB.Bson;

namespace Common.Database
{
    /// <summary>
    /// 实体
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// MongoDB Key
        /// </summary>
        public BsonObjectId _id;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime;
        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateUser;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateDateTime;
        /// <summary>
        /// 更新者
        /// </summary>
        public string UpdateUser;
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool IsDel;
    }
}