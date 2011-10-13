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
        /// 添加用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        /// <param name="Pw">密码</param>
        /// <param name="IsReadOnly">是否为只读</param>
        public static void AddUserForDB(String strDBPath, String strUser, String Pw, Boolean IsReadOnly)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            MongoUser newUser = new MongoUser(strUser, Pw, IsReadOnly);
            if (mongodb.FindUser(strUser) == null)
            {
                mongodb.AddUser(newUser);
            }
        }
        public static void ChangePwForDB(String strDBPath, String strUser, String OldPw, String NewPw)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            //TODO:
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        public static void RemoveUserForDB(String strDBPath, String strUser)
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
