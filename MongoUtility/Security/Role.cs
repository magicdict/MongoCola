using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoUtility.Security
{
    public class Role
    {
        #region"用户角色"

        public const string UserRoleRead = "read";
        public const string UserRoleReadWrite = "readWrite";
        public const string UserRoleDbAdmin = "dbAdmin";
        public const string UserRoleUserAdmin = "userAdmin";
        public const string UserRoleClusterAdmin = "clusterAdmin";
        public const string UserRoleReadAnyDatabase = "readAnyDatabase";
        public const string UserRoleReadWriteAnyDatabase = "readWriteAnyDatabase";
        public const string UserRoleUserAdminAnyDatabase = "userAdminAnyDatabase";
        public const string UserRoleDbAdminAnyDatabase = "dbAdminAnyDatabase";

        #endregion

        #region"角色操作"

        /// <summary>
        ///     可以省略？？
        /// </summary>
        public string Id;

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
            /// </summary>
            public MongoDbAction.ActionType[] Actions;

            /// <summary>
            /// </summary>
            public Resource Resource;
        }

        /// <summary>
        ///     角色
        /// </summary>
        public struct GrantRole
        {
            /// <summary>
            /// </summary>
            public string Db;

            /// <summary>
            /// </summary>
            public string MRole;
        }

        /// <summary>
        ///     添加一个用户自定义角色
        /// </summary>
        public static BsonValue AddRole(MongoDatabase mongoDb, Role role)
        {
            var roleCommand = string.Empty;
            var doc = new EvalArgs();
            roleCommand = "db.createRole(" + Environment.NewLine;
            roleCommand += "{" + Environment.NewLine;
            roleCommand += "    role: '" + role.Rolename + "'," + Environment.NewLine;
            //Roles
            roleCommand += "    roles:" + Environment.NewLine;
            roleCommand += "    [";
            for (var i = 0; i < role.Roles.Length; i++)
            {
                var singleroles = role.Roles[i];
                roleCommand += "{ role: '" + singleroles.MRole + "', db: '" + singleroles.Db + "' }" +
                               (i == role.Roles.Length - 1 ? "" : ",") + Environment.NewLine;
            }
            roleCommand += "     ],";
            //privileges
            roleCommand += "    privileges:" + Environment.NewLine;
            roleCommand += "    [";
            for (var i = 0; i < role.Privileges.Length; i++)
            {
                var singleprivileges = role.Privileges[i];
                roleCommand += "{" + singleprivileges.Resource.GetJsCode() + "," +
                               MongoDbAction.GetActionListJs(singleprivileges.Actions) + "}" +
                               (i == role.Privileges.Length - 1 ? "" : ",") + Environment.NewLine;
            }
            roleCommand += "     ],";
            //
            roleCommand += "}" + Environment.NewLine;
            roleCommand += ")";
            doc.Code = roleCommand;
            BsonValue result;
            try
            {
                result = mongoDb.Eval(doc);
            }
            catch (MongoCommandException ex)
            {
                result = ex.Result;
            }
            return result;
        }

        /// <summary>
        ///     GetRole
        /// </summary>
        /// <param name="mongoDb"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public static BsonDocument GetRole(MongoDatabase mongoDb, string roleName)
        {
            var doc = new EvalArgs();
            doc.Code = "db.getRole('" + roleName + "',{showPrivileges:true})";
            return mongoDb.Eval(doc).AsBsonDocument;
        }

        #endregion
    }
}