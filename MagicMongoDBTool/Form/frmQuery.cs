using System;
using System.Collections.Generic;
using System.Drawing;
using MagicMongoDBTool.Module;
using MongoDB.Driver;
using System.Windows.Forms;


namespace MagicMongoDBTool
{
    public partial class frmQuery : Form
    {
        /// <summary>
        /// 当前数据集
        /// </summary>
        private MongoCollection _mongoCol;
        /// <summary>
        /// 当前数据集的字段列表
        /// </summary>
        private List<String> ColumnList = new List<String>();
        /// <summary>
        /// 条件输入器数量
        /// </summary>
        private byte _conditionCount = 1;
        /// <summary>
        /// 条件输入器位置
        /// </summary>
        private Point _conditionPos = new Point(5, 20);
        /// <summary>
        /// 当前DataViewInfo
        /// </summary>
        MongoDBHelper.DataViewInfo CurrentDataViewInfo;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="mDataViewInfo">Filter也是DataViewInfo的一个属性，所以这里加上参数</param>
        public frmQuery(MongoDBHelper.DataViewInfo mDataViewInfo)
        {
            InitializeComponent();
            CurrentDataViewInfo = mDataViewInfo;
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            _mongoCol = SystemManager.GetCurrentCollection();
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
                if (!CurrentDataViewInfo.IsUseFilter)
                {
                    queryFieldItem.IsShow = true;
                    queryFieldItem.sortType = DataFilter.SortType.NoSort;
                }
                else
                {
                    DataFilter.QueryFieldItem find = CurrentDataViewInfo.mDataFilter.QueryFieldList.Find
                        (
                            (x) => { return x.ColName == item; }
                        );
                    if (find.ColName != String.Empty)
                    {
                        queryFieldItem.IsShow = find.IsShow;
                        queryFieldItem.sortType = find.sortType;
                    }
                }
                if (queryFieldItem.ColName == "_id") {
                    queryFieldItem.IsShow = true;
                }
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

            if (CurrentDataViewInfo.mDataFilter.QueryConditionList.Count > 0)
            {
                PutQueryToUI(CurrentDataViewInfo.mDataFilter);
            }

            if (!SystemManager.IsUseDefaultLanguage())
            {
                this.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Query_Title);
                tabFieldInfo.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Query_FieldInfo);
                tabCondition.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Query_Filter);
                cmdAddCondition.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Query_Filter_AddCondition);
                cmdLoad.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Query_Action_Load);
                cmdSave.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_Save);
                cmdOK.Text = SystemManager.mStringResource.GetText(MagicMongoDBTool.Module.StringResource.TextType.Common_OK);
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
            ///按下OK，不论是否做更改都认为True
            CurrentDataViewInfo.IsUseFilter = true;
            //启用过滤器
            //MongoDBHelper.IsUseFilter = true;
            this.Close();
        }
        /// <summary>
        /// 设置DataFilter
        /// </summary>
        private void SetCurrDataFilter()
        {
            //清除以前的结果和内部变量，重要！
            CurrentDataViewInfo.mDataFilter.Clear();
            CurrentDataViewInfo.mDataFilter.DBName = SystemManager.GetCurrentDataBase().Name;
            CurrentDataViewInfo.mDataFilter.CollectionName = SystemManager.GetCurrentCollection().Name;

            foreach (var item in ColumnList)
            {
                CurrentDataViewInfo.mDataFilter.QueryFieldList.Add(((ctlFieldInfo)Controls.Find(item, true)[0]).QueryFieldItem);
            }
            for (int i = 0; i < _conditionCount; i++)
            {
                ctlQueryCondition ctl = (ctlQueryCondition)Controls.Find("Condition" + (i + 1).ToString(), true)[0];
                if (ctl.IsSeted)
                {
                    CurrentDataViewInfo.mDataFilter.QueryConditionList.Add(ctl.ConditionItem);
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
            savefile.Filter = MongoDBHelper.XmlFilter;
            if (savefile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // 设置DataFilter
                SetCurrDataFilter();
                CurrentDataViewInfo.mDataFilter.SaveFilter(savefile.FileName);
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
            openFile.Filter = MongoDBHelper.XmlFilter;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
                CurrentDataViewInfo.mDataFilter = NewDataFilter;
            }
        }
        private void PutQueryToUI(DataFilter NewDataFilter)
        {
            String strErrMsg = String.Empty;
            List<String> ShowColumnList = new List<String>();
            foreach (String item in ColumnList)
            {
                ShowColumnList.Add(item);
            }
            //清除所有的控件
            tabFieldInfo.Controls.Clear();
            foreach (DataFilter.QueryFieldItem queryFieldItem in NewDataFilter.QueryFieldList)
            {
                //动态加载控件
                if (!ColumnList.Contains(queryFieldItem.ColName))
                {
                    strErrMsg += queryFieldItem.ColName + "Display Field is not exist in current collection any more" + System.Environment.NewLine;
                }
                else
                {
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
            _conditionPos = new Point(5, 0);
            foreach (String item in ShowColumnList)
            {
                strErrMsg += "New Field" + item + "Is Append" + System.Environment.NewLine;
                //输出配置的初始化
                DataFilter.QueryFieldItem queryFieldItem = new DataFilter.QueryFieldItem();
                queryFieldItem.ColName = item;
                queryFieldItem.IsShow = true;
                queryFieldItem.sortType = DataFilter.SortType.NoSort;
                //动态加载控件
                ctlFieldInfo ctrItem = new ctlFieldInfo();
                ctrItem.Name = item;
                _conditionPos.Y += ctrItem.Height;
                ctrItem.Location = _conditionPos;
                ctrItem.QueryFieldItem = queryFieldItem;
                tabFieldInfo.Controls.Add(ctrItem);
            }

            panFilter.Controls.Clear();
            _conditionPos = new Point(5, 0);
            _conditionCount = 0;
            foreach (DataFilter.QueryConditionInputItem queryConditionItem in NewDataFilter.QueryConditionList)
            {
                ctlQueryCondition newCondition = new ctlQueryCondition();
                newCondition.Init(ColumnList);
                _conditionPos.Y += newCondition.Height;
                newCondition.Location = _conditionPos;
                newCondition.ConditionItem = queryConditionItem;
                _conditionCount++;
                newCondition.Name = "Condition" + _conditionCount.ToString();
                panFilter.Controls.Add(newCondition);

                if (!ColumnList.Contains(queryConditionItem.ColName))
                {
                    strErrMsg += queryConditionItem.ColName + "Query Condition Field is not exist in collection any more" + System.Environment.NewLine;
                }
            }

            if (strErrMsg != String.Empty)
            {
                MyMessageBox.ShowMessage("Load Exception", "A Exception is happened when loading", strErrMsg, true);
            }


        }
        /// <summary>
        /// 直接关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
