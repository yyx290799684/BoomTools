using BoomTools.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoomTools
{
    public class DateHelper
    {
        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetNowTimeStamp()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
            return timeStamp;
        }

        /// <summary>
        /// 时间戳转为DateTime时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime TimeStampToDateTime(string timeStamp)
        {
            DateTime dtStart = (new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return (dtStart.Add(toNow).ToLocalTime());
        }

        /// <summary>
        /// DateTime时间转为时间戳
        /// </summary>
        /// <returns></returns>
        public static long DateTimeToTimeStamp(System.DateTime date)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(date); // 当地时区
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
            return timeStamp;
        }

        /// <summary>
        /// 获取当前时区信息
        /// </summary>
        /// <returns></returns>
        public static string GetTimeZoneInfo()
        {
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.Local;
            string tz;
            TimeZoneList.WindowsTimes.TryGetValue(timeZoneInfo.Id, out tz);
            return tz;
        }

        /// <summary>
        /// 日期是否为空
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsEmptyDate(DateTime date)
        {
            if (date == null || date.Year == 0001)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 日期是否为空
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsEmptyDate(DateTime? date)
        {
            if (date == null || date.Value.Year == 0001)
            {
                return true;
            }

            return false;
        }
    }
}
