using Common.Security;
using MongoCola.Module;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MongoCola
{
    public partial class frmAddRole : Form
    {
        public frmAddRole()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddRole_Load(object sender, EventArgs e)
        {
            cmbResourceType.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(Common.Security.Resource.ResourceType)))
            {
                cmbResourceType.Items.Add(item.ToString());
            }
            cmbDatabase.Items.Clear();
            foreach (String item in SystemManager.GetCurrentServer().GetDatabaseNames())
            {
                cmbDatabase.Items.Add(item);
            }
            foreach (var item in System.Enum.GetValues(typeof(Common.Security.Action.ActionGroup)))
            {
                cmbActionGroup.Items.Add(item.ToString().Replace("_", " "));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Resource GetRoleResource()
        {
            Resource res = new Resource()
            {
                Type = (Resource.ResourceType)Enum.Parse(typeof(Resource.ResourceType), cmbResourceType.Text),
                DataBaseName = cmbDatabase.Text,
                CollectionName = cmbCollection.Text
            };
            return res;
        }
        /// <summary>
        /// Add A Custom User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            Role r = new Role();
            if (SystemManager.GetCurrentDataBase() != null) {
                r.database = SystemManager.GetCurrentDataBase().Name;
            } else {
                r.database = MongoDbHelper.DATABASE_NAME_ADMIN;
            }
            r.rolename = txtRolename.Text;
            r.privileges = new Role.privilege[PrivilegeList.Count];
            for (int i = 0; i < PrivilegeList.Count; i++)
            {
                r.privileges[i] = PrivilegeList[i];
            }
            r.roles = new Role.GrantRole[RoleList.Count];
            for (int i = 0; i < RoleList.Count; i++)
            {
                r.roles[i] = RoleList[i];
            }
            var result = Role.AddRole(SystemManager.GetCurrentDataBase(), r);
            if (result.IsBsonDocument) {
                MyMessageBox.ShowMessage("Error", "Add Role Error",MongoDbHelper.ConvertToString(result));
            }
            else
            {
                MyMessageBox.ShowEasyMessage("Succeed", "Add Role OK");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        List<Role.privilege> PrivilegeList = new List<Role.privilege>();
        /// <summary>
        /// 
        /// </summary>
        List<Role.GrantRole> RoleList = new List<Role.GrantRole>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbActionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            chklstAction.Items.Clear();
            string Prifix = cmbActionGroup.Text.Replace(" ", string.Empty);
            foreach (var item in System.Enum.GetValues(typeof(Common.Security.Action.ActionType)))
            {
                if (item.ToString().StartsWith(Prifix)) chklstAction.Items.Add(item.ToString().Substring(Prifix.Length + 1));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPriviege_Click(object sender, EventArgs e)
        {
            Common.Security.Action.ActionType[] actionlst = new Common.Security.Action.ActionType[chklstAction.CheckedItems.Count];
            for (int i = 0; i < chklstAction.CheckedItems.Count; i++)
            {
                actionlst[i] = ((Common.Security.Action.ActionType)Enum.Parse(typeof(Common.Security.Action.ActionType),
                               cmbActionGroup.Text.Replace(" ", String.Empty) + "_" + chklstAction.CheckedItems[i].ToString()));
            }
            PrivilegeList.Add(new Role.privilege()
            {
                resource = GetRoleResource(),
                actions = actionlst
            });

            ListViewItem t = new ListViewItem();
            t.Text = GetRoleResource().GetJsCode();
            t.SubItems.Add(Common.Security.Action.GetActionListJs(actionlst));
            lstPriviege.Items.Add(t);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCollection.Text = String.Empty;
            cmbCollection.Items.Clear();
            foreach (var item in SystemManager.GetCurrentServer().GetDatabase(cmbDatabase.Text).GetCollectionNames())
            {
                cmbCollection.Items.Add(item);
            }
        }
    }
}
