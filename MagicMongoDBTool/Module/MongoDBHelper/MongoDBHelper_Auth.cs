using System;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

        /// <summary>
        /// Add A User to Admin database
        /// </summary>
        /// <param name="strUser">Username</param>
        /// <param name="password">Password</param>
        /// <param name="isReadOnly">Is ReadOnly</param>
        public static void AddUserToSvr(string strUser, string password, bool isReadOnly)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentService();
            //必须使用MongoCredentials来添加用户不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCredentials newUser = new MongoCredentials(strUser, password, true);
            if (mongoSvr.AdminDatabase.FindUser(strUser) == null)
            {
                mongoSvr.AdminDatabase.AddUser(newUser, isReadOnly);
            }
        }
        /// <summary>
        /// Remove A User From Admin database
        /// </summary>
        /// <param name="strUser">UserName</param>
        public static void RemoveUserFromSvr(String strUser)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentService();
            if (mongoSvr.AdminDatabase.FindUser(strUser) != null)
            {
                mongoSvr.AdminDatabase.RemoveUser(strUser);
            }
        }
        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="strUser">Username</param>
        /// <param name="password">Password</param>
        /// <param name="isReadOnly">Is ReadOnly</param>
        public static void AddUserToDB(string strUser, string password, bool isReadOnly)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoCredentials newUser = new MongoCredentials(strUser, password, false);
            if (mongoDB.FindUser(strUser) == null)
            {
                mongoDB.AddUser(newUser, isReadOnly);
            }
        }

        /// <summary>
        /// Remove User
        /// </summary>
        /// <param name="strUser">Username</param>
        public static void RemoveUserFromDB(string strUser)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (mongoDB.FindUser(strUser) != null)
            {
                mongoDB.RemoveUser(strUser);
            }
        }
    }
}
