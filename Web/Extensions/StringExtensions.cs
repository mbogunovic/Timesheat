namespace TimeshEAT.Web.Extensions
{
	public static class StringExtensions
	{
		public static string RemoveControllerSuffix(this string val) =>
			val.RemoveSuffix("Controller");

		public static string AddViewModelSuffix(this string val) =>
			val.AddSuffix("ViewModel");

		public static string RemoveSuffix(this string val, string suffix) =>
			val.Replace(suffix, "");

		public static string AddSuffix(this string val, string suffix) =>
			val + suffix;
	}
}