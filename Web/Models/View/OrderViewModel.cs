using System;
using System.Collections.Generic;
using TimeshEAT.Web.Helpers;

namespace TimeshEAT.Web.Models.View
{
	public class OrderViewModel : NavigationViewModel
	{
		public OrderViewModel()
		{
			Days = new Lazy<IEnumerable<DayModel>>(() => GetDays());
		}

		public override string PageTitle => "Naruči obrok";
		public override string PageIcon => "home";

		public Lazy<IEnumerable<DayModel>> Days { get; }
		public DateTime Date { get; set; } = DateTime.Now;
		public int Total { get; private set; }

		private IEnumerable<DayModel> GetDays()
		{
			DateTime startDate = DateHelper.GetMonthStartDate(Date);
			DateTime endDate = DateHelper.GetMonthEndDate(Date);

			while (startDate <= endDate)
			{
				//_api.GetAllMeals()

				//foreach (var activity in _activityService.GetEmployeeActivityForDate(new DailyActivityGetByDate
				//{
				//	Date = startDate,
				//	EmployeeId = model.CurrentUser.Id
				//}))
				//{
				//	total += activity.HoursSpent + activity.Overtime;
				//}

				var dateModel = new DayModel(startDate, Date);
				
				Total += Total;
				startDate = startDate.AddDays(1);

				yield return dateModel;
			}
		}

	}

	public class DayModel
	{
		public DayModel(DateTime date, DateTime queryDate)
		{
			Date = date;
			IsActive = Date.ToString("dd.MM.yyyy").Equals(queryDate.ToString("dd.MM.yyyy"));
			IsDisabled = !Date.ToString("MM.yyyy").Equals(queryDate.ToString("MM.yyyy"));
		}

		public DateTime Date { get; }
		public bool IsActive { get; }
		public bool IsDisabled { get; }
	}
}