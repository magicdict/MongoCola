using MongoCola;
using MongoCola.Module;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Common.GFS
{
    public static class GFS
    {
        #region"GFS操作"

        /// <summary>
        /// </summary>
        public enum UploadResult
        {
            Complete,
            Skip,
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
        public static void SaveAndOpenStringAsFile(String strJson)
        {
            if (!Directory.Exists(MongoDbHelper.TempFileFolder))
            {
                Directory.CreateDirectory(MongoDbHelper.TempFileFolder);
            }
            String localFileName = MongoDbHelper.TempFileFolder + Path.DirectorySeparatorChar + "JsonData.txt";
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
        public static void OpenFile(String strRemoteFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());

            String[] strLocalFileName = strRemoteFileName.Split(Path.DirectorySeparatorChar);

            try
            {
                if (!Directory.Exists(MongoDbHelper.TempFileFolder))
                {
                    Directory.CreateDirectory(MongoDbHelper.TempFileFolder);
                }
                String LocalFileName = MongoDbHelper.TempFileFolder + Path.DirectorySeparatorChar +
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
                SystemManager.ExceptionDeal(ex, "Error", "Exception happend when open file");
            }
        }

        /// <summary>
        ///     下载文件
        /// </summary>
        /// <param name="strLocalFileName"></param>
        /// <param name="strRemoteFileName"></param>
        public static void DownloadFile(String strLocalFileName, String strRemoteFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Download(strLocalFileName, strRemoteFileName);
        }

        /// <summary>
        ///     上传文件
        /// </summary>
        /// <remarks>Mongo允许同名文件，因为id才是主键</remarks>
        /// <param name="strFileName"></param>
        public static UploadResult UpLoadFile(String strFileName, UpLoadFileOption Option)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            String RemoteName = String.Empty;
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
                MongoDbHelper.OnActionDone(new ActionDoneEventArgs(RemoteName + " Uploading "));
                if (!gfs.Exists(RemoteName))
                {
                    gfs.Upload(strFileName, RemoteName);
                    return UploadResult.Complete;
                }
                else
                {
                    switch (Option.AlreadyOpt)
                    {
                        case enumGFSAlready.JustAddIt:
                            gfs.Upload(strFileName, RemoteName);
                            return UploadResult.Complete;
                        case enumGFSAlready.RenameIt:
                            String ExtendName = new FileInfo(strFileName).Extension;
                            String MainName = RemoteName.Substring(0, RemoteName.Length - ExtendName.Length);
                            int i = 1;
                            while (gfs.Exists(MainName + i.ToString() + ExtendName))
                            {
                                i++;
                            }
                            gfs.Upload(strFileName, MainName + i.ToString() + ExtendName);
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
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex);
                return UploadResult.Exception;
            }
        }

        /// <summary>
        ///     删除文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DelFile(String strFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Delete(strFileName);
        }

        /// <summary>
        ///     GFS初始化
        /// </summary>
        public static void InitGFS()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(MongoDbHelper.COLLECTION_NAME_GFS_FILES))
            {
                mongoDB.CreateCollection(MongoDbHelper.COLLECTION_NAME_GFS_FILES);
            }
        }

        /// <summary>
        ///     数据库User初始化
        /// </summary>
        public static void InitDBUser()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(MongoDbHelper.COLLECTION_NAME_USER))
            {
                mongoDB.CreateCollection(MongoDbHelper.COLLECTION_NAME_USER);
            }
        }

        /// <summary>
        ///     Js数据集初始化
        /// </summary>
        public static void InitJavascript()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(MongoDbHelper.COLLECTION_NAME_JAVASCRIPT))
            {
                mongoDB.CreateCollection(MongoDbHelper.COLLECTION_NAME_JAVASCRIPT);
            }
        }

        /// <summary>
        /// </summary>
        public struct UpLoadFileOption
        {
            public enumGFSAlready AlreadyOpt;
            public Char DirectorySeparatorChar;
            public enumGFSFileName FileNameOpt;
            public Boolean IgnoreSubFolder;
        }

        #endregion
    }
}