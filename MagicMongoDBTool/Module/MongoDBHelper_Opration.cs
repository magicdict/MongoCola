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
        public enum Oprcode{
            Create,
            Drop
        }
        /// <summary>
        /// 数据库操作
        /// </summary>
        /// <param name="strSvrPath"></param>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public static Boolean DataBaseOpration(String strSvrPath, String DBName,Oprcode Func)
        {
            Boolean rtnResult = false;
            MongoServer Mongosrv = GetMongoServerBySvrPath(strSvrPath);
            if (mongosrvlst == null)
            {
                rtnResult = false;
            }
            else {

                switch (Func)
                {
                    case Oprcode.Create:
                        if (!Mongosrv.DatabaseExists(DBName))
                        {
                            Mongosrv.GetDatabase(DBName);
                            rtnResult = true;
                        }
                        break;
                    case Oprcode.Drop:
                        if (Mongosrv.DatabaseExists(DBName))
                        {
                            Mongosrv.DropDatabase(DBName);
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
        /// 根据路径字符获得服务器[Service/DBName/Collection]
        /// </summary>
        /// <param name="strSvrPath"></param>
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
    }
}
