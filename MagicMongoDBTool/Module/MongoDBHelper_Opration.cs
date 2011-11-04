using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
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
        /// <param name="strSvrPathWithTag"></param>
        /// <param name="dbName"></param>
        /// <param name="func"></param>
        /// <param name="tr"></param>
        /// <returns></returns>
        public static Boolean DataBaseOpration(String strSvrPathWithTag, string dbName, Oprcode func, TreeNode tr)
        {
            Boolean rtnResult = false;
            MongoServer mongoSvr = GetMongoServerBySvrPath(strSvrPathWithTag);
            string strSvrPath = strSvrPathWithTag.Split(":".ToCharArray())[1];
            string svrKey = strSvrPath.Split("/".ToCharArray())[0];
            if (mongoSvr != null)
            {
                switch (func)
                {
                    case Oprcode.Create:
                        if (!mongoSvr.DatabaseExists(dbName))
                        {
                            mongoSvr.GetDatabase(dbName);
                            tr.Nodes.Add(FillDataBaseInfoToTreeNode(dbName, mongoSvr, svrKey));
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
        /// 数据集操作
        /// </summary>
        /// <param name="strSvrPathWithTag"></param>
        /// <param name="collectionName"></param>
        /// <param name="func"></param>
        /// <param name="treeNode"></param>
        /// <param name="newCollectionName"></param>
        /// <returns></returns>
        public static Boolean CollectionOpration(string strSvrPathWithTag, string collectionName, Oprcode func, TreeNode treeNode, string newCollectionName = "")
        {
            Boolean rtnResult = false;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strSvrPathWithTag);

            string strSvrPath = strSvrPathWithTag.Split(":".ToCharArray())[1];
            string svrkey = strSvrPath.Split("/".ToCharArray())[0];
            if (mongoDB != null)
            {
                switch (func)
                {
                    case Oprcode.Create:
                        if (!mongoDB.CollectionExists(collectionName))
                        {
                            mongoDB.CreateCollection(collectionName);
                            treeNode.Nodes.Add(FillCollectionInfoToTreeNode(collectionName, mongoDB, svrkey));
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Drop:
                        if (mongoDB.CollectionExists(collectionName))
                        {
                            mongoDB.DropCollection(collectionName);
                            treeNode.TreeView.Nodes.Remove(treeNode);
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Rename:
                        if (!mongoDB.CollectionExists(newCollectionName))
                        {
                            mongoDB.RenameCollection(collectionName, newCollectionName);
                            treeNode.Text = newCollectionName;
                            //添加新节点
                            treeNode.Parent.Nodes.Add(FillCollectionInfoToTreeNode(newCollectionName, mongoDB, svrkey));
                            //删除旧节点
                            treeNode.TreeView.Nodes.Remove(treeNode);
                            rtnResult = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            return rtnResult;
        }
        /// <summary>
        /// 根据路径字符获得服务器
        /// </summary>
        /// <param name="strSvrPathWithTag">[Service/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoServer GetMongoServerBySvrPath(string strSvrPathWithTag)
        {
            MongoServer rtnMongoSvr = null;
            String strSvrPath = strSvrPathWithTag.Split(":".ToCharArray())[1];
            String[] strPath = strSvrPath.Split("/".ToCharArray());
            if (strPath.Length > 0)
            {
                if (_mongoSrvLst.ContainsKey(strPath[(int)PathLv.ServerLV]))
                {
                    rtnMongoSvr = _mongoSrvLst[strPath[(int)PathLv.ServerLV]];
                }
            }
            return rtnMongoSvr;
        }
        /// <summary>
        /// 根据路径字符获得数据库
        /// </summary>
        /// <param name="strSvrPath">[Service/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoDatabase GetMongoDBBySvrPath(String strSvrPathWithTag)
        {
            MongoDatabase rtnMongoDB = null;
            MongoServer mongoSvr = GetMongoServerBySvrPath(strSvrPathWithTag);
            if (mongoSvr != null)
            {
                String strTag = strSvrPathWithTag.Split(":".ToCharArray())[0];
                String strSvrPath = strSvrPathWithTag.Split(":".ToCharArray())[1];
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
        /// <param name="strSvrPath"></param>
        /// <returns></returns>
        public static MongoCollection GetMongoCollectionBySvrPath(String strSvrPathWithTag)
        {
            MongoCollection rtnMongoCollection = null;
            MongoDatabase mongoDB = GetMongoDBBySvrPath(strSvrPathWithTag);
            if (mongoDB != null)
            {
                string strSvrPath = strSvrPathWithTag.Split(":".ToCharArray())[1];
                string[] strPathArray = strSvrPath.Split("/".ToCharArray());
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
        public static Boolean CreateMongoIndex(String[] AscendingKey, String[] DescendingKey,
            Boolean IsBackground = false, Boolean IsDropDups = false, Boolean IsSparse = false, Boolean IsUnique = false, String IndexName = "")
        {
            MongoCollection mongoCol = SystemManager.GetCurrentCollection();
            IndexKeysBuilder indexkeys = new IndexKeysBuilder();
            indexkeys.Ascending(AscendingKey);
            indexkeys.Descending(DescendingKey);
            IndexOptionsBuilder option = new IndexOptionsBuilder();
            option.SetBackground(IsBackground);
            option.SetDropDups(IsDropDups);
            option.SetSparse(IsSparse);
            option.SetUnique(IsUnique);
            if (IndexName != String.Empty && !mongoCol.IndexExists(IndexName))
            {
                option.SetName(IndexName);
            }
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
        public static Boolean SaveJavascript(string jsName, string jsCode)
        {
            //标准的JS库格式未知
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (!IsExistByField(jsCol, jsName))
            {
                jsCol.Insert<BsonDocument>(new BsonDocument().Add("_id", jsName).Add("value", jsCode));
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获得JS代码
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static String LoadJavascript(string jsName)
        {
            MongoCollection jsCol = SystemManager.GetCurrentJsCollection();
            if (IsExistByField(jsCol, jsName))
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
        public static Boolean DropRecord(MongoCollection mongoCol, object strKey, string keyField = "_id")
        {
            if (IsExistByField(mongoCol, (BsonValue)strKey, keyField))
            {
                mongoCol.Remove(Query.EQ(keyField, (BsonValue)strKey));
            }
            return true;
        }

        ///在使用GirdFileSystem的时候，请注意：
        ///1.Windows 系统的文件名不区分大小写，不过，filename一定是区分大小写的，如果大小写不匹配的话，会发生无法找到文件的问题
        ///2.Download的时候，不能使用SlaveOk选项！

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void OpenFile(string strRemoteFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());

            String[] strLocalFileName = strRemoteFileName.Split(@"\".ToCharArray());
            try
            {
                gfs.Download(strLocalFileName[strLocalFileName.Length - 1], strRemoteFileName);
                System.Diagnostics.Process.Start(strLocalFileName[strLocalFileName.Length - 1]);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DownloadFile(string strLocalFileName, string strRemoteFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Download(strLocalFileName, strRemoteFileName);
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void UpLoadFile(string strFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Upload(strFileName);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DelFile(string strFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Delete(strFileName);
        }
        /// <summary>
        /// GFS初始化
        /// </summary>
        public static void InitGFS()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(COLLECTION_NAME_GFS_FILES))
            {
                mongoDB.CreateCollection(COLLECTION_NAME_GFS_FILES);
            }
        }

    }
}
