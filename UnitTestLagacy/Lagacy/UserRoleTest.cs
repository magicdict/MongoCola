using System;
using System.Windows.Forms;
using MongoGUICtl;
using MongoUtility.Security;

namespace UnitTestLagacy.Lagacy
{
    public partial class UserRoleTest : Form
    {
        public UserRoleTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetAllCustomRole_Click(object sender, EventArgs e)
        {
            var doc = Role.GetRole(SystemManager.GetCurrentServer().GetDatabase("admin"), "myClusterwideAdmin");
            UIHelper.FillDataToTreeView("myClusterwideAdmin", treeViewColumns1, doc);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRoleToDB_Click(object sender, EventArgs e)
        {
            var r = new Role();
            r.rolename = "tester" + DateTime.Now.ToString("yyyyMMddHHmmss");
            r.database = "admin";
            r.roles = new Role.GrantRole[1];
            r.roles[0] = new Role.GrantRole {db = "admin", mRole = "read"};
            r.privileges = new Role.privilege[1];
            r.privileges[0] = new Role.privilege
            {
                actions =
                    new MongoDBAction.ActionType[1]
                    {MongoDBAction.ActionType.DatabaseManagementActions_createCollection},
                resource =
                    new Resource {CollectionName = "", DataBaseName = "admin", Type = Resource.ResourceType.DataBase}
            };
            var doc = Role.AddRole(SystemManager.GetCurrentServer().GetDatabase("admin"), r);
            if (doc.IsBsonDocument)
                UIHelper.FillDataToTreeView("myClusterwideAdmin", treeViewColumns1, doc.AsBsonDocument);
        }
    }
}