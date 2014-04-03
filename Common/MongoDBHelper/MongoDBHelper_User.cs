using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDbHelper
    {
        #region"用户操作"

        //这里有个漏洞,对于数据库来说，对于local的验证和对于admin的验证是相同的。
        //如果是加入用户到服务器中，是加入到local还是admin，需要考虑一下。

        /// <summary>
        ///     Mongo操作
        /// </summary>
        public enum MongoOperate
        {
            DelMongoDB,
            CreateMongoCollection,
            InitGFS,
            AddUser,
            RepairDB,
            EvalJS
        }

        /// <summary>
        ///     AddUserToSystem
        /// </summary>
        /// <param name="newUserEx">用户信息</param>
        /// <param name="IsAdmin">是否是Admin</param>
        public static void AddUserToSystem(MongoUserEx newUserEx, Boolean IsAdmin)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentServer();
            //必须使用MongoCredentials来添加用户,不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCollection users;
            users = IsAdmin
                ? mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).GetCollection(COLLECTION_NAME_USER)
                : SystemManager.GetCurrentDataBase().GetCollection(COLLECTION_NAME_USER);
            //以下代码 1.Ver2.4以前的有ReadOnly,FindUser需要寻找ReadOnly字段
            //         2.这个其实不用检查，有的话修改，没有的话，新建
            //if (users.Database.FindUser(newUserEx.Username) == null)
            //{
            AddUserEx(users, newUserEx);
            //}
        }

        /// <summary>
        ///     Adds a user to this database.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void AddUserEx(MongoCollection Col, MongoUserEx user)
        {
            var document = Col.FindOneAs<BsonDocument>(Query.EQ("user", user.Username));
            if (document == null)
            {
                document = new BsonDocument("user", user.Username);
            }
            document["roles"] = user.roles;
            if (document.Contains("readOnly"))
            {
                document.Remove("readOnly");
            }
            //必须要Hash一下Password
            document["pwd"] = MongoUser.HashPassword(user.Username, user.Password);
            //OtherRole 必须放在Admin.system.users里面
            if (Col.Database.Name == DATABASE_NAME_ADMIN)
            {
                document["otherDBRoles"] = user.otherDBRoles;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                document["userSource"] = user.userSource;
            }
            Col.Save(document);
        }

        /// <summary>
        ///     Remove A User From Admin database
        /// </summary>
        /// <param name="strUser">UserName</param>
        public static void RemoveUserFromSystem(String strUser, Boolean IsAdmin)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentServer();
            MongoCollection users;
            users = IsAdmin
                ? mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).GetCollection(COLLECTION_NAME_USER)
                : SystemManager.GetCurrentDataBase().GetCollection(COLLECTION_NAME_USER);
            users.Remove(Query.EQ("user", strUser));
        }

        /// <summary>
        ///     获得用户当前角色
        /// </summary>
        /// <returns></returns>
        public static List<String> GetCurrentDBRoles()
        {
            var Roles = new List<String>();
            String ConnectionName = SystemManager.GetCurrentServerConfig().ConnectionName;
            String DBName = SystemManager.GetCurrentDataBase().Name;
            foreach (BsonValue item in _mongoUserLst[ConnectionName].GetRolesByDBName(DBName))
            {
                Roles.Add(item.ToString());
            }
            return Roles;
        }

        /// <summary>
        ///     根据角色判断能否执行操作
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static Boolean JudgeRightByRole(List<String> roles, MongoOperate opt)
        {
            Boolean CanDoIt = false;
            switch (opt)
            {
                case MongoOperate.DelMongoDB:
                case MongoOperate.RepairDB:
                    if (roles.Contains(UserRole_clusterAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case MongoOperate.EvalJS:
                    //http://docs.mongodb.org/manual/reference/user-privileges/
                    //Combined Access
                    //Requires readWriteAnyDatabase, userAdminAnyDatabase, dbAdminAnyDatabase and clusterAdmin (on the admin database.)
                    if (roles.Contains(UserRole_readWriteAnyDatabase) &&
                        roles.Contains(UserRole_userAdminAnyDatabase) &&
                        roles.Contains(UserRole_dbAdminAnyDatabase) &&
                        roles.Contains(UserRole_clusterAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case MongoOperate.CreateMongoCollection:
                case MongoOperate.InitGFS:
                    if (roles.Contains(UserRole_readWrite) ||
                        roles.Contains(UserRole_readWriteAnyDatabase) ||
                        roles.Contains(UserRole_dbAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case MongoOperate.AddUser:
                    if (roles.Contains(UserRole_userAdmin) ||
                        roles.Contains(UserRole_userAdminAnyDatabase))
                    {
                        CanDoIt = true;
                    }
                    break;
                default:
                    break;
            }
            return CanDoIt;
        }

        /// <summary>
        ///     用户
        /// </summary>
        public class MongoUserEx
        {
            public string Password;
            public string Username;
            public BsonDocument otherDBRoles;
            public BsonArray roles;
            public string userSource;
        }

        #endregion

        #region"角色操作"
            public static void AddRole(){

            }
        #endregion
    }
}