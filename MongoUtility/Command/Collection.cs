using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Basic;
using MongoUtility.Core;
using System;
using System.Collections.Generic;

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


        public struct IndexOption
        {
            public bool IsBackground;

            public bool IsDropDups;

            public bool IsSparse;

            public bool IsUnique;

            public bool IsExpireData;

            public int TTL;

            public string IndexName;

            public List<string> ascendingKey;

            public List<string> descendingKey;

            public string geoSpatialKey;

            public string firstKey;

            public string textKey;

        }

        public static bool CreateIndex(IndexOption UIOption, ref string strMessageTitle, ref string strMessageContent)
        {
            var Result = true;
            var option = new IndexOptionsBuilder();
            option.SetBackground(UIOption.IsBackground);
            option.SetDropDups(UIOption.IsDropDups);
            option.SetSparse(UIOption.IsSparse);
            option.SetUnique(UIOption.IsUnique);

            if (UIOption.IsExpireData)
            {
                //TTL的限制条件很多
                //http://docs.mongodb.org/manual/tutorial/expire-data/
                //不能是组合键
                var canUseTtl = true;
                if ((UIOption.ascendingKey.Count + UIOption.descendingKey.Count + (string.IsNullOrEmpty(UIOption.geoSpatialKey) ? 0 : 1)) != 1)
                {
                    strMessageTitle = "Can't Set TTL";
                    strMessageContent = "the TTL index may not be compound (may not have multiple fields).";
                    canUseTtl = false;
                }
                else
                {
                    //不能是_id
                    if (UIOption.firstKey == ConstMgr.KeyId)
                    {
                        strMessageTitle = "Can't Set TTL";
                        strMessageContent = "you cannot create this index on the _id field, or a field that already has an index.";
                        canUseTtl = false;
                    }
                }
                if (RuntimeMongoDbContext.GetCurrentCollection().IsCapped())
                {
                    strMessageTitle = "Can't Set TTL";
                    strMessageContent = "you cannot use a TTL index on a capped collection, because MongoDB cannot remove documents from a capped collection.";
                    canUseTtl = false;
                }
                if (canUseTtl)
                {
                    strMessageTitle = "Constraints Of TimeToLive";
                    strMessageContent = "the indexed field must be a date BSON type. If the field does not have a date type, the data will not expire." +
                        Environment.NewLine + "if the field holds an array, and there are multiple date-typed data in the index, the document will expire when the lowest (i.e. earliest) matches the expiration threshold.";
                    option.SetTimeToLive(new TimeSpan(0, 0, UIOption.TTL));
                }
            }
            var totalIndex = (UIOption.ascendingKey.Count + UIOption.descendingKey.Count +
                             (string.IsNullOrEmpty(UIOption.geoSpatialKey) ? 0 : 1) +
                             (string.IsNullOrEmpty(UIOption.textKey) ? 0 : 1));
            if (UIOption.IndexName != string.Empty && !RuntimeMongoDbContext.GetCurrentCollection().IndexExists(UIOption.IndexName) && totalIndex != 0)
            {
                option.SetName(UIOption.IndexName);
                try
                {
                    //暂时要求只能一个TextKey
                    if (!string.IsNullOrEmpty(UIOption.textKey))
                    {
                        var textKeysDoc = new IndexKeysDocument { { UIOption.textKey, "text" } };
                        RuntimeMongoDbContext.GetCurrentCollection().CreateIndex(textKeysDoc, option);
                    }
                    else
                    {
                        Operater.CreateMongoIndex(UIOption.ascendingKey.ToArray(), UIOption.descendingKey.ToArray(), UIOption.geoSpatialKey,
                            option, RuntimeMongoDbContext.GetCurrentCollection());
                    }
                    strMessageTitle = "Index Add Completed!";
                    strMessageContent = "IndexName:" + UIOption.IndexName + " is add to collection.";
                }
                catch (Exception ex)
                {
                    strMessageTitle = "Index Add Failed!";
                    strMessageContent = "IndexName:" + UIOption.IndexName;
                    Result = false;
                }

            }
            else
            {
                strMessageTitle = "Index Add Failed!";
                strMessageContent = "Please Check the index information.";
                Result = false;

            }
            return Result;
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