using System;
using System.Windows.Forms;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
        /// <summary>
        /// 操作模式
        /// </summary>
        public enum Oprcode
        {
            Create,
            Drop
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
        public static Boolean CollectionOpration(String strSvrPath, String CollectionName, Oprcode Func, TreeNode tr)
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
                            tr.Nodes.Add(FillCollectionInfoToTreeNode(CollectionName, Mongodb, strSvrPath.Split("/".ToCharArray())[0]));
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Drop:
                        if (Mongodb.CollectionExists(CollectionName))
                        {
                            Mongodb.DropCollection(CollectionName);
                            tr.TreeView.Nodes.Remove(tr);
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
        public static MongoDatabase GetMongoDBBySvrPath(String strSvrPath,Boolean WithTag = false)
        {
            if (WithTag) {
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
        public static Boolean CreateMongoIndex(String KeyName, Boolean IsAccending = true) {
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
    }
}
