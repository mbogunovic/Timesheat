using System;

namespace TimeshEAT.Web.Helpers
{
	public class DateHelper
	{
		public static DateTime GetMonthEndDate(DateTime date)
		{
			DateTime endDate = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
			for (; endDate.DayOfWeek != DayOfWeek.Sunday;)
			{
				endDate = endDate.AddDays(1);
			}
			return endDate;
		}

		public static DateTime GetMonthStartDate(DateTime date)
		{
			DateTime startDate = new DateTime(date.Year, date.Month, 1);
			for (; startDate.DayOfWeek != DayOfWeek.Monday;)
			{
				startDate = startDate.AddDays(-1);
			}
			return startDate;
		}

		public static DateTime GetWeekEndDate(DateTime date)
		{
			DateTime end = date;
			for (; end.DayOfWeek != DayOfWeek.Sunday;)
			{
				end = end.AddDays(1);
			}
			return end;
		}

		public static DateTime GetWeekStartDate(DateTime date)
		{
			DateTime start = date;
			for (; start.DayOfWeek != DayOfWeek.Monday;)
			{
				start = start.AddDays(-1);
			}
			return start;
		}
	}
}