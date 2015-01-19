using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.EventArgs;
using Utility = Common.Logic.Utility;

namespace MongoUtility.Extend
{
    /// 注意，有些db.XXXX(xxx) 这样的函数需要 mongoDb.Eval方法才能做
    /// 有些RepairDatabase 这样的函数可以简单的执行
    /// <summary>
    /// </summary>
    public static class CommandHelper
    {
        /// <summary>
        ///     Command Complete Event
        /// </summary>
        public static EventHandler<RunCommandEventArgs> RunCommandComplete;

        #region"DataBase Command"

        /// 数据库命令 http://www.mongodb.org/display/DOCS/List+of+Database+Commands
        /// <summary>
        ///     修复数据库
        ///     http://www.mongodb.org/display/DOCS/Durability+and+Repair
        /// </summary>
        public static MongoCommand repairDatabase_Command = new MongoCommand("repairDatabase", EnumMgr.PathLv.DatabaseLv);

        #endregion

        //查看命令方法：http://localhost:29018/_commands
        //假设28018为端口号，同时使用 --rest 选项
        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands

        /// <summary>
        ///     Command Complete
        /// </summary>
        /// <param name="e"></param>
        public static void OnCommandRunComplete(RunCommandEventArgs e)
        {
            e.Raise(null, ref RunCommandComplete);
        }

        /// <summary>
        ///     当前对象的MONGO命令
        /// </summary>
        /// <param name="mMongoCommand">命令对象</param>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoCommand(MongoCommand mMongoCommand)
        {
            var ResultCommandList = new List<CommandResult>();

            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                switch (mMongoCommand.RunLevel)
                {
                    case EnumMgr.PathLv.CollectionLv:
                        if (String.IsNullOrEmpty(mMongoCommand.CommandString))
                        {
                            mCommandResult = ExecuteMongoColCommand(mMongoCommand.cmdDocument,
                                RuntimeMongoDBContext.GetCurrentCollection());
                        }
                        else
                        {
                            mCommandResult = ExecuteMongoColCommand(mMongoCommand.CommandString,
                                RuntimeMongoDBContext.GetCurrentCollection());
                        }
                        break;
                    case EnumMgr.PathLv.DatabaseLv:
                        mCommandResult = ExecuteMongoDBCommand(mMongoCommand.cmdDocument,
                            RuntimeMongoDBContext.GetCurrentDataBase());
                        break;
                    case EnumMgr.PathLv.InstanceLv:
                        mCommandResult = ExecuteMongoSvrCommand(mMongoCommand.cmdDocument,
                            RuntimeMongoDBContext.GetCurrentServer());
                        break;
                    default:
                        break;
                }
                ResultCommandList.Add(mCommandResult);
            }
            catch (IOException ex)
            {
                Utility.ExceptionDeal(ex, mMongoCommand.CommandString,
                    "IOException,Try to set Socket TimeOut more long at connection config");
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex, mMongoCommand.CommandString);
            }

            return mCommandResult;
        }

        /// <summary>
        ///     执行数据集命令
        /// </summary>
        /// <param name="CommandString"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(String CommandString, MongoCollection mongoCol)
        {
            CommandResult mCommandResult;
            var BaseCommand = new BsonDocument {{CommandString, mongoCol.Name}};
            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(BaseCommand);
            try
            {
                mCommandResult = mongoCol.Database.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = CommandString,
                RunLevel = EnumMgr.PathLv.CollectionLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     数据集命令
        /// </summary>
        /// <param name="Command">命令关键字</param>
        /// <param name="mongoCol">数据集</param>
        /// <param name="ExtendInfo">命令参数</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(String Command, MongoCollection mongoCol,
            BsonDocument ExtendInfo)
        {
            var ExecuteCommand = new CommandDocument
            {
                {Command, mongoCol.Name}
            };
            foreach (var item in ExtendInfo.Elements)
            {
                ExecuteCommand.Add(item);
            }
            var mCommandResult = mongoCol.Database.RunCommand(ExecuteCommand);
            var e = new RunCommandEventArgs
            {
                CommandString = ExecuteCommand.ToString(),
                RunLevel = EnumMgr.PathLv.CollectionLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行数据集命令
        /// </summary>
        /// <param name="CmdDoc"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(CommandDocument CmdDoc, MongoCollection mongoCol)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoCol.Database.RunCommand(CmdDoc);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = CmdDoc.GetElement(0).Value.ToString(),
                RunLevel = EnumMgr.PathLv.DatabaseLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行数据库命令
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(String mongoCmd, MongoDatabase mongoDB)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoDB.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd,
                RunLevel = EnumMgr.PathLv.DatabaseLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行数据库命令
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(CommandDocument mongoCmd, MongoDatabase mongoDB)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoDB.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd.ToString(),
                RunLevel = EnumMgr.PathLv.DatabaseLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     在指定数据库执行指定命令
        /// </summary>
        /// <param name="mMongoCommand"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(MongoCommand mMongoCommand, MongoDatabase mongoDB)
        {
            var Command = new CommandDocument {{mMongoCommand.CommandString, 1}};
            if (mMongoCommand.RunLevel == EnumMgr.PathLv.DatabaseLv)
            {
                return ExecuteMongoDBCommand(Command, mongoDB);
            }
            throw new Exception();
        }

        /// <summary>
        ///     执行MongoCommand
        /// </summary>
        /// <param name="mongoCmd">命令Command</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(String mongoCmd, MongoServer mongoSvr)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoSvr.GetDatabase(ConstMgr.DATABASE_NAME_ADMIN).RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd,
                RunLevel = EnumMgr.PathLv.InstanceLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行MongoCommand
        /// </summary>
        /// <param name="mCommandDocument">命令Doc</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(CommandDocument mCommandDocument, MongoServer mongoSvr)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoSvr.GetDatabase(ConstMgr.DATABASE_NAME_ADMIN).RunCommand(mCommandDocument);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mCommandDocument.ToString(),
                RunLevel = EnumMgr.PathLv.InstanceLv,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     在指定服务器上执行指定命令
        /// </summary>
        /// <param name="mMongoCommand"></param>
        /// <param name="mongosrv"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(MongoCommand mMongoCommand, MongoServer mongosrv)
        {
            var Command = new CommandDocument {{mMongoCommand.CommandString, 1}};
            if (mMongoCommand.RunLevel == EnumMgr.PathLv.DatabaseLv)
            {
                throw new Exception();
            }
            return ExecuteMongoSvrCommand(Command, mongosrv);
        }

        /// <summary>
        ///     MONGO命令
        /// </summary>
        public struct MongoCommand
        {
            /// <summary>
            /// </summary>
            public CommandDocument cmdDocument;

            /// <summary>
            ///     命令文
            /// </summary>
            public String CommandString;

            /// <summary>
            ///     对象等级
            /// </summary>
            public EnumMgr.PathLv RunLevel;

            /// <summary>
            ///     初始化
            /// </summary>
            /// <param name="_CommandString"></param>
            /// <param name="_RunLevel"></param>
            public MongoCommand(String _CommandString, EnumMgr.PathLv _RunLevel)
            {
                CommandString = _CommandString;
                RunLevel = _RunLevel;
                cmdDocument = new CommandDocument {{_CommandString, 1}};
            }

            /// <summary>
            ///     初始化
            /// </summary>
            /// <param name="_CommandDocument"></param>
            /// <param name="_RunLevel"></param>
            public MongoCommand(CommandDocument _CommandDocument, EnumMgr.PathLv _RunLevel)
            {
                cmdDocument = _CommandDocument;
                RunLevel = _RunLevel;
                CommandString = String.Empty;
            }
        }

        #region"Shell Command"

        /// 注意：有些命令可能只能用在mongos上面，例如addshard
        /// <summary>
        ///     使用Shell Helper命令
        /// </summary>
        /// <param name="JsShell"></param>
        /// <param name="mongoSvr"></param>
        /// <returns></returns>
        public static CommandResult ExecuteJsShell(String JsShell, MongoServer mongoSvr)
        {
            var ShellCmd = new BsonDocument
            {
                {
                    "$eval",
                    new BsonJavaScript(JsShell)
                },
                {
                    "nolock",
                    true
                }
            };
            //必须nolock
            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(ShellCmd);
            return ExecuteMongoSvrCommand(mongoCmd, mongoSvr);
        }

        /// <summary>
        ///     Js Shell 的结果判定
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static Boolean IsShellOK(CommandResult Result)
        {
            if (!Result.Response.ToBsonDocument().GetElement("retval").Value.IsBsonDocument)
            {
                return true;
            }
            return
                Result.Response.ToBsonDocument()
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
        public static MongoCommand Compact_Command = new MongoCommand("compact", EnumMgr.PathLv.CollectionLv);

        /// <summary>
        ///     执行聚合
        /// </summary>
        /// <param name="AggregateDoc"></param>
        /// <returns></returns>
        /// <param name="CollectionName"></param>
        public static CommandResult Aggregate(BsonArray AggregateDoc, String CollectionName)
        {
            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            try
            {
                var agg = new CommandDocument
                {
                    new BsonElement("aggregate", new BsonString(CollectionName)),
                    new BsonElement("pipeline", AggregateDoc)
                };
                var Aggregate_Command = new MongoCommand(agg, EnumMgr.PathLv.DatabaseLv);
                return ExecuteMongoCommand(Aggregate_Command);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
                return new CommandResult(new BsonDocument());
            }
        }

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
        public static MongoCommand serverStatus_Command = new MongoCommand("serverStatus", EnumMgr.PathLv.InstanceLv);

        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        /// <summary>
        ///     副本状态
        /// </summary>
        public static MongoCommand replSetGetStatus_Command = new MongoCommand("replSetGetStatus",
            EnumMgr.PathLv.InstanceLv);

        //http://www.mongodb.org/display/DOCS/Master+Slave
        /// <summary>
        ///     Slave强制同步
        /// </summary>
        public static MongoCommand resync_Command = new MongoCommand("resync", EnumMgr.PathLv.InstanceLv);

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
            return mCommandResult;
        }

        /// <summary>
        ///     重新启动
        /// </summary>
        /// <param name="PrimarySvr">副本组主服务器</param>
        /// <param name="config">服务器信息</param>
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
            var cmdPara = replicaSetName == String.Empty ? String.Empty : (replicaSetName + "/");
            foreach (var item in lstAddress)
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
            var maxValue = String.Empty;
            var minValue = String.Empty;
            if (Min.IsString)
            {
                minValue = "'" + Min + "'";
            }
            if (Max.IsString)
            {
                maxValue = "'" + Max + "'";
            }

            if (Min.IsNumeric)
            {
                minValue = Min.ToString();
            }
            if (Max.IsNumeric)
            {
                maxValue = Max.ToString();
            }
            return ExecuteJsShell(
                "sh.addTagRange('" + NameSpace + "'," + minValue + "," + maxValue + ",'" + Tag + "')", routeSvr);
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
        /// <param name="replicaSetName">副本名称</param>
        /// <param name="hostList">从属服务器列表</param>
        /// <param name="Configs"></param>
        public static CommandResult InitReplicaSet(String replicaSetName, String hostList,
            Dictionary<string, MongoConnectionConfig> Configs)
        {
            //第一台服务器作为Primary服务器
            var PrimarySetting = new MongoClientSettings
            {
                Server = new MongoServerAddress(Configs[hostList].Host,
                    Configs[hostList].Port),
                ReadPreference = ReadPreference.PrimaryPreferred
            };
            //如果不设置的话，会有错误：不是Primary服务器，SlaveOK 是 False

            var PrimarySvr = new MongoClient(PrimarySetting).GetServer();
            var config = new BsonDocument();
            var hosts = new BsonArray();
            var replSetInitiateCmd = new BsonDocument();
            var host = new BsonDocument();
            //生成命令
            host = new BsonDocument
            {
                {ConstMgr.KEY_ID, 1},
                {
                    "host", Configs[hostList].Host + ":" + Configs[hostList].Port
                }
            };
            hosts.Add(host);
            config.Add(ConstMgr.KEY_ID, replicaSetName);
            config.Add("members", hosts);
            replSetInitiateCmd.Add("replSetInitiate", config);

            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(replSetInitiateCmd);
            return ExecuteMongoSvrCommand(mongoCmd, PrimarySvr);
        }

        #endregion
    }
}