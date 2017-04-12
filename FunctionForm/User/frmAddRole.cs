using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.Security;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.User
{
    public partial class FrmAddRole : Form
    {
        /// <summary>
        ///     Priviege List
        /// </summary>
        private List<Role.Privilege> _privilegeList = new List<Role.Privilege>();

        /// <summary>
        ///     Role List
        /// </summary>
        private List<Role.GrantRole> _roleList = new List<Role.GrantRole>();

        /// <summary>
        ///     选中的Action
        /// </summary>
        private List<string> PickedAction = new List<string>();

        public FrmAddRole()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddRole_Load(object sender, EventArgs e)
        {
            Common.UIAssistant.FillComberWithEnum(cmbResourceType, typeof(MongoResource.ResourceType));
            var dbs = RuntimeMongoDbContext.GetCurrentServer().GetDatabaseNames();
            Common.UIAssistant.FillComberWithArray(cmbDatabase, dbs, false);
            Common.UIAssistant.FillComberWithEnum(cmbActionGroup, typeof(MongoAction.ActionGroup));
            GuiConfig.Translateform(this);
        }

        #region Priviege
        /// <summary>
        ///     选择数据库变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCollection.Text = string.Empty;
            cmbCollection.Items.Clear();
            if (cmbDatabase.SelectedIndex == 0)
            {
                Common.UIAssistant.FillComberWithArray(cmbCollection, new List<string>(), false);
                return;
            }
            var cols = RuntimeMongoDbContext.GetCurrentServer().GetDatabase(cmbDatabase.Text).GetCollectionNames();
            Common.UIAssistant.FillComberWithArray(cmbCollection, cols, false);
        }

        /// <summary>
        ///     获得资源定义
        /// </summary>
        /// <returns></returns>
        private MongoResource GetRoleResource()
        {
            var res = new MongoResource
            {
                Type = (MongoResource.ResourceType)Enum.Parse(typeof(MongoResource.ResourceType), cmbResourceType.Text),
                DataBaseName = cmbDatabase.SelectedIndex == 0 ? string.Empty : cmbDatabase.Text,
                CollectionName = cmbCollection.SelectedIndex == 0 ? string.Empty : cmbCollection.Text
            };
            return res;
        }

        /// <summary>
        ///     Action Group Changed
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
                    chklstAction.Items.Add(actionName, PickedAction.Contains(actionName));
                }
            }
        }

        /// <summary>
        ///     选择或者放弃选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chklstAction_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                //新的状态是选中，则添加
                PickedAction.Add(((CheckedListBox)sender).Text);
            }
            else
            {
                //新的状态是不选中，则删除
                PickedAction.Remove(((CheckedListBox)sender).Text);
            }
        }

        /// <summary>
        ///     添加权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPriviege_Click(object sender, EventArgs e)
        {
            var res = GetRoleResource().GetBsonDoc();
            var act = MongoAction.GetActionArray(PickedAction);
            _privilegeList.Add(new Role.Privilege
            {
                Resource = res,
                Actions = act
            });

            var t = new ListViewItem()
            {
                Text = res.ToString()
            };
            t.SubItems.Add(act.ToString());
            lstPriviege.Items.Add(t);
            PickedAction.Clear();
            cmbActionGroup.SelectedIndex = 1;
            cmbActionGroup.SelectedIndex = 0;
        }
        #endregion

        /// <summary>
        ///     Add A Custom User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCustomRole_Click(object sender, EventArgs e)
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
            //这个时候可能没有GetCurrentDataBase，如果是Admin
            var result = DataBaseCommand.createRole(RuntimeMongoDbContext.GetCurrentServer().GetDatabase(r.Database), r);
            if (result.Ok)
            {
                MyMessageBox.ShowEasyMessage("Succeed", "Add Role OK");
            }
            else
            {
                MyMessageBox.ShowMessage("Error", "Add Role Error", result.Response.ToString());
            }
        }


        /// <summary>
        ///     选择角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickRole_Click(object sender, EventArgs e)
        {
            var mUserRole = new FrmUserRole(_roleList, true);
            mUserRole.ShowDialog();
            _roleList = mUserRole.PickedRoles;
            lstRoles.Items.Clear();
            foreach (var role in _roleList)
            {
                var lst = new ListViewItem(role.Role);
                lst.SubItems.Add(role.Db);
                lstRoles.Items.Add(lst);
            }
        }
    }
}