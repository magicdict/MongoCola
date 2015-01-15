using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using Utility = Common.Utility;

namespace MongoUtility.Operation
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
        public static Boolean IsSystemCollection(MongoCollection mongoCol)
        {
            //http://docs.mongodb.org/manual/reference/system-collections/
            return IsSystemCollection(mongoCol.Database.Name, mongoCol.Name);
        }

        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoDBName"></param>
        /// <param name="mongoColName"></param>
        /// <returns></returns>
        public static Boolean IsSystemCollection(String mongoDBName, String mongoColName)
        {
            //config数据库,默认为系统
            //local数据库,默认为系统
            //系统文件
            if (mongoColName.StartsWith("system."))
                return true;
            if (mongoColName.StartsWith("fs."))
                return true;
            return IsSystemDataBase(mongoDBName);
        }

        /// <summary>
        ///     是否为系统数据库[无法删除]
        /// </summary>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static Boolean IsSystemDataBase(String DataBaseName)
        {
            //local数据库,默认为系统
            if (DataBaseName == ConstMgr.DATABASE_NAME_LOCAL)
            {
                return true;
            }
            //config数据库,默认为系统
            if (DataBaseName == ConstMgr.DATABASE_NAME_CONFIG)
            {
                return true;
            }
            //admin数据库,默认为系统
            if (DataBaseName == ConstMgr.DATABASE_NAME_ADMIN)
            {
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
        /// <param name="tr"></param>
        /// <returns></returns>
        public static String DataBaseOpration(String strObjTag,
            String dbName,
            Oprcode func,
            MongoServer mongoSvr)
        {
            var rtnResult = String.Empty;
            var strSvrPath = Utility.GetTagData(strObjTag);
            var result = new CommandResult(new BsonDocument());
            if (mongoSvr != null)
            {
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
                                //tr.Nodes.Add(UIHelper.FillDataBaseInfoToTreeNode(dbName, mongoSvr, svrKey + "/" + svrKey));
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
                            result = mongoSvr.DropDatabase(dbName);
//                            if (tr != null)
//                            {
//                                tr.TreeView.Nodes.Remove(tr);
//                            }
                            if (!result.Response.Contains("err"))
                            {
                                return String.Empty;
                            }
                            return result.Response["err"].ToString();
                        }
                        break;
                    case Oprcode.Repair:
                        //其实Repair的入口不在这个方法里面
                        CommandHelper.ExecuteMongoDBCommand(CommandHelper.repairDatabase_Command,
                            mongoSvr.GetDatabase(dbName));
                        break;
                    default:
                        break;
                }
            }
            return rtnResult;
        }

        /// <summary>
        ///     带有参数的CreateOption
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="treeNode"></param>
        /// <param name="collectionName"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static Boolean CreateCollectionWithOptions(String strObjTag, String collectionName,
            CollectionOptionsBuilder option, MongoDatabase mongoDB)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            var rtnResult = false;
            var strSvrPath = Utility.GetTagData(strObjTag);
            if (mongoDB != null)
            {
                if (!mongoDB.CollectionExists(collectionName))
                {
                    mongoDB.CreateCollection(collectionName, option);
//                    foreach (TreeNode item in treeNode.Nodes)
//                    {
//                        if (item.Tag.ToString().StartsWith(COLLECTION_LIST_TAG))
//                        {
//                            item.Nodes.Add(UIHelper.FillCollectionInfoToTreeNode(collectionName, mongoDB, ConKey + "/" + svrKey));
//                        }
//                    }
                    rtnResult = true;
                }
            }
            return rtnResult;
        }

        /// <summary>
        ///     Create Collection
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="treeNode"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static Boolean CreateCollection(String strObjTag, String collectionName, MongoDatabase mongoDB)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            var rtnResult = false;
            var strSvrPath = Utility.GetTagData(strObjTag);
            if (mongoDB != null)
            {
                if (!mongoDB.CollectionExists(collectionName))
                {
                    mongoDB.CreateCollection(collectionName);
//                    foreach (TreeNode item in treeNode.Nodes)
//                    {
//                        if (item.Tag.ToString().StartsWith(COLLECTION_LIST_TAG))
//                        {
//                            item.Nodes.Add(UIHelper.FillCollectionInfoToTreeNode(collectionName, mongoDB, ConKey + "/" + svrKey));
//                        }
//                    }
                    rtnResult = true;
                }
            }
            return rtnResult;
        }

        /// <summary>
        ///     获得Shard情报
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, String> GetShardInfo(MongoServer server, String Key)
        {
            var ShardInfo = new Dictionary<String, String>();
            if (server.DatabaseExists(ConstMgr.DATABASE_NAME_CONFIG))
            {
                var configdb = server.GetDatabase(ConstMgr.DATABASE_NAME_CONFIG);
                if (configdb.CollectionExists("shards"))
                {
                    foreach (var item in configdb.GetCollection("shards").FindAll().ToList())
                    {
                        ShardInfo.Add(item.GetElement(ConstMgr.KEY_ID).Value.ToString(),
                            item.GetElement(Key).Value.ToString());
                    }
                }
            }
            return ShardInfo;
        }

        /// <summary>
        ///     添加索引
        /// </summary>
        /// <param name="AscendingKey"></param>
        /// <param name="DescendingKey"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static Boolean CreateMongoIndex(String[] AscendingKey, String[] DescendingKey, String GeoSpatialKey,
            IndexOptionsBuilder option, MongoCollection CurrentCollection)
        {
            var mongoCol = CurrentCollection;
            var indexkeys = new IndexKeysBuilder();
            if (!String.IsNullOrEmpty(GeoSpatialKey))
            {
                indexkeys.GeoSpatial(GeoSpatialKey);
            }
            indexkeys.Ascending(AscendingKey);
            indexkeys.Descending(DescendingKey);
            mongoCol.CreateIndex(indexkeys, option);
            return true;
        }

        /// <summary>
        ///     删除索引[KEY_ID]以外
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public static Boolean DropMongoIndex(String indexName, MongoCollection mongoCol)
        {
            if (indexName == ConstMgr.KEY_ID)
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
        public static String CreateNewJavascript(String jsName, String jsCode, MongoCollection jsCol)
        {
            //标准的JS库格式未知
            if (!QueryHelper.IsExistByKey(jsCol, jsName))
            {
                var result = new CommandResult(new BsonDocument());
                try
                {
                    result = jsCol.Insert(new BsonDocument().Add(ConstMgr.KEY_ID, jsName).Add("value", jsCode));
                }
                catch (MongoCommandException ex)
                {
                    result = ex.CommandResult;
                }
                if (result.Response["err"] == BsonNull.Value)
                {
                    return String.Empty;
                }
                return result.Response["err"].ToString();
            }
            return String.Empty;
        }

        /// <summary>
        ///     Save Edited Javascript
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        /// <returns></returns>
        public static String SaveEditorJavascript(String jsName, String jsCode, MongoCollection jsCol)
        {
            //标准的JS库格式未知
            if (QueryHelper.IsExistByKey(jsCol, jsName))
            {
                var result = DropDocument(jsCol, (BsonString) jsName);
                if (String.IsNullOrEmpty(result))
                {
                    var resultCommand = new CommandResult(new BsonDocument());
                    try
                    {
                        resultCommand =
                            jsCol.Insert(new BsonDocument().Add(ConstMgr.KEY_ID, jsName).Add("value", jsCode));
                    }
                    catch (MongoCommandException ex)
                    {
                        resultCommand = ex.CommandResult;
                    }
                    if (resultCommand.Response["err"] == BsonNull.Value)
                    {
                        return String.Empty;
                    }
                    return resultCommand.Response["err"].ToString();
                }
                return result;
            }
            return String.Empty;
        }

        /// <summary>
        ///     Delete Javascript Collection Document
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static String DelJavascript(String jsName, MongoCollection jsCol)
        {
            if (QueryHelper.IsExistByKey(jsCol, jsName))
            {
                return DropDocument(jsCol, (BsonString) jsName);
            }
            return String.Empty;
        }

        /// <summary>
        ///     获得JS代码
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static String LoadJavascript(String jsName, MongoCollection jsCol)
        {
            if (QueryHelper.IsExistByKey(jsCol, jsName))
            {
                return jsCol.FindOneAs<BsonDocument>(Query.EQ(ConstMgr.KEY_ID, jsName)).GetValue("value").ToString();
            }
            return String.Empty;
        }

        /// <summary>
        ///     删除数据
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static String DropDocument(MongoCollection mongoCol, object strKey)
        {
            var result = new CommandResult(new BsonDocument());
            if (QueryHelper.IsExistByKey(mongoCol, (BsonValue) strKey))
            {
                try
                {
                    result = mongoCol.Remove(Query.EQ(ConstMgr.KEY_ID, (BsonValue) strKey), WriteConcern.Acknowledged);
                }
                catch (MongoCommandException ex)
                {
                    result = ex.CommandResult;
                }
            }
            if (result.Response["err"] == BsonNull.Value)
            {
                return String.Empty;
            }
            return result.Response["err"].ToString();
        }

        /// <summary>
        ///     插入空文档
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <returns>插入记录的ID</returns>
        public static BsonValue InsertEmptyDocument(MongoCollection mongoCol, Boolean safeMode)
        {
            var document = new BsonDocument();
            if (safeMode)
            {
                try
                {
                    mongoCol.Insert(document, WriteConcern.Acknowledged);
                    return document.GetElement(ConstMgr.KEY_ID).Value;
                }
                catch (Exception)
                {
                    return BsonNull.Value;
                }
            }
            mongoCol.Insert(document);
            return document.GetElement(ConstMgr.KEY_ID).Value;
        }
    }
}