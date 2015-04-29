using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using ResourceLib.Method;

namespace MongoGUIView
{
    public partial class FrmQuery : Form
    {
        /// <summary>
        ///     当前DataViewInfo
        /// </summary>
        private readonly DataViewInfo _currentDataViewInfo;

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="mDataViewInfo">Filter也是DataViewInfo的一个属性，所以这里加上参数</param>
        public FrmQuery(DataViewInfo mDataViewInfo)
        {
            InitializeComponent();
            _currentDataViewInfo = mDataViewInfo;
            RuntimeMongoDbContext.SelectObjectTag = mDataViewInfo.StrDbTag;
        }

        /// <summary>
        ///     输出配置字典
        /// </summary>
        private void frmQuery_Load(object sender, EventArgs e)
        {
            Icon = GetSystemIcon.ConvertImgToIcon(GetResource.GetImage(ImageType.Query));
            var fieldList = new List<DataFilter.QueryFieldItem>();
            fieldList = _currentDataViewInfo.MDataFilter.QueryFieldList;
            //增加第一个条件
            ConditionPan.AddCondition();
            if (_currentDataViewInfo.IsUseFilter)
            {
                //使用过滤：字段和条件的设定
                QueryFieldPicker.SetQueryFieldList(fieldList);
                if (_currentDataViewInfo.MDataFilter.QueryConditionList.Count > 0)
                {
                    ConditionPan.PutQueryToUi(_currentDataViewInfo.MDataFilter);
                }
            }
            else
            {
                //不使用过滤：字段初始化
                QueryFieldPicker.InitByCurrentCollection(true);
            }
            if (GuiConfig.IsUseDefaultLanguage) return;
            Text = GuiConfig.GetText(TextType.QueryTitle);
            tabFieldInfo.Text = GuiConfig.GetText(TextType.QueryFieldInfo);
            tabCondition.Text = GuiConfig.GetText(TextType.QueryFilter);
            tabSql.Text = GuiConfig.GetText(TextType.ConvertSqlTitle);
            cmdAddCondition.Text =
                GuiConfig.GetText(TextType.QueryFilterAddCondition);
            cmdLoad.Text = GuiConfig.GetText(TextType.QueryActionLoad);
            cmdSave.Text = GuiConfig.GetText(TextType.CommonSave);
            cmdOK.Text = GuiConfig.GetText(TextType.CommonOk);
            cmdCancel.Text = GuiConfig.GetText(TextType.CommonCancel);
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
                _currentDataViewInfo.MDataFilter = SqlHelper.ConvertQuerySql(txtSql.Text,
                    RuntimeMongoDbContext.GetCurrentCollection());
            }
            //按下OK，不论是否做更改都认为True
            _currentDataViewInfo.IsUseFilter = true;
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
            var savefile = new SaveFileDialog {Filter = Utility.XmlFilter};
            if (savefile.ShowDialog() != DialogResult.OK) return;
            // 设置DataFilter
            if (string.IsNullOrEmpty(txtSql.Text))
            {
                //设置DataFilter
                SetCurrDataFilter();
            }
            else
            {
                _currentDataViewInfo.MDataFilter = SqlHelper.ConvertQuerySql(txtSql.Text,
                    RuntimeMongoDbContext.GetCurrentCollection());
            }
            _currentDataViewInfo.MDataFilter.SaveFilter(savefile.FileName);
        }

        /// <summary>
        ///     设置DataFilter
        /// </summary>
        private void SetCurrDataFilter()
        {
            //清除以前的结果和内部变量，重要！
            _currentDataViewInfo.MDataFilter.Clear();
            _currentDataViewInfo.MDataFilter.DbName = RuntimeMongoDbContext.GetCurrentDataBase().Name;
            _currentDataViewInfo.MDataFilter.CollectionName = RuntimeMongoDbContext.GetCurrentCollection().Name;
            _currentDataViewInfo.MDataFilter.QueryFieldList = QueryFieldPicker.GetQueryFieldList();
            ConditionPan.SetCurrDataFilter(_currentDataViewInfo);
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog {Filter = Utility.XmlFilter};
            if (openFile.ShowDialog() != DialogResult.OK) return;
            var newDataFilter = DataFilter.LoadFilter(openFile.FileName);
            _currentDataViewInfo.MDataFilter = newDataFilter;
        }
    }
}