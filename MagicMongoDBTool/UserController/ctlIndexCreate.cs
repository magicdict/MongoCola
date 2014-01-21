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
                lblKeyName.Text = SystemManager.MStringResource.GetText(StringResource.TextType.ctlIndexCreate_Index);
                radAscendingKey.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Index_Asce);
                radDescendingKey.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Index_Desc);
            }
            if (SystemManager.GetCurrentCollection() != null)
            {
                foreach (String FieldName in MongoDbHelper.GetCollectionSchame(SystemManager.GetCurrentCollection()))
                {
                    cmbKeyName.Items.Add(FieldName);
                }
            }
        }

        public MongoDbHelper.IndexType IndexKeyType
        {
            get
            {
                if (radAscendingKey.Checked)
                {
                    return MongoDbHelper.IndexType.Ascending;
                }
                if (radDescendingKey.Checked)
                {
                    return MongoDbHelper.IndexType.Descending;
                }
                if (radGeoSpatial.Checked)
                {
                    return MongoDbHelper.IndexType.GeoSpatial;
                }
                if (radText.Checked)
                {
                    return MongoDbHelper.IndexType.Text;
                }
                return MongoDbHelper.IndexType.Ascending;
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