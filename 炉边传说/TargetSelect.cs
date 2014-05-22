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
        private void TargetSelect_Load(object sender, System.EventArgs e)
        {
            //暂时这样写吧，应该用控件数组的。。。
            this.btnAgainst1.Click += (x,y) => {
                pos.MyOrAgainst = false;
                pos.Postion = 1;
            };
            this.btnAgainst2.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 2;
            };
            this.btnAgainst3.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 3;
            };
            this.btnAgainst4.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 4;
            };
            this.btnAgainst5.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 5;
            };
            this.btnAgainst6.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 6;
            };
            this.btnAgainst7.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 7;
            };

            this.btnMy1.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 1;
            };
            this.btnMy2.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 2;
            };
            this.btnMy3.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 3;
            };
            this.btnMy4.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 4;
            };
            this.btnMy5.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 5;
            };
            this.btnMy6.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 6;
            };
            this.btnMy7.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 7;
            };

            this.HostHero.Click += (x, y) =>
            {
                pos.MyOrAgainst = true;
                pos.Postion = 0;
            };
            this.GuestHero.Click += (x, y) =>
            {
                pos.MyOrAgainst = false;
                pos.Postion = 0;
            };
        }
    }
}
