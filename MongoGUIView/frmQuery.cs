using Common;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using ResourceLib.Method;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MongoGUIView
{
    [Obsolete("该窗体已经废止")]
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
            RuntimeMongoDbContext.SelectObjectTag = mDataViewInfo.strCollectionPath;
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
            fieldList = _currentDataViewInfo.mDataFilter.QueryFieldList;
            if (fieldList.Count != 0)
            {
                //使用过滤：字段和条件的设定
                ConditionPan.PutQueryToUi(_currentDataViewInfo.mDataFilter);
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
            //按下OK，不论是否做更改都认为True
            SetCurrentDataFilter();
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
            //设置DataFilter
            SetCurrentDataFilter();
            _currentDataViewInfo.mDataFilter.SaveFilter(savefile.FileName);
        }

        /// <summary>
        ///     设置DataFilter
        /// </summary>
        private void SetCurrentDataFilter()
        {
            //清除以前的结果和内部变量，重要！
            //FieldList 和 FieldPicker 是引用关系，所以这里Clear掉之后FieldPicker也会被清除掉。GetQueryFieldList就会始终为空！
            _currentDataViewInfo.mDataFilter.QueryConditionList.Clear();
            _currentDataViewInfo.mDataFilter.DbName = RuntimeMongoDbContext.GetCurrentDataBaseName();
            _currentDataViewInfo.mDataFilter.CollectionName = RuntimeMongoDbContext.GetCurrentCollectionName();
            _currentDataViewInfo.mDataFilter.QueryFieldList = QueryFieldPicker.GetQueryFieldList();
            ConditionPan.SetCurrDataFilter(_currentDataViewInfo);
            if (RuntimeMongoDbContext.CollectionFilter.ContainsKey(RuntimeMongoDbContext.GetCurrentCollectionName()))
            {
                RuntimeMongoDbContext.CollectionFilter[RuntimeMongoDbContext.GetCurrentCollectionName()] = _currentDataViewInfo.mDataFilter;
            }
            else
            {
                RuntimeMongoDbContext.CollectionFilter.Add(RuntimeMongoDbContext.GetCurrentCollectionName(), _currentDataViewInfo.mDataFilter);
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
            _currentDataViewInfo.mDataFilter = newDataFilter;
            QueryFieldPicker.SetQueryFieldList(_currentDataViewInfo.mDataFilter.QueryFieldList);
        }
    }
}