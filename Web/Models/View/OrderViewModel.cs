using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Helpers;
using TimeshEAT.Web.Membership;

namespace TimeshEAT.Web.Models.View
{
	public class OrderViewModel : NavigationViewModel
	{
		public OrderViewModel()
		{
			_days = new Lazy<IEnumerable<DayModel>>(() => GetDays());
		}

		public override string PageTitle => "Naruči obrok";
		public override string PageIcon => "home";

		private Lazy<IEnumerable<DayModel>> _days { get; }
		public List<List<DayModel>> Weeks => _days.Value
			.Select((x, i) => new { Index = i, Value = x })
			.GroupBy(x => x.Index / 7)
			.Select(x => x.Select(v => v.Value).ToList())
			.ToList();

		public DateTime Date { get; set; } = DateTime.Now;
		public int Total { get; private set; }

		private IEnumerable<DayModel> GetDays()
		{
			DateTime startDate = DateHelper.GetMonthStartDate(Date);
			DateTime endDate = DateHelper.GetMonthEndDate(Date);

			while (startDate <= endDate)
			{
				var dateModel = new DayModel(startDate, Date);
				Total += dateModel.Total;
				startDate = startDate.AddDays(1);

				yield return dateModel;
			}
		}

	}

	public class DayModel
	{
		public DayModel(DateTime date, DateTime queryDate)
		{
			var orders = DependencyResolver.Current.GetService<IApiClient>()
				.GetAllOrdersBy<OrderModel>((HttpContext.Current.User as MemberPrincipal).Id, date)?.Data;
			Orders = orders?.Select(x => $"{x.Meal.Name} - ({x.Portion.Name}) x{x.Quantity}").ToArray();
			Date = date;
			IsActive = Date.ToString("dd.MM.yyyy").Equals(DateTime.Now.ToString("dd.MM.yyyy"));
			IsDisabled = !Date.ToString("MM.yyyy").Equals(queryDate.ToString("MM.yyyy"));
			Total = orders?.Sum(x => x.Quantity * x.Meal.Price) ?? 0;
		}

		public string[] Orders { get; }
		public DateTime Date { get; }
		public bool IsActive { get; }
		public bool IsDisabled { get; }
		public int Total { get; }
	}
}