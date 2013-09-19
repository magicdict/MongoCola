using MagicMongoDBTool.Module;
using System;
using System.Windows.Forms;
namespace MagicMongoDBTool
{
    public partial class frmExport : Form
    {
        private MongoDBHelper.DataViewInfo viewinfo;
        MongoDBHelper.ExportType exportType;
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
            ctlExportFilePicker.FileFilter = MongoDBHelper.ExcelFilter;
            exportType = MongoDBHelper.ExportType.Excel;
            ctlExportFilePicker.FileName = SystemManager.GetCurrentCollection().Name;
            optExcel.CheckedChanged += optExportType_CheckedChanged;
            optText.CheckedChanged += optExportType_CheckedChanged;
            optXML.CheckedChanged += optExportType_CheckedChanged;
            if (!SystemManager.IsUseDefaultLanguage) {
                btnSave.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Save);
            }
        }
        /// <summary>
        /// 导出类型更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void optExportType_CheckedChanged(object sender, EventArgs e)
        {
            if (optExcel.Checked) {
                ctlExportFilePicker.FileFilter = MongoDBHelper.ExcelFilter;
                exportType = MongoDBHelper.ExportType.Excel;
            }
            if (optText.Checked)
            {
                ctlExportFilePicker.FileFilter = MongoDBHelper.TxtFilter;
                exportType = MongoDBHelper.ExportType.Text;
            }
            if (optXML.Checked)
            {
                ctlExportFilePicker.FileFilter = MongoDBHelper.XmlFilter;
                exportType = MongoDBHelper.ExportType.XML;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ActionDone += new EventHandler<ActionDoneEventArgs>(
                (x, y) =>
                {
                    MyMessageBox.ShowMessage("Export", y.Message);                    
                }
            );
            MongoDBHelper.ExportToFile(viewinfo, ctlExportFilePicker.SelectedPathOrFileName, exportType);
        }

    }
}
