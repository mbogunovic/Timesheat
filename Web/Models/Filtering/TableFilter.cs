using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.Filtering
{
	public class UserFilter
	{
		public string Letter { get; set; }
		public string Query { get; set; }

		internal IReadOnlyList<UserDetailsRenderModel> Apply(IReadOnlyList<UserDetailsRenderModel> items) =>
			items.Where(x => LetterFiltering(x) && QueryFiltering(x))
				.ToList()
				.AsReadOnly();

		private bool LetterFiltering(UserDetailsRenderModel user) => true;
		private bool QueryFiltering(UserDetailsRenderModel user) => true;
	}
}