using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace 火炉服务器
{
    public static class HTTPServer
    {
        /// <summary>
        /// 开启服务器
        /// </summary>
        public static void Start()
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
        ///     响应请求
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
            //512Byte单位进行处理
            while ((client.Available != 0) && (ActualSize = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                String data = Encoding.ASCII.GetString(bytes, 0, ActualSize);
            }
            client.Close();
        }
    }
}