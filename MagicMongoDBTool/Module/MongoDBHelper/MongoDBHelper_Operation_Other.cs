using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Bson;
using System;
using System.IO;

namespace MagicMongoDBTool.Module
{
    public static partial class MongoDBHelper
    {
        #region"GFS操作"

        /// <summary>
        /// Save And Open String As File
        /// </summary>
        /// <param name="strJson"></param>
        public static void SaveAndOpenStringAsFile(String strJson)
        {
            if (!Directory.Exists(TempFileFolder))
            {
                Directory.CreateDirectory(TempFileFolder);
            }
            String LocalFileName = TempFileFolder + System.IO.Path.DirectorySeparatorChar + "JsonData.txt";
            StreamWriter t = new StreamWriter(LocalFileName, false);
            t.Write(strJson);
            t.Close();
            System.Diagnostics.Process.Start(LocalFileName);
        }


        ///在使用GirdFileSystem的时候，请注意：
        ///1.Windows 系统的文件名不区分大小写，不过，filename一定是区分大小写的，如果大小写不匹配的话，会发生无法找到文件的问题
        ///2.Download的时候，不能使用SlaveOk选项！

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void OpenFile(String strRemoteFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());

            String[] strLocalFileName = strRemoteFileName.Split(System.IO.Path.DirectorySeparatorChar);

            try
            {
                if (!Directory.Exists(TempFileFolder))
                {
                    Directory.CreateDirectory(TempFileFolder);
                }
                String LocalFileName = TempFileFolder + System.IO.Path.DirectorySeparatorChar + strLocalFileName[strLocalFileName.Length - 1];
                gfs.Download(LocalFileName, strRemoteFileName);
                System.Diagnostics.Process.Start(LocalFileName);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MyMessageBox.ShowEasyMessage("Error", "No Program can open this file");
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex, "Error", "Exception happend when open file");
            }
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DownloadFile(String strLocalFileName, String strRemoteFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Download(strLocalFileName, strRemoteFileName);
        }
        /// <summary>
        /// 
        /// </summary>
        public struct UpLoadFileOption
        {
            public enumGFSFileName FileNameOpt;
            public enumGFSAlready AlreadyOpt;
            public Boolean IgnoreSubFolder;
            public Char DirectorySeparatorChar;
        }
        /// <summary>
        /// 
        /// </summary>
        public enum enumGFSFileName
        {
            filename,
            path
        }
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public enum UploadResult
        {
            Complete,
            Skip,
            Exception
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <remarks>Mongo允许同名文件，因为id才是主键</remarks>
        /// <param name="strFileName"></param>
        public static UploadResult UpLoadFile(String strFileName, UpLoadFileOption Option)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            String RemoteName = String.Empty;
            if (Option.FileNameOpt == enumGFSFileName.filename)
            {
                RemoteName = new FileInfo(strFileName).Name;
            }
            else
            {
                if (Option.DirectorySeparatorChar != Path.DirectorySeparatorChar)
                {
                    RemoteName = strFileName.Replace(Path.DirectorySeparatorChar, Option.DirectorySeparatorChar);
                }
                else
                {
                    RemoteName = strFileName;
                }
            }
            try
            {
                OnActionDone(new ActionDoneEventArgs(RemoteName + " Uploading "));
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
        /// 删除文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void DelFile(String strFileName)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            MongoGridFS gfs = mongoDB.GetGridFS(new MongoGridFSSettings());
            gfs.Delete(strFileName);
        }
        /// <summary>
        /// GFS初始化
        /// </summary>
        public static void InitGFS()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(COLLECTION_NAME_GFS_FILES))
            {
                mongoDB.CreateCollection(COLLECTION_NAME_GFS_FILES);
            }
        }
        /// <summary>
        /// 数据库User初始化
        /// </summary>
        public static void InitDBUser()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(COLLECTION_NAME_USER))
            {
                mongoDB.CreateCollection(COLLECTION_NAME_USER);
            }
        }
        /// <summary>
        /// Js数据集初始化
        /// </summary>
        public static void InitJavascript()
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            if (!mongoDB.CollectionExists(COLLECTION_NAME_JAVASCRIPT))
            {
                mongoDB.CreateCollection(COLLECTION_NAME_JAVASCRIPT);
            }
        }
        #endregion

        #region"用户操作"

        public class MongoUserEx
        {
            public string Username;
            public string Password;
            public BsonArray roles;
            public string userSource;
            public BsonDocument otherDBRoles;
        }
        //这里有个漏洞,对于数据库来说，对于local的验证和对于admin的验证是相同的。
        //如果是加入用户到服务器中，是加入到local还是admin，需要考虑一下。
        /// <summary>
        /// Add A User to Admin database
        /// </summary>
        /// <param name="strUser">Username</param>
        /// <param name="password">Password</param>
        /// <param name="isReadOnly">Is ReadOnly</param>
        public static void AddUserToSystem(MongoUserEx newUserEx, Boolean IsAdmin)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentServer();
            //必须使用MongoCredentials来添加用户,不然的话，Password将使用明文登入到数据库中！
            //这样的话，在使用MongoCredentials登入的时候，会发生密码错误引发的认证失败
            MongoCollection users;
            if (IsAdmin)
            {
                users = mongoSvr.GetDatabase(DATABASE_NAME_ADMIN).GetCollection("system.users");
            }
            else
            {
                users = SystemManager.GetCurrentDataBase().GetCollection("system.users");
            }
            if (users.Database.FindUser(newUserEx.Username) == null)
            {
                AddUserEx(users, newUserEx);
            }
        }
        // public methods
        /// <summary>
        /// Adds a user to this database.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void AddUserEx(MongoCollection Col, MongoUserEx user)
        {
            var document = Col.FindOneAs<BsonDocument>(MongoDB.Driver.Builders.Query.EQ("user", user.Username));
            if (document == null)
            {
                document = new BsonDocument("user", user.Username);
            }
            document["roles"] = user.roles;
            document["pwd"] = user.Password;
            Col.Save(document);
        }
        /// <summary>
        /// Remove A User From Admin database
        /// </summary>
        /// <param name="strUser">UserName</param>
        public static void RemoveUserFromSystem(String strUser,Boolean IsAdmin)
        {
            MongoServer mongoSvr = SystemManager.GetCurrentServer();
            MongoDatabase users;
            if (IsAdmin) { 
                users= mongoSvr.GetDatabase(DATABASE_NAME_ADMIN);
            }else{
                users = SystemManager.GetCurrentDataBase();
            }
            if (users.FindUser(strUser) != null)
            {
                users.RemoveUser(strUser);
            }
        }
        #endregion
    }
}

