using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

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

        //mongod.exe 服务端程序
        //mongodump.exe 备份程序
        //mongoexport.exe 数据导出程序
        //mongofiles.exe GridFS工具,内建的分布式文件系统
        //mongoimport.exe 数据导入程序
        //mongorestore.exe 数据恢复程序
        //mongos.exe 数据分片程序，支持数据的横向扩展
        //mongostat.exe 监视程序

        /// <summary>
        /// Mongod使用结构体
        /// </summary>
        public class struMongod
        {
            /// <summary>
            /// 数据库路径，必须
            /// </summary>
            public String dbpath = string.Empty;
            /// <summary>
            /// 端口号
            /// </summary>
            public int Port = 27017;
            /// <summary>
            /// 是否为Master
            /// </summary>
            public Boolean IsMaster = false;
            /// <summary>
            /// 是否为Master
            /// </summary>
            public Boolean IsSlave = false;
            /// <summary>
            /// 
            /// </summary>
            public String Source = String.Empty;
            /// <summary>
            /// 日志文件
            /// </summary>
            public String logpath = String.Empty;
            /// <summary>
            /// 日志是否为添加模式
            /// </summary>
            public Boolean Islogappend = false;
            /// <summary>
            /// 日志等级
            /// </summary>
            public MongologLevel loglv = MongologLevel.quiet;
            /// <summary>
            /// 是否作为Windows服务
            /// </summary>
            public Boolean IsInstall = false;
            /// <summary>
            /// 是否采用认证模式
            /// </summary>
            public Boolean IsAuth = false;
        }
        /// <summary>
        /// 日志等级
        /// </summary>
        public enum MongologLevel : int
        {
            /// <summary>
            /// 最少
            /// </summary>
            quiet = 1,
            /// <summary>
            /// Verb * 1
            /// </summary>
            v,
            /// <summary>
            /// Verb * 2
            /// </summary>
            vv,
            /// <summary>
            /// Verb * 3
            /// </summary>
            vvv,
            /// <summary>
            /// Verb * 4
            /// </summary>
            vvvv,
            /// <summary>
            /// Verb * 5
            /// </summary>
            vvvvv
        };
        /// <summary>
        /// 部署
        /// </summary>
        static public String GetMongodCommandLine(struMongod Mongod)
        {
            //mongo.exe 客户端程序
            String DosCommand = @"mongod --dbpath @dbpath --port @port ";
            //数据库路径
            DosCommand = DosCommand.Replace("@dbpath", Mongod.dbpath);
            //端口号
            DosCommand = DosCommand.Replace("@port", Mongod.Port.ToString());
            //日志文件
            if (Mongod.logpath != String.Empty)
            {
                DosCommand += " --logpath " + Mongod.logpath;
                switch (Mongod.loglv)
                {
                    case MongologLevel.quiet:
                        DosCommand += " --quiet ";
                        break;
                    case MongologLevel.v:
                        DosCommand += " --verbose ";
                        break;
                    case MongologLevel.vv:
                        DosCommand += " --vv ";
                        break;
                    case MongologLevel.vvv:
                        DosCommand += " --vvv ";
                        break;
                    case MongologLevel.vvvv:
                        DosCommand += " --vvvv ";
                        break;
                    case MongologLevel.vvvvv:
                        DosCommand += " --vvvvv ";
                        break;
                    default:
                        break;
                }
                //日志是否为添加模式
                if (Mongod.Islogappend)
                {
                    DosCommand += " --logappend ";
                }
            }
            //是否为Master
            if (Mongod.IsMaster)
            {
                DosCommand += " --master";
            }
            if (Mongod.IsSlave)
            {
                DosCommand += " --slave";
                if (Mongod.Source != String.Empty) {
                    DosCommand += " --source " + Mongod.Source;
                }
            }
            //是否作为Windows服务
            if (Mongod.IsInstall)
            {
                DosCommand += " --install";
            }
            //是否使用认证服务
            if (Mongod.IsAuth)
            {
                DosCommand += " --auth";
            }
            return DosCommand;
        }

        /// <summary>
        /// Mongodump使用的结构
        /// </summary>
        public class struMongodump
        {
            public String HostAddr = string.Empty;
            public Int32 Port = 27017;
            public String DBName = String.Empty;
            public String CollectionName = String.Empty;
            public String OutPutPath = String.Empty;
            public MongologLevel loglv = MongologLevel.quiet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mongodump"></param>
        /// <returns></returns>
        static public String GetMongodumpCommandLine(struMongodump Mongodump)
        {
            //mongodump.exe 备份程序
            String DosCommand = @"mongodump -h @hostaddr:@port -d @dbname";
            DosCommand = DosCommand.Replace("@hostaddr", Mongodump.HostAddr);
            DosCommand = DosCommand.Replace("@port", Mongodump.Port.ToString());
            DosCommand = DosCommand.Replace("@dbname", Mongodump.DBName);
            if (Mongodump.CollectionName != string.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                DosCommand += " --collection " + Mongodump.CollectionName;
            }
            if (Mongodump.OutPutPath != string.Empty)
            {
                //-o CollectionName Or --out CollectionName
                DosCommand += " --out " + Mongodump.OutPutPath;
            }
            return DosCommand;
        }

        public enum ImprotExport { 
            Import,
            Export
        }
        public class struImportExport {
            public String HostAddr = string.Empty;
            public Int32 Port = 27017;
            public String DBName = String.Empty;
            public String CollectionName = String.Empty;
            public String FieldList = String.Empty;
            public String FileName = String.Empty;
            public MongologLevel loglv = MongologLevel.quiet;
            public ImprotExport Direct = ImprotExport.Import;
        }

        static public String GetMongoImportExportCommandLine(struImportExport MongoImprotExport)
        {
            //mongodump.exe 备份程序
            String DosCommand;
            if (MongoImprotExport.Direct == ImprotExport.Import) {
                DosCommand = @"mongoimport -h @hostaddr:@port -d @dbname";
                if (MongoImprotExport.FieldList != string.Empty)
                {
                    DosCommand += " --fields " + MongoImprotExport.FieldList;
                }
                if (MongoImprotExport.FileName != string.Empty)
                {
                    DosCommand += " --file " + MongoImprotExport.FileName;
                }
            } else {
                DosCommand = @"mongoexport -h @hostaddr:@port -d @dbname";
                if (MongoImprotExport.FileName != string.Empty)
                {
                    DosCommand += " --out " + MongoImprotExport.FileName;
                }
            }
            DosCommand = DosCommand.Replace("@hostaddr", MongoImprotExport.HostAddr);
            DosCommand = DosCommand.Replace("@port", MongoImprotExport.Port.ToString());
            DosCommand = DosCommand.Replace("@dbname", MongoImprotExport.DBName);
            if (MongoImprotExport.CollectionName != string.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                DosCommand += " --collection " + MongoImprotExport.CollectionName;
            }
            return DosCommand;
        }

        /// <summary>
        /// 执行Dos下的命令
        /// </summary>
        /// <param name="DosCommand"></param>
        /// <param name="sb"></param>
        public static void RunDosCommand(String DosCommand, StringBuilder sb)
        {
            Process myProcess = new Process();
            //myProcess.StartInfo.WorkingDirectory = SystemManager.mConfig.MongoBinPath;//DOS控制平台
            myProcess.StartInfo.FileName = "cmd";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.Start();
            StreamWriter sIn = myProcess.StandardInput;//标准输入流
            sIn.AutoFlush = true;
            StreamReader sOut = myProcess.StandardOutput;//标准输入流
            StreamReader sErr = myProcess.StandardError;//标准错误流
            sIn.Write(DosCommand + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write(@"cd " + SystemManager.mConfig.MongoBinPath + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write(DosCommand + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write("exit" + System.Environment.NewLine);
            string s = sOut.ReadToEnd();//读取执行DOS命令后输出信息
            string er = sErr.ReadToEnd();//读取执行DOS命令后错误信息
            sb.AppendLine(s);
            sb.AppendLine(er);
            if (myProcess.HasExited == false)
            {
                myProcess.Kill();
            }
            sIn.Close();
            sOut.Close();
            sErr.Close();
            myProcess.Close();
        }
    }
}
