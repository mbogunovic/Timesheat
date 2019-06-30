using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.Filtering
{
	public class UserFilter : TableFilter<UserDetailsRenderModel>
	{
		protected override bool LetterFiltering(UserDetailsRenderModel item) =>
			item.FullName.ToLower()
				.StartsWith(Letter.ToLower());


		protected override bool QueryFiltering(UserDetailsRenderModel item) =>
			item.FullName.ToLower()
				.Contains(Query.ToLower());
	}
}