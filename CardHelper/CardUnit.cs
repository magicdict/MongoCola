using System;
using System.Windows.Forms;
using System.Drawing;
namespace CardHelper
{
    public partial class CardUnit : Form
    {
        public CardUnit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 稀有度
        /// </summary>
        public enum 稀有程度:byte { 
            白色,
            绿色,
            蓝色,
            紫色,
            橙色
        }
        /// <summary>
        /// 新建卡牌:奥术飞弹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init();
            //如果需要的话，可以定制
            //Card.CardUtility.RareNameDic = new string[] { "白色", "绿色", "蓝色", "紫色", "橙色" };
            //获得图片的方法
            //Card.CardUtility.GetCardImage = (x) => { return null; };
            
            Card.MagicCard 奥术飞弹 = new Card.MagicCard();
            奥术飞弹.SN = "T000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "造成3点伤害，随机分配给敌方角色。";
            奥术飞弹.Rare = (byte)稀有程度.绿色;
            System.Diagnostics.Debug.WriteLine(Card.CardUtility.GetRareName(奥术飞弹.Rare));
            //使用成本
            奥术飞弹.ActualCostPoint = 1;
            奥术飞弹.StandardCostPoint = 1;
            //3回1点攻击
            奥术飞弹.StandardAttackPoint = 1;
            奥术飞弹.ActualAttackPoint = 1;
            奥术飞弹.AttackCount = 3;
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
            狼骑兵.Rare = (byte)稀有程度.绿色;
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
            角斗士的长弓.Rare = (byte)稀有程度.紫色;
            角斗士的长弓.StandardAttackPoint = 5;
            角斗士的长弓.StandardCostPoint = 7;
            角斗士的长弓.StandardHealthPoint = 2;
        }
    }
}
