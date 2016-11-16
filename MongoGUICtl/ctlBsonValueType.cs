using MongoDB.Bson;
using MongoUtility.Basic;
using System.Windows.Forms;

namespace MongoGUICtl
{
    public partial class ctlBsonValueType : UserControl
    {
        /// <summary>
        ///     初始化，请确保 getArray 和 getDocument正确设定
        /// </summary>
        public ctlBsonValueType()
        {
            InitializeComponent();
        }
        private void ctlBsonValue1_Load(object sender, System.EventArgs e)
        {
            //BsonValue基本属性
            Common.UIAssistant.FillComberWithEnum(cmbDataType, typeof(BsonValueEx.BasicType), true);
            //类型变动委托
            cmbDataType.SelectedIndexChanged += (x, y) => { ctlBsonValue1.DataTypeChanged((BsonValueEx.BasicType)cmbDataType.SelectedIndex); };
        }
        public void SetValue(BsonValue value)
        {
            ctlBsonValue1.SetValue(value);
        }
        public BsonValue GetValue()
        {
            return ctlBsonValue1.GetValue((BsonValueEx.BasicType)cmbDataType.SelectedIndex);
        }
    }
}