using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Command
{
    public static partial class Operater
    {
        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static bool IsSystemCollection(MongoCollection mongoCol)
        {
            //http://docs.mongodb.org/manual/reference/system-collections/
            return IsSystemCollection(mongoCol.Database.Name, mongoCol.Name);
        }

        public static bool IsSystemCollection()
        {
            var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            //http://docs.mongodb.org/manual/reference/system-collections/
            return IsSystemCollection(mongoCol.Database.Name, mongoCol.Name);
        }

        /// <summary>
        ///     是否为系统数据集[无法删除]
        /// </summary>
        /// <param name="mongoDbName"></param>
        /// <param name="mongoColName"></param>
        /// <returns></returns>
        public static bool IsSystemCollection(string mongoDbName, string mongoColName)
        {
            //config数据库,默认为系统
            //local数据库,默认为系统
            //系统文件
            if (mongoColName.StartsWith("system."))
                return true;
            return mongoColName.StartsWith("fs.") || IsSystemDataBase(mongoDbName);
        }

        /// <summary>
        ///     带有参数的CreateOption
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="collectionName"></param>
        /// <param name="option"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static bool CreateCollectionWithOptions(string strObjTag, string collectionName,
            CollectionOptionsBuilder option, MongoDatabase mongoDb)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            if (mongoDb == null) return false;
            if (mongoDb.CollectionExists(collectionName)) return false;
            mongoDb.CreateCollection(collectionName, option);
            return true;
        }

        /// <summary>
        ///     删除数据集
        /// </summary>
        /// <param name="strCollectionName"></param>
        /// <returns></returns>
        public static bool DrapCollection(string strCollectionName)
        {
            return RuntimeMongoDbContext.GetCurrentDataBase().DropCollection(strCollectionName).Ok;
        }

        /// <summary>
        ///     重命名数据集
        /// </summary>
        /// <param name="strOldCollectionName"></param>
        /// <param name="strNewCollectionName"></param>
        /// <returns></returns>
        public static bool RenameCollection(string strOldCollectionName, string strNewCollectionName)
        {
            return RuntimeMongoDbContext.GetCurrentDataBase().RenameCollection(strOldCollectionName, strNewCollectionName).Ok;
        }

        /// <summary>
        /// </summary>
        public static void ReIndex()
        {
            RuntimeMongoDbContext.GetCurrentCollection().ReIndex();
        }

        /// <summary>
        ///     Create Collection
        /// </summary>
        /// <param name="strObjTag"></param>
        /// <param name="collectionName"></param>
        /// <param name="mongoDb"></param>
        /// <returns></returns>
        public static bool CreateCollection(string strObjTag, string collectionName, MongoDatabase mongoDb)
        {
            //不支持中文 JIRA ticket is created : SERVER-4412
            //SERVER-4412已经在2013/03解决了
            //collection names are limited to 121 bytes after converting to UTF-8. 
            if (mongoDb == null) return false;
            if (mongoDb.CollectionExists(collectionName)) return false;
            mongoDb.CreateCollection(collectionName);
            return true;
        }

        /// <summary>
        ///     添加索引
        /// </summary>
        /// <param name="ascendingKey"></param>
        /// <param name="descendingKey"></param>
        /// <param name="geoSpatialKey"></param>
        /// <param name="option"></param>
        /// <param name="currentCollection"></param>
        /// <returns></returns>
        public static bool CreateMongoIndex(string[] ascendingKey, string[] descendingKey, string geoSpatialKey,
            IndexOptionsBuilder option, MongoCollection currentCollection)
        {
            var mongoCol = currentCollection;
            var indexkeys = new IndexKeysBuilder();
            if (!string.IsNullOrEmpty(geoSpatialKey))
            {
                indexkeys.GeoSpatial(geoSpatialKey);
            }
            indexkeys.Ascending(ascendingKey);
            indexkeys.Descending(descendingKey);
            mongoCol.CreateIndex(indexkeys, option);
            return true;
        }

        /// <summary>
        ///     删除索引[KEY_ID]以外
        /// </summary>
        /// <param name="indexName"></param>
        /// <param name="mongoCol"></param>
        /// <returns></returns>
        public static bool DropMongoIndex(string indexName, MongoCollection mongoCol)
        {
            if (indexName == ConstMgr.KeyId)
            {
                return false;
            }
            if (mongoCol.IndexExistsByName(indexName))
            {
                mongoCol.DropIndexByName(indexName);
            }
            return true;
        }
    }
}