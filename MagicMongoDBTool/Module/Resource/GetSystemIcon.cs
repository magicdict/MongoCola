using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool.Module
{
    /// <summary>
    /// 提供从操作系统读取图标的方法
    /// </summary>
    public static class GetSystemIcon
    {
#if !MONO
        [DllImport("gdi32.dll")]
        public static extern Boolean DeleteObject(IntPtr hObject);
        /// <summary>
        /// Image转换为Icon
        /// </summary>
        /// <param name="orgImg"></param>
        /// <returns></returns>
        public static Icon ConvertImgToIcon(Image orgImg)
        {
            Bitmap bmp = new Bitmap(orgImg);
            IntPtr h = bmp.GetHicon();
            Icon icon = System.Drawing.Icon.FromHandle(h);
            DeleteObject(h);// 释放IntPtr
            return icon;
        }
#endif
        /// <summary>
        /// 扩展名和图片下标关联
        /// </summary>
        public static Dictionary<String, Int32> IconList = new Dictionary<String, Int32>();
        /// <summary>
        /// 图片数组
        /// </summary>
        public static ImageList IconImagelist = new ImageList();
        /// <summary>
        /// 主树形控件图标数组
        /// </summary>
        public static ImageList MainTreeImage = new ImageList();
        /// <summary>
        /// 主树形控件图标类型
        /// </summary>
        public enum MainTreeImageType : int
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
            Err = 9
        }
        /// <summary>
        /// 主树形控件图标数组初始化
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
            MainTreeImage.Images.Add(GetResource.GetIcon(IconType.No));
        }
        /// <summary>
        /// 根据文件名获得图片数组下标
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
            else
            {
#if !MONO
                IconImagelist.Images.Add(GetIconByFileType(GetIcon, isLarge));
#else
                //TODO:Linux
#endif
                IconList.Add(GetIcon, IconImagelist.Images.Count - 1);
                return IconImagelist.Images.Count - 1;
            }
        }

#if !MONO
        /// <summary>
        /// 依据文件名读取图标，若指定文件不存在，则返回空值。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetIconByFileName(String fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return null;
            }
            if (!File.Exists(fileName))
            {
                return null;
            }

            SHFILEINFO shInfo = new SHFILEINFO();
            //Use this to get the small Icon
            Win32.SHGetFileInfo(fileName, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            //The icon is returned in the hIcon member of the shinfo struct
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shInfo.hIcon);
            return myIcon;
        }
        /// <summary>
        /// 给出文件扩展名（.*），返回相应图标
        /// 若不以"."开头则返回文件夹的图标。
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="isLarge"></param>
        /// <returns></returns>
        public static Icon GetIconByFileType(String fileType, bool isLarge)
        {
            if (String.IsNullOrEmpty(fileType))
            {
                return null;
            }

            RegistryKey regVersion = null;
            String regFileType = null;
            String regIconString = null;
            String systemDirectory = Environment.SystemDirectory + "\\";

            if (fileType[0] == '.')
            {
                //读系统注册表中文件类型信息
                regVersion = Registry.ClassesRoot.OpenSubKey(fileType, true);
                if (regVersion != null)
                {
                    regFileType = regVersion.GetValue("") as String;
                    regVersion.Close();
                    regVersion = Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon", true);
                    if (regVersion != null)
                    {
                        regIconString = regVersion.GetValue("") as String;
                        regVersion.Close();
                    }
                }
                if (regIconString == null)
                {
                    //没有读取到文件类型注册信息，指定为未知文件类型的图标
                    regIconString = systemDirectory + "shell32.dll,0";
                }
            }
            else
            {
                //直接指定为文件夹图标
                regIconString = systemDirectory + "shell32.dll,3";
            }
            String[] fileIcon = regIconString.Split(new char[] { ',' });
            if (fileIcon.Length != 2)
            {
                //系统注册表中注册的标图不能直接提取，则返回可执行文件的通用图标
                fileIcon = new String[] { systemDirectory + "shell32.dll", "2" };
            }
            Icon resultIcon = null;
            try
            {
                //调用API方法读取图标
                int[] phiconLarge = new int[1];
                int[] phiconSmall = new int[1];
                Win32.ExtractIconEx(fileIcon[0], Int32.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                IntPtr IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                resultIcon = Icon.FromHandle(IconHnd);
            }
            catch { }
            return resultIcon;
        }
#endif

    }

#if !MONO
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public String szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public String szTypeName;
    };
    ///
    /// 定义调用的API方法
    ///
    static class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(String pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(String lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
    }
#endif
}

