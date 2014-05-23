
using System;
using System.Collections.Generic;
namespace CardHelper
{
    public static class HelperUtility
    {
        /// <summary>
        /// 生成一套牌
        /// </summary>
        /// <returns></returns>
        public static Stack<String> GetCardDeck()
        {
            Stack<String> CardList = new Stack<string>();
            CardList.Push("M000001");
            CardList.Push("M000002");
            CardList.Push("M000003");
            CardList.Push("W000001");
            CardList.Push("F000001");
            CardList.Push("F000002");
            CardList.Push("F000003");
            CardList.Push("F000004");

            CardList.Push("M000001");
            CardList.Push("M000002");
            CardList.Push("M000003");
            CardList.Push("W000001");
            CardList.Push("F000001");
            CardList.Push("F000002");
            CardList.Push("F000003");
            CardList.Push("F000004");
            return CardList;
        }

        /// <summary>
        /// 初始化奥术飞弹
        /// </summary>
        /// <returns></returns>
        public static Card.AbilityCard Get奥术飞弹()
        {
            Card.AbilityCard 奥术飞弹 = new Card.AbilityCard();
            奥术飞弹.SN = "M000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "造成3点伤害，随机分配给敌方角色。";
            奥术飞弹.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            奥术飞弹.ActualCostPoint = 1;
            奥术飞弹.StandardCostPoint = 1;
            //3回1点攻击
            //奥术飞弹.FirstAbilityDefine.StandardEffectPoint = 1;
            //奥术飞弹.FirstAbilityDefine.ActualEffectPoint = 1;
            //奥术飞弹.FirstAbilityDefine.EffectCount = 3;
            //奥术飞弹.FirstAbilityDefine.EffictTargetSelectMode = Card.CardUtility.TargetSelectModeEnum.随机;
            return 奥术飞弹;
        }
        /// <summary>
        /// 初始化奥术智慧
        /// </summary>
        /// <returns></returns>
        public static Card.AbilityCard Get奥术智慧()
        {
            Card.AbilityCard 奥术智慧 = new Card.AbilityCard();
            奥术智慧.SN = "M000002";
            奥术智慧.Name = "奥术智慧";
            奥术智慧.Description = "随机抽两张牌。";
            奥术智慧.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            奥术智慧.ActualCostPoint = 1;
            奥术智慧.StandardCostPoint = 1;
            奥术智慧.CardAbility.JoinType = Card.CardUtility.EffectJoinType.None;

            //随机抽两张牌
            Card.Effect.CardDeckEffect CardDeckEffect = new Card.Effect.CardDeckEffect();
            CardDeckEffect.StandardEffectPoint = 2;
            CardDeckEffect.EffectCount = 1;
            CardDeckEffect.EffectTargetSelectDirect = Card.CardUtility.TargetSelectDirectEnum.本方;
            奥术智慧.CardAbility.FirstAbilityDefine = CardDeckEffect;
            return 奥术智慧;
        }
        /// <summary>
        /// 初始化变羊术
        /// </summary>
        /// <returns></returns>
        public static Card.AbilityCard Get变羊术()
        {
            Card.AbilityCard 变羊术 = new Card.AbilityCard();
            变羊术.SN = "M000003";
            变羊术.Name = "变羊术";
            变羊术.Description = "指定一个单位变成 1/1 的羊。";
            变羊术.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            变羊术.StandardCostPoint = 4;
            变羊术.CardAbility.JoinType = Card.CardUtility.EffectJoinType.None;
            //变成 1/1 的羊
            //Card.Effect.TransformEffect transformEffect = new Card.Effect.TransformEffect();
            //transformEffect.EffectCount = 1;
            //transformEffect.EffectTargetSelectDirect = Card.CardUtility.TargetSelectDirectEnum.无限制;
            //transformEffect.EffectTargetSelectRole = Card.CardUtility.TargetSelectRoleEnum.随从;
            //transformEffect.AddtionInfo = "F000004";
            //变羊术.CardAbility.FirstAbilityDefine = transformEffect;
            return 变羊术;
        }
        /// <summary>
        /// 初始化角斗士的长弓
        /// </summary>
        /// <returns></returns>
        public static Card.WeaponCard Get角斗士的长弓()
        {
            //角斗士的长弓
            Card.WeaponCard 角斗士的长弓 = new Card.WeaponCard();
            角斗士的长弓.SN = "W000001";
            角斗士的长弓.Name = "角斗士的长弓";
            角斗士的长弓.Description = "你的英雄在攻击时具有免疫。";
            角斗士的长弓.Rare = Card.CardBasicInfo.稀有程度.紫色;
            角斗士的长弓.StandardAttackPoint = 5;
            角斗士的长弓.StandardCostPoint = 7;
            角斗士的长弓.标准耐久度 = 2;

            return 角斗士的长弓;
        }
        /// <summary>
        /// 初始化狼骑兵
        /// </summary>
        /// <returns></returns>
        public static Card.MinionCard Get狼骑兵()
        {
            Card.MinionCard 狼骑兵 = new Card.MinionCard();
            狼骑兵.SN = "F000001";
            狼骑兵.Name = "狼骑兵";
            狼骑兵.Description = "冲锋";
            狼骑兵.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //属性
            狼骑兵.ActualAttackPoint = 1;
            狼骑兵.ActualCostPoint = 3;
            狼骑兵.ActualHealthPoint = 1;
            狼骑兵.Actual冲锋 = true;
            狼骑兵.Actual嘲讽 = false;
            狼骑兵.StandardAttackPoint = 1;
            狼骑兵.StandardCostPoint = 3;
            狼骑兵.StandardHealthPoint = 1;
            狼骑兵.Standard冲锋 = true;
            狼骑兵.Standard嘲讽 = false;
            return 狼骑兵;
        }
        /// <summary>
        /// 初始化鱼人猎潮者
        /// </summary>
        /// <returns></returns>
        public static Card.MinionCard Get鱼人猎潮者()
        {
            //鱼人猎潮者
            Card.MinionCard 鱼人猎潮者 = new Card.MinionCard();
            鱼人猎潮者.SN = "F000002";
            鱼人猎潮者.Name = "鱼人猎潮者";
            鱼人猎潮者.Description = "战吼: 召唤一个1/1的鱼人斥候。";
            鱼人猎潮者.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //属性
            鱼人猎潮者.ActualAttackPoint = 1;
            鱼人猎潮者.ActualCostPoint = 3;
            鱼人猎潮者.ActualHealthPoint = 1;
            鱼人猎潮者.Actual冲锋 = true;
            鱼人猎潮者.Actual嘲讽 = false;
            鱼人猎潮者.StandardAttackPoint = 1;
            鱼人猎潮者.StandardCostPoint = 3;
            鱼人猎潮者.StandardHealthPoint = 1;
            鱼人猎潮者.Standard冲锋 = false;
            鱼人猎潮者.Standard嘲讽 = false;
            //战吼
            鱼人猎潮者.战吼效果 = new  Card.Effect.Ability();

            return 鱼人猎潮者;
        }
        /// <summary>
        /// 初始化鲜血小鬼
        /// </summary>
        /// <returns></returns>
        public static Card.MinionCard Get鲜血小鬼()
        {
            //鲜血小鬼
            Card.MinionCard 鲜血小鬼 = new Card.MinionCard();
            鲜血小鬼.SN = "F000003";
            鲜血小鬼.Name = "鲜血小鬼";
            鲜血小鬼.Description = "战吼: 召唤一个1/1的鱼人斥候。";
            鲜血小鬼.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //属性
            鲜血小鬼.ActualAttackPoint = 1;
            鲜血小鬼.ActualCostPoint = 3;
            鲜血小鬼.ActualHealthPoint = 1;
            鲜血小鬼.Actual冲锋 = true;
            鲜血小鬼.Actual嘲讽 = false;
            鲜血小鬼.StandardAttackPoint = 1;
            鲜血小鬼.StandardCostPoint = 3;
            鲜血小鬼.StandardHealthPoint = 1;
            鲜血小鬼.Standard冲锋 = false;
            鲜血小鬼.Standard嘲讽 = false;
            鲜血小鬼.潜行特性 = true;
            鲜血小鬼.Is潜行Status = true;
            //战吼
            鲜血小鬼.战吼效果 = new Card.Effect.Ability();
            return 鲜血小鬼;
        }
        /// <summary>
        /// 初始化羊
        /// </summary>
        /// <returns></returns>
        public static Card.MinionCard Get羊()
        {
            //羊
            Card.MinionCard 羊 = new Card.MinionCard();
            羊.SN = "F000004";
            羊.Name = "羊";
            羊.Description = "1/1的小绵羊。";
            羊.Rare = Card.CardBasicInfo.稀有程度.白色;
            //属性
            羊.StandardAttackPoint = 1;
            羊.StandardCostPoint = 1;
            羊.StandardHealthPoint = 1;
            return 羊;
        }
    }
}
