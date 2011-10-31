using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {

        /// <summary>
        /// 添加User到Admin数据库[效果如同添加USER到整个服务器]
        /// </summary>
        /// <param name="strDBPath"></param>
        /// <param name="strUser"></param>
        /// <param name="Password"></param>
        /// <param name="IsReadOnly"></param>
        public static void AddUserToSrv(String strDBPath, String strUser, String Password, Boolean IsReadOnly)
        {
            MongoServer mongosrv = SystemManager.getCurrentService();
            //必须使用MongoCredentials来添加用户不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCredentials newUser = new MongoCredentials(strUser, Password,true);
            if (mongosrv.AdminDatabase.FindUser(strUser) == null)
            {
                mongosrv.AdminDatabase.AddUser(newUser,IsReadOnly);
            }
        }
        /// <summary>
        /// 从Admin数据库删除用户
        /// </summary>
        /// <param name="strDBPath"></param>
        /// <param name="strUser"></param>
        public static void RemoveUserFromSrv(String strDBPath, String strUser)
        {
            MongoServer mongosrv = SystemManager.getCurrentService();
            if (mongosrv.AdminDatabase.FindUser(strUser) != null)
            {
                mongosrv.AdminDatabase.RemoveUser(strUser);
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        /// <param name="Password">密码</param>
        /// <param name="IsReadOnly">是否为只读</param>
        public static void AddUserToDB(String strDBPath, String strUser, String Password, Boolean IsReadOnly)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath);
            MongoCredentials newUser = new MongoCredentials(strUser, Password, false);
            if (mongodb.FindUser(strUser) == null)
            {
                mongodb.AddUser(newUser,IsReadOnly);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        public static void RemoveUserFromDB(String strDBPath, String strUser)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath);
            if (mongodb.FindUser(strUser) != null)
            {
                mongodb.RemoveUser(strUser);
            }
        }
        public static void Shutdown()
        {
            MongoServer mongosrv = GetMongoServerBySvrPath(SystemManager.SelectObjectTag);
            try
            {
                //the server will be  shutdown with exception
                mongosrv.Shutdown();
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
