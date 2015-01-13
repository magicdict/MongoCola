using System;
using System.Collections.Generic;
using System.IO;
using MongoCola.Module;
using MongoDB.Bson;
using MongoUtility.Basic;
using MongoUtility.Core;
using RazorEngine;
using SystemUtility;

namespace MongoCola
{
	public static class GetPage
	{
		/// <summary>
		/// </summary>
		public static String FilePath { set; get; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		internal static string ConnectionList()
		{
			String fileName = FilePath + "\\ConnectionList.htm";
			String content;
			var stream = new StreamReader(fileName);
			content = stream.ReadToEnd();
			String connectionList = String.Empty;
			foreach (MongoConnectionConfig item in 
                     RuntimeMongoDBContext._mongoConnectionConfigList.Values) {
				if (item.ReplSetName == String.Empty) {
					connectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName +
					"@" + (item.Host == String.Empty ? "localhost" : item.Host)
					+ (item.Port == 0 ? String.Empty : ":" + item.Port) + "</a></li>" +
					Environment.NewLine;
				} else {
					connectionList += "<li><a href = 'Connection?" + item.ConnectionName + "'>" + item.ConnectionName +
					"</a></li>" + Environment.NewLine;
				}
			}
			content = Razor.Parse(content,new {ConnectionList = SystemConfig.config.SerializableConnectionList });
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

			var connLst = new List<MongoUtility.Core.MongoConnectionConfig> {
				RuntimeMongoDBContext._mongoConnectionConfigList[ConnectionName]
			};
			RuntimeMongoDBContext.AddServer(connLst);
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
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = DBTag;
			var cr = new BsonDocument();
			cr =
                CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command,
				MongoUtility.Core.RuntimeMongoDBContext.GetCurrentServer()).Response;
			return WEBUIHelper.ConvertBsonTozTreeJson("Connection Status", cr, true);
		}
		/// <summary>
		/// </summary>
		/// <param name="DBTag"></param>
		/// <returns></returns>
		public static string GetDatabase(String DBTag)
		{
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = DBTag;
			var cr = new BsonDocument();
			cr = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentDataBase().GetStats().Response.ToBsonDocument();
			return WEBUIHelper.ConvertBsonTozTreeJson("DataBase Status", cr, true);
		}

		/// <summary>
		/// </summary>
		/// <param name="DBTag"></param>
		/// <returns></returns>
		public static string GetCollection(String DBTag)
		{
			WEBUIHelper.WebDataViewInfo = new MongoUtility.Aggregation.DataViewInfo { strDBTag = DBTag };
			MongoUtility.Core.RuntimeMongoDBContext.SelectObjectTag = DBTag;
			return WEBUIHelper.GetCollectionzTreeJSON(RuntimeMongoDBContext.GetCurrentServer());
		}
	}
}