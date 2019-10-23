using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Web.Extensions;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Navigation
{
	public class NavigationContext : INavigationContext
	{
		private IEnumerable<NavigationItem> _items;
		public IEnumerable<NavigationItem> Items => _items ?? (_items = GetItems().Reverse().ToList());
		public T GetPageViewModel<T>() where T : INavigationViewModel =>
			(T)Items.FirstOrDefault(x => x.PageName.Equals(typeof(T).Name))?.Page;

		private IEnumerable<NavigationItem> GetItems()
		{
			Type type = typeof(INavigationController);
			IEnumerable<Type> itemTypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => !type.Equals(p) && type.IsAssignableFrom(p));

			UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

			foreach (Type itemType in itemTypes)
			{
				string pageName = itemType.Name.RemoveControllerSuffix();
				var authorizeAttribute = itemType.GetCustomAttributes(typeof(AuthorizeAttribute), true).FirstOrDefault() as AuthorizeAttribute;
				if (authorizeAttribute?.Roles.Split(',').Any(role => HttpContext.Current.User.IsInRole(role)) ?? false)
				{
					yield return new NavigationItem(urlHelper.Action("Index", pageName, Constants.DefaultRouteValues(pageName)), pageName);
				}
			}
		}
	}
}