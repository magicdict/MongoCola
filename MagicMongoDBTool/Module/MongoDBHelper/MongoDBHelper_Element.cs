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

        public static BsonElement ClipElement = null;

        /// <summary>
        /// 复制元素
        /// </summary>
        /// <param name="ElementPath"></param>
        public static void CopyElement(String ElementPath)
        {
            ClipElement = GetElementOrValueFromPath(ElementPath);
        }
        /// <summary>
        /// 粘贴元素
        /// </summary>
        /// <param name="ElementPath"></param>
        public static void PasteElement(String ElementPath)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            BsonValue t = GetLastParentDocument(BaseDoc, ElementPath, true);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.InsertAt(t.AsBsonDocument.ElementCount, ClipElement);
            }
            if (t.IsBsonArray)
            {
                t.AsBsonArray.Insert(t.AsBsonArray.Count, ClipElement.Value);
            }
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 剪切元素
        /// </summary>
        /// <param name="ElementPath"></param>
        public static void CutElement(String ElementPath)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            ClipElement = GetElementOrValueFromPath(ElementPath);
            BsonValue t = GetLastParentDocument(BaseDoc, ElementPath);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.Remove(GetElementOrValueFromPath(ElementPath).Name);
            }
            if (t.IsBsonArray)
            {
                t.AsBsonArray.Remove(GetElementOrValueFromPath(ElementPath).Value);
            }
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 是否可以粘贴
        /// </summary>
        public static Boolean CanPaste
        {
            get { return ClipElement != null; }
        }
        /// <summary>
        /// 添加元素
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="AddElement"></param>
        public static void AddElement(String ElementPath, BsonElement AddElement)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            BsonValue t = GetLastParentDocument(BaseDoc, ElementPath, true);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.InsertAt(t.AsBsonDocument.ElementCount, AddElement);
            }
            if (t.IsBsonArray)
            {
                t.AsBsonArray.Insert(t.AsBsonArray.Count, AddElement.Value);
            }
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 删除元素
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="ElementPath"></param>
        public static void DropElement(String ElementPath,int ValueIndex)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            BsonValue t = GetLastParentDocument(BaseDoc, ElementPath);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.Remove(GetElementOrValueFromPath(ElementPath).Name);
            }
            if (t.IsBsonArray)
            {
                t.AsBsonArray.RemoveAt(ValueIndex);
            }
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 修改元素
        /// </summary>
        /// <param name="ModifyElement"></param>
        /// <param name="NewValue"></param>
        public static void ModifyElement(String ElementPath, BsonValue NewValue,int ValueIndex)
        {
            BsonDocument BaseDoc = SystemManager.GetCurrentDocument();
            BsonValue t = GetLastParentDocument(BaseDoc, ElementPath);
            if (t.IsBsonDocument)
            {
                t.AsBsonDocument.GetElement(GetElementOrValueFromPath(ElementPath).Name).Value = NewValue;
            }
            if (t.IsBsonArray)
            {
                t.AsBsonArray[ValueIndex] = NewValue;
            }
            SystemManager.GetCurrentCollection().Save(BaseDoc);
        }
        /// <summary>
        /// 通过路径获得元素名称[元素值为字符]
        /// </summary>
        /// <param name="ElementPath"></param>
        /// <returns></returns>
        public static BsonElement GetElementOrValueFromPath(String ElementPath)
        {
            String[] strPath = ElementPath.Split(@"\".ToCharArray());
            String LastNode = strPath[strPath.Length - 1];
            if (LastNode.IndexOf(":") > 0)
            {
                String ElementName = LastNode.Substring(0, strPath[strPath.Length - 1].IndexOf(":"));
                String ElementValue = LastNode.Substring(strPath[strPath.Length - 1].IndexOf(":") + 1);
                ElementValue = ElementValue.Trim("\"".ToCharArray());
                return new BsonElement(ElementName, ElementValue);
            }
            else {
                return new BsonElement(String.Empty, LastNode);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BaseDoc"></param>
        /// <param name="ElementPath"></param>
        /// <param name="IsGetLast">T:取到最后 F:取到倒数第二</param>
        /// <returns></returns>
        public static BsonValue GetLastParentDocument(BsonDocument BaseDoc, String ElementPath, Boolean IsGetLast = false)
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
            int DeepLv;
            if (IsGetLast)
            {
                DeepLv = strPath.Length;
            }
            else
            {
                DeepLv = strPath.Length - 1;
            }
            for (int i = 1; i < DeepLv; i++)
            {
                String strTag = strPath[i];
                Boolean IsArray = false;
                if (strTag.EndsWith(Array_Mark))
                {
                    //去除[Array]后缀
                    strTag = strTag.Substring(0, strTag.Length - Array_Mark.Length);
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
            return Current;
        }

    }
}
