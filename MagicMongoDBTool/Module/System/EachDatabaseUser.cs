using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool.Module
{
    public class EachDatabaseUser
    {
        public Dictionary<String, MongoDBHelper.MongoUserEx> UserList = new Dictionary<string, MongoDBHelper.MongoUserEx>();
        /// <summary>
        /// 获得数据库角色
        /// </summary>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
        public BsonArray GetRolesByDBName(String DatabaseName) {
            BsonArray roles = new BsonArray();
            if (UserList.ContainsKey(DatabaseName)) {
                roles = UserList[DatabaseName].roles;
            }
            return roles;
        }
        /// <summary>
        /// 获得Admin的otherDBRoles
        /// </summary>
        /// <returns></returns>
        public BsonDocument GetOtherDBRoles() {
            BsonDocument roles = new BsonDocument();
            if (UserList.ContainsKey(MongoDBHelper.DATABASE_NAME_ADMIN)) {
                roles = UserList[MongoDBHelper.DATABASE_NAME_ADMIN].otherDBRoles;
            }
            return roles;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Username"></param>
        public void AddUser(MongoDatabase db,String Username){
           var userInfo = db.GetCollection(MongoDBHelper.COLLECTION_NAME_USER).FindOneAs<BsonDocument>(MongoDB.Driver.Builders.Query.EQ("user", Username));
           if (userInfo != null)
           {
               MongoDBHelper.MongoUserEx user = new MongoDBHelper.MongoUserEx();
               user.roles = userInfo["roles"].AsBsonArray;
               if (userInfo.Contains("otherDBRoles"))
               {
                   user.otherDBRoles = userInfo["otherDBRoles"].AsBsonDocument;
               }
               UserList.Add(db.Name, user); 
           }
        }
        public override string ToString()
        {
            String UserInfo = String.Empty;
            foreach (var item in UserList.Keys)
            {
                UserInfo += "DataBase:" + item + System.Environment.NewLine;
                if (UserList[item].roles != null) {
                    UserInfo += "Roles:" + UserList[item].roles + System.Environment.NewLine;
                }
                if (UserList[item].otherDBRoles != null)
                {
                    UserInfo += "otherDBRoles:" + UserList[item].otherDBRoles + System.Environment.NewLine;
                }
                UserInfo += System.Environment.NewLine;
            }
            return UserInfo;
        }
    }
}
