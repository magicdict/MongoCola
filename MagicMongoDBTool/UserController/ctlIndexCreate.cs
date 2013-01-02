using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlIndexCreate : UserControl
    {
        public MagicMongoDBTool.Module.DataFilter.SortType SortKeyType
        {
            get
            {
                if (this.radAscendingKey.Checked) { return DataFilter.SortType.Ascending; }
                if (this.radDescendingKey.Checked) { return DataFilter.SortType.Descending; }
                if (this.radGeoSpatial.Checked) { return DataFilter.SortType.GeoSpatial; }
                return DataFilter.SortType.NoSort;
            }
        }
        /// <summary>
        /// 键名称
        /// </summary>
        public String KeyName
        {
            get { return cmbKeyName.Text; }
        }
        public ctlIndexCreate()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.lblKeyName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.ctlIndexCreate_Index);
                this.radAscendingKey.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Asce);
                this.radDescendingKey.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Desc);
            }
            if (SystemManager.GetCurrentCollection() != null)
            {
                foreach (String FieldName in MongoDBHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbKeyName.Items.Add(FieldName);
                }
            }
        }
    }
}
