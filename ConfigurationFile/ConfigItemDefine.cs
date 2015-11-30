using MongoUtility.Core;
using System.Collections.Generic;
using Common;
using System;

namespace ConfigurationFile
{
    public static class ConfigItemDefine
    {
        /// <summary>
        ///     Config Option Dictionary
        /// </summary>
        public static Dictionary<string, ConfigurationFileOption.Define> ConfigurationItemDictionary =
            new Dictionary<string, ConfigurationFileOption.Define>();

        /// <summary>
        ///     已经选中的项目以及值的字面量
        /// </summary>
        public static Dictionary<string, ConfigurationFileOption.ConfigValue> SelectedConfigurationValueDictionary = new Dictionary<string, ConfigurationFileOption.ConfigValue>();

        /// <summary>
        ///     OptionDefines文件名称
        /// </summary>
        public static string DefineFilename = @"OptionDefines.xml";
        /// <summary>
        ///     OptionValue文件名称
        /// </summary>
        public static string ValueFilename = @"OptionValue.xml";

        /// <summary>
        ///     更新Value
        /// </summary>
        /// <param name="OptionValue"></param>
        public static void UpdateValue(ConfigurationFileOption.ConfigValue OptionValue)
        {
            if (SelectedConfigurationValueDictionary.ContainsKey(OptionValue.Path))
            {
                SelectedConfigurationValueDictionary.Remove(OptionValue.Path);
            }
            SelectedConfigurationValueDictionary.Add(OptionValue.Path, OptionValue);
        }
        /// <summary>
        /// 删除Value
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveValue(string key)
        {
            if (SelectedConfigurationValueDictionary.ContainsKey(key))
            {
                SelectedConfigurationValueDictionary.Remove(key);
            }
        }
        /// <summary>
        ///     加载XML文件
        /// </summary>
        public static void LoadValues()
        {
            List<ConfigurationFileOption.ConfigValue> ValueList = Utility.LoadObjFromXml<List<ConfigurationFileOption.ConfigValue>>(ValueFilename);
            foreach (var item in ValueList)
            {
                SelectedConfigurationValueDictionary.Add(item.Path, item);
            }
        }

        /// <summary>
        ///     保存为XML文件
        /// </summary>
        public static void SaveValues()
        {
            List<ConfigurationFileOption.ConfigValue> ValueList = new List<ConfigurationFileOption.ConfigValue>();
            foreach (var item in SelectedConfigurationValueDictionary.Values)
            {
                ValueList.Add(item);
            }
            Utility.SaveObjAsXml(ValueFilename, ValueList);
        }
        /// <summary>
        ///     保存为Conf文件
        /// </summary>
        /// <param name="ConfFilename"></param>
        public static void SaveAsYMAL(string ConfFilename)
        {
            List<ConfigurationFileOption.ConfigValue> ValueList = new List<ConfigurationFileOption.ConfigValue>();
            List<string> strValueList = new List<string>();
            foreach (var item in SelectedConfigurationValueDictionary.Values)
            {
                ValueList.Add(item);
                strValueList.Add(item.Path + ": " + item.ValueLiteral.Replace(".",YamlHelper.PointChar));
            }
            //YMAL的做成
            if (string.IsNullOrEmpty(ConfFilename)) ConfFilename = @"MongoService.conf";
            YamlHelper.CreateFile(ConfFilename, strValueList);
        }
        /// <summary>
        ///     从外部文件中获取Options列表
        /// </summary>
        public static CTreeNode LoadDefines()
        {
            List<ConfigurationFileOption.Define> Definelist = new List<ConfigurationFileOption.Define>();
            Definelist = Utility.LoadObjFromXml<List<ConfigurationFileOption.Define>>(DefineFilename);
            Definelist.Sort((x, y) => { return x.Path.CompareTo(y.Path); });
            //Root Node
            var Root = new CTreeNode(string.Empty);
            foreach (var item in Definelist)
            {
                System.Diagnostics.Debug.WriteLine(item.Path);
                CTreeNode.AddToRootNode(Root, item.Path);
                ConfigurationItemDictionary.Add(item.Path, item);
            }
            return Root;
        }



        /// <summary>
        ///     将列表存储到外部文件中
        /// </summary>
        public static void SaveDefines()
        {
            List<ConfigurationFileOption.Define> lst = new List<ConfigurationFileOption.Define>();
            //http://docs.mongodb.org/manual/reference/configuration-options/

            #region SystemLog
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.verbosity",
                ValueType = ConfigurationFileOption.MetaType.Int,
                DefaultValueLiteral = "0",
                RangeMax = 5,
                RangeMin = 0,
                Description = "The default log message verbosity level for components. The verbosity level determines the amount of Informational and Debug messages MongoDB outputs.",
                NewSinceVersion = MongoUtility.Basic.EnumMgr.PrimaryVersion.V300
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.quiet",
                ValueType = ConfigurationFileOption.MetaType.Boolean,
                Description = "Run the mongos or mongod in a quiet mode that attempts to limit the amount of output.",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.traceAllExceptions",
                ValueType = ConfigurationFileOption.MetaType.Boolean,
                Description = "Print verbose information for debugging. Use for additional logging for support-related troubleshooting.",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.syslogFacility",
                ValueType = ConfigurationFileOption.MetaType.String,
                DefaultValueLiteral = "user",
                Description = "The facility level used when logging messages to syslog. The value you specify must be supported by your operating system’s implementation of syslog. To use this option, you must enable the --syslog option.",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.path",
                ValueType = ConfigurationFileOption.MetaType.FileName,
                DefaultValueLiteral = "user",
                Description = "The facility level used when logging messages to syslog. The value you specify must be supported by your operating system’s implementation of syslog. To use this option, you must enable the --syslog option.",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.logAppend",
                ValueType = ConfigurationFileOption.MetaType.Boolean,
                Description = "When true, mongos or mongod appends new entries to the end of the log file rather than overwriting the content of the log when the mongos or mongod instance restarts.",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.logRotate",
                ValueType = ConfigurationFileOption.MetaType.List,
                OptionValueList = new List<string>() {
                    "rename","reopen"
                },
                Description = "The behavior for the logRotate command. Specify either rename or reopen:",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.destination",
                ValueType = ConfigurationFileOption.MetaType.List,
                OptionValueList = new List<string>() {
                    "file","syslog"
                },
                Description = "The destination to which MongoDB sends all log output. Specify either file or syslog. If you specify file, you must also specify systemLog.path.",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.timeStampFormat",
                ValueType = ConfigurationFileOption.MetaType.List,
                OptionValueList = new List<string>() {
                    "ctime","iso8601-utc","iso8601-local"
                },
                DefaultValueLiteral = "iso8601-local",
                Description = "The time format for timestamps in log messages. Specify one of the following values:",
            });
            #endregion

            #region systemLog.component
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.component.accessControl.verbosity",
                ValueType = ConfigurationFileOption.MetaType.Int,
                DefaultValueLiteral = "0",
                RangeMax = 5,
                RangeMin = 0,
                Description = "The log message verbosity level for components related to access control. See ACCESS components.",
                NewSinceVersion = MongoUtility.Basic.EnumMgr.PrimaryVersion.V300
            });

            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.component.command.verbosity",
                ValueType = ConfigurationFileOption.MetaType.Int,
                DefaultValueLiteral = "0",
                RangeMax = 5,
                RangeMin = 0,
                Description = "The log message verbosity level for components related to commands. See COMMAND components.",
                NewSinceVersion = MongoUtility.Basic.EnumMgr.PrimaryVersion.V300
            });

            #endregion

            #region processManagement
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "processManagement.fork",
                ValueType = ConfigurationFileOption.MetaType.Boolean,
                Description = "Enable a daemon mode that runs the mongos or mongod process in the background. By default mongos or mongod does not run as a daemon: typically you will run mongos or mongod as a daemon, either by using processManagement.fork or by using a controlling process that handles the daemonization process (e.g. as with upstart and systemd).",
            });
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "processManagement.pidFilePath",
                ValueType = ConfigurationFileOption.MetaType.PathName,
                Description = "Specifies a file location to hold the process ID of the mongos or mongod process where mongos or mongod will write its PID. This is useful for tracking the mongos or mongod process in combination with the --fork option. Without a specified processManagement.pidFilePath option, the process creates no PID file.",
            });

            #endregion

            #region storage 
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "storage.dbPath",
                ValueType = ConfigurationFileOption.MetaType.PathName,
                Description = "The directory where the mongod instance stores its data.",
            });
            #endregion

            Utility.SaveObjAsXml(DefineFilename, lst);
        }


    }
}
