using System.Collections.Generic;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Filtering
{
	public interface IFilter<T> where T : IForm
    {
        IReadOnlyList<T> Apply(IReadOnlyList<T> items);
    }
}
