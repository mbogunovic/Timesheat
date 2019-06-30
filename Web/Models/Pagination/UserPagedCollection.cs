using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Models.Pagination
{
	public class UserPagedCollection : ReadOnlyPagedCollection<UserDetailsRenderModel>
	{
		private readonly Lazy<IList<CompanyModel>> companies;
		public List<SelectListItem> CompanyList => new List<SelectListItem>(companies.Value
			.Select(x => new SelectListItem()
				{
					Text = x.Name,
					Value = x.Id.ToString()
				}));

		public UserPagedCollection(IReadOnlyList<UserDetailsRenderModel> items, int page, int itemsPerPage, UserFilter filter = null) : base(filter?.Apply(items) ?? items, page, itemsPerPage)
		{
			companies = new Lazy<IList<CompanyModel>>(() => _api.GetAllCompanies<CompanyModel>().Data);

			foreach (UserDetailsRenderModel user in Items)
			{
				user.CompanyList = CompanyList;
			}
		}
	}
}