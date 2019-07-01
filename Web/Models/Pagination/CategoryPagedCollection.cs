using System.Collections.Generic;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render;

namespace TimeshEAT.Web.Models.Pagination
{
	public class CategoryPagedCollection : ReadOnlyPagedCollection<CategoryDetailsRenderModel>
	{
		public CategoryPagedCollection(IReadOnlyList<CategoryDetailsRenderModel> items, int page, int itemsPerPage, CategoryFilter filter = null) : base(items, page, itemsPerPage, filter)
		{
		}
	}
}