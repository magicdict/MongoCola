using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;

namespace MongoUtility.Command
{
    public static class ElementHelper
    {
        /// <summary>
        /// </summary>
        public static object ClipElement;

        /// <summary>
        /// </summary>
        public static bool IsElementClip = true;

        /// <summary>
        ///     Can Paste As Value
        /// </summary>
        public static bool CanPasteAsValue
        {
            get { return ClipElement != null && !IsElementClip; }
        }

        /// <summary>
        ///     Can Paste As Element
        /// </summary>
        public static bool CanPasteAsElement
        {
            get { return ClipElement != null && IsElementClip; }
        }

        //http://www.mongodb.org/display/DOCS/Capped+Collections#CappedCollections-UsageandRestrictions
        //Usage and Restrictions Of capped collection.
        //You may insert new documents in the capped collection.
        //You may update the existing documents in the collection. However, the documents must not grow in size. If they do, the update will fail. Note if you are performing updates, you will likely want to declare an appropriate index (given there is no _id index for capped collections by default).
        //The database does not allow deleting documents from a capped collection. Use the drop() method to remove all rows from the collection. (After the drop you must explicitly recreate the collection.)
        //Capped collection are not shard-able.

        /// <summary>
        ///     Paste
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static string PasteElement(string elementPath, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, true);
            if (t.IsBsonDocument)
            {
                try
                {
                    t.AsBsonDocument.InsertAt(t.AsBsonDocument.ElementCount, (BsonElement) ClipElement);
                }
                catch (InvalidOperationException ex)
                {
                    return ex.Message;
                }
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
            return string.Empty;
        }

        /// <summary>
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void PasteValue(string elementPath, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, true);
            if (t.IsBsonArray)
            {
                t.AsBsonArray.Insert(t.AsBsonArray.Count, (BsonValue) ClipElement);
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
        }

        /// <summary>
        ///     Cut Element
        /// </summary>
        /// <param name="el"></param>
        public static void CopyElement(BsonElement el)
        {
            ClipElement = el;
            IsElementClip = true;
        }

        /// <summary>
        ///     Cut Array Value
        /// </summary>
        /// <param name="val"></param>
        public static void CopyValue(BsonValue val)
        {
            ClipElement = val;
            IsElementClip = false;
        }

        /// <summary>
        ///     Cut Element
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="el"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void CutElement(string elementPath, BsonElement el, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            ClipElement = el;
            IsElementClip = true;
            DropElement(elementPath, el, currentDocument, currentCollection);
        }

        /// <summary>
        ///     Cut Array Value
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="valueIndex"></param>
        /// <param name="val"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void CutValue(string elementPath, int valueIndex, BsonValue val, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            ClipElement = val;
            IsElementClip = false;
            DropArrayValue(elementPath, valueIndex, currentDocument, currentCollection);
        }

        /// <summary>
        ///     Add Element
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="addElement"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static string AddElement(string elementPath, BsonElement addElement, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, true);
            if (t.IsBsonDocument)
            {
                try
                {
                    t.AsBsonDocument.InsertAt(t.AsBsonDocument.ElementCount, addElement);
                }
                catch (InvalidOperationException ex)
                {
                    return ex.Message;
                }
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
            return string.Empty;
        }

        /// <summary>
        ///     Add Value
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="addValue"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void AddArrayValue(string elementPath, BsonValue addValue, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, true);
            if (t.IsBsonArray)
            {
                t.AsBsonArray.Insert(t.AsBsonArray.Count, addValue);
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
        }

        /// <summary>
        ///     Drop Element
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="el"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void DropElement(string elementPath, BsonElement el, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, false);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.Remove(el.Name);
            }
            currentCollection.Save(baseDoc);
        }

        /// <summary>
        ///     Drop A Value of Array
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="valueIndex"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void DropArrayValue(string elementPath, int valueIndex, BsonDocument currentDocument,
            MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, false);
            if (t.IsBsonArray)
            {
                t.AsBsonArray.RemoveAt(valueIndex);
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
        }

        /// <summary>
        ///     Modify Element
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="newValue"></param>
        /// <param name="el"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void ModifyElement(string elementPath, BsonValue newValue, BsonElement el,
            BsonDocument currentDocument, MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, false);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.SetElement(new BsonElement(el.Name, newValue));
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
        }

        /// <summary>
        ///     Modify A Value of Array
        /// </summary>
        /// <param name="elementPath"></param>
        /// <param name="newValue"></param>
        /// <param name="valueIndex"></param>
        /// <param name="currentDocument"></param>
        /// <param name="currentCollection"></param>
        public static void ModifyArrayValue(string elementPath, BsonValue newValue, int valueIndex,
            BsonDocument currentDocument, MongoCollection currentCollection)
        {
            var baseDoc = currentDocument;
            var t = GetLastParentDocument(baseDoc, elementPath, false);
            if (t.IsBsonArray)
            {
                t.AsBsonArray[valueIndex] = newValue;
            }
            if (!currentCollection.IsCapped())
            {
                currentCollection.Save(baseDoc);
            }
        }

        /// <summary>
        ///     Locate the Operation Place
        /// </summary>
        /// <param name="baseDoc"></param>
        /// <param name="elementPath"></param>
        /// <param name="isGetLast">T:GetOperationPlace F:GetOperationPlace Parent</param>
        /// <returns></returns>
        public static BsonValue GetLastParentDocument(BsonDocument baseDoc, string elementPath, bool isGetLast)
        {
            BsonValue current = baseDoc;
            //JpCnWord[1]\Translations[ARRAY]\Translations[1]\Sentences[ARRAY]\Sentences[1]\Japanese:"ああいう文章はなかなか書けない"
            //1.将路径按照\分开
            var strPath = elementPath.Split(@"\".ToCharArray());
            //JpCnWord[1]                                    First
            //Translations[ARRAY]
            //Translations[1]
            //Sentences[ARRAY]
            //Sentences[1]
            //Japanese:"ああいう文章はなかなか書けない"        Last
            int deepLv;
            if (isGetLast)
            {
                deepLv = strPath.Length;
            }
            else
            {
                deepLv = strPath.Length - 1;
            }
            for (var i = 1; i < deepLv; i++)
            {
                var strTag = strPath[i];
                var isArray = false;
                if (strTag.EndsWith(ConstMgr.ArrayMark))
                {
                    //去除[Array]后缀
                    strTag = strTag.Substring(0, strTag.Length - ConstMgr.ArrayMark.Length);
                    isArray = true;
                }
                if (isArray)
                {
                    //这里的Array是指一个列表的上层节点，在BSON里面没有相应的对象，只是个逻辑概念
                    if (strTag == string.Empty)
                    {
                        //Array里面的Array,所以没有元素名称。
                        //TODO：正确做法是将元素的Index传入，这里暂时认为第一个数组就是目标数组
                        foreach (var item in current.AsBsonArray)
                        {
                            if (item.IsBsonArray)
                            {
                                current = item;
                            }
                        }
                    }
                    else
                    {
                        current = current.AsBsonDocument.GetValue(strTag).AsBsonArray;
                    }
                }
                else
                {
                    if (current.IsBsonArray)
                    {
                        //当前的如果是数组，获得当前下标。
                        int index =
                            Convert.ToInt16(strTag.Substring(strTag.IndexOf("[") + 1,
                                strTag.Length - strTag.IndexOf("[") - 2));
                        current = current.AsBsonArray[index - 1];
                    }
                    else
                    {
                        if (current.IsBsonDocument)
                        {
                            //如果当前还是一个文档的话
                            current = current.AsBsonDocument.GetValue(strTag);
                        }
                        else
                        {
                            //不应该会走到这个分支
                            return null;
                        }
                    }
                }
            }
            return current;
        }
    }
}