using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card
{
    public static class SystemManager
    {
        public static string[] RareNameDic;
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init() {
            RareNameDic = new string[] { "白色", "蓝色", "紫色", "橙色" };
        }
    }
}
