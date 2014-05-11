using System.Text;
using System.Windows.Forms;

namespace 炉边传说
{
    public partial class BattleField : Form
    {
        public BattleField()
        {
            InitializeComponent();
        }

        private void BattleField_Load(object sender, System.EventArgs e)
        {
            StringBuilder Status = new StringBuilder();
            Status.AppendLine("GameId：" + GameManager.GameId);
            Status.AppendLine("PlayerNickName：" + GameManager.PlayerNickName);
            Status.AppendLine("IsHost：" + GameManager.IsHost);
            Status.AppendLine("IsFirst：" + GameManager.IsFirst);
            lblStatus.Text = Status.ToString();
        }
    }
}
