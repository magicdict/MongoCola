using MongoGUIView;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
            foreach (var item in Enum.GetNames(typeof(Resource.ResourceType)))
            {
                cmbResourceType.Items.Add(item);
            }
            cmbDatabase.Items.Clear();
            foreach (var item in RuntimeMongoDbContext.GetCurrentServer().GetDatabaseNames())
            {
                cmbDatabase.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(MongoAction.ActionGroup)))
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
                Type = (Resource.ResourceType)Enum.Parse(typeof(Resource.ResourceType), cmbResourceType.Text),
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
            foreach (var item in Enum.GetValues(typeof(MongoAction.ActionType)))
            {
                if (item.ToString().StartsWith(prifix))
                {
                    var actionName = item.ToString().Substring(prifix.Length);
                    actionName = actionName.Substring(0, 1).ToLower() + actionName.Substring(1);
                    chklstAction.Items.Add(actionName);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPriviege_Click(object sender, EventArgs e)
        {
            var actionlst = new MongoAction.ActionType[chklstAction.CheckedItems.Count];
            for (var i = 0; i < chklstAction.CheckedItems.Count; i++)
            {
                actionlst[i] = (MongoAction.ActionType)Enum.Parse(typeof(MongoAction.ActionType),
                    cmbActionGroup.Text.Replace(" ", string.Empty) + "_" + chklstAction.CheckedItems[i]);
            }
            _privilegeList.Add(new Role.Privilege
            {
                Resource = GetRoleResource(),
                Actions = actionlst
            });

            var t = new ListViewItem();
            t.Text = GetRoleResource().GetJsCode();
            t.SubItems.Add(MongoAction.GetActionListJs(actionlst));
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