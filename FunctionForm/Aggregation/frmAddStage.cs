using Common;
using ICSharpCode.TextEditor.Document;
using MongoDB.Bson;
using MongoGUICtl.ClientTree;
using MongoUtility.Basic;
using ResourceLib.Method;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.Aggregation
{
    public partial class FrmAddStage : Form
    {
        public List<BsonDocument> BsonDocumentList;
        public FrmAddStage()
        {
            InitializeComponent();
        }

        private List<BsonDocument> Parse(String text)
        {
            var list = new List<BsonDocument>();
            //确实很丑陋，但BsonArray没有Parse方法，只能这么干了
            BsonDocument newDoc;
            newDoc = BsonDocument.Parse("{\"value\":" + text + "}");
            BsonElement valueElement = newDoc.GetElement("value");
            if (valueElement.Value.IsBsonArray)
            {
                foreach (BsonDocument item in valueElement.Value.AsBsonArray)
                {
                    list.Add(item);
                }
            }
            else
            {
                list.Add(valueElement.Value.AsBsonDocument);
            }
            return list;
        }

        private void cmdPreview_Click(object sender, EventArgs e)
        {
            try
            {
                var list = Parse(txtDocument.Text);

                trvNewStage.DatatreeView.BeginUpdate();
                UiHelper.FillDataToTreeView("stages", trvNewStage, list, 0);
                trvNewStage.DatatreeView.ExpandAll();
                trvNewStage.DatatreeView.EndUpdate();
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }
        }

        private void frmAddStage_Load(object sender, EventArgs e)
        {
            txtDocument.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(ConstMgr.CSharp);
            GuiConfig.Translateform(this);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.BsonDocumentList = Parse(txtDocument.Text);
                Close();
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex);
            }

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
