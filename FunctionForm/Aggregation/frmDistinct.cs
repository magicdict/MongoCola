using MongoDB.Bson;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using ResourceLib.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FunctionForm.Aggregation
{
    public partial class FrmDistinct : Form
    {
        public FrmDistinct()
        {
            InitializeComponent();
        }

        private void frmSelectKey_Load(object sender, EventArgs e)
        {
            var mongoCol = RuntimeMongoDbContext.GetCurrentCollection();
            var mongoColumn = MongoHelper.GetCollectionSchame(mongoCol);
            Common.UIAssistant.FillComberWithArray(cmbFields, mongoColumn.ToArray());
            GuiConfig.Translateform(this);
        }

        /// <summary>
        ///     运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            var strKey = cmbFields.Text;
            if (string.IsNullOrEmpty(strKey))
            {
                MyMessageBox.ShowMessage("Distinct", "Pick the field");
                return;
            }
            var strResult = Distinct(strKey);
            MyMessageBox.ShowMessage("Distinct", "Distinct:" + strKey, strResult, true);
        }
        /// <summary>
        ///     Distinct
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private string Distinct(string strKey)
        {
            var strResult = string.Empty;
            var resultList = RuntimeMongoDbContext.GetCurrentCollection().Distinct(strKey).ToList();
            resultList.Sort();
            //防止错误的条件造成的海量数据
            var count = 0;
            foreach (var item in resultList)
            {
                if (count == 1000)
                {
                    strResult = "Too many result,Display first 1000 records" + Environment.NewLine + strResult;
                    break;
                }
                strResult += item.ToJson(MongoHelper.JsonWriterSettings) + Environment.NewLine;
                count++;
            }
            strResult = "Distinct Count: " + resultList.Count + Environment.NewLine + Environment.NewLine + strResult;
            return strResult;
        }

    }
}