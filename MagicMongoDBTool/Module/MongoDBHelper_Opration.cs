using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
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
            if (mongoCol.Name.StartsWith("system.")) { return true; }
            //文件
            if (mongoCol.Name.StartsWith("fs.")) { return true; }
            //local数据库,默认为系统
            if (mongoCol.Database.Name == "local") { return true; }
            //config数据库,默认为系统
            if (mongoCol.Database.Name == "config") { return true; }
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
            if (mongoDB.Name == "local") { return true; }
            //config数据库,默认为系统
            if (mongoDB.Name == "config") { return true; }
            return false;
        }
        /// <summary>
        /// 数据库操作
        /// </summary>
        /// <param name="strSvrPath"></param>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public static Boolean DataBaseOpration(String strSvrPath, String DBName, Oprcode Func, TreeNode tr)
        {
            Boolean rtnResult = false;
            MongoServer Mongosrv = GetMongoServerBySvrPath(strSvrPath);
            if (Mongosrv != null)
            {
                switch (Func)
                {
                    case Oprcode.Create:
                        if (!Mongosrv.DatabaseExists(DBName))
                        {
                            Mongosrv.GetDatabase(DBName);
                            tr.Nodes.Add(FillDataBaseInfoToTreeNode(DBName, Mongosrv, strSvrPath.Split("/".ToCharArray())[0]));
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Drop:
                        if (Mongosrv.DatabaseExists(DBName))
                        {
                            Mongosrv.DropDatabase(DBName);
                            tr.TreeView.Nodes.Remove(tr);
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
        /// <param name="strSvrPath"></param>
        /// <param name="CollectionName"></param>
        /// <param name="Func"></param>
        /// <returns></returns>
        public static Boolean CollectionOpration(String strSvrPath, String CollectionName, Oprcode Func, TreeNode mTreenode,String NewCollectionName ="")
        {
            Boolean rtnResult = false;
            MongoDatabase Mongodb = GetMongoDBBySvrPath(strSvrPath);
            if (Mongodb != null)
            {
                switch (Func)
                {
                    case Oprcode.Create:
                        if (!Mongodb.CollectionExists(CollectionName))
                        {
                            Mongodb.CreateCollection(CollectionName);
                            mTreenode.Nodes.Add(FillCollectionInfoToTreeNode(CollectionName, Mongodb, strSvrPath.Split("/".ToCharArray())[0]));
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Drop:
                        if (Mongodb.CollectionExists(CollectionName))
                        {
                            Mongodb.DropCollection(CollectionName);
                            mTreenode.TreeView.Nodes.Remove(mTreenode);
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Rename:
                        if (!Mongodb.CollectionExists(NewCollectionName))
                        {
                            Mongodb.RenameCollection(CollectionName,NewCollectionName);
                            mTreenode.Text = NewCollectionName;
                            //添加新节点
                            mTreenode.Parent.Nodes.Add(FillCollectionInfoToTreeNode(NewCollectionName, Mongodb, strSvrPath.Split("/".ToCharArray())[0]));
                            //删除旧节点
                            mTreenode.TreeView.Nodes.Remove(mTreenode);
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
        /// <param name="strSvrPath">[Service/DBName/Collection]</param>
        /// <param name="WithTag">是否带有标签</param>
        /// <returns></returns>
        public static MongoServer GetMongoServerBySvrPath(String strSvrPath, Boolean WithTag = false)
        {
            if (WithTag)
            {
                strSvrPath = strSvrPath.Split(":".ToCharArray())[1];
            }
            MongoServer rtnMongoSrv = null;
            String[] strPath = strSvrPath.Split("/".ToCharArray());
            if (strPath.Length > 0)
            {
                if (mongosrvlst.ContainsKey(strPath[(int)PathLv.ServerLV]))
                {
                    rtnMongoSrv = mongosrvlst[strPath[(int)PathLv.ServerLV]];
                }
            }
            return rtnMongoSrv;
        }
        /// <summary>
        /// 根据路径字符获得数据库
        /// </summary>
        /// <param name="strSvrPath">[Service/DBName/Collection]</param>
        /// <param name="WithTag">是否带有标签</param>
        /// <returns></returns>
        public static MongoDatabase GetMongoDBBySvrPath(String strSvrPath, Boolean WithTag = false)
        {
            if (WithTag)
            {
                strSvrPath = strSvrPath.Split(":".ToCharArray())[1];
            }
            MongoDatabase rtnMongoDb = null;
            MongoServer MongoSrv = GetMongoServerBySvrPath(strSvrPath);
            if (MongoSrv != null)
            {
                String[] strPath = strSvrPath.Split("/".ToCharArray());
                if (strPath.Length > 1)
                {
                    if (MongoSrv.DatabaseExists(strPath[(int)PathLv.DatabaseLv]))
                    {
                        rtnMongoDb = MongoSrv.GetDatabase(strPath[(int)PathLv.DatabaseLv]);
                    }
                }
            }
            return rtnMongoDb;
        }
        /// <summary>
        /// 通过路径获得数据集
        /// </summary>
        /// <param name="strSvrPath"></param>
        /// <param name="WithTag"></param>
        /// <returns></returns>
        public static MongoCollection GetMongoCollectionBySvrPath(String strSvrPath, Boolean WithTag = false)
        {
            if (WithTag)
            {
                strSvrPath = strSvrPath.Split(":".ToCharArray())[1];
            }
            MongoCollection rtnMongoCollection = null;
            MongoServer MongoSrv = GetMongoServerBySvrPath(strSvrPath);
            if (MongoSrv != null)
            {
                String[] strPath = strSvrPath.Split("/".ToCharArray());
                if (strPath.Length > 1)
                {
                    if (MongoSrv.DatabaseExists(strPath[(int)PathLv.DatabaseLv]))
                    {
                        rtnMongoCollection = MongoSrv.GetDatabase(strPath[(int)PathLv.DatabaseLv]).GetCollection(strPath[(int)PathLv.CollectionLV]);
                    }
                }
            }
            return rtnMongoCollection;

        }
        /// <summary>
        /// 添加索引
        /// </summary>
        /// <param name="KeyName">索引名称</param>
        /// <param name="IsAccending">是否为升序</param>
        /// <returns></returns>
        public static Boolean CreateMongoIndex(String KeyName, Boolean IsAccending = true)
        {
            MongoCollection mongoCol = SystemManager.getCurrentCollection();
            IndexKeysDocument index = new IndexKeysDocument();
            if (!mongoCol.IndexExists(KeyName))
            {
                index.Add(KeyName, IsAccending ? 1 : 0);
                mongoCol.CreateIndex(index);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public static Boolean DropMongoIndex(String indexName)
        {
            MongoCollection mongoCol = SystemManager.getCurrentCollection();
            if (mongoCol.IndexExistsByName(indexName))
            {
                mongoCol.DropIndexByName(indexName);
            }
            return true;
        }
        /// <summary>
        /// 插入JS到系统JS库
        /// </summary>
        /// <param name="JsName"></param>
        /// <param name="JsCode"></param>
        public static Boolean SaveJavascript(String JsName, String JsCode)
        {
            //标准的JS库格式未知
            MongoCollection JsCol = SystemManager.getCurrentJsCollection();
            if (!IsExistByField(JsCol,JsName))
            {
                JsCol.Insert<BsonDocument>(new BsonDocument().Add("_id", JsName).Add("value", JsCode));
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获得JS代码
        /// </summary>
        /// <param name="JsName"></param>
        /// <returns></returns>
        public static String LoadJavascript(String JsName)
        {
            MongoCollection JsCol = SystemManager.getCurrentJsCollection();
            if (IsExistByField(JsCol, JsName))
            {
                return JsCol.FindOneAs<BsonDocument>(Query.EQ("_id", JsName)).GetValue("value").ToString();
            }
            return String.Empty;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="MongoCol"></param>
        /// <param name="strKey"></param>
        /// <param name="KeyField"></param>
        /// <returns></returns>
        public static Boolean DropRecord(MongoCollection MongoCol,Object strKey, String KeyField = "_id") {
            if (IsExistByField(MongoCol, (BsonValue)strKey, KeyField))
            {
                MongoCol.Remove(Query.EQ(KeyField, (BsonValue)strKey));
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
        public static void OpenFile(String strRemoteFileName)
        {
            MongoDatabase MongoDB = SystemManager.getCurrentDataBase();
            MongoGridFS gfs = MongoDB.GetGridFS(new MongoGridFSSettings());
            
            String[] strLocalFileName = strRemoteFileName.Split(@"\".ToCharArray());
            try
            {
                gfs.Download(strLocalFileName[strLocalFileName.Length - 1], strRemoteFileName);
                System.Diagnostics.Process.Start(strLocalFileName[strLocalFileName.Length - 1]);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DownloadFile(String strLocalFileName,String strRemoteFileName)
        {
            MongoDatabase MongoDB = SystemManager.getCurrentDataBase();
            MongoGridFS gfs = MongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Download(strLocalFileName,strRemoteFileName);   
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void UpLoadFile(String strFileName) {
            MongoDatabase MongoDB = SystemManager.getCurrentDataBase();
            MongoGridFS gfs = MongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Upload(strFileName); 
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DelFile(String strFileName)
        {
            MongoDatabase MongoDB = SystemManager.getCurrentDataBase();
            MongoGridFS gfs = MongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Delete(strFileName);
        }
    }
}
