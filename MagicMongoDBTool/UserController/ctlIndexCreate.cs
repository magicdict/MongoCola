using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlIndexCreate : UserControl
    {
        public Boolean IsAscendingKey
        {
            get { return radAscendingKey.Checked; }
        }
        public String KeyName
        {
            get { return txtKeyName.Text; }
        }
        public ctlIndexCreate()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.lblKeyName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.ctlIndexCreate_Index);
                this.radAscendingKey.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Asce);
                this.radDescendingKey.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Desc);
            }

        }
    }
}
