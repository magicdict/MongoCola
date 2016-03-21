using System;
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
            return result.Response.Contains("ok")
                ? result.Response["ok"] == 1 ? string.Empty : "err"
                : "err";

            //result.Response["err"] == BsonNull.Value ? string.Empty : result.Response["err"].ToString()
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
                //var result = DropDocument(jsCol, (BsonString) jsName);
                //if (string.IsNullOrEmpty(result))
                //{
                CommandResult resultCommand;
                try
                {
                    resultCommand = new CommandResult(
                        jsCol.Save(new BsonDocument().Add(ConstMgr.KeyId, jsName)
                            .Add("value", BsonJavaScript.Create(jsCode))).Response);
                }
                catch (MongoCommandException ex)
                {
                    resultCommand = new CommandResult(ex.Result);
                }
                if (resultCommand.Response["ok"] == 1)
                {
                    return string.Empty;
                }
                return resultCommand.Response.Contains("err") ? resultCommand.Response["err"].ToString() : string.Empty;
                //}
                //return result;
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
            return QueryHelper.IsExistByKey(jsName) ? DropJsDocument(jsCol, (BsonString) jsName) : string.Empty;
        }

        /// <summary>
        ///     获得JS代码
        /// </summary>
        /// <param name="jsName"></param>
        /// <param name="jsCol"></param>
        /// <returns></returns>
        public static string LoadJavascript(string jsName, MongoCollection jsCol)
        {
            if (QueryHelper.IsExistByKey(jsName))
            {
                var js = jsCol.FindOneAs<BsonDocument>(Query.EQ(ConstMgr.KeyId, jsName)).GetValue("value").ToString();
                return js.IndexOf("new ", StringComparison.Ordinal) != -1 ? js.Substring(20, js.Length - 22) : js;
            }
            return string.Empty;

            //var js = delegate(IMongoQuery query)
            //{ return jsCol.FindOneAs<BsonDocument>(query).GetValue("value").ToString();
            //};
        }

        /// <summary>
        ///     删除js数据
        /// </summary>
        /// <param name="mongoCol"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DropJsDocument(MongoCollection mongoCol, object strKey)
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
        ///     删除单条数据
        /// </summary>
        /// <param name="mongoCol">表对象</param>
        /// <param name="objectId">ObjectId</param>
        /// <returns></returns>
        public static string DropDocument(MongoCollection mongoCol, string objectId)
        {
            CommandResult result;
            try
            {
                //有时候在序列化的过程中，objectId是由某个字段带上[id]特性客串的，所以无法转换为ObjectId对象
                //这里先尝试转换，如果可以转换，则转换
                ObjectId seekId;
                if (ObjectId.TryParse(objectId, out seekId))
                {
                    //如果可以转换，则转换
                    result =
                        new CommandResult(
                            mongoCol.Remove(Query.EQ(ConstMgr.KeyId, seekId), WriteConcern.Acknowledged)
                                .Response);
                }
                else
                {
                    //不能转换则保持原状
                    result =
                        new CommandResult(
                            mongoCol.Remove(Query.EQ(ConstMgr.KeyId, objectId), WriteConcern.Acknowledged)
                                .Response);
                }
            }
            catch (MongoCommandException ex)
            {
                result = new CommandResult(ex.Result);
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