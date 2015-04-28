using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;

namespace MongoUtility.Security
{
    public class EachDatabaseUser
    {
        public Dictionary<string, User> UserList =
            new Dictionary<string, User>();

        /// <summary>
        ///     获得数据库角色
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public BsonArray GetRolesByDbName(string databaseName)
        {
            var roles = new BsonArray();
            //当前DB的System.user的角色
            if (UserList.ContainsKey(databaseName))
            {
                roles = UserList[databaseName].Roles;
            }
            //Admin的OtherDBRoles和当前数据库角色合并
            var adminRoles = GetOtherDbRoles(databaseName);
            foreach (string item in adminRoles)
            {
                if (!roles.Contains(item))
                {
                    roles.Add(item);
                }
            }
            //ADMIN的ANY系角色的追加
            if (UserList.ContainsKey(ConstMgr.DatabaseNameAdmin))
            {
                if (UserList[ConstMgr.DatabaseNameAdmin].Roles.Contains(Role.UserRoleDbAdminAnyDatabase))
                {
                    roles.Add(Role.UserRoleDbAdminAnyDatabase);
                }
                if (UserList[ConstMgr.DatabaseNameAdmin].Roles.Contains(Role.UserRoleReadAnyDatabase))
                {
                    roles.Add(Role.UserRoleReadAnyDatabase);
                }
                if (
                    UserList[ConstMgr.DatabaseNameAdmin].Roles.Contains(
                        Role.UserRoleReadWriteAnyDatabase))
                {
                    roles.Add(Role.UserRoleReadWriteAnyDatabase);
                }
                if (
                    UserList[ConstMgr.DatabaseNameAdmin].Roles.Contains(
                        Role.UserRoleUserAdminAnyDatabase))
                {
                    roles.Add(Role.UserRoleUserAdminAnyDatabase);
                }
            }
            return roles;
        }

        /// <summary>
        ///     获得Admin的otherDBRoles
        /// </summary>
        /// <returns></returns>
        public BsonArray GetOtherDbRoles(string dataBaseName)
        {
            var roles = new BsonArray();
            var otherDbRoles = new BsonDocument();
            if (UserList.ContainsKey(ConstMgr.DatabaseNameAdmin))
            {
                otherDbRoles = UserList[ConstMgr.DatabaseNameAdmin].OtherDbRoles;
                if (otherDbRoles != null && otherDbRoles.Contains(dataBaseName))
                {
                    roles = otherDbRoles[dataBaseName].AsBsonArray;
                }
            }
            return roles;
        }

        /// <summary>
        /// </summary>
        /// <param name="db"></param>
        /// <param name="username"></param>
        public void AddUser(MongoDatabase db, string username)
        {
            var userInfo =
                db.GetCollection(ConstMgr.CollectionNameUser).FindOneAs<BsonDocument>(Query.EQ("user", username));
            if (userInfo != null)
            {
                var user = new User();
                user.Roles = userInfo["roles"].AsBsonArray;
                if (userInfo.Contains("otherDBRoles"))
                {
                    user.OtherDbRoles = userInfo["otherDBRoles"].AsBsonDocument;
                }
                UserList.Add(db.Name, user);
            }
        }

        /// <summary>
        ///     重载ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var userInfo = string.Empty;
            foreach (var item in UserList.Keys)
            {
                userInfo += "DataBase:" + item + Environment.NewLine;
                if (UserList[item].Roles != null)
                {
                    userInfo += "Roles:" + UserList[item].Roles + Environment.NewLine;
                }
                if (UserList[item].OtherDbRoles != null)
                {
                    userInfo += "otherDBRoles:" + UserList[item].OtherDbRoles + Environment.NewLine;
                }
                userInfo += Environment.NewLine;
            }
            return userInfo;
        }
    }
}