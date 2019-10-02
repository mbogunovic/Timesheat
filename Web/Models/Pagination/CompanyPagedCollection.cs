using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.Pagination
{
	public class CompanyPagedCollection : ReadOnlyPagedCollection<CompanyDetailsRenderModel>
	{
		private readonly Lazy<IList<MealModel>> allMeals;
		public List<SelectListItem> MealList => new List<SelectListItem>(allMeals.Value
			.Select(x => new SelectListItem()
			{
				Text = x.Name,
				Value = x.Id.ToString()
			}));

		public CompanyPagedCollection(IReadOnlyList<CompanyDetailsRenderModel> items, int page, int itemsPerPage, CompanyFilter filter = null) : base(items, page, itemsPerPage, filter)
		{
			allMeals = new Lazy<IList<MealModel>>(() => _api.GetAllMeals<MealModel>().Data);
			foreach (CompanyDetailsRenderModel company in Items)
			{
				company.MealList = company.Meals?.Select(m => new SelectListItem
				{
					Text = m.Name,
					Value = m.Id.ToString()
				}).ToList() ?? new List<SelectListItem>();
				company.MealList = MealList.Where(x => !company.Meals.ToList().Any(y => y.Id.ToString().Equals(x.Value))).ToList();
			}
		}
	}
}