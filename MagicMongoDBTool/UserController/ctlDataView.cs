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
        /// <summary>
        /// Control for show Data
        /// </summary>
        public List<Control> _dataShower = new List<Control>();

        private void ctlDataView_Load(object sender, EventArgs e)
        {
            _dataShower.Add(lstData);
            _dataShower.Add(trvData);
            _dataShower.Add(txtData);


            if (!SystemManager.IsUseDefaultLanguage())
            {
                //数据显示区
                this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
                this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
                this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);
                this.lnkFile.Text = SystemManager.mStringResource.GetText(StringResource.TextType.OpenInNativeEditor);
            }
        }
        public void clear() {
            lstData.Clear();
            txtData.Text = String.Empty;
            trvData.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.ContextMenuStrip = null;
        }
        /// <summary>
        /// Open In Native Editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MongoDBHelper.SaveAndOpenStringAsFile(txtData.Text);
        }
    }
}
