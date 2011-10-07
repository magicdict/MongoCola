using System;
using System.Windows.Forms;
using MongoDB.Driver;
namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelpler
    {
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
        public static Boolean CollectionOpration(String strSvrPath, String CollectionName, Oprcode Func,TreeNode tr)
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
        /// <returns></returns>
        public static MongoServer GetMongoServerBySvrPath(String strSvrPath)
        {
            MongoServer rtnMongoSrv = null;
            String[] strPath = strSvrPath.Split("/".ToCharArray());
            if (strPath.Length > 0)
            {
                if (mongosrvlst.ContainsKey(strPath[0]))
                {
                    rtnMongoSrv = mongosrvlst[strPath[0]];
                }
            }
            return rtnMongoSrv;
        }

        /// <summary>
        /// 根据路径字符获得数据库
        /// </summary>
        /// <param name="strSvrPath">[Service/DBName/Collection]</param>
        /// <returns></returns>
        public static MongoDatabase GetMongoDBBySvrPath(String strSvrPath)
        {
            MongoDatabase rtnMongoDb = null;
            MongoServer MongoSrv = GetMongoServerBySvrPath(strSvrPath);
            if (MongoSrv != null)
            {
                String[] strPath = strSvrPath.Split("/".ToCharArray());
                if (strPath.Length > 1)
                {
                    if (MongoSrv.DatabaseExists(strPath[1]))
                    {
                        rtnMongoDb = MongoSrv.GetDatabase(strPath[1]);
                    }
                }
            }
            return rtnMongoDb;
        }

    }
}
