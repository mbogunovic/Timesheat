using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Common.Extensions;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.Filtering
{
	public class UserFilter : TableFilter<UserDetailsRenderModel>
	{
		public UserFilter(string letter, string query) : base(letter, query) { }

		protected override Letter GetLetter(IEnumerable<UserDetailsRenderModel> items, Letter letter)
		{
			letter.IsActive = letter.Value.Equals(Letter);
			letter.IsAvailable = items.Any(x => x.FullName.StartsWith(letter.Value));

			return letter;
		}


		protected override bool LetterFiltering(UserDetailsRenderModel item) =>
			!Letter.HasValue() || item.FullName.ToLower()
				.StartsWith(Letter?.ToLower());


		protected override bool QueryFiltering(UserDetailsRenderModel item) =>
			!Query.HasValue() || item.FullName.ToLower()
				.Contains(Query?.ToLower());
	}
}