using System;
using System.Globalization;

namespace ProjectWeb.Application.Extensions
{
    public static class DateExtensions
    {
        public static string ToShamsi(this DateTime dateTime)
        {
            var persianCalender = new PersianCalendar();

            return
                $"{persianCalender.GetYear(dateTime)}/{persianCalender.GetMonth(dateTime):00}/{persianCalender.GetDayOfMonth(dateTime):00}";
        }

        public static DateTime ToMiladi(this string date)
        {
            var splitDate = date.Split("/");

            var year = Convert.ToInt32(splitDate[0]);
            var month = Convert.ToInt32(splitDate[1]);
            var day = Convert.ToInt32(splitDate[2]);

            return new DateTime(year, month, day, new PersianCalendar());
        }

        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} ثانیه پیش", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1
                    ? String.Format("حدود {0} دقیقه پیش", timeSpan.Minutes)
                    : "حدود یک دقیقه پیش";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ? String.Format("حدود {0} ساعت پیش", timeSpan.Hours) : "حدود یک ساعت پیش";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ? String.Format("حدود {0} روز پیش", timeSpan.Days) : "دیروز";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ? String.Format("حدود {0} ماه پیش", timeSpan.Days / 30) : "حدود یک ماه پیش";
            }
            else
            {
                result = timeSpan.Days > 365
                    ? String.Format("حدود {0} سال پیش", timeSpan.Days / 365)
                    : "حدود یک سال پیش";
            }

            return result;
        }
    }
}