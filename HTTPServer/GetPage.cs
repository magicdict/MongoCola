using System;
using System.Collections.Generic;
using System.IO;
using SystemUtility;
using MongoDB.Bson;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace HTTPServer
{
    public static class GetPage
    {
        /// <summary>
        /// </summary>
        public static String FilePath { set; get; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        internal static string ConnectionList()
        {
            var fileName = FilePath + "\\ConnectionList.htm";
            String content;
            var stream = new StreamReader(fileName);
            content = stream.ReadToEnd();
            var connectionList = String.Empty;
            foreach (var item in
                RuntimeMongoDBContext._mongoConnectionConfigList.Values)
            {
                if (item.ReplSetName == String.Empty)
                {
                    connectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName +
                                      "@" + (item.Host == String.Empty ? "localhost" : item.Host)
                                      + (item.Port == 0 ? String.Empty : ":" + item.Port) + "</a></li>" +
                                      Environment.NewLine;
                }
                else
                {
                    connectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName +
                                      "</a></li>" + Environment.NewLine;
                }
            }
            var config = new TemplateServiceConfiguration();
            //config.ReferenceResolver = (IReferenceResolver)((new UseCurrentAssembliesReferenceResolver()).GetReferences(null));
            config.Debug = true;
            var ser = new TemplateService(config);
            ser.AddNamespace("MongoUtility.Core");
            ser.AddNamespace("SystemUtility");
            Razor.SetTemplateService(ser);
            content = Razor.Parse(content, new {SystemConfig.config.ConnectionList});
            return content;
        }

        /// <summary>
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        internal static string Connection(String ConnectionName)
        {
            var FileName = FilePath + "\\Connection.htm";
            var content = String.Empty;
            var stream = new StreamReader(FileName);
            content = stream.ReadToEnd();

            var connLst = new List<MongoConnectionConfig>
            {
                RuntimeMongoDBContext._mongoConnectionConfigList[ConnectionName]
            };
            RuntimeMongoDBContext.ResetConnectionList(connLst);
            content = content.Replace("<%=NodeJSon%>", WEBUIHelper.GetConnectionzTreeJson());
            content = content.Replace("<%=ConnectionName%>", ConnectionName);
            content = content.Replace("<%=ConnectionTag%>", ConstMgr.CONNECTION_TAG);
            content = content.Replace("<%=DataBaseTag%>", ConstMgr.DATABASE_TAG);
            content = content.Replace("<%=CollectionTag%>", ConstMgr.COLLECTION_TAG);
            return content;
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetConnection(String DBTag)
        {
            RuntimeMongoDBContext.SelectObjectTag = DBTag;
            var cr = CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command,
                RuntimeMongoDBContext.GetCurrentServer()).Response;
            return WEBUIHelper.ConvertBsonTozTreeJson("Connection Status", cr, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetDatabase(String DBTag)
        {
            RuntimeMongoDBContext.SelectObjectTag = DBTag;
            var cr = new BsonDocument();
            cr = RuntimeMongoDBContext.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
            return WEBUIHelper.ConvertBsonTozTreeJson("DataBase Status", cr, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetCollection(String DBTag)
        {
            WEBUIHelper.WebDataViewInfo = new DataViewInfo {strDBTag = DBTag};
            RuntimeMongoDBContext.SelectObjectTag = DBTag;
            return WEBUIHelper.GetCollectionzTreeJSON(RuntimeMongoDBContext.GetCurrentServer());
        }
    }
}