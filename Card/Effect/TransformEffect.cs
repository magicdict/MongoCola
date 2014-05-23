using Card.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Effect
{
    public static class TransformEffect
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
            if (Pos.MeOrYou)
            {
                game.MySelf.RoleInfo.BattleField.BattleMinions[Pos.Postion] = (Card.MinionCard)CardUtility.GetCardInfoBySN(singleEffect.AddtionInfo);
                Result.Add(ActionCode.strTransform + Card.CardUtility.strSplitMark + CardUtility.strMe +
                    Card.CardUtility.strSplitMark + Pos.Postion + Card.CardUtility.strSplitMark + singleEffect.AddtionInfo);
            }
            else
            {
                game.AgainstInfo.BattleField.BattleMinions[Pos.Postion] = (Card.MinionCard)CardUtility.GetCardInfoBySN(singleEffect.AddtionInfo);
                Result.Add(ActionCode.strTransform + Card.CardUtility.strSplitMark + CardUtility.strYou +
                    Card.CardUtility.strSplitMark + Pos.Postion + Card.CardUtility.strSplitMark + singleEffect.AddtionInfo);
            }
            return Result;
        }
    }
}
