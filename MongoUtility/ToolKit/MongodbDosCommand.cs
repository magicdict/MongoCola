using System;
using System.Diagnostics;
using System.Text;

namespace MongoUtility.ToolKit
{
    /// <summary>
    ///     DOS方式操作Mongodb的类
    /// </summary>
    /// <remarks>
    ///     http://www.cnblogs.com/tommyli/archive/2011/07/22/2114045.html
    /// </remarks>
    public static class MongodbDosCommand
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
        ///     日志等级
        /// </summary>
        public enum MongologLevel
        {
            /// <summary>
            ///     最少
            /// </summary>
            Quiet = 0,

            /// <summary>
            ///     Verb * 1
            /// </summary>
            V,

            /// <summary>
            ///     Verb * 2
            /// </summary>
            Vv,

            /// <summary>
            ///     Verb * 3
            /// </summary>
            Vvv,

            /// <summary>
            ///     Verb * 4
            /// </summary>
            Vvvv,

            /// <summary>
            ///     Verb * 5
            /// </summary>
            Vvvvv
        }

        /// <summary>
        ///     Mongo Bin Paht
        /// </summary>
        public static string MongoBinPath;

        /// <summary>
        ///     标准输出
        /// </summary>
        public static string StrOutPut = string.Empty;

        /// <summary>
        ///     标准错误
        /// </summary>
        public static string StrErrorPut = string.Empty;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static string GenerateIniFile(MongodConfig mongod)
        {
            //http://www.mongodb.org/display/DOCS/File+Based+SystemManager(无法阅览，自动跳到下面这个链接)
            //http://docs.mongodb.org/manual/reference/configuration-options/
            //http://www.cnblogs.com/think-first/archive/2013/03/22/2976553.html
            //Location of the database files 

            var strIni = "#Basic database configuration" + Environment.NewLine;

            if (mongod.DbPath != string.Empty)
            {
                strIni += "#Location of the database files   " + Environment.NewLine;
                strIni += "dbpath = " + mongod.DbPath + Environment.NewLine;
            }

            if (mongod.Port != 0)
            {
                strIni += "#Port the mongod will listen on  " + Environment.NewLine;
                strIni += "port = " + mongod.Port + Environment.NewLine;
            }

            strIni += "#Specific IP address that mongod will listen on  " + Environment.NewLine;
            if (mongod.BindIp != string.Empty)
            {
                strIni += "bind_ip  = " + mongod.BindIp + Environment.NewLine;
            }
            else
            {
                strIni += "bind_ip = 127.0.0.1" + Environment.NewLine;
            }

            if (mongod.LogPath != string.Empty)
            {
                strIni += "#Full filename path to where log messages will be written  " + Environment.NewLine;
                strIni += "logpath = " + mongod.LogPath + Environment.NewLine;
            }

            strIni += "#Full filename path to where log messages will be written  " + Environment.NewLine;
            if (mongod.Islogappend)
            {
                strIni += "logappend = true" + Environment.NewLine;
            }
            else
            {
                strIni += "logappend = false " + mongod.LogPath + Environment.NewLine;
            }

            return strIni;
        }

        /// <summary>
        ///     部署
        /// </summary>
        public static string GetMongodCommandLine(MongodConfig mongod)
        {
            //mongo.exe 客户端程序
            var dosCommand = @"mongod --dbpath @dbpath --port @port ";
            //数据库路径
            dosCommand = dosCommand.Replace("@dbpath", "\"" + mongod.DbPath + "\"");
            //端口号
            dosCommand = dosCommand.Replace("@port", mongod.Port.ToString());
            //日志文件
            if (mongod.LogPath != string.Empty)
            {
                dosCommand += " --logpath \"" + mongod.LogPath + "\"";
                switch (mongod.LogLv)
                {
                    case MongologLevel.Quiet:
                        dosCommand += " --quiet ";
                        break;
                    case MongologLevel.V:
                        dosCommand += " --verbose ";
                        break;
                    case MongologLevel.Vv:
                        dosCommand += " --vv ";
                        break;
                    case MongologLevel.Vvv:
                        dosCommand += " --vvv ";
                        break;
                    case MongologLevel.Vvvv:
                        dosCommand += " --vvvv ";
                        break;
                    case MongologLevel.Vvvvv:
                        dosCommand += " --vvvvv ";
                        break;
                }
                //日志是否为添加模式
                if (mongod.Islogappend)
                {
                    dosCommand += " --logappend ";
                }
            }
            //是否为Master
            if (mongod.Master)
            {
                dosCommand += " --master";
            }
            if (mongod.Slave)
            {
                dosCommand += " --slave";
                if (mongod.Source != string.Empty)
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
        ///     执行Dos下的命令
        /// </summary>
        /// <remarks>Only For Windows Platform</remarks>
        /// <param name="dosCommand"></param>
        /// <param name="sb"></param>
        public static void RunDosCommand(string dosCommand, StringBuilder sb)
        {
            StrOutPut = string.Empty;
            StrErrorPut = string.Empty;
            var myProcess = new Process();
            myProcess.StartInfo.FileName = "cmd";
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.RedirectStandardInput = true;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardError = true;
            myProcess.ErrorDataReceived += ErrorDataHandler;
            myProcess.OutputDataReceived += OutputDataHandler;
            myProcess.Start();
            myProcess.BeginErrorReadLine();
            myProcess.BeginOutputReadLine();
            //标准输出流
            var stringWriter = myProcess.StandardInput;
            stringWriter.AutoFlush = true;
            //DOS控制平台上的命令
            //如果MongoUtility和本程序不在一个驱动器的话，需要先切换驱动器
            stringWriter.Write(MongoBinPath.Substring(0, 1) + ":" + Environment.NewLine);
            stringWriter.Write("cd " + MongoBinPath + Environment.NewLine);
            //DOS控制平台上的命令
            stringWriter.Write(dosCommand + Environment.NewLine);
            stringWriter.Write("exit" + Environment.NewLine);
            myProcess.WaitForExit();
            sb.AppendLine(StrOutPut);
            sb.AppendLine(StrErrorPut);
            if (myProcess.HasExited == false)
            {
                myProcess.Kill();
            }
            stringWriter.Close();
            myProcess.Close();
        }

        private static void ErrorDataHandler(object sendingProcess, DataReceivedEventArgs errLine)
        {
            if (errLine.Data == null)
                return;
            StrErrorPut = StrErrorPut + errLine.Data + Environment.NewLine;
        }

        private static void OutputDataHandler(object sendingProcess, DataReceivedEventArgs outputLine)
        {
            if (outputLine.Data == null)
                return;
            StrOutPut = StrOutPut + outputLine.Data + Environment.NewLine;
        }
    }
}