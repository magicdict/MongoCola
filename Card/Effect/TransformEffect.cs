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
        public static List<string> RunEffect(EffectDefine singleEffect, Client.GameManager game, CardUtility.TargetPosition Pos)
        {
            List<string> Result = new List<string>();
            var Summon = (Card.MinionCard)CardUtility.GetCardInfoBySN(singleEffect.AddtionInfo);
            //一定要初始化，不然的话，生命值是-1；
            Summon.Init();
            if (Pos.MeOrYou)
            {
                game.MySelf.RoleInfo.BattleField.BattleMinions[Pos.Postion - 1] = Summon;
                //TRANSFORM#ME#1#M9000001
                Result.Add(ActionCode.strTransform + Card.CardUtility.strSplitMark + CardUtility.strMe +
                    Card.CardUtility.strSplitMark + Pos.Postion + Card.CardUtility.strSplitMark + singleEffect.AddtionInfo);
            }
            else
            {
                game.AgainstInfo.BattleField.BattleMinions[Pos.Postion - 1] = Summon;
                Result.Add(ActionCode.strTransform + Card.CardUtility.strSplitMark + CardUtility.strYou +
                    Card.CardUtility.strSplitMark + Pos.Postion + Card.CardUtility.strSplitMark + singleEffect.AddtionInfo);
            }
            return Result;
        }
    }
}
