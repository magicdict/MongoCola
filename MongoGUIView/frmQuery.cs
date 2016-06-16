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
        //Query 不支持$project操作和其他复杂操作！

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
        ///     直接关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     输出配置字典
        /// </summary>
        private void frmQuery_Load(object sender, EventArgs e)
        {
            if (!GuiConfig.IsMono) Icon = GetSystemIcon.ConvertImgToIcon(GetResource.GetImage(ImageType.Query));
            var fieldList = new List<DataFilter.QueryFieldItem>();
            fieldList = _currentDataViewInfo.MDataFilter.QueryFieldList;
            if (fieldList.Count != 0)
            {
                //使用过滤：字段和条件的设定
                ConditionPan.PutQueryToUi(_currentDataViewInfo.MDataFilter);
                QueryFieldPicker.SetQueryFieldList(fieldList);
            }
            else
            {
                //增加第一个条件
                ConditionPan.AddCondition();
                //不使用过滤：字段初始化
                QueryFieldPicker.InitByCurrentCollection(true);
            }
            //多国语言
            GuiConfig.Translateform(this);
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
                //No Sql
                SetCurrentDataFilter();
            }
            else
            {
                SetCurrentDataFilter();
                _currentDataViewInfo.MDataFilter = SqlHelper.ConvertQuerySql(txtSql.Text,
                    RuntimeMongoDbContext.GetCurrentCollection());
            }
            //按下OK，不论是否做更改都认为True
            _currentDataViewInfo.IsUseFilter = true;
            Close();
        }

        /// <summary>
        ///     保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            var savefile = new SaveFileDialog { Filter = Utility.XmlFilter };
            if (savefile.ShowDialog() != DialogResult.OK) return;
            // 设置DataFilter
            if (string.IsNullOrEmpty(txtSql.Text))
            {
                //设置DataFilter
                SetCurrentDataFilter();
            }
            else
            {
                //使用SQL
                _currentDataViewInfo.MDataFilter = SqlHelper.ConvertQuerySql(txtSql.Text,
                    RuntimeMongoDbContext.GetCurrentCollection());
            }
            _currentDataViewInfo.MDataFilter.SaveFilter(savefile.FileName);
        }

        /// <summary>
        ///     设置DataFilter
        /// </summary>
        private void SetCurrentDataFilter()
        {
            //清除以前的结果和内部变量，重要！
            //FieldList 和 FieldPicker 是引用关系，所以这里Clear掉之后FieldPicker也会被清除掉。GetQueryFieldList就会始终为空！
            _currentDataViewInfo.MDataFilter.QueryConditionList.Clear();
            _currentDataViewInfo.MDataFilter.DbName = RuntimeMongoDbContext.GetCurrentDataBase().Name;
            _currentDataViewInfo.MDataFilter.CollectionName = RuntimeMongoDbContext.GetCurrentCollection().Name;
            _currentDataViewInfo.MDataFilter.QueryFieldList = QueryFieldPicker.GetQueryFieldList();
            ConditionPan.SetCurrDataFilter(_currentDataViewInfo);
            if (RuntimeMongoDbContext.CollectionFilter.ContainsKey(RuntimeMongoDbContext.GetCurrentCollectionName()))
            {
                RuntimeMongoDbContext.CollectionFilter[RuntimeMongoDbContext.GetCurrentCollectionName()] = _currentDataViewInfo.MDataFilter;
            }
            else
            {
                RuntimeMongoDbContext.CollectionFilter.Add(RuntimeMongoDbContext.GetCurrentCollectionName(), _currentDataViewInfo.MDataFilter);
            }
        }

        /// <summary>
        ///     加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog { Filter = Utility.XmlFilter };
            if (openFile.ShowDialog() != DialogResult.OK) return;
            var newDataFilter = DataFilter.LoadFilter(openFile.FileName);
            _currentDataViewInfo.MDataFilter = newDataFilter;
            QueryFieldPicker.SetQueryFieldList(_currentDataViewInfo.MDataFilter.QueryFieldList);
        }
    }
}