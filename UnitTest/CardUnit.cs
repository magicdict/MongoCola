using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Card.SystemManager.Init();
            Card.SystemManager.RareNameDic = new string[] { "一般", "普通", "卓越", "史诗" };
            Card.CardBasicInfo 奥术飞弹 = new Card.CardBasicInfo();
            奥术飞弹.SN = "T000001";
            奥术飞弹.Name = "奥术飞弹";
            奥术飞弹.Description = "随机向敌方发射3枚奥术飞弹";
            奥术飞弹.ImagePath = "Image/奥术飞弹";
            奥术飞弹.Rare = (byte)稀有程度.史诗;
            MessageBox.Show(奥术飞弹.GetRareName());
            奥术飞弹.Rare = ((byte)稀有程度.史诗) + 1;
            MessageBox.Show(奥术飞弹.GetRareName());
        }
    }
}
