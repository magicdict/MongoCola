using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GUIResource;
using MongoDB.Bson;
using MongoDB.Driver;
using QLFUI;
using MongoDB.Driver.Builders;
namespace MagicMongoDBTool.Module
{
    public static class SystemManager
    {
        /// <summary>
        /// 测试模式
        /// </summary>
        public static Boolean DEBUG_MODE = true;
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
        public static string SelectObjectTag = string.Empty;
        /// <summary>
        /// 选中数据ID
        /// </summary>
        public static String SelectDocId = String.Empty;
        /// <summary>
        /// 文字资源
        /// </summary>
        public static StringResource mStringResource = new GUIResource.StringResource();
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
            string svrName = SelectObjectTag.Split(":".ToCharArray())[1];
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
        /// 
        /// </summary>
        /// <returns></returns>
        public static BsonDocument GetCurrentDocument() {
            return GetCurrentCollection().FindOneAs<BsonDocument>(Query.EQ("_id",(BsonValue)SelectDocId));
        }
        /// <summary>
        /// 获得JS名称列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetJsNameList()
        {
            List<string> jsNamelst = new List<string>();
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
            return ConfigHelperInstance.LanguageFileName == "";
        }
        /// <summary>
        /// 初始化
        /// </summary>
        internal static void InitLanguage()
        {
            //语言的初始化
            if (SystemManager.ConfigHelperInstance.LanguageFileName != String.Empty)
            {
                if (File.Exists("Language\\" + SystemManager.ConfigHelperInstance.LanguageFileName))
                {
                    SystemManager.mStringResource.InitLanguage("Language\\" + SystemManager.ConfigHelperInstance.LanguageFileName);
                    MyMessageBox.SwitchLanguage(mStringResource);
                }
                else
                {
                    ConfigHelperInstance.LanguageFileName = "";
                }
            }
        }
    }
}
