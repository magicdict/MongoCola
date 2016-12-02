using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using static MongoUtility.Command.CommandExecute;

namespace MongoUtility.Command
{

    /// <summary>
    ///     DataBase Command
    /// </summary>
    public static class DataBaseCommand
    {
        #region Aggregate

        /// <summary>
        ///     Compact
        /// </summary>
        /// <see cref="http://www.mongodb.org/display/DOCS/Compact+Command" />
        public static MongoCommand CompactCommand = new MongoCommand("compact", EnumMgr.PathLevel.CollectionAndView);

        /// <summary>
        ///     执行聚合
        /// </summary>
        /// <param name="aggregateDoc"></param>
        /// <returns></returns>
        /// <param name="collectionName"></param>
        public static CommandResult Aggregate(BsonArray aggregateDoc, string collectionName)
        {
            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            var aggrCmd = new CommandDocument
                {
                    new BsonElement("aggregate", new BsonString(collectionName)),
                    new BsonElement("pipeline", aggregateDoc)
                };
            var aggregateCommand = new MongoCommand(aggrCmd, EnumMgr.PathLevel.Database);
            return ExecuteMongoCommand(aggregateCommand);
        }
        /// <summary>
        ///     执行聚合（指定路劲）
        /// </summary>
        /// <param name="aggregateDoc"></param>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static CommandResult Aggregate(BsonArray aggregateDoc, string databaseName, string collectionName)
        {
            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            var aggrCmd = new CommandDocument
                {
                    new BsonElement("aggregate", new BsonString(collectionName)),
                    new BsonElement("pipeline", aggregateDoc)
                };
            var aggregateCommand = new MongoCommand(aggrCmd, EnumMgr.PathLevel.Database, databaseName);
            return ExecuteMongoCommand(aggregateCommand);
        }
        /// <summary>
        ///     执行Count（指定路劲）
        /// </summary>
        /// <param name="QueryDoc"></param>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static CommandResult Count(BsonDocument QueryDoc, string databaseName, string collectionName)
        {
            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            var aggrCmd = new CommandDocument
                {
                    new BsonElement("count", new BsonString(collectionName)),
                    new BsonElement("query", QueryDoc)
                };
            var aggregateCommand = new MongoCommand(aggrCmd, EnumMgr.PathLevel.Database, databaseName);
            return ExecuteMongoCommand(aggregateCommand);
        }

        #endregion

        #region Replset

        /// <summary>
        ///     副本状态
        ///     http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        /// </summary>
        public static MongoCommand ReplSetGetStatusCommand = new MongoCommand("replSetGetStatus", EnumMgr.PathLevel.Instance);

        /// <summary>
        ///     重新启动
        /// </summary>
        /// <param name="primarySvr">副本组主服务器</param>
        /// <param name="config">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult ReconfigReplsetServer(MongoServer primarySvr, BsonDocument config, Boolean force = false)
        {
            var mongoCmd = new CommandDocument { { "replSetReconfig", config } };
            mongoCmd.Add("force", force);
            return ExecuteMongoSvrCommand(mongoCmd, primarySvr);
        }

        /// <summary>
        ///     初始化副本（Mongo Shell）
        /// </summary>
        /// <returns></returns>
        public static CommandResult InitReplicaSet()
        {
            //使用local数据库发送 rs.initiate() 指令
            MongoDatabase mongoDb = RuntimeMongoDbContext.GetCurrentClient().GetServer().GetDatabase("local");
            var args = new EvalArgs { Code = "rs.initiate()" };
            var result = mongoDb.Eval(args);
            return new CommandResult(result.AsBsonDocument);
        }

        /// <summary>
        ///     初始化副本（数据库版本 - 废止）
        /// </summary>
        /// <param name="replicaSetName">副本名称</param>
        /// <param name="hostList">从属服务器列表</param>
        /// <param name="configs"></param>
        public static CommandResult InitReplicaSet(string replicaSetName, string hostList,
            Dictionary<string, MongoConnectionConfig> configs)
        {
            //第一台服务器作为Primary服务器
            var primarySetting = new MongoClientSettings
            {
                Server = new MongoServerAddress(configs[hostList].Host,
                    configs[hostList].Port),
                ReadPreference = ReadPreference.PrimaryPreferred
            };
            //如果不设置的话，会有错误：不是Primary服务器，SlaveOK 是 False

            var primarySvr = new MongoClient(primarySetting).GetServer();
            var config = new BsonDocument();
            var hosts = new BsonArray();
            var replSetInitiateCmd = new BsonDocument();
            var host = new BsonDocument();
            //生成命令
            host = new BsonDocument
            {
                {ConstMgr.KeyId, 1},
                {
                    "host", configs[hostList].Host + ":" + configs[hostList].Port
                }
            };
            hosts.Add(host);
            config.Add(ConstMgr.KeyId, replicaSetName);
            config.Add("members", hosts);
            replSetInitiateCmd.Add("replSetInitiate", config);

            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(replSetInitiateCmd);
            return ExecuteMongoSvrCommand(mongoCmd, primarySvr);
        }

        #endregion

        #region Sharding
        //从MongoDB3.4开始，使用Zone来代替Tag了

        /// <summary>
        ///     增加数据分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="replicaSetName"></param>
        /// <param name="lstAddress"></param>
        /// <remarks>注意：有个命令可能只能用在mongos上面</remarks>
        /// <returns></returns>
        public static CommandResult AddSharding(MongoServer routeSvr, string replicaSetName, List<string> lstAddress,
            string name, decimal maxSize)
        {
            // replset/host:port,host:port
            var cmdPara = replicaSetName == string.Empty ? string.Empty : replicaSetName + "/";
            foreach (var item in lstAddress)
            {
                cmdPara += item + ",";
            }
            cmdPara = cmdPara.TrimEnd(",".ToCharArray());
            var mongoCmd = new CommandDocument { { "addshard", cmdPara } };
            if (maxSize != 0)
            {
                mongoCmd.Add("maxSize", maxSize);
            }
            if (name != string.Empty)
            {
                mongoCmd.Add("name", name);
            }

            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }


        /// <summary>
        ///     AddShardToZone
        /// </summary>
        /// <param name="routeSvr">服务器</param>
        /// <param name="shardName">Shard名称</param>
        /// <param name="tagName">Tag名称</param>
        /// <returns></returns>
        public static CommandResult AddShardToZone(MongoServer routeSvr, string shardName, string zone)
        {
            var mongoCmd = new CommandDocument { { "addShardToZone", shardName } };
            mongoCmd.Add("zone", zone);
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }


        /// <summary>
        ///     AddTagRange
        /// </summary>
        /// <param name="routeSvr">路由服务器</param>
        /// <param name="nameSpace">名字空间</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="tag">标签</param>
        /// <returns></returns>
        public static CommandResult updateZoneKeyRange(MongoServer routeSvr, string nameSpace, string FieldName, BsonValue min, BsonValue max, string zone)
        {
            var mongoCmd = new CommandDocument { { "updateZoneKeyRange", nameSpace } };
            mongoCmd.Add("min", new BsonDocument(FieldName, min));
            mongoCmd.Add("max", new BsonDocument(FieldName, max));
            mongoCmd.Add("zone", zone);
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     移除Shard
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="shardName">Shard名称</param>
        /// <returns></returns>
        public static CommandResult RemoveSharding(MongoServer routeSvr, string shardName)
        {
            var mongoCmd = new CommandDocument { { "removeshard", shardName } };
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     数据库分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="shardingDb"></param>
        /// <returns></returns>
        public static CommandResult EnableSharding(MongoServer routeSvr, string shardingDb)
        {
            var mongoCmd = new CommandDocument();
            mongoCmd = new CommandDocument { { "enablesharding", shardingDb } };
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     数据集分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="sharingCollection"></param>
        /// <param name="shardingKey"></param>
        /// <returns></returns>
        public static CommandResult ShardCollection(MongoServer routeSvr, string sharingCollection,
            BsonDocument shardingKey)
        {
            var mongoCmd = new CommandDocument { { "shardCollection", sharingCollection }, { "key", shardingKey } };
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        #endregion

        #region Administrator

        // 数据库命令 http://www.mongodb.org/display/DOCS/List+of+Database+Commands
        // 修复数据库 http://www.mongodb.org/display/DOCS/Durability+and+Repair
        // convertToCapped https://docs.mongodb.com/master/reference/command/convertToCapped/

        /// <summary>
        ///     修复数据库
        /// </summary>
        public static MongoCommand RepairDatabaseCommand = new MongoCommand("repairDatabase", EnumMgr.PathLevel.Database);

        /// <summary>
        ///     convertToCapped
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static CommandResult convertToCapped(string collectionName, long size, MongoDatabase db)
        {
            var mongoCmd = new CommandDocument { { "convertToCapped", collectionName } };
            mongoCmd.Add("size", size);
            return ExecuteMongoDBCommand(mongoCmd, db);
        }

        #endregion

        #region  User & Role & Diagnostic
        /// <summary>
        ///     新建用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static CommandResult createUser(MongoUserEx user, MongoDatabase db)
        {
            var mongoCmd = new CommandDocument { { "createUser", user.Username } };
            mongoCmd.Add("pwd", user.Password);
            var roles = new BsonArray();
            roles.AddRange(user.Roles.Select(x => x.AsBsonValue()));
            mongoCmd.Add("roles", roles);
            if (user.customData != null)
            {
                mongoCmd.Add("customData", user.customData);
            }
            return ExecuteMongoDBCommand(mongoCmd, db);
        }

        /// <summary>
        ///     修改用户（完全替换）
        /// </summary>
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static CommandResult updateUser(MongoUserEx user, MongoDatabase db)
        {
            var mongoCmd = new CommandDocument { { "updateUser", user.Username } };
            mongoCmd.Add("pwd", user.Password);
            var roles = new BsonArray();
            roles.AddRange(user.Roles.Select(x => x.AsBsonValue()));
            mongoCmd.Add("roles", roles);
            if (user.customData != null)
            {
                mongoCmd.Add("customData", user.customData);
            }
            return ExecuteMongoDBCommand(mongoCmd, db);
        }

        /// <summary>
        ///     添加自定义角色
        /// </summary>
        public static CommandResult createRole(MongoDatabase mongoDb, Role role)
        {
            var mongoCmd = new CommandDocument("createRole", role.Rolename);
            var privileges = new BsonArray();
            privileges.AddRange(role.Privileges.Select(x => x.AsBsonDocument()));
            mongoCmd.Add("privileges", privileges);
            var roles = new BsonArray();
            roles.AddRange(role.Roles.Select(x => x.AsBsonValue()));
            mongoCmd.Add("roles", roles);
            return ExecuteMongoDBCommand(mongoCmd, mongoDb);
        }

        /// <summary>
        ///     服务器状态
        ///     [OLD]http://www.mongodb.org/display/DOCS/serverStatus+Command
        ///     [NEW]https://docs.mongodb.com/manual/reference/command/serverStatus/
        /// </summary>
        public static MongoCommand ServerStatusCommand = new MongoCommand("serverStatus", EnumMgr.PathLevel.Instance);

        #endregion
    }
}