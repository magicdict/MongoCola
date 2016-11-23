using Common;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Core;
using MongoUtility.ToolKit;
using ResourceLib.Method;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionForm.Extend
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
            GuiConfig.Translateform(this);
            ctlEval.Title = GuiConfig.GetText("Eval Js", "EvalJS.Method");
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
            var Params = new List<BsonValue>();
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
                var args = new EvalArgs { Args = Params.ToArray(), Code = js };
                var result = mongoDb.Eval(args);
                txtResult.Text = result.ToJson(MongoHelper.JsonWriterSettings);
            }
            catch (Exception ex)
            {
                Utility.ExceptionDeal(ex, "Exception", "Result");
            }
        }
    }
}