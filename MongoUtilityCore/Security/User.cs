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
        public BsonDocument OtherDbRoles;

        /// <summary>
        /// </summary>
        public BsonArray Roles;

        /// <summary>
        /// </summary>
        public string UserSource;

        /// <summary>
        ///     AddUserToSystem
        /// </summary>
        /// <param name="newUserEx">用户信息</param>
        /// <param name="isAdmin">是否是Admin</param>
        public static void AddUserToSystem(User newUserEx, bool isAdmin)
        {
            //必须使用MongoCredentials来添加用户,不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCollection users;
            users = isAdmin
                ? RuntimeMongoDbContext.GetCurrentServer()
                    .GetDatabase(ConstMgr.DatabaseNameAdmin)
                    .GetCollection(ConstMgr.CollectionNameUser)
                : RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(ConstMgr.CollectionNameUser);
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
        public static void AddUserEx(MongoCollection col, User user)
        {
            var document = col.FindOneAs<BsonDocument>(Query.EQ("user", user.Username));
            if (document == null)
            {
                document = new BsonDocument("user", user.Username);
            }
            document["roles"] = user.Roles;
            if (document.Contains("readOnly"))
            {
                document.Remove("readOnly");
            }
            //必须要Hash一下Password
            document["pwd"] = MongoUser.HashPassword(user.Username, user.Password);
            //OtherRole 必须放在Admin.system.users里面
            if (col.Database.Name == ConstMgr.DatabaseNameAdmin)
            {
                document["otherDBRoles"] = user.OtherDbRoles;
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                document["userSource"] = user.UserSource;
            }
            col.Save(document);
        }

        /// <summary>
        ///     Remove A User From Admin database
        /// </summary>
        /// <param name="strUser">UserName</param>
        public static void RemoveUserFromSystem(string strUser, bool isAdmin)
        {
            MongoCollection users;
            users = isAdmin
                ? RuntimeMongoDbContext.GetCurrentServer()
                    .GetDatabase(ConstMgr.DatabaseNameAdmin)
                    .GetCollection(ConstMgr.CollectionNameUser)
                : RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(ConstMgr.CollectionNameUser);
            users.Remove(Query.EQ("user", strUser));
        }

        /// <summary>
        ///     获得用户当前角色
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCurrentDbRoles(string connectionName, string dbName)
        {
            var roles = new List<string>();
//			foreach (BsonValue item in MongoDbHelper._mongoUserLst[ConnectionName].GetRolesByDBName(DBName)) {
//				Roles.Add(item.ToString());
//			}
            return roles;
        }

        #endregion
    }
}