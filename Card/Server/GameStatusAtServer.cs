using Card;
using System;
using System.Collections.Generic;

namespace Card.Server
{

    ///原本应该是服务器方法，但是为了开始测试，暂时作为客户端方法
    ///这样的话，就可以暂时不用考虑网络通讯了
    /// <summary>
    /// 游戏状态(如果考虑到同时有多个游戏，必须为非静态)
    /// </summary>
    ///<remarks>
    /// 最低要求：双方牌堆情况
    /// （棋牌类游戏难以作弊，无需大量验证）
    /// </remarks>
    public class GameStatusAtServer
    {
        /// <summary>
        /// 
        /// </summary>
        public int GameId;
        /// <summary>
        /// 先手牌堆
        /// </summary>
        private Card.CardDeck FirstCardDeck = new CardDeck();
        /// <summary>
        /// 后手牌堆
        /// </summary>
        private Card.CardDeck SecondCardDeck = new CardDeck();
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="FirstCardStack"></param>
        /// <param name="SecondCardStack"></param>
        public void Init(Stack<String> FirstCardStack, Stack<String> SecondCardStack)
        {
            //1.洗牌处理
            FirstCardDeck.Init(FirstCardStack);
            SecondCardDeck.Init(SecondCardStack);
        }
        /// <summary>
        /// 抽牌
        /// </summary>
        /// <param name="IsFirst"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public List<String> DrawCard(Boolean IsFirst, int Count)
        {
            var targetStock = IsFirst ? FirstCardDeck : SecondCardDeck;
            return targetStock.DrawCard(Count);
        }
    }
}
