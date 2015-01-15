using System;
using System.Windows.Forms;
using SystemUtility;
using Common.UI;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.Extend;
using ResourceLib.Utility;
using Utility = Common.Logic.Utility;

namespace MongoCola
{
    public partial class frmExport : Form
    {
        private readonly DataViewInfo _viewinfo;
        private EnumMgr.ExportType _exportType;

        public frmExport(DataViewInfo info)
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
            ctlExportFilePicker.FileFilter = Utility.ExcelFilter;
            _exportType = EnumMgr.ExportType.Excel;
            ctlExportFilePicker.FileName = RuntimeMongoDBContext.GetCurrentCollection().Name;
            optExcel.CheckedChanged += optExportType_CheckedChanged;
            optText.CheckedChanged += optExportType_CheckedChanged;
            optXML.CheckedChanged += optExportType_CheckedChanged;
            if (SystemConfig.IsUseDefaultLanguage)
                return;
            btnSave.Text = SystemConfig.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
            Text =
                SystemConfig.guiConfig.MStringResource.GetText(
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
            MongoUtility.Basic.Utility.ActionDone += (x, y) => MyMessageBox.ShowMessage("ExportImport", y.Message);
            ExportImport.ExportToFile(_viewinfo, ctlExportFilePicker.SelectedPathOrFileName, _exportType,
                RuntimeMongoDBContext.GetCurrentCollection());
        }
    }
}