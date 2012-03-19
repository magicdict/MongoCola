using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"服务器管理"
        /// <summary>
        /// 管理中服务器列表
        /// </summary>
        public static Dictionary<String, MongoServer> _mongoSrvLst = new Dictionary<String, MongoServer>();
        public static Dictionary<String, Boolean> _mongoStatusLst = new Dictionary<String, Boolean>();

        /// <summary>
        /// 增加管理服务器
        /// </summary>
        /// <param name="configLst"></param>
        /// <returns></returns>
        public static void AddServer(List<ConfigHelper.MongoConnectionConfig> configLst)
        {
            foreach (ConfigHelper.MongoConnectionConfig config in configLst)
            {
                try
                {
                    if (_mongoSrvLst.ContainsKey(config.ConnectionName))
                    {
                        _mongoSrvLst.Remove(config.ConnectionName);
                    }
                    _mongoSrvLst.Add(config.ConnectionName, CreateMongoSetting(config));
                }
                catch (Exception ex)
                {
                    MyMessageBox.ShowMessage("Exception", "Can't Connect to Server：" + config.ConnectionName, ex.ToString(), true);
                }
            }
        }
        /// <summary>
        /// 根据config获得Server
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static MongoServer CreateMongoSetting(ConfigHelper.MongoConnectionConfig config)
        {
            MongoServerSettings mongoSvrSetting = new MongoServerSettings();
            if (String.IsNullOrEmpty(config.ConnectionString))
            {
                mongoSvrSetting.ConnectionMode = ConnectionMode.Direct;
                //当一个服务器作为从属服务器，副本组中的备用服务器，这里一定要设置为SlaveOK
                mongoSvrSetting.SlaveOk = config.IsSlaveOk;
                //安全模式
                mongoSvrSetting.SafeMode = new SafeMode(config.IsSafeMode);
                //Replset时候可以不用设置吗？                    
                mongoSvrSetting.Server = new MongoServerAddress(config.Host, config.Port);
                //MapReduce的时候将消耗大量时间。不过这里需要平衡一下，太长容易造成并发问题
                if (config.SocketTimeOut != 0)
                {
                    mongoSvrSetting.SocketTimeout = new TimeSpan(0, 0, config.SocketTimeOut);
                }
                if (!(String.IsNullOrEmpty(config.UserName) | String.IsNullOrEmpty(config.Password)))
                {
                    //认证的设定:注意，这里的密码是明文
                    mongoSvrSetting.DefaultCredentials = new MongoCredentials(config.UserName, config.Password, config.LoginAsAdmin);
                }
                if (config.ServerRole == ConfigHelper.SvrRoleType.ReplsetSvr)
                {
                    //ReplsetName不是固有属性,可以设置，不过必须保持与配置文件的一致
                    mongoSvrSetting.ReplicaSetName = config.ReplSetName;
                    mongoSvrSetting.ConnectionMode = ConnectionMode.ReplicaSet;
                    //添加Replset服务器，注意，这里可能需要事先初始化副本
                    List<MongoServerAddress> ReplsetSvrList = new List<MongoServerAddress>();
                    foreach (String item in config.ReplsetList)
                    {
                        //如果这里的服务器在启动的时候没有--Replset参数，将会出错，当然作为单体的服务器，启动是没有任何问题的
                        MongoServerAddress ReplSrv = new MongoServerAddress(
                                        SystemManager.ConfigHelperInstance.ConnectionList[item].Host,
                                        SystemManager.ConfigHelperInstance.ConnectionList[item].Port);
                        ReplsetSvrList.Add(ReplSrv);
                    }
                    mongoSvrSetting.Servers = ReplsetSvrList;
                }
            }
            else
            {
                //使用MongoConnectionString建立连接
                mongoSvrSetting = MongoUrl.Create(config.ConnectionString).ToServerSettings();
            }
            MongoServer masterMongoSvr = new MongoServer(mongoSvrSetting);
            return masterMongoSvr;
        }
        /// <summary>
        /// 使用字符串连接来填充
        /// </summary>
        /// <remarks>http://www.mongodb.org/display/DOCS/Connections</remarks>
        /// <param name="connectionString"></param>
        /// <param name="config"></param>
        public static Boolean FillConfigWithConnectionString(ref ConfigHelper.MongoConnectionConfig config)
        {
            String connectionString = config.ConnectionString;
            //mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
            try
            {
                MongoUrl mongourl = MongoUrl.Create(connectionString);
                config.DataBaseName = mongourl.DatabaseName;
                if (mongourl.DefaultCredentials != null)
                {
                    config.UserName = mongourl.DefaultCredentials.Username;
                    config.Password = mongourl.DefaultCredentials.Password;
                    config.LoginAsAdmin = mongourl.DefaultCredentials.Admin;
                }
                config.Host = mongourl.Server.Host;
                config.Port = mongourl.Server.Port;
                config.IsSlaveOk = mongourl.SlaveOk;
                config.IsSafeMode = mongourl.SafeMode.Enabled;
                config.ReplSetName = mongourl.ReplicaSetName;
                config.SocketTimeOut = (int)mongourl.SocketTimeout.TotalSeconds;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        #endregion


    }
}
