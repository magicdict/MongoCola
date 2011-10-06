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
        }
        /// <summary>
        /// 日志等级
        /// </summary>
        public enum MongologLevel:int   
        {
            /// <summary>
            /// 最少
            /// </summary>
            quiet=1,
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
            String DosCommand = @"mongod.exe --dbpath @dbpath --port @port ";
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
            //是否作为Windows服务
            if (Mongod.IsInstall)
            {
                DosCommand += " --install";
            }
            return DosCommand;
        }

        /// <summary>
        /// Mongodump使用的结构
        /// </summary>
        public class struMongodump {
            String HostName;
            Int32 Port=27017;
            String DBName = String.Empty;
            String CollectionName = String.Empty;
            String OutPutPath = String.Empty;
        }
        
        /// <summary>
        /// 执行Dos下的命令
        /// </summary>
        /// <param name="DosCommand"></param>
        /// <param name="sb"></param>
        public static void RunDosCommand(String DosCommand, StringBuilder sb)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.WorkingDirectory = SystemManager.mConfig.MongoBinPath ;//DOS控制平台
            myProcess.StartInfo.FileName = SystemManager.mConfig.MongoBinPath + DosCommand.Split(" ".ToCharArray())[0];
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
