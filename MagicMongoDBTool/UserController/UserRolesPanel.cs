using MongoDB.Bson;
using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool.UserController
{
    public partial class UserRolesPanel : UserControl
    {
        public UserRolesPanel()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage) {
                grpRoles.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Roles);
            }
        }
        public BsonArray getRoles()
        {
            BsonArray roles = new BsonArray();
            foreach (Control item in this.grpRoles.Controls)
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
        public void setRoles(BsonArray value)
        {
            {
                foreach (String item in value)
                {
                    ((CheckBox)(grpRoles.Controls.Find("chk" + item, true)[0])).Checked = true;
                }
            }
        }
    }
}
