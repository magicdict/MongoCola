using Common;
using FunctionForm.Status;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoGUICtl;
using MongoGUIView;
using MongoUtility.ToolKit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MongoCola.Config
{
    /// <summary>
    ///     SystemConfig
    /// </summary>
    [Serializable]
    public class SystemConfig
    {
        #region"通用"

        /// <summary>
        ///     配置文件名称
        /// </summary>
        public static string SystemConfigFilename = "SystemConfig.xml";

        /// <summary>
        ///     AppPath
        /// </summary>
        public static string AppPath = string.Empty;

        /// <summary>
        ///     Config Format Version
        /// </summary>
        public byte ConfigVer = 4;

        /// <summary>
        ///     MongoBin的路径，用于Dos命令
        /// </summary>
        public string MongoBinPath { set; get; }

        /// <summary>
        ///     DateTime UTC
        /// </summary>
        public bool IsUtc { set; get; }

        /// <summary>
        ///     数字使用K系统表示
        /// </summary>
        public bool IsDisplayNumberWithKSystem { set; get; }

        /// <summary>
        ///     GuidRepresentation
        /// </summary>
        public enum GuidRepresentation
        {
            Unspecified = 0,
            Standard,
            CSharpLegacy,
            JavaLegacy,
            PythonLegacy
        }

        /// <summary>
        ///     BsonGuidRepresentation
        /// </summary>
        public GuidRepresentation BsonGuidRepresentation { set; get; }

        /// <summary>
        ///     DateTimeFormat
        /// </summary>
        public DateTimePickerFormat DateTimeFormat { set; get; }
        /// <summary>
        ///     DateTimeCustomFormat
        /// </summary>
        public string DateTimeCustomFormat { set; get; }

        /// <summary>
        ///     JsonOutputMode
        /// </summary>
        public JsonOutputMode jsonMode { set; get; }

        /// <summary>
        ///     状态刷新间隔时间(初始化时候用)
        /// </summary>
        [NonSerialized]
        public static int DefaultRefreshStatusTimer = 30;

        /// <summary>
        ///     状态刷新间隔时间
        /// </summary>
        public int RefreshStatusTimer { set; get; }

        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        /// <returns></returns>
        public bool IsUseDefaultLanguage()
        {
            return LanguageFileName == "English.xml" || string.IsNullOrEmpty(LanguageFileName);
        }

        /// <summary>
        ///     语言
        /// </summary>
        public string LanguageFileName { set; get; }

        /// <summary>
        ///     Font Use For Mac System
        /// </summary>
        /// <value>The user interface font.</value>
        public string UiFontFamily { get; set; }

        /// <summary>
        ///     自定义系统监视项目
        /// </summary>
        public List<string> MonitorItems { get; set; }

        /// <summary>
        ///     写入配置
        /// </summary>
        public void SaveSystemConfig()
        {
            if (DateTimeFormat == 0) DateTimeFormat = DateTimePickerFormat.Long;
            Utility.SaveObjAsXml(AppPath + SystemConfigFilename, this);
            SystemManager.SystemConfig = this;
            ApplyConfig();
        }

        /// <summary>
        ///     读取配置
        /// </summary>
        /// <returns></returns>
        public static void LoadFromConfigFile()
        {
            SystemManager.SystemConfig = Utility.LoadObjFromXml<SystemConfig>(AppPath + SystemConfigFilename);
            ApplyConfig();
        }

        /// <summary>
        ///     应用配置
        /// </summary>
        private static void ApplyConfig()
        {
            if (SystemManager.SystemConfig.DateTimeFormat.GetHashCode() == 0)
            {
                SystemManager.SystemConfig.DateTimeFormat = DateTimePickerFormat.Long;
            }
            CtlTreeViewColumns.IsUtc = SystemManager.SystemConfig.IsUtc;
            CtlTreeViewColumns.DateTimeFormat = SystemManager.SystemConfig.DateTimeFormat;
            CtlTreeViewColumns.DateTimeCustomFormat = SystemManager.SystemConfig.DateTimeCustomFormat;
            ctlBsonValue.DateTimeFormat = SystemManager.SystemConfig.DateTimeFormat;
            ctlBsonValue.DateTimeCustomFormat = SystemManager.SystemConfig.DateTimeCustomFormat;
            CtlTreeViewColumns.IsDisplayNumberWithKSystem = SystemManager.SystemConfig.IsDisplayNumberWithKSystem;
            ViewHelper.IsUtc = SystemManager.SystemConfig.IsUtc;
            ViewHelper.IsDisplayNumberWithKSystem = SystemManager.SystemConfig.IsDisplayNumberWithKSystem;
            FrmServerMonitor.RefreshInterval = SystemManager.SystemConfig.RefreshStatusTimer;
            MongoDefaults.GuidRepresentation = (MongoDB.Bson.GuidRepresentation)SystemManager.SystemConfig.BsonGuidRepresentation;
            MongoHelper.JsonWriterSettings.OutputMode = SystemManager.SystemConfig.jsonMode;
            FrmServerMonitor.MonitorItems = SystemManager.SystemConfig.MonitorItems;
        }
        #endregion
    }
}