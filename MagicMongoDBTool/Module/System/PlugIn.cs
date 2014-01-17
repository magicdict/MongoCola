using MagicMongoDBTool.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
namespace MagicMongoDBTool.Module
{
    public class PlugIn
    {
        public static Dictionary<String, PlugBase> PlugInList = new Dictionary<string, PlugBase>();
        /// <summary>
        /// 运行插件
        /// </summary>
        /// <param name="PlugInKeyCode"></param>
        public static void RunPlugIn(string PlugInKeyCode)
        {
            System.Reflection.Assembly mAssem = Assembly.LoadFile(Application.StartupPath + @"\PlugIn\" + PlugInKeyCode + ".dll");
            String TypeName = PlugInKeyCode;
            Type mType = mAssem.GetType(TypeName + "." + TypeName);
            ConstructorInfo ConstructorInfo = mType.GetConstructor(new System.Type[] { });
            PlugBase mPlug = (PlugBase)ConstructorInfo.Invoke(new object[] { });
            switch (PlugIn.PlugInList[PlugInKeyCode].RunLv)
            {
                case MagicMongoDBTool.Common.PlugBase.PathLv.ConnectionLV:
                    mPlug.PlugObj = SystemManager.GetCurrentServer();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.InstanceLV:
                    mPlug.PlugObj = SystemManager.GetCurrentServer();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.DatabaseLV:
                    mPlug.PlugObj = SystemManager.GetCurrentDataBase();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.CollectionLV:
                    mPlug.PlugObj = SystemManager.GetCurrentCollection();
                    break;
                case MagicMongoDBTool.Common.PlugBase.PathLv.DocumentLV:
                    break;
                default:
                    break;
            }
            mPlug.Run();
        }
        /// <summary>
        /// 加载到菜单项目
        /// </summary>
        public static void LoadPlugIn()
        {
            ///注意
            ///必须将Common.DLL放在Bin下面！
            foreach (var mFile in System.IO.Directory.GetFiles(Application.StartupPath + @"\PlugIn\","*.dll"))
            {
                try
                {
                    Assembly mAssem = Assembly.LoadFile(mFile);
                    String FileName = mFile.Replace(Application.StartupPath + @"\PlugIn\", String.Empty);
                    if (FileName == "MagicMongoDBTool.Common.dll") continue;
                    String TypeName = FileName.Substring(0, FileName.Length - 4);
                    Type mType = mAssem.GetType(TypeName + "." + TypeName);
                    ConstructorInfo ConstructorInfo = mType.GetConstructor(new System.Type[] {});
                    PlugBase mPlug = (PlugBase)ConstructorInfo.Invoke(new object[] { });
                    PlugInList.Add(TypeName, mPlug);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
        }
    }
}
