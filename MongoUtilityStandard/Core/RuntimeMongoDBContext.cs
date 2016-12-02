using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MongoUtility.Core
{
    /// <summary>
    ///     MongoDB运行时环境
    /// </summary>
    public static class RuntimeMongoDbContext
    {
        #region 实例准备

        /// <summary>
        ///     CreateMongoServer
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static MongoServer CreateMongoServer(ref MongoConnectionConfig config)
        {
            var masterMongoClient = new MongoClient(CreateMongoClientSettingsByConfig(ref config));
            return masterMongoClient.GetServer();
        }

        /// <summary>
        ///     CreateMongoClient
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static MongoClient CreateMongoClient(ref MongoConnectionConfig config)
        {
            var masterMongoClient = new MongoClient(CreateMongoClientSettingsByConfig(ref config));
            return masterMongoClient;
        }

        /// <summary>
        ///     获得密码的委托
        /// </summary>
        public static Func<string, string> GetPassword = null;

        /// <summary>
        ///     根据config获得MongoClientSettings,同时更新一些运行时变量
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static MongoClientSettings CreateMongoClientSettingsByConfig(ref MongoConnectionConfig config)
        {
            //修改获得数据实例的方法
            var mongoClientSetting = new MongoClientSettings();
            if (string.IsNullOrEmpty(config.ConnectionString))
            {
                mongoClientSetting.ConnectionMode = ConnectionMode.Direct;
                ReadWrite.SetReadPreferenceWriteConcern(mongoClientSetting, config);
                //Replset时候可以不用设置吗？                    
                mongoClientSetting.Server = new MongoServerAddress(config.Host, config.Port);
                //MapReduce的时候将消耗大量时间。不过这里需要平衡一下，太长容易造成并发问题
                //The default value for SocketTimeout has been changed from 30 seconds to 0, 
                if (config.SocketTimeoutMs != 0)
                {
                    mongoClientSetting.SocketTimeout = new TimeSpan(0, 0, (int)(config.SocketTimeoutMs / 1000));
                }
                if (config.ConnectTimeoutMs != 0)
                {
                    mongoClientSetting.ConnectTimeout = new TimeSpan(0, 0, (int)(config.ConnectTimeoutMs / 1000));
                }
                //运行时LoginAsAdmin的设定
                config.LoginAsAdmin = config.DataBaseName == string.Empty;

                if (config.InputPasswordOnConnect && config.Password == string.Empty && GetPassword != null)
                {
                    config.Password = GetPassword(config.UserName);
                }

                if (!(string.IsNullOrEmpty(config.UserName) || string.IsNullOrEmpty(config.Password)))
                {
                    //认证的设定:注意，这里的密码是明文
                    //3.0开始默认SCRAM-SHA-1
                    if (config.AuthMechanism == ConstMgr.MONGODB_CR)
                    {
                        if (string.IsNullOrEmpty(config.DataBaseName))
                        {
                            mongoClientSetting.Credentials = new[] { MongoCredential.CreateMongoCRCredential(ConstMgr.DatabaseNameAdmin, config.UserName, config.Password) };
                        }
                        else
                        {
                            mongoClientSetting.Credentials = new[] { MongoCredential.CreateMongoCRCredential(config.DataBaseName, config.UserName, config.Password) };
                        }
                    }
                    if (config.AuthMechanism == ConstMgr.SCRAM_SHA_1)
                    {
                        if (string.IsNullOrEmpty(config.DataBaseName))
                        {
                            mongoClientSetting.Credentials = new[] { MongoCredential.CreateCredential(ConstMgr.DatabaseNameAdmin, config.UserName, config.Password) };
                        }
                        else
                        {
                            mongoClientSetting.Credentials = new[] { MongoCredential.CreateCredential(config.DataBaseName, config.UserName, config.Password) };
                        }
                    }
                }

                //X509
                if (!string.IsNullOrEmpty(config.UserName))
                {
                    if (config.AuthMechanism == ConstMgr.MONGODB_X509)
                    {
                        mongoClientSetting.Credentials = new[] { MongoCredential.CreateMongoX509Credential(config.UserName) };
                    }
                }

                //ReplSetName
                if (!string.IsNullOrEmpty(config.ReplSetName))
                {
                    mongoClientSetting.ReplicaSetName = config.ReplSetName;
                    config.ServerRole = MongoConnectionConfig.SvrRoleType.ReplsetSvr;
                }
                else
                {
                    config.ServerRole = MongoConnectionConfig.SvrRoleType.DataSvr;
                }
                if (config.ServerRole == MongoConnectionConfig.SvrRoleType.ReplsetSvr)
                {
                    //ReplsetName不是固有属性,可以设置，不过必须保持与配置文件的一致
                    mongoClientSetting.ConnectionMode = ConnectionMode.ReplicaSet;
                    //添加Replset服务器，注意，这里可能需要事先初始化副本
                    var replsetSvrList = new List<MongoServerAddress>();
                    foreach (var item in config.ReplsetList)
                    {
                        //如果这里的服务器在启动的时候没有--Replset参数，将会出错，当然作为单体的服务器，启动是没有任何问题的
                        MongoServerAddress replSrv;
                        if (item.Split(":".ToCharArray()).Length == 2)
                        {
                            replSrv = new MongoServerAddress(
                                item.Split(":".ToCharArray())[0],
                                Convert.ToInt16(item.Split(":".ToCharArray())[1]));
                        }
                        else
                        {
                            replSrv = new MongoServerAddress(item);
                        }
                        replsetSvrList.Add(replSrv);
                    }
                    mongoClientSetting.Servers = replsetSvrList;
                }
            }
            else
            {
                //使用MongoConnectionString建立连接
                mongoClientSetting = MongoClientSettings.FromUrl(MongoUrl.Create(config.ConnectionString));
            }
            //为了避免出现无法读取数据库结构的问题，将读权限都设置为Preferred
            if (Equals(mongoClientSetting.ReadPreference, ReadPreference.Primary))
            {
                mongoClientSetting.ReadPreference = ReadPreference.PrimaryPreferred;
            }
            if (Equals(mongoClientSetting.ReadPreference, ReadPreference.Secondary))
            {
                mongoClientSetting.ReadPreference = ReadPreference.SecondaryPreferred;
            }
            return mongoClientSetting;
        }

        #endregion

        #region"系统状态"

        /// <summary>
        ///     管理中服务器列表
        /// </summary>
        public static Dictionary<string, MongoServer> MongoConnSvrLst = new Dictionary<string, MongoServer>();

        /// <summary>
        ///     管理中客户端列表
        /// </summary>
        public static Dictionary<string, MongoClient> MongoConnClientLst = new Dictionary<string, MongoClient>();

        /// <summary>
        ///     管理中服务器实例列表
        /// </summary>
        public static Dictionary<string, MongoServerInstance> MongoInstanceLst =
            new Dictionary<string, MongoServerInstance>();

        /// <summary>
        ///     连接配置列表(管理用）
        /// </summary>
        public static Dictionary<string, MongoConnectionConfig> MongoConnectionConfigList =
            new Dictionary<string, MongoConnectionConfig>();

        /// <summary>
        ///     用户列表
        /// </summary>
        //public static Dictionary<string, EachDatabaseUser> MongoUserLst = new Dictionary<string, EachDatabaseUser>();

        /// <summary>
        ///     数据过滤器
        /// </summary>
        public static Dictionary<string, DataFilter> CollectionFilter = new Dictionary<string, DataFilter>();


        /// <summary>
        ///     获得当前服务器
        /// </summary>
        /// <returns></returns>
        public static MongoServer GetCurrentServer()
        {
            return GetMongoServerBySvrPath(SelectObjectTag, MongoConnSvrLst);
        }

        /// <summary>
        ///     获得当前客户端
        /// </summary>
        /// <returns></returns>
        public static MongoClient GetCurrentClient()
        {
            return GetMongoClientBySvrPath(SelectObjectTag, MongoConnClientLst);
        }

        /// <summary>
        ///     获得ServerKey
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentServerKey()
        {
            var strSvrPath = TagInfo.GetTagPath(SelectObjectTag);
            var strPath = strSvrPath.Split("/".ToCharArray());
            return strPath[0];
        }

        /// <summary>
        ///     移除Connection
        /// </summary>
        /// <param name="connectionName"></param>
        public static void RemoveConnectionConfig(string connectionName)
        {
            MongoConnSvrLst.Remove(connectionName);
            MongoConnClientLst.Remove(connectionName);
        }

        /// <summary>
        ///     获得当前数据库
        /// </summary>
        /// <returns></returns>
        public static MongoDatabase GetCurrentDataBase()
        {
            return GetMongoDBBySvrPath(SelectObjectTag, GetCurrentServer());
        }

        /// <summary>
        ///     当前IMongoDatabase
        /// </summary>
        /// <returns></returns>
        public static IMongoDatabase GetCurrentIMongoDataBase()
        {
            return GetIMongoDbBySvrPath(SelectObjectTag, GetCurrentClient());
        }

        /// <summary>
        ///     当前数据库名称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDataBaseName()
        {
            return GetMongoDBBySvrPath(SelectObjectTag, GetCurrentServer()).Name;
        }

        /// <summary>
        ///     获得当前数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentCollection()
        {
            return GetMongoCollectionBySvrPath(SelectObjectTag, GetCurrentDataBase());
        }

        /// <summary>
        ///     获得当前数据集信息
        /// </summary>
        /// <returns></returns>
        public static BsonDocument GetCurrentCollectionInfo()
        {
            return ConnectionInfo.GetCollectionInfo(GetCurrentClient(), GetCurrentDataBaseName(), GetCurrentCollectionName());
        }

        /// <summary>
        ///     设定当前数据集
        /// </summary>
        /// <param name="CollectionName"></param>
        public static void SetCurrentCollection(string CollectionName)
        {
            var t = SelectObjectTag.Split("/".ToCharArray());
            if (t.Length == 3)
            {
                SelectObjectTag += "/" + CollectionName;
            }
            else
            {
                t[3] = CollectionName;
                SelectObjectTag = string.Join("/", t);
            }
        }

        /// <summary>
        ///     获得当前数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentJavaScript()
        {
            return GetMongoJavaScript(GetCurrentDataBase());
        }

        /// <summary>
        ///     当前数据集是否为Capped
        /// </summary>
        /// <returns></returns>
        public static bool GetCurrentCollectionIsCapped()
        {
            return GetMongoCollectionBySvrPath(SelectObjectTag, GetCurrentDataBase()).GetStats().IsCapped;
        }

        /// <summary>
        ///     获得当前数据集名称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCollectionName()
        {
            return GetMongoCollectionBySvrPath(SelectObjectTag, GetCurrentDataBase()).Name;
        }

        /// <summary>
        ///     获得当前数据集全称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentCollectionFullName()
        {
            return GetMongoCollectionBySvrPath(SelectObjectTag, GetCurrentDataBase()).FullName;
        }

        /// <summary>
        ///     获得当前数据库View名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCurrentDBViewNameList()
        {
            var Database = GetCurrentDataBase();
            var ViewList = new List<string>();
            if (Database.CollectionExists(ConstMgr.CollectionNameSystemViews))
            {
                var Col = Database.GetCollection(ConstMgr.CollectionNameSystemViews);
                ViewList = Col.FindAll().ToList().Select(x =>
                {
                    var id = x.GetElement(ConstMgr.KeyId).Value.ToString();
                    return id.Substring(id.IndexOf(".") + 1);
                }).ToList();
            }
            return ViewList;
        }

        /// <summary>
        ///     获得当前服务器配置
        /// </summary>
        /// <returns></returns>
        public static MongoConnectionConfig GetCurrentServerConfig()
        {
            var serverName = SelectObjectTag.Split(":".ToCharArray())[1];
            serverName = serverName.Split("/".ToCharArray())[(int)EnumMgr.PathLevel.Connection];
            var rtnMongoConnectionConfig = new MongoConnectionConfig();
            if (MongoConnectionConfigList.ContainsKey(serverName))
            {
                rtnMongoConnectionConfig = MongoConnectionConfigList[serverName];
            }
            return rtnMongoConnectionConfig;
        }

        /// <summary>
        ///     Current selected document
        /// </summary>
        public static BsonDocument CurrentDocument;

        /// <summary>
        ///     系统当前连接状态
        /// </summary>
        public static MongoConnectionConfig CurrentMongoConnectionconfig;

        /// <summary>
        ///     选择对象标签
        /// </summary>
        public static string SelectObjectTag = string.Empty;

        /// <summary>
        ///     获得当前对象的种类
        /// </summary>
        public static string SelectTagType
        {
            get { return TagInfo.GetTagType(SelectObjectTag); }
        }

        /// <summary>
        ///     获得当前对象的路径
        /// </summary>
        public static string SelectTagData
        {
            get { return TagInfo.GetTagPath(SelectObjectTag); }
        }

        #endregion

        #region"辅助方法： GetObjBySrvPath"

        /// <summary>
        ///     根据路径字符获得服务器
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <returns></returns>
        /// <param name="mongoConnSvrLst"></param>
        public static MongoServer GetMongoServerBySvrPath(string strObjTag,
            Dictionary<string, MongoServer> mongoConnSvrLst)
        {
            var strSvrPath = TagInfo.GetTagPath(strObjTag);
            var strPath = strSvrPath.Split("/".ToCharArray());
            if (strPath.Length == 1)
            {
                //[Tag:Connection
                if (mongoConnSvrLst.ContainsKey(strPath[0]))
                {
                    return mongoConnSvrLst[strPath[0]];
                }
            }
            if (strPath.Length > (int)EnumMgr.PathLevel.Instance)
            {
                if (strPath[0] == strPath[1])
                {
                    //[Tag:Connection/Connection/DBName/Collection]
                    return mongoConnSvrLst[strPath[0]];
                }
                //[Tag:Connection/Host@Port/DBName/Collection]
                var strInstKey = strPath[(int)EnumMgr.PathLevel.Connection] + "/" +
                                 strPath[(int)EnumMgr.PathLevel.Instance];
                if (MongoInstanceLst.ContainsKey(strInstKey))
                {
                    return mongoConnSvrLst[strPath[0]];
                }
            }
            return null;
        }

        /// <summary>
        ///     根据路径字符获得客户端
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <returns></returns>
        /// <param name="mongoConnSvrLst"></param>
        public static MongoClient GetMongoClientBySvrPath(string strObjTag,
            Dictionary<string, MongoClient> mongoConnSvrLst)
        {
            var strSvrPath = TagInfo.GetTagPath(strObjTag);
            var strPath = strSvrPath.Split("/".ToCharArray());
            if (strPath.Length == 1)
            {
                //[Tag:Connection
                if (mongoConnSvrLst.ContainsKey(strPath[0]))
                {
                    return mongoConnSvrLst[strPath[0]];
                }
            }
            if (strPath.Length > (int)EnumMgr.PathLevel.Instance)
            {
                if (strPath[0] == strPath[1])
                {
                    //[Tag:Connection/Connection/DBName/Collection]
                    return mongoConnSvrLst[strPath[0]];
                }
                //[Tag:Connection/Host@Port/DBName/Collection]
                var strInstKey = strPath[(int)EnumMgr.PathLevel.Connection] + "/" +
                                 strPath[(int)EnumMgr.PathLevel.Instance];
                if (MongoInstanceLst.ContainsKey(strInstKey))
                {
                    return mongoConnSvrLst[strPath[0]];
                }
            }
            return null;
        }

        /// <summary>
        ///     根据路径字符获得数据库
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <param name="mongoSvr"></param>
        /// <returns></returns>
        public static MongoDatabase GetMongoDBBySvrPath(string strObjTag, MongoServer mongoSvr)
        {
            MongoDatabase rtnMongoDb = null;
            if (mongoSvr != null)
            {
                var strSvrPath = TagInfo.GetTagPath(strObjTag);
                var strPathArray = strSvrPath.Split("/".ToCharArray());
                if (strPathArray.Length > (int)EnumMgr.PathLevel.Database)
                {
                    rtnMongoDb = mongoSvr.GetDatabase(strPathArray[(int)EnumMgr.PathLevel.Database]);
                }
            }
            return rtnMongoDb;
        }

        /// <summary>
        ///     根据路径字符获得IMongoDatabase
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="mongoClient"></param>
        /// <returns></returns>
        public static IMongoDatabase GetIMongoDbBySvrPath(string strObjTag, MongoClient mongoClient)
        {
            IMongoDatabase rtnMongoDb = null;
            if (mongoClient != null)
            {
                var strSvrPath = TagInfo.GetTagPath(strObjTag);
                var strPathArray = strSvrPath.Split("/".ToCharArray());
                if (strPathArray.Length > (int)EnumMgr.PathLevel.Database)
                {
                    rtnMongoDb = mongoClient.GetDatabase(strPathArray[(int)EnumMgr.PathLevel.Database]);
                }
            }
            return rtnMongoDb;
        }

        /// <summary>
        ///     根据路径字符获得数据库
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="mongoSvr"></param>
        /// <returns></returns>
        public static IMongoDatabase GetMongoDBBySvrPath(string strObjTag, MongoClient mongoSvr)
        {
            IMongoDatabase rtnMongoDb = null;
            if (mongoSvr != null)
            {
                var strSvrPath = TagInfo.GetTagPath(strObjTag);
                var strPathArray = strSvrPath.Split("/".ToCharArray());
                if (strPathArray.Length > (int)EnumMgr.PathLevel.Database)
                {
                    rtnMongoDb = mongoSvr.GetDatabase(strPathArray[(int)EnumMgr.PathLevel.Database]);
                }
            }
            return rtnMongoDb;
        }

        /// <summary>
        ///     通过路径获得数据集
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static MongoCollection GetMongoCollectionBySvrPath(string strObjTag, MongoDatabase mongoDb)
        {
            MongoCollection rtnMongoCollection = null;
            if (mongoDb != null)
            {
                var strSvrPath = TagInfo.GetTagPath(strObjTag);
                var strPathArray = strSvrPath.Split("/".ToCharArray());
                if (strPathArray.Length > (int)EnumMgr.PathLevel.CollectionAndView)
                {
                    rtnMongoCollection = mongoDb.GetCollection(strPathArray[(int)EnumMgr.PathLevel.CollectionAndView]);
                }
            }
            return rtnMongoCollection;
        }

        /// <summary>
        ///     获得JavaScript数据集
        /// </summary>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static MongoCollection GetMongoJavaScript(MongoDatabase mongoDb)
        {
            MongoCollection rtnMongoCollection = null;
            if (mongoDb != null)
            {
                rtnMongoCollection = mongoDb.GetCollection("system.js");
            }
            return rtnMongoCollection;
        }

        /// <summary>
        ///     通过路径获得数据集
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static IMongoCollection<BsonDocument> GetMongoCollectionBySvrPath(string strObjTag,
            IMongoDatabase mongoDb)
        {
            IMongoCollection<BsonDocument> rtnMongoCollection = null;
            if (mongoDb != null)
            {
                var strSvrPath = TagInfo.GetTagPath(strObjTag);
                var strPathArray = strSvrPath.Split("/".ToCharArray());
                if (strPathArray.Length > (int)EnumMgr.PathLevel.CollectionAndView)
                {
                    rtnMongoCollection =
                        mongoDb.GetCollection<BsonDocument>(strPathArray[(int)EnumMgr.PathLevel.CollectionAndView]);
                }
            }
            return rtnMongoCollection;
        }

        /// <summary>
        ///     根据服务器名称获取配置
        /// </summary>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        public static MongoConnectionConfig GetServerConfigBySvrPath(string mongoSvrKey)
        {
            var rtnMongoConnectionConfig = new MongoConnectionConfig();
            if (MongoConnectionConfigList.ContainsKey(mongoSvrKey))
            {
                rtnMongoConnectionConfig = MongoConnectionConfigList[mongoSvrKey];
            }
            return rtnMongoConnectionConfig;
        }

        /// <summary>
        ///     更新连接参数列表
        /// </summary>
        /// <param name="configLst"></param>
        /// <returns></returns>
        public static void ResetConnectionList(List<MongoConnectionConfig> configLst)
        {
            for (var i = 0; i < configLst.Count; i++)
            {
                var config = configLst[i];
                //Client
                if (MongoConnClientLst.ContainsKey(config.ConnectionName))
                {
                    MongoConnClientLst.Remove(config.ConnectionName);
                }
                var client = CreateMongoClient(ref config);
                MongoConnClientLst.Add(config.ConnectionName, client);
                //Legacy Server
                if (MongoConnSvrLst.ContainsKey(config.ConnectionName))
                {
                    MongoConnSvrLst.Remove(config.ConnectionName);
                }
                MongoConnSvrLst.Add(config.ConnectionName, client.GetServer());
            }
        }

        /// <summary>
        ///     通过连接名称获得Host信息
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static MongoServerAddress GetMongoSvrAddrByConnectionName(string connectionName)
        {
            MongoServerAddress mongosrvAddr = null;
            if (MongoConnectionConfigList.ContainsKey(connectionName))
            {
                mongosrvAddr = new MongoServerAddress(MongoConnectionConfigList[connectionName].Host,
                    MongoConnectionConfigList[connectionName].Port);
            }
            return mongosrvAddr;
        }

        #endregion
    }
}