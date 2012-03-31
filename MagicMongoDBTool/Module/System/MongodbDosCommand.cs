using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MagicMongoDBTool.Module
{
    /// <summary>
    /// DOS方式操作Mongodb的类
    /// </summary>
    /// <remarks>
    /// http://www.cnblogs.com/tommyli/archive/2011/07/22/2114045.html
    /// </remarks>
    public class MongodbDosCommand
    {
        //Utilies of Mongo
        //bsondump (2.0.3)
        //mongod.exe 服务端程序
        //mongodump.exe 备份程序
        //mongoexport.exe 数据导出程序
        //mongofiles.exe GridFS工具,内建的分布式文件系统
        //mongoimport.exe 数据导入程序
        //mongorestore.exe 数据恢复程序
        //mongos.exe 数据分片程序，支持数据的横向扩展
        //mongostat.exe 监视程序
        //mongotop.exe (2.0.3) 
        //*Utilities Changed by Mongo Version

        /// <summary>
        /// Mongod使用结构体
        /// </summary>
        public class StruMongod
        {
            /// <summary>
            /// 数据库路径，必须
            /// </summary>
            public String DBPath = String.Empty;
            /// <summary>
            /// 端口号
            /// </summary>
            public int Port = MongoDBHelper.DEFAULT_PORT;
            /// <summary>
            /// 是否为Master
            /// </summary>
            public bool IsMaster = false;
            /// <summary>
            /// 是否为Master
            /// </summary>
            public bool IsSlave = false;
            /// <summary>
            /// 
            /// </summary>
            public String Source = String.Empty;
            /// <summary>
            /// 日志文件
            /// </summary>
            public String LogPath = String.Empty;
            /// <summary>
            /// 日志是否为添加模式
            /// </summary>
            public bool Islogappend = false;
            /// <summary>
            /// 日志等级
            /// </summary>
            public MongologLevel LogLV = MongologLevel.Quiet;
            /// <summary>
            /// 是否作为Windows服务
            /// </summary>
            public bool IsInstall = false;
            /// <summary>
            /// 是否采用认证模式
            /// </summary>
            public bool IsAuth = false;
        }
        /// <summary>
        /// 日志等级
        /// </summary>
        public enum MongologLevel : int
        {
            /// <summary>
            /// 最少
            /// </summary>
            Quiet = 1,
            /// <summary>
            /// Verb * 1
            /// </summary>
            V,
            /// <summary>
            /// Verb * 2
            /// </summary>
            VV,
            /// <summary>
            /// Verb * 3
            /// </summary>
            VVV,
            /// <summary>
            /// Verb * 4
            /// </summary>
            VVVV,
            /// <summary>
            /// Verb * 5
            /// </summary>
            VVVVV
        };
        /// <summary>
        /// 部署
        /// </summary>
        public static String GetMongodCommandLine(StruMongod mongod)
        {
            //mongo.exe 客户端程序
            String dosCommand = @"mongod --dbpath @dbpath --port @port ";
            //数据库路径
            dosCommand = dosCommand.Replace("@dbpath", "\"" + mongod.DBPath + "\"");
            //端口号
            dosCommand = dosCommand.Replace("@port", mongod.Port.ToString());
            //日志文件
            if (mongod.LogPath != String.Empty)
            {
                dosCommand += " --logpath \"" + mongod.LogPath + "\"";
                switch (mongod.LogLV)
                {
                    case MongologLevel.Quiet:
                        dosCommand += " --quiet ";
                        break;
                    case MongologLevel.V:
                        dosCommand += " --verbose ";
                        break;
                    case MongologLevel.VV:
                        dosCommand += " --vv ";
                        break;
                    case MongologLevel.VVV:
                        dosCommand += " --vvv ";
                        break;
                    case MongologLevel.VVVV:
                        dosCommand += " --vvvv ";
                        break;
                    case MongologLevel.VVVVV:
                        dosCommand += " --vvvvv ";
                        break;
                    default:
                        break;
                }
                //日志是否为添加模式
                if (mongod.Islogappend)
                {
                    dosCommand += " --logappend ";
                }
            }
            //是否为Master
            if (mongod.IsMaster)
            {
                dosCommand += " --master";
            }
            if (mongod.IsSlave)
            {
                dosCommand += " --slave";
                if (mongod.Source != String.Empty)
                {
                    dosCommand += " --source " + mongod.Source;
                }
            }
            //是否作为Windows服务
            if (mongod.IsInstall)
            {
                dosCommand += " --install";
            }
            //是否使用认证服务
            if (mongod.IsAuth)
            {
                dosCommand += " --auth";
            }
            return dosCommand;
        }

        /// <summary>
        /// Mongodump使用的结构
        /// </summary>
        public class StruMongoDump
        {
            /// <summary>
            /// 主机地址
            /// </summary>
            public String HostAddr = String.Empty;
            /// <summary>
            /// 主机端口
            /// </summary>
            public Int32 Port = MongoDBHelper.DEFAULT_PORT;
            /// <summary>
            /// 数据库名称
            /// </summary>
            public String DBName = String.Empty;
            /// <summary>
            /// 数据集名称
            /// </summary>
            public String CollectionName = String.Empty;
            /// <summary>
            /// 输出路径
            /// </summary>
            public String OutPutPath = String.Empty;
            /// <summary>
            /// 日志等级
            /// </summary>
            public MongologLevel LogLV = MongologLevel.Quiet;
        }

        /// <summary>
        /// 获得备份的配置
        /// </summary>
        /// <param name="mongoDump"></param>
        /// <returns></returns>
        static public String GetMongodumpCommandLine(StruMongoDump mongoDump)
        {
            //mongodump.exe 备份程序
            String dosCommand = @"mongodump -h @hostaddr:@port -d @dbname";
            dosCommand = dosCommand.Replace("@hostaddr", mongoDump.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoDump.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoDump.DBName);
            if (mongoDump.CollectionName != String.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                dosCommand += " --collection " + mongoDump.CollectionName;
            }
            if (mongoDump.OutPutPath != String.Empty)
            {
                //-o CollectionName Or --out CollectionName
                dosCommand += " --out \"" + mongoDump.OutPutPath + "\"";
            }
            return dosCommand;
        }
        /// <summary>
        /// MongoRestore使用的结构
        /// </summary>
        public class StruMongoRestore
        {
            /// <summary>
            /// 主机地址
            /// </summary>
            public String HostAddr = String.Empty;
            /// <summary>
            /// 主机端口
            /// </summary>
            public Int32 Port = MongoDBHelper.DEFAULT_PORT;
            /// <summary>
            /// 备份数据库路径
            /// </summary>
            public String DirectoryPerDB = String.Empty;
        }
        /// <summary>
        /// 获得恢复的配置
        /// 和恢复数据库是相同的操作，只是根据目录结构不同进行不同恢复操作
        /// 目录名称表示数据库名称，BSON文件表示数据集
        /// </summary>
        /// <param name="mongoDump"></param>
        /// <returns></returns>
        static public String GetMongoRestoreCommandLine(StruMongoRestore MongoRestore)
        {
            //mongorestore.exe 恢复程序
            String dosCommand = @"mongorestore -h @hostaddr:@port --directoryperdb @dbname";
            dosCommand = dosCommand.Replace("@hostaddr", MongoRestore.HostAddr);
            dosCommand = dosCommand.Replace("@port", MongoRestore.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", MongoRestore.DirectoryPerDB);
            return dosCommand;
        }
        public enum ImprotExport
        {
            /// <summary>
            /// 导入
            /// </summary>
            Import,
            /// <summary>
            /// 导出
            /// </summary>
            Export
        }
        /// <summary>
        /// ImportExport使用的结构
        /// </summary>
        public class StruImportExport
        {
            /// <summary>
            /// 主机地址
            /// </summary>
            public String HostAddr = String.Empty;
            /// <summary>
            /// 主机端口
            /// </summary>
            public Int32 Port = MongoDBHelper.DEFAULT_PORT;
            /// <summary>
            /// 数据库名称
            /// </summary>
            public String DBName = String.Empty;
            /// <summary>
            /// 数据集名称
            /// </summary>
            public String CollectionName = String.Empty;
            /// <summary>
            /// 字段列表
            /// </summary>
            public String FieldList = String.Empty;
            /// <summary>
            /// 文件名称
            /// </summary>
            public String FileName = String.Empty;
            /// <summary>
            /// 日志等级
            /// </summary>
            public MongologLevel LogLV = MongologLevel.Quiet;
            /// <summary>
            /// 导入导出标志
            /// </summary>
            public ImprotExport Direct = ImprotExport.Import;
        }
        /// <summary>
        /// 获得MongoImportExport命令[必须指定数据集名称！！]
        /// </summary>
        /// <param name="mongoImprotExport"></param>
        /// <returns></returns>
        public static String GetMongoImportExportCommandLine(StruImportExport mongoImprotExport)
        {
            //mongodump.exe 备份程序
            String dosCommand;
            if (mongoImprotExport.Direct == ImprotExport.Import)
            {
                dosCommand = @"mongoimport -h @hostaddr:@port -d @dbname";
                if (mongoImprotExport.FieldList != String.Empty)
                {
                    dosCommand += " --fields " + mongoImprotExport.FieldList;
                }
                if (mongoImprotExport.FileName != String.Empty)
                {
                    dosCommand += " --file \"" + mongoImprotExport.FileName + "\"";
                }
            }
            else
            {
                dosCommand = @"mongoexport -h @hostaddr:@port -d @dbname";
                if (mongoImprotExport.FileName != String.Empty)
                {
                    dosCommand += " --out \"" + mongoImprotExport.FileName + "\"";
                }
            }
            dosCommand = dosCommand.Replace("@hostaddr", mongoImprotExport.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoImprotExport.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoImprotExport.DBName);
            if (mongoImprotExport.CollectionName != String.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                dosCommand += " --collection " + mongoImprotExport.CollectionName;
            }
            return dosCommand;
        }
        /// <summary>
        /// Mongo可执行文件目录的检查
        /// </summary>
        /// <returns></returns>
        public static Boolean IsMongoPathExist()
        {
            return Directory.Exists(SystemManager.ConfigHelperInstance.MongoBinPath);
        }
        /// <summary>
        /// 执行Dos下的命令
        /// </summary>
        /// <remarks>Only For Windows Platform</remarks>
        /// <param name="DosCommand"></param>
        /// <param name="sb"></param>
        public static void RunDosCommand(String DosCommand, StringBuilder sb)
        {
            if (!SystemManager.MONO_MODE)
            {
                Process myProcess = new Process();
                myProcess.StartInfo.FileName = "cmd";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.Start();
                //标准输出流
                StreamWriter stringWriter = myProcess.StandardInput;
                stringWriter.AutoFlush = true;
                //标准输入流
                StreamReader stringReader = myProcess.StandardOutput;
                //标准错误流
                StreamReader streamReaderError = myProcess.StandardError;
                //DOS控制平台上的命令
                stringWriter.Write(@"cd " + SystemManager.ConfigHelperInstance.MongoBinPath + System.Environment.NewLine);
                //DOS控制平台上的命令
                stringWriter.Write(DosCommand + System.Environment.NewLine);
                stringWriter.Write("exit" + System.Environment.NewLine);
                //读取执行DOS命令后输出信息
                String s = stringReader.ReadToEnd();
                //读取执行DOS命令后错误信息
                String er = streamReaderError.ReadToEnd();
                sb.AppendLine(s);
                sb.AppendLine(er);
                if (myProcess.HasExited == false)
                {
                    myProcess.Kill();
                }
                stringWriter.Close();
                stringReader.Close();
                streamReaderError.Close();
                myProcess.Close();
            }
            else
            {
                sb.AppendLine("This method is not implement in Linux");
            }
        }
    }
}
