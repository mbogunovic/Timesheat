using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Web.Membership;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	public class BaseController : Controller
	{
		protected readonly ILogger _log;
		protected readonly IApiClient _api;

		protected MemberPrincipal _member
		{
			get
			{
				return System.Web.HttpContext.Current.User as MemberPrincipal;
			}
			private set
			{
				System.Web.HttpContext.Current.User = value;
			}
		}

		public BaseController()
		{
			_log = DependencyResolver.Current.GetService<ILogger>();
			_api = DependencyResolver.Current.GetService<IApiClient>();
			_member = _member is MemberPrincipal ? _member : new MemberPrincipal(System.Web.HttpContext.Current.User.Identity, _api);
		}

		protected override void OnException(ExceptionContext filterContext)
		{
			//if (filterContext.ExceptionHandled)
			//{
			//	return;
			//}

			//_log.WriteErrorLog($"Unhandled exception occured for user {User.Identity.Name}", filterContext.Exception);
			//filterContext.ExceptionHandled = true;

			//filterContext.Controller.TempData["errorModel"] = new ErrorViewModel("Error 500", "Something went wrong.");
			//filterContext.Result = RedirectToAction("Index", "Error");
		}
	}
}