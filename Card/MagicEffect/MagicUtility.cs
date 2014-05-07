using System;
namespace Card
{
    /// <summary>
    /// 法术大全
    /// </summary>
    public static class MagicUtility{
        /// <summary>
        /// 使用单个魔法效果
        /// </summary>
        /// <param name="enviroment">整个战场环境</param>
        /// <param name="IsFirst">是先手玩家还是后手玩家</param>
        /// <param name="magic">使用魔法定义</param>
        /// <remarks>服务器端方法，一张卡牌通常会有选择或者副作用，这是客户端处理的东西</remarks>
        public static RoleInfo GetSingleTargetRole(BattleEnviroment enviroment, Boolean IsFirst, MagicCard.MagicDefine magic)
        {
            RoleInfo SingleTargetRole = null;
            switch (magic.MagicTargetSelectDirect)
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
