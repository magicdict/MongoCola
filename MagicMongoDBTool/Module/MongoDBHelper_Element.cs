using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;


namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="AddElement"></param>
        public static void AddElement(BsonDocument BaseDoc, BsonElement AddElement)
        {
           BaseDoc =BaseDoc.Add(AddElement);
           SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="BsonName"></param>
        public static void DropElement(BsonDocument BaseDoc, String BsonName)
        {
            BaseDoc.Remove(BsonName);
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="ModifyElement"></param>
        /// <param name="NewValue"></param>
        public static void ModifyElement(BsonDocument BaseDoc,BsonElement ModifyElement, BsonValue NewValue)
        {
            ModifyElement.Value = NewValue;
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
    }
}
