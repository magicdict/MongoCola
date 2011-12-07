using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {

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
        /// 当前对象的MONGO命令
        /// </summary>
        /// <param name="cmd">命令对象</param>
        /// <returns></returns>
        public static CommandResult RunMongoCommandAtCurrentObj(MongoCommand cmd)
        {
            var serverStatusCommand = new CommandDocument { { cmd.CommandString, 1 } };
            if (cmd.RunLevel == PathLv.DatabaseLV)
            {
                return ExecuteMongoDBCommand(serverStatusCommand, SystemManager.GetCurrentDataBase());
            }
            else
            {
                return ExecuteMongoSvrCommand(serverStatusCommand, SystemManager.GetCurrentService());
            }
        }
        /// <summary>
        /// 在指定服务器上执行指定命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="mongosrv"></param>
        /// <returns></returns>
        public static CommandResult RunMongoCommandAtMongoSrv(MongoCommand cmd, MongoServer mongosrv)
        {
            var serverStatusCommand = new CommandDocument { { cmd.CommandString, 1 } };
            if (cmd.RunLevel == PathLv.DatabaseLV)
            {
                throw new Exception();
            }
            else
            {
                return ExecuteMongoSvrCommand(serverStatusCommand, mongosrv);
            }
        }
        /// <summary>
        /// 在指定数据库执行指定命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static CommandResult RunMongoCommandAtMongoDB(MongoCommand cmd, MongoDatabase mongoDB)
        {
            var serverStatusCommand = new CommandDocument { { cmd.CommandString, 1 } };
            if (cmd.RunLevel == PathLv.DatabaseLV)
            {
                return ExecuteMongoDBCommand(serverStatusCommand, mongoDB);
            }
            else
            {
                throw new Exception();
            }
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
            return rtn;
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
            return rtn;
        }


    }
}
