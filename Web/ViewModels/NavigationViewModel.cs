using System.Web.Mvc;
using TimeshEAT.Web.Navigation;

namespace TimeshEAT.Web.ViewModels
{
	public abstract class NavigationViewModel : BaseViewModel, INavigationViewModel
	{
		public NavigationViewModel()
		{
			Navigation = DependencyResolver.Current.GetService<INavigationContext>();
		}

		public abstract string PageIcon { get; }

		public INavigationContext Navigation { get; }
	}
}