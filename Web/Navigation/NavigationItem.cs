using System;
using System.Reflection;
using System.Web;
using TimeshEAT.Web.Extensions;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Navigation
{
	public class NavigationItem
	{
	
		public NavigationItem(string url, string pageName)
		{
			Url = !string.IsNullOrWhiteSpace(url) ? url : throw new ArgumentNullException(nameof(url));
			PageName = !string.IsNullOrWhiteSpace(pageName) ? pageName.AddViewModelSuffix() : throw new ArgumentNullException(nameof(pageName));
			Page = Activator.CreateInstance(
				Assembly.GetExecutingAssembly().GetType($"{typeof(NavigationViewModel).Namespace}.{PageName}"))
					as INavigationViewModel;
		}

		public INavigationViewModel Page { get; }
		public string PageName { get; }
		public string Url { get; set; }
		public bool IsActive =>
			HttpContext.Current.Request.Url.AbsolutePath.Contains(Url);

	}
}