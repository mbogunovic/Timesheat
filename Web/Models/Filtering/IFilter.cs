using System.Collections.Generic;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Filtering
{
	public interface IFilter
	{
		IReadOnlyList<T> Apply<T>(IReadOnlyList<T> items) where T : IForm;
	}
}
