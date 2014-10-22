using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ResourceLib.Properties;
using Microsoft.Win32;

namespace MongoCola.Module
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
            DBKey = 6,
            KeyInfo = 7,
            UserIcon = 8,
            CollectionList = 9,
            JavaScriptList = 10,
            GFS = 11,
            JsDoc = 12,
            SystemCol = 13,
            Err = 14,
            Connection = 15,
            Servers
        }

        /// <summary>
        ///     扩展名和图片下标关联
        /// </summary>
        public static Dictionary<String, Int32> IconList = new Dictionary<String, Int32>();

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
        private static extern Boolean DeleteObject(IntPtr hObject);

        /// <summary>
        ///     Image转换为Icon
        /// </summary>
        /// <param name="orgImg"></param>
        /// <returns></returns>
        public static Icon ConvertImgToIcon(Image orgImg)
        {
            var bmp = new Bitmap(orgImg);
            IntPtr h = bmp.GetHicon();
            Icon icon = Icon.FromHandle(h);
            // 释放IntPtr
            DeleteObject(h);
            return icon;
        }

        public static byte[] imageToByteArray(Image imageIn, ImageFormat Format)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";
            try
            {
                string ext = Path.GetExtension(fileName).ToLower();
                RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(ext);
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
            MainTreeImage.Images.Add(GetResource.GetImage(ImageType.DBKey));
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
        public static Int32 GetIconIndexByFileName(String fileName, bool isLarge)
        {
            String GetIcon = new FileInfo(fileName).Extension;
            if (IconList.ContainsKey(GetIcon))
            {
                return IconList[GetIcon];
            }
            Icon mIcon = GetIconByFileType(GetIcon, isLarge);
            if (mIcon != null)
            {
                IconImagelist.Images.Add(mIcon);
                IconList.Add(GetIcon, IconImagelist.Images.Count - 1);
                return IconImagelist.Images.Count - 1;
            }
            IconList.Add(GetIcon, 0);
            return 0;
        }

        /// <summary>
        ///     依据文件名读取图标，若指定文件不存在，则返回空值。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetIconByFileName(String fileName)
        {
            if (String.IsNullOrEmpty(fileName)) return null;
            if (!File.Exists(fileName)) return null;
            var shInfo = new SHFILEINFO();
            //Use this to get the small Icon
            Win32.SHGetFileInfo(fileName, 0, ref shInfo, (uint) Marshal.SizeOf(shInfo),
                Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            //The icon is returned in the hIcon member of the shinfo struct
            Icon myIcon = Icon.FromHandle(shInfo.hIcon);
            return myIcon;
        }

        /// <summary>
        ///     给出文件扩展名（.*），返回相应图标
        ///     若不以"."开头则返回文件夹的图标。
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="isLarge"></param>
        /// <returns></returns>
        public static Icon GetIconByFileType(String fileType, bool isLarge)
        {
            if (!String.IsNullOrEmpty(fileType))
            {
                RegistryKey regVersion = null;
                String regFileType = null;
                String regIconString = null;
                String systemDirectory = Environment.SystemDirectory + "\\";

                if (fileType[0] != '.')
                {
                    //直接指定为文件夹图标
                    regIconString = systemDirectory + "shell32.dll,3";
                }
                else
                {
                    //读系统注册表中文件类型信息
                    regVersion = Registry.ClassesRoot.OpenSubKey(fileType, true);
                    if (regVersion != null)
                    {
                        regFileType = regVersion.GetValue(String.Empty) as String;
                        regVersion.Close();
                        regVersion = Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon", true);
                        if (regVersion != null)
                        {
                            regIconString = regVersion.GetValue(String.Empty) as String;
                            regVersion.Close();
                        }
                    }
                    if (regIconString == null)
                    {
                        //没有读取到文件类型注册信息，指定为未知文件类型的图标
                        regIconString = systemDirectory + "shell32.dll,0";
                    }
                }
                String[] fileIcon = regIconString.Split(new[] {','});
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
                    Win32.ExtractIconEx(fileIcon[0], Int32.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                    var IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                    resultIcon = Icon.FromHandle(IconHnd);
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
                        fileIcon = regIconString.Split(new[] {','});
                        resultIcon = null;
                        //调用API方法读取图标
                        var phiconLarge = new int[1];
                        var phiconSmall = new int[1];
                        Win32.ExtractIconEx(fileIcon[0], Int32.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                        var IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                        resultIcon = Icon.FromHandle(IconHnd);
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
        public static Icon GetIconByFileType(String sFileExt)
        {
            {
                String sProg;
                object tmp = Registry.ClassesRoot.OpenSubKey(sFileExt).GetValue(String.Empty);
                //Get the program that will open files with this extension
                sProg =
                    Registry.ClassesRoot.OpenSubKey(tmp.ToString())
                        .OpenSubKey("shell")
                        .OpenSubKey("open")
                        .OpenSubKey("command")
                        .GetValue(String.Empty)
                        .ToString();
                //strip the filename
                sProg = sProg.Substring(0, 1) == Convert.ToChar(34).ToString()
                    ? sProg.Substring(1, sProg.IndexOf(Convert.ToChar(34), 2) - 1)
                    : sProg.Substring(0, sProg.IndexOf(" ", 2));
                sProg = sProg.Replace("%1", String.Empty);
                // Extract the icon from the program
                Icon oIcon = Icon.ExtractAssociatedIcon(sProg);
                return oIcon;
            }
        }

        /// <summary>
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            private readonly IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public String szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] public String szTypeName;
        };

        /// 定义调用的API方法
        private static class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(String pszPath, uint dwFileAttributes, ref SHFILEINFO psfi,
                uint cbSizeFileInfo, uint uFlags);

            [DllImport("shell32.dll")]
            public static extern uint ExtractIconEx(String lpszFile, int nIconIndex, int[] phiconLarge,
                int[] phiconSmall, uint nIcons);
        }
    }
}