using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
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
        public static String Version = "1.2.1";
        /// <summary>
        /// 配置实例
        /// </summary>
        public static ConfigHelper ConfigHelperInstance = new ConfigHelper();
        /// <summary>
        /// 选择对象标签
        /// </summary>
        public static String SelectObjectTag = String.Empty;
        /// <summary>
        /// 获得当前对象的种类
        /// </summary>
        public static String SelectTagType
        {
            get
            {
                return GetTagType(SelectObjectTag);
            }
        }
        /// <summary>
        /// 获得当前对象的路径
        /// </summary>
        public static String SelectTagData
        {
            get
            {
                return GetTagData(SelectObjectTag);
            }
        }
        /// <summary>
        /// 获得对象的种类
        /// </summary>
        /// <returns></returns>
        public static String GetTagType(String ObjectTag)
        {
            if (ObjectTag == String.Empty)
            {
                return string.Empty;
            }
            else
            {
                return ObjectTag.Split(":".ToCharArray())[0];
            }
        }
        /// <summary>
        /// 获得对象的路径
        /// </summary>
        /// <returns></returns>
        public static String GetTagData(String ObjectTag)
        {
            if (ObjectTag == String.Empty)
            {
                return string.Empty;
            }
            else
            {
                if (ObjectTag.Split(":".ToCharArray()).Length == 2)
                {
                    return ObjectTag.Split(":".ToCharArray())[1];
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// 文字资源
        /// </summary>
        public static StringResource mStringResource = new MagicMongoDBTool.Module.StringResource();
        /// <summary>
        /// 对话框子窗体的统一管理
        /// </summary>
        /// <param name="frm"></param>
        public static void OpenForm(Form mfrm, Boolean isDispose)
        {
            mfrm.StartPosition = FormStartPosition.CenterParent;
            mfrm.BackColor = System.Drawing.Color.White;
            mfrm.FormBorderStyle = FormBorderStyle.FixedSingle;
            mfrm.ShowDialog();
            mfrm.Close();
            if (isDispose) { mfrm.Dispose(); }
        }
        /// <summary>
        /// 对话框子窗体的统一管理
        /// </summary>
        /// <param name="frm"></param>
        public static void OpenForm(Form mfrm)
        {
            OpenForm(mfrm, true);
        }
        /// <summary>
        /// 获得当前服务器配置
        /// </summary>
        /// <param name="SrvName"></param>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig GetCurrentServerConfig()
        {
            String ServerName = SelectObjectTag.Split(":".ToCharArray())[1];
            ServerName = ServerName.Split("/".ToCharArray())[(int)MongoDBHelper.PathLv.ConnectionLV];
            ConfigHelper.MongoConnectionConfig rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (ConfigHelperInstance.ConnectionList.ContainsKey(ServerName))
            {
                rtnMongoConnectionConfig = ConfigHelperInstance.ConnectionList[ServerName];
            }
            return rtnMongoConnectionConfig;
        }
        /// <summary>
        /// 根据服务器名称获取配置
        /// </summary>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig GetCurrentServerConfig(String mongoSvrKey)
        {
            ConfigHelper.MongoConnectionConfig rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (ConfigHelperInstance.ConnectionList.ContainsKey(mongoSvrKey))
            {
                rtnMongoConnectionConfig = ConfigHelperInstance.ConnectionList[mongoSvrKey];
            }
            return rtnMongoConnectionConfig;
        }
        /// <summary>
        /// 获得当前服务器
        /// </summary>
        /// <returns></returns>
        public static MongoServer GetCurrentServer()
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
        public static BsonDocument CurrentDocument;
        /// <summary>
        /// Set Current Document
        /// </summary>
        /// <param name="SelectDocId"></param>
        public static void SetCurrentDocument(TreeNode CurrentNode)
        {
            TreeNode rootNode = FindRootNode(CurrentNode);
            BsonValue SelectDocId = (BsonValue)rootNode.Tag;
            MongoCollection mongoCol = GetCurrentCollection();
            BsonDocument doc = mongoCol.FindOneAs<BsonDocument>(Query.EQ(MongoDBHelper.KEY_ID, SelectDocId));
            CurrentDocument = doc;
        }
        /// <summary>
        /// 获取树形的根
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static TreeNode FindRootNode(TreeNode node)
        {
            if (node.Parent == null)
                return node;
            else
            {
                return FindRootNode(node.Parent);
            }
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
                jsNamelst.Add(item.GetValue(MongoDBHelper.KEY_ID).ToString());
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
        internal static void ExceptionDeal(Exception ex)
        {
            MyMessageBox.ShowMessage("Exception", "Exception", ex.ToString(), true);
        }
        internal static void ExceptionDeal(Exception ex, String Title)
        {
            if (Title == String.Empty)
            {
                MyMessageBox.ShowMessage("Exception", "Exception", ex.ToString(), true);
            }
            else
            {
                MyMessageBox.ShowMessage("Exception", Title, ex.ToString(), true);
            }
        }
        /// <summary>
        /// JsonWriterSettings
        /// </summary>
        public static MongoDB.Bson.IO.JsonWriterSettings JsonWriterSettings = new MongoDB.Bson.IO.JsonWriterSettings()
        {
            Indent = true,
            NewLineChars = System.Environment.NewLine,
            OutputMode = MongoDB.Bson.IO.JsonOutputMode.Strict
        };


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
