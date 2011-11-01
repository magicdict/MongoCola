using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;
namespace MagicMongoDBTool.Module
{
    /// <summary>
    /// 提供从操作系统读取图标的方法
    /// </summary>
    public static class GetSystemIcon
    {
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

        public static Dictionary<String, Int32> IconList = new Dictionary<string, Int32>();
        public static ImageList IconImagelist = new ImageList();
        /// <summary>
        /// 依据文件名读取图标，若指定文件不存在，则返回空值。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Icon GetIconByFileName(string fileName)
        {
            if (fileName == null || fileName.Equals(string.Empty))
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
        public static Int32 GetIconIndexByFileName(string fileName, bool isLarge)
        {
            string[] extName = fileName.Split(@"\".ToCharArray());
            string extFileName = extName[extName.Length - 1];
            string[] ext = fileName.Split(".".ToCharArray());
            string GetIcon = string.Empty;
            if (ext.Length > 0)
            {
                GetIcon = "." + ext[ext.Length - 1];
            }

            if (IconList.ContainsKey(GetIcon))
            {
                return IconList[GetIcon];
            }
            else
            {
                IconImagelist.Images.Add(GetIconByFileType(GetIcon, isLarge));
                IconList.Add(GetIcon, IconImagelist.Images.Count - 1);
                return IconImagelist.Images.Count - 1;
            }
        }
        /// <summary>
        /// 给出文件扩展名（.*），返回相应图标
        /// 若不以"."开头则返回文件夹的图标。
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="isLarge"></param>
        /// <returns></returns>
        public static Icon GetIconByFileType(string fileType, bool isLarge)
        {
            if (fileType == null || fileType.Equals(string.Empty))
            {
                return null;
            }

            RegistryKey regVersion = null;
            string regFileType = null;
            string regIconString = null;
            string systemDirectory = Environment.SystemDirectory + "\\";

            if (fileType[0] == '.')
            {
                //读系统注册表中文件类型信息
                regVersion = Registry.ClassesRoot.OpenSubKey(fileType, true);
                if (regVersion != null)
                {
                    regFileType = regVersion.GetValue("") as string;
                    regVersion.Close();
                    regVersion = Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon", true);
                    if (regVersion != null)
                    {
                        regIconString = regVersion.GetValue("") as string;
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
            string[] fileIcon = regIconString.Split(new char[] { ',' });
            if (fileIcon.Length != 2)
            {
                //系统注册表中注册的标图不能直接提取，则返回可执行文件的通用图标
                fileIcon = new string[] { systemDirectory + "shell32.dll", "2" };
            }
            Icon resultIcon = null;
            try
            {
                //调用API方法读取图标
                int[] phiconLarge = new int[1];
                int[] phiconSmall = new int[1];
                uint count = Win32.ExtractIconEx(fileIcon[0], Int32.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                IntPtr IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                resultIcon = Icon.FromHandle(IconHnd);
            }
            catch { }
            return resultIcon;
        }
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
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
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        [DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
    }
}

