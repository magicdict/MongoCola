using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool.UserController
{
    public partial class ctlDataView : UserControl
    {
        public ctlDataView()
        {
            InitializeComponent();
        }

        private void ctlDataView_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage())
            {
                //数据显示区
                this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
                this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
                this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);
                this.lnkFile.Text = SystemManager.mStringResource.GetText(StringResource.TextType.OpenInNativeEditor);
            }
        }
    }
}
