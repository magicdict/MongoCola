using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"用户操作"
        /// <summary>
        /// 用户
        /// </summary>
        public class MongoUserEx
        {
            public string Username;
            public string Password;
            public BsonArray roles;
            public string userSource;
            public BsonDocument otherDBRoles;
        }
        //这里有个漏洞,对于数据库来说，对于local的验证和对于admin的验证是相同的。
        //如果是加入用户到服务器中，是加入到local还是admin，需要考虑一下。

        /// <summary>
        /// AddUserToSystem
        /// </summary>
        /// <param name="newUserEx">用户信息</param>
        /// <param name="IsAdmin">是否是Admin</param>
        public static void AddUserToSystem(MongoUserEx newUserEx, Boolean IsAdmin)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentServer();
            //必须使用MongoCredentials来添加用户,不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCollection users;
            if (IsAdmin)
            {
                users = mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).GetCollection(MongoDBHelper.COLLECTION_NAME_USER);
            }
            else
            {
                users = SystemManager.GetCurrentDataBase().GetCollection(MongoDBHelper.COLLECTION_NAME_USER);
            }
            //以下代码 1.Ver2.4以前的有ReadOnly,FindUser需要寻找ReadOnly字段
            //         2.这个其实不用检查，有的话修改，没有的话，新建
            //if (users.Database.FindUser(newUserEx.Username) == null)
            //{
            AddUserEx(users, newUserEx);
            //}
        }
        /// <summary>
        /// Adds a user to this database.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void AddUserEx(MongoCollection Col, MongoUserEx user)
        {
            var document = Col.FindOneAs<BsonDocument>(MongoDB.Driver.Builders.Query.EQ("user", user.Username));
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
            if (Col.Database.Name == MongoDBHelper.DATABASE_NAME_ADMIN)
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
        /// Remove A User From Admin database
        /// </summary>
        /// <param name="strUser">UserName</param>
        public static void RemoveUserFromSystem(String strUser, Boolean IsAdmin)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentServer();
            MongoCollection users;
            if (IsAdmin)
            {
                users = mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).GetCollection(MongoDBHelper.COLLECTION_NAME_USER);
            }
            else
            {
                users = SystemManager.GetCurrentDataBase().GetCollection(MongoDBHelper.COLLECTION_NAME_USER);
            }
            users.Remove(MongoDB.Driver.Builders.Query.EQ("user", strUser));
        }
        /// <summary>
        /// 获得用户当前角色
        /// </summary>
        /// <returns></returns>
        public static BsonArray GetCurrentDBRoles()
        {
            BsonArray Roles = new BsonArray();
            String ConnectionName = SystemManager.GetCurrentServerConfig().ConnectionName;
            String DBName = SystemManager.GetCurrentDataBase().Name;
            Roles = _mongoUserLst[ConnectionName].GetRolesByDBName(DBName);
            return Roles;
        }
        /// <summary>
        /// Mongo操作
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
        /// 根据角色判断能否执行操作
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static Boolean JudgeRightByRole(BsonArray roles, MongoOperate opt)
        {
            Boolean CanDoIt = false;
            switch (opt)
            {
                case MongoOperate.DelMongoDB:
                case MongoOperate.RepairDB:
                    if (roles.Contains(MongoDBHelper.UserRole_clusterAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case MongoOperate.EvalJS:
                    //http://docs.mongodb.org/manual/reference/user-privileges/
                    //Combined Access
                    //Requires readWriteAnyDatabase, userAdminAnyDatabase, dbAdminAnyDatabase and clusterAdmin (on the admin database.)
                    if (roles.Contains(MongoDBHelper.UserRole_readWriteAnyDatabase) &&
                        roles.Contains(MongoDBHelper.UserRole_userAdminAnyDatabase) &&
                        roles.Contains(MongoDBHelper.UserRole_dbAdminAnyDatabase) &&
                        roles.Contains(MongoDBHelper.UserRole_clusterAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case MongoOperate.CreateMongoCollection:
                case MongoOperate.InitGFS:
                    if (roles.Contains(MongoDBHelper.UserRole_readWrite) ||
                        roles.Contains(MongoDBHelper.UserRole_readWriteAnyDatabase) ||
                        roles.Contains(MongoDBHelper.UserRole_dbAdmin))
                    {
                        CanDoIt = true;
                    }
                    break;
                case MongoOperate.AddUser:
                    if (roles.Contains(MongoDBHelper.UserRole_userAdmin) ||
                        roles.Contains(MongoDBHelper.UserRole_userAdminAnyDatabase))
                    {
                        CanDoIt = true;
                    }
                    break;
                default:
                    break;
            }
            return CanDoIt;
        }
        #endregion
    }
}

