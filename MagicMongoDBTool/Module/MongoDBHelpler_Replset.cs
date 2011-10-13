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
        public static void SetReplica(MongoServer mongosrv, String ReplicaSetName, List<String> SecondaryNames)
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
        public static void AddSharding(MongoServer routesrv, String ReplicaSetName, List<String> ShardingNames, String shardingDB = "", String SharingCollection = "")
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
            routesrv.RunAdminCommand(Mongocmd);

            if (shardingDB != String.Empty)
            {
                ///可分片数据库
                Mongocmd = new CommandDocument();
                Mongocmd.Add("enablesharding", shardingDB);
                routesrv.RunAdminCommand(Mongocmd);
            }

            if (SharingCollection != String.Empty)
            {
                ///可分片数据集
                Mongocmd = new CommandDocument();
                Mongocmd.Add("shardcollection", SharingCollection);
                Mongocmd.Add("key", new BsonDocument().Add("_id", 1));
                routesrv.RunAdminCommand(Mongocmd);
            }
        }

    }
}
