using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Bson.Serialization;
using System.IO;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// 操作模式
        /// </summary>
        public enum Oprcode
        {
            /// <summary>
            /// 新建
            /// </summary>
            Create,
            /// <summary>
            /// 删除
            /// </summary>
            Drop,
            /// <summary>
            /// 压缩
            /// </summary>
            Repair,
            /// <summary>
            /// 重命名
            /// </summary>
            Rename
        }
        /// <summary>
        /// 是否为系统数据集[无法删除]
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
        /// 是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static Boolean IsSystemCollection(String mongoDBName, String mongoColName)
        {
            //系统
            if (mongoColName.StartsWith("system."))
            {
                return true;
            }
            //文件
            if (mongoColName.StartsWith("fs."))
            {
                return true;
            }
            //local数据库,默认为系统
            if (mongoDBName == "local")
            {
                return true;
            }
            //config数据库,默认为系统
            if (mongoDBName == "config")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 是否为系统数据库[无法删除]
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
            if (mongoDB.Name == "admin")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 数据库操作
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="dbName"></param>
        /// <param name="func"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public static Boolean DataBaseOpration(String strObjTag, String dbName, Oprcode func, TreeNode tr)
        {
            Boolean rtnResult = false;
            MongoServer mongoSvr = GetMongoServerBySvrPath(strObjTag);
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String svrKey = strSvrPath.Split("/".ToCharArray())[(int)PathLv.ServerLV];
            if (mongoSvr != null)
            {
                switch (func)
                {
                    case Oprcode.Create:
                        if (!mongoSvr.DatabaseExists(dbName))
                        {
                            mongoSvr.GetDatabase(dbName);
                            tr.Nodes.Add(FillDataBaseInfoToTreeNode(dbName, mongoSvr, svrKey + "/" + svrKey));
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Drop:
                        if (mongoSvr.DatabaseExists(dbName))
                        {
                            mongoSvr.DropDatabase(dbName);
                            if (tr != null)
                            {
                                tr.TreeView.Nodes.Remove(tr);
                            }
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Repair:
                        //How To Compress?Run Command？？    
                        break;
                    default:
                        break;
                }
            }
            return rtnResult;
        }

        /// <summary>
        /// 带有参数的CreateOption
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="treeNode"></param>
        /// <param name="collectionName"></param>
        /// <param name="IsCapped"></param>
        /// <param name="MaxSize"></param>
        /// <param name="IsAutoIndexId"></param>
        /// <param name="IsMaxDocument"></param>
        /// <returns></returns>
        public static Boolean CreateCollectionWithOptions(String strObjTag, TreeNode treeNode, String collectionName,
            Boolean IsCapped, long MaxSize, Boolean IsAutoIndexId, long IsMaxDocument)
        {
            Boolean rtnResult = false;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strObjTag);
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String svrKey = strSvrPath.Split("/".ToCharArray())[(int)PathLv.ServerLV];
            if (mongoDB != null)
            {
                if (!mongoDB.CollectionExists(collectionName))
                {
                    CollectionOptionsBuilder COB = new CollectionOptionsBuilder();
                    COB.SetCapped(IsCapped);
                    COB.SetMaxSize(MaxSize);
                    COB.SetAutoIndexId(IsAutoIndexId);
                    COB.SetMaxDocuments(IsMaxDocument);
                    mongoDB.CreateCollection(collectionName, COB);
                    foreach (TreeNode item in treeNode.Nodes)
                    {
                        if (item.Tag.ToString().StartsWith(COLLECTION_LIST_TAG))
                        {
                            item.Nodes.Add(FillCollectionInfoToTreeNode(collectionName, mongoDB, svrKey));
                        }
                    }
                    rtnResult = true;
                }
            }
            return rtnResult;
        }
        /// <summary>
        /// Create Collection
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="treeNode"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static Boolean CreateCollection(String strObjTag, TreeNode treeNode, String collectionName)
        {
            Boolean rtnResult = false;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strObjTag);
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String svrKey = strSvrPath.Split("/".ToCharArray())[(int)PathLv.ServerLV];
            if (mongoDB != null)
            {
                if (!mongoDB.CollectionExists(collectionName))
                {
                    mongoDB.CreateCollection(collectionName);
                    foreach (TreeNode item in treeNode.Nodes)
                    {
                        if (item.Tag.ToString().StartsWith(COLLECTION_LIST_TAG))
                        {
                            item.Nodes.Add(FillCollectionInfoToTreeNode(collectionName, mongoDB, svrKey));
                        }
                    }
                    rtnResult = true;
                }
            }
            return rtnResult;
        }

        /// <summary>
        /// 根据路径字符获得服务器
        /// </summary>
        /// <param name="strObjTag">[Tag:Connection/Host@Port/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoServer GetMongoServerBySvrPath(String strObjTag)
        {
            MongoServer rtnMongoSvr = null;
            String strSvrPath = SystemManager.GetTagData(strObjTag);
            String[] strPath = strSvrPath.Split("/".ToCharArray());
            String strInstKey = strPath[(int)PathLv.ConnectionLV] + "/" + strPath[(int)PathLv.ServerLV];
            if (strPath.Length > 0)
            {
                if (_mongoInstanceLst.ContainsKey(strInstKey))
                {
                    rtnMongoSvr = _mongoInstanceLst[strInstKey].Server;
                    return rtnMongoSvr;
                }
                strInstKey = strInstKey.Split("/".ToCharArray())[0];
                if (_mongoConnSvrLst.ContainsKey(strInstKey))
                {
                    rtnMongoSvr = _mongoConnSvrLst[strInstKey];
                    return rtnMongoSvr;
                }
            }
            return rtnMongoSvr;
        }
        /// <summary>
        /// 根据路径字符获得数据库
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
                    rtnMongoDB = mongoSvr.GetDatabase(strPathArray[(int)PathLv.DatabaseLV]);
                }
            }
            return rtnMongoDB;
        }
        /// <summary>
        /// 通过路径获得数据集
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
                rtnMongoCollection = mongoDB.GetCollection(strPathArray[(int)PathLv.CollectionLV]);
            }
            return rtnMongoCollection;
        }
        /// <summary>
        /// 添加索引
        /// </summary>
        /// <param name="AscendingKey"></param>
        /// <param name="DescendingKey"></param>
        /// <param name="IsBackground"></param>
        /// <param name="IsDropDups"></param>
        /// <param name="IsSparse"></param>
        /// <param name="IsUnique"></param>
        /// <param name="IndexName"></param>
        /// <returns></returns>
        public static Boolean CreateMongoIndex(String[] AscendingKey, String[] DescendingKey,IndexOptionsBuilder option)
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            IndexKeysBuilder indexkeys = new IndexKeysBuilder();
            indexkeys.Ascending(AscendingKey);
            indexkeys.Descending(DescendingKey);
            mongoCol.CreateIndex(indexkeys, option);
            return true;
        }
        /// <summary>
        /// 删除索引["_id"]以外
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public static Boolean DropMongoIndex(String indexName)
        {
            if (indexName == "_id") { return false; }
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            if (mongoCol.IndexExistsByName(indexName))
            {
                mongoCol.DropIndexByName(indexName);
            }
            return true;
        }
        /// <summary>
        /// 插入JS到系统JS库
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        public static Boolean CreateNewJavascript(String jsName, String jsCode)
        {
            //标准的JS库格式未知
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (!IsExistByKey(jsCol, jsName))
            {
                jsCol.Insert<BsonDocument>(new BsonDocument().Add("_id", jsName).Add("value", jsCode));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Save Edited Javascript
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        /// <returns></returns>
        public static Boolean SaveEditorJavascript(String jsName, String jsCode)
        {
            //标准的JS库格式未知
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (IsExistByKey(jsCol, jsName))
            {
                if (DropDocument(jsCol, (BsonString)jsName))
                {
                    jsCol.Insert<BsonDocument>(new BsonDocument().Add("_id", jsName).Add("value", jsCode));
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Delete Javascript Collection Document
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static Boolean DelJavascript(String jsName)
        {
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (MongoDBHelper.IsExistByKey(jsCol, jsName))
            {
                return MongoDBHelper.DropDocument(jsCol, (BsonString)jsName);
            }
            return false;
        }
        /// <summary>
        /// 获得JS代码
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static String LoadJavascript(String jsName)
        {
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (IsExistByKey(jsCol, jsName))
            {
                return jsCol.FindOneAs<BsonDocument>(Query.EQ("_id", jsName)).GetValue("value").ToString();
            }
            return String.Empty;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="strKey"></param>
        /// <param name="keyField"></param>
        /// <returns></returns>
        public static Boolean DropDocument(MongoCollection mongoCol, object strKey)
        {
            if (IsExistByKey(mongoCol, (BsonValue)strKey, "_id"))
            {
                try
                {
                    mongoCol.Remove(Query.EQ("_id", (BsonValue)strKey), new SafeMode(true));
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 插入空文档
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <returns>插入记录的ID</returns>
        public static BsonValue InsertEmptyDocument(MongoCollection mongoCol, Boolean safeMode)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412 
            //collection names are limited to 121 bytes after converting to UTF-8. 
            BsonDocument document = new BsonDocument();
            if (safeMode)
            {
                try
                {
                    mongoCol.Insert<BsonDocument>(document, new SafeMode(true));
                    return document.GetElement("_id").Value;
                }
                catch (Exception)
                {
                    return BsonNull.Value;
                }
            }
            else
            {
                mongoCol.Insert<BsonDocument>(document);
                return document.GetElement("_id").Value;
            }
        }
    }
}
