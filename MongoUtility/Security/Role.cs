using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoUtility.Security
{
    public class Role
    {
        #region"用户角色"

        //Database User Roles
        public const string UserRoleRead = "read";
        public const string UserRoleReadWrite = "readWrite";

        //Database Administration Roles
        public const string UserRoleDbAdmin = "dbAdmin";
        public const string UserRoleDbOwner = "dbOwner";
        public const string UserRoleUserAdmin = "userAdmin";

        //Cluster Administration Roles
        public const string UserRoleClusterAdmin = "clusterAdmin";
        public const string UserRoleClusterManager = "clusterManager";
        public const string UserRoleClusterMonitor = "clusterMonitor";
        public const string UserRoleHostManager = "hostManager";

        //Backup and Restoration Roles
        public const string UserRoleBackup = "backup";
        public const string UserRoleRestore = "restore";

        //All-Database Roles
        public const string UserRoleReadAnyDatabase = "readAnyDatabase";
        public const string UserRoleReadWriteAnyDatabase = "readWriteAnyDatabase";
        public const string UserRoleUserAdminAnyDatabase = "userAdminAnyDatabase";
        public const string UserRoleDbAdminAnyDatabase = "dbAdminAnyDatabase";

        //Superuser Roles
        public const string UserRoleRoot = "root";

        //Internal Role
        public const string UserRoleSystem = "__system";

        #endregion

        #region"角色操作"

        /// <summary>
        ///     rolename
        /// </summary>
        public string Rolename;

        /// <summary>
        /// </summary>
        public string Database;

        /// <summary>
        /// </summary>
        public Privilege[] Privileges;

        /// <summary>
        /// </summary>
        public GrantRole[] Roles;

        /// <summary>
        ///     权限
        /// </summary>
        public struct Privilege
        {
            /// <summary>
            ///     Actions
            /// </summary>
            public BsonArray Actions;

            /// <summary>
            ///     Resource
            /// </summary>
            public BsonElement Resource;
            /// <summary>
            ///     AsBsonDocument
            /// </summary>
            /// <returns></returns>
            public BsonDocument AsBsonDocument()
            {
                BsonDocument privilege = new BsonDocument(Resource)
                {
                    { "actions", Actions }
                };
                return privilege;
            }
        }

        /// <summary>
        ///     角色
        /// </summary>
        public struct GrantRole
        {
            /// <summary>
            ///     数据库
            /// </summary>
            public string Db;

            /// <summary>
            ///     角色
            /// </summary>
            public string Role;
            /// <summary>
            ///     BsonValue
            /// </summary>
            /// <returns></returns>
            public BsonValue AsBsonValue()
            {
                if (string.IsNullOrEmpty(Db))
                {
                    return Role;
                }else
                {
                    var role = new BsonDocument("role", Role)
                    {
                        { "db", Db }
                    };
                    return role;
                }
            }
        }

        /// <summary>
        ///     GetRole
        /// </summary>
        /// <param name="mongoDb"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static BsonDocument GetRole(MongoDatabase mongoDb, string roleName)
        {
            var doc = new EvalArgs()
            {
                Code = "db.getRole('" + roleName + "',{showPrivileges:true})"
            };
            return mongoDb.Eval(doc).AsBsonDocument;
        }

        #endregion
    }
}