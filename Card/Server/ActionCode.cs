using Card.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Server
{
    public static class ActionCode
    {
        /// <summary>
        /// 动作类型
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// 使用武器
            /// </summary>
            UseWeapon,
            /// <summary>
            /// 使用随从
            /// </summary>
            UseMinion,
            /// <summary>
            /// 使用魔法
            /// </summary>
            UseAbility,
            /// <summary>
            /// 结束TURN
            /// </summary>
            EndTurn,
            /// <summary>
            /// 变形（效果）
            /// </summary>
            Transform,
            /// <summary>
            /// 未知
            /// </summary>
            UnKnown
        }
        #region"常数"
        /// <summary>
        /// 变形（效果）
        /// </summary>
        public const string strTransform = "TRANSFORM";
        /// <summary>
        /// 攻击
        /// </summary>
        public const string strAttack = "ATTACK";
        /// <summary>
        /// 武器
        /// </summary>
        public const string strWeapon = "WEAPON";
        /// <summary>
        /// 随从
        /// </summary>
        public const string strMinion = "MINION";
        /// <summary>
        /// 法术
        /// </summary>
        public const string strAbility = "ABILITY";
        /// <summary>
        /// ENDTURN
        /// </summary>
        public const String strEndTurn = "ENDTURN";

        #endregion
        public static List<String> StartAction(GameManager game, String CardSn)
        {
            Card.CardBasicInfo card = Card.CardUtility.GetCardInfoBySN(CardSn);
            List<String> ActionCodeLst = new List<string>();
            switch (CardSn.Substring(0, 1))
            {
                case "A":
                    ActionCodeLst.Add(ActionCode.UseAbility(CardSn));
                    var ResultArg = game.UseAbility(CardSn);
                    ActionCodeLst.AddRange(ResultArg);
                    break;
                case "M":
                    int MinionPos = game.MySelf.RoleInfo.BattleField.MinionCount + 1;
                    ActionCodeLst.Add(ActionCode.UseMinion(CardSn, MinionPos));
                    game.MySelf.RoleInfo.BattleField.PutToBattle(MinionPos, (Card.MinionCard)card);
                    break;
                case "W":
                    ActionCodeLst.Add(ActionCode.UseWeapon(CardSn));
                    game.MySelf.RoleInfo.Weapon = (Card.WeaponCard)card;
                    break;
                default:
                    break;
            }
            return ActionCodeLst;
        }
        /// <summary>
        /// 处理对方的动作
        /// </summary>
        /// <param name="item"></param>
        /// <param name="game"></param>
        public static void ProcessAction(string item,GameManager game)
        {
            var actionArray = item.Split("#".ToCharArray());
            switch (Card.Server.ActionCode.GetActionType(item))
            {
                case ActionCode.ActionType.UseWeapon:
                    game.AgainstInfo.Weapon = (Card.WeaponCard)Card.CardUtility.GetCardInfoBySN(actionArray[1]);
                    break;
                case ActionCode.ActionType.UseMinion:
                    int Pos = int.Parse(actionArray[2]);
                    String CardSn = actionArray[1];
                    game.AgainstInfo.BattleField.PutToBattle(Pos, CardSn);
                    break;
                case ActionCode.ActionType.UseAbility:
                    break;
                case ActionCode.ActionType.Transform:
                    game.MySelf.RoleInfo.BattleField.BattleMinions[0] = (Card.MinionCard)Card.CardUtility.GetCardInfoBySN(actionArray[3]);
                    break;
                case ActionCode.ActionType.UnKnown:
                    break;
            }
        }
 
        /// <summary>
        /// 
        /// </summary>
        public static ActionType GetActionType(String ActionWord)
        {
            ActionType t = ActionType.UnKnown;
            //动作
            if (ActionWord.StartsWith(strWeapon + CardUtility.strSplitMark)) t = ActionType.UseWeapon;
            if (ActionWord.StartsWith(strMinion + CardUtility.strSplitMark)) t = ActionType.UseMinion;
            if (ActionWord.StartsWith(strAbility + CardUtility.strSplitMark)) t = ActionType.UseAbility;
            if (ActionWord.Equals(strEndTurn)) t = ActionType.EndTurn;
            //效果
            if (ActionWord.StartsWith(strTransform + CardUtility.strSplitMark)) t = ActionType.Transform;
            return t;
        }
        /// <summary>
        /// 使用武器
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <returns></returns>
        public static String UseWeapon(String CardSn)
        {
            String ActionCode = String.Empty;
            ActionCode = strWeapon + CardUtility.strSplitMark + CardSn;
            return ActionCode;
        }
        /// <summary>
        /// 使用随从
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static String UseMinion(String CardSn, int Position)
        {
            String ActionCode = String.Empty;
            ActionCode = strMinion + CardUtility.strSplitMark + CardSn + CardUtility.strSplitMark + Position.ToString("D1");
            return ActionCode;
        }
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <returns></returns>
        public static String UseAbility(String CardSn)
        {
            String ActionCode = String.Empty;
            ActionCode = strAbility + CardUtility.strSplitMark + CardSn;
            return ActionCode;
        }
    }
}
