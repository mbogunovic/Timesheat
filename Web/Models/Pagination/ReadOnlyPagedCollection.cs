using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Web.Models.Filtering;

namespace TimeshEAT.Web.Models.Pagination
{
	public class ReadOnlyPagedCollection<T>
	{
		protected readonly IApiClient _api;


		public ReadOnlyPagedCollection(IReadOnlyList<T> items, int page, int itemsPerPage, IFilter<T> filter)
		{
			_api = DependencyResolver.Current.GetService<IApiClient>();
			TotalCount = items.Count;
			Items = filter?.Apply(items) ?? items
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.ToList();
			Pagination = new PaginationRenderModel(page, (this.TotalCount / itemsPerPage) + (this.TotalCount % itemsPerPage != 0 ? 1 : 0), 2);
		}

		public IReadOnlyList<T> Items { get; }
		public PaginationRenderModel Pagination { get; }
		public int TotalCount { get; }
	}
}