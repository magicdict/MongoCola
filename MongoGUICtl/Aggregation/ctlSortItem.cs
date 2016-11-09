using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MongoGUICtl.Aggregation
{
    public partial class ctlSortItem : UserControl
    {
        public ctlSortItem()
        {
            InitializeComponent();
        }
       
        private void ctlSortItem_Load(object sender, EventArgs e)
        {
            cmbSort.Items.Clear();
            cmbSort.Items.Add("Asce");
            cmbSort.Items.Add("Desc");
            cmbSort.Items.Add("TextScore(Desc)");
        }

        /// <summary>
        ///     设定字段
        /// </summary>
        /// <param name="FieldList"></param>
        public void SetField(List<string> FieldList)
        {
            Common.Utility.FillComberWithArray(cmbField, FieldList.ToArray());
        }        

    }
}
