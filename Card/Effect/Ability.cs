using System;
using System.Collections.Generic;

namespace Card.Effect
{
    public class Ability
    {
        /// <summary>
        /// 第一定义
        /// </summary>
        public EffectDefine FirstAbilityDefine = new EffectDefine();
        /// <summary>
        /// 第二定义
        /// </summary>
        public EffectDefine SecondAbilityDefine = new EffectDefine();
        /// <summary>
        /// 第一定义 和 第二定义 的连接方式
        /// </summary>
        public Card.CardUtility.EffectJoinType JoinType = Card.CardUtility.EffectJoinType.None;
        /// <summary>
        /// 是否需要抉择
        /// </summary>
        /// <returns></returns>
        public Boolean IsNeedSelect()
        {
            return JoinType == CardUtility.EffectJoinType.OR;
        }
        /// <summary>
        /// 分解获得效果列表
        /// </summary>
        /// <param name="IsFirstEffect">需要抉择的时候，是否选择第一项目</param>
        /// <returns>最小效果列表</returns>
        public List<Card.Effect.EffectDefine> GetSingleEffectList(Boolean IsFirstEffect)
        {
            //这里都转化为1次效果
            //例如：奥术飞弹的3次工具这里将转为3次效果
            //这样做的原因是，每次奥术飞弹攻击之后，必须要进行一次清算，是否有目标已经被摧毁
            //如果被摧毁的话，无法攻击这个目标了，
            //同时，如果出现亡语的话，亡语可能召唤出新的可攻击目标
            List<Card.Effect.EffectDefine> EffectLst = new List<Card.Effect.EffectDefine>();
            if (IsNeedSelect())
            {
                if (IsFirstEffect)
                {
                    for (int i = 0; i < FirstAbilityDefine.EffectCount; i++)
                    {
                        EffectLst.Add(FirstAbilityDefine);
                    }
                }
                else
                {
                    for (int i = 0; i < SecondAbilityDefine.EffectCount; i++)
                    {
                        EffectLst.Add(SecondAbilityDefine);
                    }
                }
            }
            else
            {
                for (int i = 0; i < FirstAbilityDefine.EffectCount; i++)
                {
                    EffectLst.Add(FirstAbilityDefine);
                }
                if (SecondAbilityDefine.AbilityEffectType !=  EffectDefine.AbilityEffectEnum.未知)
                {
                    for (int i = 0; i < SecondAbilityDefine.EffectCount; i++)
                    {
                        EffectLst.Add(SecondAbilityDefine);
                    }
                }
            }
            return EffectLst;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            if (FirstAbilityDefine != null) FirstAbilityDefine.Init();
            if (SecondAbilityDefine != null) SecondAbilityDefine.Init();            
        }
    }
}
