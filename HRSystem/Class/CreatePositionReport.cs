using System;
using System.Collections.Generic;
using System.Linq;
namespace HRSystem
{
    public class CreatePositionReport
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
        /// PositionStatistic Data
        /// </summary>
        public static List<PositionStatistic> PositionStatisticDataSet = new List<PositionStatistic>();
        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByPosition(string Position)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.Position == Position
                      select p;
            return pos.ToList<HiringTracking>();
        }
        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByFinalStatus(HiringTracking.FinalStatusEnum status)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.FinalStatus == status
                      select p;
            return pos.ToList<HiringTracking>();
        }
        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByPosition(string Position,HiringTracking.FinalStatusEnum FinalStatus)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.Position == Position && p.FinalStatus == FinalStatus
                      select p;
            return pos.ToList<HiringTracking>();
        }
        /// <summary>
        /// 根据职位获得Hiring
        /// </summary>
        /// <param name="Position"></param>
        /// <returns></returns>
        public static List<HiringTracking> GetHiringTrackByScreenDate(DateTime Start,DateTime End)
        {
            var pos = from p in HiringTrackingDataSet
                      where p.ScreenDate.Date >= Start.Date && p.ScreenDate.Date <= End.Date
                      select p;
            return pos.ToList<HiringTracking>();
        }
        /// <summary>
        /// Group By Position
        /// </summary>
        public static void ReCompute()
        {
            PositionStatisticDataSet.Clear();
            //Total Rec
            PositionStatistic total = new PositionStatistic();
            total.BasicInfo = new PositionBasicInfo();
            total.BasicInfo.No = SystemManager.strTotal;
            total.BasicInfo.Target = PositionBasicDataSet.Sum((x)=> {
                if (x.isOpen)
                {
                    return x.Target;
                }else
                {
                    return 0;
                }
            });
            var pos = from p in HiringTrackingDataSet
                      select p;
            Statistic(pos.ToList<HiringTracking>(), total);
            PositionStatisticDataSet.Add(total);

            foreach (var item in PositionBasicDataSet)
            {
                if (!item.isOpen) continue;
                PositionStatistic t = new PositionStatistic();
                t.BasicInfo = item;
                var posItems = from p in HiringTrackingDataSet
                          where p.Position == item.Position
                          select p;
                Statistic(posItems.ToList<HiringTracking>(), t);
                PositionStatisticDataSet.Add(t);
            }
        }

        private static void Statistic(List<HiringTracking> pos, PositionStatistic t)
        {
            t.Pipeline = pos.Count();
            var firstInterview = from p in pos
                                 where p.FirstInterviewDate != System.DateTime.MinValue
                                 select p;
            var secondInterview = from p in pos
                                  where p.SecondInterviewDate != System.DateTime.MinValue
                                  select p;
            var thirdInterview = from p in pos
                                 where p.ThirdInterviewDate != System.DateTime.MinValue
                                 select p;

            var firstInterviewPass = from p in pos
                                     where HiringTracking.InterviewPassCheck(p.FirstInterviewResult)
                                     select p;
            var secondInterviewPass = from p in pos
                                      where HiringTracking.InterviewPassCheck(p.SecondInterviewResult)
                                      select p;
            var thirdInterviewPass = from p in pos
                                     where HiringTracking.InterviewPassCheck(p.ThirdInterviewResult)
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

            var Onboard = from p in pos
                          where p.FinalStatus == HiringTracking.FinalStatusEnum.Onboard
                          select p;
            t.Onboard = Onboard.Count();

            var RejectOffer = from p in pos
                              where p.FinalStatus == HiringTracking.FinalStatusEnum.RejectOffer
                              select p;
            t.RejectOffer = RejectOffer.Count();

            var OpenOffer = from p in pos
                            where p.FinalStatus == HiringTracking.FinalStatusEnum.OpenOffer
                            select p;
            t.OpenOffer = OpenOffer.Count();
        }
    }
}
