using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static class SystemManager
    {
        public static ConfigHelper ConfigHelperInstance = new ConfigHelper();
        public static string SelectObjectTag = String.Empty;
        /// <summary>
        /// 通过服务器名称获得服务器配置
        /// </summary>
        /// <param name="SrvName"></param>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig getSelectedSrvProByName()
        {
            string srvName = SelectObjectTag.Split(":".ToCharArray())[1];
            srvName = srvName.Split("/".ToCharArray())[0];
            ConfigHelper.MongoConnectionConfig rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (ConfigHelperInstance.ConnectionList.ContainsKey(srvName))
            {
                rtnMongoConnectionConfig = ConfigHelperInstance.ConnectionList[srvName];
            }
            return rtnMongoConnectionConfig;
        }
        /// <summary>
        /// 获得当前服务器
        /// </summary>
        /// <returns></returns>
        public static MongoServer GetCurrentService()
        {
            return MongoDBHelpler.GetMongoServerBySvrPath(SelectObjectTag);
        }
        /// <summary>
        /// 获得当前数据库
        /// </summary>
        /// <returns></returns>
        public static MongoDatabase GetCurrentDataBase()
        {
            return MongoDBHelpler.GetMongoDBBySvrPath(SelectObjectTag);
        }
        /// <summary>
        /// 获得当前数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentCollection()
        {
            return MongoDBHelpler.GetMongoCollectionBySvrPath(SelectObjectTag);
        }
        /// <summary>
        /// 获得系统JS数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentJsCollection()
        {
            MongoDatabase Mongodb = GetCurrentDataBase();
            MongoCollection MongoJsCol = Mongodb.GetCollection(MongoDBHelpler.COLLECTION_NAME_JAVASCRIPT);
            return MongoJsCol;
        }

        public static List<string> GetJsNameList()
        {
            List<string> jsNamelst = new List<string>();
            foreach (var item in GetCurrentJsCollection().FindAllAs<BsonDocument>())
            {
                jsNamelst.Add(item.GetValue("_id").ToString());
            }
            return jsNamelst;

        }
    }
}
