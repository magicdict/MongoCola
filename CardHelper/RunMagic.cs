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
        Card.BattleFieldInfo 敌方战场 = new Card.BattleFieldInfo();
        Card.RoleInfo 敌人 = new Card.RoleInfo();

        private void btnCreate奥术飞弹_Click(object sender, EventArgs e)
        {
            奥术飞弹 = Utility.Get奥术飞弹();
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
                var 狼骑兵= Utility.Get狼骑兵();
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
            var 变羊术 = Utility.Get变羊术();
            
        }
    }
}
