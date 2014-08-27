using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRSystem
{
    public static class ViewStyleSheet
    {
        /// <summary>
        /// Column 
        /// </summary>
        public enum ColPos
        {
            No = 2,
            Name,
            Position,
            Channel,
            PhoneNumber,
            University,
            Language_EN,
            Language_CN,
            Language_JP,
            Language_KR,
            Language_Other,
            MarketBackground,
            ITBakcground,
            ScreenData,

            firstInterviewDate,
            firstInterviewer,
            firstInterviewresult,

            secondInterviewDate,
            secondInterviewer,
            secondInterviewresult,

            thirdInterviewDate,
            thirdInterviewer,
            thirdInterviewresult,

            offerofferdate,
            onboarddate,
            rejectofferreason,
            finalstatus
        }
        /// <summary>
        /// OnBord
        /// </summary>
        public static string[] HiringTracking_OnboardSytle = new string[]
        {
            "No",
            "Name",
            "Contact",
            "Language",
            "1st Interviewer",
            "2nd Interviewer",
            "3rd Interviewer",
            "Final Status",
            "Offer offer date",
            "Onboard date",
        };

        public static string[] HiringTracking_RejectOfferSytle = new string[]
        {
            "No",
            "Name",
            "Contact",
            "Language",
            "1st Interviewer",
            "2nd Interviewer",
            "3rd Interviewer",
            "Final Status",
            "Offer offer date",
            "Onboard date",
            "Reject offer reason"
        };

        

    }
}
