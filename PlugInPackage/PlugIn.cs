using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MongoUtility.Core;
using ResourceLib.Utility;

namespace PlugInPackage
{
    public static class PlugIn
    {
        public static GUIConfig guiConfig;

        /// <summary>
        ///     插件列表
        /// </summary>
        public static Dictionary<string, PlugInBase> PlugInList = new Dictionary<string, PlugInBase>();

        /// <summary>
        ///     运行插件
        /// </summary>
        /// <param name="PlugInKeyCode"></param>
        public static void RunPlugIn(string PlugInKeyCode)
        {
            var mPlug = PlugInList[PlugInKeyCode];
            switch (mPlug.RunLv)
            {
                case PlugInBase.PathLv.ConnectionLV:
                    mPlug.PlugObj = RuntimeMongoDBContext.GetCurrentServer();
                    break;
                case PlugInBase.PathLv.InstanceLV:
                    mPlug.PlugObj = RuntimeMongoDBContext.GetCurrentServer();
                    break;
                case PlugInBase.PathLv.DatabaseLV:
                    mPlug.PlugObj = RuntimeMongoDBContext.GetCurrentDataBase();
                    break;
                case PlugInBase.PathLv.CollectionLV:
                    mPlug.PlugObj = RuntimeMongoDBContext.GetCurrentCollection();
                    break;
                case PlugInBase.PathLv.DocumentLV:
                    break;
            }
            mPlug.Run();
        }

        /// <summary>
        ///     加载到菜单项目
        /// </summary>
        public static void LoadPlugIn()
        {
            foreach (var mFile in Directory.GetFiles(Application.StartupPath + @"\", "*.dll"))
            {
                try
                {
                    var FileName = mFile.Replace(Application.StartupPath + @"\", string.Empty);
                    //正式版本中，应该不会有这些
                    if (FileName != "PlugInPackage.dll") continue;
                    var mAssem = Assembly.LoadFile(mFile);
                    var TypeName = FileName.Substring(0, FileName.Length - 4);
                    var mTypelist = mAssem.GetTypes();
                    foreach (var mType in mTypelist)
                    {
                        if (mType.BaseType == typeof (PlugInBase))
                        {
                            var ConstructorInfo = mType.GetConstructor(new Type[] {});
                            var mPlug = (PlugInBase) ConstructorInfo.Invoke(new object[] {});
                            PlugInList.Add(TypeName + "." + mType, mPlug);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }
    }
}