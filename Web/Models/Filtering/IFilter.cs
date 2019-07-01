using System.Collections.Generic;

namespace TimeshEAT.Web.Models.Filtering
{
	public interface IFilter<T>
    {
        IReadOnlyList<T> Apply(IReadOnlyList<T> items);
    }
}
