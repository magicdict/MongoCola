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
            /// 降低成本
            /// </summary>
            CostDown,
            /// <summary>
            /// 抽牌/弃牌
            /// </summary>
            卡牌,
            /// <summary>
            /// 变形
            /// 变羊，变青蛙
            /// </summary>
            变形,
            /// <summary>
            /// 获得水晶
            /// </summary>
            法力水晶,
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
            /// <summary>
            /// 法术对象选择角色
            /// </summary>
            public CardUtility.TargetSelectRoleEnum MagicTargetSelectRole;
            /// <summary>
            /// 法术对象选择方向
            /// </summary>
            public CardUtility.TargetSelectDirectEnum MagicTargetSelectDirect;
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
            /// <summary>
            /// 附加信息
            /// </summary>
            public String AddtionInfo;
        }
        /// <summary>
        /// 使用单个魔法效果
        /// </summary>
        /// <param name="enviroment">整个战场环境</param>
        /// <param name="IsFirst">是先手玩家还是后手玩家</param>
        /// <param name="magic">使用魔法定义</param>
        /// <remarks>服务器端方法，一张卡牌通常会有选择或者副作用，这是客户端处理的东西</remarks>
        public void RunMagic(BattleEnviroment enviroment, Boolean IsFirst,MagicDefine magic)
        {

        }
    }
}
