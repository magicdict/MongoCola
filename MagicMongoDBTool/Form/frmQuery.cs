using Common.Aggregation;
using MagicMongoDBTool.Module;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MagicMongoDBTool
{
    public partial class frmQuery : Form
    {
        /// <summary>
        ///     当前DataViewInfo
        /// </summary>
        private readonly MongoDbHelper.DataViewInfo CurrentDataViewInfo;

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="mDataViewInfo">Filter也是DataViewInfo的一个属性，所以这里加上参数</param>
        public frmQuery(MongoDbHelper.DataViewInfo mDataViewInfo)
        {
            InitializeComponent();
            CurrentDataViewInfo = mDataViewInfo;
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
        }

        /// <summary>
        ///     输出配置字典
        /// </summary>
        private void frmQuery_Load(object sender, EventArgs e)
        {
            Icon = GetSystemIcon.ConvertImgToIcon(GetResource.GetImage(ImageType.Query));
            var FieldList = new List<DataFilter.QueryFieldItem>();
            FieldList = CurrentDataViewInfo.mDataFilter.QueryFieldList;
            //增加第一个条件
            ConditionPan.AddCondition();
            if (CurrentDataViewInfo.IsUseFilter)
            {
                //使用过滤：字段和条件的设定
                QueryFieldPicker.setQueryFieldList(FieldList);
                if (CurrentDataViewInfo.mDataFilter.QueryConditionList.Count > 0)
                {
                    ConditionPan.PutQueryToUI(CurrentDataViewInfo.mDataFilter);
                }
            }
            else
            {
                //不使用过滤：字段初始化
                QueryFieldPicker.InitByCurrentCollection(true);
            }
            if (SystemManager.IsUseDefaultLanguage) return;
            Text = SystemManager.MStringResource.GetText(StringResource.TextType.Query_Title);
            tabFieldInfo.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Query_FieldInfo);
            tabCondition.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Query_Filter);
            tabSql.Text = SystemManager.MStringResource.GetText(StringResource.TextType.ConvertSql_Title);
            cmdAddCondition.Text =
                SystemManager.MStringResource.GetText(StringResource.TextType.Query_Filter_AddCondition);
            cmdLoad.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Query_Action_Load);
            cmdSave.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Save);
            cmdOK.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_OK);
            cmdCancel.Text = SystemManager.MStringResource.GetText(StringResource.TextType.Common_Cancel);
        }

        /// <summary>
        ///     添加条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddCondition_Click(object sender, EventArgs e)
        {
            ConditionPan.AddCondition();
        }

        /// <summary>
        ///     清空条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ConditionPan.ClearCondition();
        }

        /// <summary>
        ///     确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdOK_Click(object sender, EventArgs e)
        {
            // 设置DataFilter
            if (string.IsNullOrEmpty(txtSql.Text))
            {
                SetCurrDataFilter();
            }
            else
            {
                CurrentDataViewInfo.mDataFilter = Sql.ConvertQuerySql(txtSql.Text);
            }
            //按下OK，不论是否做更改都认为True
            CurrentDataViewInfo.IsUseFilter = true;
            Close();
        }

        /// <summary>
        ///     直接关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            var savefile = new SaveFileDialog {Filter = MongoDbHelper.XmlFilter};
            if (savefile.ShowDialog() != DialogResult.OK) return;
            // 设置DataFilter
            if (string.IsNullOrEmpty(txtSql.Text))
            {
                //设置DataFilter
                SetCurrDataFilter();
            }
            else
            {
                CurrentDataViewInfo.mDataFilter = Sql.ConvertQuerySql(txtSql.Text);
            }
            CurrentDataViewInfo.mDataFilter.SaveFilter(savefile.FileName);
        }

        /// <summary>
        ///     设置DataFilter
        /// </summary>
        private void SetCurrDataFilter()
        {
            //清除以前的结果和内部变量，重要！
            CurrentDataViewInfo.mDataFilter.Clear();
            CurrentDataViewInfo.mDataFilter.DBName = SystemManager.GetCurrentDataBase().Name;
            CurrentDataViewInfo.mDataFilter.CollectionName = SystemManager.GetCurrentCollection().Name;
            CurrentDataViewInfo.mDataFilter.QueryFieldList = QueryFieldPicker.getQueryFieldList();
            ConditionPan.SetCurrDataFilter(CurrentDataViewInfo);
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog {Filter = MongoDbHelper.XmlFilter};
            if (openFile.ShowDialog() != DialogResult.OK) return;
            DataFilter NewDataFilter = DataFilter.LoadFilter(openFile.FileName);
            CurrentDataViewInfo.mDataFilter = NewDataFilter;
        }
    }
}