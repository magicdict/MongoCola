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
            MongoDatabase mongodb = mongosrv.GetDatabase("admin");
            MongoUser newUser = new MongoUser(strUser, Password, IsReadOnly);
            if (mongodb.FindUser(strUser) == null)
            {
                mongodb.AddUser(newUser);
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
            MongoDatabase mongodb = mongosrv.GetDatabase("admin");
            if (mongodb.FindUser(strUser) != null)
            {
                mongodb.RemoveUser(strUser);
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
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            MongoUser newUser = new MongoUser(strUser, Password, IsReadOnly);
            if (mongodb.FindUser(strUser) == null)
            {
                mongodb.AddUser(newUser);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        public static void RemoveUserFromDB(String strDBPath, String strUser)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            if (mongodb.FindUser(strUser) != null)
            {
                mongodb.RemoveUser(strUser);
            }
        }
        public static void Shutdown()
        {
            MongoServer mongosrv = GetMongoServerBySvrPath(SystemManager.SelectObjectTag, true);
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
