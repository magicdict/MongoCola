using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

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
        public static CommandResult AddToReplsetServer(MongoServer mongoSvr, String HostPort, Boolean IsArb = false)
        {
            if (!IsArb)
            {
                return ExecuteJsShell("rs.add('" + HostPort + "');", mongoSvr);
            }
            else
            {
                //其实addArb最后也只是调用了add方法
                return ExecuteJsShell("rs.addArb('" + HostPort + "');", mongoSvr);
            }
        }
        /// <summary>
        /// 删除服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="HostPort">服务器信息</param>
        /// <returns></returns>
        public static CommandResult RemoveFromReplsetServer(MongoServer mongoSvr, String HostPort)
        {
            return ExecuteJsShell("rs.remove('" + HostPort + "');", mongoSvr);
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
            /// 初始化
            /// </summary>
            /// <param name="_CommandString"></param>
            /// <param name="_RunLevel"></param>
            public MongoCommand(String _CommandString, PathLv _RunLevel)
            {
                CommandString = _CommandString;
                RunLevel = _RunLevel;
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
        /// <param name="cmd">命令对象</param>
        /// <returns></returns>
        public static void ExecuteMongoCommand(MongoCommand cmd)
        {
            var Command = new CommandDocument { { cmd.CommandString, 1 } };
            List<CommandResult> ResultCommandList = new List<CommandResult>();

            CommandResult rtn = new CommandResult();
            try
            {
                switch (cmd.RunLevel)
                {
                    case PathLv.CollectionLV:
                        rtn = ExecuteMongoColCommand(cmd.CommandString, SystemManager.GetCurrentCollection());
                        break;
                    case PathLv.DatabaseLV:
                        rtn = ExecuteMongoDBCommand(Command, SystemManager.GetCurrentDataBase());
                        break;
                    case PathLv.ServerLV:
                        rtn = ExecuteMongoSvrCommand(Command, SystemManager.GetCurrentService());
                        break;
                    default:
                        break;
                }
                ResultCommandList.Add(rtn);
                MyMessageBox.ShowMessage(cmd.CommandString, cmd.CommandString + " Result", MongoDBHelper.ConvertCommandResultlstToString(ResultCommandList), true);
            }
            catch (System.IO.IOException ex) {
                MyMessageBox.ShowMessage(cmd.CommandString, "IOException,Try to set Socket TimeOut more long at connection config", ex.ToString(), true);
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex, cmd.CommandString);
            }
        }

        /// <summary>
        /// 执行数据集命令
        /// </summary>
        /// <param name="CommandString"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoColCommand(String CommandString, MongoCollection mongoCol)
        {
            CommandResult rtn;
            BsonDocument cmd = new BsonDocument();
            cmd.Add(CommandString, mongoCol.Name);
            CommandDocument mongoCmd = new CommandDocument() { cmd };
            try
            {
                rtn = mongoCol.Database.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                rtn = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = CommandString;
            e.RunLevel = PathLv.DatabaseLV;
            e.Result = rtn;
            OnCommandRunComplete(e);
            return rtn;
        }

        /// <summary>
        /// 执行数据库命令
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(String mongoCmd, MongoDatabase mongoDB)
        {
            CommandResult rtn;
            try
            {
                rtn = mongoDB.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                rtn = ex.CommandResult;
            }
            return rtn;
        }
        /// <summary>
        /// 执行数据库命令
        /// </summary>
        /// <param name="mongoCmd"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(CommandDocument mongoCmd, MongoDatabase mongoDB)
        {
            CommandResult rtn;
            try
            {
                rtn = mongoDB.RunCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                rtn = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = mongoCmd.ToString();
            e.RunLevel = PathLv.DatabaseLV;
            e.Result = rtn;
            OnCommandRunComplete(e);
            return rtn;
        }
        /// <summary>
        /// 在指定数据库执行指定命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoDBCommand(MongoCommand cmd, MongoDatabase mongoDB)
        {
            var Command = new CommandDocument { { cmd.CommandString, 1 } };
            if (cmd.RunLevel == PathLv.DatabaseLV)
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
            CommandResult rtn;
            try
            {
                rtn = mongoSvr.RunAdminCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                rtn = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = mongoCmd;
            e.RunLevel = PathLv.ServerLV;
            e.Result = rtn;
            OnCommandRunComplete(e);
            return rtn;
        }
        /// <summary>
        /// 执行MongoCommand
        /// </summary>
        /// <param name="mongoCmd">命令Doc</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(CommandDocument mongoCmd, MongoServer mongoSvr)
        {
            CommandResult rtn;
            try
            {
                rtn = mongoSvr.RunAdminCommand(mongoCmd);
            }
            catch (MongoCommandException ex)
            {
                rtn = ex.CommandResult;
            }
            RunCommandEventArgs e = new RunCommandEventArgs();
            e.CommandString = mongoCmd.ToString();
            e.RunLevel = PathLv.ServerLV;
            e.Result = rtn;
            OnCommandRunComplete(e);
            return rtn;
        }
        /// <summary>
        /// 在指定服务器上执行指定命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="mongosrv"></param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoSvrCommand(MongoCommand cmd, MongoServer mongosrv)
        {
            var Command = new CommandDocument { { cmd.CommandString, 1 } };
            if (cmd.RunLevel == PathLv.DatabaseLV)
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
