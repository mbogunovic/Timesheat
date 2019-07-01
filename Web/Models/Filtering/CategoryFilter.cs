using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Common.Extensions;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.Filtering
{
	public class CategoryFilter : TableFilter<CategoryDetailsRenderModel>
	{
		public CategoryFilter(string letter, string query) : base(letter, query) { }

		protected override Letter GetLetter(IEnumerable<CategoryDetailsRenderModel> items, Letter letter)
		{
			letter.IsActive = letter.Value.ToLower().Equals(Letter?.ToLower());
			letter.IsAvailable = items.Any(x => x.Name.ToLower().StartsWith(letter.Value.ToLower()));

			return letter;
		}


		protected override bool LetterFiltering(CategoryDetailsRenderModel item) =>
			!Letter.HasValue() || item.Name.ToLower()
				.StartsWith(Letter?.ToLower());


		protected override bool QueryFiltering(CategoryDetailsRenderModel item) =>
			!Query.HasValue() || item.Name.ToLower()
				.Contains(Query?.ToLower());
	}
}