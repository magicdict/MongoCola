using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            databaseList.Sort((x, y) =>
            {
                if (x.GetElement("name").Value.ToString() == ConstMgr.DatabaseNameAdmin)
                {
                    return -1;
                }
                else
                {
                    return x.GetElement("name").Value.ToString().CompareTo(y.GetElement("name").Value.ToString());
                }
            });
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
        public static List<string> GetViewInfoList(MongoClient client, string dbName)
        {
            var mongoDb = client.GetServer().GetDatabase(dbName);
            var viewlist = new List<string>();
            //获得View列表
            if (mongoDb.CollectionExists(ConstMgr.CollectionNameSystemViews))
            {
                foreach (var viewdoc in mongoDb.GetCollection(ConstMgr.CollectionNameSystemViews).FindAll())
                {
                    viewlist.Add(viewdoc.GetElement(ConstMgr.KeyId).Value.AsString);
                }
            }
            return viewlist;
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

        public static long GetCollectionCnt(IMongoCollection<BsonDocument> col)
        {
            long colCount = 0;
            Expression<Func<BsonDocument, bool>> countfun = x => true;
            var task = Task.Run(
                async () => { colCount = await col.CountAsync(countfun); }
                );
            task.Wait();
            return colCount;
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