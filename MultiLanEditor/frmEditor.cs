using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ResourceLib.Method;
namespace MultiLanEditor
{
    public partial class frmEditor : Form
    {
        /// <summary>
        /// 多语言字典
        /// 语种 VS 语种字典（单词标示 VS 表示文本）
        /// </summary>
        Dictionary<String, Dictionary<String, string>> MultiLanguageDictionary = new Dictionary<string, Dictionary<string, string>>();

        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //整体表格
            string multilanFolder = ctlMultiLanFolder.SelectedPathOrFileName;
            //整理出最大列表，防止文件之间出现单词表格不同
            List<String> UUIDs = new List<string>();
            UUIDs.Clear();
            if (!string.IsNullOrEmpty(multilanFolder)) {
                //便利整个文件夹，获得语言字典
                foreach (string filename in Directory.GetFiles(multilanFolder))
                {
                    StringResource.InitLanguage(filename);
                    Dictionary<String, string> SingleDic = new Dictionary<string, string>();
                    foreach (var item in StringResource.StringDic)
                    {
                        if (!UUIDs.Contains(item.Key)) UUIDs.Add(item.Key);
                        SingleDic.Add(item.Key,item.Value);
                    }
                    MultiLanguageDictionary.Add(StringResource.LanguageType, SingleDic);
                }
            }
            //将数据放入ListView视图
            lstMultiLan.Clear();
            //Header
            lstMultiLan.Columns.Add("统一标示");
            for (int i = 0; i < MultiLanguageDictionary.Keys.Count; i++)
            {
                lstMultiLan.Columns.Add(MultiLanguageDictionary.Keys.ElementAt(i));
            }
            //Details
            for (int i = 0; i < UUIDs.Count; i++)
            {
                ListViewItem item = new ListViewItem(UUIDs[i]);
                for (int j = 0; j < MultiLanguageDictionary.Keys.Count; j++)
                {

                    if (MultiLanguageDictionary[MultiLanguageDictionary.Keys.ElementAt(j)].ContainsKey(UUIDs[i]))
                    {
                        item.SubItems.Add(MultiLanguageDictionary[MultiLanguageDictionary.Keys.ElementAt(j)][UUIDs[i]]);
                    }
                    else {
                        item.SubItems.Add("");
                    }
                }
                lstMultiLan.Items.Add(item);
            }
            Common.Utility.ListViewColumnResize(lstMultiLan);
        }
    }
}
