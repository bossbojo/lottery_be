using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lottery.WebAPI.Entity;
namespace Lottery.WebAPI.Authentication
{
    public class Authentication
    {
        private static string _Token = null;
        private static User _User = null;

        public int? username { get; set; }
        public string name { get; set; }
        public int? Countday { get; set; }
        public DateTime ep_day { get; set; }
        public long exp { get; set; }

        public static string Token { get { return Authentication._Token; } }

        public static User User
        {
            get { return Authentication._User; }
        }

        public static string SetAuthenticated(User custObj, int time = 60*24*365)
        {
            if (custObj == null)
            {
                Authentication._User = null;
                Authentication._Token = null;
                return null;
            }

            Authentication._Token = Securities.JWTEncode(
            new Authentication
            {
                username = custObj.username,
                Countday = custObj.Count_Expire_day,
                ep_day = custObj.Expire_dt,
                exp = GetNow.AddMinutes(time).ToBinary()
            });
            Authentication._User = custObj;

            return Authentication._Token;
        }

        // Check time of Token if time to the end
        public static bool HasToken(Authentication auth)
        {
            if (auth != null)
                return new DateTime(auth.exp) >= Authentication.GetNow;
            return false;
        }

        // Set Time Zone
        public static DateTime GetNow
        {
            get
            {
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                return TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
            }
        }
    }
}