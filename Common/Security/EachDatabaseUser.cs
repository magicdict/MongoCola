using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool.Module
{
    public class EachDatabaseUser
    {
        public Dictionary<String, MongoUserHelper.MongoUserEx> UserList =
            new Dictionary<string, MongoUserHelper.MongoUserEx>();
        /// <summary>
        ///     获得数据库角色
        /// </summary>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
        public BsonArray GetRolesByDBName(String DatabaseName)
        {
            var roles = new BsonArray();
            //当前DB的System.user的角色
            if (UserList.ContainsKey(DatabaseName))
            {
                roles = UserList[DatabaseName].roles;
            }
            //Admin的OtherDBRoles和当前数据库角色合并
            BsonArray adminRoles = GetOtherDBRoles(DatabaseName);
            foreach (String item in adminRoles)
            {
                if (!roles.Contains(item))
                {
                    roles.Add(item);
                }
            }
            //ADMIN的ANY系角色的追加
            if (UserList.ContainsKey(MongoDbHelper.DATABASE_NAME_ADMIN))
            {
                if (UserList[MongoDbHelper.DATABASE_NAME_ADMIN].roles.Contains(MongoUserHelper.UserRole_dbAdminAnyDatabase))
                {
                    roles.Add(MongoUserHelper.UserRole_dbAdminAnyDatabase);
                }
                if (UserList[MongoDbHelper.DATABASE_NAME_ADMIN].roles.Contains(MongoUserHelper.UserRole_readAnyDatabase))
                {
                    roles.Add(MongoUserHelper.UserRole_readAnyDatabase);
                }
                if (
                    UserList[MongoDbHelper.DATABASE_NAME_ADMIN].roles.Contains(
                        MongoUserHelper.UserRole_readWriteAnyDatabase))
                {
                    roles.Add(MongoUserHelper.UserRole_readWriteAnyDatabase);
                }
                if (
                    UserList[MongoDbHelper.DATABASE_NAME_ADMIN].roles.Contains(
                        MongoUserHelper.UserRole_userAdminAnyDatabase))
                {
                    roles.Add(MongoUserHelper.UserRole_userAdminAnyDatabase);
                }
            }
            return roles;
        }

        /// <summary>
        ///     获得Admin的otherDBRoles
        /// </summary>
        /// <returns></returns>
        public BsonArray GetOtherDBRoles(String DataBaseName)
        {
            var roles = new BsonArray();
            var OtherDBRoles = new BsonDocument();
            if (UserList.ContainsKey(MongoDbHelper.DATABASE_NAME_ADMIN))
            {
                OtherDBRoles = UserList[MongoDbHelper.DATABASE_NAME_ADMIN].otherDBRoles;
                if (OtherDBRoles != null && OtherDBRoles.Contains(DataBaseName))
                {
                    roles = OtherDBRoles[DataBaseName].AsBsonArray;
                }
            }
            return roles;
        }

        /// <summary>
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Username"></param>
        public void AddUser(MongoDatabase db, String Username)
        {
            var userInfo =
                db.GetCollection(MongoDbHelper.COLLECTION_NAME_USER).FindOneAs<BsonDocument>(Query.EQ("user", Username));
            if (userInfo != null)
            {
                var user = new MongoUserHelper.MongoUserEx();
                user.roles = userInfo["roles"].AsBsonArray;
                if (userInfo.Contains("otherDBRoles"))
                {
                    user.otherDBRoles = userInfo["otherDBRoles"].AsBsonDocument;
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
            String UserInfo = String.Empty;
            foreach (string item in UserList.Keys)
            {
                UserInfo += "DataBase:" + item + Environment.NewLine;
                if (UserList[item].roles != null)
                {
                    UserInfo += "Roles:" + UserList[item].roles + Environment.NewLine;
                }
                if (UserList[item].otherDBRoles != null)
                {
                    UserInfo += "otherDBRoles:" + UserList[item].otherDBRoles + Environment.NewLine;
                }
                UserInfo += Environment.NewLine;
            }
            return UserInfo;
        }
    }
}