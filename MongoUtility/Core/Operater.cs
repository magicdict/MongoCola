using System.Collections.Generic;
using MongoUtility.Extend;

namespace MongoUtility.Core
{
    public static class Operater
    {
        public static bool InitReplicaSet(string replSetName, ref string strMessage)
        {
            var result = CommandHelper.InitReplicaSet(replSetName,
                RuntimeMongoDbContext.GetCurrentServerConfig().ConnectionName, MongoConnectionConfig.MongoConfig.ConnectionList);
            if (result.Ok)
            {
                //修改配置
                var newConfig = RuntimeMongoDbContext.GetCurrentServerConfig();
                newConfig.ReplSetName = replSetName;
                newConfig.ReplsetList = new List<string>
                {
                    newConfig.Host +
                    (newConfig.Port != 0 ? ":" + newConfig.Port : string.Empty)
                };
                MongoConnectionConfig.MongoConfig.ConnectionList[newConfig.ConnectionName] = newConfig;
                MongoConnectionConfig.MongoConfig.SaveMongoConfig();
                RuntimeMongoDbContext.MongoConnSvrLst.Remove(newConfig.ConnectionName);
                RuntimeMongoDbContext.MongoConnSvrLst.Add(
                    RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName,
                    RuntimeMongoDbContext.CreateMongoServer(ref newConfig));
                return true;

            }
            strMessage = result.ErrorMessage;
            return false;
        }

        public static void ReplicaSet(MongoConnectionConfig newConfig)
        {
            MongoConnectionConfig.MongoConfig.ConnectionList[newConfig.ConnectionName] = newConfig;
            MongoConnectionConfig.MongoConfig.SaveMongoConfig();
            RuntimeMongoDbContext.MongoConnSvrLst.Remove(newConfig.ConnectionName);
            RuntimeMongoDbContext.MongoConnSvrLst.Add(
                RuntimeMongoDbContext.CurrentMongoConnectionconfig.ConnectionName,
                RuntimeMongoDbContext.CreateMongoServer(ref newConfig));
        }

        public static bool IsDatabaseNameValid(string strDBName, out string errMessage)
        {
            return RuntimeMongoDbContext.GetCurrentServer().IsDatabaseNameValid(strDBName, out errMessage);
        }

        public static void ResyncCommand(){
            CommandHelper.ExecuteMongoCommand(CommandHelper.ResyncCommand);
        }
        public static void RepairDB()
        {
            CommandHelper.ExecuteMongoCommand(CommandHelper.RepairDatabaseCommand);
        }
        public static void ReIndex()
        {
            RuntimeMongoDbContext.GetCurrentCollection().ReIndex();
        }
        public static void Compact()
        {
            CommandHelper.ExecuteMongoCommand(CommandHelper.CompactCommand);
        }
    }
}
