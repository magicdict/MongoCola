using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Web;

namespace MagicMongoDBTool.HTTP
{
    public class HTTPServer
    {
        public class LogOutEvent : EventArgs
        {
            public String Info;
            public byte Level;
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Information"></param>
            /// <param name="lv"></param>
            public LogOutEvent(String Information, byte lv)
            {
                Info = Information;
                Level = lv;
            }
        }
        /// <summary>
        /// Log
        /// </summary>
        public event EventHandler<LogOutEvent> LogInfo;

        public void OutputLog(String StrText, byte MessageLv)
        {
            if (LogInfo != null)
            {
                LogInfo(null, new LogOutEvent(StrText, MessageLv));
            }
        }
        /// <summary>
        /// 服务器路径
        /// </summary>
        public static String ServerPath
        {
            set;
            get;
        }
        public void Start()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (true)
                {
                    ///对于每个请求创建一个线程，线程的参数是TcpClient对象
                    TcpClient client = server.AcceptTcpClient();
                    OutputLog("[Init]" + DateTime.Now + "Connected!", 0);
                    ParameterizedThreadStart ParStart = new ParameterizedThreadStart(ProcessFun);
                    Thread t = new Thread(ParStart);
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
        /// 响应请求
        /// </summary>
        /// <param name="clientObj"></param>
        private void ProcessFun(object clientObj)
        {
            TcpClient client = clientObj as TcpClient;
            // Buffer for reading data
            Byte[] bytes = new Byte[512];

            OutputLog("[Init]Waiting for a connection... ", 0);

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();
            int i;
            // Loop to receive all the data sent by the client.
            while ((client.Available != 0) && (i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                String data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                //OutputLog("Received:" + data);

                string[] Rec = data.Split(Environment.NewLine.ToCharArray());
                if (Rec[0].StartsWith("GET"))
                {
                    string[] Request = Rec[0].Split(" ".ToCharArray());
                    String RequestItem = HttpUtility.UrlDecode(Request[1], System.Text.Encoding.UTF8);
                    OutputLog("[RequestItem]Received : " + RequestItem, 0);
                    switch (RequestItem)
                    {
                        case "/":
                            //根节点 

                            break;
                        default:
                            break;
                    }

                    String FileName = ServerPath + RequestItem.Replace("/", "\\");
                    GETFile(stream, FileName);
                }
                else
                {
                    if (Rec[0].StartsWith("POST"))
                    {

                    }
                }
            }

            // Shutdown and end connection
            client.Close();
        }

        private void GETFile(NetworkStream stream, String FileName)
        {
            byte[] msg = null;
            String data = String.Empty;
            if (File.Exists(FileName))
            {
                byte[] bFile = FileOperation.ReadFile(FileName);
                // Process the data sent by the client.
                data = "HTTP/1.1 200 OK" + Environment.NewLine;
                data += "Content-Type: text/html; charset=utf-8" + Environment.NewLine;
                data += "Content-Length: ";
                data += (bFile.Length).ToString();
                data += Environment.NewLine + Environment.NewLine;
                msg = System.Text.Encoding.ASCII.GetBytes(data);
                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                stream.Write(bFile, 0, bFile.Length);
                stream.Flush();
            }
            else
            {
                data = "HTTP/1.1 404 Not Found" + Environment.NewLine;
                msg = System.Text.Encoding.ASCII.GetBytes(data);
                // Send back a response.
                stream.Write(msg, 0, msg.Length);
            }
            OutputLog("[System]Sent HTML OK", 0);
        }
    }
}
