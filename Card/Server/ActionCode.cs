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
             /// 
             /// </summary>
            TRANSFORM,
            /// <summary>
            /// 未知
            /// </summary>
            UnKnown
        }
        /// <summary>
        /// 
        /// </summary>
        public static ActionType GetActionType(String ActionWord){
            ActionType t = ActionType.UnKnown;
            if (ActionWord.StartsWith("WEAPON" + CardUtility.strSplitMark)) t = ActionType.UseWeapon;
            if (ActionWord.StartsWith("MINION" + CardUtility.strSplitMark)) t = ActionType.UseMinion;
            if (ActionWord.StartsWith("ABILITY" + CardUtility.strSplitMark)) t = ActionType.UseAbility;
            if (ActionWord.Equals(Card.CardUtility.strEndTurn)) t = ActionType.EndTurn;

            if (ActionWord.StartsWith("TRANSFORM" + CardUtility.strSplitMark)) t = ActionType.TRANSFORM;

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
            ActionCode = "WEAPON" + CardUtility.strSplitMark + CardSn;
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
            ActionCode = "MINION" + CardUtility.strSplitMark + CardSn + CardUtility.strSplitMark + Position.ToString("D1");
            return ActionCode;
        }
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="CardSn">卡牌号码</param>
        /// <param name="ResultArg">法术效果</param>
        /// <returns></returns>
        public static String UseAbility(String CardSn, List<String> ResultArg)
        {
            String ActionCode = String.Empty;
            ActionCode = "ABILITY" + CardUtility.strSplitMark + CardSn;
            for (int i = 0; i < ResultArg.Count; i++)
            {
                ActionCode += CardUtility.strSplitMark + ResultArg[i];
            }
            return ActionCode;
        }
    }
}
