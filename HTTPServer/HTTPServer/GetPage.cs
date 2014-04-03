using System;
using System.Collections.Generic;
using System.IO;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool.HTTP
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
            String fileName = FilePath + "\\ConnectionList.htm";
            String content;
            var stream = new StreamReader(fileName);
            content = stream.ReadToEnd();
            String connectionList = String.Empty;
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values
                )
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

            content = content.Replace("<%=ConnectionList%>", connectionList);
            return content;
        }

        /// <summary>
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        internal static string Connection(String ConnectionName)
        {
            String FileName = FilePath + "\\Connection.htm";
            String content = String.Empty;
            var stream = new StreamReader(FileName);
            content = stream.ReadToEnd();

            var connLst = new List<ConfigHelper.MongoConnectionConfig>
            {
                SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName]
            };
            MongoDbHelper.AddServer(connLst);
            content = content.Replace("<%=NodeJSon%>", MongoDbHelper.GetConnectionzTreeJson());
            content = content.Replace("<%=ConnectionName%>", ConnectionName);
            content = content.Replace("<%=ConnectionTag%>", MongoDbHelper.CONNECTION_TAG);
            content = content.Replace("<%=DataBaseTag%>", MongoDbHelper.DATABASE_TAG);
            content = content.Replace("<%=CollectionTag%>", MongoDbHelper.COLLECTION_TAG);
            return content;
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetConnection(String DBTag)
        {
            SystemManager.SelectObjectTag = DBTag;
            var cr = new BsonDocument();
            cr =
                MongoDbHelper.ExecuteMongoSvrCommand(MongoDbHelper.serverStatus_Command,
                    SystemManager.GetCurrentServer()).Response;
            return MongoDbHelper.ConvertBsonTozTreeJson("Connection Status", cr, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetDatabase(String DBTag)
        {
            SystemManager.SelectObjectTag = DBTag;
            var cr = new BsonDocument();
            cr = SystemManager.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
            return MongoDbHelper.ConvertBsonTozTreeJson("DataBase Status", cr, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetCollection(String DBTag)
        {
            MongoDbHelper.WebDataViewInfo = new MongoDbHelper.DataViewInfo {strDBTag = DBTag};
            SystemManager.SelectObjectTag = DBTag;
            return MongoDbHelper.GetCollectionzTreeJSON();
        }
    }
}