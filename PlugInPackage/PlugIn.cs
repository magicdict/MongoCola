using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Common;
using MongoUtility.Core;

namespace PlugInPackage
{
    public static class PlugIn
    {
        /// <summary>
        ///     插件列表
        /// </summary>
        public static Dictionary<string, PlugInBase> PlugInList = new Dictionary<string, PlugInBase>();

        /// <summary>
        ///     运行插件
        /// </summary>
        /// <param name="plugInKeyCode"></param>
        public static void RunPlugIn(string plugInKeyCode)
        {
            var mPlug = PlugInList[plugInKeyCode];
            switch (mPlug.RunLv)
            {
                case PlugInBase.PathLv.ConnectionLv:
                    mPlug.PlugObj = RuntimeMongoDbContext.GetCurrentServer();
                    break;
                case PlugInBase.PathLv.InstanceLv:
                    mPlug.PlugObj = RuntimeMongoDbContext.GetCurrentServer();
                    break;
                case PlugInBase.PathLv.DatabaseLv:
                    mPlug.PlugObj = RuntimeMongoDbContext.GetCurrentDataBase();
                    break;
                case PlugInBase.PathLv.CollectionLv:
                    mPlug.PlugObj = RuntimeMongoDbContext.GetCurrentCollection();
                    break;
                case PlugInBase.PathLv.DocumentLv:
                    break;
            }
            mPlug.Run();
        }

        /// <summary>
        ///     加载插件信息
        /// </summary>
        private static void LoadPlugIn()
        {
            foreach (var mFile in Directory.GetFiles(Application.StartupPath + Path.DirectorySeparatorChar, "*.dll"))
            {
                try
                {
                    var fileName = mFile.Replace(Application.StartupPath + Path.DirectorySeparatorChar, string.Empty);
                    //正式版本中，应该不会有这些
                    if (fileName != "PlugInPackage.dll") continue;
                    var mAssem = Assembly.LoadFile(mFile);
                    var typeName = fileName.Substring(0, fileName.Length - 4);
                    var mTypelist = mAssem.GetTypes();
                    foreach (var mType in mTypelist)
                    {
                        if (mType.BaseType == typeof (PlugInBase))
                        {
                            var constructorInfo = mType.GetConstructor(new Type[] {});
                            var mPlug = (PlugInBase) constructorInfo.Invoke(new object[] {});
                            PlugInList.Add(typeName + "." + mType, mPlug);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        /// <summary>
        ///     将插件放入列表
        /// </summary>
        public static void LoadPlugInMenuItem(ToolStripMenuItem plugInToolStripMenuItem)
        {
            try
            {
                LoadPlugIn();
                foreach (var plugin in PlugInList)
                {
                    var plugInType = string.Empty;
                    switch (plugin.Value.RunLv)
                    {
                        case PlugInBase.PathLv.ConnectionLv:
                            plugInType = "[Connection]";
                            break;
                        case PlugInBase.PathLv.InstanceLv:
                            plugInType = "[Instance]";
                            break;
                        case PlugInBase.PathLv.DatabaseLv:
                            plugInType = "[Database]";
                            break;
                        case PlugInBase.PathLv.CollectionLv:
                            plugInType = "[Collection]";
                            break;
                        case PlugInBase.PathLv.DocumentLv:
                            plugInType = "[Document]";
                            break;
                        case PlugInBase.PathLv.Misc:
                            plugInType = "[Misc]";
                            break;
                    }
                    ToolStripItem menu = new ToolStripMenuItem(plugin.Value.PlugName + plugInType);
                    menu.ToolTipText = plugin.Value.PlugFunction;
                    menu.Tag = plugin.Key;
                    menu.Click += (x, y) => RunPlugIn(plugin.Key);
                    plugInToolStripMenuItem.DropDownItems.Add(menu);
                }
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }
    }
}