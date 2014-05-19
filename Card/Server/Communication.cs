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
            RequestType requestType = (RequestType)Enum.Parse(typeof(RequestType), Request.Substring(0, 3));
            String Response = String.Empty;
            switch (requestType)
            {
                case RequestType.新建游戏:
                    //返回GameId
                    Response = GameServer.CreateNewGame(Request.Substring(3)).ToString(GameServer.GameIdFormat);
                    break;
                case RequestType.等待游戏列表:
                    Response = GameServer.GetWaitGameList();
                    break;
                case RequestType.加入游戏:
                    Response = GameServer.JoinGame(int.Parse(Request.Substring(3, 5)), Request.Substring(8)).ToString();
                    break;
                case RequestType.游戏启动状态:
                    Response = GameServer.IsGameStart(int.Parse(Request.Substring(3, 5))).ToString();
                    break;
                case RequestType.先后手状态:
                    Response = GameServer.IsFirst(int.Parse(Request.Substring(3, 5)), Request.Substring(8, 1) == CardUtility.strTrue) ? CardUtility.strTrue : CardUtility.strFalse;
                    break;
                case RequestType.抽牌:
                    var Cardlist = GameServer.DrawCard(int.Parse(Request.Substring(3, 5)), Request.Substring(8, 1) == CardUtility.strTrue,int.Parse(Request.Substring(9, 1) ));
                    Response = String.Join("|",Cardlist.ToArray());
                    break;
                case RequestType.回合结束:
                case RequestType.写入行动:
                    GameServer.WriteAction(int.Parse(Request.Substring(3, 5)), Request.Substring(8));
                    break;
                case RequestType.读取行动:
                    Response = GameServer.ReadAction(int.Parse(Request.Substring(3, 5)));
                    break;
                default:
                    break;
            }
            bytes = Encoding.ASCII.GetBytes(Response);
            stream.Write(bytes, 0, bytes.Length);
            client.Close();
            //logger.Log("Request :[" + requestType.ToString() + "]");
            //logger.Log("Response:[" + Response.ToString() + "]");
        }
        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        public static String Request(String requestInfo)
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 13000);
            var stream = client.GetStream();
            var bytes = new Byte[512];
            bytes = Encoding.ASCII.GetBytes(requestInfo);
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
        /// 消息类型(3位)
        /// </summary>
        public enum RequestType
        {
            /// <summary>
            /// 新建一个游戏
            /// </summary>
            新建游戏,
            /// <summary>
            /// 获得等待中游戏列表
            /// </summary>
            等待游戏列表,
            /// <summary>
            /// 加入一个游戏
            /// </summary>
            加入游戏,
            /// <summary>
            /// 主机询问是否游戏已经启动
            /// </summary>
            游戏启动状态,
            /// <summary>
            /// 确认先后手状态
            /// </summary>
            先后手状态,
            /// <summary>
            /// 认输，退出一个游戏
            /// </summary>
            认输,
            /// <summary>
            /// 抽牌
            /// </summary>
            抽牌,
            /// <summary>
            /// 回合结束
            /// </summary>
            回合结束,
            /// <summary>
            /// 写入行动
            /// </summary>
            写入行动,
            /// <summary>
            /// 读取行动
            /// </summary>
            读取行动
        }
    }
}
