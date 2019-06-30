using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.Filtering
{
	public class CompanyFilter : TableFilter<CompanyDetailsRenderModel>
    {
		protected override bool LetterFiltering(CompanyDetailsRenderModel item) =>
			item.Name.ToLower()
				.StartsWith(Letter.ToLower());


		protected override bool QueryFiltering(CompanyDetailsRenderModel item) =>
			item.Name.ToLower()
				.Contains(Query.ToLower());
	}
}