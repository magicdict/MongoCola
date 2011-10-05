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
    class MongodbDosCommand
    {
        
        //mongod.exe 服务端程序
        //mongodump.exe 备份程序
        //mongoexport.exe 数据导出程序
        //mongofiles.exe GridFS工具,内建的分布式文件系统
        //mongoimport.exe 数据导入程序
        //mongorestore.exe 数据恢复程序
        //mongos.exe 数据分片程序，支持数据的横向扩展
        //mongostat.exe 监视程序

        public struct struMongod {
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
            /// 是否作为Windows服务
            /// </summary>
            public Boolean IsInstall = false; 
        }
        /// <summary>
        /// 日志等级
        /// </summary>
        enum MongologLevel { 
        
        }


        /// <summary>
        /// 部署
        /// </summary>
        static public void StartMongod(struMongod Mongod){
            //mongo.exe 客户端程序
            String DosCommand = @"mongod --dbpath @dbpath --port @port ";
            //数据库路径
            DosCommand = DosCommand.Replace("@dbpath", Mongod.dbpath);
            //端口号
            DosCommand = DosCommand.Replace("@port", Mongod.Port.ToString());
            //日志文件
            if (Mongod.logpath != String.Empty) {
                DosCommand += " --logpath " + Mongod.logpath;
                //日志是否为添加模式
                if (Mongod.Islogappend) {
                    DosCommand += " --logappend ";
                }
            }
            //是否为Master
            if (Mongod.IsMaster) {
                DosCommand += " --master";
            }
            //是否作为Windows服务
            if (Mongod.IsMaster)
            {
                DosCommand += " --install";
            }

            RunDosCommand(DosCommand);
        }

        private static void RunDosCommand(String DosCommand) {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe ";
            p.StartInfo.Arguments = DosCommand;
            p.Start();
        }

        private static void RunDosCommandAdvance(String DosCommand,StringBuilder sb) {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd.exe ";//DOS控制平台
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
            sIn.Write("ver " + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write("dir " + System.Environment.NewLine);//DOS控制平台上的命令
            sIn.Write("exit " + System.Environment.NewLine);
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
