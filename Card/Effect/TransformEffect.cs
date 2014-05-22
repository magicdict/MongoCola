using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Effect
{
    public class TransformEffect : EffectDefine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="singleEffect"></param>
        /// <param name="game"></param>
        /// <returns></returns>
        public static List<string> RunEffect(EffectDefine singleEffect, Player.GameManager game, CardUtility.TargetPosition Pos)
        {
            List<string> Result = new List<string>();
            if (Pos.MyOrAgainst)
            {
                game.MySelf.RoleInfo.BattleField.BattleMinions[Pos.Postion] = (Card.MinionCard)CardUtility.GetCardInfoBySN(singleEffect.AddtionInfo);
            }
            else
            {
                game.AgainstInfo.BattleField.BattleMinions[Pos.Postion] = (Card.MinionCard)CardUtility.GetCardInfoBySN(singleEffect.AddtionInfo);
            }
            return Result;
        }
    }
}
