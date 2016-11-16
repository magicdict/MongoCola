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
                foreach (var fieldName in MongoHelper.GetCollectionSchame(RuntimeMongoDbContext.GetCurrentCollection()))
                {
                    cmbKeyName.Items.Add(fieldName);
                }
            }
            Common.UIAssistant.FillComberWithEnum(cmbIndexKeyType, typeof(EnumMgr.IndexType), true);
        }

        public EnumMgr.IndexType IndexKeyType
        {
            get
            {
                return (EnumMgr.IndexType)cmbIndexKeyType.SelectedIndex;
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