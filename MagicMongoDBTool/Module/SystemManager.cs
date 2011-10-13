using System;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static class SystemManager
    {
        public static ConfigHelper mConfig = new ConfigHelper();
        public static String SelectObjectTag = String.Empty;
        /// <summary>
        /// 通过服务器名称获得服务器配置
        /// </summary>
        /// <param name="SrvName"></param>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig getSelectedSrvProByName() {
            String SrvName = SelectObjectTag.Split(":".ToCharArray())[1];
            SrvName = SrvName.Split("/".ToCharArray())[0]; 
            ConfigHelper.MongoConnectionConfig rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (mConfig.ConnectionList.ContainsKey(SrvName)) {
                rtnMongoConnectionConfig = mConfig.ConnectionList[SrvName];
            }
            return rtnMongoConnectionConfig;
        }
        /// <summary>
        /// 获得当前服务器
        /// </summary>
        /// <returns></returns>
        public static MongoServer getCurrentService() {
            return MongoDBHelpler.GetMongoServerBySvrPath(SelectObjectTag, true);
        }
        /// <summary>
        /// 获得当前数据库
        /// </summary>
        /// <returns></returns>
        public static MongoDatabase getCurrentDataBase()
        {
            return MongoDBHelpler.GetMongoDBBySvrPath(SelectObjectTag, true);
        }
        /// <summary>
        /// 获得当前数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection getCurrentCollection()
        {
            return MongoDBHelpler.GetMongoCollectionBySvrPath(SelectObjectTag, true);
        }
    }
}
