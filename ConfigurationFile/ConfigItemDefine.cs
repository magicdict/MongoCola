using MongoUtility.Core;
using System.Collections.Generic;
using Common;

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
        ///     xml文件名称
        /// </summary>
        public static string xmlfilename = @"OptionDefines.xml";

        /// <summary>
        ///     从外部文件中获取Options列表
        /// </summary>
        public static void LoadDefines()
        {
            List<ConfigurationFileOption.Define> Definelist = new List<ConfigurationFileOption.Define>();
            Definelist = Utility.LoadObjFromXml<List<ConfigurationFileOption.Define>>(xmlfilename);
            Definelist.Sort((x, y) => { return x.Path.CompareTo(y.Path); });
            //Root Node
            var Root = new CTreeNode(string.Empty);
            foreach (var item in Definelist)
            {
                System.Diagnostics.Debug.WriteLine(item.Path);
                CTreeNode.AddToRootNode(Root,item.Path);
                ConfigurationItemDictionary.Add(item.Path, item);
            }
        }

        /// <summary>
        ///     将列表存储到外部文件中
        /// </summary>
        public static void SaveDefines()
        {
            List<ConfigurationFileOption.Define> lst = new List<ConfigurationFileOption.Define>();
            //SystemLog
            lst.Add(new ConfigurationFileOption.Define()
            {
                Path = "systemLog.verbosity",
                ValueType = ConfigurationFileOption.MetaType.Int,
                DefaultValueLiteral = "0",
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
            Utility.SaveObjAsXml(xmlfilename, lst);
        }
    }
}
