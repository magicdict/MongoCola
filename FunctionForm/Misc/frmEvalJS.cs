using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoDB.Bson;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Method;
using ResourceLib.UI;

namespace FunctionForm
{
    public partial class FrmEvalJs : Form
    {
        public FrmEvalJs()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmevalJS_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                Text = GuiConfig.GetText(TextType.EvalJsTitle);
                ctlEval.Title = GuiConfig.GetText(TextType.EvalJsMethod);
                lblParm.Text = GuiConfig.GetText(TextType.EvalJsParameter);
                cmdEval.Text = GuiConfig.GetText(TextType.EvalJsRun);
            }
            ctlEval.Context = "function eval(){" + Environment.NewLine;
            ctlEval.Context += "    var i = 0;" + Environment.NewLine;
            ctlEval.Context += "    i++;" + Environment.NewLine;
            ctlEval.Context += "    return i;" + Environment.NewLine;
            ctlEval.Context += "}" + Environment.NewLine;
        }

        /// <summary>
        ///     eval Javascript
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEval_Click(object sender, EventArgs e)
        {
            var mongoDb = RuntimeMongoDbContext.GetCurrentDataBase();
            var js = new BsonJavaScript(ctlEval.Context);
            var Params = new List<Object>();
            if (txtParm.Text != string.Empty)
            {
                foreach (var parm in txtParm.Text.Split(",".ToCharArray()))
                {
                    if (parm.StartsWith("'") & parm.EndsWith("'"))
                    {
                        Params.Add(parm.Trim("'".ToCharArray()));
                    }
                    else
                    {
                        try
                        {
                            var isNuberic = true;
                            for (var i = 0; i < parm.Length; i++)
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
                            Utility.ExceptionDeal(ex, "Exception", "Parameter Exception");
                        }
                    }
                }
            }
            try
            {
                var result = mongoDb.Eval(js, Params.ToArray());
                MyMessageBox.ShowMessage("Result", "Result",
                    result.ToJson(MongoHelper.JsonWriterSettings), true);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex, "Exception", "Result");
            }
        }
    }
}