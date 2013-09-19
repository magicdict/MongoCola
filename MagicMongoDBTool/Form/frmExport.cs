using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
namespace MagicMongoDBTool
{
    public partial class frmExport : Form
    {
        private MongoDBHelper.DataViewInfo viewinfo;
        public frmExport(MongoDBHelper.DataViewInfo info)
        {
            InitializeComponent();
            viewinfo = info;
        }
        private void btnSaveAsExcel_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ExportToExcel(viewinfo,ctlExcelFilePicker.SelectedPathOrFileName);
        }
    }
}
