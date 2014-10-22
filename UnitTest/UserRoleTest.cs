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
using MongoCola.Module;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRoleToDB_Click(object sender, EventArgs e)
        {
            Role r = new Role();
            r.rolename = "tester" + System.DateTime.Now.ToString("yyyyMMddHHmmss");
            r.database = "admin";
            r.roles = new Role.GrantRole[1];
            r.roles[0] = new Role.GrantRole() {  db = "admin", mRole="read"};
            r.privileges = new Role.privilege[1];
            r.privileges[0] = new Role.privilege()
            {
                actions = new Common.Security.Action.ActionType[1] { Common.Security.Action.ActionType.DatabaseManagementActions_createCollection },
                resource = new Resource() { CollectionName = "", DataBaseName = "admin", Type = Resource.ResourceType.DataBase }
            };
            var doc = Role.AddRole(SystemManager.GetCurrentServer().GetDatabase("admin"), r);
            if (doc.IsBsonDocument) MongoDbHelper.FillDataToTreeView("myClusterwideAdmin", treeViewColumns1, doc.AsBsonDocument);
        }
    }
}
