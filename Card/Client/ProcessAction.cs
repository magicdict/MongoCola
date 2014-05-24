using Card.Server;
using System;

namespace Card.Client
{
    public static class ProcessAction
    {
        #region"处理对方的动作"
        /// <summary>
        /// 处理对方的动作
        /// </summary>
        /// <param name="item"></param>
        /// <param name="game"></param>
        public static void Process(string item, GameManager game)
        {
            var actionArray = item.Split("#".ToCharArray());
            switch (Card.Server.ActionCode.GetActionType(item))
            {
                case ActionCode.ActionType.UseWeapon:
                    game.AgainstInfo.Weapon = (Card.WeaponCard)Card.CardUtility.GetCardInfoBySN(actionArray[1]);
                    break;
                case ActionCode.ActionType.UseMinion:
                    int Pos = int.Parse(actionArray[2]);
                    var minion = (Card.MinionCard)Card.CardUtility.GetCardInfoBySN(actionArray[1]);
                    minion.Init();
                    game.AgainstInfo.BattleField.PutToBattle(Pos, minion);
                    game.AgainstInfo.BattleField.ResetBuff();
                    break;
                case ActionCode.ActionType.UseAbility:
                    break;
                case ActionCode.ActionType.Transform:
                    game.MySelf.RoleInfo.BattleField.BattleMinions[0] = (Card.MinionCard)Card.CardUtility.GetCardInfoBySN(actionArray[3]);
                    break;
                case ActionCode.ActionType.Attack:
                    //ATTACK#ME#POS#AP
                    //Me代表对方 YOU代表自己，必须反过来
                    var actField = item.Split(CardUtility.strSplitMark.ToCharArray());
                    int AttackPoint = int.Parse(actField[3]);
                    if (actField[1] == CardUtility.strYou)
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
                    break;
                case ActionCode.ActionType.UnKnown:
                    break;
            }
        }
        #endregion

    }
}
