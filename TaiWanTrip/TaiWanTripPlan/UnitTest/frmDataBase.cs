using System;
using System.Windows.Forms;

namespace UnitTest
{
    public partial class frmDataBase : Form
    {
        public frmDataBase()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            //用户测试用例
            Common.Database.Operater.Init();
            Common.User.UserInfo user = new Common.User.UserInfo();
            user.UserName = "TEST005";
            user.Email = "Test005@mail.com";
            Common.User.UserInfo.InsertUser(user);
            var t = Common.User.UserInfo.GetUserByName(user.UserName);
            MessageBox.Show(t.UserName + ":" + t.Email);
            Common.User.UserInfo.DeleteUser(user.UserName);
            t = Common.User.UserInfo.GetUserByName(user.UserName);
            if (t != null) MessageBox.Show(t.UserName + ":" + t.Email);
        }
    }
}
