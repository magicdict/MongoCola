using Card.Server;
using System;
using System.Collections.Generic;

namespace Card.Effect
{
    public static class AttackEffect
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="singleEffect"></param>
        /// <param name="game"></param>
        /// <param name="Pos"></param>
        /// <param name="Seed">随机数种子</param>
        /// <returns></returns>
        public static List<string> RunEffect(EffectDefine singleEffect, Client.GameManager game, CardUtility.TargetPosition Pos, int Seed)
        {
            //切记，这里的EffectCount都是1
            List<string> Result = new List<string>();
            int AttackPoint = singleEffect.ActualEffectPoint;
            switch (singleEffect.EffictTargetSelectMode)
            {
                case CardUtility.TargetSelectModeEnum.随机:
                    Random t = new Random(Seed);
                    switch (singleEffect.EffectTargetSelectDirect)
                    {
                        case CardUtility.TargetSelectDirectEnum.本方:
                            switch (singleEffect.EffectTargetSelectRole)
                            {
                                case CardUtility.TargetSelectRoleEnum.随从:
                                    Pos.Postion = t.Next(1, game.MySelf.RoleInfo.BattleField.MinionCount + 1);
                                    Pos.MeOrYou = true;
                                    break;
                                case CardUtility.TargetSelectRoleEnum.所有角色:
                                    Pos.Postion = t.Next(0, game.MySelf.RoleInfo.BattleField.MinionCount + 1);
                                    Pos.MeOrYou = true;
                                    break;
                            }
                            //ATTACK#ME#POS#AP
                            Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                       Pos.Postion.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                            break;
                        case CardUtility.TargetSelectDirectEnum.对方:
                            switch (singleEffect.EffectTargetSelectRole)
                            {
                                case CardUtility.TargetSelectRoleEnum.随从:
                                    Pos.Postion = t.Next(1, game.MySelf.RoleInfo.BattleField.MinionCount + 1);
                                    Pos.MeOrYou = false;
                                    break;
                                case CardUtility.TargetSelectRoleEnum.所有角色:
                                    Pos.Postion = t.Next(0, game.MySelf.RoleInfo.BattleField.MinionCount + 1);
                                    Pos.MeOrYou = false;
                                    break;
                            }
                            //ATTACK#ME#POS#AP
                            Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                       Pos.Postion.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                            break;
                        case CardUtility.TargetSelectDirectEnum.双方:
                            //本方对方
                            int MinionCount;
                            if (t.Next(1, 3) == 1)
                            {
                                Pos.MeOrYou = true;
                                MinionCount = game.MySelf.RoleInfo.BattleField.MinionCount;
                            }
                            else
                            {
                                Pos.MeOrYou = false;
                                MinionCount = game.AgainstInfo.BattleField.MinionCount;
                            }
                            switch (singleEffect.EffectTargetSelectRole)
                            {
                                case CardUtility.TargetSelectRoleEnum.随从:
                                    Pos.Postion = t.Next(1, MinionCount + 1);
                                    break;
                                case CardUtility.TargetSelectRoleEnum.所有角色:
                                    Pos.Postion = t.Next(0, MinionCount + 1);
                                    break;
                            }
                            Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + (Pos.MeOrYou ? CardUtility.strMe : CardUtility.strYou) + CardUtility.strSplitMark +
                                       Pos.Postion.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                            break;
                        default:
                            break;
                    }
                    break;
                case CardUtility.TargetSelectModeEnum.全体:
                    switch (singleEffect.EffectTargetSelectDirect)
                    {
                        case CardUtility.TargetSelectDirectEnum.本方:
                            switch (singleEffect.EffectTargetSelectRole)
                            {
                                case CardUtility.TargetSelectRoleEnum.随从:
                                    for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    break;
                                case CardUtility.TargetSelectRoleEnum.英雄:
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    break;
                                case CardUtility.TargetSelectRoleEnum.所有角色:
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    break;
                            }
                            break;
                        case CardUtility.TargetSelectDirectEnum.对方:
                            switch (singleEffect.EffectTargetSelectRole)
                            {
                                case CardUtility.TargetSelectRoleEnum.随从:
                                    for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    break;
                                case CardUtility.TargetSelectRoleEnum.英雄:
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    break;
                                case CardUtility.TargetSelectRoleEnum.所有角色:
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    break;
                            }
                            break;
                        case CardUtility.TargetSelectDirectEnum.双方:
                            switch (singleEffect.EffectTargetSelectRole)
                            {
                                case CardUtility.TargetSelectRoleEnum.随从:
                                    for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    break;
                                case CardUtility.TargetSelectRoleEnum.英雄:
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    break;
                                case CardUtility.TargetSelectRoleEnum.所有角色:
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                    0.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    for (int i = 0; i < game.MySelf.RoleInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strMe + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    for (int i = 0; i < game.AgainstInfo.BattleField.MinionCount; i++)
                                    {
                                        Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + CardUtility.strYou + CardUtility.strSplitMark +
                                        (i + 1).ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case CardUtility.TargetSelectModeEnum.指定:
                    Result.Add(ActionCode.strAttack + CardUtility.strSplitMark + (Pos.MeOrYou ? CardUtility.strMe : CardUtility.strYou) + CardUtility.strSplitMark +
                    Pos.Postion.ToString("D1") + CardUtility.strSplitMark + AttackPoint);
                    break;
            }
            //处理对象
            //ATTACK#ME#POS#AP
            foreach (var act in Result)
            {
                var actField = act.Split(CardUtility.strSplitMark.ToCharArray());
                if (actField[1] == CardUtility.strMe)
                {
                    if (actField[2] == "0")
                    {
                        game.MySelf.RoleInfo.HealthPoint -= AttackPoint;
                    }
                    else
                    {
                        //位置从1开始，数组从0开始
                        game.MySelf.RoleInfo.BattleField.BattleMinions[int.Parse(actField[2]) - 1].AfterBeAttack(AttackPoint);
                    }
                }
                else
                {
                    if (actField[2] == "0")
                    {
                        game.AgainstInfo.HealthPoint -= AttackPoint;
                    }
                    else
                    {
                        //位置从1开始，数组从0开始
                        game.AgainstInfo.BattleField.BattleMinions[int.Parse(actField[2]) - 1].AfterBeAttack(AttackPoint);
                    }
                }
            }
            return Result;
        }
    }
}
