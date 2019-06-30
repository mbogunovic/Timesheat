using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Common.Extensions;
using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.Filtering
{
	public class CompanyFilter : TableFilter<CompanyDetailsRenderModel>
    {
		public CompanyFilter(string letter, string query) : base(letter, query)
		{
		}

		protected override Letter GetLetter(IEnumerable<CompanyDetailsRenderModel> items, Letter letter)
		{
			letter.IsActive = letter.Value.Equals(Letter);
			letter.IsAvailable = items.Any(x => x.Name.StartsWith(letter.Value));

			return letter;
		}

		protected override bool LetterFiltering(CompanyDetailsRenderModel item) =>
			!Letter.HasValue() || item.Name.ToLower()
				.StartsWith(Letter.ToLower());


		protected override bool QueryFiltering(CompanyDetailsRenderModel item) =>
			!Query.HasValue() || item.Name.ToLower()
				.Contains(Query.ToLower());
	}
}