using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common.UI;
using MongoGUIView;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;

namespace MongoCola
{
    public partial class frmAddRole : Form
    {
        /// <summary>
        /// </summary>
        private readonly List<Role.privilege> PrivilegeList = new List<Role.privilege>();

        /// <summary>
        /// </summary>
        private readonly List<Role.GrantRole> RoleList = new List<Role.GrantRole>();

        public frmAddRole()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddRole_Load(object sender, EventArgs e)
        {
            cmbResourceType.Items.Clear();
            foreach (var item in Enum.GetNames(typeof (Resource.ResourceType)))
            {
                cmbResourceType.Items.Add(item);
            }
            cmbDatabase.Items.Clear();
            foreach (var item in RuntimeMongoDBContext.GetCurrentServer().GetDatabaseNames())
            {
                cmbDatabase.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof (MongoDBAction.ActionGroup)))
            {
                cmbActionGroup.Items.Add(item.ToString().Replace("_", " "));
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private Resource GetRoleResource()
        {
            var res = new Resource
            {
                Type = (Resource.ResourceType) Enum.Parse(typeof (Resource.ResourceType), cmbResourceType.Text),
                DataBaseName = cmbDatabase.Text,
                CollectionName = cmbCollection.Text
            };
            return res;
        }

        /// <summary>
        ///     Add A Custom User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var r = new Role();
            if (RuntimeMongoDBContext.GetCurrentDataBase() != null)
            {
                r.database = RuntimeMongoDBContext.GetCurrentDataBase().Name;
            }
            else
            {
                r.database = ConstMgr.DATABASE_NAME_ADMIN;
            }
            r.rolename = txtRolename.Text;
            r.privileges = new Role.privilege[PrivilegeList.Count];
            for (var i = 0; i < PrivilegeList.Count; i++)
            {
                r.privileges[i] = PrivilegeList[i];
            }
            r.roles = new Role.GrantRole[RoleList.Count];
            for (var i = 0; i < RoleList.Count; i++)
            {
                r.roles[i] = RoleList[i];
            }
            var result = Role.AddRole(RuntimeMongoDBContext.GetCurrentDataBase(), r);
            if (result.IsBsonDocument)
            {
                MyMessageBox.ShowMessage("Error", "Add Role Error", ViewHelper.ConvertToString(result));
            }
            else
            {
                MyMessageBox.ShowEasyMessage("Succeed", "Add Role OK");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbActionGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            chklstAction.Items.Clear();
            var Prifix = cmbActionGroup.Text.Replace(" ", string.Empty);
            foreach (var item in Enum.GetValues(typeof (MongoDBAction.ActionType)))
            {
                if (item.ToString().StartsWith(Prifix))
                    chklstAction.Items.Add(item.ToString().Substring(Prifix.Length + 1));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPriviege_Click(object sender, EventArgs e)
        {
            var actionlst = new MongoDBAction.ActionType[chklstAction.CheckedItems.Count];
            for (var i = 0; i < chklstAction.CheckedItems.Count; i++)
            {
                actionlst[i] = ((MongoDBAction.ActionType) Enum.Parse(typeof (MongoDBAction.ActionType),
                    cmbActionGroup.Text.Replace(" ", string.Empty) + "_" + chklstAction.CheckedItems[i]));
            }
            PrivilegeList.Add(new Role.privilege
            {
                resource = GetRoleResource(),
                actions = actionlst
            });

            var t = new ListViewItem();
            t.Text = GetRoleResource().GetJsCode();
            t.SubItems.Add(MongoDBAction.GetActionListJs(actionlst));
            lstPriviege.Items.Add(t);
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCollection.Text = string.Empty;
            cmbCollection.Items.Clear();
            foreach (
                var item in RuntimeMongoDBContext.GetCurrentServer().GetDatabase(cmbDatabase.Text).GetCollectionNames())
            {
                cmbCollection.Items.Add(item);
            }
        }
    }
}