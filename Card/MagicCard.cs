using System;

namespace Card
{
    /// <summary>
    /// 魔法卡牌
    /// </summary>
    public class MagicCard : CardBasicInfo
    {
        /// <summary>
        /// 魔法效果
        /// </summary>
        public enum MagicEffect
        {
            /// <summary>
            /// 攻击类
            /// </summary>
            Attack,
            /// <summary>
            /// 治疗回复
            /// </summary>
            Recover,
            /// <summary>
            /// 召唤
            /// </summary>
            Summon,
            /// <summary>
            /// 抽牌
            /// </summary>
            DrawCard,
            /// <summary>
            /// 变形
            /// 变羊，变青蛙
            /// </summary>
            Transfer,
            /// <summary>
            /// 获得水晶
            /// </summary>
            GetCyastal,
            /// <summary>
            /// 奥秘
            /// </summary>
            奥秘
        }

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
        public MagicDefine FirstMagicDefine = new MagicDefine();
        /// <summary>
        /// 第二定义
        /// </summary>
        public MagicDefine SecondMagicDefine = new MagicDefine();
        /// <summary>
        /// 第一定义 和 第二定义 的连接方式
        /// </summary>
        public EffectJoinType JoinType = EffectJoinType.None;
        /// <summary>
        /// 一个完整的（魔法）效果定义
        /// </summary>
        public struct MagicDefine
        {
            /// <summary>
            /// 法术类型
            /// </summary>
            public MagicEffect MagicType;
            /// <summary>
            /// 法术对象选择模式
            /// </summary>
            public CardUtility.TargetSelectModeEnum MagicTargetSelectMode;
            /// 攻击的时候：99表示消灭一个单位
            /// 治疗的时候：99表示完全回复一个单位
            /// 抽牌的时候：表示抽牌的数量
            /// <summary>
            /// 效果点数(标准)
            /// </summary>
            public int StandardEffectPoint;
            /// <summary>
            /// 效果点数(实际)
            /// </summary>
            public int ActualEffectPoint;
            /// <summary>
            /// 效果回数
            /// </summary>
            public int EffectCount;
        }
        /// <summary>
        /// 施法
        /// </summary>
        /// <param name="enviroment">整个战场环境</param>
        /// <param name="IsFirst">是先手玩家还是后手玩家</param>
        public static void Run(BattleEnviroment enviroment, Boolean IsFirst)
        {
            //攻击类魔法，如果是先手玩家，则对于环境中的 SecondPlayer 进行攻击，反之亦然

        }
    }
}
