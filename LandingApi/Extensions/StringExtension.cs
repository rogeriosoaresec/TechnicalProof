using System.Web;

namespace LandingApi.Extensions
{
    public static class StringExtension
    {
        public static string Encoded(this string value)
        {
            return HttpUtility.HtmlEncode(value);
        }
    }
}