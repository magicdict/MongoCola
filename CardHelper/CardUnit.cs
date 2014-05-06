using System;
using System.Windows.Forms;
using System.Drawing;
using MongoDB.Driver;
namespace CardHelper
{
    public partial class CardUnit : Form
    {
        public CardUnit()
        {
            InitializeComponent();
        }
        private static MongoServer innerServer;
        private static MongoDatabase innerDatabase;
        private static MongoCollection innerCollection;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init();
            innerServer = MongoServer.Create(@"mongodb://localhost:28030");
            innerServer.Connect();
            innerDatabase = innerServer.GetDatabase("HeartStone");
            innerCollection = innerDatabase.GetCollection("Card");

        }
        /// <summary>
        /// 新建卡牌:奥术飞弹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            Card.MagicCard 奥术飞弹 = new Card.MagicCard();
            奥术飞弹.SN = "T000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "造成3点伤害，随机分配给敌方角色。";
            奥术飞弹.Rare = Card.CardBasicInfo.稀有程度.绿色;
            //使用成本
            奥术飞弹.ActualCostPoint = 1;
            奥术飞弹.StandardCostPoint = 1;
            //3回1点攻击
            奥术飞弹.StandardAttackPoint = 1;
            奥术飞弹.ActualAttackPoint = 1;
            奥术飞弹.AttackCount = 3;
            奥术飞弹.AttackMode = Card.MagicCard.AttackModeEnum.随机;

            innerCollection.Insert<Card.MagicCard>(奥术飞弹);

        }
        /// <summary>
        /// 新建卡牌:狼骑兵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate狼骑兵_Click(object sender, EventArgs e)
        {
            //狼骑兵
            Card.FollowerCard 狼骑兵 = new Card.FollowerCard();
            狼骑兵.SN = "T000002";
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

            innerCollection.Insert<Card.FollowerCard>(狼骑兵);

        }
        /// <summary>
        /// 新建卡牌:角斗士的长弓
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate角斗士的长弓_Click(object sender, EventArgs e)
        {
            //角斗士的长弓
            Card.WeaponCard 角斗士的长弓 = new Card.WeaponCard();
            角斗士的长弓.SN = "T000003";
            角斗士的长弓.Name = "角斗士的长弓";
            角斗士的长弓.Description = "你的英雄在攻击时具有免疫。";
            角斗士的长弓.Rare = Card.CardBasicInfo.稀有程度.紫色;
            角斗士的长弓.StandardAttackPoint = 5;
            角斗士的长弓.StandardCostPoint = 7;
            角斗士的长弓.StandardHealthPoint = 2;

            innerCollection.Insert<Card.WeaponCard>(角斗士的长弓);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate鱼人猎潮者_Click(object sender, EventArgs e)
        {
            //鱼人猎潮者
            Card.FollowerCard 鱼人猎潮者 = new Card.FollowerCard();
            鱼人猎潮者.SN = "T000004";
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
            鱼人猎潮者.CardSpecial = Card.FollowerCard.SpecialEnum.FightMessage;

            innerCollection.Insert<Card.FollowerCard>(鱼人猎潮者);
        }
        /// <summary>
        /// 鲜血小鬼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate鲜血小鬼_Click(object sender, EventArgs e)
        {
            //鱼人猎潮者
            Card.FollowerCard 鲜血小鬼 = new Card.FollowerCard();
            鲜血小鬼.SN = "T000004";
            鲜血小鬼.Name = "鱼人猎潮者";
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
            鲜血小鬼.Can潜行 = true;
            鲜血小鬼.Is潜行Status = true;
            //战吼
            鲜血小鬼.CardSpecial = Card.FollowerCard.SpecialEnum.FightMessage;
            innerCollection.Insert<Card.FollowerCard>(鲜血小鬼);
        }
    }
}
