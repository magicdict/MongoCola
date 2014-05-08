using Card.Player;
using System;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class RunMagic : Form
    {
        public RunMagic()
        {
            InitializeComponent();
        }

        Card.MagicCard 奥术飞弹 = new Card.MagicCard();
        BattleFieldInfo 敌方战场 = new BattleFieldInfo();
        PlayerBasicInfo 敌人 = new PlayerBasicInfo();

        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            奥术飞弹 = HelperUtility.Get奥术飞弹();
        }
        /// <summary>
        /// 重置对手
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetEenmey_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 敌方战场.BattleFollowers.Length; i++)
            {
                var 狼骑兵= HelperUtility.Get狼骑兵();
                狼骑兵.Init();
                敌方战场.BattleFollowers[i] = 狼骑兵;
            }
        }

 
        /// <summary>
        /// 使用魔法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserMagic_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUserMagic变羊术_Click(object sender, EventArgs e)
        {
            var 变羊术 = HelperUtility.Get变羊术();
            
        }
    }
}
