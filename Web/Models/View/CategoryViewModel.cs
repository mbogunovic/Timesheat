using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Pagination;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.View
{
	public class CategoryViewModel : NavigationViewModel
	{
		public CategoryViewModel()
		{
			categories = new Lazy<IEnumerable<CategoryDetailsRenderModel>>(() => _api.GetAllCategories<CategoryDetailsRenderModel>()?.Data.OrderBy(x => x.Name));
			searchResult = new Lazy<CategoryPagedCollection>(() => Search());
		}

		public override string PageTitle => "Kategorije";
		public override string PageIcon => "category";

		public int Page { get; set; } = 1;
		private CategoryFilter _filter;
		public CategoryFilter Filter
		{
			get
			{
				_filter.SetLetters(categories.Value);
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}


		private readonly Lazy<IEnumerable<CategoryDetailsRenderModel>> categories;
		private readonly Lazy<CategoryPagedCollection> searchResult;

		public CategoryPagedCollection Categories => searchResult.Value;

		private CategoryPagedCollection Search() =>
			new CategoryPagedCollection(categories.Value.ToList(), Page, Constants.ITEMS_PER_AGE, Filter);

	}
}