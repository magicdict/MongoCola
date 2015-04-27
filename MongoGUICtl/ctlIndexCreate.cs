using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Utility;

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
            GUIConfig.Translateform(Controls);
            if (RuntimeMongoDBContext.GetCurrentCollection() != null)
            {
                foreach (var FieldName in Utility.GetCollectionSchame(RuntimeMongoDBContext.GetCurrentCollection()))
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
        public string KeyName
        {
            get { return cmbKeyName.Text; }
        }
    }
}