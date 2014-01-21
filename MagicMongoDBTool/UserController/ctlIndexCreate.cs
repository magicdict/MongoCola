using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlIndexCreate : UserControl
    {
        /// <summary>
        ///     构造器
        /// </summary>
        public ctlIndexCreate()
        {
            InitializeComponent();
            if (!SystemManager.IsUseDefaultLanguage)
            {
                lblKeyName.Text = SystemManager.mStringResource.GetText(StringResource.TextType.ctlIndexCreate_Index);
                radAscendingKey.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Asce);
                radDescendingKey.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Index_Desc);
            }
            if (SystemManager.GetCurrentCollection() != null)
            {
                foreach (String FieldName in MongoDBHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbKeyName.Items.Add(FieldName);
                }
            }
        }

        public MongoDBHelper.IndexType IndexKeyType
        {
            get
            {
                if (radAscendingKey.Checked)
                {
                    return MongoDBHelper.IndexType.Ascending;
                }
                if (radDescendingKey.Checked)
                {
                    return MongoDBHelper.IndexType.Descending;
                }
                if (radGeoSpatial.Checked)
                {
                    return MongoDBHelper.IndexType.GeoSpatial;
                }
                if (radText.Checked)
                {
                    return MongoDBHelper.IndexType.Text;
                }
                return MongoDBHelper.IndexType.Ascending;
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