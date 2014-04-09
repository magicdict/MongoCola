using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Security;
using MagicMongoDBTool.Module;

namespace UnitTest
{
    public partial class UserRoleTest : Form
    {
        public UserRoleTest()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllCustomRole_Click(object sender, EventArgs e)
        {
            var doc = Role.GetRole(SystemManager.GetCurrentServer().GetDatabase("admin"), "myClusterwideAdmin");
            MongoDbHelper.FillDataToTreeView("myClusterwideAdmin", treeViewColumns1, doc);
        }
    }
}
