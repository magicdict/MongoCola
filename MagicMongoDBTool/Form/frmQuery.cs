using System;
using System.Collections.Generic;
using System.Drawing;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using System.Windows.Forms;
using QLFUI;
namespace MagicMongoDBTool
{
    public partial class frmQuery : QLFUI.QLFForm
    {
        private MongoCollection _mongoCol = SystemManager.GetCurrentCollection();
        private List<String> ColumnList = new List<String>();

        /// <summary>
        /// 条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;
        /// <summary>
        /// 条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(50, 20);
        public frmQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 输出配置字典
        /// </summary>
        private void frmQuery_Load(object sender, EventArgs e)
        {
            ColumnList = MongoDBHelper.GetCollectionSchame(_mongoCol);

            foreach (String item in ColumnList)
            {
                //输出配置的初始化
                DataFilter.QueryFieldItem queryFieldItem = new DataFilter.QueryFieldItem();
                queryFieldItem.ColName = item;
                queryFieldItem.IsShow = true;
                queryFieldItem.sortType = DataFilter.SortType.NoSort;
                //动态加载控件
                ctlFieldInfo ctrItem = new ctlFieldInfo();
                ctrItem.Name = item;
                ctrItem.Location = _conditionPos;
                ctrItem.QueryFieldItem = queryFieldItem;
                tabFieldInfo.Controls.Add(ctrItem);
                //纵向位置的累加
                _conditionPos.Y += ctrItem.Height;
            }
            _conditionPos = new Point(5, 20);
            ctlQueryCondition firstQueryCtl = new ctlQueryCondition();
            firstQueryCtl.Init(ColumnList);
            firstQueryCtl.Location = _conditionPos;
            firstQueryCtl.Name = "Condition" + _conditionCount.ToString();
            panFilter.Controls.Add(firstQueryCtl);

            if (!SystemManager.IsUseDefaultLanguage())
            {
                tabFieldInfo.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Query_FieldInfo);
                tabFilter.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Query_Filter);
                cmdAddCondition.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Query_Filter_AddCondition);
                cmdLoad.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Query_Action_Load);
                cmdSave.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_Save);
                cmdOK.Text = SystemManager.mStringResource.GetText(GUIResource.StringResource.TextType.Common_OK);
            }

        }
        /// <summary>
        /// 新增条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCondition_Click(object sender, EventArgs e)
        {
            _conditionCount++;
            ctlQueryCondition newCondition = new ctlQueryCondition();
            newCondition.Init(ColumnList);
            _conditionPos.Y += newCondition.Height;
            newCondition.Location = _conditionPos;
            newCondition.Name = "Condition" + _conditionCount.ToString();
            panFilter.Controls.Add(newCondition);
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            // 设置DataFilter
            SetCurrDataFilter();
            //启用过滤器
            MongoDBHelper.IsUseFilter = true;
            this.Close();
        }
        /// <summary>
        /// 设置DataFilter
        /// </summary>
        private void SetCurrDataFilter()
        {
            //清除以前的结果和内部变量，重要！
            SystemManager.CurrDataFilter.Clear();
            SystemManager.CurrDataFilter.DBName = SystemManager.GetCurrentDataBase().Name;
            SystemManager.CurrDataFilter.CollectionName = SystemManager.GetCurrentCollection().Name;

            foreach (var item in ColumnList)
            {
                SystemManager.CurrDataFilter.QueryFieldList.Add(((ctlFieldInfo)Controls.Find(item, true)[0]).QueryFieldItem);
            }
            for (int i = 0; i < _conditionCount; i++)
            {
                ctlQueryCondition ctl = (ctlQueryCondition)Controls.Find("Condition" + (i + 1).ToString(), true)[0];
                if (ctl.IsSeted)
                {
                    SystemManager.CurrDataFilter.QueryConditionList.Add(ctl.ConditionItem);
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // 设置DataFilter
                SetCurrDataFilter();
                DataFilter NewDataFilter = SystemManager.CurrDataFilter;
                NewDataFilter.SaveFilter(savefile.FileName);
            }
        }
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String strErrMsg = String.Empty;
                List<String> ShowColumnList = new List<String>();
                foreach (String item in ColumnList)
                {
                    ShowColumnList.Add(item);
                }

                DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
                SystemManager.CurrDataFilter = NewDataFilter;
                //清除所有的控件
                tabFieldInfo.Controls.Clear();
                foreach (DataFilter.QueryFieldItem queryFieldItem in NewDataFilter.QueryFieldList)
                {
                    //动态加载控件
                    if (!ColumnList.Contains(queryFieldItem.ColName))
                    {
                        strErrMsg += queryFieldItem.ColName + "显示设置字段已经在当前数据集中不存在了" + "\r\n";
                    }
                    else {
                        ctlFieldInfo ctrItem = new ctlFieldInfo();
                        ctrItem.Name = queryFieldItem.ColName;
                        ctrItem.Location = _conditionPos;
                        ctrItem.QueryFieldItem = queryFieldItem;
                        tabFieldInfo.Controls.Add(ctrItem);
                        //纵向位置的累加
                        _conditionPos.Y += ctrItem.Height;
                        ShowColumnList.Remove(queryFieldItem.ColName);
                    }
                }
                //新增字段
                foreach (String item in ShowColumnList)
                {
                    strErrMsg += "新增加" + item + "显示设置字段" + "\r\n";
                    //输出配置的初始化
                    DataFilter.QueryFieldItem queryFieldItem = new DataFilter.QueryFieldItem();
                    queryFieldItem.ColName = item;
                    queryFieldItem.IsShow = true;
                    queryFieldItem.sortType = DataFilter.SortType.NoSort;
                    //动态加载控件
                    ctlFieldInfo ctrItem = new ctlFieldInfo();
                    ctrItem.Name = item;
                    ctrItem.Location = _conditionPos;
                    ctrItem.QueryFieldItem = queryFieldItem;
                    tabFieldInfo.Controls.Add(ctrItem);
                    //纵向位置的累加
                    _conditionPos.Y += ctrItem.Height;
                }
                
                panFilter.Controls.Clear();
                _conditionPos = new Point(5, 20);
                _conditionCount = 0;
                foreach (DataFilter.QueryConditionInputItem queryConditionItem in NewDataFilter.QueryConditionList)
                {
                    ctlQueryCondition newCondition = new ctlQueryCondition();
                    newCondition.Init(ColumnList);
                    newCondition.Location = _conditionPos;
                    newCondition.ConditionItem = queryConditionItem;
                    _conditionCount++;
                    newCondition.Name = "Condition" + _conditionCount.ToString();
                    panFilter.Controls.Add(newCondition);
                    _conditionPos.Y += newCondition.Height;
                    if (!ColumnList.Contains(queryConditionItem.ColName))
                    {
                        strErrMsg += queryConditionItem.ColName + "条件查询字段已经在当前数据集中不存在了" + "\r\n";
                    }
                }

                if (strErrMsg != String.Empty) {
                    MyMessageBox.ShowMessage("加载错误", "加载检索设置时发生错误", strErrMsg, true);
                }
            }
        }
    }
}
