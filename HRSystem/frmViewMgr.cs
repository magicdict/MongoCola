using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace HRSystem
{
    public partial class frmViewMgr : Form
    {
        public frmViewMgr()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewMgr_Load(object sender, EventArgs e)
        {
            chklstDisplay.Items.Clear();
            foreach (var DisplayItem in ViewControl.FullPositionFields)
            {
                chklstDisplay.Items.Add(DisplayItem,true);
            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            chklstDisplay.Items.Clear();
            foreach (var DisplayItem in ViewControl.FullPositionFields)
            {
                chklstDisplay.Items.Add(DisplayItem, true);
            }
        }
        /// <summary>
        /// 全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            chklstDisplay.Items.Clear();
            foreach (var DisplayItem in ViewControl.FullPositionFields)
            {
                chklstDisplay.Items.Add(DisplayItem, false);
            }
        }
        /// <summary>
        /// 设定当前视图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            ViewControl.CurrentPositionViewFields = new string[chklstDisplay.CheckedItems.Count];
            for (int i = 0; i < chklstDisplay.CheckedItems.Count; i++)
            {
                ViewControl.CurrentPositionViewFields[i] = chklstDisplay.CheckedItems[i].ToString();
            }
            this.Close();
        }
        /// <summary>
        /// Save The View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveView_Click(object sender, EventArgs e)
        {
            var ViewName = Interaction.InputBox("Please Input View Name");

        }
    }
}
