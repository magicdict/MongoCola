using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MagicMongoDBTool.Module;

namespace MagicMongoDBTool
{
    public partial class ctlJsEditor : UserControl
    {
        /// <summary>
        /// Js名称
        /// </summary>
        public String JsName { set; get; }
        /// <summary>
        /// 关闭Tab事件
        /// </summary>
        public event EventHandler CloseTab;
        public ctlJsEditor()
        {
            InitializeComponent();
            SaveStripButton.Image = MagicMongoDBTool.Properties.Resources.save.ToBitmap();
        }

        private void JsEditor_Load(object sender, EventArgs e)
        {
            txtJavaScript.Text = MongoDBHelper.LoadJavascript(JsName);
            txtJavaScript.Select(0,0);
        }

        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            if (CloseTab != null)
            {
                CloseTab(sender, e);
            }
        }
    }
}
