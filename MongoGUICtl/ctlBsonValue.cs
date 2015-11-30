using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoUtility.Basic;

namespace MongoGUICtl
{
    public partial class CtlBsonValue : UserControl
    {
        private BsonArray _mBsonArray = new BsonArray();

        private BsonDocument _mBsonDocument = new BsonDocument();

        /// <summary>
        ///     获得一个新BSonArray的委托
        /// </summary>
        public Func<BsonArray> GetArray;

        /// <summary>
        ///     获得一个新BSonDocument的委托
        /// </summary>
        public Func<BsonDocument> GetDocument;

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
                case 0:
                    mValue = new BsonString(txtBsonValue.Text);
                    break;
                case 1:
                    mValue = new BsonInt32(Convert.ToInt32(NumberPick.Value));
                    break;
                case 2:
                    mValue = new BsonDateTime(dateTimePicker.Value);
                    break;
                case 3:
                    mValue = radTrue.Checked ? BsonBoolean.True : BsonBoolean.False;
                    break;
                case 4:
                    mValue = _mBsonArray;
                    break;
                case 5:
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
                cmbDataType.SelectedIndex = 0;
                txtBsonValue.Visible = true;
                txtBsonValue.Text = value.ToString();
            }
            if (value.IsInt32)
            {
                cmbDataType.SelectedIndex = 1;
                NumberPick.Visible = true;
                NumberPick.Value = value.AsInt32;
            }
            if (value.IsValidDateTime)
            {
                dateTimePicker.Visible = true;
                dateTimePicker.Value = value.ToUniversalTime();
                cmbDataType.SelectedIndex = 2;
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
                cmbDataType.SelectedIndex = 3;
            }
            if (value.IsBsonArray)
            {
                var t = GetArray();
                if (t != null)
                {
                    _mBsonArray = t;
                    txtBsonValue.Visible = true;
                    txtBsonValue.Text = _mBsonArray.ToString();
                    txtBsonValue.ReadOnly = true;
                    cmbDataType.SelectedIndex = 4;
                }
            }
            if (value.IsBsonDocument)
            {
                var t = GetDocument();
                if (t != null)
                {
                    _mBsonDocument = t;
                    txtBsonValue.Visible = true;
                    txtBsonValue.Text = _mBsonDocument.ToString();
                    txtBsonValue.ReadOnly = true;
                    cmbDataType.SelectedIndex = 5;
                }
            }
        }

        /// <summary>
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
                case 0:
                    SetValue(new BsonString(string.Empty));
                    break;
                case 1:
                    SetValue(new BsonInt32(0));
                    break;
                case 2:
                    SetValue(new BsonDateTime(DateTime.Now));
                    break;
                case 3:
                    SetValue(BsonBoolean.False);
                    break;
                case 4:
                    SetValue(new BsonArray());
                    break;
                case 5:
                    SetValue(new BsonDocument());
                    break;
                default:
                    break;
            }
        }
    }
}