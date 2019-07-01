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
        private readonly Lazy<IList<MealModel>> meals;
        public List<SelectListItem> MealList => new List<SelectListItem>(meals.Value
            .Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));

        public CompanyPagedCollection(IReadOnlyList<CompanyDetailsRenderModel> items, int page, int itemsPerPage, CompanyFilter filter = null) : base(items, page, itemsPerPage, filter)
        {
            meals = new Lazy<IList<MealModel>>(() => _api.GetAllMeals<MealModel>().Data);

            foreach (CompanyDetailsRenderModel company in Items)
            {
                company.MealList = MealList;
            }
        }
    }
}