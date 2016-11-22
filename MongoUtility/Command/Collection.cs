using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
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
            if (mongoColName.StartsWith("system.")) return true;
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
            collectionName = collectionName.Trim();
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
            return
                RuntimeMongoDbContext.GetCurrentDataBase()
                    .RenameCollection(strOldCollectionName, strNewCollectionName).Ok;
        }

        /// <summary>
        /// </summary>
        /// <param name="KeyOptions"></param>
        /// <param name="strMessageTitle"></param>
        /// <param name="strMessageContent"></param>
        /// <returns></returns>
        public static bool CreateIndex(IndexOption KeyOptions, ref string strMessageTitle, ref string strMessageContent)
        {
            var option = new IndexOptionsBuilder();
            option.SetBackground(KeyOptions.IsBackground);
            option.SetDropDups(KeyOptions.IsDropDups);
            option.SetSparse(KeyOptions.IsSparse);
            option.SetUnique(KeyOptions.IsUnique);
            if (KeyOptions.IsPartial)
            {
                IMongoQuery query = (QueryDocument)BsonDocument.Parse(KeyOptions.PartialCondition);
                option.SetPartialFilterExpression(query);
            }
            if (KeyOptions.IsExpireData)
            {
                //TTL的限制条件很多
                //http://docs.mongodb.org/manual/tutorial/expire-data/
                //不能是组合键
                var canUseTtl = true;
                if (KeyOptions.AscendingKey.Count + KeyOptions.DescendingKey.Count +
                    (string.IsNullOrEmpty(KeyOptions.GeoSpatialKey) ? 0 : 1) != 1)
                {
                    strMessageTitle = "Can't Set TTL";
                    strMessageContent = "the TTL index may not be compound (may not have multiple fields).";
                    canUseTtl = false;
                }
                else
                {
                    //不能是_id
                    if (KeyOptions.FirstKey == ConstMgr.KeyId)
                    {
                        strMessageTitle = "Can't Set TTL";
                        strMessageContent =
                            "you cannot create this index on the _id field, or a field that already has an index.";
                        canUseTtl = false;
                    }
                }
                if (RuntimeMongoDbContext.GetCurrentCollection().IsCapped())
                {
                    strMessageTitle = "Can't Set TTL";
                    strMessageContent =
                        "you cannot use a TTL index on a capped collection, because MongoDB cannot remove documents from a capped collection.";
                    canUseTtl = false;
                }
                if (canUseTtl)
                {
                    strMessageTitle = "Constraints Of TimeToLive";
                    strMessageContent =
                        "the indexed field must be a date BSON type. If the field does not have a date type, the data will not expire." +
                        Environment.NewLine +
                        "if the field holds an array, and there are multiple date-typed data in the index, the document will expire when the lowest (i.e. earliest) matches the expiration threshold.";
                    option.SetTimeToLive(new TimeSpan(0, 0, KeyOptions.Ttl));
                }
            }
            var totalIndex = KeyOptions.AscendingKey.Count + KeyOptions.DescendingKey.Count + KeyOptions.TextKey.Count;
            totalIndex += string.IsNullOrEmpty(KeyOptions.GeoSpatialHaystackKey) ? 0 : 1;
            totalIndex += string.IsNullOrEmpty(KeyOptions.GeoSpatialKey) ? 0 : 1;
            totalIndex += string.IsNullOrEmpty(KeyOptions.GeoSpatialSphericalKey) ? 0 : 1;
            totalIndex += string.IsNullOrEmpty(KeyOptions.HashedKey) ? 0 : 1;


            if (string.IsNullOrEmpty(KeyOptions.IndexName) || totalIndex == 0 ||
                RuntimeMongoDbContext.GetCurrentCollection().IndexExists(KeyOptions.IndexName))
            {
                strMessageTitle = "Index Add Failed!";
                strMessageContent = "Please Check the index information.";
                return false;
            }
            option.SetName(KeyOptions.IndexName);
            string errorMessage = string.Empty;
            if (CreateMongoIndex(KeyOptions, option, RuntimeMongoDbContext.GetCurrentCollection(), ref errorMessage))
            {
                strMessageTitle = "Index Add Completed!";
                strMessageContent = "IndexName:" + KeyOptions.IndexName + " is add to collection.";
                return true;
            }
            else
            {
                strMessageTitle = "Index Add Failed!";
                strMessageContent = errorMessage;
                return false;
            }
        }

        /// <summary>
        ///     添加索引
        /// </summary>
        /// <param name="IdxOpt"></param>
        /// <param name="option"></param>
        /// <param name="currentCollection"></param>
        /// <returns></returns>
        public static bool CreateMongoIndex(IndexOption IdxOpt,
            IndexOptionsBuilder option, MongoCollection currentCollection,ref string errorMessage)
        {
            var mongoCol = currentCollection;
            var indexkeys = new IndexKeysBuilder();
            if (!string.IsNullOrEmpty(IdxOpt.GeoSpatialHaystackKey)) indexkeys.GeoSpatialHaystack(IdxOpt.GeoSpatialHaystackKey);
            if (!string.IsNullOrEmpty(IdxOpt.GeoSpatialKey)) indexkeys.GeoSpatial(IdxOpt.GeoSpatialKey);
            if (!string.IsNullOrEmpty(IdxOpt.GeoSpatialSphericalKey)) indexkeys.GeoSpatialSpherical(IdxOpt.GeoSpatialSphericalKey);
            if (!string.IsNullOrEmpty(IdxOpt.HashedKey)) indexkeys.Hashed(IdxOpt.HashedKey);
            indexkeys.Ascending(IdxOpt.AscendingKey.ToArray());
            indexkeys.Descending(IdxOpt.DescendingKey.ToArray());
            indexkeys.Text(IdxOpt.TextKey.ToArray());
            //CreateIndex失败的时候会出现异常！
            try
            {
                var result = mongoCol.CreateIndex(indexkeys, option);
                return result.Response.GetElement("ok").Value.AsInt32 == 1;
            }
            catch (Exception ex)
            {
                errorMessage = ex.ToString();
                return false;
            }
        }

        /// <summary>
        ///     索引选项
        /// </summary>
        public struct IndexOption
        {
            /// <summary>
            ///     IsBackground
            /// </summary>
            public bool IsBackground;
            /// <summary>
            ///     IsDropDups
            /// </summary>
            public bool IsDropDups;
            /// <summary>
            ///     IsSparse
            /// </summary>
            public bool IsSparse;
            /// <summary>
            ///     IsUnique
            /// </summary>
            public bool IsUnique;

            /// <summary>
            ///     是否为 Partial Indexes
            /// </summary>
            public bool IsPartial;
            /// <summary>
            ///     IsExpireData
            /// </summary>
            public bool IsExpireData;
            /// <summary>
            ///     Ttl
            /// </summary>
            public int Ttl;
            /// <summary>
            ///     IndexName
            /// </summary>
            public string IndexName;
            /// <summary>
            ///     AscendingKey
            /// </summary>
            public List<string> AscendingKey;
            /// <summary>
            ///     DescendingKey
            /// </summary>
            public List<string> DescendingKey;
            /// <summary>
            ///     GeoSpatialHaystackKey
            /// </summary>
            public string GeoSpatialHaystackKey;
            /// <summary>
            ///     GeoSpatialSphericalKey
            /// </summary>
            public string GeoSpatialSphericalKey;
            /// <summary>
            ///     GeoSpatialKey
            /// </summary>
            public string GeoSpatialKey;
            /// <summary>
            ///     HashedKey
            /// </summary>
            public string HashedKey;
            /// <summary>
            ///     FirstKey
            /// </summary>
            public string FirstKey;
            /// <summary>
            ///     TextKey
            /// </summary>
            public List<string> TextKey;

            /// <summary>
            ///     Partial Indexes 的条件
            /// </summary>
            public string PartialCondition;
        }
        /// <summary>
        /// ReIndex
        /// </summary>
        public static void ReIndex()
        {
            RuntimeMongoDbContext.GetCurrentCollection().ReIndex();
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
            collectionName = collectionName.Trim();
            if (mongoDb == null) return false;
            if (mongoDb.CollectionExists(collectionName)) return false;
            mongoDb.CreateCollection(collectionName);
            return true;
        }

        /// <summary>
        ///     复制表
        /// </summary>
        /// <param name="fromDb">数据来源</param>
        /// <param name="toDb">数据去向</param>
        /// <param name="collectionName">表名</param>
        /// <param name="isIndex">是否连同索引一起复制</param>
        /// <returns></returns>
        public static bool CopyCollection(MongoDatabase fromDb, MongoDatabase toDb, string collectionName,
            bool isIndex)
        {
            try
            {
                var fromCollection = fromDb.GetCollection(collectionName);
                var toCollection = toDb.GetCollection(collectionName);
                toCollection.RemoveAll();
                var result = toCollection.InsertBatch(fromCollection.FindAll()).ToList();
                if (isIndex)
                {
                    //TODO:复制索引
                }
                return result.Count > 0 && result[0].Response.Contains("ok") && result[0].Response["ok"] == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}