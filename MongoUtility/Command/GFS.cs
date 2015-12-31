using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Common;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoUtility.EventArgs;
using MongoUtility.ToolKit;

namespace MongoUtility.Command
{
    public static class Gfs
    {
        /// <summary>
        ///     TempFileFolder
        /// </summary>
        public const string TempFileFolder = "TempFile";

        #region"GFS操作"

        /// <summary>
        ///     上传结果
        /// </summary>
        public enum UploadResult
        {
            /// <summary>
            ///     完成
            /// </summary>
            Complete,

            /// <summary>
            ///     忽视
            /// </summary>
            Skip,

            /// <summary>
            ///     异常
            /// </summary>
            Exception
        }

        /// <summary>
        /// </summary>
        public enum EnumGfsAlready
        {
            JustAddIt,
            RenameIt,
            SkipIt,
            OverwriteIt,
            Stop
        }

        /// <summary>
        /// </summary>
        public enum EnumGfsFileName
        {
            Filename,
            Path
        }

        /// <summary>
        ///     Save And Open String As File
        /// </summary>
        /// <param name="strJson"></param>
        public static void SaveAndOpenStringAsFile(string strJson)
        {
            if (!Directory.Exists(TempFileFolder))
            {
                Directory.CreateDirectory(TempFileFolder);
            }
            var localFileName = TempFileFolder + Path.DirectorySeparatorChar + "JsonData.txt";
            var t = new StreamWriter(localFileName, false);
            t.Write(strJson);
            t.Close();
            Process.Start(localFileName);
        }


        /// 在使用GirdFileSystem的时候，请注意：
        /// 1.Windows 系统的文件名不区分大小写，不过，filename一定是区分大小写的，如果大小写不匹配的话，会发生无法找到文件的问题
        /// 2.Download的时候，不能使用SlaveOk选项！
        /// <summary>
        ///     打开文件
        /// </summary>
        /// <param name="strRemoteFileName"></param>
        /// <param name="mongoDb"></param>
        public static void OpenFile(string strRemoteFileName, MongoDatabase mongoDb)
        {
            var gfs = mongoDb.GetGridFS(new MongoGridFSSettings());

            var strLocalFileName = strRemoteFileName.Split(Path.DirectorySeparatorChar);

            try
            {
                if (!Directory.Exists(TempFileFolder))
                {
                    Directory.CreateDirectory(TempFileFolder);
                }
                var localFileName = TempFileFolder + Path.DirectorySeparatorChar +
                                    strLocalFileName[strLocalFileName.Length - 1];
                gfs.Download(localFileName, strRemoteFileName);
                Process.Start(localFileName);
            }
            catch (Win32Exception ex)
            {
                Utility.ExceptionDeal(ex, "No Program can open this file");
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex, "Error", "Exception happend when open file");
            }
        }

        /// <summary>
        ///     下载文件
        /// </summary>
        /// <param name="strLocalFileName"></param>
        /// <param name="strRemoteFileName"></param>
        /// <param name="mongoDb"></param>
        public static void DownloadFile(string strLocalFileName, string strRemoteFileName, MongoDatabase mongoDb)
        {
            var gfs = mongoDb.GetGridFS(new MongoGridFSSettings());
            gfs.Download(strLocalFileName, strRemoteFileName);
        }

        /// <summary>
        ///     上传文件
        /// </summary>
        /// <remarks>Mongo允许同名文件，因为id才是主键</remarks>
        /// <param name="strFileName"></param>
        /// <param name="option"></param>
        /// <param name="mongoDb"></param>
        public static UploadResult UpLoadFile(string strFileName, UpLoadFileOption option, MongoDatabase mongoDb)
        {
            var gfs = mongoDb.GetGridFS(new MongoGridFSSettings());
            string remoteName;
            if (option.FileNameOpt == EnumGfsFileName.Filename)
            {
                remoteName = new FileInfo(strFileName).Name;
            }
            else
            {
                remoteName = option.DirectorySeparatorChar != Path.DirectorySeparatorChar
                    ? strFileName.Replace(Path.DirectorySeparatorChar, option.DirectorySeparatorChar)
                    : strFileName;
            }
            try
            {
                MongoHelper.OnActionDone(new ActionDoneEventArgs(remoteName + " Uploading "));
                if (!gfs.Exists(remoteName))
                {
                    gfs.Upload(strFileName, remoteName);
                    return UploadResult.Complete;
                }
                switch (option.AlreadyOpt)
                {
                    case EnumGfsAlready.JustAddIt:
                        gfs.Upload(strFileName, remoteName);
                        return UploadResult.Complete;
                    case EnumGfsAlready.RenameIt:
                        var extendName = new FileInfo(strFileName).Extension;
                        var mainName = remoteName.Substring(0, remoteName.Length - extendName.Length);
                        var i = 1;
                        while (gfs.Exists(mainName + i + extendName))
                        {
                            i++;
                        }
                        gfs.Upload(strFileName, mainName + i + extendName);
                        return UploadResult.Complete;
                    case EnumGfsAlready.SkipIt:
                        return UploadResult.Skip;
                    case EnumGfsAlready.OverwriteIt:
                        gfs.Delete(remoteName);
                        gfs.Upload(strFileName, remoteName);
                        return UploadResult.Complete;
                    case EnumGfsAlready.Stop:
                        return UploadResult.Skip;
                }
                return UploadResult.Skip;
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
                return UploadResult.Exception;
            }
        }

        /// <summary>
        ///     删除文件
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="mongoDb"></param>
        public static void DelFile(string strFileName, MongoDatabase mongoDb)
        {
            var gfs = mongoDb.GetGridFS(new MongoGridFSSettings());
            gfs.Delete(strFileName);
        }

        /// <summary>
        ///     上传选项
        /// </summary>
        public struct UpLoadFileOption
        {
            public EnumGfsAlready AlreadyOpt;
            public char DirectorySeparatorChar;
            public EnumGfsFileName FileNameOpt;
            public bool IgnoreSubFolder;
        }

        #endregion
    }
}