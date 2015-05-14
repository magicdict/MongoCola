using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;

namespace MongoUtility.Command
{
    public static partial class Operater
    {
        /// <summary>
        ///     插入JS到系统JS库
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        public static string CreateNewJavascript(string jsName, string jsCode)
        {
            var jsCol = RuntimeMongoDbContext.GetCurrentCollection();
            //标准的JS库格式未知
            if (QueryHelper.IsExistByKey(jsName)) return string.Empty;
            CommandResult result;
            try
            {
                result =
                    new CommandResult(
                        jsCol.Insert(new BsonDocument().Add(ConstMgr.KeyId, jsName).Add("value", jsCode)).Response);
            }
            catch (MongoCommandException ex)
            {
                result = new CommandResult(ex.Result);
            }
            return result.Response["err"] == BsonNull.Value ? string.Empty : result.Response["err"].ToString();
        }

        /// <summary>
        ///     Save Edited Javascript
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCode"></param>
        /// <param name="jsCol"></param>
        /// <returns></returns>
        public static string SaveEditorJavascript(string jsName, string jsCode, MongoCollection jsCol)
        {
            //标准的JS库格式未知
            if (QueryHelper.IsExistByKey(jsName))
            {
                var result = DropDocument(jsCol, (BsonString) jsName);
                if (string.IsNullOrEmpty(result))
                {
                    CommandResult resultCommand;
                    try
                    {
                        resultCommand = new CommandResult(
                            jsCol.Insert(new BsonDocument().Add(ConstMgr.KeyId, jsName).Add("value", jsCode)).Response);
                    }
                    catch (MongoCommandException ex)
                    {
                        resultCommand = new CommandResult(ex.Result);
                    }
                    if (resultCommand.Response["err"] == BsonNull.Value)
                    {
                        return string.Empty;
                    }
                    return resultCommand.Response["err"].ToString();
                }
                return result;
            }
            return string.Empty;
        }

        /// <summary>
        ///     Delete Javascript Collection Document
        /// </summary>
        /// <param name="jsName"></param>
        /// <returns></returns>
        public static string DelJavascript(string jsName)
        {
            var jsCol = RuntimeMongoDbContext.GetCurrentCollection();
            return QueryHelper.IsExistByKey(jsName) ? DropDocument(jsCol, (BsonString) jsName) : string.Empty;
        }

        /// <summary>
        ///     获得JS代码
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCol"></param>
        /// <returns></returns>
        public static string LoadJavascript(string jsName, MongoCollection jsCol)
        {
            return QueryHelper.IsExistByKey(jsName)
                ? jsCol.FindOneAs<BsonDocument>(Query.EQ(ConstMgr.KeyId, jsName)).GetValue("value").ToString()
                : string.Empty;
        }

        /// <summary>
        ///     删除数据
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DropDocument(MongoCollection mongoCol, object strKey)
        {
            var result = new CommandResult(new BsonDocument());
            if (QueryHelper.IsExistByKey(strKey.ToString()))
            {
                try
                {
                    result =
                        new CommandResult(
                            mongoCol.Remove(Query.EQ(ConstMgr.KeyId, (BsonValue) strKey), WriteConcern.Acknowledged)
                                .Response);
                }
                catch (MongoCommandException ex)
                {
                    result = new CommandResult(ex.Result);
                }
            }
            BsonElement err;
            return !result.Response.TryGetElement("err", out err) ? string.Empty : err.ToString();
        }

        /// <summary>
        ///     插入空文档
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="safeMode"></param>
        /// <returns>插入记录的ID</returns>
        public static BsonValue InsertEmptyDocument(MongoCollection mongoCol, bool safeMode)
        {
            var document = new BsonDocument();
            if (safeMode)
            {
                try
                {
                    mongoCol.Insert(document, WriteConcern.Acknowledged);
                    return document.GetElement(ConstMgr.KeyId).Value;
                }
                catch
                {
                    return BsonNull.Value;
                }
            }
            mongoCol.Insert(document);
            return document.GetElement(ConstMgr.KeyId).Value;
        }
    }
}