using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.Pagination
{
	public class MealPagedCollection : ReadOnlyPagedCollection<MealDetailsRenderModel>
    {
        private readonly Lazy<IList<PortionModel>> portions;
		private readonly Lazy<IList<CategoryModel>> categories;

        public List<SelectListItem> PortionList => new List<SelectListItem>(portions.Value
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));
        public List<SelectListItem> CategoryList => new List<SelectListItem>(categories.Value
			.Select(x => new SelectListItem()
				{
					Text = x.Name,
					Value = x.Id.ToString()
				}));

		public MealPagedCollection(IReadOnlyList<MealDetailsRenderModel> items, int page, int itemsPerPage, MealFilter filter = null) : base(items, page, itemsPerPage, filter)
		{
			categories = new Lazy<IList<CategoryModel>>(() => _api.GetAllCategories<CategoryModel>().Data);
            portions = new Lazy<IList<PortionModel>>(() => _api.GetAllPortions<PortionModel>().Data);

			foreach (MealDetailsRenderModel meal in Items)
            {
                meal.MealPortions = meal.Portions?.Select(p => new SelectListItem
                {
                    Text = p.Portion.Name,
                    Value = p.Portion.Id.ToString()
                }).ToList() ?? new List<SelectListItem>();
                meal.MealPortionsObjects = string.Join(",", meal.Portions?.Select(mp => "{ \"PortionId\":" + mp.Portion.Id + ", \"Price\":" + mp.Price + "}") ?? Array.Empty<string>());
                meal.PortionsList = PortionList.Where(pli => !meal.MealPortionsObjects.Split(',').Contains(pli.Value)).ToList();
				meal.CategoryList = CategoryList;
			}
		}
	}
}