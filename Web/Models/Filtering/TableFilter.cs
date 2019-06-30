using System.Collections.Generic;
using System.Linq;

namespace TimeshEAT.Web.Models.Filtering
{
	public abstract class TableFilter<T> : IFilter<T>
	{
		public string Letter { get; set; }
		public string Query { get; set; }

		public IReadOnlyList<T> Apply(IReadOnlyList<T> items) =>
			items.Where(x => LetterFiltering(x) && QueryFiltering(x))
				.ToList()
				.AsReadOnly();

		protected abstract bool LetterFiltering(T item);
		protected abstract bool QueryFiltering(T item);
	}
}