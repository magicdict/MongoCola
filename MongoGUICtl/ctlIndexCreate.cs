using System.Windows.Forms;
using MongoUtility.Basic;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;

namespace MongoGUICtl
{
    public partial class CtlIndexCreate : UserControl
    {
        /// <summary>
        ///     构造器
        /// </summary>
        public CtlIndexCreate()
        {
            InitializeComponent();
            GuiConfig.Translateform(Controls);
            if (RuntimeMongoDbContext.GetCurrentCollection() != null)
            {
                foreach (
                    var fieldName in
                        MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection())
                    )
                {
                    cmbKeyName.Items.Add(fieldName);
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