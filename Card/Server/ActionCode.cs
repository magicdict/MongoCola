using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Server
{
    public static class ActionCode
    {
        public const String ArgumentMark = "#";
        /// <summary>
        /// 使用武器
        /// </summary>
        /// <param name="CardSn"></param>
        /// <returns></returns>
        public static String UseWeapon(String CardSn)
        {
            String ActionCode = String.Empty;
            ActionCode = "WEAPON" + ArgumentMark + CardSn;
            return ActionCode;
        }
        /// <summary>
        /// 使用随从
        /// </summary>
        /// <param name="CardSn"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static String UseMinion(String CardSn, int Position)
        {
            String ActionCode = String.Empty;
            ActionCode = "MINION" + ArgumentMark + CardSn + ArgumentMark + Position.ToString("D1");
            return ActionCode;
        }
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="CardSn"></param>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static String UseAbility(String CardSn, String[] Argument)
        {
            String ActionCode = String.Empty;
            ActionCode = "ABILITY" + ArgumentMark + CardSn;
            for (int i = 0; i < Argument.Length; i++)
            {
                ActionCode += ArgumentMark + Argument[i];
            }
            return ActionCode;
        }
    }
}
