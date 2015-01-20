using System;
using System.Windows.Forms;
using MongoDB.Bson;
using ResourceLib.Utility;

namespace MongoGUICtl
{
    public partial class ctlUserRolesPanel : UserControl
    {
        public ctlUserRolesPanel()
        {
            InitializeComponent();
            if (configuration.guiConfig == null) return;
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                grpRoles.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Roles);
            }
        }

        public Boolean IsAdmin
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

        public BsonArray getRoles()
        {
            var roles = new BsonArray();
            foreach (Control item in grpRoles.Controls)
            {
                if (item.Name.StartsWith("chk"))
                {
                    if (((CheckBox) item).Checked)
                    {
                        roles.Add(item.Name.Substring(3));
                    }
                }
            }
            return roles;
        }

        public void setRoles(BsonArray value)
        {
            {
                foreach (String item in value)
                {
                    ((CheckBox) (grpRoles.Controls.Find("chk" + item, true)[0])).Checked = true;
                }
            }
        }
    }
}