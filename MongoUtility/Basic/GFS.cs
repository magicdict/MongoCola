using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using Common.UI;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoUtility.EventArgs;

namespace MongoUtility.Basic
{
    public static class GFS
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
        public enum enumGFSAlready
        {
            JustAddIt,
            RenameIt,
            SkipIt,
            OverwriteIt,
            Stop
        }

        /// <summary>
        /// </summary>
        public enum enumGFSFileName
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
        /// <param name="mongoDB"></param>
        public static void OpenFile(string strRemoteFileName, MongoDatabase mongoDB)
        {
            var gfs = mongoDB.GetGridFS(new MongoGridFSSettings());

            var strLocalFileName = strRemoteFileName.Split(Path.DirectorySeparatorChar);

            try
            {
                if (!Directory.Exists(TempFileFolder))
                {
                    Directory.CreateDirectory(TempFileFolder);
                }
                var LocalFileName = TempFileFolder + Path.DirectorySeparatorChar +
                                    strLocalFileName[strLocalFileName.Length - 1];
                gfs.Download(LocalFileName, strRemoteFileName);
                Process.Start(LocalFileName);
            }
            catch (Win32Exception)
            {
                MyMessageBox.ShowEasyMessage("Error", "No Program can open this file");
            }
            catch (Exception ex)
            {
                Common.Logic.Utility.ExceptionDeal(ex, "Error", "Exception happend when open file");
            }
        }

        /// <summary>
        ///     下载文件
        /// </summary>
        /// <param name="strLocalFileName"></param>
        /// <param name="strRemoteFileName"></param>
        /// <param name="mongoDB"></param>
        public static void DownloadFile(string strLocalFileName, string strRemoteFileName, MongoDatabase mongoDB)
        {
            var gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Download(strLocalFileName, strRemoteFileName);
        }

        /// <summary>
        ///     上传文件
        /// </summary>
        /// <remarks>Mongo允许同名文件，因为id才是主键</remarks>
        /// <param name="strFileName"></param>
        /// <param name="Option"></param>
        /// <param name="mongoDB"></param>
        public static UploadResult UpLoadFile(string strFileName, UpLoadFileOption Option, MongoDatabase mongoDB)
        {
            var gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            var RemoteName = string.Empty;
            if (Option.FileNameOpt == enumGFSFileName.Filename)
            {
                RemoteName = new FileInfo(strFileName).Name;
            }
            else
            {
                RemoteName = Option.DirectorySeparatorChar != Path.DirectorySeparatorChar
                    ? strFileName.Replace(Path.DirectorySeparatorChar, Option.DirectorySeparatorChar)
                    : strFileName;
            }
            try
            {
                Utility.OnActionDone(new ActionDoneEventArgs(RemoteName + " Uploading "));
                if (!gfs.Exists(RemoteName))
                {
                    gfs.Upload(strFileName, RemoteName);
                    return UploadResult.Complete;
                }
                switch (Option.AlreadyOpt)
                {
                    case enumGFSAlready.JustAddIt:
                        gfs.Upload(strFileName, RemoteName);
                        return UploadResult.Complete;
                    case enumGFSAlready.RenameIt:
                        var ExtendName = new FileInfo(strFileName).Extension;
                        var MainName = RemoteName.Substring(0, RemoteName.Length - ExtendName.Length);
                        var i = 1;
                        while (gfs.Exists(MainName + i + ExtendName))
                        {
                            i++;
                        }
                        gfs.Upload(strFileName, MainName + i + ExtendName);
                        return UploadResult.Complete;
                    case enumGFSAlready.SkipIt:
                        return UploadResult.Skip;
                    case enumGFSAlready.OverwriteIt:
                        gfs.Delete(RemoteName);
                        gfs.Upload(strFileName, RemoteName);
                        return UploadResult.Complete;
                    case enumGFSAlready.Stop:
                        return UploadResult.Skip;
                }
                return UploadResult.Skip;
            }
            catch (Exception ex)
            {
                Common.Logic.Utility.ExceptionDeal(ex);
                return UploadResult.Exception;
            }
        }

        /// <summary>
        ///     删除文件
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="mongoDB"></param>
        public static void DelFile(string strFileName, MongoDatabase mongoDB)
        {
            var gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Delete(strFileName);
        }

        /// <summary>
        ///     上传选项
        /// </summary>
        public struct UpLoadFileOption
        {
            public enumGFSAlready AlreadyOpt;
            public Char DirectorySeparatorChar;
            public enumGFSFileName FileNameOpt;
            public bool IgnoreSubFolder;
        }

        #endregion
    }
}