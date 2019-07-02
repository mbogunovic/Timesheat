using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Pagination;
using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.View
{
	public class CompanyViewModel : NavigationViewModel
	{
        public CompanyViewModel()
        {
            companies = new Lazy<IEnumerable<CompanyDetailsRenderModel>>(() => _api.GetAllCompanies<CompanyDetailsRenderModel>()?.Data.OrderBy(c => c.Name));
            searchResult = new Lazy<CompanyPagedCollection>(() => Search());
        }

		public override string PageTitle => "Kompanije";
		public override string PageIcon => "company";
        public int Page { get; set; } = 1;
		private CompanyFilter _filter;
		public CompanyFilter Filter
		{
			get
			{
				_filter.SetLetters(companies.Value);
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}

		private readonly Lazy<IEnumerable<CompanyDetailsRenderModel>> companies;
        private readonly Lazy<CompanyPagedCollection> searchResult;

        public CompanyPagedCollection Companies => searchResult.Value;

        private CompanyPagedCollection Search() =>
            new CompanyPagedCollection(companies.Value.ToList(), Page, Constants.ITEMS_PER_AGE, Filter);
    }
}