using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;
using ResourceLib.Utility;

namespace HTTPServer
{
    public class HTTPServer
    {
        private static string mServerPath;

        /// <summary>
        ///     服务器路径
        /// </summary>
        public static String ServerPath
        {
            set
            {
                GetPage.FilePath = value;
                mServerPath = value;
            }
            get { return mServerPath; }
        }

        /// <summary>
        ///     Log
        /// </summary>
        public event EventHandler<LogOutEvent> LogInfo;

        public void OutputLog(String StrText, byte MessageLv)
        {
            if (LogInfo != null)
            {
                LogInfo(null, new LogOutEvent(StrText, MessageLv));
            }
        }

        public void Start()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                var port = 13000;
                var localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (true)
                {
                    //对于每个请求创建一个线程，线程的参数是TcpClient对象
                    var client = server.AcceptTcpClient();
                    OutputLog("[Init]" + DateTime.Now + "Connected!", 0);
                    ParameterizedThreadStart ParStart = ProcessFun;
                    var t = new Thread(ParStart);
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                OutputLog("SocketException: " + e, 0);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
                server = null;
            }
        }

        /// <summary>
        ///     响应请求
        /// </summary>
        /// <param name="clientObj"></param>
        private void ProcessFun(object clientObj)
        {
            var client = clientObj as TcpClient;
            // Buffer for reading data
            var bytes = new Byte[512];

            OutputLog("[Init]Waiting for a connection... ", 0);

            // Get a stream object for reading and writing
            var stream = client.GetStream();
            int i;
            // Loop to receive all the data sent by the client.
            while ((client.Available != 0) && (i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                var data = Encoding.ASCII.GetString(bytes, 0, i);
                //OutputLog("Received:" + data);

                var OrgRequest = data.Split(Environment.NewLine.ToCharArray());
                if (OrgRequest[0].StartsWith("GET"))
                {
                    var Request = OrgRequest[0].Split(" ".ToCharArray());
                    var RequestItem = HttpUtility.UrlDecode(Request[1], Encoding.UTF8);
                    OutputLog("[RequestItem]Received : " + RequestItem, 0);
                    var RequestPath = RequestItem.Split("?".ToCharArray());
                    switch (RequestPath[0])
                    {
                        case "/":
                            //根节点 
                            GETPage(stream, GetPage.ConnectionList());
                            break;
                        case "/Connection":
                            GETPage(stream, GetPage.Connection(RequestPath[1]));
                            break;
                        case "/ASHX/GetCollection.ashx":
                        case "/ASHX/GetDatabase.ashx":
                        case "/ASHX/GetConnection.ashx":
                            var Arg = RequestPath[1].Split("&".ToCharArray());
                            var strTag = Arg[0].Substring("Tag=".Length);
                            var strData = Arg[1].Substring("Data=".Length);
                            switch (RequestPath[0])
                            {
                                case "/ASHX/GetConnection.ashx":
                                    GETPage(stream, GetPage.GetConnection(strTag + ":" + strData));
                                    break;
                                case "/ASHX/GetDatabase.ashx":
                                    GETPage(stream, GetPage.GetDatabase(strTag + ":" + strData));
                                    break;
                                case "/ASHX/GetCollection.ashx":
                                    GETPage(stream, GetPage.GetCollection(strTag + ":" + strData));
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            GETFile(stream, RequestItem.Replace("/", "\\"));
                            break;
                    }
                }
                else
                {
                    if (OrgRequest[0].StartsWith("POST"))
                    {
                    }
                }
            }

            // Shutdown and end connection
            client.Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="PageContent"></param>
        private void GETPage(NetworkStream stream, String PageContent)
        {
            byte[] msg = null;
            var bFile = Encoding.UTF8.GetBytes(PageContent);
            var data = String.Empty;
            data = "HTTP/1.1 200 OK" + Environment.NewLine;
            data += "Content-Type: text/html; charset=utf-8" + Environment.NewLine;
            data += "Content-Length: ";
            data += (bFile.Length).ToString(CultureInfo.InvariantCulture);
            data += Environment.NewLine + Environment.NewLine;
            msg = Encoding.ASCII.GetBytes(data);
            // Send back a response.
            stream.Write(msg, 0, msg.Length);
            stream.Write(bFile, 0, bFile.Length);
        }

        /// <summary>
        ///     文件读取
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static byte[] ReadFile(String Path)
        {
            var fs = new FileStream(Path, FileMode.Open);
            var bFile = new byte[fs.Length];
            var r = new BinaryReader(fs);
            bFile = r.ReadBytes((int) fs.Length);
            r.Close();
            r = null;
            fs.Close();
            return bFile;
        }

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="FileName"></param>
        private void GETFile(NetworkStream stream, String FileName)
        {
            byte[] msg = null;
            var bFile = new byte[0];
            var data = String.Empty;
            var IsFound = false;
            if (File.Exists(ServerPath + FileName))
            {
                IsFound = true;
                bFile = ReadFile(ServerPath + FileName);
            }
            else
            {
                //资源文件里面获得
                if (FileName.StartsWith("\\MainTreeImage"))
                {
                    //MainTreeImage00.png -- 从MainTreeImage 里面获得
                    var MainTreeImageIndex = Convert.ToInt32(FileName.Substring("\\MainTreeImage".Length, 2));
                    var img = GetSystemIcon.MainTreeImage.Images[MainTreeImageIndex];
                    bFile = GetSystemIcon.imageToByteArray(img, ImageFormat.Png);
                    IsFound = true;
                }
            }
            if (IsFound)
            {
                // Process the data sent by the client.
                data = "HTTP/1.1 200 OK" + Environment.NewLine;
                //if content-type is wrong,FF can;t render it,but IE can
                var filetype = String.Empty;
                switch (new FileInfo(FileName).Extension)
                {
                    case ".css":
                        filetype = "text/css";
                        break;
                    case ".js":
                        filetype = "text/javascript";
                        break;
                    case ".png":
                        filetype = "image";
                        break;
                    default:
                        break;
                }
                data += "Content-Type: @filetype; charset=utf-8".Replace("@filetype", filetype) + Environment.NewLine;
                data += "Content-Length: ";
                data += (bFile.Length).ToString(CultureInfo.InvariantCulture);
                data += Environment.NewLine + Environment.NewLine;
                msg = Encoding.ASCII.GetBytes(data);
                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                stream.Write(bFile, 0, bFile.Length);
                OutputLog("[System]Sent HTML OK", 0);
            }
            else
            {
                data = "HTTP/1.1 404 Not Found" + Environment.NewLine;
                msg = Encoding.ASCII.GetBytes(data);
                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                OutputLog("[System]FileName Not Found:" + FileName, 0);
            }
            stream.Flush();
        }

        public class LogOutEvent : EventArgs
        {
            public String Info;
            public byte Level;

            /// <summary>
            /// </summary>
            /// <param name="Information"></param>
            /// <param name="lv"></param>
            public LogOutEvent(String Information, byte lv)
            {
                Info = Information;
                Level = lv;
            }
        }
    }
}