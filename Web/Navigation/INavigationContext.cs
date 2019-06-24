using System.Collections.Generic;

namespace TimeshEAT.Web.Navigation
{
	public interface INavigationContext
	{
		IEnumerable<NavigationItem> Items { get; }
		T GetPageViewModel<T>() where T : INavigationViewModel;
	}
}