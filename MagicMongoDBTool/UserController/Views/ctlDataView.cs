using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MagicMongoDBTool.Module;
using MongoDB.Bson;

namespace MagicMongoDBTool.UserController
{
    public partial class ctlDataView : UserControl
    {

        #region"Main"

        /// <summary>
        ///初始化
        /// </summary>
        public ctlDataView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Is Need Refresh after the element is modify
        /// </summary>
        public Boolean IsNeedRefresh = false;
        /// <summary>
        /// 是否是一个数据容器
        /// </summary>
        private Boolean _IsDataView = true;
        /// <summary>
        /// 是否是一个数据容器
        /// </summary>
        [Description("Is used for display a data collection")]
        public Boolean IsDocumentView
        {
            set
            {
                _IsDataView = value;
                CollapseAllStripButton.Visible = _IsDataView;
                ExpandAllStripButton.Visible = _IsDataView;
            }
            get
            {
                return _IsDataView;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="_DataViewInfo"></param>
        public ctlDataView(MongoDBHelper.DataViewInfo _DataViewInfo)
        {
            InitializeComponent();
            mDataViewInfo = _DataViewInfo;
        }
        /// <summary>
        /// Control for show Data
        /// </summary>
        public List<Control> _dataShower = new List<Control>();
        /// <summary>
        /// DataView信息
        /// </summary>
        public MongoDBHelper.DataViewInfo mDataViewInfo;
        /// <summary>
        /// 关闭Tab事件(主界面操作这个文档的时候用的事件)
        /// </summary>
        public event EventHandler CloseTab;
        /// <summary>
        /// 加载数据集控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctlDataView_Load(object sender, EventArgs e)
        {
            if (mDataViewInfo == null) { return; }
            this.cmbRecPerPage.SelectedIndex = 1;
            mDataViewInfo.LimitCnt = 100;
            if (!SystemManager.IsUseDefaultLanguage)
            {
                //数据显示区
                this.tabTreeView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Tree);
                this.tabTableView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Table);
                this.tabTextView.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Tab_Text);
                this.PrePageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Previous);
                this.NextPageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Next);
                this.FirstPageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_First);
                this.LastPageStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Last);
                this.QueryStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_Query);
                this.FilterStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView_DataFilter);
                this.RefreshStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Refresh);
                this.CloseStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Close);
                this.ExpandAllStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Expansion);
                this.CollapseAllStripButton.Text = SystemManager.mStringResource.GetText(StringResource.TextType.Common_Collapse);

            }
            InitControlsVisiableAndEvent();
            //加载数据
            //第一次加载数据的时候，会发生滚动条位置不正确的问题，需要DoEvents,RefreshGUI.
            //可能是太多的事情一起做，造成了一些诡异的位置计算问题。DoEvents暂停一下，然后再刷新一下
            Application.DoEvents();
            //数据导航
            RefreshGUI();
        }
        /// <summary>
        /// 将部分的按钮和右键菜单有效化
        /// </summary>
        private void InitControlsVisiableAndEvent()
        {

            FirstPageStripButton.Visible = true;
            PrePageStripButton.Visible = true;
            NextPageStripButton.Visible = true;
            LastPageStripButton.Visible = true;
            this.FilterStripButton.Visible = true;
            this.QueryStripButton.Visible = true;

            GotoStripButton.Visible = true;

            RefreshStripButton.Visible = true;
            RefreshStripButton.Enabled = true;

            HelpStripButton.Visible = true;
            HelpStripButton.Enabled = true;

            CloseStripButton.Visible = true;
            CloseStripButton.Enabled = true;
        }
        /// <summary>
        /// 初始化控件状态
        /// </summary>
        private void InitControlsEnable()
        {
            foreach (var item in this.contextMenuStripMain.Items)
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

            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            this.FilterStripButton.Enabled = true;
            this.QueryStripButton.Enabled = true;

            GotoStripButton.Enabled = true;
            HelpStripButton.Enabled = true;
            RefreshStripButton.Enabled = true;
            CloseStripButton.Enabled = true;
        }
        /// <summary>
        /// 关闭本Tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseStripButton_Click(object sender, EventArgs e)
        {
            if (CloseTab != null)
            {
                CloseTab(sender, e);
            }
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpStripButton_Click(object sender, EventArgs e)
        {
            String strType = this.GetType().ToString();
            strType = strType.Split(".".ToCharArray())[1];
            String strUrl = @"UserGuide\index.htm";
            switch (strType)
            {
                case "ctlDataView":
                    strUrl = @"UserGuide\index.html";
                    break;
                case "ctlDocumentView":
                    strUrl = @"UserGuide\DataView.html";
                    break;
                case "ctlGFSView":
                    strUrl = @"UserGuide\GFS.html";
                    break;
                case "ctlUserView":
                    strUrl = @"UserGuide\User.html";
                    break;
            }
            System.Diagnostics.Process.Start(strUrl);
        }

        #endregion

        #region"数据导航"
        /// <summary>
        /// 换页操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbRecPerPage_SelectedIndexChanged(object sender, System.EventArgs e)
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
        /// 指定起始位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GotoStripButton_Click(object sender, EventArgs e)
        {
            if (txtSkip.Text.IsNumeric())
            {
                int skip = Convert.ToInt32(txtSkip.Text);
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
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.FirstPage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrePage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.PrePage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.NextPage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 最后页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastPage_Click(object sender, EventArgs e)
        {
            MongoDBHelper.PageChanged(MongoDBHelper.PageChangeOpr.LastPage, ref mDataViewInfo, _dataShower);
            SetDataNav();
        }
        /// <summary>
        /// 展开所有
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
        /// 折叠所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollapseAll_Click(object sender, EventArgs e)
        {
            trvData.DatatreeView.CollapseAll();
        }
        /// <summary>
        /// 清除所有数据
        /// </summary>
        private void clear()
        {
            lstData.Clear();
            txtData.Text = String.Empty;
            trvData.DatatreeView.Nodes.Clear();
            lstData.ContextMenuStrip = null;
            trvData.DatatreeView.ContextMenuStrip = null;
        }

        /// <summary>
        /// 设置导航可用性
        /// </summary>
        private void SetDataNav()
        {
            PrePageStripButton.Enabled = mDataViewInfo.HasPrePage;
            NextPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            FirstPageStripButton.Enabled = mDataViewInfo.HasPrePage;
            LastPageStripButton.Enabled = mDataViewInfo.HasNextPage;
            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            this.QueryStripButton.Enabled = true;
            String strTitle = "Records";
            if (!SystemManager.IsUseDefaultLanguage)
            {
                strTitle = SystemManager.mStringResource.GetText(StringResource.TextType.Main_Menu_DataView);
            }
            if (mDataViewInfo.CurrentCollectionTotalCnt == 0)
            {
                this.DataNaviToolStripLabel.Text = strTitle + "：0/0";
            }
            else
            {
                this.DataNaviToolStripLabel.Text = strTitle + "：" + (mDataViewInfo.SkipCnt + 1).ToString() + "/" + mDataViewInfo.CurrentCollectionTotalCnt.ToString();
            }
            txtSkip.Text = (mDataViewInfo.SkipCnt + 1).ToString();
        }
        /// <summary>
        /// Refresh Data
        /// </summary>
        public void RefreshGUI()
        {
            this.clear();
            mDataViewInfo.SkipCnt = 0;
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            List<BsonDocument> datalist = MongoDBHelper.GetDataList(ref mDataViewInfo);
            MongoDBHelper.FillDataToControl(datalist, _dataShower, mDataViewInfo);
            InitControlsEnable();
            SetDataNav();
            if (mDataViewInfo.Query != String.Empty)
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
        /// 重新加载数据
        /// </summary>
        private void ReloadData()
        {
            if (mDataViewInfo == null) { return; }
            this.clear();
            SystemManager.SelectObjectTag = mDataViewInfo.strDBTag;
            List<BsonDocument> datalist = MongoDBHelper.GetDataList(ref mDataViewInfo);
            MongoDBHelper.FillDataToControl(datalist, _dataShower, mDataViewInfo);
            SetDataNav();
            IsNeedRefresh = false;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QueryStripButton_Click(object sender, EventArgs e)
        {
            SystemManager.OpenForm(new frmQuery(mDataViewInfo), true, false);
            this.FilterStripButton.Enabled = mDataViewInfo.IsUseFilter;
            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            //重新展示数据
            RefreshGUI();
        }
        /// <summary>
        /// 过滤器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterStripButton_Click(object sender, EventArgs e)
        {
            mDataViewInfo.IsUseFilter = !mDataViewInfo.IsUseFilter;
            this.FilterStripButton.Checked = mDataViewInfo.IsUseFilter;
            //过滤变更后，重新刷新
            RefreshGUI();
        }
        //刷新
        private void RefreshStripButton_Click(object sender, EventArgs e)
        {
            RefreshGUI();
        }
        #endregion


    }
}
