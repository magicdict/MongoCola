using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MagicMongoDBTool.HTTP
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public static class FileOperation
    {
        /// <summary>
        /// 文件读取
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static byte[] ReadFile(String Path)
        {
            FileStream fs = new FileStream(Path, FileMode.Open);
            byte[] bFile = new byte[fs.Length];
            BinaryReader r = new BinaryReader(fs);
            bFile = r.ReadBytes((int)fs.Length);
            r.Close();
            r = null;
            fs.Close();
            return bFile;
        }
    }
}
