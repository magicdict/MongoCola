using System;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool
{
    public partial class ctlBsonValue : UserControl
    {
        BsonDocument mBsonDocument = new BsonDocument();
        /// <summary>
        /// 使用属性会发生一些MONO上的移植问题
        /// </summary>
        /// <returns></returns>
        public BsonValue getValue()
        {
            BsonValue mValue = new BsonString(String.Empty);
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
                    if (radTrue.Checked)
                    {
                        mValue = BsonBoolean.True;
                    }
                    else
                    {
                        mValue = BsonBoolean.False;
                    }
                    break;
                case 4:
                    mValue = new BsonArray();
                    break;
                case 5:
                    mValue = mBsonDocument;
                    break;
            }
            return mValue;
        }
        /// <summary>
        /// 使用属性会发生一些MONO上的移植问题
        /// </summary>
        /// <returns></returns>
        public void setValue(BsonValue value)
        {
            txtBsonValue.Visible = false;
            txtBsonValue.Text = String.Empty;
            txtBsonValue.ReadOnly = true;
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
            if (value.IsDateTime)
            {
                dateTimePicker.Visible = true;
                dateTimePicker.Value = value.AsDateTime;
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
                cmbDataType.SelectedIndex = 4;
            }
            if (value.IsBsonDocument)
            {
                frmNewDocument frmInsertDoc = new frmNewDocument();
                SystemManager.OpenForm(frmInsertDoc, false, true);
                mBsonDocument = frmInsertDoc.mBsonDocument;
                txtBsonValue.Visible = true;
                txtBsonValue.Text = mBsonDocument.ToString();
                txtBsonValue.ReadOnly = false;
                cmbDataType.SelectedIndex = 5;
            }
        }

        public ctlBsonValue()
        {
            InitializeComponent();
            dateTimePicker.Location = txtBsonValue.Location;
            dateTimePicker.Size = txtBsonValue.Size;

            radTrue.Location = txtBsonValue.Location;
            radFalse.Top = txtBsonValue.Top;
            NumberPick.Location = txtBsonValue.Location;
            NumberPick.Size = txtBsonValue.Size;
            NumberPick.Minimum = Int32.MinValue;
            NumberPick.Maximum = Int32.MaxValue;

            txtBsonValue.Visible = true;
            txtBsonValue.Text = String.Empty;
            radTrue.Visible = false;
            radFalse.Visible = false;
            radFalse.Checked = true;
            dateTimePicker.Visible = false;
            NumberPick.Visible = false;

            foreach (String item in BsonValueEx.GetBasicTypeList())
            {
                cmbDataType.Items.Add(item);
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
                case 0:
                    setValue(new BsonString(String.Empty));
                    break;
                case 1:
                    setValue(new BsonInt32(0));
                    break;
                case 2:
                    setValue(new BsonDateTime(DateTime.Now));
                    break;
                case 3:
                    setValue(BsonBoolean.False);
                    break;
                case 4:
                    setValue(new BsonArray());
                    break;
                case 5:
                    setValue(new BsonDocument());
                    break;
                default:
                    break;
            }
        }
    }
}
