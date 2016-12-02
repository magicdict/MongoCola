using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Security
{
    public class MongoUserEx
    {
        #region"用户操作"

        /// <summary>
        ///     密码
        /// </summary>
        public string Password;

        /// <summary>
        ///     用户
        /// </summary>
        public string Username;

        /// <summary>
        ///     角色
        /// </summary>
        public List<Role.GrantRole> Roles;

        /// <summary>
        ///     自定义数据
        /// </summary>
        public BsonDocument customData;


        /// <summary>
        ///     增加用户
        /// </summary>
        /// <param name="user"></param>
        public static CommandResult AddUser(MongoUserEx user, bool IsAdmin)
        {
            var result = Command.DataBaseCommand.createUser(user, IsAdmin ? RuntimeMongoDbContext.GetCurrentServer()
                    .GetDatabase(ConstMgr.DatabaseNameAdmin) : RuntimeMongoDbContext.GetCurrentDataBase());
            return result;
        }

        /// <summary>
        ///     修改用户
        /// </summary>
        /// <param name="user"></param>
        public static CommandResult UpdateUser(MongoUserEx user, bool IsAdmin)
        {
            var result = Command.DataBaseCommand.updateUser(user, IsAdmin ? RuntimeMongoDbContext.GetCurrentServer()
                    .GetDatabase(ConstMgr.DatabaseNameAdmin) : RuntimeMongoDbContext.GetCurrentDataBase());
            return result;
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
                    .GetCollection(ConstMgr.CollectionNameUsers)
                : RuntimeMongoDbContext.GetCurrentDataBase().GetCollection(ConstMgr.CollectionNameUsers);
            users.Remove(Query.EQ("user", strUser));
        }

        /// <summary>
        ///     获得用户当前角色
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCurrentDbRoles(string connectionName, string dbName)
        {
            var roles = new List<string>();
            return roles;
        }

        #endregion
    }
}