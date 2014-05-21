using Card;
using System.Windows.Forms;

namespace 炉边传说
{
    public partial class TargetSelect : Form
    {

        public CardUtility.TargetPosition pos = new CardUtility.TargetPosition();
        public TargetSelect()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HostHero_Click(object sender, System.EventArgs e)
        {
            pos.MyOrAgainst = true;
            pos.Postion = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuestHero_Click(object sender, System.EventArgs e)
        {
            pos.MyOrAgainst = false;
            pos.Postion = 0;
        }
    }
}
