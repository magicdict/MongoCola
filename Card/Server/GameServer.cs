using System;
using System.Collections.Generic;

namespace Card.Server
{
    public static class GameServer
    {
        /// <summary>
        /// GameId
        /// </summary>
        public static int GameId = 0;
        /// <summary>
        /// 维护游戏
        /// </summary>
        public static Dictionary<int, GameStatusAtServer> GameContent = new Dictionary<int, GameStatusAtServer>();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int CreateNewGame() {
            GameId++;
            GameContent.Add(GameId, new GameStatusAtServer(GameId));
            return GameId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="GameId"></param>
        /// <param name="card"></param>
        public static void SetCardStack(int GameId, Boolean IsHost,Stack<String> card)
        {
            //IsHost == false 的时候，初始化已经完成，
            //网络版的时候，要向两个客户端发送开始游戏的下一步指令            
            GameContent[GameId].SetCardStack(IsHost, card);
        }
        /// <summary>
        /// 抽牌
        /// </summary>
        /// <param name="GameId"></param>
        /// <param name="IsFirst"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static List<string> DrawCard(int GameId,bool IsFirst, int Count)
        {
            return GameContent[GameId].DrawCard(IsFirst, Count);
        }
    }
}
