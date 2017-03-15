using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// 时间类
    /// 1、SecondToMinute(int Second) 把秒转换成分钟
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// 将时间格式化成 年月日 的形式,如果时间为null，返回当前系统时间
        /// </summary>
        /// <param name="dt">年月日分隔符</param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public string GetFormatDate(DateTime dt, char Separator)
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("yyyy{0}MM{1}dd", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        /// <summary>
        /// 将时间格式化成 时分秒 的形式,如果时间为null，返回当前系统时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Separator"></param>
        /// <returns></returns>
        public string GetFormatTime(DateTime dt, char Separator)
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("hh{0}mm{1}ss", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        #region 返回某年某月最后一天
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 返回时间差
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        #endregion

        #region 获得两个日期的间隔
        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public static TimeSpan DateDiff2(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
        #endregion

        #region 格式化日期时间
        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="dateTime1">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(DateTime dateTime1, string dateMode)
        {
            switch (dateMode)
            {
                case "0":
                    return dateTime1.ToString("yyyy-MM-dd");
                case "1":
                    return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dateTime1.ToString("yyyy/MM/dd");
                case "3":
                    return dateTime1.ToString("yyyy年MM月dd日");
                case "4":
                    return dateTime1.ToString("MM-dd");
                case "5":
                    return dateTime1.ToString("MM/dd");
                case "6":
                    return dateTime1.ToString("MM月dd日");
                case "7":
                    return dateTime1.ToString("yyyy-MM");
                case "8":
                    return dateTime1.ToString("yyyy/MM");
                case "9":
                    return dateTime1.ToString("yyyy年MM月");
                default:
                    return dateTime1.ToString();
            }
        }
        #endregion

        #region 得到随机日期
        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();

            System.TimeSpan ts = new System.TimeSpan(time1.Ticks - time2.Ticks);

            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue + 1;

            int i = random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }
        #endregion

        /// <summary>
        /// 返回指定时间的每月的第一天和最后一天
        /// </summary>
        /// <param name="date"></param>
        /// <param name="month"></param>
        /// <param name="firstDay"></param>
        /// <param name="lastDay"></param>
        public static void ReturnDateFormat(DateTime date, int month, out string firstDay, out string lastDay)
        {
            int year = date.Year + month / 12;
            if (month != 12)
            {
                month = month % 12;
            }
            switch (month)
            {
                case 1:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-31");
                    break;
                case 2:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    if (DateTime.IsLeapYear(date.Year))
                        lastDay = date.ToString(year + "-0" + month + "-29");
                    else
                        lastDay = date.ToString(year + "-0" + month + "-28");
                    break;
                case 3:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString("yyyy-0" + month + "-31");
                    break;
                case 4:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-30");
                    break;
                case 5:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-31");
                    break;
                case 6:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-30");
                    break;
                case 7:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-31");
                    break;
                case 8:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-31");
                    break;
                case 9:
                    firstDay = date.ToString(year + "-0" + month + "-01");
                    lastDay = date.ToString(year + "-0" + month + "-30");
                    break;
                case 10:
                    firstDay = date.ToString(year + "-" + month + "-01");
                    lastDay = date.ToString(year + "-" + month + "-31");
                    break;
                case 11:
                    firstDay = date.ToString(year + "-" + month + "-01");
                    lastDay = date.ToString(year + "-" + month + "-30");
                    break;
                default:
                    firstDay = date.ToString(year + "-" + month + "-01");
                    lastDay = date.ToString(year + "-" + month + "-31");
                    break;
            }
        }



        /// <summary>
        /// 获取当前日期在本周中第几天(周日记为最后一天)
        /// </summary>
        /// <param name="curDate"></param>
        /// <param name="sundayStart"></param>
        /// <returns></returns>
        public static int GetWeekDay(DateTime curDate, bool sundayStart = false)
        {
            string curDay = curDate.DayOfWeek.ToString();
            int[] Day = null;
            if (sundayStart)
            {
                Day = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            }
            else
            {
                Day = new int[] { 7, 1, 2, 3, 4, 5, 6 };
            }
            int week = Day[Convert.ToInt32(curDate.DayOfWeek.ToString("d"))];

            return week;
        }

        /// <summary>
        /// 获取当前日期在本周中名称(周日记为最后一天)
        /// </summary>
        /// <param name="curDate"></param>
        /// <param name="sundayStart"></param>
        /// <returns></returns>
        public static string GetWeekDayName(DateTime curDate)
        {
            string curDay = curDate.DayOfWeek.ToString();
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };

            string week = Day[Convert.ToInt32(curDate.DayOfWeek.ToString("d"))].ToString();
            return week;
        }

        /// 某个年月有多少天 
        /// </summary> 
        /// <param name="y"></param> 
        /// <param name="m"></param> 
        /// <returns></returns> 
        public static int HowMonthDay(int y, int m)
        {
            int mnext;
            int ynext;
            if (m < 12)
            {
                mnext = m + 1;
                ynext = y;
            }
            else
            {
                mnext = 1;
                ynext = y + 1;
            }
            DateTime dt1 = System.Convert.ToDateTime(y + "-" + m + "-1");
            DateTime dt2 = System.Convert.ToDateTime(ynext + "-" + mnext + "-1");
            TimeSpan diff = dt2 - dt1;
            return diff.Days;
        }

        /// <summary> 
        /// 求某年有多少周 
        /// 返回 int 
        /// </summary> 
        /// <param name="strYear"></param> 
        /// <returns>int</returns> 
        public static int GetYearWeekCount(int strYear)
        {
            System.DateTime fDt = DateTime.Parse(strYear.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//得到该年的第一天是周几 
            if (k == 1)
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 1;
                return countWeek;

            }
            else
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 2;
                return countWeek;
            }

        }

        /// <summary> 
        /// 求某日期是一年的中第几周 
        /// </summary> 
        /// <param name="date"></param> 
        /// <returns></returns> 
        public static int WeekOfYear(DateTime curDay)
        {
            int firstdayofweek = Convert.ToInt32(Convert.ToDateTime(curDay.Year.ToString() + "- " + "1-1 ").DayOfWeek);

            int days = curDay.DayOfYear;
            int daysOutOneWeek = days - (7 - firstdayofweek);

            if (daysOutOneWeek <= 0)
            {
                return 1;
            }
            else
            {
                int weeks = daysOutOneWeek / 7;
                if (daysOutOneWeek % 7 != 0)
                    weeks++;

                return weeks + 1;
            }
        }

        /// <summary>
        /// 统计一段时间内有多少个星期几
        /// </summary>
        /// <param name="beginDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="weekNumber">星期几</param>
        /// <returns>多少个星期几</returns>
        public static int WeekOfTotalWeeks(DateTime beginDate, DateTime endDate, DayOfWeek weekNumber)
        {
            TimeSpan _dayTotal = new TimeSpan(endDate.Ticks - beginDate.Ticks);
            int result = (int)_dayTotal.TotalDays / 7;
            double iLen = _dayTotal.TotalDays % 7;
            for (int i = 0; i <= iLen; i++)
            {
                if (beginDate.AddDays(i).DayOfWeek == weekNumber)
                {
                    result++;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// 计算某个月属于第几季度
        /// </summary>
        /// <param name="month">需要计算的月份</param>
        /// <returns>某年第几季度</returns>
        public static int QuarterOfCurrent(int month)
        {
            if (month < 1 || month > 12) return -1;
            return (month - 1) / 3 + 1;
        }
        /// <summary>
        /// 获得指定日期所在季度的开始日期和结束日期
        /// </summary>
        /// <param name="fromDate">需要计算的日期</param>
        /// <param name="quarterBeginDate">开始日期</param>
        /// <param name="quarterEndDate">结束日期</param>
        public static void QuarterOfDate(DateTime fromDate, out DateTime quarterBeginDate, out DateTime quarterEndDate)
        {
            int quarter = QuarterOfCurrent(fromDate.Month);
            QuarterOfDate(fromDate.Year, quarter, out quarterBeginDate, out quarterEndDate);
        }
        /// <summary>
        /// 获得某年第某季度的开始日期和结束日期
        /// </summary>
        /// <param name="year">需要计算的年份</param>
        /// <param name="quarter">需要计算的季度</param>
        /// <param name="quarterBeginDate">开始日期</param>
        /// <param name="quarterEndDate">结束日期</param>
        public static void QuarterOfDate(int year, int quarter, out DateTime quarterBeginDate, out DateTime quarterEndDate)
        {
            quarterBeginDate = DateTime.MinValue;
            quarterEndDate = DateTime.MaxValue;
            if (year <= 0001 || year >= 9999 || quarter < 1 || quarter > 4) return;
            int month = (quarter - 1) * 3 + 1;
            quarterBeginDate = new DateTime(year, month, 1);
            quarterEndDate = quarterBeginDate.AddMonths(3).AddMilliseconds(-1);
        }


    }
}
