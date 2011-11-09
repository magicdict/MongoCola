using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {

        //查看命令方法：http://localhost:29018/_commands
        //假设28018为端口号，同时使用 --rest 选项

        /// <summary>
        /// 初始化副本
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <param name="replicaSetName">副本名称</param>
        /// <param name="HostList">从属服务器列表</param>
        public static CommandResult InitReplicaSet(string replicaSetName, List<string> HostList)
        {
            MongoServerSettings PrimarySetting = new MongoServerSettings();
            PrimarySetting.Server = new MongoServerAddress(SystemManager.ConfigHelperInstance.ConnectionList[HostList[0]].IpAddr,
                                                           SystemManager.ConfigHelperInstance.ConnectionList[HostList[0]].Port);
            PrimarySetting.SlaveOk = true;

            MongoServer PrimarySvr = new MongoServer(PrimarySetting);
            BsonDocument config = new BsonDocument();
            BsonArray hosts = new BsonArray();
            BsonDocument cmd = new BsonDocument();
            BsonDocument host = new BsonDocument();

            byte id = 0;
            foreach (var item in HostList)
            {
                id++;
                host = new BsonDocument();
                host.Add("_id", id);
                host.Add("host", SystemManager.ConfigHelperInstance.ConnectionList[item].IpAddr + ":" + SystemManager.ConfigHelperInstance.ConnectionList[item].Port.ToString());
                if (SystemManager.ConfigHelperInstance.ConnectionList[item].ServerType == ConfigHelper.SvrType.ArbiterSvr)
                {
                    host.Add("arbiterOnly", true);
                }
                else
                {
                    host.Add("priority", SystemManager.ConfigHelperInstance.ConnectionList[item].Priority);
                }
                hosts.Add(host);
            }

            config.Add("_id", replicaSetName);
            config.Add("members", hosts);

            cmd.Add("replSetInitiate", config);

            CommandDocument mongoCmd = new CommandDocument() { cmd };
            return ExecuteMongoCommand(mongoCmd, PrimarySvr);
        }
        /// <summary>
        /// 增加仲裁服务器
        /// </summary>
        /// <param name="mongoSvr">副本组主服务器</param>
        /// <returns></returns>
        public static CommandResult addArb(MongoServer mongoSvr, String HostPort)
        {
            //使用Shell Helper命令
            BsonDocument cmd = new BsonDocument();
            cmd.Add("$eval", new BsonJavaScript("rs.addArb('" + HostPort + "');"));
            cmd.Add("nolock", true);
            CommandDocument mongoCmd = new CommandDocument() { cmd };
            return ExecuteMongoCommand(mongoCmd, mongoSvr);
        }
        /// <summary>
        /// 执行MongoCommand
        /// </summary>
        /// <param name="mongoCmd">命令Command</param>
        /// <param name="mongoSvr">目标服务器</param>
        /// <returns></returns>
        public static CommandResult ExecuteMongoCommand(String mongoCmd, MongoServer mongoSvr)
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
        public static CommandResult ExecuteMongoCommand(CommandDocument mongoCmd, MongoServer mongoSvr)
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
        /// 增加数据分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="replicaSetName"></param>
        /// <param name="shardingNames"></param>
        /// <returns></returns>
        public static CommandResult AddSharding(MongoServer routeSvr, string replicaSetName, List<string> shardingNames)
        {
            BsonDocument config = new BsonDocument();
            BsonDocument cmd = new BsonDocument();
            BsonDocument host = new BsonDocument();
            string cmdPara = replicaSetName + "/";
            foreach (var item in shardingNames)
            {
                cmdPara += SystemManager.ConfigHelperInstance.ConnectionList[item].IpAddr + ":" + SystemManager.ConfigHelperInstance.ConnectionList[item].Port.ToString() + ",";
            }
            cmdPara = cmdPara.TrimEnd(",".ToCharArray());
            CommandDocument mongoCmd = new CommandDocument();
            mongoCmd.Add("addshard", cmdPara);
            return ExecuteMongoCommand(mongoCmd, routeSvr);
        }
        /// <summary>
        /// 数据库分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="shardingDB"></param>
        /// <returns></returns>
        public static CommandResult EnableSharding(MongoServer routeSvr, String shardingDB)
        {
            CommandDocument mongoCmd = new CommandDocument();
            mongoCmd = new CommandDocument();
            mongoCmd.Add("enablesharding", shardingDB);
            return ExecuteMongoCommand(mongoCmd, routeSvr);
        }
        /// <summary>
        /// 数据集分片
        /// </summary>
        /// <param name="routeSvr"></param>
        /// <param name="sharingCollection"></param>
        /// <param name="shardingKey"></param>
        /// <returns></returns>
        public static CommandResult ShardCollection(MongoServer routeSvr, String sharingCollection, BsonDocument shardingKey)
        {
            CommandDocument mongoCmd = new CommandDocument();
            mongoCmd.Add("shardcollection", sharingCollection);
            mongoCmd.Add("key", shardingKey);
            return ExecuteMongoCommand(mongoCmd, routeSvr);
        }
    }
}
