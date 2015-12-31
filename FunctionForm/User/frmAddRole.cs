using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MongoGUIView;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.UI;

namespace FunctionForm.User
{
    public partial class FrmAddRole : Form
    {
        /// <summary>
        /// </summary>
        private readonly List<Role.Privilege> _privilegeList = new List<Role.Privilege>();

        /// <summary>
        /// </summary>
        private readonly List<Role.GrantRole> _roleList = new List<Role.GrantRole>();

        public FrmAddRole()
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
            foreach (var item in RuntimeMongoDbContext.GetCurrentServer().GetDatabaseNames())
            {
                cmbDatabase.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof (MongoDbAction.ActionGroup)))
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
            if (RuntimeMongoDbContext.GetCurrentDataBase() != null)
            {
                r.Database = RuntimeMongoDbContext.GetCurrentDataBase().Name;
            }
            else
            {
                r.Database = ConstMgr.DatabaseNameAdmin;
            }
            r.Rolename = txtRolename.Text;
            r.Privileges = new Role.Privilege[_privilegeList.Count];
            for (var i = 0; i < _privilegeList.Count; i++)
            {
                r.Privileges[i] = _privilegeList[i];
            }
            r.Roles = new Role.GrantRole[_roleList.Count];
            for (var i = 0; i < _roleList.Count; i++)
            {
                r.Roles[i] = _roleList[i];
            }
            var result = Role.AddRole(RuntimeMongoDbContext.GetCurrentDataBase(), r);
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
            var prifix = cmbActionGroup.Text.Replace(" ", string.Empty);
            foreach (var item in Enum.GetValues(typeof (MongoDbAction.ActionType)))
            {
                if (item.ToString().StartsWith(prifix))
                    chklstAction.Items.Add(item.ToString().Substring(prifix.Length + 1));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPriviege_Click(object sender, EventArgs e)
        {
            var actionlst = new MongoDbAction.ActionType[chklstAction.CheckedItems.Count];
            for (var i = 0; i < chklstAction.CheckedItems.Count; i++)
            {
                actionlst[i] = (MongoDbAction.ActionType) Enum.Parse(typeof (MongoDbAction.ActionType),
                    cmbActionGroup.Text.Replace(" ", string.Empty) + "_" + chklstAction.CheckedItems[i]);
            }
            _privilegeList.Add(new Role.Privilege
            {
                Resource = GetRoleResource(),
                Actions = actionlst
            });

            var t = new ListViewItem();
            t.Text = GetRoleResource().GetJsCode();
            t.SubItems.Add(MongoDbAction.GetActionListJs(actionlst));
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
                var item in RuntimeMongoDbContext.GetCurrentServer().GetDatabase(cmbDatabase.Text).GetCollectionNames())
            {
                cmbCollection.Items.Add(item);
            }
        }
    }
}