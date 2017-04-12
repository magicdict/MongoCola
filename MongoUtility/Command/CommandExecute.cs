using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public static class CommandExecute
    {

        /// <summary>
        ///     Command Complete Event
        /// </summary>
        public static EventHandler<RunCommandEventArgs> RunCommandComplete;

        /// <summary>
        ///     Command Complete
        /// </summary>
        /// <param name="e"></param>
        public static void OnCommandRunComplete(RunCommandEventArgs e)
        {
            e.Raise(null, ref RunCommandComplete);
        }

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
                { "$eval", new BsonJavaScript(jsShell)},
                { "nolock", true }
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
            return result.Response.ToBsonDocument().GetElement("retval").Value.AsBsonDocument.GetElement("ok").Value.ToString() == "1";
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
            switch (mMongoCommand.RunLevel)
            {
                case EnumMgr.PathLevel.CollectionAndView:
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
                    if (string.IsNullOrEmpty(mMongoCommand.DatabaseName))
                    {
                        mCommandResult = ExecuteMongoDBCommand(mMongoCommand.CmdDocument, RuntimeMongoDbContext.GetCurrentDataBase());
                    }
                    else
                    {
                        var db = RuntimeMongoDbContext.GetCurrentClient().GetDatabase(mMongoCommand.DatabaseName);
                        mCommandResult = ExecuteMongoDBCommand(mMongoCommand.CmdDocument, db);
                    }
                    break;
                case EnumMgr.PathLevel.Instance:
                    mCommandResult = ExecuteMongoSvrCommand(mMongoCommand.CmdDocument,
                        RuntimeMongoDbContext.GetCurrentServer());
                    break;
            }
            resultCommandList.Add(mCommandResult);
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
            var baseCommand = new BsonDocument { { commandString, mongoCol.Name } };
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
                RunLevel = EnumMgr.PathLevel.CollectionAndView,
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
                RunLevel = EnumMgr.PathLevel.CollectionAndView,
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
            var command = new CommandDocument { { mMongoCommand.CommandString, 1 } };
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
            CommandResult mCommandResult = null;
            try
            {
                if (mongoSvr.DatabaseExists(ConstMgr.DatabaseNameAdmin))
                {
                    mCommandResult = mongoSvr.GetDatabase(ConstMgr.DatabaseNameAdmin).RunCommand(mongoCmd);
                }
                else
                {
                    //Replset的时候，没有Admin数据库
                    BsonDocument AdminDatabaseNotFound = new BsonDocument
                    {
                        { "errmsg", "Admin Database Not Found" }
                    };
                    mCommandResult = new CommandResult(AdminDatabaseNotFound);
                }
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            catch (TimeoutException)
            {
                BsonDocument TimeOutDocument = new BsonDocument
                {
                    { "errmsg", "TimeoutException" }
                };
                mCommandResult = new CommandResult(TimeOutDocument);
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
            CommandResult mCommandResult = null;
            try
            {
                if (mongoSvr.DatabaseExists(ConstMgr.DatabaseNameAdmin))
                {
                    //Repl的时候，会发生超时问题
                    mCommandResult = mongoSvr.GetDatabase(ConstMgr.DatabaseNameAdmin).RunCommand(mCommandDocument);
                }
                else
                {
                    //Replset的时候，没有Admin数据库
                    BsonDocument AdminDatabaseNotFound = new BsonDocument
                    {
                        { "errmsg", "Admin Database Not Found" }
                    };
                    mCommandResult = new CommandResult(AdminDatabaseNotFound);
                }
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = new CommandResult(ex.Result);
            }
            catch (TimeoutException)
            {
                BsonDocument TimeOutDocument = new BsonDocument
                {
                    { "errmsg", "TimeoutException" }
                };
                mCommandResult = new CommandResult(TimeOutDocument);
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
            var command = new CommandDocument { { mMongoCommand.CommandString, 1 } };
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
            ///     命令数据库对象名称
            /// </summary>
            public string DatabaseName;
            /// <summary>
            ///     命令数据集对象名称
            /// </summary>
            public string CollectionName;

            /// <summary>
            ///     初始化
            /// </summary>
            /// <param name="commandString"></param>
            /// <param name="runLevel"></param>
            public MongoCommand(string commandString, EnumMgr.PathLevel runLevel, string databaseName = "", string collectionName = "")
            {
                CommandString = commandString;
                RunLevel = runLevel;
                CmdDocument = new CommandDocument { { commandString, 1 } };
                DatabaseName = databaseName;
                CollectionName = collectionName;
            }

            /// <summary>
            ///     初始化
            /// </summary>
            /// <param name="commandDocument"></param>
            /// <param name="runLevel"></param>
            public MongoCommand(CommandDocument commandDocument, EnumMgr.PathLevel runLevel, string databaseName = "", string collectionName = "")
            {
                CmdDocument = commandDocument;
                RunLevel = runLevel;
                CommandString = string.Empty;
                DatabaseName = databaseName;
                CollectionName = collectionName;
            }
        }
    }
}
