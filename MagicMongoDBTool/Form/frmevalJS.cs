using System;
using System.Collections.Generic;
using MagicMongoDBTool.Module;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MagicMongoDBTool
{
    public partial class frmevalJS : System.Windows.Forms.Form
    {
        public frmevalJS()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmevalJS_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage)
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Title);
                ctlEval.Title = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Method);
                lblParm.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Parameter);
                cmdEval.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Run);
            }
            ctlEval.Context =
@"function eval(){
var i = 0;
i++;
return i;
}";
        }
        /// <summary>
        /// eval Javascript
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEval_Click(object sender, EventArgs e)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            BsonJavaScript js = new BsonJavaScript(ctlEval.Context);
            List<Object> Params = new List<Object>();
            if (txtParm.Text != String.Empty)
            {
                foreach (String parm in txtParm.Text.Split(",".ToCharArray()))
                {
                    if (parm.StartsWith("'") & parm.EndsWith("'"))
                    {
                        Params.Add(parm.Trim("'".ToCharArray()));
                    }
                    else
                    {
                        try
                        {
                            Boolean isNuberic = true;
                            for (int i = 0; i < parm.Length; i++)
                            {
                                if (!char.IsNumber(parm, i))
                                {
                                    isNuberic = false;
                                }
                            }
                            if (isNuberic)
                            {
                                Params.Add(Convert.ToInt16(parm));
                            }
                        }
                        catch (Exception ex)
                        {
                            SystemManager.ExceptionDeal(ex, "Exception", "Parameter Exception");
                        }
                    }
                }
            }
            try
            {
                BsonValue result = mongoDB.Eval(js, Params.ToArray());
                MyMessageBox.ShowMessage("Result", "Result", result.ToJson(SystemManager.JsonWriterSettings), true);
            }
            catch (Exception ex)
            {
                SystemManager.ExceptionDeal(ex, "Exception", "Result");
            }

        }
    }
}
