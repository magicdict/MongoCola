using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Basic;

namespace MongoGUICtl
{
    public partial class CtlBsonValue : UserControl
    {
        /// <summary>
        ///     数组
        /// </summary>
        private BsonArray _mBsonArray = new BsonArray();
        /// <summary>
        ///     获得一个新BsonArray的委托
        /// </summary>
        public static Func<BsonArray> GetArray;

        /// <summary>
        ///     文档
        /// </summary>
        private BsonDocument _mBsonDocument = new BsonDocument();
        /// <summary>
        ///     获得一个新BsonDocument的委托
        /// </summary>
        public static Func<BsonDocument> GetDocument;

        /// <summary>
        ///     初始化，请确保 getArray 和 getDocument正确设定
        /// </summary>
        public CtlBsonValue()
        {
            InitializeComponent();

            dateTimePicker.Location = txtBsonValue.Location;
            dateTimePicker.Size = txtBsonValue.Size;
            radTrue.Location = txtBsonValue.Location;
            radFalse.Top = txtBsonValue.Top;
            NumberPick.Location = txtBsonValue.Location;
            NumberPick.Size = txtBsonValue.Size;
            NumberPick.Minimum = int.MinValue;
            NumberPick.Maximum = int.MaxValue;

            txtBsonValue.Visible = true;
            txtBsonValue.Text = string.Empty;
            radTrue.Visible = false;
            radFalse.Visible = false;
            radFalse.Checked = true;
            dateTimePicker.Visible = false;
            NumberPick.Visible = false;

            foreach (var item in BsonValueEx.GetBasicTypeList())
            {
                cmbDataType.Items.Add(item);
            }
        }

        /// <summary>
        ///     使用属性会发生一些MONO上的移植问题
        /// </summary>
        /// <returns></returns>
        public BsonValue GetValue()
        {
            BsonValue mValue = null;
            switch (cmbDataType.SelectedIndex)
            {
                case (int)BsonValueEx.BasicType.BsonString:
                    mValue = new BsonString(txtBsonValue.Text);
                    break;
                case (int)BsonValueEx.BasicType.BsonInt32:
                    mValue = new BsonInt32(Convert.ToInt32(NumberPick.Value));
                    break;
                case (int)BsonValueEx.BasicType.BsonInt64:
                    mValue = new BsonInt64(Convert.ToInt64(NumberPick.Value));
                    break;
                case (int)BsonValueEx.BasicType.BsonDecimal128:
                    mValue = new BsonDecimal128(Convert.ToDecimal(NumberPick.Value));
                    break;
                case (int)BsonValueEx.BasicType.BsonDateTime:
                    mValue = new BsonDateTime(dateTimePicker.Value);
                    break;
                case (int)BsonValueEx.BasicType.BsonBoolean:
                    mValue = radTrue.Checked ? BsonBoolean.True : BsonBoolean.False;
                    break;
                case (int)BsonValueEx.BasicType.BsonArray:
                    mValue = _mBsonArray;
                    break;
                case (int)BsonValueEx.BasicType.BsonDocument:
                    mValue = _mBsonDocument;
                    break;
            }
            return mValue;
        }

        /// <summary>
        ///     使用属性会发生一些MONO上的移植问题
        /// </summary>
        /// <returns></returns>
        public void SetValue(BsonValue value)
        {
            txtBsonValue.Visible = false;
            txtBsonValue.Text = string.Empty;
            txtBsonValue.ReadOnly = false;
            radTrue.Visible = false;
            radFalse.Visible = false;
            radFalse.Checked = true;
            dateTimePicker.Visible = false;
            NumberPick.Visible = false;
            if (value.IsString)
            {
                cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonString;
                txtBsonValue.Visible = true;
                txtBsonValue.Text = value.ToString();
            }
            if (value.IsInt32)
            {
                cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonInt32;
                NumberPick.Visible = true;
                NumberPick.Value = value.AsInt32;
            }
            if (value.IsInt64)
            {
                cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonInt64;
                NumberPick.Visible = true;
                NumberPick.Value = value.AsInt64;
            }
            if (value.IsDecimal128)
            {
                cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonDecimal128;
                NumberPick.Visible = true;
                NumberPick.Value = value.AsDecimal;
            }
            if (value.IsValidDateTime)
            {
                dateTimePicker.Visible = true;
                dateTimePicker.Value = value.ToUniversalTime();
                cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonDateTime;
            }
            if (value.IsBoolean)
            {
                radTrue.Visible = true;
                radFalse.Visible = true;
                if (value.AsBoolean)
                {
                    radTrue.Checked = true;
                }
                else
                {
                    radFalse.Checked = true;
                }
                cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonBoolean;
            }
            if (value.IsBsonArray)
            {
                if (GetArray == null)
                {
                    MessageBox.Show("GetArray委托不存在！");
                    return;
                }
                var t = GetArray();
                if (t != null)
                {
                    _mBsonArray = t;
                    txtBsonValue.Visible = true;
                    txtBsonValue.Text = _mBsonArray.ToString();
                    txtBsonValue.ReadOnly = true;
                    cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonArray;
                }
            }
            if (value.IsBsonDocument)
            {
                if (GetDocument == null)
                {
                    MessageBox.Show("GetDocument委托不存在！");
                    return;
                }
                var t = GetDocument();
                if (t != null)
                {
                    _mBsonDocument = t;
                    txtBsonValue.Visible = true;
                    txtBsonValue.Text = _mBsonDocument.ToString();
                    txtBsonValue.ReadOnly = true;
                    cmbDataType.SelectedIndex = (int)BsonValueEx.BasicType.BsonDocument;
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBsonValue.Visible = false;
            radTrue.Visible = false;
            radFalse.Visible = false;
            switch (cmbDataType.SelectedIndex)
            {
                case (int)BsonValueEx.BasicType.BsonString:
                    SetValue(new BsonString(string.Empty));
                    break;
                case (int)BsonValueEx.BasicType.BsonInt32:
                    SetValue(new BsonInt32(0));
                    break;
                case (int)BsonValueEx.BasicType.BsonInt64:
                    SetValue(new BsonInt64(0));
                    break;
                case (int)BsonValueEx.BasicType.BsonDecimal128:
                    SetValue(new BsonDecimal128(0));
                    break;
                case (int)BsonValueEx.BasicType.BsonDateTime:
                    SetValue(new BsonDateTime(DateTime.Now));
                    break;
                case (int)BsonValueEx.BasicType.BsonBoolean:
                    SetValue(BsonBoolean.False);
                    break;
                case (int)BsonValueEx.BasicType.BsonArray:
                    SetValue(new BsonArray());
                    break;
                case (int)BsonValueEx.BasicType.BsonDocument:
                    SetValue(new BsonDocument());
                    break;
                default:
                    break;
            }
        }
    }
}