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
