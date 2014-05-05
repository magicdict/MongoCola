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
        public enum 稀有程度:byte { 
            一般,
            普通,
            卓越,
            史诗
        }
        private void btnCreateNewCard_Click(object sender, EventArgs e)
        {
            Card.CardUtility.Init();
            Card.CardUtility.RareNameDic = new string[] { "一般", "普通", "卓越", "史诗" };
            Card.CardUtility.GetCardImage = GetImageAA;
            Card.MagicCard 奥术飞弹 = new Card.MagicCard();
            奥术飞弹.SN = "T000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "随机向敌方发射3枚奥术飞弹";
            奥术飞弹.Rare = (byte)稀有程度.史诗;
            System.Diagnostics.Debug.WriteLine(Card.CardUtility.GetRareName(奥术飞弹.Rare));
            奥术飞弹.Rare = ((byte)稀有程度.史诗) + 1;
            System.Diagnostics.Debug.WriteLine(Card.CardUtility.GetRareName(奥术飞弹.Rare));
        }
        private Image GetImageAA(String aaa) {
            return null;
        }
    }
}
