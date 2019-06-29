using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Web.Models.Pagination;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.View
{
	public class UserViewModel : NavigationViewModel
	{
		public UserViewModel()
		{
			users = new Lazy<IEnumerable<UserDetailsRenderModel>>(() => _api.GetAllUsers<UserDetailsRenderModel>()?.Data.OrderBy(x => x.FullName));
			searchResult = new Lazy<ReadOnlyPagedCollection<UserDetailsRenderModel>>(() => Search());
		}

		public override string PageTitle => "Korisnici";
		public override string PageIcon => "user";
		public int PageId { get; set; } = 1;

		private readonly Lazy<IList<SelectListItem>> countries;
		private readonly Lazy<IEnumerable<UserDetailsRenderModel>> users;
		private readonly Lazy<ReadOnlyPagedCollection<UserDetailsRenderModel>> searchResult;

		public ReadOnlyPagedCollection<UserDetailsRenderModel> Users => searchResult.Value;

		private ReadOnlyPagedCollection<UserDetailsRenderModel> Search() =>
			new ReadOnlyPagedCollection<UserDetailsRenderModel>(users.Value.ToList(), PageId, Constants.ITEMS_PER_AGE);

	}
}