using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.EventArgs;

namespace MongoUtility.Command
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
        public static MongoCommand RepairDatabaseCommand = new MongoCommand("repairDatabase", EnumMgr.PathLevel.Database);

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
        /// <returns></returns>
        public static CommandResult ExecuteMongoCommand(MongoCommand mMongoCommand)
        {
            var resultCommandList = new List<CommandResult>();

            var mCommandResult = new CommandResult(new BsonDocument());
            try
            {
                switch (mMongoCommand.RunLevel)
                {
                    case EnumMgr.PathLevel.Collection:
                        if (string.IsNullOrEmpty(mMongoCommand.CommandString))
                        {
                            mCommandResult = ExecuteMongoColCommand(mMongoCommand.CmdDocument,
                                RuntimeMongoDbContext.GetCurrentCollection());
                        }
                        else
                        {
                            mCommandResult = ExecuteMongoColCommand(mMongoCommand.CommandString,
                                RuntimeMongoDbContext.GetCurrentCollection());
                        }
                        break;
                    case EnumMgr.PathLevel.Database:
                        mCommandResult = ExecuteMongoDBCommand(mMongoCommand.CmdDocument,
                            RuntimeMongoDbContext.GetCurrentDataBase());
                        break;
                    case EnumMgr.PathLevel.Instance:
                        mCommandResult = ExecuteMongoSvrCommand(mMongoCommand.CmdDocument,
                            RuntimeMongoDbContext.GetCurrentServer());
                        break;
                }
                resultCommandList.Add(mCommandResult);
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
        /// <param name="commandString"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(string commandString, MongoCollection mongoCol)
        {
            CommandResult mCommandResult;
            var baseCommand = new BsonDocument {{commandString, mongoCol.Name}};
            var mongoCmd = new CommandDocument();
            mongoCmd.AddRange(baseCommand);
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
                CommandString = commandString,
                RunLevel = EnumMgr.PathLevel.Collection,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     数据集命令
        /// </summary>
        /// <param name="command">命令关键字</param>
        /// <param name="mongoCol">数据集</param>
        /// <param name="extendInfo">命令参数</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(string command, MongoCollection mongoCol,
            BsonDocument extendInfo)
        {
            var executeCommand = new CommandDocument
            {
                {command, mongoCol.Name}
            };
            foreach (var item in extendInfo.Elements)
            {
                executeCommand.Add(item);
            }
            var mCommandResult = mongoCol.Database.RunCommand(executeCommand);
            var e = new RunCommandEventArgs
            {
                CommandString = executeCommand.ToString(),
                RunLevel = EnumMgr.PathLevel.Collection,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行数据集命令
        /// </summary>
        /// <param name="cmdDoc"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(CommandDocument cmdDoc, MongoCollection mongoCol)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoCol.Database.RunCommand(cmdDoc);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = cmdDoc.GetElement(0).Value.ToString(),
                RunLevel = EnumMgr.PathLevel.Database,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行数据库命令
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(string mongoCmd, MongoDatabase mongoDb)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoDb.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd,
                RunLevel = EnumMgr.PathLevel.Database,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     执行数据库命令
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(CommandDocument mongoCmd, MongoDatabase mongoDb)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoDb.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd.ToString(),
                RunLevel = EnumMgr.PathLevel.Database,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(CommandDocument mongoCmd, IMongoDatabase mongoDb)
        {
            CommandResult mCommandResult = null;
            try
            {
                var t = Task.Run(
                    async () => { mCommandResult = await mongoDb.RunCommandAsync<CommandResult>(mongoCmd); }
                    );
                t.Wait();
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd.ToString(),
                RunLevel = EnumMgr.PathLevel.Database,
                Result = mCommandResult
            };
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        ///     在指定数据库执行指定命令
        /// </summary>
        /// <param name="mMongoCommand"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(MongoCommand mMongoCommand, MongoDatabase mongoDb)
        {
            var command = new CommandDocument {{mMongoCommand.CommandString, 1}};
            if (mMongoCommand.RunLevel == EnumMgr.PathLevel.Database)
            {
                return ExecuteMongoDBCommand(command, mongoDb);
            }
            throw new Exception();
        }

        /// <summary>
        ///     执行MongoCommand
        /// </summary>
        /// <param name="mongoCmd">命令Command</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(string mongoCmd, MongoServer mongoSvr)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoSvr.GetDatabase(ConstMgr.DatabaseNameAdmin).RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mongoCmd,
                RunLevel = EnumMgr.PathLevel.Instance,
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
                mCommandResult = mongoSvr.GetDatabase(ConstMgr.DatabaseNameAdmin).RunCommand(mCommandDocument);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            var e = new RunCommandEventArgs
            {
                CommandString = mCommandDocument.ToString(),
                RunLevel = EnumMgr.PathLevel.Instance,
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
            var command = new CommandDocument {{mMongoCommand.CommandString, 1}};
            if (mMongoCommand.RunLevel == EnumMgr.PathLevel.Database)
            {
                throw new Exception();
            }
            return ExecuteMongoSvrCommand(command, mongosrv);
        }

        /// <summary>
        ///     MONGO命令
        /// </summary>
        public struct MongoCommand
        {
            /// <summary>
            /// </summary>
            public CommandDocument CmdDocument;

            /// <summary>
            ///     命令文
            /// </summary>
            public string CommandString;

            /// <summary>
            ///     对象等级
            /// </summary>
            public EnumMgr.PathLevel RunLevel;

            /// <summary>
            ///     初始化
            /// </summary>
            /// <param name="commandString"></param>
            /// <param name="runLevel"></param>
            public MongoCommand(string commandString, EnumMgr.PathLevel runLevel)
            {
                CommandString = commandString;
                RunLevel = runLevel;
                CmdDocument = new CommandDocument {{commandString, 1}};
            }

            /// <summary>
            ///     初始化
            /// </summary>
            /// <param name="commandDocument"></param>
            /// <param name="runLevel"></param>
            public MongoCommand(CommandDocument commandDocument, EnumMgr.PathLevel runLevel)
            {
                CmdDocument = commandDocument;
                RunLevel = runLevel;
                CommandString = string.Empty;
            }
        }

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
        public static MongoCommand CompactCommand = new MongoCommand("compact", EnumMgr.PathLevel.Collection);

        /// <summary>
        ///     执行聚合
        /// </summary>
        /// <param name="aggregateDoc"></param>
        /// <returns></returns>
        /// <param name="collectionName"></param>
        public static CommandResult Aggregate(BsonArray aggregateDoc, string collectionName)
        {
            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            try
            {
                var agg = new CommandDocument
                {
                    new BsonElement("aggregate", new BsonString(collectionName)),
                    new BsonElement("pipeline", aggregateDoc)
                };
                var aggregateCommand = new MongoCommand(agg, EnumMgr.PathLevel.Database);
                return ExecuteMongoCommand(aggregateCommand);
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
        public static MongoCommand ServerStatusCommand = new MongoCommand("serverStatus", EnumMgr.PathLevel.Instance);

        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands
        /// <summary>
        ///     副本状态
        /// </summary>
        public static MongoCommand ReplSetGetStatusCommand = new MongoCommand("replSetGetStatus",
            EnumMgr.PathLevel.Instance);

        //http://www.mongodb.org/display/DOCS/Master+Slave
        /// <summary>
        ///     Slave强制同步
        /// </summary>
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
                    mCommandResult =
                        ExecuteJsShell(
                            "rs.add({_id:" + mongoSvr.Instances.Length + 1 + ",host:'" + hostPort + "',priority:" +
                            priority + "});", mongoSvr);
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
            var mongoCmd = new CommandDocument {{"addshard", cmdPara}};
            if (maxSize != 0)
            {
                mongoCmd.Add("maxSize", (BsonValue) maxSize);
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
        public static CommandResult AddShardTag(MongoServer routeSvr, string shardName, string tagName)
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
            return ExecuteJsShell("sh.addShardTag('" + shardName + "', '" + tagName + "')", routeSvr);
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
        public static CommandResult AddTagRange(MongoServer routeSvr, string nameSpace, BsonValue min, BsonValue max,
            string tag)
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
            var maxValue = string.Empty;
            var minValue = string.Empty;
            if (min.IsString)
            {
                minValue = "'" + min + "'";
            }
            if (max.IsString)
            {
                maxValue = "'" + max + "'";
            }

            if (min.IsNumeric)
            {
                minValue = min.ToString();
            }
            if (max.IsNumeric)
            {
                maxValue = max.ToString();
            }
            return ExecuteJsShell(
                "sh.addTagRange('" + nameSpace + "'," + minValue + "," + maxValue + ",'" + tag + "')", routeSvr);
        }

        /// <summary>
        ///     移除Shard
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="shardName">Shard名称</param>
        /// <returns></returns>
        public static CommandResult RemoveSharding(MongoServer routeSvr, string shardName)
        {
            var mongoCmd = new CommandDocument {{"removeshard", shardName}};
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
            mongoCmd = new CommandDocument {{"enablesharding", shardingDb}};
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
            var mongoCmd = new CommandDocument {{"shardCollection", sharingCollection}, {"key", shardingKey}};
            return ExecuteMongoSvrCommand(mongoCmd, routeSvr);
        }

        /// <summary>
        ///     初始化副本
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
    }
}