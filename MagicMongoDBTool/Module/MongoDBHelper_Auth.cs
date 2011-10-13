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
        /// 添加用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        /// <param name="Pw">密码</param>
        /// <param name="IsReadOnly">是否为只读</param>
        public static void AddUserForDB(String strDBPath, String strUser, String Pw, Boolean IsReadOnly)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            MongoUser newUser = new MongoUser(strUser, Pw, IsReadOnly);
            if (mongodb.FindUser(strUser) == null)
            {
                mongodb.AddUser(newUser);
            }
        }
        public static void ChangePwForDB(String strDBPath, String strUser, String OldPw, String NewPw)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            //TODO:
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="strDBPath">数据库路径</param>
        /// <param name="strUser">用户名</param>
        public static void RemoveUserForDB(String strDBPath, String strUser)
        {
            MongoDatabase mongodb = GetMongoDBBySvrPath(strDBPath, true);
            if (mongodb.FindUser(strUser) != null)
            {
                mongodb.RemoveUser(strUser);
            }
        }
        public static void Shutdown()
        {
            MongoServer mongosrv = GetMongoServerBySvrPath(SystemManager.SelectObjectTag, true);
            try
            {
                //the server will be  shutdown with exception
                mongosrv.Shutdown();
            }
            catch (System.IO.IOException)
            {

            }
            catch (Exception)
            {
                throw;
            }
        }
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
                host = new BsonDocument();
                _id++;
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

            if (shardingDB == string.Empty)
            {
                Mongocmd = new CommandDocument();
                Mongocmd.Add("enablesharding", shardingDB);
                routesrv.RunAdminCommand(Mongocmd);
            }

            if (SharingCollection == string.Empty)
            {
                Mongocmd = new CommandDocument();
                Mongocmd.Add("shardcollection", SharingCollection);
                Mongocmd.Add("key", new BsonDocument().Add("_id", 1));
                routesrv.RunAdminCommand(Mongocmd);
            }
        }
        public static void Mongos()
        {

        }
    }
}
