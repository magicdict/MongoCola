using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"Collection Command"

        /// <summary>
        ///     Compact
        /// </summary>
        /// <see cref="http://www.mongodb.org/display/DOCS/Compact+Command" />
        public static MongoCommand Compact_Command = new MongoCommand("compact", PathLv.CollectionLV);

        /// <summary>
        ///     执行聚合
        /// </summary>
        /// <param name="AggregateDoc"></param>
        /// <returns></returns>
        public static CommandResult Aggregate(BsonArray AggregateDoc)
        {
            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            try
            {
                var agg = new CommandDocument
                {
                    new BsonElement("aggregate", new BsonString(SystemManager.GetCurrentCollection().Name)),
                    new BsonElement("pipeline", AggregateDoc)
                };
                var Aggregate_Command = new MongoCommand(agg, PathLv.DatabaseLV);
                return ExecuteMongoCommand(Aggregate_Command, false);
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
                return new CommandResult(new BsonDocument());
            }
        }

        #endregion

        #region"DataBase Command"

        /// 数据库命令 http://www.mongodb.org/display/DOCS/List+of+Database+Commands
        /// <summary>
        ///     修复数据库
        ///     http://www.mongodb.org/display/DOCS/Durability+and+Repair
        /// </summary>
        public static MongoCommand repairDatabase_Command = new MongoCommand("repairDatabase", PathLv.DatabaseLV);

        #endregion

        #region"Server Command"

        //Replica Set Commands
        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands
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
        ///     http://www.mongodb.org/display/DOCS/serverStatus+Command
        /// </summary>
        public static MongoCommand serverStatus_Command = new MongoCommand("serverStatus", PathLv.InstanceLV);

        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        /// <summary>
        ///     副本状态
        /// </summary>
        public static MongoCommand replSetGetStatus_Command = new MongoCommand("replSetGetStatus", PathLv.InstanceLV);

        //http://www.mongodb.org/display/DOCS/Master+Slave
        /// <summary>
        ///     Slave强制同步
        /// </summary>
        public static MongoCommand resync_Command = new MongoCommand("resync", PathLv.InstanceLV);

        /// <summary>
        ///     增加服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <param name="IsArb">是否为仲裁服务器</param>
        /// <returns></returns>
        public static CommandResult AddToReplsetServer(MongoServer mongoSvr, String HostPort, int priority,
            Boolean IsArb)
        {
            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                if (!IsArb)
                {
                    mCommandResult =
                        ExecuteJsShell(
                            "rs.add({_id:" + mongoSvr.Instances.Length + 1 + ",host:'" + HostPort + "',priority:" +
                            priority + "});", mongoSvr);
                }
                else
                {
                    //其实addArb最后也只是调用了add方法
                    mCommandResult = ExecuteJsShell("rs.addArb('" + HostPort + "');", mongoSvr);
                }
            }
            catch (EndOfStreamException)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mCommandResult;
        }

        /// <summary>
        ///     删除服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult RemoveFromReplsetServer(MongoServer mongoSvr, String HostPort)
        {
            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                ExecuteJsShell("rs.remove('" + HostPort + "');", mongoSvr);
            }
            catch (EndOfStreamException)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mCommandResult;
        }

        /// <summary>
        ///     重新启动
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult ReconfigReplsetServer(MongoServer PrimarySvr, BsonDocument config)
        {
            var cmdRtn = new CommandResult(new BsonDocument());
            try
            {
                return ExecuteJsShell("rs.reconfig(" + config + ",{force : true})", PrimarySvr);
            }
            catch (EndOfStreamException)
            {
            }
            return cmdRtn;
        }

        /// <summary>
        ///     增加数据分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="replicaSetName"></param>
        /// <param name="lstAddress"></param>
        /// <remarks>注意：有个命令可能只能用在mongos上面</remarks>
        /// <returns></returns>
        public static CommandResult AddSharding(MongoServer routeSvr, String replicaSetName, List<String> lstAddress,
            String Name, Decimal MaxSize)
        {
            // replset/host:port,host:port
            String cmdPara = replicaSetName == String.Empty ? String.Empty : (replicaSetName + "/");
            foreach (String item in lstAddress)
            {
                cmdPara += item + ",";
            }
            cmdPara = cmdPara.TrimEnd(",".ToCharArray());
            var mongoCmd = new CommandDocument {{"addshard", cmdPara}};
            if (MaxSize != 0)
            {
                mongoCmd.Add("maxSize", (BsonValue) MaxSize);
            }
            if (Name != String.Empty)
            {
                mongoCmd.Add("name", Name);
            }

            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     增加分片Tag
        /// </summary>
        /// <param name="routeSvr">服务器</param>
        /// <param name="ShardName">Shard名称</param>
        /// <param name="TagName">Tag名称</param>
        /// <returns></returns>
        public static CommandResult AddShardTag(MongoServer routeSvr, String ShardName, String TagName)
        {
            //mongos> sh.addShardTag
            //function (shard, tag) {
            //    var config = db.getSisterDB("config");
            //    if (config.shards.findOne({_id:shard}) == null) {
            //        throw "can't find a shard with name: " + shard;
            //    }
            //    config.shards.update({_id:shard}, {$addToSet:{tags:tag}});
            //    sh._checkLastError(config);
            //}
            var mongoCmd = new CommandDocument();
            return ExecuteJsShell("sh.addShardTag('" + ShardName + "', '" + TagName + "')", routeSvr);
        }

        /// <summary>
        ///     AddTagRange
        /// </summary>
        /// <param name="routeSvr">路由服务器</param>
        /// <param name="NameSpace">名字空间</param>
        /// <param name="Min">最小值</param>
        /// <param name="Max">最大值</param>
        /// <param name="Tag">标签</param>
        /// <returns></returns>
        public static CommandResult AddTagRange(MongoServer routeSvr, String NameSpace, BsonValue Min, BsonValue Max,
            String Tag)
        {
            //mongos> sh.addTagRange
            //function (ns, min, max, tag) {
            //    var config = db.getSisterDB("config");
            //    config.tags.update(
            //                       {_id:{ns:ns, min:min}},
            //                       {
            //                             _id:{ns:ns, min:min},
            //                             ns:ns,
            //                             min:min,
            //                             max:max, 
            //                             tag:tag
            //                       }, 
            //                       true
            //                       );
            //    sh._checkLastError(config);
            //}
            var mongoCmd = new CommandDocument();
            String MaxValue = String.Empty;
            String MinValue = String.Empty;
            if (Min.IsString)
            {
                MinValue = "'" + Min + "'";
            }
            if (Max.IsString)
            {
                MaxValue = "'" + Max + "'";
            }

            if (Min.IsNumeric)
            {
                MinValue = Min.ToString();
            }
            if (Max.IsNumeric)
            {
                MaxValue = Max.ToString();
            }
            return ExecuteJsShell(
                "sh.addTagRange('" + NameSpace + "'," + MinValue + "," + MaxValue + ",'" + Tag + "')", routeSvr);
        }

        /// <summary>
        ///     移除Shard
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="ShardName">Shard名称</param>
        /// <returns></returns>
        public static CommandResult RemoveSharding(MongoServer routeSvr, String ShardName)
        {
            var mongoCmd = new CommandDocument {{"removeshard", ShardName}};
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     数据库分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="shardingDB"></param>
        /// <returns></returns>
        public static CommandResult EnableSharding(MongoServer routeSvr, String shardingDB)
        {
            var mongoCmd = new CommandDocument();
            mongoCmd = new CommandDocument {{"enablesharding", shardingDB}};
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     数据集分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="sharingCollection"></param>
        /// <param name="shardingKey"></param>
        /// <returns></returns>
        public static CommandResult ShardCollection(MongoServer routeSvr, String sharingCollection,
            BsonDocument shardingKey)
        {
            var mongoCmd = new CommandDocument {{"shardCollection", sharingCollection}, {"key", shardingKey}};
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     初始化副本
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="replicaSetName">副本名称</param>
        /// <param name="HostList">从属服务器列表</param>
        public static CommandResult InitReplicaSet(String replicaSetName, String HostList)
        {
            //第一台服务器作为Primary服务器
            var PrimarySetting = new MongoClientSettings
            {
                Server = new MongoServerAddress(SystemManager.ConfigHelperInstance.ConnectionList[HostList].Host,
                    SystemManager.ConfigHelperInstance.ConnectionList[HostList].Port),
                ReadPreference = ReadPreference.PrimaryPreferred
            };
            //如果不设置的话，会有错误：不是Primary服务器，SlaveOK 是 False

            MongoServer PrimarySvr = new MongoClient(PrimarySetting).GetServer();
            var config = new BsonDocument();
            var hosts = new BsonArray();
            var replSetInitiateCmd = new BsonDocument();
            var host = new BsonDocument();
            //生成命令
            host = new BsonDocument
            {
                {KEY_ID, 1},
                {
                    "host", SystemManager.ConfigHelperInstance.ConnectionList[HostList].Host + ":" +
                            SystemManager.ConfigHelperInstance.ConnectionList[HostList].Port
                }
            };
            hosts.Add(host);
            config.Add(KEY_ID, replicaSetName);
            config.Add("members", hosts);
            replSetInitiateCmd.Add("replSetInitiate", config);

            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(replSetInitiateCmd);
            return ExecuteMongoSvrCommand(mongoCmd, PrimarySvr);
        }

        #endregion
    }
}