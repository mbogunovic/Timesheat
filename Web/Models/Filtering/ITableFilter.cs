using System.Collections.Generic;

namespace TimeshEAT.Web.Models.Filtering
{
	public interface ITableFilter
    {
		string Letter { get; set; }
		string Query { get; set; }
		IReadOnlyList<Letter> Letters { get; }
	}
}
