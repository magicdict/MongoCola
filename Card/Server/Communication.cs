using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Card.Server
{
    /// <summary>
    /// 服务器 - 客户端 通信协议
    /// </summary>
    public static class Communication
    {
        /// <summary>
        /// 开启服务器
        /// </summary>
        public static void StartServer()
        {
            TcpListener server = null;
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();
                while (true)
                {
                    //对于每个请求创建一个线程，线程的参数是TcpClient对象
                    TcpClient client = server.AcceptTcpClient();
                    ParameterizedThreadStart ParStart = ProcessRequest;
                    var t = new Thread(ParStart);
                    t.Start(client);
                }
            }
            catch (SocketException)
            {

            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
                server = null;
            }
        }
        /// <summary>
        ///     进行一次请求处理操作
        /// </summary>
        /// <param name="clientObj"></param>
        private static void ProcessRequest(object clientObj)
        {
            var client = clientObj as TcpClient;
            // Buffer for reading data
            var bytes = new Byte[512];
            NetworkStream stream = client.GetStream();
            ///实际长度
            int ActualSize;
            ///
            String Request = String.Empty;
            //512Byte单位进行处理
            while ((client.Available != 0) && (ActualSize = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                Request = Encoding.ASCII.GetString(bytes, 0, ActualSize);
            }
            bytes = Encoding.ASCII.GetBytes("Response Of [" + Request + "]");
            stream.Write(bytes, 0, bytes.Length);
            client.Close();
        }
        public static String Request(String Request) {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 13000);
            var stream = client.GetStream();
            var bytes = new Byte[512];
            bytes = Encoding.ASCII.GetBytes(Request);
            stream.Write(bytes, 0, bytes.Length);
            String Response = String.Empty;
            using (StreamReader reader = new StreamReader(stream))
            {
                while (reader.Peek() != -1)
                {
                    Response = reader.ReadLine();
                }
            }
            client.Close();
            return Response;
        }
        /// <summary>
        /// 作为消息的前3位传输
        /// </summary>
        public enum MessageHeader
        {
            /// <summary>
            /// 正常
            /// </summary>
            正常 = 100,
            /// <summary>
            /// 异常
            /// </summary>
            异常 = 999,
            /// <summary>
            /// 使用法术
            /// </summary>
            使用法术 = 101,
            /// <summary>
            /// 英雄使用技能
            /// </summary>
            英雄使用技能 = 102,
            /// <summary>
            /// 随从攻击
            /// </summary>
            随从攻击 = 103,
            /// <summary>
            /// 随从出场
            /// </summary>
            随从出场 = 104
        }
    }
}
