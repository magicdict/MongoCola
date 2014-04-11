using MagicMongoDBTool;
using MagicMongoDBTool.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI
{
    public static class SystemManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MStringResource"></param>
        public static void SwitchLanguage(StringResource MStringResource){
            GUI.SystemManager.IsUseDefaultLanguage = false;
            GUI.SystemManager.MStringResource = MStringResource;
            MyMessageBox.SwitchLanguage(MStringResource);
        }
        public static Boolean IsUseDefaultLanguage = true;
        public static StringResource MStringResource;
    }
}
