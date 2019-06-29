using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Web.Models.View;
using WebGrease.Css.Extensions;

namespace TimeshEAT.Web.Attributes
{
	public class RoleAuthorizeAttribute : AuthorizeAttribute
	{
		private string[] roles => Roles.Split(',');

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (!base.AuthorizeCore(httpContext))
			{
				return false;
			}

			return roles?.Any(r => httpContext.User.IsInRole(r.Trim())) ?? httpContext.User.Identity.IsAuthenticated;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Controller.TempData[Constants.ERROR_MODEL] = new ErrorViewModel("Error 401", "Niste prijavljeni ili nemate dovoljne permisije da pristupite ovoj stranici.");
			filterContext.Result = new RedirectResult(new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Index", "Error"));
		}
	}
}