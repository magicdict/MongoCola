using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Builders;
namespace MagicMongoDBTool.Module
{
    public static class SystemManager
    {
        /// <summary>
        /// 测试模式
        /// </summary>
        public static Boolean DEBUG_MODE = false;
        /// <summary>
        /// 是否为MONO
        /// </summary>
        public static Boolean MONO_MODE = false;
        /// <summary>
        /// 版本号
        /// </summary>
        public static String Version = "1.02";
        /// <summary>
        /// 数据过滤器
        /// </summary>
        public static DataFilter CurrDataFilter = new DataFilter();
        /// <summary>
        /// 配置实例
        /// </summary>
        public static ConfigHelper ConfigHelperInstance = new ConfigHelper();
        /// <summary>
        /// 选择对象标签
        /// </summary>
        public static String SelectObjectTag = String.Empty;
        /// <summary>
        /// 文字资源
        /// </summary>
        public static StringResource mStringResource = new MagicMongoDBTool.Module.StringResource();
        /// <summary>
        /// 对话框子窗体的统一管理
        /// </summary>
        /// <param name="frm"></param>
        public static void OpenForm(Form mfrm)
        {
            mfrm.ShowDialog();
            mfrm.Close();
            mfrm.Dispose();
        }
        /// <summary>
        /// 通过服务器名称获得服务器配置
        /// </summary>
        /// <param name="SrvName"></param>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig GetSelectedSvrProByName()
        {
            String svrName = SelectObjectTag.Split(":".ToCharArray())[1];
            svrName = svrName.Split("/".ToCharArray())[0];
            ConfigHelper.MongoConnectionConfig rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (ConfigHelperInstance.ConnectionList.ContainsKey(svrName))
            {
                rtnMongoConnectionConfig = ConfigHelperInstance.ConnectionList[svrName];
            }
            return rtnMongoConnectionConfig;
        }
        /// <summary>
        /// 获得当前服务器
        /// </summary>
        /// <returns></returns>
        public static MongoServer GetCurrentService()
        {
            return MongoDBHelper.GetMongoServerBySvrPath(SelectObjectTag);
        }
        /// <summary>
        /// 获得当前数据库
        /// </summary>
        /// <returns></returns>
        public static MongoDatabase GetCurrentDataBase()
        {
            return MongoDBHelper.GetMongoDBBySvrPath(SelectObjectTag);
        }
        /// <summary>
        /// 获得当前数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentCollection()
        {
            return MongoDBHelper.GetMongoCollectionBySvrPath(SelectObjectTag);
        }
        /// <summary>
        /// 获得系统JS数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentJsCollection()
        {
            MongoDatabase mongoDB = GetCurrentDataBase();
            MongoCollection mongoJsCol = mongoDB.GetCollection(MongoDBHelper.COLLECTION_NAME_JAVASCRIPT);
            return mongoJsCol;
        }
        /// <summary>
        /// Current selected document
        /// </summary>
        private static BsonDocument CurrentDocument;
        /// <summary>
        /// Set Current Document
        /// </summary>
        /// <param name="SelectDocId"></param>
        public static void SetCurrentDocument(TreeNode CurrentNode)
        {
            TreeNode rootNode = findroot(CurrentNode);
            BsonValue SelectDocId = (BsonValue)rootNode.Tag;
            MongoCollection mongoCol = GetCurrentCollection();
            BsonDocument doc = mongoCol.FindOneAs<BsonDocument>(Query.EQ("_id", SelectDocId));
            CurrentDocument = doc;
        }
        private static TreeNode findroot(TreeNode node)
        {
            if (node.Parent == null)
                return node;
            else
            {
                return findroot(node.Parent);
            }
        }
        /// <summary>
        /// Get Current Document
        /// </summary>
        /// <returns></returns>
        public static BsonDocument GetCurrentDocument()
        {
            return CurrentDocument;
        }
        /// <summary>
        /// 获得JS名称列表
        /// </summary>
        /// <returns></returns>
        public static List<String> GetJsNameList()
        {
            List<String> jsNamelst = new List<String>();
            foreach (var item in GetCurrentJsCollection().FindAllAs<BsonDocument>())
            {
                jsNamelst.Add(item.GetValue("_id").ToString());
            }
            return jsNamelst;

        }
        /// <summary>
        /// 是否使用默认语言
        /// </summary>
        /// <returns></returns>
        internal static Boolean IsUseDefaultLanguage()
        {
            if (ConfigHelperInstance == null)
            {
                return true;
            }
            if (ConfigHelperInstance.LanguageFileName == "English" ||
                String.IsNullOrEmpty(ConfigHelperInstance.LanguageFileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        internal static void InitLanguage()
        {
            //语言的初始化
            if (!IsUseDefaultLanguage())
            {
                String LanguageFile = "Language" + System.IO.Path.DirectorySeparatorChar + SystemManager.ConfigHelperInstance.LanguageFileName;
                if (File.Exists(LanguageFile))
                {
                    SystemManager.mStringResource.InitLanguage(LanguageFile);
                    MyMessageBox.SwitchLanguage(mStringResource);
                }
            }
        }
    }
}
