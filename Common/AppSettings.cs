using System.Configuration;

namespace TimeshEAT.Common
{
    public static class AppSettings
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["TimesheatDBConnection"].ConnectionString;
        public static readonly string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
    }
}
