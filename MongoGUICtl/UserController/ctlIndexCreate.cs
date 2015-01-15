using System;
using System.Windows.Forms;
using MongoUtility.Operation;
using MongoUtility.Basic;
using ResourceLib;

namespace MongoGUICtl
{
    public partial class ctlIndexCreate : UserControl
    {
        /// <summary>
        ///     构造器
        /// </summary>
        public ctlIndexCreate()
        {
            InitializeComponent();
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                lblKeyName.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.ctlIndexCreate_Index);
                radAscendingKey.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Asce);
                radDescendingKey.Text = configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Index_Desc);
            }
            if (MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                foreach (String FieldName in MongoUtility.Basic.Utility.GetCollectionSchame(MongoUtility.Core.RuntimeMongoDBContext.GetCurrentCollection()))
                {
                    cmbKeyName.Items.Add(FieldName);
                }
            }
        }

        public EnumMgr.IndexType IndexKeyType
        {
            get
            {
                if (radAscendingKey.Checked)
                {
                    return EnumMgr.IndexType.Ascending;
                }
                if (radDescendingKey.Checked)
                {
                    return EnumMgr.IndexType.Descending;
                }
                if (radGeoSpatial.Checked)
                {
                    return EnumMgr.IndexType.GeoSpatial;
                }
                if (radText.Checked)
                {
                    return EnumMgr.IndexType.Text;
                }
                return EnumMgr.IndexType.Ascending;
            }
        }

        /// <summary>
        ///     键名称
        /// </summary>
        public String KeyName
        {
            get { return cmbKeyName.Text; }
        }
    }
}