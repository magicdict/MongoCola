using Card.Client;
using System;
using System.Collections.Generic;

namespace Card.Server
{
    public static class ActionCode
    {
        #region"常数"
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
            /// 攻击处理
            /// </summary>
            Attack,
            /// <summary>
            /// 
            /// </summary>
            Fight,
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
        /// 
        /// </summary>
        public const string strFight = "FIGHT";
        /// <summary>
        /// ENDTURN
        /// </summary>
        public const String strEndTurn = "ENDTURN";

        /// <summary>
        /// 获得类型
        /// </summary>
        public static ActionType GetActionType(String ActionWord)
        {
            ActionType t = ActionType.UnKnown;
            //动作
            if (ActionWord.StartsWith(strWeapon + CardUtility.strSplitMark)) t = ActionType.UseWeapon;
            if (ActionWord.StartsWith(strMinion + CardUtility.strSplitMark)) t = ActionType.UseMinion;
            if (ActionWord.StartsWith(strAbility + CardUtility.strSplitMark)) t = ActionType.UseAbility;

            if (ActionWord.StartsWith(strFight + CardUtility.strSplitMark)) t = ActionType.Fight;
            if (ActionWord.Equals(strEndTurn)) t = ActionType.EndTurn;
            //效果
            if (ActionWord.StartsWith(strTransform + CardUtility.strSplitMark)) t = ActionType.Transform;
            if (ActionWord.StartsWith(strAttack + CardUtility.strSplitMark)) t = ActionType.Attack;
            return t;
        }

        #endregion

    }
}
