using MagicMongoDBTool.Module;
using System;
using System.Windows.Forms;
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
        public frmExport()
        {
            InitializeComponent();
        }
        private void frmExport_Load(object sender, EventArgs e)
        {
            //Excel文件过滤器
            ctlExcelFilePicker.FileFilter = MongoDBHelper.ExcelFilter;
        }
        private void btnSaveAsExcel_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ActionDone += new EventHandler<ActionDoneEventArgs>(
                (x, y) =>
                {
                    MyMessageBox.ShowMessage("Export", y.Message);                    
                }
            );
            MongoDBHelper.ExportToExcel(viewinfo,ctlExcelFilePicker.SelectedPathOrFileName);
        }

    }
}
