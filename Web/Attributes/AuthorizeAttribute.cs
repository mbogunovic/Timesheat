using System.ComponentModel.Composition;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Web.Attributes
{
	public class RoleAuthorizeAttribute : AuthorizeAttribute
	{
		[Import]
		internal IServiceContext _serivices { get; set; }

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (!base.AuthorizeCore(httpContext))
				return false;


			//TODO: ROLES IMPLEMENT THEN CHECK BY BLAH BLAH BLAH
			return false;//_serivices.GetByEmail(httpContext.User.Identity.Name).IsAdmin;
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			filterContext.Result = new RedirectResult(new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Error401","Error"));
		}
	}
}