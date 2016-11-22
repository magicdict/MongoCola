using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MongoUtility.Command
{
    /// 注意，有些db.XXXX(xxx) 这样的函数需要 mongoDb.Eval方法才能做
    /// 有些RepairDatabase 这样的函数可以简单的执行
    /// <summary>
    /// </summary>
    public static partial class CommandHelper
    {
        //查看命令方法：http://localhost:29018/_commands
        //假设28018为端口号，同时使用 --rest 选项
        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands

        #region"Shell Command"

        /// 注意：有些命令可能只能用在mongos上面，例如addshard
        /// <summary>
        ///     使用Shell Helper命令
        /// </summary>
        /// <param name="jsShell"></param>
        /// <param name="mongoSvr"></param>
        /// <returns></returns>
        public static CommandResult ExecuteJsShell(string jsShell, MongoServer mongoSvr)
        {
            var shellCmd = new BsonDocument
            {
                {
                    "$eval",
                    new BsonJavaScript(jsShell)
                },
                {
                    "nolock",
                    true
                }
            };
            //必须nolock
            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(shellCmd);
            return ExecuteMongoSvrCommand(mongoCmd, mongoSvr);
        }

        /// <summary>
        ///     Js Shell 的结果判定
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsShellOk(CommandResult result)
        {
            if (!result.Response.ToBsonDocument().GetElement("retval").Value.IsBsonDocument)
            {
                return true;
            }
            return
                result.Response.ToBsonDocument()
                    .GetElement("retval")
                    .Value.AsBsonDocument.GetElement("ok")
                    .Value.ToString() == "1";
        }

        #endregion

        #region"Collection Command"

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

        #region"Replset Command"

        //Replica Set Commands
        //[OLD]http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        //[NEW]https://docs.mongodb.com/manual/reference/replication/
        //rs.help()                       show help
        //rs.status()                     { replSetGetStatus : 1 }
        //rs.initiate()                   { replSetInitiate : null } initiate
        //                                    with default settings
        //rs.initiate(cfg)                { replSetInitiate : cfg }
        //rs.add(hostportstr)             add a new member to the set
        //rs.add(membercfgobj)            add a new member to the set
        //rs.addArb(hostportstr)          add a new member which is arbiterOnly:true
        //rs.remove(hostportstr)          remove a member (primary, secondary, or arbiter) from the set
        //rs.stepDown()                   { replSetStepDown : true }
        //rs.conf()                       return configuration from local.system.replset
        //db.isMaster()                   check who is primary

        /// <summary>
        ///     服务器状态
        ///     [OLD]http://www.mongodb.org/display/DOCS/serverStatus+Command
        ///     [NEW]https://docs.mongodb.com/manual/reference/command/serverStatus/
        /// </summary>
        public static MongoCommand ServerStatusCommand = new MongoCommand("serverStatus", EnumMgr.PathLevel.Instance);

        /// <summary>
        ///     副本状态
        ///     http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        /// </summary>
        public static MongoCommand ReplSetGetStatusCommand = new MongoCommand("replSetGetStatus", EnumMgr.PathLevel.Instance);

        /// <summary>
        ///     Slave强制同步（废止）
        ///     http://www.mongodb.org/display/DOCS/Master+Slave
        /// </summary>
        [Obsolete("Deprecated since version 3.2: MongoDB 3.2 deprecates the use of master-slave replication for components of sharded clusters.")]
        public static MongoCommand ResyncCommand = new MongoCommand("resync", EnumMgr.PathLevel.Instance);

        /// <summary>
        ///     增加服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="hostPort">服务器信息</param>
        /// <param name="isArb">是否为仲裁服务器</param>
        /// <returns></returns>
        public static CommandResult AddToReplsetServer(MongoServer mongoSvr, string hostPort, int priority,
            bool isArb)
        {
            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                if (!isArb)
                {
                    var code = "rs.add({_id:" + (mongoSvr.Instances.Length + 1) + ",host:'" + hostPort + "',priority:" + priority + "});";
                    mCommandResult = ExecuteJsShell(code, mongoSvr);
                }
                else
                {
                    //其实addArb最后也只是调用了add方法
                    mCommandResult = ExecuteJsShell("rs.addArb('" + hostPort + "');", mongoSvr);
                }
            }
            catch (EndOfStreamException)
            {
            }
            return mCommandResult;
        }

        /// <summary>
        ///     删除服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="hostPort">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult RemoveFromReplsetServer(MongoServer mongoSvr, string hostPort)
        {
            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                ExecuteJsShell("rs.remove('" + hostPort + "');", mongoSvr);
            }
            catch (EndOfStreamException)
            {

            }
            return mCommandResult;
        }

        /// <summary>
        ///     重新启动
        /// </summary>
        /// <param name="primarySvr">副本组主服务器</param>
        /// <param name="config">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult ReconfigReplsetServer(MongoServer primarySvr, BsonDocument config)
        {
            var cmdRtn = new CommandResult(new BsonDocument());
            try
            {
                return ExecuteJsShell("rs.reconfig(" + config + ",{force : true})", primarySvr);
            }
            catch (EndOfStreamException)
            {

            }
            return cmdRtn;
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
        ///     增加分片Tag
        /// </summary>
        /// <param name="routeSvr">服务器</param>
        /// <param name="shardName">Shard名称</param>
        /// <param name="tagName">Tag名称</param>
        /// <returns></returns>
        [Obsolete("MongoDB 3.4 introduces Zones, which supersedes tag-aware sharding available in earlier versions.")]
        public static CommandResult AddShardTag(MongoServer routeSvr, string shardName, string tagName)
        {
            return ExecuteJsShell("sh.addShardTag('" + shardName + "', '" + tagName + "')", routeSvr);
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


        //https://docs.mongodb.com/master/reference/replication/
        //Mongo Shell进行初始化副本


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

        #region"DataBase Command"

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

        #endregion
    }
}