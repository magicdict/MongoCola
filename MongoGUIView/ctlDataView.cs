using Common;
using MongoUtility.Aggregation;
using MongoUtility.Core;
using ResourceLib.Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace MongoGUIView
{
    public partial class CtlDataView : MultiTabControl
    {
        #region"Main"

        /// <summary>
        ///     Is Need Refresh after the element is modify
        /// </summary>
        public bool IsNeedRefresh;

        /// <summary>
        ///     是否是一个数据容器
        /// </summary>
        private bool _isDataView = true;

        /// <summary>
        ///     Control for show Data
        /// </summary>
        public List<Control> DataShower = new List<Control>();

        /// <summary>
        ///     DataView信息
        /// </summary>
        public DataViewInfo mDataViewInfo;

        /// <summary>
        ///     初始化
        /// </summary>
        public CtlDataView()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="dataViewInfo"></param>
        public CtlDataView(DataViewInfo dataViewInfo)
        {
            InitializeComponent();
            mDataViewInfo = dataViewInfo;
        }

        /// <summary>
        ///     是否是一个数据容器
        /// </summary>
        [Description("Is used for display a data collection")]
        public bool IsDocumentView
        {
            set
            {
                _isDataView = value;
                CollapseAllStripButton.Visible = _isDataView;
                ExpandAllStripButton.Visible = _isDataView;
            }
            get { return _isDataView; }
        }

        /// <summary>
        ///     加载数据集控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlDataView_Load(object sender, EventArgs e)
        {
            if (mDataViewInfo == null)
            {
                return;
            }
            cmbRecPerPage.SelectedIndex = 1;
            mDataViewInfo.LimitCnt = 100;
            GuiConfig.Translateform(Controls);
            InitControlsVisiableAndEvent();
            //加载数据
            //第一次加载数据的时候，会发生滚动条位置不正确的问题，需要DoEvents,RefreshGUI.
            //可能是太多的事情一起做，造成了一些诡异的位置计算问题。DoEvents暂停一下，然后再刷新一下
            Application.DoEvents();
            //数据导航
            RefreshGui();
        }

        /// <summary>
        ///     将部分的按钮和右键菜单有效化
        /// </summary>
        private void InitControlsVisiableAndEvent()
        {
            FirstPageStripButton.Visible = true;
            PrePageStripButton.Visible = true;
            NextPageStripButton.Visible = true;
            LastPageStripButton.Visible = true;

            GotoStripButton.Visible = true;

            RefreshStripButton.Visible = true;
            RefreshStripButton.Enabled = true;

            HelpStripButton.Visible = true;
            HelpStripButton.Enabled = true;

            CloseStripButton.Visible = true;
            CloseStripButton.Enabled = true;
        }

        /// <summary>
        ///     初始化控件状态
        /// </summary>
        private void InitControlsEnable()
        {
            foreach (var item in contextMenuStripMain.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    ((ToolStripMenuItem)item).Enabled = false;
                }
            }
            foreach (var item in ViewtoolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    ((ToolStripButton)item).Enabled = false;
                }
            }

            ExpandAllStripButton.Enabled = true;
            CollapseAllStripButton.Enabled = true;


            PrePageStripButton.Enabled = mDataViewInfo.HasPrePage;
            NextPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            FirstPageStripButton.Enabled = mDataViewInfo.HasPrePage;
            LastPageStripButton.Enabled = mDataViewInfo.HasNextPage;

            GotoStripButton.Enabled = true;
            HelpStripButton.Enabled = true;
            RefreshStripButton.Enabled = true;
            CloseStripButton.Enabled = true;
        }

        /// <summary>
        ///     关闭本Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            RaiseCloseTabEvent();
        }

        /// <summary>
        ///     帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                var strType = GetType().FullName;
                var strUrl = @"http://www.codesnippet.info/Article/Index?ArticleId=00000062";
                if (strType == typeof(CtlDataView).FullName) strUrl = @"http://www.codesnippet.info/Article/Index?ArticleId=00000062";
                if (strType == typeof(CtlDocumentView).FullName) strUrl = @"http://www.codesnippet.info/Article/Index?ArticleId=00000062";
                if (strType == typeof(CtlGfsView).FullName) strUrl = @"http://www.codesnippet.info/Article/Index?ArticleId=00000062#Grid File System";
                if (strType == typeof(CtlUserView).FullName) strUrl = @"http://www.codesnippet.info/Article/Index?ArticleId=00000062#安全";
                Process.Start(strUrl);
            }
            catch (Exception)
            {
                MessageBox.Show("HelpFile Error!");
            }
        }

        #endregion

        #region"数据导航"

        /// <summary>
        ///     换页操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbRecPerPage.SelectedIndex)
            {
                case 0:
                    mDataViewInfo.LimitCnt = 50;
                    break;
                case 1:
                    mDataViewInfo.LimitCnt = 100;
                    break;
                case 2:
                    mDataViewInfo.LimitCnt = 200;
                    break;
                default:
                    mDataViewInfo.LimitCnt = 100;
                    break;
            }
            ReloadData();
        }

        /// <summary>
        ///     指定起始位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoStripButton_Click(object sender, EventArgs e)
        {
            if (txtSkip.Text.IsNumeric())
            {
                var skip = Convert.ToInt32(txtSkip.Text);
                skip--;
                if (skip >= 0)
                {
                    if (mDataViewInfo.CurrentCollectionTotalCnt <= skip)
                    {
                        mDataViewInfo.SkipCnt = mDataViewInfo.CurrentCollectionTotalCnt - 1;
                        if (mDataViewInfo.SkipCnt == -1)
                        {
                            ///CurrentCollectionTotalCnt可能为0
                            mDataViewInfo.SkipCnt = 0;
                        }
                    }
                    else
                    {
                        mDataViewInfo.SkipCnt = skip;
                    }
                    ReloadData();
                }
            }
            else
            {
                txtSkip.Text = string.Empty;
            }
        }

        /// <summary>
        ///     第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstPage_Click(object sender, EventArgs e)
        {
            ViewHelper.PageChanged(ViewHelper.PageChangeOpr.FirstPage, ref mDataViewInfo, DataShower);
            SetDataNav();
        }

        /// <summary>
        ///     前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrePage_Click(object sender, EventArgs e)
        {
            ViewHelper.PageChanged(ViewHelper.PageChangeOpr.PrePage, ref mDataViewInfo, DataShower);
            SetDataNav();
        }

        /// <summary>
        ///     下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, EventArgs e)
        {
            ViewHelper.PageChanged(ViewHelper.PageChangeOpr.NextPage, ref mDataViewInfo, DataShower);
            SetDataNav();
        }

        /// <summary>
        ///     最后页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastPage_Click(object sender, EventArgs e)
        {
            ViewHelper.PageChanged(ViewHelper.PageChangeOpr.LastPage, ref mDataViewInfo, DataShower);
            SetDataNav();
        }

        /// <summary>
        ///     展开所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpandAll_Click(object sender, EventArgs e)
        {
            trvData.DatatreeView.BeginUpdate();
            trvData.DatatreeView.ExpandAll();
            trvData.DatatreeView.EndUpdate();
        }

        /// <summary>
        ///     折叠所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAll_Click(object sender, EventArgs e)
        {
            trvData.DatatreeView.BeginUpdate();
            trvData.DatatreeView.CollapseAll();
            trvData.DatatreeView.EndUpdate();
        }

        /// <summary>
        ///     清除所有数据
        /// </summary>
        private void Clear()
        {
            lstData.Clear();
            txtData.Text = string.Empty;
            trvData.DatatreeView.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.DatatreeView.ContextMenuStrip = null;
        }

        /// <summary>
        ///     设置导航可用性
        /// </summary>
        private void SetDataNav()
        {
            PrePageStripButton.Enabled = mDataViewInfo.HasPrePage;
            NextPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            FirstPageStripButton.Enabled = mDataViewInfo.HasPrePage;
            LastPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            var strTitle = string.Empty;
            if (mDataViewInfo.CurrentCollectionTotalCnt == 0)
            {
                DataNaviToolStripLabel.Text = strTitle + "0/0";
            }
            else
            {
                DataNaviToolStripLabel.Text = (mDataViewInfo.SkipCnt + 1) + "/" + mDataViewInfo.CurrentCollectionTotalCnt;
            }
            txtSkip.Text = (mDataViewInfo.SkipCnt + 1).ToString();
        }

        /// <summary>
        ///     Refresh Data
        /// </summary>
        public override void RefreshGui()
        {
            Clear();
            mDataViewInfo.SkipCnt = 0;
            RuntimeMongoDbContext.SelectObjectTag = mDataViewInfo.strCollectionPath;
            var datalist = DataViewInfo.GetDataList(ref mDataViewInfo, RuntimeMongoDbContext.GetCurrentServer());
            ViewHelper.FillDataToControl(datalist, DataShower, mDataViewInfo);
            InitControlsEnable();
            SetDataNav();
            if (mDataViewInfo.Query != string.Empty)
            {
                txtQuery.Text = mDataViewInfo.Query;
                if (!tabDataShower.TabPages.Contains(tabQuery))
                {
                    tabDataShower.TabPages.Add(tabQuery);
                }
            }
            else
            {
                if (tabDataShower.TabPages.Contains(tabQuery))
                {
                    tabDataShower.TabPages.Remove(tabQuery);
                }
            }
            IsNeedRefresh = false;
        }

        /// <summary>
        ///     重新加载数据
        /// </summary>
        private void ReloadData()
        {
            if (mDataViewInfo == null)
            {
                return;
            }
            Clear();
            RuntimeMongoDbContext.SelectObjectTag = mDataViewInfo.strCollectionPath;
            var datalist = DataViewInfo.GetDataList(ref mDataViewInfo, RuntimeMongoDbContext.GetCurrentServer());
            ViewHelper.FillDataToControl(datalist, DataShower, mDataViewInfo);
            SetDataNav();
            IsNeedRefresh = false;
        }

        //刷新
        private void RefreshStripButton_Click(object sender, EventArgs e)
        {
            RefreshGui();
        }

        #endregion
    }
}