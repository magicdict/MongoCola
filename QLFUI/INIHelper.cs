using System.Runtime.InteropServices;
using System.Text;

namespace QLFUI
{
    internal class IniHelper
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        public static string ReadIniValue(string path, string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, 255, path);
            return sb.ToString();
        }

        public static void WriteIniValue(string path, string section, string key, string keyValue)
        {
            WritePrivateProfileString(section, key, keyValue, path);
        }
    }
}
