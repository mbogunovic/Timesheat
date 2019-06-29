using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Web.Navigation;

namespace TimeshEAT.Web.Models.View
{
	public abstract class NavigationViewModel : BaseViewModel, INavigationViewModel
	{
		protected IApiClient _api;

		public NavigationViewModel()
		{
			Navigation = DependencyResolver.Current.GetService<INavigationContext>();
			_api = DependencyResolver.Current.GetService<IApiClient>();
		}

		public abstract string PageIcon { get; }
		public INavigationContext Navigation { get; }
	}
}