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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmevalJS_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Title);
                lblFunction.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Method);
                lblParm.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Parameter);
                cmdEval.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.EvalJS_Run);
                cmdSaveJs.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save);
            }
            cmbFuncLst.SelectedIndexChanged += new EventHandler(
             (x, y) => { txtevalJs.Text = MongoDBHelper.LoadJavascript(cmbFuncLst.Text); }
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveMapJs_Click(object sender, EventArgs e)
        {
            if (txtevalJs.Text != string.Empty)
            {
                String strJsName = MyMessageBox.ShowInput("请输入Javascript名称：", "保存Javascript");
                MongoDBHelper.SaveJavascript(strJsName, txtevalJs.Text);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEval_Click(object sender, EventArgs e)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            BsonJavaScript js = new BsonJavaScript(txtevalJs.Text);
            List<Object> Params = new List<Object>();
            if (txtParm.Text != String.Empty)
            {
                foreach (String parm in txtParm.Text.Split(",".ToCharArray()))
                {
                    if (parm.StartsWith("'") & parm.EndsWith("'"))
                    {
                        Params.Add(parm);
                    }
                    else
                    {
                        //TODO：检查数字型
                        try
                        {
                            Params.Add(Convert.ToInt16(parm));
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.ShowMessage("异常", "参数异常", ex.ToString(), true);
                        }
                    }
                }
            }
            try
            {
                BsonValue result = mongoDB.Eval(js, Params.ToArray());
                MyMessageBox.ShowMessage("结果", "执行结果", MongoDBHelper.GetBsonElementText("Result", result, 0), true);
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowMessage("异常", "执行异常", ex.ToString(), true);
            }

        }
    }
}
