using System;
using System.Collections.Generic;

namespace Card.Effect
{
    public class EffectDefine
    {
        /// <summary>
        /// 描述
        /// </summary>
        public String Description = String.Empty;
        /// <summary>
        /// 魔法效果
        /// </summary>
        public enum AbilityEffectEnum
        {
            /// <summary>
            /// 攻击类
            /// </summary>
            攻击,
            /// <summary>
            /// 治疗回复
            /// </summary>
            回复,
            /// <summary>
            /// 召唤
            /// </summary>
            召唤,
            /// <summary>
            /// 降低成本
            /// </summary>
            增益,
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
            奥秘,
            /// <summary>
            /// 
            /// </summary>
            未知
        }
        /// <summary>
        /// 法术类型
        /// </summary>
        public AbilityEffectEnum AbilityEffectType;
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean IsNeedSelectTarget()
        {
            return EffictTargetSelectMode == CardUtility.TargetSelectModeEnum.指定;
        }
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

        /// <summary>
        /// 实施效果
        /// </summary>
        /// <param name="singleEffect">效果</param>
        /// <param name="Field"></param>
        /// <param name="Pos">指定对象</param>
        /// <returns></returns>
        public static List<String> RunSingleEffect(EffectDefine singleEffect, Card.Client.GameManager game, Card.CardUtility.TargetPosition Pos, int Seed)
        {
            List<String> Result = new List<string>();
            //切记，这里的EffectCount都是1
            switch (singleEffect.AbilityEffectType)
            {
                case AbilityEffectEnum.攻击:
                    Result.AddRange(AttackEffect.RunEffect(singleEffect, game, Pos, Seed));
                    break;
                case AbilityEffectEnum.回复:
                    break;
                case AbilityEffectEnum.召唤:
                    break;
                case AbilityEffectEnum.增益:
                    break;
                case AbilityEffectEnum.卡牌:
                    break;
                case AbilityEffectEnum.变形:
                    Result.AddRange(TransformEffect.RunEffect(singleEffect, game, Pos));
                    break;
                case AbilityEffectEnum.法力水晶:
                    Result.AddRange(CrystalEffect.RunEffect(singleEffect, game));
                    break;
                case AbilityEffectEnum.奥秘:
                    break;
                default:
                    break;
            }
            return Result;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            ActualEffectPoint = StandardEffectPoint;
        }
    }
}
