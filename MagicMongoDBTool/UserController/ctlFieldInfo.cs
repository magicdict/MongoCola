using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class ctlFieldInfo : UserControl
    {
        public ctlFieldInfo()
        {
            InitializeComponent();
        }
        public DataFilter.QueryFieldItem QueryFieldItem
        {
            set
            {
                lblFieldName.Text = value.ColName;
                chkIsShow.Checked = value.IsShow;
                switch (value.sortType)
                {
                    case DataFilter.SortType.NoSort:
                        radNoSort.Checked = true;
                        break;
                    case DataFilter.SortType.Ascending:
                        radSortAcs.Checked = true;
                        break;
                    case DataFilter.SortType.Descending:
                        radSortDes.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            get
            {
                DataFilter.QueryFieldItem rtn = new DataFilter.QueryFieldItem();
                rtn.IsShow = chkIsShow.Checked;
                rtn.ColName = lblFieldName.Text;
                if (this.radNoSort.Checked) 
                {
                    rtn.sortType = DataFilter.SortType.NoSort;
                }
                if (this.radSortAcs.Checked) 
                {
                    rtn.sortType = DataFilter.SortType.Ascending; 
                }
                if (this.radSortDes.Checked) 
                {
                    rtn.sortType = DataFilter.SortType.Descending; 
                }
                return rtn;
            }

        }
    }
}
