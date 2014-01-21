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
        /// <param name="FileName"></param>
        /// <returns></returns>
        internal static string ConnectionList()
        {
            String FileName = FilePath + "\\ConnectionList.htm";
            String content = String.Empty;
            var stream = new StreamReader(FileName);
            content = stream.ReadToEnd();
            String ConnectionList = String.Empty;
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values
                )
            {
                if (item.ReplSetName == String.Empty)
                {
                    ConnectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName +
                                      "@" + (item.Host == String.Empty ? "localhost" : item.Host)
                                      + (item.Port == 0 ? String.Empty : ":" + item.Port) + "</a></li>" +
                                      Environment.NewLine;
                }
                else
                {
                    ConnectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName +
                                      "</a></li>" + Environment.NewLine;
                }
            }

            content = content.Replace("<%=ConnectionList%>", ConnectionList);
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
            MongoDBHelper.AddServer(connLst);
            content = content.Replace("<%=NodeJSon%>", MongoDBHelper.GetConnectionzTreeJSON());
            content = content.Replace("<%=ConnectionName%>", ConnectionName);
            content = content.Replace("<%=ConnectionTag%>", MongoDBHelper.CONNECTION_TAG);
            content = content.Replace("<%=DataBaseTag%>", MongoDBHelper.DATABASE_TAG);
            content = content.Replace("<%=CollectionTag%>", MongoDBHelper.COLLECTION_TAG);
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
                MongoDBHelper.ExecuteMongoSvrCommand(MongoDBHelper.serverStatus_Command,
                    SystemManager.GetCurrentServer()).Response;
            return MongoDBHelper.ConvertBsonTozTreeJson("Connection Status", cr, true);
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
            return MongoDBHelper.ConvertBsonTozTreeJson("DataBase Status", cr, true);
        }

        /// <summary>
        /// </summary>
        /// <param name="DBTag"></param>
        /// <returns></returns>
        public static string GetCollection(String DBTag)
        {
            MongoDBHelper.WebDataViewInfo = new MongoDBHelper.DataViewInfo {strDBTag = DBTag};
            SystemManager.SelectObjectTag = DBTag;
            return MongoDBHelper.GetCollectionzTreeJSON();
        }
    }
}