using System;
using System.Collections.Generic;
using TimeshEAT.Web.Models.Additional;
using TimeshEAT.Web.Models.User;

namespace TimeshEAT.Web.ViewModels
{
	public class UserViewModel : NavigationViewModel
	{
		public override string PageTitle => "Korisnici";
		public override string PageIcon => "user";

		private Lazy<IEnumerable<SimpleUserModel>> users;
		public ReadOnlyPagedCollection<SimpleUserModel> Users { get; private set; }

	}
}