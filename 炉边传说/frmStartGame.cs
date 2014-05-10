using System;
using System.Windows.Forms;

namespace 炉边传说
{
    public partial class frmStartGame : Form
    {
        public frmStartGame()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开始游戏的请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGame_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Card.Server.Communication.Request("STARTGAME"));
        }
    }
}
