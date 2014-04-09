using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MagicMongoDBTool.Module;

namespace Common.Security
{
    public static class Role
    {
        #region"用户角色"

        public const String UserRole_read = "read";
        public const String UserRole_readWrite = "readWrite";
        public const String UserRole_dbAdmin = "dbAdmin";
        public const String UserRole_userAdmin = "userAdmin";
        public const String UserRole_clusterAdmin = "clusterAdmin";
        public const String UserRole_readAnyDatabase = "readAnyDatabase";
        public const String UserRole_readWriteAnyDatabase = "readWriteAnyDatabase";
        public const String UserRole_userAdminAnyDatabase = "userAdminAnyDatabase";
        public const String UserRole_dbAdminAnyDatabase = "dbAdminAnyDatabase";

        #endregion

        #region"角色操作"
        /// <summary>
        /// 自定义角色
        /// </summary>
        public struct CustomRole
        {
            /// <summary>
            /// 
            /// </summary>
            public String _id;
            /// <summary>
            /// 
            /// </summary>
            public String role;
            /// <summary>
            /// 
            /// </summary>
            public privilege[] privileges;
            /// <summary>
            /// 
            /// </summary>
            public role[] roles;
        }
        /// <summary>
        /// 权限
        /// </summary>
        public struct privilege
        {
            /// <summary>
            /// 
            /// </summary>
            public String resource;
            /// <summary>
            /// 
            /// </summary>
            public String actions;

        }
        /// <summary>
        /// 角色
        /// </summary>
        public struct role
        {
            /// <summary>
            /// 
            /// </summary>
            public String mRole;
            /// <summary>
            /// 
            /// </summary>
            public String db;
        }
        /// <summary>
        /// 添加一个用户自定义角色
        /// </summary>
        public static void AddRole(MongoDatabase mongoDb, CustomRole role)
        {

        }
        /// <summary>
        /// GetRole
        /// </summary>
        /// <param name="mongoDb"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public static BsonDocument GetRole(MongoDatabase mongoDb,String RoleName)
        {
            EvalArgs doc = new EvalArgs();
            doc.Code = "db.getRole('" + RoleName + "',{showPrivileges:true})";
            return mongoDb.Eval(doc).AsBsonDocument;
        }
        #endregion

    }
}
