using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Pagination;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.View
{
	public class MealViewModel : NavigationViewModel
	{
		public MealViewModel()
		{
			meals = new Lazy<IEnumerable<MealDetailsRenderModel>>(() => _api.GetAllMeals<MealDetailsRenderModel>()?.Data.OrderBy(x => x.Name));
			searchResult = new Lazy<MealPagedCollection>(() => Search());
		}

		public override string PageTitle => "Obroci";
		public override string PageIcon => "meal";

		public int Page { get; set; } = 1;
		private MealFilter _filter;
		public MealFilter Filter
		{
			get
			{
				_filter.SetLetters(meals.Value);
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}


		private readonly Lazy<IEnumerable<MealDetailsRenderModel>> meals;
		private readonly Lazy<MealPagedCollection> searchResult;

		public MealPagedCollection Meals => searchResult.Value;

		private MealPagedCollection Search() =>
			new MealPagedCollection(meals.Value.ToList(), Page, Constants.ITEMS_PER_AGE, Filter);

	}
}