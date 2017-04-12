using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using System.Collections.Generic;
using System.Linq;

namespace MongoUtility.Command
{
    public static partial class Operater
    {
        /// <summary>
        ///     初始化副本
        /// </summary>
        /// <param name="replSetName"></param>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public static bool InitReplicaSet(string replSetName, ref string strMessage)
        {
            //注意：这里的replSetName名称只是为了设定本工具用的MongoConfig信息，
            //实际的replSetName名称应该在启动命令中
            var result = DataBaseCommand.InitReplicaSet();
            if (result.Ok)
            {
                //修改配置
                var newConfig = RuntimeMongoDbContext.GetCurrentServerConfig();
                newConfig.ReplSetName = replSetName;
                newConfig.ReplsetList = new List<string>
                {
                    newConfig.Host +
                    (newConfig.Port != 0 ? ":" + newConfig.Port : string.Empty)
                };
                MongoConnectionConfig.MongoConfig.ConnectionList[newConfig.ConnectionName] = newConfig;
                MongoConnectionConfig.MongoConfig.SaveMongoConfig();
                RuntimeMongoDbContext.MongoConnSvrLst.Remove(newConfig.ConnectionName);
                RuntimeMongoDbContext.MongoConnSvrLst.Add(
                    RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName,
                    RuntimeMongoDbContext.CreateMongoServer(ref newConfig));
                strMessage = result.Response.ToJson(MongoHelper.JsonWriterSettings);
                return true;
            }
            strMessage = result.ErrorMessage;
            return false;
        }

 
        /// <summary>
        ///     刷新配置文件副本状态
        /// </summary>
        /// <param name="newConfig"></param>
        public static void RefreshConnectionConfig(MongoConnectionConfig newConfig)
        {
            MongoConnectionConfig.MongoConfig.ConnectionList[newConfig.ConnectionName] = newConfig;
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
            RuntimeMongoDbContext.MongoConnSvrLst.Remove(newConfig.ConnectionName);
            RuntimeMongoDbContext.MongoConnSvrLst.Add(RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName,
                RuntimeMongoDbContext.CreateMongoServer(ref newConfig));
        }

        /// <summary>
        ///     获得Shard情报
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetShardInfo(MongoServer server, string key)
        {
            var shardInfo = new Dictionary<string, string>();
            if (!server.DatabaseExists(ConstMgr.DatabaseNameConfig)) return shardInfo;
            var configdb = server.GetDatabase(ConstMgr.DatabaseNameConfig);
            if (!configdb.CollectionExists("shards")) return shardInfo;
            foreach (var item in configdb.GetCollection("shards").FindAll().ToList())
            {
                shardInfo.Add(item.GetElement(ConstMgr.KeyId).Value.ToString(),
                    item.GetElement(key).Value.ToString());
            }
            return shardInfo;
        }

        /// <summary>
        ///     压缩
        /// </summary>
        public static void Compact()
        {
            CommandExecute.ExecuteMongoCommand(DataBaseCommand.CompactCommand);
        }

        /// <summary>
        ///     验证
        /// </summary>
        /// <param name="isFull"></param>
        /// <returns></returns>
        public static BsonDocument Validate(bool isFull)
        {
            BsonDocument result;
            var textSearchOption = new BsonDocument().Add(new BsonElement("full", isFull.ToString()));
            var searchResult = CommandExecute.ExecuteMongoColCommand("validate",
                RuntimeMongoDbContext.GetCurrentCollection(), textSearchOption);
            result = searchResult.Response;
            return result;
        }
    }
}