using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLFUI;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using MongoDB.Bson;
namespace MagicMongoDBTool
{
    public partial class frmevalJS : QLFForm
    {
        public frmevalJS()
        {
            InitializeComponent();
        }

        private void frmevalJS_Load(object sender, EventArgs e)
        {
            if (!SystemManager.IsUseDefaultLanguage())
            {
                lblFunction.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.EvalJS_Method);
                lblParm.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.EvalJS_Parameter);
                cmdEval.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.EvalJS_Run);
                cmdSaveJs.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Save);
            }

            cmbFuncLst.SelectedIndexChanged += new EventHandler(
             (x, y) => { txtevalJs.Text = MongoDBHelper.LoadJavascript(cmbFuncLst.Text); }
            );
        }

        private void cmdSaveMapJs_Click(object sender, EventArgs e)
        {
            if (txtevalJs.Text != string.Empty)
            {
                String strJsName = Microsoft.VisualBasic.Interaction.InputBox("请输入Javascript名称：", "保存Javascript");
                MongoDBHelper.SaveJavascript(strJsName, txtevalJs.Text);
            }
        }

        private void cmdEval_Click(object sender, EventArgs e)
        {
            MongoDatabase mongoDB = SystemManager.GetCurrentDataBase();
            BsonJavaScript js = new BsonJavaScript(txtevalJs.Text);
            List<Object> Params = new List<Object>();
            if (txtParm.Text != String.Empty) {
                foreach (String parm in txtParm.Text.Split(",".ToCharArray())) {
                    if (parm.StartsWith("'") & parm.EndsWith("'"))
                    {
                        Params.Add(parm);
                    }
                    else {
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
                MyMessageBox.ShowMessage("结果", "执行结果", MongoDBHelper.GetBsonElementText("Result",result,0), true);   
            }
            catch (Exception ex)
            {
                 MyMessageBox.ShowMessage("异常","执行异常",ex.ToString(),true);   
            }

        }
    }
}
