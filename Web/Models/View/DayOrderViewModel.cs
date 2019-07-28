using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Helpers;
using TimeshEAT.Web.Membership;

namespace TimeshEAT.Web.Models.View
{
	public class DayOrderViewModel : NavigationViewModel
	{
		public override string PageTitle => "Naruči obrok";
		public override string PageIcon => "home";

		private CompanyModel company => (HttpContext.Current.User as MemberPrincipal).Company;

		public IList<SelectListItem> GetMealList(int categoryId) => company.Meals
			.Where(x => x.CategoryId.Equals(categoryId))
			.Select(x => new SelectListItem()
			{
				Value = x.Id.ToString(), Text = x.Name
			}).ToList();

		public IList<SelectListItem> CategoryList { get; set; }

		public DayOrderViewModel(DateTime date)
		{
			CategoryList = company.Meals
				.Select(x => new SelectListItem(){ Value = x.CategoryId.ToString(), Text = x.Category.Name })
				.DistinctBy(x => x.Value)
				.ToList();

			Orders = new Lazy<IEnumerable<OrderDetailsRenderModel>>(() => _api
				.GetAllOrdersBy<OrderDetailsRenderModel>((HttpContext.Current.User as MemberPrincipal).Id, date)?.Data);
			Date = date;
            CurrentDate = new DateViewModel
            {
                Date = date
            };
            StartDate = new DateViewModel
            {
                Date = DateHelper.GetWeekStartDate(date)
            };
            EndDate = new DateViewModel
            {
                Date = DateHelper.GetWeekEndDate(date)
            };
            DateRange = GetDateRange();
        }

        private IEnumerable<DateViewModel> GetDateRange()
        {
            DateTime iterator = StartDate.Date;

            for (; iterator <= EndDate.Date; iterator = iterator.AddDays(1))
            {
                yield return new DateViewModel
                {
                    Date = iterator
                };
            }
        }

        public Lazy<IEnumerable<OrderDetailsRenderModel>> Orders { get; }
		public DateTime Date { get; }
        public DateViewModel StartDate { get; }
        public DateViewModel EndDate { get; }
        public DateViewModel CurrentDate { get; }
        public IEnumerable<DateViewModel> DateRange { get; set; }
		public int Total => Orders.Value?.Sum(x => x.Quantity * x.Meal?.Portions?.FirstOrDefault(p => p.Id == x.PortionId)?.Price ?? 0) ?? 0;
	}
}