using Card;
using System;
using System.Collections.Generic;

namespace 炉边传说
{

    ///原本应该是服务器方法，但是为了开始测试，暂时作为客户端方法
    ///这样的话，就可以暂时不用考虑网络通讯了

    /// <summary>
    /// 游戏状态
    /// </summary>
    ///<remarks>
    /// 最低要求：双方牌堆情况
    /// （棋牌类游戏难以作弊，无需大量验证）
    /// </remarks>
    public static class GameStatus
    {
        /// <summary>
        /// 先手牌堆
        /// </summary>
        public static Card.CardStock FirstCardStock = new CardStock();
        /// <summary>
        /// 后手牌堆
        /// </summary>
        public static Card.CardStock SecondCardStock = new CardStock();
        /// <summary>
        /// 抽牌
        /// </summary>
        /// <param name="IsFirst"></param>
        /// <param name="Count"></param>
        /// <returns></returns>
        public static List<String> DrawCard(Boolean IsFirst, int Count)
        {
            var targetStock = IsFirst ? FirstCardStock : SecondCardStock;
            return targetStock.DrawCard(Count);
        }
    }
}
