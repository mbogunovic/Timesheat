using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Attributes
{
	public class RoleAuthorizeAttribute : AuthorizeAttribute
	{
		private string[] roles => this.Roles.Split(',');

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (!base.AuthorizeCore(httpContext))
				return false;

			return this.roles?.Any(r => httpContext.User.IsInRole(r)) ?? httpContext.User.Identity.IsAuthenticated;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Controller.TempData["errorModel"] = new ErrorViewModel("Error 401", "Unauthorized");
			filterContext.Result = new RedirectResult(new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Index", "Error"));
		}
	}
}