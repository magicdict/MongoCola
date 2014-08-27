using System;
using System.Windows.Forms;
using Common.Account;
using Common.Schedule;
using Common.Database;

namespace UnitTest
{
    public partial class frmDataBase : Form
    {
        public frmDataBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 用户测试用例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUser_Click(object sender, EventArgs e)
        {
            //用户测试用例
            Operater.Init();
            UserInfo user = new UserInfo();
            user.UserName = "TEST005";
            user.Email = "Test005@mail.com";
            UserInfo.InsertUser(user);
            var t = UserInfo.GetUserByName(user.UserName);
            MessageBox.Show(t.UserName + ":" + t.Email);
            UserInfo.DeleteUser(user.UserName);
            t = UserInfo.GetUserByName(user.UserName);
            if (t != null) MessageBox.Show(t.UserName + ":" + t.Email);
        }
        /// <summary>
        /// 行程测试用例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSchedule_Click(object sender, EventArgs e)
        {
            //行程测试用例
            Operater.Init();
            Overview Trip = new Overview();
            UserInfo user = new UserInfo();
            user.UserName = "TEST005";
            user.Email = "Test005@mail.com";
            UserInfo.InsertUser(user);
            Trip.CreateUserName = user.UserName;
            Trip.StartDate = new DateTime(2014, 10, 10);
            Trip.EndDate = new DateTime(2014, 10, 15);
            Trip.MemberCount = 4;
            Trip.DepartLocation = "上海";
            Trip.ReturnLocation = "上海";
            Trip.EntryLocation = "台币";
            Trip.ExitLocation = "高雄";
            Trip.Budget = 20000;

            Preparation 入台通行证办理 = new Preparation();
            入台通行证办理.StartDate = new DateTime(2014, 8, 23);
            入台通行证办理.EndDate = new DateTime(2014, 8, 23);
            入台通行证办理.Location = "上海市杨浦区出入境管理处 淞沪路605号";
            入台通行证办理.Comments = "网上先预约一下，可以加快办理速度";
            Consumption 入台通行证手续费 = new Consumption();
            入台通行证手续费.Price = 50;
            入台通行证手续费.Count = 4;
            入台通行证手续费.PayCurrency = Consumption.CurrencyEnum.RMB;
            入台通行证手续费.PayMethod = Consumption.PayMethodEnum.Cash;
            入台通行证手续费.PayClass = Consumption.PayClassEnum.Certificates;
            入台通行证手续费.PayTime = new DateTime(2014, 8, 23);
            入台通行证办理.ConsumptionList.Add(入台通行证手续费);
            Operater.FillBaseInfo(入台通行证办理);
            Trip.PreparationList.Add(入台通行证办理);

            Overview.InsertOverview(Trip);

        }
        /// <summary>
        /// 详细行程测试用例
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailSchedule_Click(object sender, EventArgs e)
        {
            Operater.Init();
            Traffic info = new Traffic();
            info.Description = "坐车去九份";
            info.Location = "台北市";
            info.StartDate = new DateTime(2014, 10, 11, 8, 30, 00);
            info.EndDate = new DateTime(2014, 10, 11, 10, 00, 00);
            info.Comments = "BUS1602!别坐错了";
            Traffic.InsertDetailInfo(info);
        }
    }
}
