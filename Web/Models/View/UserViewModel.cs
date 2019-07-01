using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Pagination;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.View
{
	public class UserViewModel : NavigationViewModel
	{
		public UserViewModel()
		{
			users = new Lazy<IEnumerable<UserDetailsRenderModel>>(() => _api.GetAllUsers<UserDetailsRenderModel>()?.Data.OrderBy(x => x.FullName));
			searchResult = new Lazy<UserPagedCollection>(() => Search());
		}

		public override string PageTitle => "Korisnici";
		public override string PageIcon => "user";

		public int Page { get; set; } = 1;
		private UserFilter _filter;
		public UserFilter Filter
		{
			get
			{
				_filter.SetLetters(users.Value);
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}


		private readonly Lazy<IEnumerable<UserDetailsRenderModel>> users;
		private readonly Lazy<UserPagedCollection> searchResult;

		public UserPagedCollection Users => searchResult.Value;

		private UserPagedCollection Search() =>
			new UserPagedCollection(users.Value.ToList(), Page, Constants.ITEMS_PER_AGE, Filter);

	}
}