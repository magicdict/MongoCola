using System;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoGUICtl;
using MongoUtility.Aggregation;
using MongoUtility.Basic;
using MongoUtility.Core;
using Utility = Common.Logic.Utility;

namespace HTTPServer
{
    public static class WEBUIHelper
    {
        #region"展示数据库结构 WebForm"

        /// <summary>
        ///     唯一的网页展示数据的数据信息
        /// </summary>
        public static DataViewInfo WebDataViewInfo;

        /// <summary>
        ///     获取JSON
        /// </summary>
        /// <returns></returns>
        public static String GetConnectionzTreeJson()
        {
            var tree = new TreeView();
            var nodes = UIHelper.GetConnectionNodes(RuntimeMongoDBContext._mongoConnSvrLst,
                RuntimeMongoDBContext._mongoConnectionConfigList);
            foreach (var element in nodes)
            {
                tree.Nodes.Add(element);
            }
            return ConvertTreeViewTozTreeJson(tree);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static string GetCollectionzTreeJSON(MongoServer mServer)
        {
            //获得数据
            WebDataViewInfo.LimitCnt = 100;
            var dataList = DataViewInfo.GetDataList(ref WebDataViewInfo, mServer);
            var collectionName =
                Utility.GetTagData(WebDataViewInfo.strDBTag).Split("/".ToCharArray())[(int) EnumMgr.PathLv.CollectionLv];
            var tree = new ctlTreeViewColumns();
            UIHelper.FillDataToTreeView(collectionName, tree, dataList, WebDataViewInfo.SkipCnt);
            var array = new BsonArray();
            foreach (TreeNode item in tree.TreeView.Nodes)
            {
                array.Add(ConvertTreeNodeTozTreeBsonDoc(item));
            }
            return array.ToJson(MongoUtility.Basic.Utility.JsonWriterSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="RootName"></param>
        /// <param name="doc"></param>
        /// <param name="IsOpen"></param>
        /// <returns></returns>
        public static String ConvertBsonTozTreeJson(String RootName, BsonDocument doc, Boolean IsOpen)
        {
            var trvStatus = new ctlTreeViewColumns();
            UIHelper.FillDataToTreeView(RootName, trvStatus, doc);
            if (IsOpen)
            {
                trvStatus.TreeView.Nodes[0].Expand();
            }
            return ConvertTreeViewTozTreeJson(trvStatus.TreeView);
        }

        /// <summary>
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static String ConvertTreeViewTozTreeJson(TreeView tree)
        {
            var array = new BsonArray();
            foreach (TreeNode item in tree.Nodes)
            {
                array.Add(ConvertTreeNodeTozTreeBsonDoc(item));
            }
            return array.ToJson(MongoUtility.Basic.Utility.JsonWriterSettings);
        }

        /// <summary>
        /// </summary>
        /// <param name="SubNode"></param>
        /// <returns></returns>
        public static BsonDocument ConvertTreeNodeTozTreeBsonDoc(TreeNode SubNode)
        {
            var SingleNode = new BsonDocument();
            SingleNode.Add("name", SubNode.Text + GetTagText(SubNode));
            if (SubNode.Nodes.Count == 0)
            {
                SingleNode.Add("icon", "MainTreeImage" + String.Format("{0:00}", SubNode.ImageIndex) + ".png");
            }
            else
            {
                var ChildrenList = new BsonArray();
                foreach (TreeNode item in SubNode.Nodes)
                {
                    ChildrenList.Add(ConvertTreeNodeTozTreeBsonDoc(item));
                }
                SingleNode.Add("children", ChildrenList);
                SingleNode.Add("icon", "MainTreeImage" + String.Format("{0:00}", SubNode.ImageIndex) + ".png");
            }
            if (SubNode.IsExpanded)
            {
                SingleNode.Add("open", "true");
            }
            if (SubNode.Tag != null)
            {
                SingleNode.Add("click",
                    "ShowData('" + Utility.GetTagType(SubNode.Tag.ToString()) + "','" +
                    Utility.GetTagData(SubNode.Tag.ToString()) + "')");
            }
            return SingleNode;
        }

        /// <summary>
        ///     展示数据值和类型
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static string GetTagText(TreeNode node)
        {
            var strColumnText = String.Empty;
            var Element = node.Tag as BsonElement;
            if (Element != null && !Element.Value.IsBsonDocument && !Element.Value.IsBsonArray)
            {
                strColumnText = ":" + Element.Value;
                strColumnText += "[" + Element.Value.GetType().Name.Substring(4) + "]";
            }
            return strColumnText;
        }

        #endregion
    }
}