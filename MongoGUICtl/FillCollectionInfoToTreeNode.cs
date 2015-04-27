using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoUtility.Basic;
using ResourceLib.Utility;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace MongoGUICtl
{
    public static partial class UIHelper
    {
        /// <summary>
        /// 将数据集放入Node
        /// </summary>
        /// <param name="ICol"></param>
        /// <param name="mongoConnSvrKey"></param>
        /// <returns></returns>
        public static TreeNode FillCollectionInfoToTreeNode(IMongoCollection<BsonDocument> ICol, string mongoConnSvrKey)
        {
            var strShowColName = ICol.CollectionNamespace.CollectionName;
            var DatabaseName = ICol.CollectionNamespace.DatabaseNamespace.DatabaseName;
            if (!configuration.guiConfig.IsUseDefaultLanguage)
            {
                switch (strShowColName)
                {
                    case "chunks":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_chunks) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "collections":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_collections) + "(" + strShowColName + ")";
                        }
                        break;
                    case "changelog":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_changelog) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "databases":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_databases) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "lockpings":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_lockpings) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "locks":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_locks) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "mongos":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_mongos) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "settings":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_settings) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "shards":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_shards) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "tags":
                        //ADD: 2013/01/04 Mongo2.2.2开始支持ShardTag了 
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_tags) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "version":
                        if (DatabaseName == "config")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_version) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "me":
                        if (DatabaseName == "local")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_me) + "(" +
                                strShowColName + ")";
                        }
                        break;
                    case "sources":
                        if (DatabaseName == "local")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_sources) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case "slaves":
                        if (DatabaseName == "local")
                        {
                            strShowColName =
                                configuration.guiConfig.MStringResource.GetText(
                                    TextType.SYSTEMC_COLNAME_slaves) +
                                "(" + strShowColName + ")";
                        }
                        break;
                    case ConstMgr.COLLECTION_NAME_GFS_CHUNKS:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_GFS_CHUNKS) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_GFS_FILES:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_GFS_FILES) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_OPERATION_LOG:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_OPERATION_LOG) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_SYSTEM_INDEXES:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_SYSTEM_INDEXES) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_JAVASCRIPT:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_JAVASCRIPT) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_SYSTEM_REPLSET:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_SYSTEM_REPLSET) +
                            "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_REPLSET_MINVALID:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_REPLSET_MINVALID) + "(" + strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_USER:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(TextType.COLLECTION_NAME_USER) +
                            "(" +
                            strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_ROLE:
                        //New From 2.6 
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(TextType.COLLECTION_NAME_ROLE) +
                            "(" +
                            strShowColName + ")";
                        break;
                    case ConstMgr.COLLECTION_NAME_SYSTEM_PROFILE:
                        strShowColName =
                            configuration.guiConfig.MStringResource.GetText(
                                TextType.COLLECTION_NAME_SYSTEM_PROFILE) +
                            "(" + strShowColName + ")";
                        break;
                    default:
                        break;
                }
            }
            //Collection件数的表示
            long ColCount = 0;
            Expression<Func<BsonDocument, bool>> countfun = x => true;
            Task task = Task.Run(
                async () =>
                {
                    ColCount = await ICol.CountAsync(countfun);
                }
            );
            task.Wait();
            strShowColName = strShowColName + "(" + ColCount.ToString() + ")";
            var mongoColNode = new TreeNode(strShowColName);
            switch (ICol.CollectionNamespace.CollectionName)
            {
                case ConstMgr.COLLECTION_NAME_GFS_FILES:
                    mongoColNode.Tag = ConstMgr.GRID_FILE_SYSTEM_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" +
                                       ICol.CollectionNamespace.CollectionName;
                    break;
                case ConstMgr.COLLECTION_NAME_USER:
                    mongoColNode.Tag = ConstMgr.USER_LIST_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" +
                                       ICol.CollectionNamespace.CollectionName;
                    break;
                //case COLLECTION_NAME_ROLE:
                //    mongoColNode.Tag = USER_LIST_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" + strColName;
                //    break;
                default:
                    mongoColNode.Tag = ConstMgr.COLLECTION_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" +
                                       ICol.CollectionNamespace.CollectionName;
                    break;
            }

            //MongoCollection mongoCol = mongoDB.GetCollection(strColName);

            ////Start ListIndex
            //var mongoIndexes = new TreeNode("Indexes");
            //var indexList = mongoCol.GetIndexes();
            IAsyncCursor<BsonDocument> IndexCursor = null;
            task = Task.Run(
               async () =>
               {
                   IndexCursor = await ICol.Indexes.ListAsync();
               }
           );
            task.Wait();
            List<BsonDocument> IndexDoc = null;
            task = Task.Run(
               async () =>
               {
                   IndexDoc = await IndexCursor.ToListAsync();
               }
            );
            task.Wait();
            foreach (BsonDocument indexDoc in IndexDoc)
            {
                var mongoIndexes = new TreeNode();
                mongoIndexes.Text = indexDoc.GetElement("name").Value.ToString();
                foreach (var item in indexDoc.Elements)
                {
                    mongoIndexes.Nodes.Add(string.Empty, item.Name + ":" + item.Value.ToString(), (int)GetSystemIcon.MainTreeImageType.KeyInfo,
                        (int)GetSystemIcon.MainTreeImageType.KeyInfo);
                }
                mongoIndexes.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
                mongoIndexes.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Keys;
                mongoIndexes.Tag = ConstMgr.INDEXES_TAG + ":" + mongoConnSvrKey + "/" + DatabaseName + "/" + ICol.CollectionNamespace.CollectionName;
                mongoColNode.Nodes.Add(mongoIndexes);
            }

            #region Legacy
            //foreach (var indexDoc in indexList.ToList())
            //{
            //    var mongoIndex = new TreeNode();
            //    if (!configuration.guiConfig.IsUseDefaultLanguage)
            //    {
            //        mongoIndex.Text =
            //            (configuration.guiConfig.MStringResource.GetText(TextType.Index_Name) + ":" +
            //             indexDoc.Name);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_Keys) + ":" +
            //            GetKeyString(indexDoc.Key), (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_RepeatDel) + ":" +
            //            indexDoc.DroppedDups, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_Background) + ":" +
            //            indexDoc.IsBackground, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_Sparse) + ":" +
            //            indexDoc.IsSparse, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_Unify) + ":" +
            //            indexDoc.IsUnique, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_NameSpace) + ":" +
            //            indexDoc.Namespace, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        mongoIndex.Nodes.Add(string.Empty,
            //            configuration.guiConfig.MStringResource.GetText(TextType.Index_Version) + ":" +
            //            indexDoc.Version, (int) GetSystemIcon.MainTreeImageType.KeyInfo,
            //            (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        if (indexDoc.TimeToLive == TimeSpan.MaxValue)
            //        {
            //            mongoIndex.Nodes.Add(string.Empty,
            //                configuration.guiConfig.MStringResource.GetText(TextType.Index_ExpireData) +
            //                ":Not Set",
            //                (int) GetSystemIcon.MainTreeImageType.KeyInfo, (int) GetSystemIcon.MainTreeImageType.KeyInfo);
            //        }
            //        else
            //        {
            //            mongoIndex.Nodes.Add(string.Empty,
            //                configuration.guiConfig.MStringResource.GetText(TextType.Index_ExpireData) +
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

            if (ICol.CollectionNamespace.CollectionName == ConstMgr.COLLECTION_NAME_USER)
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

    }
}
