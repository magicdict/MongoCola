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
            GetLastParentDocument(BaseDoc, ElementPath).InsertAt(GetLastParentDocument(BaseDoc, ElementPath).ElementCount, AddElement);
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="ElementPath"></param>
        public static void DropElement(String ElementPath, String ElementName)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            GetLastParentDocument(BaseDoc, ElementPath).Remove(ElementName);
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="ModifyElement"></param>
        /// <param name="NewValue"></param>
        public static void ModifyElement(String ElementPath, String ElementName, BsonValue NewValue)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            GetLastParentDocument(BaseDoc, ElementPath).GetElement(ElementName).Value = NewValue;
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        public static BsonDocument GetLastParentDocument(BsonDocument BaseDoc, String ElementPath)
        {
            BsonValue Current = BaseDoc;
            //JpCnWord[1]\Translations[ARRAY]\Translations[1]\Sentences[ARRAY]\Sentences[1]\Japanese:"ああいう文章はなかなか書けない"
            //1.将路径按照\分开
            String[] strPath = ElementPath.Split(@"\".ToCharArray());
            //JpCnWord[1]                                    First
            //Translations[ARRAY]
            //Translations[1]
            //Sentences[ARRAY]
            //Sentences[1]
            //Japanese:"ああいう文章はなかなか書けない"        Last
            for (int i = 1; i < strPath.Length - 1; i++)
            {
                String strTag = strPath[i];
                Boolean IsArray = false;
                if (strTag.EndsWith(ArrayMark))
                {
                    //去除[Array]后缀
                    strTag = strTag.Substring(0, strTag.Length - ArrayMark.Length);
                    IsArray = true;
                }
                if (IsArray)
                {
                    //这里的Array是指一个列表的上层节点，在BSON里面没有相应的对象，只是个逻辑概念
                    Current = Current.AsBsonDocument.GetValue(strTag).AsBsonArray;
                }
                else
                {
                    if (Current.IsBsonArray)
                    {
                        //当前的如果是数组，获得当前下标。
                        int Index = Convert.ToInt16(strTag.Substring(strTag.IndexOf("[".ToString()) + 1, strTag.Length - strTag.IndexOf("[".ToString()) - 2));
                        Current = Current.AsBsonArray[Index - 1];
                    }
                    else
                    {
                        if (Current.IsBsonDocument)
                        {
                            //如果当前还是一个文档的话
                            Current = Current.AsBsonDocument.GetValue(strTag);
                        }
                        else
                        {
                            //不应该会走到这个分支
                            return null;
                        }
                    }
                }
            }
            return Current.AsBsonDocument;
        }

    }
}
