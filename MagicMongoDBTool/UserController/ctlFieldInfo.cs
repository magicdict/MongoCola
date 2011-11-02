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
        public MongoDBHelpler.QueryFieldItem QueryFieldItem
        {
            set
            {
                lblFieldName.Text = value.ColName;
                chkIsShow.Checked = value.IsShow;
                switch (value.sortType)
                {
                    case MongoDBHelpler.SortType.NoSort:
                        radNoSort.Checked = true;
                        break;
                    case MongoDBHelpler.SortType.Ascending:
                        radSortAcs.Checked = true;
                        break;
                    case MongoDBHelpler.SortType.Descending:
                        radSortDes.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            get
            {
                MongoDBHelpler.QueryFieldItem rtn = new MongoDBHelpler.QueryFieldItem();
                rtn.IsShow = chkIsShow.Checked;
                rtn.ColName = lblFieldName.Text;
                if (this.radNoSort.Checked) 
                { 
                    rtn.sortType = MongoDBHelpler.SortType.NoSort;
                }
                if (this.radSortAcs.Checked) 
                { 
                    rtn.sortType = MongoDBHelpler.SortType.Ascending; 
                }
                if (this.radSortDes.Checked) 
                { 
                    rtn.sortType = MongoDBHelpler.SortType.Descending; 
                }
                return rtn;
            }

        }
    }
}
