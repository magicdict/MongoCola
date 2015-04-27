using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoUtility.NewUtility
{
    public static class GetConnectionInfo
    {
        /// <summary>
        /// 获得数据库列表
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static List<BsonDocument> GetDatabaseList(MongoClient client)
        {
            //暂时返回一个同步的结果
            IAsyncCursor<BsonDocument> DatabaseCursor = null;
            Task task = Task.Run(
                async () =>
                {
                    DatabaseCursor = await client.ListDatabasesAsync();
                }
            );
            task.Wait();
            List<BsonDocument> DatabaseList = null;
            task = Task.Run(
                async () =>
                {
                    DatabaseList = await DatabaseCursor.ToListAsync();
                }
            );
            task.Wait();
            return DatabaseList;
        }

        /// <summary>
        /// 获得数据集列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="DataBaseDoc"></param>
        /// <returns></returns>
        public static List<BsonDocument> GetCollectionList(MongoClient client,string DBName)
        {
            var db = client.GetDatabase(DBName);
            IAsyncCursor<BsonDocument> CollectionCursor = null;
            Task task = Task.Run(
                async () =>
                {
                    CollectionCursor = await db.ListCollectionsAsync();
                }
            );
            task.Wait();
            List<BsonDocument> CollectionList = null;
            task = Task.Run(
                async () =>
                {
                    CollectionList = await CollectionCursor.ToListAsync();
                }
            );
            task.Wait();
            return CollectionList;
        }

        /// <summary>
        /// 获得数据集实例
        /// </summary>
        /// <param name="client"></param>
        /// <param name="DBName"></param>
        /// <param name="CollectionName"></param>
        /// <returns></returns>
        public static IMongoCollection<BsonDocument> GetCollectionInfo(MongoClient client, string DBName, string CollectionName)
        {
            var db = client.GetDatabase(DBName);
            var Col = db.GetCollection<BsonDocument>(CollectionName);
            return Col;
        }

        /// <summary>
        /// 获得信息
        /// </summary>
        /// <param name="config"></param>
        public static void GetInfo(MongoConnectionConfig config)
        {
            //OnlyTest Start
            try
            {
                var client = RuntimeMongoDBContext.CreateMongoClient(ref config);
                List<BsonDocument> list = GetDatabaseList(client);
                foreach (var doc in list)
                {
                    System.Diagnostics.Debug.WriteLine(doc.ToString());
                    string DBName = doc.GetElement("name").Value.ToString();
                    foreach (var col in GetCollectionList(client, DBName))
                    {
                        string CollectionName = col.GetElement("name").Value.ToString();
                        System.Diagnostics.Debug.WriteLine(col.ToString());
                        var ICol = GetCollectionInfo(client, DBName, CollectionName);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //OnlyTest End
        }

    }
}
