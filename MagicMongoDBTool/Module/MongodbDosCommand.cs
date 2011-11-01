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
        public class StruMongod
        {
            /// <summary>
            /// 数据库路径，必须
            /// </summary>
            public string DBPath = string.Empty;
            /// <summary>
            /// 端口号
            /// </summary>
            public int Port = 27017;
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
            public string Source = string.Empty;
            /// <summary>
            /// 日志文件
            /// </summary>
            public string LogPath = string.Empty;
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
        static public string GetMongodCommandLine(StruMongod mongoD)
        {
            //mongo.exe 客户端程序
            string dosCommand = @"mongod --dbpath @dbpath --port @port ";
            //数据库路径
            dosCommand = dosCommand.Replace("@dbpath", mongoD.DBPath);
            //端口号
            dosCommand = dosCommand.Replace("@port", mongoD.Port.ToString());
            //日志文件
            if (mongoD.LogPath != string.Empty)
            {
                dosCommand += " --logpath " + mongoD.LogPath;
                switch (mongoD.LogLV)
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
                if (mongoD.Islogappend)
                {
                    dosCommand += " --logappend ";
                }
            }
            //是否为Master
            if (mongoD.IsMaster)
            {
                dosCommand += " --master";
            }
            if (mongoD.IsSlave)
            {
                dosCommand += " --slave";
                if (mongoD.Source != String.Empty)
                {
                    dosCommand += " --source " + mongoD.Source;
                }
            }
            //是否作为Windows服务
            if (mongoD.IsInstall)
            {
                dosCommand += " --install";
            }
            //是否使用认证服务
            if (mongoD.IsAuth)
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
            public string HostAddr = string.Empty;
            public Int32 Port = 27017;
            public string DBName = string.Empty;
            public string CollectionName = string.Empty;
            public string OutPutPath = String.Empty;
            public MongologLevel LogLV = MongologLevel.Quiet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mongoDump"></param>
        /// <returns></returns>
        static public string GetMongodumpCommandLine(StruMongoDump mongoDump)
        {
            //mongodump.exe 备份程序
            string dosCommand = @"mongodump -h @hostaddr:@port -d @dbname";
            dosCommand = dosCommand.Replace("@hostaddr", mongoDump.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoDump.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoDump.DBName);
            if (mongoDump.CollectionName != string.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                dosCommand += " --collection " + mongoDump.CollectionName;
            }
            if (mongoDump.OutPutPath != string.Empty)
            {
                //-o CollectionName Or --out CollectionName
                dosCommand += " --out " + mongoDump.OutPutPath;
            }
            return dosCommand;
        }

        public enum ImprotExport
        {
            Import,
            Export
        }
        public class StruImportExport
        {
            public string HostAddr = string.Empty;
            public Int32 Port = 27017;
            public string DBName = string.Empty;
            public string CollectionName = string.Empty;
            public string FieldList = string.Empty;
            public string FileName = string.Empty;
            public MongologLevel LogLV = MongologLevel.Quiet;
            public ImprotExport Direct = ImprotExport.Import;
        }

        static public string GetMongoImportExportCommandLine(StruImportExport mongoImprotExport)
        {
            //mongodump.exe 备份程序
            string dosCommand;
            if (mongoImprotExport.Direct == ImprotExport.Import)
            {
                dosCommand = @"mongoimport -h @hostaddr:@port -d @dbname";
                if (mongoImprotExport.FieldList != string.Empty)
                {
                    dosCommand += " --fields " + mongoImprotExport.FieldList;
                }
                if (mongoImprotExport.FileName != string.Empty)
                {
                    dosCommand += " --file " + mongoImprotExport.FileName;
                }
            }
            else
            {
                dosCommand = @"mongoexport -h @hostaddr:@port -d @dbname";
                if (mongoImprotExport.FileName != string.Empty)
                {
                    dosCommand += " --out " + mongoImprotExport.FileName;
                }
            }
            dosCommand = dosCommand.Replace("@hostaddr", mongoImprotExport.HostAddr);
            dosCommand = dosCommand.Replace("@port", mongoImprotExport.Port.ToString());
            dosCommand = dosCommand.Replace("@dbname", mongoImprotExport.DBName);
            if (mongoImprotExport.CollectionName != string.Empty)
            {
                //-c CollectionName Or --collection CollectionName
                dosCommand += " --collection " + mongoImprotExport.CollectionName;
            }
            return dosCommand;
        }

        /// <summary>
        /// 执行Dos下的命令
        /// </summary>
        /// <param name="dosCommand"></param>
        /// <param name="sb"></param>
        public static void RunDosCommand(string dosCommand, StringBuilder sb)
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
            sIn.Write(dosCommand + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write(@"cd " + SystemManager.ConfigHelperInstance.MongoBinPath + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write(dosCommand + System.Environment.NewLine);//DOS控制平台上的命令
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
