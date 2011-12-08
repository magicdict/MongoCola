using System;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

        /// <summary>
        /// 添加User到Admin数据库[效果如同添加USER到整个服务器]
        /// </summary>
        /// <param name="strUser">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="isReadOnly">是否为只读</param>
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
        /// 从Admin数据库删除用户
        /// </summary>
        /// <param name="strUser"></param>
        public static void RemoveUserFromSvr(String strUser)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentService();
            if (mongoSvr.AdminDatabase.FindUser(strUser) != null)
            {
                mongoSvr.AdminDatabase.RemoveUser(strUser);
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="strUser">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="isReadOnly">是否为只读</param>
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
        /// 删除用户
        /// </summary>
        /// <param name="strUser">用户名</param>
        public static void RemoveUserFromDB(string strUser)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (mongoDB.FindUser(strUser) != null)
            {
                mongoDB.RemoveUser(strUser);
            }
        }
        /// <summary>
        /// 关闭服务器
        /// </summary>
        public static void Shutdown()
        {
            MongoServer mongoSvr = GetMongoServerBySvrPath(SystemManager.SelectObjectTag);
            try
            {
                //the server will be  shutdown with exception
                mongoSvr.Shutdown();
            }
            catch (System.IO.IOException)
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
