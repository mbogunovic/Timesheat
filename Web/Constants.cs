using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace TimeshEAT.Web
{
	public static class Constants
	{
		public const string RESPONSE_MESSAGE = "ResponseMessage";

		public const int MAX_LOGIN_ATTEMPTS = 3;

		public const string ERROR_MODEL = "error_model";

		public const int MEMBER_CACHE_TIME = 30; // in minutes
		public const string MEMBER_CACHE_FORMAT = "member_data_{0}";
		public const string MEMBER_CACHE_TOKEN = "member_token_{0}";

		public const int ITEMS_PER_AGE = 2;


		#region [Months]

		public static List<MonthModel> MonthList = new List<MonthModel>()
		{
			new MonthModel(Months.January),
			new MonthModel(Months.February),
			new MonthModel(Months.March),
			new MonthModel(Months.April),
			new MonthModel(Months.May),
			new MonthModel(Months.June),
			new MonthModel(Months.July),
			new MonthModel(Months.August),
			new MonthModel(Months.September),
			new MonthModel(Months.October),
			new MonthModel(Months.November),
			new MonthModel(Months.December),
		};

		public enum Months
		{
			January = 1,
			February,
			March,
			April,
			May,
			June,
			July,
			August,
			September,
			October,
			November,
			December
		}

		public class MonthModel
		{
			public MonthModel(Months month)
			{
				Month = month;
			}

			public Months Month { get; set; }
			public bool IsActive => HttpContext.Current.Request.Url.AbsoluteUri.Contains(Month.ToString());
			public string Name => _monthNames[(int) Month];

			private static readonly string[] _monthNames = new string[]
			{
				"Empty",
				"Januar",
				"Februar",
				"Mart",
				"April",
				"Maj",
				"Jun",
				"Jul",
				"Avgust",
				"Septembar",
				"Oktobar",
				"Novembar",
				"Decembar"
			};
		}

		#endregion

		#region [INavigation default route values]
		public static object DefaultRouteValues(string pageName) =>
			_defaultRouteValues.ContainsKey(pageName) ? _defaultRouteValues[pageName] : null;

		private static Dictionary<string, object> _defaultRouteValues = new Dictionary<string, object>()
		{
			{"Order", new {month = (Months) DateTime.Now.Month}}
		};

		#endregion

		public static readonly string[] LETTERS = { "A", "B", "V", "G", "D", "Đ", "E", "Ž", "Z", "I", "J", "K", "L", "LJ", "M", "N", "NJ", "O", "P", "R", "S", "T", "U", "F", "H", "C", "Č", "Ć", "DŽ", "Š" };

		public static readonly IList<SelectListItem> QuantityList = new List<SelectListItem>()
		{
			new SelectListItem(){ Value = "1", Text = "1 kom." },
			new SelectListItem(){ Value = "2", Text = "2 kom." },
			new SelectListItem(){ Value = "3", Text = "3 kom." },
			new SelectListItem(){ Value = "4", Text = "4 kom." },
			new SelectListItem(){ Value = "5", Text = "5 kom." }
		};
	}
}