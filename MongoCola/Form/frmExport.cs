using System;
using System.Windows.Forms;
using MongoCola.Module;

namespace MongoCola
{
    public partial class frmExport : Form
    {
        private readonly MongoDbHelper.DataViewInfo _viewinfo;
        private MongoDbHelper.ExportType _exportType;

        public frmExport(MongoDbHelper.DataViewInfo info)
        {
            InitializeComponent();
            _viewinfo = info;
        }

        public frmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            //Excel文件过滤器
            ctlExportFilePicker.FileFilter = MongoDbHelper.ExcelFilter;
            _exportType = MongoDbHelper.ExportType.Excel;
            ctlExportFilePicker.FileName = SystemManager.GetCurrentCollection().Name;
            optExcel.CheckedChanged += optExportType_CheckedChanged;
            optText.CheckedChanged += optExportType_CheckedChanged;
            optXML.CheckedChanged += optExportType_CheckedChanged;
            if (SystemManager.IsUseDefaultLanguage) return;
            btnSave.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Save);
            Text =
                SystemManager.MStringResource.GetText(
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
                ctlExportFilePicker.FileFilter = MongoDbHelper.ExcelFilter;
                _exportType = MongoDbHelper.ExportType.Excel;
            }
            if (optText.Checked)
            {
                ctlExportFilePicker.FileFilter = MongoDbHelper.TxtFilter;
                _exportType = MongoDbHelper.ExportType.Text;
            }
            if (!optXML.Checked) return;
            ctlExportFilePicker.FileFilter = MongoDbHelper.XmlFilter;
            _exportType = MongoDbHelper.ExportType.Xml;
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            MongoDbHelper.ActionDone += (x, y) => MyMessageBox.ShowMessage("Export", y.Message);
            MongoDbHelper.ExportToFile(_viewinfo, ctlExportFilePicker.SelectedPathOrFileName, _exportType);
        }
    }
}