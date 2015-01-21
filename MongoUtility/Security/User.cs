using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Security
{
    public class User
    {
        #region"用户操作"

        /// <summary>
        /// </summary>
        public string Password;

        /// <summary>
        /// </summary>
        public string Username;

        /// <summary>
        /// </summary>
        public BsonDocument otherDBRoles;

        /// <summary>
        /// </summary>
        public BsonArray roles;

        /// <summary>
        /// </summary>
        public string userSource;

        /// <summary>
        ///     AddUserToSystem
        /// </summary>
        /// <param name="newUserEx">用户信息</param>
        /// <param name="IsAdmin">是否是Admin</param>
        public static void AddUserToSystem(User newUserEx, Boolean IsAdmin)
        {
            //必须使用MongoCredentials来添加用户,不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCollection users;
            users = IsAdmin
                ? RuntimeMongoDBContext.GetCurrentServer()
                    .GetDatabase(ConstMgr.DATABASE_NAME_ADMIN)
                    .GetCollection(ConstMgr.COLLECTION_NAME_USER)
                : RuntimeMongoDBContext.GetCurrentDataBase().GetCollection(ConstMgr.COLLECTION_NAME_USER);
            //以下代码 1.Ver2.4以前的有ReadOnly,FindUser需要寻找ReadOnly字段
            //        2.这个其实不用检查，有的话修改，没有的话，新建
            //if (users.Database.FindUser(newUserEx.Username) == null)
            //{
            AddUserEx(users, newUserEx);
            //}
        }

        /// <summary>
        ///     Adds a user to this database.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void AddUserEx(MongoCollection Col, User user)
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
            if (Col.Database.Name == ConstMgr.DATABASE_NAME_ADMIN)
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
            MongoCollection users;
            users = IsAdmin
                ? RuntimeMongoDBContext.GetCurrentServer()
                    .GetDatabase(ConstMgr.DATABASE_NAME_ADMIN)
                    .GetCollection(ConstMgr.COLLECTION_NAME_USER)
                : RuntimeMongoDBContext.GetCurrentDataBase().GetCollection(ConstMgr.COLLECTION_NAME_USER);
            users.Remove(Query.EQ("user", strUser));
        }

        /// <summary>
        ///     获得用户当前角色
        /// </summary>
        /// <returns></returns>
        public static List<String> GetCurrentDBRoles(String ConnectionName, String DBName)
        {
            var Roles = new List<String>();
//			foreach (BsonValue item in MongoDbHelper._mongoUserLst[ConnectionName].GetRolesByDBName(DBName)) {
//				Roles.Add(item.ToString());
//			}
            return Roles;
        }

        #endregion
    }
}