using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDbHelper
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
            //系统
            if (mongoCol.Name.StartsWith("system."))
            {
                return true;
            }
            //文件
            if (mongoCol.Name.StartsWith("fs."))
            {
                return true;
            }
            //local数据库,默认为系统
            if (mongoCol.Database.Name == "local")
            {
                return true;
            }
            //config数据库,默认为系统
            if (mongoCol.Database.Name == "config")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoDBName"></param>
        /// <param name="mongoColName"></param>
        /// <returns></returns>
        public static Boolean IsSystemCollection(String mongoDBName, String mongoColName)
        {
            //系统
            if (mongoColName.StartsWith("system.")) return true;
            if (mongoColName.StartsWith("fs.")) return true;
            if (mongoDBName == "local") return true;
            if (mongoDBName != "config") return false;
            return true;
            //config数据库,默认为系统
            //local数据库,默认为系统
            //文件
        }

        /// <summary>
        ///     是否为系统数据库[无法删除]
        /// </summary>
        /// <param name="mongoDB"></param>
        /// <returns></returns>
        public static Boolean IsSystemDataBase(MongoDatabase mongoDB)
        {
            //local数据库,默认为系统
            if (mongoDB.Name == "local")
            {
                return true;
            }
            //config数据库,默认为系统
            if (mongoDB.Name == "config")
            {
                return true;
            }
            //admin数据库,默认为系统
            if (mongoDB.Name == DATABASE_NAME_ADMIN)
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
        public static String DataBaseOpration(String strObjTag, String dbName, Oprcode func, TreeNode tr)
        {
            String rtnResult = String.Empty;
            MongoServer mongoSvr = GetMongoServerBySvrPath(strObjTag);
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String svrKey = strSvrPath.Split("/".ToCharArray())[(int) PathLv.InstanceLv];
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
                                tr.Nodes.Add(UIHelper.FillDataBaseInfoToTreeNode(dbName, mongoSvr, svrKey + "/" + svrKey));
                            }
                            catch (Exception ex)
                            {
                                //如果使用没有dbAdmin权限的clusterAdmin。。。。
                                SystemManager.ExceptionDeal(ex);
                            }
                        }
                        break;
                    case Oprcode.Drop:
                        if (mongoSvr.DatabaseExists(dbName))
                        {
                            result = mongoSvr.DropDatabase(dbName);
                            if (tr != null)
                            {
                                tr.TreeView.Nodes.Remove(tr);
                            }
                            if (!result.Response.Contains("err"))
                            {
                                return String.Empty;
                            }
                            return result.Response["err"].ToString();
                        }
                        break;
                    case Oprcode.Repair:
                        //其实Repair的入口不在这个方法里面
                        ExecuteMongoDBCommand(repairDatabase_Command, SystemManager.GetCurrentDataBase());
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
        public static Boolean CreateCollectionWithOptions(String strObjTag, TreeNode treeNode, String collectionName,
            CollectionOptionsBuilder option)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            Boolean rtnResult = false;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strObjTag);
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String svrKey = strSvrPath.Split("/".ToCharArray())[(int) PathLv.InstanceLv];
            String ConKey = strSvrPath.Split("/".ToCharArray())[(int) PathLv.ConnectionLv];
            if (mongoDB != null)
            {
                if (!mongoDB.CollectionExists(collectionName))
                {
                    mongoDB.CreateCollection(collectionName, option);
                    foreach (TreeNode item in treeNode.Nodes)
                    {
                        if (item.Tag.ToString().StartsWith(COLLECTION_LIST_TAG))
                        {
                            item.Nodes.Add(UIHelper.FillCollectionInfoToTreeNode(collectionName, mongoDB, ConKey + "/" + svrKey));
                        }
                    }
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
        public static Boolean CreateCollection(String strObjTag, TreeNode treeNode, String collectionName)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            Boolean rtnResult = false;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strObjTag);
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String svrKey = strSvrPath.Split("/".ToCharArray())[(int) PathLv.InstanceLv];
            String ConKey = strSvrPath.Split("/".ToCharArray())[(int) PathLv.ConnectionLv];
            if (mongoDB != null)
            {
                if (!mongoDB.CollectionExists(collectionName))
                {
                    mongoDB.CreateCollection(collectionName);
                    foreach (TreeNode item in treeNode.Nodes)
                    {
                        if (item.Tag.ToString().StartsWith(COLLECTION_LIST_TAG))
                        {
                            item.Nodes.Add(UIHelper.FillCollectionInfoToTreeNode(collectionName, mongoDB, ConKey + "/" + svrKey));
                        }
                    }
                    rtnResult = true;
                }
            }
            return rtnResult;
        }

        /// <summary>
        ///     根据路径字符获得服务器
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoServer GetMongoServerBySvrPath(String strObjTag)
        {
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String[] strPath = strSvrPath.Split("/".ToCharArray());
            if (strPath.Length == 1)
            {
                //[Tag:Connection
                if (_mongoConnSvrLst.ContainsKey(strPath[0]))
                {
                    return _mongoConnSvrLst[strPath[0]];
                }
            }
            if (strPath.Length > 1)
            {
                if (strPath[0] == strPath[1])
                {
                    //[Tag:Connection/Connection/DBName/Collection]
                    return _mongoConnSvrLst[strPath[0]];
                }
                //[Tag:Connection/Host@Port/DBName/Collection]
                String strInstKey = String.Empty;
                strInstKey = strPath[(int) PathLv.ConnectionLv] + "/" + strPath[(int) PathLv.InstanceLv];
                if (_mongoInstanceLst.ContainsKey(strInstKey))
                {
                    MongoServerInstance mongoInstance = _mongoInstanceLst[strInstKey];
                    return MongoServer.Create(mongoInstance.Settings);
                }
            }
            return null;
        }

        /// <summary>
        ///     根据路径字符获得数据库
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoDatabase GetMongoDBBySvrPath(String strObjTag)
        {
            MongoDatabase rtnMongoDB = null;
            MongoServer mongoSvr = GetMongoServerBySvrPath(strObjTag);
            if (mongoSvr != null)
            {
                String strSvrPath = SystemManager.GetTagData(strObjTag);
                String[] strPathArray = strSvrPath.Split("/".ToCharArray());
                if (strPathArray.Length > 1)
                {
                    rtnMongoDB = mongoSvr.GetDatabase(strPathArray[(int) PathLv.DatabaseLv]);
                }
            }
            return rtnMongoDB;
        }

        /// <summary>
        ///     通过路径获得数据集
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoCollection GetMongoCollectionBySvrPath(String strObjTag)
        {
            MongoCollection rtnMongoCollection = null;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strObjTag);
            if (mongoDB != null)
            {
                String strSvrPath = SystemManager.GetTagData(strObjTag);
                String[] strPathArray = strSvrPath.Split("/".ToCharArray());
                rtnMongoCollection = mongoDB.GetCollection(strPathArray[(int) PathLv.CollectionLv]);
            }
            return rtnMongoCollection;
        }

        /// <summary>
        ///     获得Shard情报
        /// </summary>
        /// <returns></returns>
        public static Dictionary<String, String> GetShardInfo(MongoServer server, String Key)
        {
            var ShardInfo = new Dictionary<String, String>();
            if (server.DatabaseExists(DATABASE_NAME_CONFIG))
            {
                MongoDatabase configdb = server.GetDatabase(DATABASE_NAME_CONFIG);
                if (configdb.CollectionExists("shards"))
                {
                    foreach (BsonDocument item in configdb.GetCollection("shards").FindAll().ToList())
                    {
                        ShardInfo.Add(item.GetElement(KEY_ID).Value.ToString(), item.GetElement(Key).Value.ToString());
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
            IndexOptionsBuilder option)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            var indexkeys = new IndexKeysBuilder();
            if (!String.IsNullOrEmpty(GeoSpatialKey))
            {
                indexkeys.GeoSpatial(GeoSpatialKey);
            }
            indexkeys.Ascending(AscendingKey);
            indexkeys.Descending(DescendingKey);
            mongoCol.EnsureIndex(indexkeys, option);
            return true;
        }

        /// <summary>
        ///     删除索引[KEY_ID]以外
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public static Boolean DropMongoIndex(String indexName)
        {
            if (indexName == KEY_ID)
            {
                return false;
            }
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
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
        public static String CreateNewJavascript(String jsName, String jsCode)
        {
            //标准的JS库格式未知
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (!IsExistByKey(jsCol, jsName))
            {
                var result = new CommandResult(new BsonDocument());
                try
                {
                    result = jsCol.Insert(new BsonDocument().Add(KEY_ID, jsName).Add("value", jsCode));
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
        public static String SaveEditorJavascript(String jsName, String jsCode)
        {
            //标准的JS库格式未知
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (IsExistByKey(jsCol, jsName))
            {
                String result = DropDocument(jsCol, (BsonString) jsName);
                if (String.IsNullOrEmpty(result))
                {
                    var resultCommand = new CommandResult(new BsonDocument());
                    try
                    {
                        resultCommand = jsCol.Insert(new BsonDocument().Add(KEY_ID, jsName).Add("value", jsCode));
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
        public static String DelJavascript(String jsName)
        {
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (IsExistByKey(jsCol, jsName))
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
        public static String LoadJavascript(String jsName)
        {
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (IsExistByKey(jsCol, jsName))
            {
                return jsCol.FindOneAs<BsonDocument>(Query.EQ(KEY_ID, jsName)).GetValue("value").ToString();
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
            if (IsExistByKey(mongoCol, (BsonValue) strKey))
            {
                try
                {
                    result = mongoCol.Remove(Query.EQ(KEY_ID, (BsonValue) strKey), WriteConcern.Acknowledged);
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
                    return document.GetElement(KEY_ID).Value;
                }
                catch (Exception)
                {
                    return BsonNull.Value;
                }
            }
            mongoCol.Insert(document);
            return document.GetElement(KEY_ID).Value;
        }
    }
}