using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Extend
{
    public static class OperationHelper
    {
        /// <summary>
        ///     操作模式
        /// </summary>
        public enum Oprcode
        {
            /// <summary>
            ///     新建
            /// </summary>
            Create,

            /// <summary>
            ///     删除
            /// </summary>
            Drop,

            /// <summary>
            ///     压缩
            /// </summary>
            Repair,

            /// <summary>
            ///     重命名
            /// </summary>
            Rename
        }

        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static bool IsSystemCollection(MongoCollection mongoCol)
        {
            //http://docs.mongodb.org/manual/reference/system-collections/
            return IsSystemCollection(mongoCol.Database.Name, mongoCol.Name);
        }

        public static bool IsSystemCollection()
        {
            var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            //http://docs.mongodb.org/manual/reference/system-collections/
            return IsSystemCollection(mongoCol.Database.Name, mongoCol.Name);
        }

        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoDbName"></param>
        /// <param name="mongoColName"></param>
        /// <returns></returns>
        public static bool IsSystemCollection(string mongoDbName, string mongoColName)
        {
            //config数据库,默认为系统
            //local数据库,默认为系统
            //系统文件
            if (mongoColName.StartsWith("system."))
                return true;
            if (mongoColName.StartsWith("fs."))
                return true;
            return IsSystemDataBase(mongoDbName);
        }

        /// <summary>
        ///     是否为系统数据库[无法删除]
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static bool IsSystemDataBase(string dataBaseName)
        {
            //config数据库,默认为系统
            //admin数据库,默认为系统
            //local数据库,默认为系统
            switch (dataBaseName)
            {
                case ConstMgr.DatabaseNameLocal:
                case ConstMgr.DatabaseNameConfig:
                case ConstMgr.DatabaseNameAdmin:
                    return true;
            }
            return false;
        }

        /// <summary>
        ///     数据库操作
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="dbName"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static string DataBaseOpration(string strObjTag, string dbName, Oprcode func)
        {
            var mongoSvr = RuntimeMongoDbContext.GetCurrentServer();
            var rtnResult = string.Empty;
            TagInfo.GetTagData(strObjTag);
            if (mongoSvr == null) return rtnResult;
            switch (func)
            {
                case Oprcode.Create:
                    if (!mongoSvr.DatabaseExists(dbName))
                    {
                        //从权限上看，clusterAdmin是必须的
                        //但是能够建立数据库，不表示能够看到里面的内容！
                        //dbAdmin可以访问数据库。
                        //clusterAdmin能创建数据库但是不能访问数据库。
                        try
                        {
                            mongoSvr.GetDatabase(dbName);
                        }
                        catch (Exception ex)
                        {
                            //如果使用没有dbAdmin权限的clusterAdmin。。。。
                            Utility.ExceptionDeal(ex);
                        }
                    }
                    break;
                case Oprcode.Drop:
                    if (mongoSvr.DatabaseExists(dbName))
                    {
                        var result = mongoSvr.DropDatabase(dbName);
                        return !result.Response.Contains("err") ? string.Empty : result.Response["err"].ToString();
                    }
                    break;
                case Oprcode.Repair:
                    //其实Repair的入口不在这个方法里面
                    CommandHelper.ExecuteMongoDBCommand(CommandHelper.RepairDatabaseCommand,
                        mongoSvr.GetDatabase(dbName));
                    break;
            }
            return rtnResult;
        }

        /// <summary>
        ///     带有参数的CreateOption
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="collectionName"></param>
        /// <param name="option"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static bool CreateCollectionWithOptions(string strObjTag, string collectionName,
            CollectionOptionsBuilder option, MongoDatabase mongoDb)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            if (mongoDb == null) return false;
            if (mongoDb.CollectionExists(collectionName)) return false;
            mongoDb.CreateCollection(collectionName, option);
            return true;
        }
        /// <summary>
        ///     删除数据集
        /// </summary>
        /// <param name="strCollection"></param>
        /// <returns></returns>
        public static bool DrapCollection(string strCollection)
        {
            return RuntimeMongoDbContext.GetCurrentDataBase().DropCollection(strCollection).Ok;
        }
        /// <summary>
        ///     重命名数据集
        /// </summary>
        /// <param name="strCollection"></param>
        /// <param name="strNewCollectionName"></param>
        /// <returns></returns>
        public static bool RenameCollection(string strCollection, string strNewCollectionName)
        {
            return RuntimeMongoDbContext.GetCurrentDataBase().RenameCollection(strCollection, strNewCollectionName).Ok;
        }

        /// <summary>
        ///     Create Collection
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="collectionName"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static bool CreateCollection(string strObjTag, string collectionName, MongoDatabase mongoDb)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            if (mongoDb == null) return false;
            if (mongoDb.CollectionExists(collectionName)) return false;
            mongoDb.CreateCollection(collectionName);
            return true;
        }

        /// <summary>
        ///     获得Shard情报
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetShardInfo(MongoServer server, string key)
        {
            var shardInfo = new Dictionary<string, string>();
            if (!server.DatabaseExists(ConstMgr.DatabaseNameConfig)) return shardInfo;
            var configdb = server.GetDatabase(ConstMgr.DatabaseNameConfig);
            if (!configdb.CollectionExists("shards")) return shardInfo;
            foreach (var item in configdb.GetCollection("shards").FindAll().ToList())
            {
                shardInfo.Add(item.GetElement(ConstMgr.KeyId).Value.ToString(),
                    item.GetElement(key).Value.ToString());
            }
            return shardInfo;
        }

        /// <summary>
        ///     添加索引
        /// </summary>
        /// <param name="ascendingKey"></param>
        /// <param name="descendingKey"></param>
        /// <param name="geoSpatialKey"></param>
        /// <param name="option"></param>
        /// <param name="currentCollection"></param>
        /// <returns></returns>
        public static bool CreateMongoIndex(string[] ascendingKey, string[] descendingKey, string geoSpatialKey,
            IndexOptionsBuilder option, MongoCollection currentCollection)
        {
            var mongoCol = currentCollection;
            var indexkeys = new IndexKeysBuilder();
            if (!string.IsNullOrEmpty(geoSpatialKey))
            {
                indexkeys.GeoSpatial(geoSpatialKey);
            }
            indexkeys.Ascending(ascendingKey);
            indexkeys.Descending(descendingKey);
            mongoCol.CreateIndex(indexkeys, option);
            return true;
        }

        /// <summary>
        ///     删除索引[KEY_ID]以外
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static bool DropMongoIndex(string indexName, MongoCollection mongoCol)
        {
            if (indexName == ConstMgr.KeyId)
            {
                return false;
            }
            if (mongoCol.IndexExistsByName(indexName))
            {
                mongoCol.DropIndexByName(indexName);
            }
            return true;
        }

        /// <summary>
        ///     插入JS到系统JS库
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        public static string CreateNewJavascript(string jsName, string jsCode)
        {
            var jsCol = RuntimeMongoDbContext.GetCurrentCollection();
            //标准的JS库格式未知
            if (QueryHelper.IsExistByKey(jsName)) return string.Empty;
            CommandResult result;
            try
            {
                result =
                    new CommandResult(
                        jsCol.Insert(new BsonDocument().Add(ConstMgr.KeyId, jsName).Add("value", jsCode)).Response);
            }
            catch (MongoCommandException ex)
            {
                result = new CommandResult(ex.Result);
            }
            return result.Response["err"] == BsonNull.Value ? string.Empty : result.Response["err"].ToString();
        }

        /// <summary>
        ///     Save Edited Javascript
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        /// <param name="jsCol"></param>
        /// <returns></returns>
        public static string SaveEditorJavascript(string jsName, string jsCode, MongoCollection jsCol)
        {
            //标准的JS库格式未知
            if (QueryHelper.IsExistByKey(jsName))
            {
                var result = DropDocument(jsCol, (BsonString) jsName);
                if (string.IsNullOrEmpty(result))
                {
                    CommandResult resultCommand;
                    try
                    {
                        resultCommand = new CommandResult(
                            jsCol.Insert(new BsonDocument().Add(ConstMgr.KeyId, jsName).Add("value", jsCode)).Response);
                    }
                    catch (MongoCommandException ex)
                    {
                        resultCommand = new CommandResult(ex.Result);
                    }
                    if (resultCommand.Response["err"] == BsonNull.Value)
                    {
                        return string.Empty;
                    }
                    return resultCommand.Response["err"].ToString();
                }
                return result;
            }
            return string.Empty;
        }

        /// <summary>
        ///     Delete Javascript Collection Document
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static string DelJavascript(string jsName)
        {
            var jsCol = RuntimeMongoDbContext.GetCurrentCollection();
            return QueryHelper.IsExistByKey(jsName) ? DropDocument(jsCol, (BsonString) jsName) : string.Empty;
        }

        /// <summary>
        ///     获得JS代码
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCol"></param>
        /// <returns></returns>
        public static string LoadJavascript(string jsName, MongoCollection jsCol)
        {
            return QueryHelper.IsExistByKey(jsName) ? jsCol.FindOneAs<BsonDocument>(Query.EQ(ConstMgr.KeyId, jsName)).GetValue("value").ToString() : string.Empty;
        }

        /// <summary>
        ///     删除数据
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DropDocument(MongoCollection mongoCol, object strKey)
        {
            var result = new CommandResult(new BsonDocument());
            if (QueryHelper.IsExistByKey(strKey.ToString()))
            {
                try
                {
                    result =
                        new CommandResult(
                            mongoCol.Remove(Query.EQ(ConstMgr.KeyId, (BsonValue) strKey), WriteConcern.Acknowledged)
                                .Response);
                }
                catch (MongoCommandException ex)
                {
                    result = new CommandResult(ex.Result);
                }
            }
            BsonElement err;
            return !result.Response.TryGetElement("err", out err) ? string.Empty : err.ToString();
        }

        /// <summary>
        ///     插入空文档
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="safeMode"></param>
        /// <returns>插入记录的ID</returns>
        public static BsonValue InsertEmptyDocument(MongoCollection mongoCol, bool safeMode)
        {
            var document = new BsonDocument();
            if (safeMode)
            {
                try
                {
                    mongoCol.Insert(document, WriteConcern.Acknowledged);
                    return document.GetElement(ConstMgr.KeyId).Value;
                }
                catch (Exception)
                {
                    return BsonNull.Value;
                }
            }
            mongoCol.Insert(document);
            return document.GetElement(ConstMgr.KeyId).Value;
        }
    }
}