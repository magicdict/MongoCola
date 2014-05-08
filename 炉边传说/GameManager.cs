using Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 炉边传说
{
    public static class GameManager
    {        /// <summary>
        /// 一个完整的（魔法）效果定义
        /// </summary>
        /// <summary>
        /// 使用单个魔法效果
        /// </summary>
        /// <param name="enviroment">整个战场环境</param>
        /// <param name="IsFirst">是先手玩家还是后手玩家</param>
        /// <param name="magic">使用魔法定义</param>
        /// <remarks>服务器端方法，一张卡牌通常会有选择或者副作用，这是客户端处理的东西</remarks>
        public static RoleInfo GetSingleTargetRole(BattleEnviroment enviroment, Boolean IsFirst, EffectDefine magic)
        {
            RoleInfo SingleTargetRole = null;
            switch (magic.EffectTargetSelectDirect)
            {
                case CardUtility.TargetSelectDirectEnum.本方:
                    if (IsFirst)
                    {
                        SingleTargetRole = enviroment.FirstPlayer;
                    }
                    else
                    {
                        SingleTargetRole = enviroment.SecondPlayer;
                    }
                    break;
                case CardUtility.TargetSelectDirectEnum.对方:
                    if (IsFirst)
                    {
                        SingleTargetRole = enviroment.SecondPlayer;
                    }
                    else
                    {
                        SingleTargetRole = enviroment.FirstPlayer;
                    }
                    break;
                case CardUtility.TargetSelectDirectEnum.无限制:
                    break;
                default:
                    break;
            }
            return SingleTargetRole;
        }
    }
}
