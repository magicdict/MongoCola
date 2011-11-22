using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace QLFUI
{
    public static class IniHelper
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

        private static Boolean IsInited;

        public static Dictionary<String, Bitmap> ImageDic = new Dictionary<String, Bitmap>();
        /// <summary>
        /// 载入默认
        /// </summary>
        public static void Init()
        {
            if (IsInited)
            {
                return;
            }
            IsInited = true;
            ImageDic.Clear();

            ImageDic.Add("_topLeft", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.TopLeft.bmp"))));
            ImageDic.Add("_topMiddle", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.TopMiddle.bmp"))));
            ImageDic.Add("_topRight", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.TopRight.bmp"))));

            ImageDic.Add("_centerLeft", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MiddleLeft.bmp"))));
            ImageDic.Add("_centerMiddle", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.Middle.bmp"))));
            ImageDic.Add("_centerRight", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MiddleRight.bmp"))));


            ImageDic.Add("_bottomLeft", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.BottomLeft.bmp"))));
            ImageDic.Add("_bottomMiddle", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.BottomMiddle.bmp"))));
            ImageDic.Add("_bottomRight", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.BottomRight.bmp"))));


            ImageDic.Add("MinNormal", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MinNormal.bmp"))));
            ImageDic.Add("MinMove", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MinMove.bmp"))));
            ImageDic.Add("MinDown", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MinDown.bmp"))));

            ImageDic.Add("MaxNormal", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MaxNormal.bmp"))));
            ImageDic.Add("MaxMove", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MaxMove.bmp"))));
            ImageDic.Add("MaxDown", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.MaxDown.bmp"))));

            ImageDic.Add("CloseNormal", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.CloseNormal.bmp"))));
            ImageDic.Add("CloseMove", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.CloseMove.bmp"))));
            ImageDic.Add("CloseDown", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.CloseDown.bmp"))));

            ImageDic.Add("SelectSkinNormal", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.SelectSkinNormal.bmp"))));
            ImageDic.Add("SelectSkinMove", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.SelectSkinMove.bmp"))));
            ImageDic.Add("SelectSkinDown", new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"QLFUI.Resources.SelectSkinDown.bmp"))));



            _trans = Color.FromArgb(255, 0, 255);
        }

        public static void ChangeSkin(String skinFolder)
        {
            ImageDic.Clear();

            ImageDic.Add("_topLeft", Image.FromFile(skinFolder + "\\TopLeft.bmp") as Bitmap);
            ImageDic.Add("_topMiddle", Image.FromFile(skinFolder + "\\TopMiddle.bmp") as Bitmap);
            ImageDic.Add("_topRight", Image.FromFile(skinFolder + "\\TopRight.bmp") as Bitmap);

            ImageDic.Add("_centerLeft", Image.FromFile(skinFolder + "\\MiddleLeft.bmp") as Bitmap);
            ImageDic.Add("_centerMiddle", Image.FromFile(skinFolder + "\\Middle.bmp") as Bitmap);
            ImageDic.Add("_centerRight", Image.FromFile(skinFolder + "\\MiddleRight.bmp") as Bitmap);


            ImageDic.Add("_bottomLeft", Image.FromFile(skinFolder + "\\BottomLeft.bmp") as Bitmap);
            ImageDic.Add("_bottomMiddle", Image.FromFile(skinFolder + "\\BottomMiddle.bmp") as Bitmap);
            ImageDic.Add("_bottomRight", Image.FromFile(skinFolder + "\\BottomRight.bmp") as Bitmap);

            ImageDic.Add("MinNormal", Image.FromFile(skinFolder + "\\MinNormal.bmp") as Bitmap);
            ImageDic.Add("MinMove", Image.FromFile(skinFolder + "\\MinMove.bmp") as Bitmap);
            ImageDic.Add("MinDown", Image.FromFile(skinFolder + "\\MinDown.bmp") as Bitmap);

            ImageDic.Add("MaxNormal", Image.FromFile(skinFolder + "\\MaxNormal.bmp") as Bitmap);
            ImageDic.Add("MaxMove", Image.FromFile(skinFolder + "\\MaxMove.bmp") as Bitmap);
            ImageDic.Add("MaxDown", Image.FromFile(skinFolder + "\\MaxDown.bmp") as Bitmap);

            ImageDic.Add("CloseNormal", Image.FromFile(skinFolder + "\\CloseNormal.bmp") as Bitmap);
            ImageDic.Add("CloseMove", Image.FromFile(skinFolder + "\\CloseMove.bmp") as Bitmap);
            ImageDic.Add("CloseDown", Image.FromFile(skinFolder + "\\CloseDown.bmp") as Bitmap);

            ImageDic.Add("SelectSkinNormal", Image.FromFile(skinFolder + "\\SelectSkinNormal.bmp") as Bitmap);
            ImageDic.Add("SelectSkinMove", Image.FromFile(skinFolder + "\\SelectSkinMove.bmp") as Bitmap);
            ImageDic.Add("SelectSkinDown", Image.FromFile(skinFolder + "\\SelectSkinDown.bmp") as Bitmap);

            //读取需要透明的颜色值
            int r = int.Parse(IniHelper.ReadIniValue(skinFolder + "\\config.ini", "Main", "TransparentColorR"));
            int g = int.Parse(IniHelper.ReadIniValue(skinFolder + "\\config.ini", "Main", "TransparentColorG"));
            int b = int.Parse(IniHelper.ReadIniValue(skinFolder + "\\config.ini", "Main", "TransparentColorB"));
            _trans = Color.FromArgb(r, g, b);
            r = int.Parse(IniHelper.ReadIniValue(skinFolder + "\\config.ini", "Main", "BackColorR"));
            g = int.Parse(IniHelper.ReadIniValue(skinFolder + "\\config.ini", "Main", "BackColorG"));
            b = int.Parse(IniHelper.ReadIniValue(skinFolder + "\\config.ini", "Main", "BackColorB"));
            _backcolor = Color.FromArgb(r, g, b);
        }

        static Color _trans;
        public static Color trans
        {
            get
            {
                return _trans;
            }
        }
        static Color _backcolor = Color.FromArgb(200, 230, 130);
        public static Color BackColor
        {
            get
            {
                return _backcolor;
            }
        }

        public static String skinName = String.Empty;

        public static Bitmap getImage(String strTag)
        {
            return ImageDic[strTag];
        }

    }
}
