using MongoUtility.Command;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.Status
{
    public partial class frmCustomMonitorItems : Form
    {
        public frmCustomMonitorItems()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 选择项目
        /// </summary>
        public List<string> SelectedItems = null;

        private void frmCustomMonitorItems_Load(object sender, EventArgs e)
        {
            chklstStatus.Items.Clear();
            //加载所有可以使用的项目
            foreach (var item in SystemStatus.StatusNameDic.Values)
            {
                chklstStatus.Items.Add(item);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedItems = new List<string>();
            SelectedItems.Clear();
            foreach (var item in chklstStatus.CheckedItems)
            {
                SelectedItems.Add(item.ToString());
            }
            Close();
        }
    }
}
