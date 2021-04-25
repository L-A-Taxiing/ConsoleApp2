using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
     public struct time
     {
        //源栈的学费是按周计费的，所以请实现这两个功能：
        //函数GetDate()，能计算一个日期若干（日/周/月）后的日期
        public static DateTime GetDate(DateTime initialtime, int number)
        {
            return initialtime.AddDays(number);     //若干日后的日期;
            /*return initialtime.AddDays(number*7);*/   //若干周后的日期；
            /*return initialtime.AddMonths(number);  */ //若干月后的日期；

        }

        //给定任意一个年份，就能按周排列显示每周的起始日期，如下图所示：
        public static DateTime GetFirstWeek(int year)//判断给定年份的一月一日是否为周一;
        {
            DateTime initialdate = new DateTime(year, 1, 1);
            while (initialdate.DayOfWeek!=DayOfWeek.Monday)
            {
                initialdate = initialdate.AddDays(1);
            }
            return initialdate;
        }

        public static void GetWeeks(DateTime initialdate)
        {
            int enddate = initialdate.Year + 1;
            int i = 1;
            while (initialdate.Year<enddate)
            {
                Console.WriteLine($"第{i}周:{ initialdate.ToLongDateString()} -{initialdate.AddDays(6).ToLongDateString() }");
                initialdate = initialdate.AddDays(7);
                i++;
            }
        }










    }


}
