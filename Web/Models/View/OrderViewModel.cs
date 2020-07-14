using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Web.Helpers;
using TimeshEAT.Web.Models.Render.Order;

namespace TimeshEAT.Web.Models.View
{
	public class OrderViewModel : NavigationViewModel
	{
		public OrderViewModel()
		{
			_days = new Lazy<IEnumerable<DayRenderModel>>(() => GetDays());
		}

		public override string PageTitle => "Naruči obrok";
		public override string PageIcon => "home";

		private Lazy<IEnumerable<DayRenderModel>> _days { get; }
		public List<List<DayRenderModel>> Weeks => _days.Value
			.Select((x, i) => new { Index = i, Value = x })
			.GroupBy(x => x.Index / 7)
			.Select(x => x.Select(v => v.Value).ToList())
			.ToList();

		public DateTime Date { get; set; } = DateTime.Now;
		public int Total { get; private set; }
		public int TotalWithDIscount { get; private set; }

		private IEnumerable<DayRenderModel> GetDays()
		{
			DateTime startDate = DateHelper.GetMonthStartDate(Date);
			DateTime endDate = DateHelper.GetMonthEndDate(Date);

			while (startDate <= endDate)
			{
				var dateModel = new DayRenderModel(startDate, Date);
				Total += dateModel.Total;
				TotalWithDIscount += dateModel.TotalWithDiscount;
				startDate = startDate.AddDays(1);

				yield return dateModel;
			}
		}

	}
}