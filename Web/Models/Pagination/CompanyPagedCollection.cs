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
                company.CompanyMeals = MealList.Where(mli => mli.Value == company.Id.ToString()).ToList();
                company.CompanyMealsIds = string.Join(",",company.CompanyMeals.Select(cm => cm.Value));
                company.MealList = MealList.Where(mli => !company.CompanyMealsIds.Split(',').Contains(mli.Value)).ToList();
            }
        }
    }
}