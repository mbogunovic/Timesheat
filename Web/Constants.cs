namespace TimeshEAT.Web
{
	public static class Constants
	{
		public const string RESPONSE_MESSAGE = "ResponseMessage";

		public const int MAX_LOGIN_ATTEMPTS = 3;

		public const string ERROR_MODEL = "error_model";

		public const int MEMBER_CACHE_TIME = 30; // in minutes
		public const string MEMBER_CACHE_FORMAT = "member_data_{0}";
		public static string MEMBER_CACHE_TOKEN = "member_token_{0}";

		public const int ITEMS_PER_AGE = 2;

	}
}