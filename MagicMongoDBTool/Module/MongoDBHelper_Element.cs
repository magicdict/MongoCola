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
        public static void AddElement(String ElementPath, BsonElement AddElement)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="ElementPath"></param>
        public static void DropElement(BsonDocument BaseDoc, String ElementPath)
        {

            BaseDoc.Remove("");
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="ModifyElement"></param>
        /// <param name="NewValue"></param>
        public static void ModifyElement(BsonDocument BaseDoc, String ElementPath, BsonValue NewValue)
        {
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }

        private static BsonValue GetElementFromPath(String ElementPath,BsonDocument BaseDoc){
            BsonValue SelectedElement = null;
            //JpCnWord[1]\Translations\Translations[1]\Sentences\Sentences[1]\Japanese:"ああいう文章はなかなか書けない"
            //1.将路径按照\分开
            String[] strPath = ElementPath.Split(@"\".ToCharArray());
            //JpCnWord[1]
            //Translations
            //Translations[1]
            //Sentences
            //Sentences[1]
            //Japanese:"ああいう文章はなかなか書けない"
            return SelectedElement;
        }

    }
}
