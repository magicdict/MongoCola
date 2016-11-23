using MongoDB.Bson;
using ResourceLib.Method;
using System.Windows.Forms;

namespace MongoGUICtl
{
    public partial class CtlUserRolesPanel : UserControl
    {
        public CtlUserRolesPanel()
        {
            InitializeComponent();
        }

        public bool IsAdmin
        {
            set
            {
                if (!value)
                {
                    //Note:Any Database Roles
                    //You must specify the following “any” database roles on the admin databases. 
                    //These roles apply to all databases in a mongod instance and are roughly equivalent to their single-database equivalents.
                    //If you add any of these roles to a user privilege document outside of the admin database,
                    //the privilege will have no effect. However, only the specification of the roles must occur in the admin database, 
                    //with delegated authentication credentials, users can gain these privileges by authenticating to another database.
                    chkdbAdminAnyDatabase.Enabled = false;
                    chkreadAnyDatabase.Enabled = false;
                    chkreadWriteAnyDatabase.Enabled = false;
                    chkuserAdminAnyDatabase.Enabled = false;
                }
            }
        }

        public BsonArray GetRoles()
        {
            var roles = new BsonArray();
            foreach (Control item in grpRoles.Controls)
            {
                if (item.Name.StartsWith("chk"))
                {
                    if (((CheckBox)item).Checked)
                    {
                        roles.Add(item.Name.Substring(3));
                    }
                }
            }
            return roles;
        }

        public void SetRoles(BsonArray value)
        {
            foreach (string item in value)
            {
                ((CheckBox)grpRoles.Controls.Find("chk" + item, true)[0]).Checked = true;
            }
        }

        private void CtlUserRolesPanel_Load(object sender, System.EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                grpRoles.Text = GuiConfig.GetText("Roles","Common.Roles");
            }
        }
    }
}