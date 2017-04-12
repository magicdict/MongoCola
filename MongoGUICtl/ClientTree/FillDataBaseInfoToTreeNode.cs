using System;
using System.Windows.Forms;
using Common;
using MongoDB.Driver;
using MongoUtility.Basic;
using MongoUtility.Command;
using MongoUtility.Core;
using ResourceLib.Method;

namespace MongoGUICtl.ClientTree
{
    public static partial class UiHelper
    {
        /// <summary>
        ///     将数据库放入Node
        /// </summary>
        /// <param name="strDbName"></param>
        /// <param name="mongoSvrKey"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static TreeNode FillDataBaseInfoToTreeNode(string strDbName, string mongoSvrKey,
            MongoClient client = null)
        {
            var strShowDbName = strDbName;
            switch (strDbName)
            {
                case ConstMgr.DatabaseNameAdmin:
                    strShowDbName = GuiConfig.GetText("admin", "databasename.admin") + "(" + strDbName + ")";
                    break;
                case "local":
                    strShowDbName = GuiConfig.GetText("local", "databasename.local") + "(" + strDbName + ")";
                    break;
                case "config":
                    strShowDbName = GuiConfig.GetText("config", "databasename.config") + "(" + strDbName + ")"; 
                    break;
            }
            var mongoDbNode = new TreeNode(strShowDbName)
            {
                Tag = TagInfo.CreateTagInfo(mongoSvrKey, strDbName)
            };

            //User Node
            var userNode = new TreeNode(GuiConfig.GetText("Users", "collectionName.system.users"), (int)GetSystemIcon.MainTreeImageType.UserIcon,
                (int)GetSystemIcon.MainTreeImageType.UserIcon)
            {
                Tag = ConstMgr.UserListTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                           ConstMgr.CollectionNameUsers
            };
            if (client.GetServer().GetDatabase(strDbName).CollectionExists(ConstMgr.CollectionNameUsers))
            {
                var usercol = ConnectionInfo.GetICollection(client, strDbName, ConstMgr.CollectionNameUsers);
                long colCount = ConnectionInfo.GetCollectionCnt(usercol);
                userNode.Text += "(" + colCount + ")";
            }
            mongoDbNode.Nodes.Add(userNode);

            var roleNode = new TreeNode(GuiConfig.GetText("Roles", "collectionName.system.roles"), (int)GetSystemIcon.MainTreeImageType.UserIcon,
                (int)GetSystemIcon.MainTreeImageType.UserIcon)
            {
                Tag = ConstMgr.RoleListTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                           ConstMgr.CollectionNameRoles
            };
            if (client.GetServer().GetDatabase(strDbName).CollectionExists(ConstMgr.CollectionNameRoles))
            {
                var rolescol = ConnectionInfo.GetICollection(client, strDbName, ConstMgr.CollectionNameRoles);
                long colCount = ConnectionInfo.GetCollectionCnt(rolescol);
                roleNode.Text += "(" + colCount + ")";
            }
            mongoDbNode.Nodes.Add(roleNode);


            //JsNode
            var jsNode = new TreeNode(GuiConfig.GetText("Javascript", "collectionName.system.Javascript"), (int)GetSystemIcon.MainTreeImageType.JavaScriptList,
                (int)GetSystemIcon.MainTreeImageType.JavaScriptList)
            {
                Tag = ConstMgr.JavascriptTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                         ConstMgr.CollectionNameJavascript
            };
            mongoDbNode.Nodes.Add(jsNode);

            //GFS Node
            var gfsNode = new TreeNode(GuiConfig.GetText("Grid File System"), (int)GetSystemIcon.MainTreeImageType.Gfs,
                (int)GetSystemIcon.MainTreeImageType.Gfs)
            {
                Tag = ConstMgr.GridFileSystemTag + ":" + mongoSvrKey + "/" + strDbName + "/" +
                          ConstMgr.CollectionNameGfsFiles
            };
            if (client.GetServer().GetDatabase(strDbName).CollectionExists(ConstMgr.CollectionNameGfsFiles))
            {
                var gfscol = ConnectionInfo.GetICollection(client, strDbName, ConstMgr.CollectionNameGfsFiles);
                long colCount = ConnectionInfo.GetCollectionCnt(gfscol);
                gfsNode.Text += "(" + colCount + ")";
            }
            mongoDbNode.Nodes.Add(gfsNode);

            var mongoSysColListNode = new TreeNode("Collections(System)",
                (int)GetSystemIcon.MainTreeImageType.SystemCol, (int)GetSystemIcon.MainTreeImageType.SystemCol)
            {
                Tag = ConstMgr.SystemCollectionListTag + ":" + mongoSvrKey + "/" + strDbName
            };
            mongoDbNode.Nodes.Add(mongoSysColListNode);

            var mongoColListNode = new TreeNode("Collections(General)",
                (int)GetSystemIcon.MainTreeImageType.CollectionList,
                (int)GetSystemIcon.MainTreeImageType.CollectionList)
            {
                Tag = ConstMgr.CollectionListTag + ":" + mongoSvrKey + "/" + strDbName
            };
            var colNameList = ConnectionInfo.GetCollectionInfoList(client, strDbName);
            //Collection按照名称排序
            colNameList.Sort((x, y) =>
            {
                return x.GetElement("name").Value.ToString().CompareTo(y.GetElement("name").Value.ToString());
            });

            var viewlist = ConnectionInfo.GetViewInfoList(client, strDbName);
            foreach (var colDoc in colNameList)
            {
                var strColName = colDoc.GetElement("name").Value.ToString();
                if (viewlist.Contains(strDbName + "." + strColName)) continue;
                switch (strColName)
                {
                    case ConstMgr.CollectionNameSystemViews:
                        //视图
                        TreeNode mongoViewNode;
                        var ViewCol = ConnectionInfo.GetICollection(client, strDbName, strColName);
                        mongoViewNode = FillViewInfoToTreeNode(ViewCol, ConstMgr.ViewTag + ":" + mongoSvrKey + "/" + strDbName + "/");
                        mongoViewNode.Tag = ConstMgr.ViewListTag + ":" + mongoSvrKey + "/" + strDbName;
                        mongoDbNode.Nodes.Add(mongoViewNode);
                        break;
                    case ConstMgr.CollectionNameUsers:
                    case ConstMgr.CollectionNameRoles:
                        break;
                    case ConstMgr.CollectionNameJavascript:
                        FillJavaScriptInfoToTreeNode(jsNode, ConnectionInfo.GetICollection(client, strDbName, strColName), mongoSvrKey, strDbName);
                        break;
                    case ConstMgr.CollectionNameGfsChunks:
                    case ConstMgr.CollectionNameGfsFiles:
                        var gfscol = ConnectionInfo.GetICollection(client, strDbName, strColName);
                        gfsNode.Nodes.Add(FillCollectionInfoToTreeNode(gfscol, mongoSvrKey));
                        break;
                    default:
                        TreeNode mongoColNode;
                        try
                        {
                            var col = ConnectionInfo.GetICollection(client, strDbName, strColName);
                            mongoColNode = FillCollectionInfoToTreeNode(col, mongoSvrKey);
                        }
                        catch (Exception ex)
                        {
                            mongoColNode = new TreeNode(strColName + "[exception:]")
                            {
                                ImageIndex = (int)GetSystemIcon.MainTreeImageType.Err,
                                SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Err
                            };
                            Utility.ExceptionDeal(ex);
                        }
                        if (Operater.IsSystemCollection(strDbName, strColName))
                        {
                            mongoSysColListNode.Nodes.Add(mongoColNode);
                        }
                        else
                        {
                            mongoColListNode.Nodes.Add(mongoColNode);
                        }
                        break;
                }
            }
            mongoDbNode.Nodes.Add(mongoColListNode);
            mongoDbNode.ImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
            mongoDbNode.SelectedImageIndex = (int)GetSystemIcon.MainTreeImageType.Database;
            return mongoDbNode;
        }
    }
}