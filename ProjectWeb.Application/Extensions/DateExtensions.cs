using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProjectWeb.Application.Extensions
{
    public static class DateExtensions
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            var persianCalender = new PersianCalendar();

            return $"{persianCalender.GetYear(dateTime)}/{persianCalender.GetMonth(dateTime):00}/{persianCalender.GetDayOfMonth(dateTime):00}";
        }

        public static DateTime ToMiladi(this string date)
        {
            var splitDate = date.Split("/");

            var year = Convert.ToInt32(splitDate[0]);
            var month = Convert.ToInt32(splitDate[1]);
            var day = Convert.ToInt32(splitDate[2]);

            return new DateTime(year, month, day, new PersianCalendar());
        }
    }
}
