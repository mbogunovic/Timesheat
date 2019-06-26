using System.Collections.Generic;
using System.Linq;

namespace TimeshEAT.Web.Models.Additional
{
	public class ReadOnlyPagedCollection<T>
	{
		public ReadOnlyPagedCollection(IReadOnlyList<T> items, int page, int itemsPerPage, string query = null)
		{
			Query = query;
			TotalCount = items.Count;
			Items = items
				.Skip((page - 1) * itemsPerPage)
				.Take(itemsPerPage)
				.ToList();
			Pagination = new PaginationModel(page, (this.TotalCount / itemsPerPage) + (this.TotalCount % itemsPerPage != 0 ? 1 : 0), 2);
		}

		public IReadOnlyList<T> Items { get; }
		public PaginationModel Pagination { get; }
		public int TotalCount { get; }
		public string Query { get; }
	}
}