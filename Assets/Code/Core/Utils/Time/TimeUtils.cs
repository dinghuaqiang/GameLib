using System;
using System.Text;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 时间的帮助类
    /// </summary>
    public class TimeUtils
    {
        //一天的秒数
        public const uint OneDaySeconds = 24 * 60 * 60;

        //一小时的秒数
        public const uint OneHourSeconds = 60 * 60;

        //这个数据用于矫正服务器与客户端时间
        public const ulong DaysFrom = (ulong)719528 * 24 * 3600;

        //时间为0的字符串
        public const string StrTimeZero = "00:00";

        //时间起始于1970年1月1日0点
        public readonly static DateTime BeginAt = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        /// 
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 返回当前时间的时间戳
        /// </summary>
        /// <returns>当前时间的时间戳</returns>
        /// 
        public static int GetNow()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(System.DateTime.Now - startTime).TotalSeconds;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        /// 
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 字符串生成MD5码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Sum(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 把数据timedate分割,
        /// </summary>
        /// <param name="timeData">单位是 秒</param>
        /// <param name="d">天</param>
        /// <param name="h">小时</param>
        /// <param name="m">分钟</param>
        /// <param name="s">秒</param>
        public static void SplitTime(UInt64 timeData, out UInt64 d, out UInt64 h, out UInt64 m, out UInt64 s)
        {
            d = timeData / 86400;
            timeData = timeData % 86400;
            h = timeData / 3600;
            timeData = timeData % 3600;
            m = timeData / 60;
            s = timeData % 60; 
        }

        // 时间戳转为C#格式时间
        public static string StampToDateTime(UInt64 timeStamp, String format = "yyyy-MM-dd")
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp.ToString() + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dateTimeStart.Add(toNow).ToString(format);
        }

        public static int GetSystemTicksMS()
        {
            // TickCount cycles between Int32.MinValue, which is a negative 
            // number, and Int32.MaxValue once every 49.8 days. This sample
            // removes the sign bit to yield a nonnegative number that cycles 
            // between zero and Int32.MaxValue once every 24.9 days.
            return Environment.TickCount & Int32.MaxValue;
        }

        //获取系统Tick的秒
        public static float GetSystemTicksS()
        {
            // TickCount cycles between Int32.MinValue, which is a negative 
            // number, and Int32.MaxValue once every 49.8 days. This sample
            // removes the sign bit to yield a nonnegative number that cycles 
            // between zero and Int32.MaxValue once every 24.9 days.
            return (float)(Environment.TickCount & Int32.MaxValue)/1000f;
        }

        //通过秒获取C#格式时间
        public static DateTime DateTimeFromSecords(int seconds)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTimeStart.AddSeconds(seconds);
            return dateTimeStart; 
        }

        /// <summary>
        /// 格式化时间,小时分钟秒
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string FormatTimeHHMMSS(int seconds)
        {
            var ts = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours + ts.Days * 24, ts.Minutes, ts.Seconds);
        }

        /// <summary>
        /// 格式化时间,天小时分钟秒
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string FormatTimeDDHHMMSS(int seconds)
        {
            var ts = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D2}", ts.Days,ts.Hours, ts.Minutes, ts.Seconds);
        }



        /// <summary>
        /// 格式化,分钟
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string FormatTimeMMSS(int seconds)
        {
            return string.Format("{0:D2}:{1:D2}", seconds / 60, seconds % 60);             
        }

        /// <summary>
        /// 计算剩余时间
        /// </summary>
        /// <param name="endTime">从服务器更新下来的剩余结束时间</param>
        /// <param name="refreshDateTime">从服务器更新时的当前时间</param>
        /// <returns></returns>
        public static int GetRemainTime(int serverRemainTime, DateTime refreshDateTime)
        {
            var ts = DateTime.Now - refreshDateTime;
            var s = (int)Math.Round(serverRemainTime - (float)(ts.TotalSeconds));
            if (s < 0) s = 0;
            return s;                         
        }

        /// <summary>
        /// 获取相差多少天
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="curTime"></param>
        /// <returns></returns>
        public static int GetDayOffset(int startTime, int curTime)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTimeStart = dateTimeStart.AddSeconds(startTime);
            var start = new DateTime(dateTimeStart.Year, dateTimeStart.Month, dateTimeStart.Day);
            DateTime dateTimeCur = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTimeCur = dateTimeCur.AddSeconds(curTime);
            var cur = new DateTime(dateTimeCur.Year, dateTimeCur.Month, dateTimeCur.Day);
            return (int)(cur - start).TotalDays;
        }

        /// <summary>
        /// 获取星期
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeWeekly(int seconds)
        {
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTime = dateTime.AddSeconds(seconds);
            return (int)dateTime.DayOfWeek;
        }

        /// <summary>
        /// 获取小时
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeHH(int seconds)
        {
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime.Hour;
        }
        /// <summary>
        /// 获取分钟
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeMM(int seconds)
        {
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime.Minute;
        }
        /// <summary>
        /// 获取秒
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeSS(int seconds)
        {
            DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime.Second;
        }

        /// <summary>
        /// 获取星期
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeWeeklyNotZone(int seconds)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddSeconds(seconds);
            return (int)dateTime.DayOfWeek;
        }

        /// <summary>
        /// 获取相差多少天
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="curTime"></param>
        /// <returns></returns>
        public static int GetDayOffsetNotZone(int startTime, int curTime)
        {
            DateTime dateTimeStart = new DateTime(1970, 1, 1);
            dateTimeStart = dateTimeStart.AddSeconds(startTime);
            var start = new DateTime(dateTimeStart.Year, dateTimeStart.Month, dateTimeStart.Day);
            DateTime dateTimeCur = new DateTime(1970, 1, 1);
            dateTimeCur = dateTimeCur.AddSeconds(curTime);
            var cur = new DateTime(dateTimeCur.Year, dateTimeCur.Month, dateTimeCur.Day);
            return (int)(cur - start).TotalDays;
        }

        /// <summary>
        /// 获取小时
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeHHNotZone(int seconds)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime.Hour;
        }
        /// <summary>
        /// 获取分钟
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeMMNotZone(int seconds)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime.Minute;
        }
        /// <summary>
        /// 获取秒
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetStampTimeSSNotZone(int seconds)
        {
            DateTime dateTime = new DateTime(1970, 1, 1);
            dateTime = dateTime.AddSeconds(seconds);
            return dateTime.Second;
        }
    }
}

