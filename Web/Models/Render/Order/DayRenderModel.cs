using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Membership;

namespace TimeshEAT.Web.Models.Render.Order
{
	public class DayRenderModel
	{
		public DayRenderModel(DateTime date, DateTime queryDate)
		{
			var orders = DependencyResolver.Current.GetService<IApiClient>()
				.GetAllOrdersBy<OrderModel>((HttpContext.Current.User as MemberPrincipal).Id, date)?.Data;
			Orders = orders?.Select(x => $"{x.Meal.Name} - ({x.Portion.Name}) x{x.Quantity}").ToArray();
			Date = date;
			IsActive = Date.ToString("dd.MM.yyyy").Equals(DateTime.Now.ToString("dd.MM.yyyy"));
			IsDisabled = !Date.ToString("MM.yyyy").Equals(queryDate.ToString("MM.yyyy"));
			Total = orders?.Sum(x => x.Quantity * x.Portion.Price) ?? 0;
		}

		public string[] Orders { get; }
		public DateTime Date { get; }
		public bool IsActive { get; }
		public bool IsDisabled { get; }
		public int Total { get; }
	}
}