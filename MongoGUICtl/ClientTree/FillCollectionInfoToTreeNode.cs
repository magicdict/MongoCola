using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        ///     将数据集放入Node
        /// </summary>
        /// <param name="col"></param>
        /// <param name="mongoConnSvrKey"></param>
        /// <returns></returns>
        public static TreeNode FillCollectionInfoToTreeNode(IMongoCollection<BsonDocument> col, string mongoConnSvrKey)
        {
            var strShowColName = col.CollectionNamespace.CollectionName;
            var databaseName = col.CollectionNamespace.DatabaseNamespace.DatabaseName;
            if (!GuiConfig.IsUseDefaultLanguage)
            {
                switch (strShowColName)
                {
                    case "chunks":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameChunks) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "collections":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameCollections) + "(" + strShowColName + ")";
                        }
                        break;
                    case "changelog":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameChangelog) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "databases":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameDatabases) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "lockpings":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameLockpings) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "locks":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameLocks) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "mongos":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameMongos) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "settings":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameSettings) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "shards":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameShards) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "tags":
                        //ADD: 2013/01/04 Mongo2.2.2开始支持ShardTag了 
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameTags) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "version":
                        if (databaseName == "config")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameVersion) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "me":
                        if (databaseName == "local")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameMe) + "(" +
                                strShowColName + ")";
                        }
                        break;
                    case "sources":
                        if (databaseName == "local")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameSources) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "slaves":
                        if (databaseName == "local")
                        {
                            strShowColName =
                                GuiConfig.GetText(
                                    TextType.SystemcColnameSlaves) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case ConstMgr.CollectionNameGfsChunks:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameGfsChunks) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameGfsFiles:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameGfsFiles) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameOperationLog:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameOperationLog) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameSystemIndexes:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameSystemIndexes) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameJavascript:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameJavascript) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameSystemReplset:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameSystemReplset) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameReplsetMinvalid:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameReplsetMinvalid) + "(" + strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameUser:
                        strShowColName =
                            GuiConfig.GetText(TextType.CollectionNameUser) +
                            "(" +
                            strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameRole:
                        //New From 2.6 
                        strShowColName =
                            GuiConfig.GetText(TextType.CollectionNameRole) +
                            "(" +
                            strShowColName + ")";
                        break;
                    case ConstMgr.CollectionNameSystemProfile:
                        strShowColName =
                            GuiConfig.GetText(
                                TextType.CollectionNameSystemProfile) +
                            "(" + strShowColName + ")";
                        break;
                }
            }
            //Collection件数的表示
            long colCount = 0;
            Expression<Func<BsonDocument, bool>> countfun = x => true;
            var task = Task.Run(
                async () => { colCount = await col.CountAsync(countfun); }
                );
            task.Wait();
            strShowColName = strShowColName + "(" + colCount + ")";
            var mongoColNode = new TreeNode(strShowColName);
            switch (col.CollectionNamespace.CollectionName)
            {
                case ConstMgr.CollectionNameGfsFiles:
                    mongoColNode.Tag = ConstMgr.GridFileSystemTag + ":" + mongoConnSvrKey + "/" + databaseName + "/" +
                                       col.CollectionNamespace.CollectionName;
                    break;
                case ConstMgr.CollectionNameUser:
                    mongoColNode.Tag = ConstMgr.UserListTag + ":" + mongoConnSvrKey + "/" + databaseName + "/" +
                                       col.CollectionNamespace.CollectionName;
                    break;
                default:
                    mongoColNode.Tag = TagInfo.CreateTagInfo(mongoConnSvrKey, databaseName,
                        col.CollectionNamespace.CollectionName);
                    break;
            }

            //MongoCollection mongoCol = mongoDB.GetCollection(strColName);

            ////Start ListIndex
            //var mongoIndexes = new TreeNode("Indexes");
            //var indexList = mongoCol.GetIndexes();
            IAsyncCursor<BsonDocument> indexCursor = null;
            task = Task.Run(
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
                var mongoIndexes = new TreeNode {Text = indexDoc.GetElement("name").Value.ToString()};
                foreach (var item in indexDoc.Elements)
                {
                    mongoIndexes.Nodes.Add(string.Empty, item.Name + ":" + item.Value,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int) GetSystemIcon.MainTreeImageType.KeyInfo);
                }
                mongoIndexes.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Keys;
                mongoIndexes.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Keys;
                mongoIndexes.Tag = ConstMgr.IndexesTag + ":" + mongoConnSvrKey + "/" + databaseName + "/" +
                                   col.CollectionNamespace.CollectionName;
                mongoColNode.Nodes.Add(mongoIndexes);
            }

            #region Legacy

            //foreach (var indexDoc in indexList.ToList())
            //{
            //    var mongoIndex = new TreeNode();
            //    if (!GUIConfig.IsUseDefaultLanguage)
            //    {
            //        mongoIndex.Text =
            //            (GUIConfig.MStringResource.GetText(TextType.Index_Name) + ":" +
            //             indexDoc.Name);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_Keys) + ":" +
            //            GetKeyString(indexDoc.Key), (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_RepeatDel) + ":" +
            //            indexDoc.DroppedDups, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_Background) + ":" +
            //            indexDoc.IsBackground, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_Sparse) + ":" +
            //            indexDoc.IsSparse, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_Unify) + ":" +
            //            indexDoc.IsUnique, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_NameSpace) + ":" +
            //            indexDoc.Namespace, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            GUIConfig.MStringResource.GetText(TextType.Index_Version) + ":" +
            //            indexDoc.Version, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        if (indexDoc.TimeToLive == TimeSpan.MaxValue)
            //        {
            //            mongoIndex.Nodes.Add(string.Empty,
            //                GUIConfig.MStringResource.GetText(TextType.Index_ExpireData) +
            //                ":Not Set",
            //                (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        }
            //        else
            //        {
            //            mongoIndex.Nodes.Add(string.Empty,
            //                GUIConfig.MStringResource.GetText(TextType.Index_ExpireData) +
            //                ":" +
            //                indexDoc.TimeToLive.TotalSeconds, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //                (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        }
            //    }
            //    else
            //    {
            //        mongoIndex.Text = "IndexName:" + indexDoc.Name;
            //        mongoIndex.Nodes.Add(string.Empty, "Keys:" + GetKeyString(indexDoc.Key),
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "DroppedDups :" + indexDoc.DroppedDups,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "IsBackground:" + indexDoc.IsBackground,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "IsSparse:" + indexDoc.IsSparse,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "IsUnique:" + indexDoc.IsUnique,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "NameSpace:" + indexDoc.Namespace,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "Version:" + indexDoc.Version,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        if (indexDoc.TimeToLive == TimeSpan.MaxValue)
            //        {
            //            mongoIndex.Nodes.Add(string.Empty, "Expire Data:Not Set",
            //                (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        }
            //        else
            //        {
            //            mongoIndex.Nodes.Add(string.Empty, "Expire Data(sec):" + indexDoc.TimeToLive.TotalSeconds,
            //                (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        }
            //    }
            //    if (indexDoc.RawDocument.Contains("default_language"))
            //    {
            //        //TextIndex
            //        mongoIndex.Nodes.Add(string.Empty, "weights:" + indexDoc.RawDocument["weights"],
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "default_language:" + indexDoc.RawDocument["default_language"],
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "language_override:" + indexDoc.RawDocument["language_override"],
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty, "textIndexVersion:" + indexDoc.RawDocument["textIndexVersion"],
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //    }
            //    mongoIndex.ImageIndex = (int) GetSystemIcon.MainTreeImageType.DBKey;
            //    mongoIndex.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.DBKey;
            //    mongoIndex.Tag = ConstMgr.INDEX_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" + strColName +
            //                     "/" +
            //                     indexDoc.Name;
            //    mongoIndexes.Nodes.Add(mongoIndex);
            //}
            //mongoIndexes.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Keys;
            //mongoIndexes.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Keys;
            //mongoIndexes.Tag = ConstMgr.INDEXES_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" + strColName;
            //mongoColNode.Nodes.Add(mongoIndexes);
            ////End ListIndex

            //mongoColNode.ToolTipText = strColName + Environment.NewLine;
            //mongoColNode.ToolTipText += "IsCapped:" + mongoCol.GetStats().IsCapped;

            #endregion

            if (col.CollectionNamespace.CollectionName == ConstMgr.CollectionNameUser)
            {
                mongoColNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.UserIcon;
                mongoColNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.UserIcon;
            }
            else
            {
                mongoColNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Collection;
                mongoColNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Collection;
            }
            //End Data
            return mongoColNode;
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
                    ImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc,
                    SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.JsDoc,
                    Tag = tag + "/" + name
                };
                jsNode.Nodes.Add(node);
            }

            jsNode.ImageIndex = (int) GetSystemIcon.MainTreeImageType.Collection;
            jsNode.SelectedImageIndex = (int) GetSystemIcon.MainTreeImageType.Collection;
        }
    }
}