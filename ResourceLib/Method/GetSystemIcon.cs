using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using ResourceLib.Properties;

namespace ResourceLib.Method
{
    /// <summary>
    ///     提供从操作系统读取图标的方法
    /// </summary>
    public static class GetSystemIcon
    {
        /// <summary>
        ///     主树形控件图标类型
        /// </summary>
        public enum MainTreeImageType
        {
            Blank = 0,
            WebServer = 1,
            Database = 2,
            Collection = 3,
            Keys = 4,
            Document = 5,
            DbKey = 6,
            KeyInfo = 7,
            UserIcon = 8,
            CollectionList = 9,
            JavaScriptList = 10,
            Gfs = 11,
            JsDoc = 12,
            SystemCol = 13,
            Err = 14,
            Connection = 15,
            Servers
        }

        /// <summary>
        ///     扩展名和图片下标关联
        /// </summary>
        public static Dictionary<string, int> IconList = new Dictionary<string, int>();

        /// <summary>
        ///     图片数组
        /// </summary>
        public static ImageList IconImagelist = new ImageList();

        /// <summary>
        ///     主树形控件图标数组
        /// </summary>
        public static ImageList MainTreeImage = new ImageList();

        /// <summary>
        ///     主树形控件图标数组
        /// </summary>
        public static ImageList TabViewImage = new ImageList();

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        ///     Image转换为Icon
        /// </summary>
        /// <param name="orgImg"></param>
        /// <returns></returns>
        public static Icon ConvertImgToIcon(Image orgImg)
        {
            var bmp = new Bitmap(orgImg);
            var h = bmp.GetHicon();
            var icon = Icon.FromHandle(h);
            // 释放IntPtr  Mono...Crash
            DeleteObject(h);
            return icon;
        }

        public static byte[] ImageToByteArray(Image imageIn, ImageFormat format)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetContentType(string fileName)
        {
            var contentType = "application/octetstream";
            try
            {
                var ext = Path.GetExtension(fileName).ToLower();
                var registryKey = Registry.ClassesRoot.OpenSubKey(ext);
                if (registryKey != null && registryKey.GetValue("Content Type") != null)
                    contentType = registryKey.GetValue("Content Type").ToString();
            }
            catch (Exception)
            {
            }
            return contentType;
        }

        /// <summary>
        ///     主树形控件图标数组初始化
        /// </summary>
        public static void InitMainTreeImage()
        {
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.Blank));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.WebServer));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.Database));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.Collection));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.Keys));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.Document));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.DbKey));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.KeyInfo));
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.User));

            MainTreeImage.Images.Add(Resources.CollectionList);
            MainTreeImage.Images.Add(Resources.JavaScriptList);
            MainTreeImage.Images.Add(Resources.GFS);
            MainTreeImage.Images.Add(Resources.Edit);
            MainTreeImage.Images.Add(Resources.SystemCollection);

            MainTreeImage.Images.Add(GetResource.GetIcon(IconType.No));
            MainTreeImage.Images.Add(Resources.Connection);
            MainTreeImage.Images.Add(Resources.Servers);
        }

        /// <summary>
        /// </summary>
        public static void InitTabViewImage()
        {
            TabViewImage.Images.Add(Resources.Monitor);
            TabViewImage.Images.Add(Resources.JavaScriptList);
            TabViewImage.Images.Add(Resources.Collection);
            TabViewImage.Images.Add(Resources.User);
            TabViewImage.Images.Add(Resources.GFS);

            IconImagelist.Images.Add(Resources.NewDocument);
        }

        /// <summary>
        ///     根据文件名获得图片数组下标
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isLarge"></param>
        /// <returns></returns>
        public static int GetIconIndexByFileName(string fileName, bool isLarge)
        {
            var getIcon = new FileInfo(fileName).Extension;
            if (IconList.ContainsKey(getIcon))
            {
                return IconList[getIcon];
            }
            var mIcon = GetIconByFileType(getIcon, isLarge);
            if (mIcon != null)
            {
                IconImagelist.Images.Add(mIcon);
                IconList.Add(getIcon, IconImagelist.Images.Count - 1);
                return IconImagelist.Images.Count - 1;
            }
            IconList.Add(getIcon, 0);
            return 0;
        }

        /// <summary>
        ///     依据文件名读取图标，若指定文件不存在，则返回空值。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetIconByFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return null;
            if (!File.Exists(fileName)) return null;
            var shInfo = new Shfileinfo();
            //Use this to get the small Icon
            Win32.SHGetFileInfo(fileName, 0, ref shInfo, (uint) Marshal.SizeOf(shInfo),
                Win32.ShgfiIcon | Win32.ShgfiSmallicon);
            //The icon is returned in the hIcon member of the shinfo struct
            var myIcon = Icon.FromHandle(shInfo.hIcon);
            return myIcon;
        }

        /// <summary>
        ///     给出文件扩展名（.*），返回相应图标
        ///     若不以"."开头则返回文件夹的图标。
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="isLarge"></param>
        /// <returns></returns>
        public static Icon GetIconByFileType(string fileType, bool isLarge)
        {
            if (!string.IsNullOrEmpty(fileType))
            {
                string regIconString = null;
                var systemDirectory = Environment.SystemDirectory + "\\";

                if (fileType[0] != '.')
                {
                    //直接指定为文件夹图标
                    regIconString = systemDirectory + "shell32.dll,3";
                }
                else
                {
                    //读系统注册表中文件类型信息
                    RegistryKey regVersion;
                    try
                    {
                        regVersion = Registry.ClassesRoot.OpenSubKey(fileType, true);
                    }
                    catch
                    {
                        //如果没有访问权限,则什么都不做
                        regVersion = null;
                    }
                    if (regVersion != null)
                    {
                        var regFileType = regVersion.GetValue(string.Empty) as string;
                        regVersion.Close();
                        try
                        {
                            //权限问题
                            regVersion = Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon", true);
                            if (regVersion != null)
                            {
                                regIconString = regVersion.GetValue(string.Empty) as string;
                                regVersion.Close();
                            }
                        }
                        catch (Exception)
                        {
                            //如果没有访问权限,则什么都不做
                            regVersion = null;
                        }
                    }
                    if (regIconString == null)
                    {
                        //没有读取到文件类型注册信息，指定为未知文件类型的图标
                        regIconString = systemDirectory + "shell32.dll,0";
                    }
                }
                var fileIcon = regIconString.Split(',');
                if (fileIcon.Length != 2)
                {
                    //系统注册表中注册的标图不能直接提取，则返回可执行文件的通用图标
                    fileIcon = new[] {systemDirectory + "shell32.dll", "2"};
                }
                Icon resultIcon = null;
                try
                {
                    //调用API方法读取图标
                    var phiconLarge = new int[1];
                    var phiconSmall = new int[1];
                    Win32.ExtractIconEx(fileIcon[0], int.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                    var iconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                    resultIcon = Icon.FromHandle(iconHnd);
                }
                catch
                {
                    try
                    {
                        //第二方案
                        resultIcon = GetIconByFileType(fileType);
                    }
                    catch
                    {
                        //默认方案
                        regIconString = systemDirectory + "shell32.dll,0";
                        fileIcon = regIconString.Split(',');
                        resultIcon = null;
                        //调用API方法读取图标
                        var phiconLarge = new int[1];
                        var phiconSmall = new int[1];
                        Win32.ExtractIconEx(fileIcon[0], int.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                        var iconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                        resultIcon = Icon.FromHandle(iconHnd);
                    }
                }
                return resultIcon;
            }

            return null;
        }

        /// <summary>
        ///     根据扩展名获得图标
        /// </summary>
        /// <param name="sFileExt"></param>
        /// <returns></returns>
        public static Icon GetIconByFileType(string sFileExt)
        {
            {
                var tmp = Registry.ClassesRoot.OpenSubKey(sFileExt).GetValue(string.Empty);
                //Get the program that will open files with this extension
                var sProg = Registry.ClassesRoot.OpenSubKey(tmp.ToString())
                    .OpenSubKey("shell")
                    .OpenSubKey("open")
                    .OpenSubKey("command")
                    .GetValue(string.Empty)
                    .ToString();
                //strip the filename
                sProg = sProg.Substring(0, 1) == Convert.ToChar(34).ToString()
                    ? sProg.Substring(1, sProg.IndexOf(Convert.ToChar(34), 2) - 1)
                    : sProg.Substring(0, sProg.IndexOf(" ", 2));
                sProg = sProg.Replace("%1", string.Empty);
                // Extract the icon from the program
                var oIcon = Icon.ExtractAssociatedIcon(sProg);
                return oIcon;
            }
        }

        /// <summary>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Shfileinfo
        {
            public IntPtr hIcon;
            private readonly IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public string szTypeName;
        }

        /// 定义调用的API方法
        private static class Win32
        {
            public const uint ShgfiIcon = 0x100;
            public const uint ShgfiSmallicon = 0x1; // 'Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref Shfileinfo psfi,
                uint cbSizeFileInfo, uint uFlags);

            [DllImport("shell32.dll")]
            public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge,
                int[] phiconSmall, uint nIcons);
        }
    }
}