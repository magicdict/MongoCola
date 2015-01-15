using MongoDB.Bson;
using MongoDB.Driver;
using MongoUtility.Command;
using ResourceLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace MongoGUICtl
{
	public static class FillMongoDB
	{
		#region"展示状态"

		/// <summary>
		///     Fill Server Status to treeview
		/// </summary>
		/// <param name="trvSvrStatus"></param>
		public  static void FillSrvStatusToList(ctlTreeViewColumns trvSvrStatus,
			Dictionary<String, MongoServer> _mongoConnSvrLst)
		{
			var SrvDocList = new List<BsonDocument>();
			foreach (string mongoSvrKey in _mongoConnSvrLst.Keys) {
				try {
					MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
					if (!MongoUtility.Core.RuntimeMongoDBContext.GetServerConfigBySvrPath(mongoSvrKey).Health) {
						continue;
					}
					//flydreamer提供的代码
					// 感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
					if (MongoUtility.Core.RuntimeMongoDBContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin) {
						BsonDocument ServerStatusDoc = CommandHelper.ExecuteMongoSvrCommand(CommandHelper.serverStatus_Command, mongoSvr).Response;
						SrvDocList.Add(ServerStatusDoc);
					}
				} catch (Exception ex) {
					Common.Utility.ExceptionDeal(ex);
				}
			}
			MongoGUICtl.UIHelper.FillDataToTreeView("Server Status", trvSvrStatus, SrvDocList, 0);
			//打开第一层
			foreach (TreeNode item in trvSvrStatus.DatatreeView.Nodes) {
				item.Expand();
			}
		}

		/// <summary>
		///     Fill Database status to ListView
		/// </summary>
		/// <param name="lstSvr"></param>
		public  static void FillDataBaseStatusToList(ListView lstSvr, Dictionary<String, MongoServer> _mongoConnSvrLst)
		{
			lstSvr.Clear();
			lstSvr.Columns.Add(configuration.guiConfig.GetText("DataBaseName", StringResource.TextType.DataBase_Status_DataBaseName));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("CollectionCount", StringResource.TextType.DataBase_Status_CollectionCount));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("DataSize", StringResource.TextType.DataBase_Status_DataSize));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("FileSize", StringResource.TextType.DataBase_Status_FileSize));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("IndexCount", StringResource.TextType.DataBase_Status_IndexCount));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("IndexSize", StringResource.TextType.DataBase_Status_IndexSize));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("ObjectCount", StringResource.TextType.DataBase_Status_ObjectCount));
			lstSvr.Columns.Add(configuration.guiConfig.GetText("StorageSize", StringResource.TextType.DataBase_Status_StorageSize));
			foreach (string mongoSvrKey in _mongoConnSvrLst.Keys) {
				try {
					MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
					//感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
					if (!MongoUtility.Core.RuntimeMongoDBContext.GetServerConfigBySvrPath(mongoSvrKey).Health ||
					                   !MongoUtility.Core.RuntimeMongoDBContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin) {
						continue;
					}
					List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList();
					foreach (string strDBName in databaseNameList) {
						MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);
						DatabaseStatsResult dbStatus = mongoDB.GetStats();
						var lst = new ListViewItem(mongoSvrKey + "." + strDBName);
						try {
							lst.SubItems.Add(dbStatus.CollectionCount.ToString());
						} catch (Exception) {
							lst.SubItems.Add("0");
						}
						lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(dbStatus.DataSize));
						lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(dbStatus.FileSize));
						lst.SubItems.Add(dbStatus.IndexCount.ToString());
						lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(dbStatus.IndexSize));
						lst.SubItems.Add(dbStatus.ObjectCount.ToString());
						lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(dbStatus.StorageSize));
						lstSvr.Items.Add(lst);
					}
				} catch (Exception ex) {
					Common.Utility.ExceptionDeal(ex);
				}
			}
			lstSvr.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		/// <summary>
		///     fill Collection status to ListView
		/// </summary>
		/// <param name="lstData"></param>
		public static void FillCollectionStatusToList(ListView lstData, Dictionary<String, MongoServer> _mongoConnSvrLst)
		{
			lstData.Clear();

			if (configuration.guiConfig.IsUseDefaultLanguage) {
				lstData.Columns.Add("CollectionName");
				lstData.Columns.Add("ObjectCount");
				lstData.Columns.Add("DataSize");
				lstData.Columns.Add("LastExtentSize");
				lstData.Columns.Add("StorageSize");
				lstData.Columns.Add("TotalIndexSize");
				lstData.Columns.Add("IsCapped");
				lstData.Columns.Add("MaxDocuments");
				lstData.Columns.Add("AverageObjectSize");
				lstData.Columns.Add("PaddingFactor");
			} else {
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_CollectionName));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_ObjectCount));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_DataSize));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_LastExtentSize));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_StorageSize));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_TotalIndexSize));

				//2012-3-6
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_IsCapped));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_MaxDocuments));


				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_AverageObjectSize));
				lstData.Columns.Add(
					configuration.guiConfig.MStringResource.GetText(StringResource.TextType.Collection_Status_PaddingFactor));
			}
			foreach (string mongoSvrKey in _mongoConnSvrLst.Keys) {
				try {
					MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
					//感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
					if (!MongoUtility.Core.RuntimeMongoDBContext.GetServerConfigBySvrPath(mongoSvrKey).Health ||
					                   !MongoUtility.Core.RuntimeMongoDBContext.GetServerConfigBySvrPath(mongoSvrKey).LoginAsAdmin) {
						continue;
					}
					List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList();
					foreach (string strDBName in databaseNameList) {
						MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);

						List<string> colNameList = mongoDB.GetCollectionNames().ToList();
						foreach (string strColName in colNameList) {
							try {
								CollectionStatsResult CollectionStatus = mongoDB.GetCollection(strColName).GetStats();
								var lst = new ListViewItem(mongoSvrKey + "." + strDBName + "." + strColName);
								lst.SubItems.Add(CollectionStatus.ObjectCount.ToString());
								lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(CollectionStatus.DataSize));
								lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(CollectionStatus.LastExtentSize));
								lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(CollectionStatus.StorageSize));
								lst.SubItems.Add(MongoUtility.Basic.Utility.GetBsonSize(CollectionStatus.TotalIndexSize));

								//2012-3-6
								lst.SubItems.Add(CollectionStatus.IsCapped.ToString());
								//https://jira.mongodb.org/browse/CSHARP-665
								try {
									//注意：这个MaxDocuments只是在CappedCollection时候有效
									lst.SubItems.Add(CollectionStatus.MaxDocuments.ToString());
								} catch (Exception ex) {
									//溢出
									lst.SubItems.Add(int.MaxValue.ToString());
									Common.Utility.ExceptionLog(ex);
								}

								lst.SubItems.Add(CollectionStatus.ObjectCount != 0
                                    ? MongoUtility.Basic.Utility.GetBsonSize((long)CollectionStatus.AverageObjectSize)
                                    : "0");

								try {
									//在某些条件下，这个值会抛出异常，IndexKeyNotFound
									lst.SubItems.Add(CollectionStatus.PaddingFactor.ToString());
								} catch (Exception) {
									lst.SubItems.Add("0");
								}
								lstData.Items.Add(lst);
							} catch (Exception ex) {
								//throw;
								//TODO:排序时候会发生错误，所以暂时不对应
								//lstData.Items.Add(new ListViewItem(strColName + "[Exception]"));
								Common.Utility.ExceptionDeal(ex);
							}
						}
					}
				} catch (Exception ex) {
					Common.Utility.ExceptionDeal(ex);
				}
			}
			lstData.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		/// <summary>
		///     将数据Opr放入ListView
		/// </summary>
		/// <param name="lstSrvOpr"></param>
		public static void FillCurrentOprToList(ListView lstSrvOpr,
			Dictionary<String, MongoServer> _mongoConnSvrLst)
		{
			lstSrvOpr.Clear();
			lstSrvOpr.Columns.Add("Name");
			lstSrvOpr.Columns.Add("opid");
			lstSrvOpr.Columns.Add("active");
			lstSrvOpr.Columns.Add("lockType");
			lstSrvOpr.Columns.Add("waitingForLock");
			lstSrvOpr.Columns.Add("secs_running");
			lstSrvOpr.Columns.Add("op");
			lstSrvOpr.Columns.Add("ns");
			lstSrvOpr.Columns.Add("query");
			lstSrvOpr.Columns.Add("client");
			lstSrvOpr.Columns.Add("desc");
			lstSrvOpr.Columns.Add("connectionId");
			lstSrvOpr.Columns.Add("numYields");

			foreach (string mongoSvrKey in _mongoConnSvrLst.Keys) {
				try {
					MongoServer mongoSvr = _mongoConnSvrLst[mongoSvrKey];
					//感谢 魏琼东 的Bug信息,一些命令必须以Admin执行
//                    if (!Init.SystemManager.GetCurrentServerConfig(mongoSvrKey).Health ||
//                        !Init.SystemManager.GetCurrentServerConfig(mongoSvrKey).LoginAsAdmin)
//                    {
//                        continue;
//                    }
					List<string> databaseNameList = mongoSvr.GetDatabaseNames().ToList();
					foreach (string strDBName in databaseNameList) {
						try {
							MongoDatabase mongoDB = mongoSvr.GetDatabase(strDBName);
							BsonDocument dbStatus = mongoDB.GetCurrentOp();
							BsonArray doc = dbStatus.GetValue("inprog").AsBsonArray;
							foreach (BsonDocument item in doc) {
								var lst = new ListViewItem(mongoSvrKey + "." + strDBName);
								foreach (string itemName in item.Names) {
									lst.SubItems.Add(item.GetValue(itemName).ToString());
								}
								lstSrvOpr.Items.Add(lst);
							}
						} catch (Exception ex) {
							Common.Utility.ExceptionDeal(ex);
						}
					}
				} catch (Exception ex) {
					Common.Utility.ExceptionDeal(ex);
				}
			}
			lstSrvOpr.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		#endregion

		#region "辅助方法和排序器"
		public class lvwColumnSorter : IComparer
		{
			/// <summary>
			///     比较方式
			/// </summary>
			public enum SortMethod
			{
				StringCompare,
				SizeCompare,
				NumberCompare
			}

			/// <summary>
			///     声明CaseInsensitiveComparer类对象
			/// </summary>
			private readonly CaseInsensitiveComparer ObjectCompare;
			/// <summary>
			///     构造函数
			/// </summary>
			public lvwColumnSorter()
			{
				SortColumn = 0; // 默认按第一列排序            
				Order = SortOrder.None; // 排序方式为不排序            
				ObjectCompare = new CaseInsensitiveComparer(); // 初始化CaseInsensitiveComparer类对象
				CompareMethod = SortMethod.StringCompare; //是否使用Size比较
			}

			public SortMethod CompareMethod {
				set;
				get;
			}

			/// 获取或设置按照哪一列排序.
			public int SortColumn {
				set;
				get;
			}

			/// 获取或设置排序方式.
			public SortOrder Order {
				set;
				get;
			}

			/// <summary>
			///     比较
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <returns></returns>
			public int Compare(object x, object y)
			{
				var lstX = (ListViewItem)x;
				var lstY = (ListViewItem)y;
				int rtnCompare = 0;
				switch (CompareMethod) {
					case SortMethod.StringCompare:
						rtnCompare = ObjectCompare.Compare(lstX.SubItems[SortColumn].Text,
							lstY.SubItems[SortColumn].Text);
						break;
					case SortMethod.SizeCompare:
						rtnCompare =
                            (int)
                                (Common.Utility.ReconvSize(lstX.SubItems[SortColumn].Text) -
						Common.Utility.ReconvSize(lstY.SubItems[SortColumn].Text));
						break;
					case SortMethod.NumberCompare:
                        //当两个数字相减小于1时，(int)的强制转换会将结果变成0，所以不能使用减法来获得Ret。。。
						if (Convert.ToDouble(lstX.SubItems[SortColumn].Text) >
						                      Convert.ToDouble(lstY.SubItems[SortColumn].Text)) {
							rtnCompare = 1;
						} else {
							if (Convert.ToDouble(lstX.SubItems[SortColumn].Text) ==
							                         Convert.ToDouble(lstY.SubItems[SortColumn].Text)) {
								rtnCompare = 0;
							} else {
								rtnCompare = -1;
							}
						}
						break;
				}
				if (Order == SortOrder.Descending) {
					rtnCompare = rtnCompare * -1;
				}
				return rtnCompare;
			}
		}

		#endregion
	}
}