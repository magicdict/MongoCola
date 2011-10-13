using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
        /// <summary>
        /// 初始化副本
        /// </summary>
        /// <param name="mongosrv">副本组主服务器</param>
        /// <param name="ReplicaSetName">副本名称</param>
        /// <param name="SecondaryNames">从属服务器列表</param>
        public static void InitReplicaSet(MongoServer mongosrv, String ReplicaSetName, List<String> SecondaryNames)
        {
            BsonDocument config = new BsonDocument();
            BsonArray hosts = new BsonArray();
            BsonDocument cmd = new BsonDocument();
            BsonDocument host = new BsonDocument();

            byte _id = 1;
            host.Add("_id", _id);
            host.Add("host", mongosrv.Settings.Server.Host + ":" + mongosrv.Settings.Server.Port.ToString());
            hosts.Add(host);

            foreach (var item in SecondaryNames)
            {
                _id++;
                host = new BsonDocument();
                host.Add("_id", _id);
                host.Add("host", SystemManager.mConfig.ConnectionList[item].IpAddr + ":" + SystemManager.mConfig.ConnectionList[item].Port.ToString());
                hosts.Add(host);
            }

            config.Add("_id", ReplicaSetName);
            config.Add("members", hosts);

            cmd.Add("replSetInitiate", config);

            CommandDocument Mongocmd = new CommandDocument() { cmd };

            mongosrv.RunAdminCommand(Mongocmd);
        }
        /// <summary>
        /// 增加数据分片
        /// </summary>
        /// <param name="routesrv"></param>
        /// <param name="ReplicaSetName"></param>
        /// <param name="ShardingNames"></param>
        /// <param name="shardingDB"></param>
        /// <param name="SharingCollection"></param>
        public static CommandResult AddSharding(MongoServer routesrv, String ReplicaSetName, List<String> ShardingNames)
        {
            BsonDocument config = new BsonDocument();
            BsonDocument cmd = new BsonDocument();
            BsonDocument host = new BsonDocument();
            String strCmdPara = ReplicaSetName + "/";
            foreach (var item in ShardingNames)
            {
                strCmdPara += SystemManager.mConfig.ConnectionList[item].IpAddr + ":" + SystemManager.mConfig.ConnectionList[item].Port.ToString() + ",";
            }
            strCmdPara = strCmdPara.TrimEnd(",".ToCharArray());
            CommandDocument Mongocmd = new CommandDocument();
            Mongocmd.Add("addshard", strCmdPara);
            return routesrv.RunAdminCommand(Mongocmd);
        }
        /// <summary>
        /// 数据库分片
        /// </summary>
        /// <param name="routesrv"></param>
        /// <param name="shardingDB"></param>
        /// <returns></returns>
        public static CommandResult EnableSharding(MongoServer routesrv, String shardingDB)
        {
            CommandDocument Mongocmd = new CommandDocument();
            ///可分片数据库
            Mongocmd = new CommandDocument();
            Mongocmd.Add("enablesharding", shardingDB);
            return routesrv.RunAdminCommand(Mongocmd);
        }
        /// <summary>
        /// 数据集分片
        /// </summary>
        /// <param name="routesrv"></param>
        /// <param name="SharingCollection"></param>
        /// <param name="ShardingKey"></param>
        /// <returns></returns>
        public static CommandResult shardcollection(MongoServer routesrv, String SharingCollection,BsonDocument ShardingKey)
        {
            CommandDocument Mongocmd = new CommandDocument();
            ///可分片数据集
            Mongocmd = new CommandDocument();
            Mongocmd.Add("shardcollection", SharingCollection);
            Mongocmd.Add("key", ShardingKey);
            return routesrv.RunAdminCommand(Mongocmd);
        }
    }
}
