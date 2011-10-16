using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
namespace MagicMongoDBTool
{
    public partial class ctlQueryCondition : UserControl
    {
        public ctlQueryCondition()
        {
            InitializeComponent();
        }
        public Boolean IsSeted{
            get { 
                return(cmbCompareOpr.SelectedIndex != -1);
            }
        }
        public MongoDBHelpler.QueryCompareItem CompareItem
        { 
            get{
                if (cmbCompareOpr.SelectedIndex != -1)
                {
                    MongoDBHelpler.QueryCompareItem rtn = new MongoDBHelpler.QueryCompareItem();
                    rtn.comp = (MongoDBHelpler.CompareEnum)cmbCompareOpr.SelectedIndex;
                    if (radString.Checked)
                    {
                        rtn.type = BsonType.String;
                    }
                    if (radInt.Checked)
                    {
                        rtn.type = BsonType.Int32;
                    }
                    if (radBoolean.Checked)
                    {
                        rtn.type = BsonType.Boolean;
                    }
                    if (radDate.Checked)
                    {
                        rtn.type = BsonType.DateTime;
                    }
                    rtn.Value = txtValue.Text;
                    return rtn;
                }
                else {
                    return new MongoDBHelpler.QueryCompareItem();
                }
            }
            set{
                radString.Checked = true;
                if (value.type == BsonType.String)
                {
                    radString.Checked = true;
                }
                if (value.type == BsonType.DateTime)
                {
                    radDate.Checked = true;
                }
                if (value.type == BsonType.Int32)
                {
                    radInt.Checked = true;
                }
                if (value.type == BsonType.Boolean)
                {
                    radBoolean.Checked = true;
                }
                txtValue.Text = value.Value.ToString();
                cmbCompareOpr.SelectedIndex = (int)value.comp;
            }
        }
        public void clear() {
            txtValue.Text = "";
            cmbCompareOpr.SelectedIndex = -1;
            cmbCompareOpr.Text = "";
            radString.Checked = true;
        }
        private void ctlQueryCondition_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetNames(typeof(MongoDBHelpler.CompareEnum)))
            {
                cmbCompareOpr.Items.Add(item);
            }
        }
    }
}
