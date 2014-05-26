using Card.Server;
using System;
using System.Collections.Generic;

namespace Card.Client
{
    public static class RunAction
    {
        #region"开始动作"
        /// <summary>
        /// 开始一个动作
        /// </summary>
        /// <param name="game"></param>
        /// <param name="CardSn"></param>
        /// <returns></returns>
        public static List<String> StartAction(GameManager game, String CardSn)
        {
            Card.CardBasicInfo card = Card.CardUtility.GetCardInfoBySN(CardSn);
            List<String> ActionCodeLst = new List<string>();
            switch (CardSn.Substring(0, 1))
            {
                case "A":
                    ActionCodeLst.Add(UseAbility(CardSn));
                    //初始化 Buff效果等等
                    Card.AbilityCard ablity = (Card.AbilityCard)CardUtility.GetCardInfoBySN(CardSn);
                    ablity.CardAbility.Init();
                    var ResultArg = game.UseAbility(ablity);
                    ActionCodeLst.AddRange(ResultArg);
                    break;
                case "M":
                    int MinionPos = game.MySelf.RoleInfo.BattleField.MinionCount + 1;
                    ActionCodeLst.Add(UseMinion(CardSn, MinionPos));
                    var minion = (Card.MinionCard)card;
                    //初始化
                    minion.Init();
                    game.MySelf.RoleInfo.BattleField.PutToBattle(MinionPos, minion);
                    game.MySelf.RoleInfo.BattleField.ResetBuff();
                    break;
                case "W":
                    ActionCodeLst.Add(UseWeapon(CardSn));
                    game.MySelf.RoleInfo.Weapon = (Card.WeaponCard)card;
                    break;
                default:
                    break;
            }
            return ActionCodeLst;
        }
        /// <summary>
        /// 使用武器
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <returns></returns>
        public static String UseWeapon(String CardSn)
        {
            String actionCode = String.Empty;
            actionCode = ActionCode.strWeapon + CardUtility.strSplitMark + CardSn;
            return actionCode;
        }
        /// <summary>
        /// 使用随从
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static String UseMinion(String CardSn, int Position)
        {
            String actionCode = String.Empty;
            actionCode = ActionCode.strMinion + CardUtility.strSplitMark + CardSn + CardUtility.strSplitMark + Position.ToString("D1");
            return actionCode;
        }
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <returns></returns>
        public static String UseAbility(String CardSn)
        {
            String actionCode = String.Empty;
            actionCode = ActionCode.strAbility + CardUtility.strSplitMark + CardSn;
            return actionCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="MyPos"></param>
        /// <param name="YourPos"></param>
        /// <returns></returns>
        public static List<String> Fight(GameManager game, int MyPos,int YourPos)
        {
            String actionCode = String.Empty;
            //FIGHT#1#2
            actionCode = ActionCode.strFight + CardUtility.strSplitMark + MyPos + CardUtility.strSplitMark + YourPos;
            List<String> ActionCodeLst = new List<string>();
            ActionCodeLst.Add(actionCode);
            ActionCodeLst.AddRange(game.Fight(MyPos,YourPos,false));
            return ActionCodeLst;
        }
        #endregion
    }
}
