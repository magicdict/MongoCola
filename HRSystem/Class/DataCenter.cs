using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using MongoDB.Driver;

namespace HRSystem
{
    public class DataCenter
    {
        /// <summary>
        /// Hiring Track Data
        /// </summary>
        public static List<HiringTracking> HiringTrackingDataSet = new List<HiringTracking>();
        /// <summary>
        /// PositionBasicInfo Data
        /// </summary>
        public static List<PositionBasicInfo> PositionBasicDataSet = new List<PositionBasicInfo>();
        /// <summary>
        /// BackUp
        /// </summary>
        public static void BackUp()
        {
            MongoServer innerServer;
            innerServer = MongoServer.Create(@"mongodb://121.199.16.71:28030");
            innerServer.Connect();
            MongoDatabase LogDB = innerServer.GetDatabase("HRSystem");
            MongoCollection HiringTrackingCol = LogDB.GetCollection("HiringTracking");
            HiringTrackingCol.RemoveAll();
            HiringTrackingCol.InsertBatch<HiringTracking>(HiringTrackingDataSet);
            MongoCollection PositionCol = LogDB.GetCollection("PositionBasic");
            PositionCol.RemoveAll();
            PositionCol.InsertBatch<PositionBasicInfo>(PositionBasicDataSet);
        }
        /// <summary>
        /// Init
        /// </summary>
        public static void Init()
        {
            HiringTrackingDataSet.Clear();
            SaveHiringTrack();
            PositionBasicDataSet.Clear();
            SaveBasicPosition();
        }
        /// <summary>
        /// 根据职位名称获得职位基本信息
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static PositionBasicInfo GetBasicPositionInfo(string Position)
        {
            PositionBasicInfo t = new PositionBasicInfo();
            t = PositionBasicDataSet.Find((x) => { return x.isOpen && x.Position == Position; });
            return t;
        }
        /// <summary>
        /// Save Basic Position Info
        /// </summary>
        public static void SaveBasicPosition()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<PositionBasicInfo>));
            var writer = new StreamWriter(SystemManager.PositionBasicInfoXmlFilename);
            xml.Serialize(writer, DataCenter.PositionBasicDataSet);
            writer.Close();
        }

        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByPosition(string Position)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.Position == Position && !p.IsDel
                      select p;
            return pos.ToList();
        }
        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByFinalStatus(HiringTracking.FinalStatusEnum status)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.FinalStatus == status && !p.IsDel
                      select p;
            return pos.ToList();
        }
        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByPosition(string Position, HiringTracking.FinalStatusEnum FinalStatus)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.Position == Position && p.FinalStatus == FinalStatus && !p.IsDel
                      select p;
            return pos.ToList();
        }

        /// <summary>
        /// 没有删除的全部
        /// </summary>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackingDataSet(bool isDelete = false)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.IsDel == isDelete
                      select p;
            return pos.ToList();
        }

        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByScreenDate(DateTime Start, DateTime End)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.ScreenDate.Date >= Start.Date && p.ScreenDate.Date <= End.Date && !p.IsDel
                      select p;
            return pos.ToList();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        public static void SaveHiringTrack()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<HiringTracking>));
            var writer = new StreamWriter(SystemManager.HiringTrackingXmlFilename);
            xml.Serialize(writer, HiringTrackingDataSet);
            writer.Close();
        }
        #region"Statistic Info"
        /// <summary>
        /// PositionStatistic Data
        /// </summary>
        public static List<PositionStatistic> PositionStatisticDataSet = new List<PositionStatistic>();
        /// <summary>
        /// Get StatisticInfo By Position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static PositionStatistic GetPositionStatisticInfo(string position)
        {
            PositionStatistic t = new PositionStatistic();
            t = PositionStatisticDataSet.Find((x) => { return x.BasicInfo.isOpen && x.BasicInfo.Position == position; });
            return t;
        }
        /// <summary>
        /// Group By Position
        /// </summary>
        public static void ReCalulatePositionStatisti(ViewControl.PositionDelegate condition)
        {
            PositionStatisticDataSet.Clear();
            //Total Rec
            List<HiringTracking> candideate = new List<HiringTracking>();
            PositionStatistic total = new PositionStatistic();
            total.BasicInfo = new PositionBasicInfo();
            total.BasicInfo.Position = SystemManager.strTotal;
            total.BasicInfo.Target = PositionBasicDataSet.Sum((x) =>
            {
                if (x.isOpen && condition(x))
                {
                    candideate.AddRange((from p in HiringTrackingDataSet
                                         where !p.IsDel && p.Position == x.Position
                                         select p).ToList());
                    return x.Target;
                }
                else
                {
                    return 0;
                }
            });
            ///Total Info Statistic 
            Statistic(candideate.ToList(), total);
            PositionStatisticDataSet.Add(total);

            foreach (var item in PositionBasicDataSet)
            {
                if (!item.isOpen) continue;
                PositionStatistic t = new PositionStatistic();
                t.BasicInfo = item;
                var posItems = from p in HiringTrackingDataSet
                               where p.Position == item.Position && !p.IsDel
                               select p;
                ///Position Info Statistic 
                Statistic(posItems.ToList(), t);
                PositionStatisticDataSet.Add(t);
            }
        }
        /// <summary>
        /// Get Statistic Info
        /// </summary>
        /// <param name="candideate"></param>
        /// <param name="t"></param>
        private static void Statistic(List<HiringTracking> candideate, PositionStatistic t)
        {
            t.Pipeline = candideate.Count();
            var firstInterview = from p in candideate
                                 where p.FirstInterviewDate != DateTime.MinValue && !p.IsDel
                                 select p;
            var secondInterview = from p in candideate
                                  where p.SecondInterviewDate != DateTime.MinValue && !p.IsDel
                                  select p;
            var thirdInterview = from p in candideate
                                 where p.ThirdInterviewDate != DateTime.MinValue && !p.IsDel
                                 select p;

            var firstInterviewPass = from p in candideate
                                     where HiringTracking.InterviewPassCheck(p.FirstInterviewResult) && !p.IsDel
                                     select p;
            var secondInterviewPass = from p in candideate
                                      where HiringTracking.InterviewPassCheck(p.SecondInterviewResult) && !p.IsDel
                                      select p;
            var thirdInterviewPass = from p in candideate
                                     where HiringTracking.InterviewPassCheck(p.ThirdInterviewResult) && !p.IsDel
                                     select p;


            if (t.Pipeline != 0)
            {
                t.CVpass = t.Pipeline / firstInterview.Count();
            }
            t.FirstInterviewCount = firstInterview.Count();
            t.SecondInterviewCount = secondInterview.Count();
            t.ThirdInterviewCount = thirdInterview.Count();
            t.FirstPass = firstInterviewPass.Count();
            t.SecondPass = secondInterviewPass.Count();
            t.ThirdPass = thirdInterviewPass.Count();

            var Onboard = from p in candideate
                          where p.FinalStatus == HiringTracking.FinalStatusEnum.Onboard && !p.IsDel
                          select p;
            t.Onboard = Onboard.Count();

            var RejectOffer = from p in candideate
                              where p.FinalStatus == HiringTracking.FinalStatusEnum.RejectOffer && !p.IsDel
                              select p;
            t.RejectOffer = RejectOffer.Count();

            var OpenOffer = from p in candideate
                            where p.FinalStatus == HiringTracking.FinalStatusEnum.OpenOffer && !p.IsDel
                            select p;
            t.OpenOffer = OpenOffer.Count();

            var ANOB = from p in candideate
                       where p.FinalStatus == HiringTracking.FinalStatusEnum.ANOB && !p.IsDel
                       select p;
            t.ANOB = ANOB.Count();
        }
        #endregion
    }
}
