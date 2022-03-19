using System;
using System.Globalization;

namespace LandingApi.test
{
    public class Utils
    {
        private static DateTime StringToDatetime(string strDate)
        {
            string dateFormat = "yyyy-MM-dd";
            DateTime dateValue;
            DateTime.TryParseExact(strDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.AllowLeadingWhite, out dateValue);

            return dateValue;
        }
    }
}