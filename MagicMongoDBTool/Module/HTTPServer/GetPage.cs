using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool.HTTP
{
    public static class GetPage
    {
        /// <summary>
        /// 
        /// </summary>
        public static String FilePath { set; get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        internal static string ConnectionList()
        {
            String FileName = FilePath + "\\ConnectionList.htm";
            String content = String.Empty;
            StreamReader stream = new StreamReader(FileName);
            content = stream.ReadToEnd();
            String ConnectionList = String.Empty;
            foreach (ConfigHelper.MongoConnectionConfig item in SystemManager.ConfigHelperInstance.ConnectionList.Values)
            {
                if (item.ReplSetName == String.Empty)
                {
                    ConnectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName + "@" + (item.Host == String.Empty ? "localhost" : item.Host)
                                             + (item.Port == 0 ? String.Empty : ":" + item.Port.ToString()) + "</a></li>" + System.Environment.NewLine;
                }
                else
                {
                    ConnectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName + "</a></li>" + System.Environment.NewLine;
                }
            }

            content = content.Replace("<%=ConnectionList%>", ConnectionList);
            return content;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionName"></param>
        /// <returns></returns>
        internal static string Connection(String ConnectionName)
        {
            String FileName = FilePath + "\\Connection.htm";
            String content = String.Empty;
            StreamReader stream = new StreamReader(FileName);
            content = stream.ReadToEnd();

            List<ConfigHelper.MongoConnectionConfig> connLst = new List<ConfigHelper.MongoConnectionConfig>();
            connLst.Add(SystemManager.ConfigHelperInstance.ConnectionList[ConnectionName]);
            MongoDBHelper.AddServer(connLst);

            content = content.Replace("<%=NodeJSon%>", MongoDBHelper.FillConnectionToJSON(ConnectionName));
            content = content.Replace("<%=ConnectionName%>", ConnectionName);
            return content;
        }
    }
}
