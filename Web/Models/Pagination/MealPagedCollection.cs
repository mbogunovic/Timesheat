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
				meal.PortionsList = PortionList.Where(x => !meal.MealPortions.ToList().Any(y => y.Portion.Id.ToString().Equals(x.Value))).ToList();
				meal.CategoryList = CategoryList;
			}
		}
	}
}