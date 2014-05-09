using System;
using System.Windows.Forms;

namespace CardHelper
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 魔法测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunAbility_Click(object sender, EventArgs e)
        {
            new RunAbility().ShowDialog();
        }
        /// <summary>
        /// 牌堆测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCardDeck_Click(object sender, EventArgs e)
        {
            new CardDeckTest().ShowDialog();
        }
        /// <summary>
        /// 游戏流程测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGameFlow_Click(object sender, EventArgs e)
        {
            new GameFlowTest().ShowDialog();
        }
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            new frmExport().ShowDialog();
        }
    }
}
