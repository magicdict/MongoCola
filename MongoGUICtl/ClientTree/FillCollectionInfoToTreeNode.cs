using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Core;
using ResourceLib.Method;

namespace MongoGUICtl.ClientTree
{
    public static partial class UiHelper
    {
        /// <summary>
        ///     View处理
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public static TreeNode FillViewInfoToTreeNode(IMongoCollection<BsonDocument> col, string TagPrefix)
        {
            var mongoColNode = new TreeNode("Views(" + col.Count(x => true).ToString() + ")")
            {
                ImageIndex = (int)GetSystemIcon.MainTreeImageType.CollectionList,
                SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.CollectionList
            };
            var r = col.Find(x => true);

            foreach (var viewDoc in r.ToList())
            {
                var id = viewDoc.GetElement(ConstMgr.KeyId).ToString();
                var viewNode = new TreeNode(id.Substring(id.IndexOf(".") + 1))
                {
                    ImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection,
                    SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection
                };

                //ViewOn
                var viewOnNode = new TreeNode("ViewOn:" + viewDoc.GetElement("viewOn").Value.ToString())
                {
                    ImageIndex = (int)GetSystemIcon.MainTreeImageType.KeyInfo,
                    SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.KeyInfo
                };
                viewNode.Nodes.Add(viewOnNode);
                //Pipeline
                var pipelineNode = new TreeNode("pipeline:" + viewDoc.GetElement("pipeline").Value.ToString())
                {
                    ImageIndex = (int)GetSystemIcon.MainTreeImageType.KeyInfo,
                    SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.KeyInfo
                };
                viewNode.Nodes.Add(pipelineNode);
                viewNode.Tag = TagPrefix + viewNode.Text;
                mongoColNode.Nodes.Add(viewNode);
            }
            return mongoColNode;
        }

        /// <summary>
        ///     将数据集放入Node
        /// </summary>
        /// <param name="col"></param>
        /// <param name="mongoConnSvrKey"></param>
        /// <returns></returns>
        public static TreeNode FillCollectionInfoToTreeNode(IMongoCollection<BsonDocument> col, string mongoConnSvrKey)
        {
            var colName = col.CollectionNamespace.CollectionName;
            var databaseName = col.CollectionNamespace.DatabaseNamespace.DatabaseName;
            var strShowColName = GetShowName(databaseName, colName);
            //Collection件数的表示
            long colCount = ConnectionInfo.GetCollectionCnt(col);
            strShowColName = strShowColName + "(" + colCount + ")";
            var mongoColNode = new TreeNode(strShowColName);
            switch (col.CollectionNamespace.CollectionName)
            {
                case ConstMgr.CollectionNameGfsFiles:
                    mongoColNode.Tag = ConstMgr.GridFileSystemTag + ":" + mongoConnSvrKey + "/" + databaseName + "/" +
                                       col.CollectionNamespace.CollectionName;
                    break;
                case ConstMgr.CollectionNameGfsChunks:
                    mongoColNode.Tag = ConstMgr.GridFileSystemTag + ":" + mongoConnSvrKey + "/" + databaseName + "/" +
                                       col.CollectionNamespace.CollectionName;
                    break;
                default:
                    mongoColNode.Tag = TagInfo.CreateTagInfo(mongoConnSvrKey, databaseName,
                        col.CollectionNamespace.CollectionName);
                    break;
            }
            try
            {
                //View 没有Index
                IAsyncCursor<BsonDocument> indexCursor = null;
                var task = Task.Run(
                    async () => { indexCursor = await col.Indexes.ListAsync(); }
                    );
                task.Wait();
                List<BsonDocument> indexDocs = null;
                task = Task.Run(
                    async () => { indexDocs = await indexCursor.ToListAsync(); }
                    );
                task.Wait();
                foreach (var indexDoc in indexDocs)
                {
                    var mongoIndexes = new TreeNode { Text = indexDoc.GetElement("name").Value.ToString() };
                    foreach (var item in indexDoc.Elements)
                    {
                        mongoIndexes.Nodes.Add(string.Empty, item.Name + ":" + item.Value,
                            (int)GetSystemIcon.MainTreeImageType.KeyInfo,
                            (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                    }
                    mongoIndexes.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
                    mongoIndexes.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
                    mongoIndexes.Tag = ConstMgr.IndexesTag + ":" + mongoConnSvrKey + "/" + databaseName + "/" +
                                       col.CollectionNamespace.CollectionName;
                    mongoColNode.Nodes.Add(mongoIndexes);
                }
            }
            catch (Exception)
            {
                return null;
            }

            if (col.CollectionNamespace.CollectionName == ConstMgr.CollectionNameUsers)
            {
                mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.UserIcon;
                mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.UserIcon;
            }
            else
            {
                mongoColNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
                mongoColNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Collection;
            }
            //End Data
            return mongoColNode;
        }

        /// <summary>
        ///     获得表示名称
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="CollectionName"></param>
        /// <returns></returns>
        public static string GetShowName(string databaseName, string CollectionName)
        {
            var strShowColName = CollectionName;
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                switch (databaseName)
                {
                    case "config":
                        switch (strShowColName)
                        {
                            case "actionlog":
                            case "chunks":
                            case "collections":
                            case "changelog":
                            case "databases":
                            case "lockpings":
                            case "locks":
                            case "migrations":
                            case "mongos":
                            case "settings":
                            case "shards":
                            case "tags":
                            case "version":
                                strShowColName = GuiConfig.GetText("CollectionName.system." + strShowColName) + "(" + strShowColName + ")";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "local":
                        switch (strShowColName)
                        {
                            case "me":
                            case "sources":
                            case "slaves":
                            case "startup_log":
                                strShowColName = GuiConfig.GetText("CollectionName.system." + strShowColName) + "(" + strShowColName + ")";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }

            switch (strShowColName)
            {
                case ConstMgr.CollectionNameOperationLog:
                case ConstMgr.CollectionNameGfsChunks:
                case ConstMgr.CollectionNameGfsFiles:
                case ConstMgr.CollectionNameSystemIndexes:
                case ConstMgr.CollectionNameJavascript:
                case ConstMgr.CollectionNameSystemReplset:
                case ConstMgr.CollectionNameReplsetMinvalid:
                case ConstMgr.CollectionNameUsers:
                case ConstMgr.CollectionNameRoles:
                case ConstMgr.CollectionNameSystemProfile:
                case ConstMgr.CollectionNameVersion:
                case ConstMgr.CollectionNameReplsetElection:
                    strShowColName = GuiConfig.GetText("CollectionName." + strShowColName) + "(" + strShowColName + ")";
                    break;
                default:
                    break;
            }

            return strShowColName;
        }

        /// <summary>
        ///     将数据集放入Node
        /// </summary>
        /// <param name="jsNode"></param>
        /// <param name="col"></param>
        /// <param name="mongoConnSvrKey"></param>
        /// <param name="strDbName"></param>
        /// <returns></returns>
        public static void FillJavaScriptInfoToTreeNode(TreeNode jsNode, IMongoCollection<BsonDocument> col,
            string mongoConnSvrKey, string strDbName)
        {
            var tag = ConstMgr.JavascriptDocTag + ":" + mongoConnSvrKey + "/" + strDbName + "/" +
                      col.CollectionNamespace.CollectionName;
            var server = RuntimeMongoDbContext.GetMongoServerBySvrPath(tag, RuntimeMongoDbContext.MongoConnSvrLst);
            var db = RuntimeMongoDbContext.GetMongoDBBySvrPath(tag, server);
            MongoCollection mongoJsCol = db.GetCollection(ConstMgr.CollectionNameJavascript);
            var list = mongoJsCol.FindAllAs<BsonDocument>()
                .Select(item => item.GetValue(ConstMgr.KeyId).ToString())
                .OrderBy(item => item)
                .ToList();

            foreach (var name in list)
            {
                var node = new TreeNode(name)
                {
                    ImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc,
                    SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JsDoc,
                    Tag = tag + "/" + name
                };
                jsNode.Nodes.Add(node);
            }

            jsNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.JavaScriptList;
            jsNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.JavaScriptList;
        }
    }
}