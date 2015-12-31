using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Command
{
    public static partial class Operater
    {
        public static bool InitReplicaSet(string replSetName, ref string strMessage)
        {
            var result = CommandHelper.InitReplicaSet(replSetName,
                RuntimeMongoDbContext.GetCurrentServerConfig().ConnectionName,
                MongoConnectionConfig.MongoConfig.ConnectionList);
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
                return true;
            }
            strMessage = result.ErrorMessage;
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="newConfig"></param>
        public static void ReplicaSet(MongoConnectionConfig newConfig)
        {
            MongoConnectionConfig.MongoConfig.ConnectionList[newConfig.ConnectionName] = newConfig;
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
            RuntimeMongoDbContext.MongoConnSvrLst.Remove(newConfig.ConnectionName);
            RuntimeMongoDbContext.MongoConnSvrLst.Add(
                RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName,
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
        /// </summary>
        public static void ResyncCommand()
        {
            CommandHelper.ExecuteMongoCommand(CommandHelper.ResyncCommand);
        }

        /// <summary>
        /// </summary>
        public static void Compact()
        {
            CommandHelper.ExecuteMongoCommand(CommandHelper.CompactCommand);
        }

        public static BsonDocument Validate(bool isFull)
        {
            BsonDocument result;
            var textSearchOption = new BsonDocument().Add(new BsonElement("full", isFull.ToString()));
            var searchResult = CommandHelper.ExecuteMongoColCommand("validate",
                RuntimeMongoDbContext.GetCurrentCollection(), textSearchOption);
            result = searchResult.Response;
            return result;
        }
    }
}