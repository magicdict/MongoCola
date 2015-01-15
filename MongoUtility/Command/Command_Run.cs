using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using Utility = Common.Utility;

namespace MongoUtility.Command
{
    /// 注意，有些db.XXXX(xxx) 这样的函数需要 mongoDb.Eval方法才能做
    /// 有些RepairDatabase 这样的函数可以简单的执行
    /// <summary>
    /// </summary>
    public static partial class CommandHelper
    {
        /// <summary>
        ///     Command Complete Event
        /// </summary>
        public static EventHandler<RunCommandEventArgs> RunCommandComplete;

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
                mCommandResult = ex.CommandResult;
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
                mCommandResult = ex.CommandResult;
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
                mCommandResult = ex.CommandResult;
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
                mCommandResult = ex.CommandResult;
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
                mCommandResult = ex.CommandResult;
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
                mCommandResult = ex.CommandResult;
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
    }
}