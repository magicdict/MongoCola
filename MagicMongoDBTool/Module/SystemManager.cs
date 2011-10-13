using System;

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
    }
}
