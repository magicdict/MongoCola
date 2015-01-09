/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/6
 * Time: 11:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MongoCola.Module;
using MongoUtility.Basic;

namespace MongoUtility.Aggregation
{
	/// <summary>
	///     多数据集视图中，每个数据集保留一个DataViewInfo
	/// </summary>
	public class DataViewInfo
	{
		/// <summary>
		///     数据集总记录数
		/// </summary>
		public int CurrentCollectionTotalCnt;

		/// <summary>
		///     解释
		/// </summary>
		public string Explain;

		/// <summary>
		///     是否存在下一页
		/// </summary>
		public bool HasNextPage;

		/// <summary>
		///     是否存在上一页
		/// </summary>
		public bool HasPrePage;

		/// <summary>
		///     是否为只读
		/// </summary>
		public bool IsReadOnly;

		/// <summary>
		///     是否为SafeMode
		/// </summary>
		public bool IsSafeMode;

		/// <summary>
		///     是否使用过滤器
		/// </summary>
		public bool IsUseFilter;

		/// <summary>
		///     每页显示数
		/// </summary>
		public int LimitCnt;

		/// <summary>
		///     查询
		/// </summary>
		public string Query;

		/// <summary>
		///     Skip记录数
		/// </summary>
		public int SkipCnt;

		/// <summary>
		///     数据过滤器
		/// </summary>
		public DataFilter mDataFilter;
		/// <summary>
		/// 数据库
		/// </summary>
		public string strDBTag;

		/// <summary>
		///     是否为Admin数据库
		/// </summary>
		public bool IsAdminDB {
			get {
				string strNodeData = strDBTag.Split(":".ToCharArray())[1];
				string[] DataList = strNodeData.Split("/".ToCharArray());
				if (DataList[(int)EnumMgr.PathLv.DatabaseLv] == ConstMgr.DATABASE_NAME_ADMIN) {
					return true;
				}
				return false;
			}
		}

		/// <summary>
		///     是否为系统数据集
		/// </summary>
		public bool IsSystemCollection {
			get {
				string strNodeData = strDBTag.Split(":".ToCharArray())[1];
				string[] DataList = strNodeData.Split("/".ToCharArray());
				return MongoDbHelper.IsSystemCollection(DataList[(int)EnumMgr.PathLv.DatabaseLv],
					DataList[(int)EnumMgr.PathLv.CollectionLv]);
			}
		}
	}
}
