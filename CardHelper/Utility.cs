
namespace CardHelper
{
    public static class Utility
    {
        /// <summary>
        /// 初始化奥术飞弹
        /// </summary>
        /// <returns></returns>
        public static Card.MagicCard Get奥术飞弹()
        {
            Card.MagicCard 奥术飞弹 = new Card.MagicCard();
            奥术飞弹.SN = "M000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "造成3点伤害，随机分配给敌方角色。";
            奥术飞弹.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            奥术飞弹.ActualCostPoint = 1;
            奥术飞弹.StandardCostPoint = 1;
            //3回1点攻击
            奥术飞弹.FirstMagicDefine.StandardEffectPoint = 1;
            奥术飞弹.FirstMagicDefine.ActualEffectPoint = 1;
            奥术飞弹.FirstMagicDefine.EffectCount = 3;
            奥术飞弹.FirstMagicDefine.EffictTargetSelectMode = Card.CardUtility.TargetSelectModeEnum.随机;
            return 奥术飞弹;
        }
        /// <summary>
        /// 初始化奥术智慧
        /// </summary>
        /// <returns></returns>
        public static Card.MagicCard Get奥术智慧()
        {
            Card.MagicCard 奥术智慧 = new Card.MagicCard();
            奥术智慧.SN = "M000002";
            奥术智慧.Name = "奥术智慧";
            奥术智慧.Description = "随机抽两张牌。";
            奥术智慧.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            奥术智慧.ActualCostPoint = 1;
            奥术智慧.StandardCostPoint = 1;
            奥术智慧.JoinType = Card.MagicCard.EffectJoinType.None;

            //随机抽两张牌
            Card.MagicCardStockEffect cardStockEffect = new Card.MagicCardStockEffect();
            cardStockEffect.StandardEffectPoint = 2;
            cardStockEffect.EffectCount = 1;
            cardStockEffect.EffectTargetSelectDirect = Card.CardUtility.TargetSelectDirectEnum.本方;
            奥术智慧.FirstMagicDefine = cardStockEffect;
            return 奥术智慧;
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
        public static Card.FollowerCard Get狼骑兵()
        {
            Card.FollowerCard 狼骑兵 = new Card.FollowerCard();
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
        public static Card.FollowerCard Get鱼人猎潮者()
        {
            //鱼人猎潮者
            Card.FollowerCard 鱼人猎潮者 = new Card.FollowerCard();
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
            鱼人猎潮者.战吼效果 = new Card.EffectDefine();

            return 鱼人猎潮者;
        }
        /// <summary>
        /// 初始化鲜血小鬼
        /// </summary>
        /// <returns></returns>
        public static Card.FollowerCard Get鲜血小鬼()
        {
            //鲜血小鬼
            Card.FollowerCard 鲜血小鬼 = new Card.FollowerCard();
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
            鲜血小鬼.战吼效果 = new Card.EffectDefine();
            return 鲜血小鬼;
        }

    }
}
