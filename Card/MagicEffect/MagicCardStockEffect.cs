using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card
{
    public class MagicCardStockEffect : EffectDefine
    {
         /// <summary>
        /// 抽牌魔法
        /// </summary>
        /// <param name="role"></param>
        /// <param name="magic"></param>
        public static void ModifyCardStock(RoleInfo role, EffectDefine magic)
        {
            //抽牌
            var cards = role.cardStock.DrawCard(magic.StandardEffectPoint);
            //加入手牌
            role.handCards.AddRange(cards);
        }
    }
}
