using System;
using System.Windows.Forms;
using System.Drawing;
namespace UnitTest
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
            一般,
            普通,
            卓越,
            史诗
        }
        /// <summary>
        /// 新建卡牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNewCard_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init();
            Card.CardUtility.RareNameDic = new string[] { "一般", "普通", "卓越", "史诗" };
            Card.CardUtility.GetCardImage = GetImageFromMongoDB;
            
            Card.MagicCard 奥术飞弹 = new Card.MagicCard();
            奥术飞弹.SN = "T000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "随机向敌方发射3枚奥术飞弹";
            奥术飞弹.Rare = (byte)稀有程度.一般;
            System.Diagnostics.Debug.WriteLine(Card.CardUtility.GetRareName(奥术飞弹.Rare));
            //奥术飞弹.Rare = ((byte)稀有程度.史诗) + 1;
            //System.Diagnostics.Debug.WriteLine(Card.CardUtility.GetRareName(奥术飞弹.Rare));
            //使用成本
            奥术飞弹.ActualCostPoint = 1;
            奥术飞弹.StandardCostPoint = 1;
            //3回1点攻击
            奥术飞弹.StandardAttackPoint = 1;
            奥术飞弹.ActualAttackPoint = 1;
            奥术飞弹.AttackCount = 3;

            //狼骑兵
            Card.FollowerCard 狼骑兵 = new Card.FollowerCard();
            狼骑兵.SN = "T000002";
            狼骑兵.Name = "狼骑兵";
            狼骑兵.Description = "冲锋";
            狼骑兵.Rare = (byte)稀有程度.一般;
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
        private Image GetImageFromMongoDB(String ImageKey) {
            return null;
        }
    }
}
