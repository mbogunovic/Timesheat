using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.API;

namespace TimeshEAT.Web.Models.Pagination
{
	public class ReadOnlyPagedCollection<T>
	{
		protected readonly IApiClient _api;

		public ReadOnlyPagedCollection(IReadOnlyList<T> items, int page, int itemsPerPage, string query = null)
		{
			_api = DependencyResolver.Current.GetService<IApiClient>();
			Query = query;
			TotalCount = items.Count;
			Items = items
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.ToList();
			Pagination = new PaginationRenderModel(page, (this.TotalCount / itemsPerPage) + (this.TotalCount % itemsPerPage != 0 ? 1 : 0), 2);
		}

		public IReadOnlyList<T> Items { get; }
		public PaginationRenderModel Pagination { get; }
		public int TotalCount { get; }
		public string Query { get; }
	}
}