using System.Configuration;

namespace TimeshEAT.Common
{
    public static class AppSettings
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["TimesheatDBConnection"].ConnectionString;
        public static readonly string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public static readonly string ReportAProblemSender = ConfigurationManager.AppSettings["ReportAProblemSender"];
        public static readonly string ReportAProblemReceiver = ConfigurationManager.AppSettings["ReportAProblemReceiver"];
		public static readonly string SerilogPath = ConfigurationManager.AppSettings["SerilogPath"];
		public static readonly string DefaultEmail = ConfigurationManager.AppSettings["DefaultEmail"];

	}
}
