using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Server
{
    public static class ClientUtlity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="NickName"></param>
        public static String CreateGame(String NickName) {
            String requestInfo = Card.Server.Communication.RequestType.新建游戏.GetHashCode().ToString("D3") + "|" + NickName;
            return Card.Server.Communication.Request(requestInfo);
        }
    }
}
