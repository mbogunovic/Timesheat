using System.Collections.Generic;
using System.Linq;

namespace TimeshEAT.Web.Models.Filtering
{
	public abstract class TableFilter<T> : ITableFilter, IFilter<T>
	{
		protected TableFilter(string letter, string query)
		{
			Query = query;
			Letter = letter;
			Letters = Constants.LETTERS
				.Select(x => new Letter(x))
				.ToList()
				.AsReadOnly();
		}

		public string Letter { get; set; }
		public string Query { get; set; }
		public IReadOnlyList<Letter> Letters { get; private set; }

		public void SetLetters(IEnumerable<T> items) =>
			Letters = Letters
				.Select(x => GetLetter(items, x))
				.ToList()
				.AsReadOnly();

		public IReadOnlyList<T> Apply(IReadOnlyList<T> items) =>
			items.Where(x => LetterFiltering(x) && QueryFiltering(x))
				.ToList()
				.AsReadOnly();

		protected abstract bool LetterFiltering(T item);
		protected abstract bool QueryFiltering(T item);
		protected abstract Letter GetLetter(IEnumerable<T> items, Letter letter);
	}
}