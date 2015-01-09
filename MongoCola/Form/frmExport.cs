using System;
using System.Windows.Forms;
using Common;
using MongoCola.Module;
using MongoUtility.Basic;


namespace MongoCola
{
	public partial class frmExport : Form
	{
		private readonly MongoUtility.Aggregation.DataViewInfo _viewinfo;
		private EnumMgr.ExportType _exportType;

		public frmExport(MongoUtility.Aggregation.DataViewInfo info)
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
			ctlExportFilePicker.FileFilter = Common.Utility.ExcelFilter;
			_exportType = EnumMgr.ExportType.Excel;
			ctlExportFilePicker.FileName = MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection().Name;
			optExcel.CheckedChanged += optExportType_CheckedChanged;
			optText.CheckedChanged += optExportType_CheckedChanged;
			optXML.CheckedChanged += optExportType_CheckedChanged;
			if (SystemManager.IsUseDefaultLanguage)
				return;
			btnSave.Text = SystemManager.guiConfig.MStringResource.GetText(StringResource.TextType.Common_Save);
			Text =
                SystemManager.guiConfig.MStringResource.GetText(
				StringResource.TextType.Main_Menu_Operation_DataCollection_ExportToFile);
		}

		/// <summary>
		///     导出类型更改
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void optExportType_CheckedChanged(object sender, EventArgs e)
		{
			if (optExcel.Checked) {
				ctlExportFilePicker.FileFilter = Common.Utility.ExcelFilter;
				_exportType = EnumMgr.ExportType.Excel;
			}
			if (optText.Checked) {
				ctlExportFilePicker.FileFilter = Common.Utility.TxtFilter;
				_exportType = EnumMgr.ExportType.Text;
			}
			if (!optXML.Checked)
				return;
			ctlExportFilePicker.FileFilter = Common.Utility.XmlFilter;
			_exportType = EnumMgr.ExportType.Xml;
		}

		/// <summary>
		///     保存
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, EventArgs e)
		{
			MongoUtility.Basic.Utility.ActionDone += (x, y) => MyMessageBox.ShowMessage("Export", y.Message);
			MongoDbHelper.ExportToFile(_viewinfo, ctlExportFilePicker.SelectedPathOrFileName, _exportType, MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection());
		}
	}
}