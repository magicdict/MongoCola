using System;

namespace Card
{
    /// <summary>
    /// 魔法卡牌
    /// </summary>
    public class MagicCard : CardBasicInfo
    {
        /// <summary>
        /// 多个效果的连接方式
        /// </summary>
        public enum EffectJoinType
        {
            /// <summary>
            /// 两个效果是并且的关系：副作用
            /// 例如：造成4点伤害，随机弃一张牌。
            /// </summary>
            AND,
            /// <summary>
            /// 两个效果是或者的关系：抉择
            /// 例如：抉择: 对一个随从造成3点伤害；或者造成1点伤害并抽一张牌。
            /// </summary>
            OR,
            /// <summary>
            /// 无需
            /// </summary>
            None
        }
        /// <summary>
        /// 第一定义
        /// </summary>
        public EffectDefine FirstMagicDefine = new EffectDefine();
        /// <summary>
        /// 第二定义
        /// </summary>
        public EffectDefine SecondMagicDefine = new EffectDefine();
        /// <summary>
        /// 第一定义 和 第二定义 的连接方式
        /// </summary>
        public EffectJoinType JoinType = EffectJoinType.None;
        /// <summary>
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
