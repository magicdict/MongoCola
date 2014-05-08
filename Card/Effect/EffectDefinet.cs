using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card.Effect
{
    public class EffectDefine
    {
        /// <summary>
        /// 魔法效果
        /// </summary>
        public enum MagicEffectEnum
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
        /// 法术类型
        /// </summary>
        public MagicEffectEnum MagicEffectType;
        /// <summary>
        /// 法术对象选择模式
        /// </summary>
        public CardUtility.TargetSelectModeEnum EffictTargetSelectMode;
        /// <summary>
        /// 法术对象选择角色
        /// </summary>
        public CardUtility.TargetSelectRoleEnum EffectTargetSelectRole;
        /// <summary>
        /// 法术对象选择方向
        /// </summary>
        public CardUtility.TargetSelectDirectEnum EffectTargetSelectDirect;
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
}
