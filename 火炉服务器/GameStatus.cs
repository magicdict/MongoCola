using Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 火炉服务器
{
    /// <summary>
    /// 游戏状态
    /// </summary>
    ///<remarks>
    ///最低要求：双方牌堆情况
    ///（棋牌类游戏难以作弊，无需大量验证）
    /// </remarks>
    public class GameStatus
    {
        /// <summary>
        /// 先手牌堆
        /// </summary>
        Card.CardStock FirstCardStock = new CardStock();
        /// <summary>
        /// 后手牌堆
        /// </summary>
        Card.CardStock SecondCardStock = new CardStock();
    }
}
