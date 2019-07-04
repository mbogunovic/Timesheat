using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TimeshEAT.Business.Models;
using TimeshEAT.Common.Extensions;
using TimeshEAT.Web.Interfaces;
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
		}

		public Lazy<IEnumerable<OrderDetailsRenderModel>> Orders { get; }
		public DateTime Date { get; }
		public int Total => Orders.Value?.Sum(x => x.Quantity * x.Meal?.Price) ?? 0;
	}

	public class OrderDetailsRenderModel : IForm
	{
		public OrderDetailsRenderModel() {}

		public OrderDetailsRenderModel(IList<SelectListItem> categoryList, DateTime orderDate)
		{
			CategoryList = categoryList ?? new List<SelectListItem>();
			UserId = (HttpContext.Current.User as MemberPrincipal).Id;
			MealList = new List<SelectListItem>();
			PortionList = new List<SelectListItem>();
			OrderDate = orderDate;
		}

		public void InitializeLists(IList<SelectListItem> categoryList, IList<SelectListItem> mealList)
		{
			CategoryList = categoryList ?? new List<SelectListItem>();
			MealList = mealList ?? new List<SelectListItem>();
			PortionList = Meal?.Portions?
				.Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name})
				.ToList() ?? new List<SelectListItem>();
		}

		public int Id { get; set; }
		public long Version { get; set; }
		public int UserId { get; set; }
		public DateTime OrderDate { get; set; }
		public MealModel Meal { get; set; }
		public int Total => Meal?.Price ?? 0 * Quantity;

		public IList<SelectListItem> CategoryList { get; set; }
		public IList<SelectListItem> MealList { get; set; }
		public IList<SelectListItem> PortionList { get; set; }

		[Required(ErrorMessage = "Morate izabrati kategoriju.")]
		[Display(Name = "Kategorija")]
		private int categoryId;


		public int CategoryId
		{
			get { return categoryId != 0 ? categoryId : Meal?.CategoryId ?? 0; }
			set { categoryId = value; }
		}

		[Required(ErrorMessage = "Morate izabrati količinu.")]
		[Display(Name = "Količina")]
		public int Quantity { get; set; } = 1;
		[Required(ErrorMessage = "Morate izabrati vreme.")]
		[Display(Name = "Vreme")]
		public string LunchTimeString { get; set; }
		[Required(ErrorMessage = "Morate izabrati obrok.")]
		[Display(Name = "Obrok")]
		public int MealId { get; set; }
		[Required(ErrorMessage = "Morate izabrati porciju.")]
		[Display(Name = "Veličina porcije")]
		public int PortionId { get; set; }

		[Display(Name = "Dodatni komentar")]
		public string Comment { get; set; }

		private TimeSpan lunchTime;
		public TimeSpan LunchTime
		{
			get
			{
				return lunchTime == default(TimeSpan)
					? DateTime.ParseExact(LunchTimeString.HasValue() ? LunchTimeString : "12:00 PM",
						"hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay
					: lunchTime;
			}
			set { lunchTime = value; }
		}

		public static implicit operator OrderModel(OrderDetailsRenderModel order)
		{
			if (order == null) return null;

			return new OrderModel(order.Quantity, order.LunchTime, order.OrderDate, order.UserId, order.MealId,
				order.PortionId, order.Comment, order.Id, order.Version);
		}
	}
}