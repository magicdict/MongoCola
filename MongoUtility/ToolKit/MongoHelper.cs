using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoUtility.Basic;
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

namespace MongoUtility.ToolKit
{
    public static class MongoHelper
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
        public static void InitGfs()
        {
            var mongoDb = RuntimeMongoDbContext.GetCurrentDataBase();
            if (!mongoDb.CollectionExists(ConstMgr.CollectionNameGfsFiles))
            {
                mongoDb.CreateCollection(ConstMgr.CollectionNameGfsFiles);
            }
        }

        /// <summary>
        ///     get current Server Information
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentSvrInfo()
        {
            var mongosvr = RuntimeMongoDbContext.GetCurrentServer();
            var rtnSvrInfo = "IsArbiter：" + mongosvr.Instance.IsArbiter + Environment.NewLine;
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
        public static string FillConfigWithConnectionString(ref MongoConnectionConfig config)
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
                config.WtimeoutMs = (int) mongourl.WaitQueueTimeout.TotalMilliseconds;
                config.IsUseDefaultSetting = false;

                config.SocketTimeoutMs = (int) mongourl.SocketTimeout.TotalMilliseconds;
                config.ConnectTimeoutMs = (int) mongourl.ConnectTimeout.TotalMilliseconds;
                config.ReplSetName = mongourl.ReplicaSetName;
                foreach (var item in mongourl.Servers)
                {
                    config.ReplsetList.Add(item.Host + (item.Port == 0 ? string.Empty : ":" + item.Port));
                }
                return string.Empty;
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
        public static void InitDbUser()
        {
            var mongDb = RuntimeMongoDbContext.GetCurrentDataBase();
            if (!mongDb.CollectionExists(ConstMgr.CollectionNameUser))
            {
                mongDb.CreateCollection(ConstMgr.CollectionNameUser);
            }
        }

        /// <summary>
        ///     Js数据集初始化
        /// </summary>
        public static void InitJavascript()
        {
            var mongDb = RuntimeMongoDbContext.GetCurrentDataBase();
            if (!mongDb.CollectionExists(ConstMgr.CollectionNameJavascript))
            {
                mongDb.CreateCollection(ConstMgr.CollectionNameJavascript);
            }
        }

        /// <summary>
        ///     保存文件
        /// </summary>
        /// <param name="result"></param>
        public static void SaveResultToJSonFile(BsonDocument result, string fileName)
        {
            var writer = new StreamWriter(fileName, false);
            writer.Write(result.ToJson(JsonWriterSettings));
            writer.Close();
        }

        /// <summary>
        ///     获得系统JS数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentJsCollection(MongoDatabase mongoDb)
        {
            MongoCollection mongoJsCol = mongoDb.GetCollection(ConstMgr.CollectionNameJavascript);
            return mongoJsCol;
        }

        /// <summary>
        ///     获得JS名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetJsNameList()
        {
            return
                GetCurrentJsCollection(RuntimeMongoDbContext.GetCurrentDataBase())
                    .FindAllAs<BsonDocument>()
                    .Select(item => item.GetValue(ConstMgr.KeyId).ToString())
                    .OrderBy(item => item)
                    .ToList();
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
            var checkRecordCnt = 100;
            var columnList = new List<string>();
            var dataList = new List<BsonDocument>();
            dataList = mongoCol.FindAllAs<BsonDocument>()
                .SetLimit(checkRecordCnt)
                .ToList();
            foreach (var doc in dataList)
            {
                foreach (var item in GetBsonNameList(string.Empty, doc))
                {
                    if (!columnList.Contains(item))
                    {
                        columnList.Add(item);
                    }
                }
            }
            return columnList.OrderBy(info => info).ToList();
        }

        /// <summary>
        ///     取得名称列表[递归获得嵌套]
        /// </summary>
        /// <param name="docName"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static List<string> GetBsonNameList(string docName, BsonDocument doc)
        {
            var columnList = new List<string>();
            foreach (var strName in doc.Names)
            {
                if (doc.GetValue(strName).IsBsonDocument)
                {
                    //包含子文档的时候
                    columnList.Add(strName);
                    columnList.AddRange(GetBsonNameList(strName, doc.GetValue(strName).AsBsonDocument));
                }
                else
                {
                    columnList.Add(docName + (docName != string.Empty ? "." : string.Empty) + strName);
                }
            }
            return columnList.OrderBy(info => info).ToList();
        }

        /// <summary>
        ///     将执行结果转化为细节报告文字列
        /// </summary>
        /// <param name="resultlst"></param>
        /// <returns></returns>
        public static string ConvertCommandResultlstToString(List<CommandResult> resultlst)
        {
            return resultlst.Aggregate(string.Empty, (current, item) => current + (item.Response + Environment.NewLine));
        }

        /// <summary>
        ///     Size的文字表达
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetBsonSize(BsonValue size)
        {
            return size.IsInt32
                ? Utility.GetSize((int) size)
                : Utility.GetSize((long) size);
        }
    }
}