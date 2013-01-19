using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

        ///注意：有些命令可能只能用在mongos上面，例如addshard

        #region"Shell Command"
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
        /// 增加服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <param name="IsArb">是否为仲裁服务器</param>
        /// <returns></returns>
        public static CommandResult AddToReplsetServer(MongoServer mongoSvr, String HostPort, int priority, Boolean IsArb)
        {
            CommandResult mCommandResult = new CommandResult();
            try
            {
                if (!IsArb)
                {
                    mCommandResult = ExecuteJsShell("rs.add({_id:" + mongoSvr.Instances.Length + 1 + ",host:'" + HostPort + "',priority:" + priority.ToString() + "});", mongoSvr);
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
        /// 删除服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult RemoveFromReplsetServer(MongoServer mongoSvr, String HostPort)
        {
            CommandResult mCommandResult = new CommandResult();
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
        /// 重新启动
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <remarks>这个命令C#无法正确执行</remarks>
        /// <returns></returns>
        public static CommandResult ReconfigReplsetServer(MongoServer PrimarySvr, BsonDocument config)
        {
            CommandResult cmdRtn = new CommandResult();
            try
            {
                return ExecuteJsShell("rs.reconfig(" + config.ToString() + ",{force : true})", PrimarySvr);
            }
            catch (EndOfStreamException)
            {

            }
            return cmdRtn;
        }
        public static CommandResult Aggregate(String AggregateDoc)
        {

            //db.runCommand( { aggregate: "people", pipeline: [<pipeline>] } )
            try
            {
                CommandDocument agg = new CommandDocument();
                agg.Add(new BsonElement("aggregate", new BsonString(SystemManager.GetCurrentCollection().Name)));
                BsonArray aggArr = new BsonArray();
                aggArr.Add(BsonDocument.Parse(AggregateDoc));
                agg.Add(new BsonElement("pipeline", aggArr));
                MongoCommand Aggregate_Command = new MongoCommand(agg, PathLv.DatabaseLV);
                return ExecuteMongoCommand(Aggregate_Command, false);
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
                return new CommandResult();
            }
        }
        /// <summary>
        /// 使用Shell Helper命令
        /// </summary>
        /// <param name="JsShell"></param>
        /// <param name="mongoSvr"></param>
        /// <returns></returns>
        public static CommandResult ExecuteJsShell(String JsShell, MongoServer mongoSvr)
        {
            BsonDocument cmd = new BsonDocument();
            cmd.Add("$eval", new BsonJavaScript(JsShell));
            //必须nolock
            cmd.Add("nolock", true);
            CommandDocument mongoCmd = new CommandDocument() { cmd };
            return ExecuteMongoSvrCommand(mongoCmd, mongoSvr);
        }
        /// <summary>
        /// Js Shell 的结果判定
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static Boolean IsShellOK(CommandResult Result)
        {
            if (!Result.Response.ToBsonDocument().GetElement("retval").Value.IsBsonDocument)
            {
                return true;
            }
            else
            {
                return Result.Response.ToBsonDocument().GetElement("retval").Value.AsBsonDocument.GetElement("ok").Value.ToString() == "1";
            }
        }

        #endregion

        //查看命令方法：http://localhost:29018/_commands
        //假设28018为端口号，同时使用 --rest 选项
        //http://www.mongodb.org/display/DOCS/Replica+Set+Commands

        /// <summary>
        /// MONGO命令
        /// </summary>
        public struct MongoCommand
        {
            /// <summary>
            /// 命令文
            /// </summary>
            public String CommandString;
            /// <summary>
            /// 对象等级
            /// </summary>
            public PathLv RunLevel;
            /// <summary>
            /// 
            /// </summary>
            public CommandDocument cmdDocument;
            /// <summary>
            /// 初始化
            /// </summary>
            /// <param name="_CommandString"></param>
            /// <param name="_RunLevel"></param>
            public MongoCommand(String _CommandString, PathLv _RunLevel)
            {
                CommandString = _CommandString;
                RunLevel = _RunLevel;
                cmdDocument = new CommandDocument { { _CommandString, 1 } };
            }
            /// <summary>
            /// 初始化
            /// </summary>
            /// <param name="_CommandDocument"></param>
            /// <param name="_RunLevel"></param>
            public MongoCommand(CommandDocument _CommandDocument, PathLv _RunLevel)
            {
                cmdDocument = _CommandDocument;
                RunLevel = _RunLevel;
                CommandString = String.Empty;
            }
        }
        /// <summary>
        /// Command Complete Event
        /// </summary>
        public static EventHandler<RunCommandEventArgs> RunCommandComplete;
        /// <summary>
        /// Command Complete
        /// </summary>
        /// <param name="e"></param>
        public static void OnCommandRunComplete(RunCommandEventArgs e)
        {
            e.Raise(null, ref RunCommandComplete);
        }
        /// <summary>
        /// 当前对象的MONGO命令
        /// </summary>
        /// <param name="mMongoCommand">命令对象</param>
        /// <param name="ShowMsgBox"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoCommand(MongoCommand mMongoCommand, Boolean ShowMsgBox = true)
        {
            List<CommandResult> ResultCommandList = new List<CommandResult>();

            CommandResult mCommandResult = new CommandResult();
            try
            {
                switch (mMongoCommand.RunLevel)
                {
                    case PathLv.CollectionLV:
                        mCommandResult = ExecuteMongoColCommand(mMongoCommand.CommandString, SystemManager.GetCurrentCollection());
                        break;
                    case PathLv.DatabaseLV:
                        mCommandResult = ExecuteMongoDBCommand(mMongoCommand.cmdDocument, SystemManager.GetCurrentDataBase());
                        break;
                    case PathLv.ServerLV:
                        mCommandResult = ExecuteMongoSvrCommand(mMongoCommand.cmdDocument, SystemManager.GetCurrentServer());
                        break;
                    default:
                        break;
                }
                ResultCommandList.Add(mCommandResult);
                if (ShowMsgBox) MyMessageBox.ShowMessage(mMongoCommand.CommandString, mMongoCommand.CommandString + " Result", MongoDBHelper.ConvertCommandResultlstToString(ResultCommandList), true);
            }
            catch (System.IO.IOException ex)
            {
                MyMessageBox.ShowMessage(mMongoCommand.CommandString, "IOException,Try to set Socket TimeOut more long at connection config", ex.ToString(), true);
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex, mMongoCommand.CommandString);
            }

            return mCommandResult;
        }

        /// <summary>
        /// 执行数据集命令
        /// </summary>
        /// <param name="CommandString"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(String CommandString, MongoCollection mongoCol)
        {
            CommandResult mCommandResult;
            BsonDocument cmd = new BsonDocument();
            cmd.Add(CommandString, mongoCol.Name);
            CommandDocument mongoCmd = new CommandDocument() { cmd };
            try
            {
                mCommandResult = mongoCol.Database.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = CommandString;
            e.RunLevel = PathLv.DatabaseLV;
            e.Result = mCommandResult;
            OnCommandRunComplete(e);
            return mCommandResult;
        }

        /// <summary>
        /// 执行数据库命令
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
            return mCommandResult;
        }
        /// <summary>
        /// 执行数据库命令
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
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = mongoCmd.ToString();
            e.RunLevel = PathLv.DatabaseLV;
            e.Result = mCommandResult;
            OnCommandRunComplete(e);
            return mCommandResult;
        }
        /// <summary>
        /// 在指定数据库执行指定命令
        /// </summary>
        /// <param name="mMongoCommand"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(MongoCommand mMongoCommand, MongoDatabase mongoDB)
        {
            var Command = new CommandDocument { { mMongoCommand.CommandString, 1 } };
            if (mMongoCommand.RunLevel == PathLv.DatabaseLV)
            {
                return ExecuteMongoDBCommand(Command, mongoDB);
            }
            else
            {
                throw new Exception();
            }
        }


        /// <summary>
        /// 执行MongoCommand
        /// </summary>
        /// <param name="mongoCmd">命令Command</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(String mongoCmd, MongoServer mongoSvr)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = mongoCmd;
            e.RunLevel = PathLv.ServerLV;
            e.Result = mCommandResult;
            OnCommandRunComplete(e);
            return mCommandResult;
        }
        /// <summary>
        /// 执行MongoCommand
        /// </summary>
        /// <param name="mCommandDocument">命令Doc</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(CommandDocument mCommandDocument, MongoServer mongoSvr)
        {
            CommandResult mCommandResult;
            try
            {
                mCommandResult = mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).RunCommand(mCommandDocument);
            }
            catch (MongoCommandException ex)
            {
                mCommandResult = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = mCommandDocument.ToString();
            e.RunLevel = PathLv.ServerLV;
            e.Result = mCommandResult;
            OnCommandRunComplete(e);
            return mCommandResult;
        }
        /// <summary>
        /// 在指定服务器上执行指定命令
        /// </summary>
        /// <param name="mMongoCommand"></param>
        /// <param name="mongosrv"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(MongoCommand mMongoCommand, MongoServer mongosrv)
        {
            var Command = new CommandDocument { { mMongoCommand.CommandString, 1 } };
            if (mMongoCommand.RunLevel == PathLv.DatabaseLV)
            {
                throw new Exception();
            }
            else
            {
                return ExecuteMongoSvrCommand(Command, mongosrv);
            }
        }

    }
}
