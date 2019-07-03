using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Membership;

namespace TimeshEAT.Web.Models.View
{
	public class DayOrderViewModel : NavigationViewModel
	{
		public override string PageTitle => "Naruči obrok";
		public override string PageIcon => "home";

		public readonly Lazy<IList<CategoryModel>> Categories;

		public DayOrderViewModel(DateTime date)
		{
			Categories = new Lazy<IList<CategoryModel>>(() => _api.GetAllCategories<CategoryModel>()?.Data);
			Orders = new Lazy<IEnumerable<OrderDetailsRenderModel>>(() => _api
				.GetAllOrdersBy<OrderDetailsRenderModel>((HttpContext.Current.User as MemberPrincipal).Id, date)?.Data);
			Date = date;
		}

		public Lazy<IEnumerable<OrderDetailsRenderModel>> Orders { get; }
		public DateTime Date { get; }
	}

	public class OrderDetailsRenderModel : IForm
	{
		public int Id { get; set; }
		public long Version { get; set; }
		public int UserId { get; set; }
		public DateTime OrderDate { get; set; }

		public IList<CategoryModel> Categories { get; set; }
		public IList<SelectListItem> CategoryList => this.Categories
			.Select(x => new SelectListItem()
			{
				Value = x.Id.ToString(),
				Text = x.Name
			})
			.ToList();
		public IList<SelectListItem> MealList => this.Categories.First(x => x.Id.Equals(this.CategoryId))
			.Meals
			.Select(x => new SelectListItem()
			{
				Value = x.Id.ToString(),
				Text = x.Name
			})
			.ToList();

		[Required(ErrorMessage = "Morate izabrati količinu.")]
		[Display(Name = "Količina")]
		public int Quantity { get; set; }
		[Required(ErrorMessage = "Morate izabrati vreme.")]
		[Display(Name = "Vreme")]
		public TimeSpan LunchTime { get; set; }
		[Required(ErrorMessage = "Morate izabrati kategoriju.")]
		[Display(Name = "Kategorija")]
		public int CategoryId { get; set; }
		[Required(ErrorMessage = "Morate izabrati obrok.")]
		[Display(Name = "Obrok")]
		public int MealId { get; set; }
		[Required(ErrorMessage = "Morate izabrati porciju.")]
		[Display(Name = "Veličina porcije")]
		public int PortionId { get; set; }
		[Display(Name = "Dodatni komentar")]
		public string Comment { get; set; }
	}
}