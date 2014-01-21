using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class frmExport : Form
    {
        private readonly MongoDBHelper.DataViewInfo viewinfo;
        private MongoDBHelper.ExportType exportType;

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
            if (SystemManager.IsUseDefaultLanguage) return;
            btnSave.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Save);
            Text =
                SystemManager.mStringResource.GetText(
                    StringResource.TextType.Main_Menu_Operation_DataCollection_ExportToFile);
        }

        /// <summary>
        ///     导出类型更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optExportType_CheckedChanged(object sender, EventArgs e)
        {
            if (optExcel.Checked)
            {
                ctlExportFilePicker.FileFilter = MongoDBHelper.ExcelFilter;
                exportType = MongoDBHelper.ExportType.Excel;
            }
            if (optText.Checked)
            {
                ctlExportFilePicker.FileFilter = MongoDBHelper.TxtFilter;
                exportType = MongoDBHelper.ExportType.Text;
            }
            if (!optXML.Checked) return;
            ctlExportFilePicker.FileFilter = MongoDBHelper.XmlFilter;
            exportType = MongoDBHelper.ExportType.XML;
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            MongoDBHelper.ActionDone += (x, y) => { MyMessageBox.ShowMessage("Export", y.Message); };
            MongoDBHelper.ExportToFile(viewinfo, ctlExportFilePicker.SelectedPathOrFileName, exportType);
        }
    }
}