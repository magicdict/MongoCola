/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2014/12/30
 * Time: 15:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common
{
    /// <summary>
    ///     数据库记录
    /// </summary>
    [Serializable]
    public class Model<T>
    {
        /// <summary>
        ///     数据
        /// </summary>
        public T DataRec;

        /// <summary>
        ///     统一编号
        /// </summary>
        public string DBId;

        /// <summary>
        ///     删除标志
        /// </summary>
        public Boolean IsDel;

        /// <summary>
        ///     最后更新时间
        /// </summary>
        public DateTime LastUpdate;
    }

    /// <summary>
    ///     数据库引擎
    /// </summary>
    public class XmlDataBase<T>
    {
        /// <summary>
        ///     数据库文件
        /// </summary>
        private readonly string DBfilename = string.Empty;

        /// <summary>
        ///     数据表
        /// </summary>
        private List<Model<T>> list = new List<Model<T>>();

        /// <summary>
        ///     数据库状态
        /// </summary>
        public string Status = "Close";

        /// <summary>
        ///     新建并且打开数据库
        /// </summary>
        /// <param name="xmlfilename"></param>
        public XmlDataBase(string xmlfilename)
        {
            DBfilename = xmlfilename;
            if (File.Exists(DBfilename))
            {
                list = Utility.LoadObjFromXml<List<Model<T>>>(DBfilename);
            }
        }

        /// <summary>
        ///     数据库记录数[Without IsDel]
        /// </summary>
        /// <returns></returns>
        public int getCount()
        {
            Refresh();
            return list.Count(x => !x.IsDel);
        }

        /// <summary>
        ///     数据库记录数[With IsDel]
        /// </summary>
        /// <returns></returns>
        public int getCountWithDel()
        {
            Refresh();
            return list.Count;
        }

        /// <summary>
        ///     刷新数据
        /// </summary>
        public void Refresh()
        {
            //非静态，所以，可能在其他地方发生了数据更新
            if (File.Exists(DBfilename))
            {
                list = Utility.LoadObjFromXml<List<Model<T>>>(DBfilename);
            }
        }

        /// <summary>
        ///     压缩数据库
        /// </summary>
        public void Compress()
        {
            var Compresslist = new List<Model<T>>();
            Func<Model<T>, Boolean> inner = x => (!x.IsDel);
            Compresslist = list.FindAll(new Predicate<Model<T>>(inner));
            list = Compresslist;
            Commit();
        }

        /// <summary>
        ///     添加
        /// </summary>
        /// <param name="rec"></param>
        public void AppendRec(T rec)
        {
            var dbrec = new Model<T>();
            dbrec.DBId = Guid.NewGuid().ToString();
            dbrec.DataRec = Utility.DeepCopy(rec);
            dbrec.LastUpdate = DateTime.Now;
            list.Add(dbrec);
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="rec"></param>
        public void DelRec(Model<T> rec)
        {
            rec.IsDel = true;
            UpdateDB(Utility.DeepCopy(rec));
        }

        /// <summary>
        ///     删除制定编号数据
        /// </summary>
        /// <param name="DBId"></param>
        public void DelRecByDBID(String DBId)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (DBId == list[i].DBId)
                {
                    list[i].IsDel = true;
                    list[i].LastUpdate = DateTime.Now;
                    break;
                }
            }
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="rec"></param>
        public void UpdataRec(Model<T> rec)
        {
            UpdateDB(Utility.DeepCopy(rec));
        }

        /// <summary>
        ///     数据的修改
        /// </summary>
        /// <param name="rec">传递过来对象的深拷贝</param>
        private void UpdateDB(Model<T> rec)
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (rec.DBId == list[i].DBId)
                {
                    rec.LastUpdate = DateTime.Now;
                    //不允许内部数据使用外部数据的指针引用
                    //这里使用深拷贝					
                    list[i] = rec;
                    break;
                }
            }
        }

        /// <summary>
        ///     提交更新
        /// </summary>
        public void Commit()
        {
            Utility.SaveObjAsXml(DBfilename, list);
        }

        /// <summary>
        ///     检索
        /// </summary>
        /// <param name="SearchMethod"></param>
        /// <returns>数据对象的深拷贝</returns>
        public List<Model<T>> SearchAsDBRecord(Func<T, Boolean> SearchMethod)
        {
            Refresh();
            Func<Model<T>, Boolean> inner = x => (SearchMethod(x.DataRec) && !x.IsDel);
            var t = new List<Model<T>>();
            foreach (var element in list.FindAll(new Predicate<Model<T>>(inner)))
            {
                //这里也是将数据的副本给与外部
                t.Add(Utility.DeepCopy(element));
            }
            return t;
        }

        /// <summary>
        ///     检索
        /// </summary>
        /// <param name="SearchMethod"></param>
        /// <returns>数据对象的深拷贝</returns>
        public List<T> SearchAsSimpleRecord(Func<T, Boolean> SearchMethod)
        {
            Refresh();
            Func<Model<T>, Boolean> inner = x => (SearchMethod(x.DataRec) && !x.IsDel);
            var t = new List<T>();
            foreach (var element in list.FindAll(new Predicate<Model<T>>(inner)))
            {
                //这里也是将数据的副本给与外部
                t.Add(Utility.DeepCopy(element.DataRec));
            }
            return t;
        }

        /// <summary>
        ///     检索（根据数据号）
        /// </summary>
        /// <param name="DBID">数据号</param>
        /// <returns></returns>
        public Model<T> SearchAsDBRecordByDBID(String DBID)
        {
            Refresh();
            var result = list.Find(x => x.DBId == DBID && !x.IsDel);
            if (result != null)
                return Utility.DeepCopy(result);
            return null;
        }

        /// <summary>
        ///     是否存在数据
        /// </summary>
        /// <param name="SearchMethod"></param>
        /// <returns></returns>
        public bool IsRecordExists(Func<T, Boolean> SearchMethod)
        {
            Func<Model<T>, Boolean> inner = x => (SearchMethod(x.DataRec) && !x.IsDel);
            return list.FindAll(new Predicate<Model<T>>(inner)).Count != 0;
        }

        /// <summary>
        ///     是否存在指定番号数据
        /// </summary>
        /// <param name="DBID"></param>
        /// <returns></returns>
        public bool IsRecordExistsByDBID(String DBID)
        {
            Func<Model<T>, Boolean> inner = x => (x.DBId == DBID && !x.IsDel);
            return list.FindAll(new Predicate<Model<T>>(inner)).Count != 0;
        }

        /// <summary>
        ///     检索（根据数据号）
        ///     调用前请使用IsRecordExist函数确认数据是否存在
        /// </summary>
        /// <param name="DBID">数据号</param>
        /// <returns></returns>
        public T SearchAsSimpleRecordByDBID(String DBID)
        {
            Refresh();
            var result = list.Find(x => x.DBId == DBID);
            return Utility.DeepCopy(result.DataRec);
        }
    }
}