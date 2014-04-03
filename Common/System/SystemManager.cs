using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MagicMongoDBTool.Module
{
    public static class SystemManager
    {
        /// <summary>
        ///     测试模式
        /// </summary>
        public static Boolean DebugMode = false;

        /// <summary>
        ///     是否为MONO
        /// </summary>
        public static Boolean MonoMode = false;

        /// <summary>
        ///     版本号
        /// </summary>
        public static String Version = Application.ProductVersion;

        /// <summary>
        ///     配置实例
        /// </summary>
        public static ConfigHelper ConfigHelperInstance = new ConfigHelper();

        /// <summary>
        ///     选择对象标签
        /// </summary>
        public static String SelectObjectTag = String.Empty;

        /// <summary>
        ///     驱动版本 MongoDB.Driver.DLL
        /// </summary>
        public static String MongoDbDriverVersion;

        /// <summary>
        ///     驱动版本 MongoDB.Bson.DLL
        /// </summary>
        public static String MongoDbBsonVersion;

        /// <summary>
        ///     文字资源
        /// </summary>
        public static StringResource MStringResource = new StringResource();

        /// <summary>
        ///     Current selected document
        /// </summary>
        public static BsonDocument CurrentDocument;

        /// <summary>
        ///     JsonWriterSettings
        /// </summary>
        public static JsonWriterSettings JsonWriterSettings = new JsonWriterSettings
        {
            Indent = true,
            NewLineChars = Environment.NewLine,
            OutputMode = JsonOutputMode.Strict
        };

        /// <summary>
        ///     获得当前对象的种类
        /// </summary>
        public static String SelectTagType
        {
            get { return GetTagType(SelectObjectTag); }
        }

        /// <summary>
        ///     获得当前对象的路径
        /// </summary>
        public static String SelectTagData
        {
            get { return GetTagData(SelectObjectTag); }
        }

        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        /// <returns></returns>
        public static Boolean IsUseDefaultLanguage
        {
            get
            {
                if (ConfigHelperInstance == null)
                {
                    return true;
                }
                return (ConfigHelperInstance.LanguageFileName == "English" ||
                        String.IsNullOrEmpty(ConfigHelperInstance.LanguageFileName));
            }
        }

        #region"异常处理"

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        public static void ExceptionDeal(Exception ex)
        {
            ExceptionDeal(ex, "Exception", "Exception");
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="message">消息</param>
        public static void ExceptionDeal(Exception ex, String message)
        {
            ExceptionDeal(ex, "Exception", message);
        }

        /// <summary>
        ///     异常处理
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="Title">标题</param>
        /// <param name="Message">消息</param>
        public static void ExceptionDeal(Exception ex, String Title, String Message)
        {
            String ExceptionString;
            ExceptionString = "MongoDB.Driver.DLL:" + MongoDbDriverVersion + Environment.NewLine;
            ExceptionString += "MongoDB.Bson.DLL:" + MongoDbBsonVersion + Environment.NewLine;
            ExceptionString += ex.ToString();
            MyMessageBox.ShowMessage(Title, Message, ExceptionString, true);
            ExceptionLog(ExceptionString);
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="ExceptionString">异常文字</param>
        public static void ExceptionLog(String ExceptionString)
        {
            var exLog = new StreamWriter("Exception.log", true);
            exLog.WriteLine("DateTime:" + DateTime.Now);
            exLog.WriteLine(ExceptionString);
            exLog.Close();
        }

        /// <summary>
        ///     错误日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void ExceptionLog(Exception ex)
        {
            String ExceptionString;
            ExceptionString = "MongoDB.Driver.DLL:" + MongoDbDriverVersion + Environment.NewLine;
            ExceptionString += "MongoDB.Bson.DLL:" + MongoDbBsonVersion + Environment.NewLine;
            ExceptionString += ex.ToString();
            ExceptionLog(ExceptionString);
        }

        #endregion

        /// <summary>
        ///     获得对象的种类
        /// </summary>
        /// <returns></returns>
        public static String GetTagType(String objectTag)
        {
            if (objectTag == String.Empty)
            {
                return string.Empty;
            }
            return objectTag.Split(":".ToCharArray())[0];
        }

        /// <summary>
        ///     获得对象的路径
        /// </summary>
        /// <returns></returns>
        public static String GetTagData(String objectTag)
        {
            if (objectTag == String.Empty)
            {
                return string.Empty;
            }
            if (objectTag.Split(":".ToCharArray()).Length == 2)
            {
                return objectTag.Split(":".ToCharArray())[1];
            }
            return string.Empty;
        }

        /// <summary>
        ///     对话框子窗体的统一管理
        /// </summary>
        /// <param name="mfrm"></param>
        /// <param name="isDispose">有些时候需要使用被打开窗体产生的数据，所以不能Dispose</param>
        /// <param name="isUseAppIcon"></param>
        public static void OpenForm(Form mfrm, Boolean isDispose, Boolean isUseAppIcon)
        {
            mfrm.StartPosition = FormStartPosition.CenterParent;
            mfrm.BackColor = Color.White;
            mfrm.FormBorderStyle = FormBorderStyle.FixedSingle;
            mfrm.MaximizeBox = false;
            if (isUseAppIcon)
            {
                mfrm.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            mfrm.ShowDialog();
            mfrm.Close();
            if (isDispose)
            {
                mfrm.Dispose();
            }
        }

        /// <summary>
        ///     获得当前服务器配置
        /// </summary>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig GetCurrentServerConfig()
        {
            String ServerName = SelectObjectTag.Split(":".ToCharArray())[1];
            ServerName = ServerName.Split("/".ToCharArray())[(int) MongoDbHelper.PathLv.ConnectionLv];
            var rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (ConfigHelperInstance.ConnectionList.ContainsKey(ServerName))
            {
                rtnMongoConnectionConfig = ConfigHelperInstance.ConnectionList[ServerName];
            }
            return rtnMongoConnectionConfig;
        }

        /// <summary>
        ///     根据服务器名称获取配置
        /// </summary>
        /// <param name="mongoSvrKey"></param>
        /// <returns></returns>
        public static ConfigHelper.MongoConnectionConfig GetCurrentServerConfig(String mongoSvrKey)
        {
            var rtnMongoConnectionConfig = new ConfigHelper.MongoConnectionConfig();
            if (ConfigHelperInstance.ConnectionList.ContainsKey(mongoSvrKey))
            {
                rtnMongoConnectionConfig = ConfigHelperInstance.ConnectionList[mongoSvrKey];
            }
            return rtnMongoConnectionConfig;
        }

        /// <summary>
        ///     获得当前服务器
        /// </summary>
        /// <returns></returns>
        public static MongoServer GetCurrentServer()
        {
            return MongoDbHelper.GetMongoServerBySvrPath(SelectObjectTag);
        }

        /// <summary>
        ///     获得当前数据库
        /// </summary>
        /// <returns></returns>
        public static MongoDatabase GetCurrentDataBase()
        {
            return MongoDbHelper.GetMongoDBBySvrPath(SelectObjectTag);
        }

        /// <summary>
        ///     获得当前数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentCollection()
        {
            return MongoDbHelper.GetMongoCollectionBySvrPath(SelectObjectTag);
        }

        /// <summary>
        ///     获得系统JS数据集
        /// </summary>
        /// <returns></returns>
        public static MongoCollection GetCurrentJsCollection()
        {
            MongoDatabase mongoDB = GetCurrentDataBase();
            MongoCollection mongoJsCol = mongoDB.GetCollection(MongoDbHelper.COLLECTION_NAME_JAVASCRIPT);
            return mongoJsCol;
        }

        /// <summary>
        ///     Set Current Document
        /// </summary>
        /// <param name="currentNode"></param>
        public static void SetCurrentDocument(TreeNode currentNode)
        {
            TreeNode rootNode = FindRootNode(currentNode);
            var selectDocId = (BsonValue) rootNode.Tag;
            MongoCollection mongoCol = GetCurrentCollection();
            var doc = mongoCol.FindOneAs<BsonDocument>(Query.EQ(MongoDbHelper.KEY_ID, selectDocId));
            CurrentDocument = doc;
        }

        /// <summary>
        ///     获取树形的根
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static TreeNode FindRootNode(TreeNode node)
        {
            if (node.Parent != null) return FindRootNode(node.Parent);
            return node;
        }

        /// <summary>
        ///     保存文件
        /// </summary>
        /// <param name="result"></param>
        public static void SaveResultToJSonFile(BsonDocument result)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = MongoDbHelper.TxtFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName, false);
                writer.Write(result.ToJson(JsonWriterSettings));
                writer.Close();
            }
        }

        /// <summary>
        ///     Javascript文件的保存
        /// </summary>
        /// <param name="result"></param>
        public static void SaveJavascriptFile(String result)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = MongoDbHelper.JsFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName, false);
                writer.Write(result);
                writer.Close();
            }
        }

        public static String LoadFile()
        {
            var dialog = new OpenFileDialog();
            String Context = String.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var reader = new StreamReader(dialog.FileName);
                    Context = reader.ReadToEnd();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    ExceptionDeal(ex);
                }
            }
            return Context;
        }

        /// <summary>
        ///     Javascript文件的保存
        /// </summary>
        /// <param name="Result"></param>
        public static void SaveTextFile(String Result, String Filter)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = Filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName, false);
                writer.Write(Result);
                writer.Close();
            }
        }

        /// <summary>
        ///     获得JS名称列表
        /// </summary>
        /// <returns></returns>
        public static List<String> GetJsNameList()
        {
            var jsNamelst = new List<String>();
            foreach (BsonDocument item in GetCurrentJsCollection().FindAllAs<BsonDocument>())
            {
                jsNamelst.Add(item.GetValue(MongoDbHelper.KEY_ID).ToString());
            }
            return jsNamelst;
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void InitLanguage()
        {
            //语言的初始化
            if (!IsUseDefaultLanguage)
            {
                String LanguageFile = "Language" + Path.DirectorySeparatorChar + ConfigHelperInstance.LanguageFileName;
                if (File.Exists(LanguageFile))
                {
                    MStringResource.InitLanguage(LanguageFile);
                    MyMessageBox.SwitchLanguage(MStringResource);
                }
            }
        }
    }
}