using Common;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Windows.Forms;

namespace FunctionForm.Extend
{
    public partial class FrmExport : Form
    {
        private readonly DataViewInfo _viewinfo;
        private EnumMgr.ExportType _exportType;

        public FrmExport(DataViewInfo info)
        {
            InitializeComponent();
            _viewinfo = info;
        }

        public FrmExport()
        {
            InitializeComponent();
        }

        private void frmExport_Load(object sender, EventArgs e)
        {
            //Excel文件过滤器
            ctlExportFilePicker.FileFilter = Utility.ExcelFilter;
            _exportType = EnumMgr.ExportType.Excel;
            ctlExportFilePicker.InitFileName = RuntimeMongoDbContext.GetCurrentCollection().Name;
            optExcel.CheckedChanged += optExportType_CheckedChanged;
            optText.CheckedChanged += optExportType_CheckedChanged;
            optXML.CheckedChanged += optExportType_CheckedChanged;
            GuiConfig.Translateform(this);
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
                ctlExportFilePicker.FileFilter = Utility.ExcelFilter;
                _exportType = EnumMgr.ExportType.Excel;
            }
            if (optText.Checked)
            {
                ctlExportFilePicker.FileFilter = Utility.TxtFilter;
                _exportType = EnumMgr.ExportType.Text;
            }
            if (!optXML.Checked)
                return;
            ctlExportFilePicker.FileFilter = Utility.XmlFilter;
            _exportType = EnumMgr.ExportType.Xml;
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            MongoHelper.ActionDone += (x, y) => MyMessageBox.ShowMessage("ExportImport", y.Message);
            ExportImport.ExportToFile(_viewinfo, ctlExportFilePicker.SelectedPathOrFileName, _exportType,
                RuntimeMongoDbContext.GetCurrentCollection());
        }
    }
}