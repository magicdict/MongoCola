using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace MongoUtility.Core
{
    public static class ConnectionInfo
    {
        /// <summary>
        ///     获得数据库定义列表
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static List<BsonDocument> GetDatabaseInfoList(MongoClient client)
        {
            //暂时返回一个同步的结果
            IAsyncCursor<BsonDocument> databaseCursor = null;
            var task = Task.Run(
                async () => { databaseCursor = await client.ListDatabasesAsync(); }
                );
            task.Wait();
            List<BsonDocument> databaseList = null;
            task = Task.Run(
                async () => { databaseList = await databaseCursor.ToListAsync(); }
                );
            task.Wait();
            return databaseList;
        }

        /// <summary>
        ///     获得数据集列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static List<BsonDocument> GetCollectionInfoList(MongoClient client, string dbName)
        {
            var db = client.GetDatabase(dbName);
            IAsyncCursor<BsonDocument> collectionCursor = null;
            var task = Task.Run(
                async () => { collectionCursor = await db.ListCollectionsAsync(); }
                );
            task.Wait();
            List<BsonDocument> collectionList = null;
            task = Task.Run(
                async () => { collectionList = await collectionCursor.ToListAsync(); }
                );
            task.Wait();
            return collectionList;
        }


        /// <summary>
        ///     获得视图定义列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static List<BsonDocument> GetViewInfoList(MongoClient client, string dbName)
        {
            var db = client.GetDatabase(dbName);
            IAsyncCursor<BsonDocument> collectionCursor = null;
            var task = Task.Run(
                async () => { collectionCursor = await db.ListCollectionsAsync(); }
                );
            task.Wait();
            List<BsonDocument> collectionList = null;
            task = Task.Run(
                async () => { collectionList = await collectionCursor.ToListAsync(); }
                );
            task.Wait();
            return collectionList;
        }

        /// <summary>
        ///     获得数据集实例（IMongoCollection）
        /// </summary>
        /// <param name="client"></param>
        /// <param name="dbName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static IMongoCollection<BsonDocument> GetICollection(MongoClient client, string dbName,
            string collectionName)
        {
            var db = client.GetDatabase(dbName);
            var col = db.GetCollection<BsonDocument>(collectionName);
            return col;
        }

        /// <summary>
        ///     获得数据集信息
        /// </summary>
        /// <param name="client"></param>
        /// <param name="dbName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static BsonDocument GetCollectionInfo(MongoClient client, string dbName, string collectionName)
        {
            var db = client.GetDatabase(dbName);
            IAsyncCursor<BsonDocument> collectionCursor = null;
            var task = Task.Run(
                async () => { collectionCursor = await db.ListCollectionsAsync(); }
                );
            task.Wait();
            List<BsonDocument> collectionList = null;
            task = Task.Run(
                async () => { collectionList = await collectionCursor.ToListAsync(); }
                );
            task.Wait();
            return collectionList.Where(x => x.GetElement("name").Value.ToString() == collectionName).First();
        }


        /// <summary>
        ///     获得索引列表
        /// </summary>
        /// <param name="client"></param>
        /// <param name="dbName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static List<BsonDocument> GetColIndexInfo(MongoClient client, string dbName,
            string collectionName)
        {
            var db = client.GetDatabase(dbName);
            var col = db.GetCollection<BsonDocument>(collectionName);
            IAsyncCursor<BsonDocument> collectionCursor = null;
            var task = Task.Run(
                async () => { collectionCursor = await col.Indexes.ListAsync(); }
                );
            task.Wait();
            List<BsonDocument> collectionList = null;
            task = Task.Run(
                async () => { collectionList = await collectionCursor.ToListAsync(); }
                );
            task.Wait();
            return collectionList;
        }

    }
}