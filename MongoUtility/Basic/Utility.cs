using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoUtility.Core;
using MongoUtility.EventArgs;

/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/5
 * Time: 15:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace MongoUtility.Basic
{
    public static class Utility
    {
        /// <summary>
        ///     驱动版本 MongoDB.Driver.DLL
        /// </summary>
        public static string MongoDbDriverVersion;

        /// <summary>
        ///     驱动版本 MongoDB.Bson.DLL
        /// </summary>
        public static string MongoDbBsonVersion;

        /// <summary>
        ///     JsonWriterSettings
        /// </summary>
        public static JsonWriterSettings JsonWriterSettings = new JsonWriterSettings
        {
            Indent = true,
            NewLineChars = Environment.NewLine,
            OutputMode = JsonOutputMode.Strict
        };

        /// <summary>
        ///     通用的ActionDone事件
        /// </summary>
        public static EventHandler<ActionDoneEventArgs> ActionDone;

        /// <summary>
        ///     GFS初始化
        /// </summary>
        public static void InitGFS(MongoDatabase mongoDB)
        {
            if (!mongoDB.CollectionExists(ConstMgr.COLLECTION_NAME_GFS_FILES))
            {
                mongoDB.CreateCollection(ConstMgr.COLLECTION_NAME_GFS_FILES);
            }
        }

        /// <summary>
        ///     get current Server Information
        /// </summary>
        /// <returns></returns>
        public static String GetCurrentSvrInfo(MongoServer mongosvr)
        {
            var rtnSvrInfo = String.Empty;
            rtnSvrInfo = "IsArbiter：" + mongosvr.Instance.IsArbiter + Environment.NewLine;
            rtnSvrInfo += "IsPrimary：" + mongosvr.Instance.IsPrimary + Environment.NewLine;
            rtnSvrInfo += "IsSecondary：" + mongosvr.Instance.IsSecondary + Environment.NewLine;
            rtnSvrInfo += "Address：" + mongosvr.Instance.Address + Environment.NewLine;
            if (mongosvr.Instance.BuildInfo != null)
            {
                //Before mongo2.0.2 BuildInfo will be null
                rtnSvrInfo += "VersionString：" + mongosvr.Instance.BuildInfo.VersionString + Environment.NewLine;
                //remove from mongodrvier 2.0.0
                //rtnSvrInfo += "SysInfo：" + mongosvr.Instance.BuildInfo.SysInfo + Environment.NewLine;
            }
            return rtnSvrInfo;
        }

        /// <summary>
        ///     使用字符串连接来填充
        /// </summary>
        /// <remarks>http://www.mongodb.org/display/DOCS/Connections</remarks>
        /// <param name="config"></param>
        public static String FillConfigWithConnectionString(ref MongoConnectionConfig config)
        {
            var connectionString = config.ConnectionString;
            //mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
            try
            {
                var mongourl = MongoUrl.Create(connectionString);
                config.DataBaseName = mongourl.DatabaseName;
                if (mongourl.Username != null)
                {
                    config.UserName = mongourl.Username;
                    config.Password = mongourl.Password;
                    //config.LoginAsAdmin = mongourl.Admin;
                }
                config.Host = mongourl.Server.Host;
                config.Port = mongourl.Server.Port;

                config.ReadPreference = mongourl.ReadPreference.ToString();
                config.WriteConcern = mongourl.GetWriteConcern(true).ToString();
                config.WaitQueueSize = mongourl.WaitQueueSize;
                config.wtimeoutMS = (int) mongourl.WaitQueueTimeout.TotalMilliseconds;
                config.IsUseDefaultSetting = false;

                config.socketTimeoutMS = (int) mongourl.SocketTimeout.TotalMilliseconds;
                config.connectTimeoutMS = (int) mongourl.ConnectTimeout.TotalMilliseconds;
                config.ReplSetName = mongourl.ReplicaSetName;
                foreach (var item in mongourl.Servers)
                {
                    config.ReplsetList.Add(item.Host + (item.Port == 0 ? String.Empty : ":" + item.Port));
                }
                return String.Empty;
            }
            catch (FormatException ex)
            {
                return ex.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        ///     数据库User初始化
        /// </summary>
        public static void InitDBUser(MongoDatabase mongoDB)
        {
            if (!mongoDB.CollectionExists(ConstMgr.COLLECTION_NAME_USER))
            {
                mongoDB.CreateCollection(ConstMgr.COLLECTION_NAME_USER);
            }
        }

        /// <summary>
        ///     Js数据集初始化
        /// </summary>
        public static void InitJavascript(MongoDatabase mongoDB)
        {
            if (!mongoDB.CollectionExists(ConstMgr.COLLECTION_NAME_JAVASCRIPT))
            {
                mongoDB.CreateCollection(ConstMgr.COLLECTION_NAME_JAVASCRIPT);
            }
        }

        /// <summary>
        ///     保存文件
        /// </summary>
        /// <param name="result"></param>
        public static void SaveResultToJSonFile(BsonDocument result, string FileName)
        {
            var writer = new StreamWriter(FileName, false);
            writer.Write(result.ToJson(JsonWriterSettings));
            writer.Close();
        }

        /// <summary>
        ///     获得系统JS数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentJsCollection(MongoDatabase mongoDB)
        {
            MongoCollection mongoJsCol = mongoDB.GetCollection(ConstMgr.COLLECTION_NAME_JAVASCRIPT);
            return mongoJsCol;
        }

        /// <summary>
        ///     获得JS名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetJsNameList()
        {
            var jsNamelst = new List<string>();
            foreach (var item in GetCurrentJsCollection(null).FindAllAs<BsonDocument>())
            {
                jsNamelst.Add(item.GetValue(ConstMgr.KEY_ID).ToString());
            }
            return jsNamelst;
        }

        /// <summary>
        ///     OnActionDone
        /// </summary>
        /// <param name="e"></param>
        public static void OnActionDone(ActionDoneEventArgs e)
        {
            e.Raise(null, ref ActionDone);
        }

        /// <summary>
        ///     通过读取N条记录来确定数据集结构
        /// </summary>
        /// <param name="mongoCol">数据集</param>
        /// <returns></returns>
        public static List<string> GetCollectionSchame(MongoCollection mongoCol)
        {
            var CheckRecordCnt = 100;
            var _ColumnList = new List<string>();
            var _dataList = new List<BsonDocument>();
            _dataList = mongoCol.FindAllAs<BsonDocument>()
                .SetLimit(CheckRecordCnt)
                .ToList();
            foreach (var doc in _dataList)
            {
                foreach (var item in getBsonNameList(string.Empty, doc))
                {
                    if (!_ColumnList.Contains(item))
                    {
                        _ColumnList.Add(item);
                    }
                }
            }
            return _ColumnList;
        }

        /// <summary>
        ///     取得名称列表[递归获得嵌套]
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<string> getBsonNameList(string docName, BsonDocument doc)
        {
            var _ColumnList = new List<string>();
            foreach (var strName in doc.Names)
            {
                if (doc.GetValue(strName).IsBsonDocument)
                {
                    //包含子文档的时候
                    _ColumnList.Add(strName);
                    foreach (var item in getBsonNameList(strName, doc.GetValue(strName).AsBsonDocument))
                    {
                        _ColumnList.Add(item);
                    }
                }
                else
                {
                    _ColumnList.Add(docName + (docName != string.Empty ? "." : string.Empty) + strName);
                }
            }
            return _ColumnList;
        }

        /// <summary>
        ///     将执行结果转化为细节报告文字列
        /// </summary>
        /// <param name="Resultlst"></param>
        /// <returns></returns>
        public static string ConvertCommandResultlstToString(List<CommandResult> Resultlst)
        {
            var Details = string.Empty;
            foreach (var item in Resultlst)
            {
                Details += item.Response + Environment.NewLine;
            }
            return Details;
        }

        /// <summary>
        ///     Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetBsonSize(BsonValue size)
        {
            return size.IsInt32
                ? Common.Logic.Utility.GetSize((int) size)
                : Common.Logic.Utility.GetSize((long) size);
        }
    }
}