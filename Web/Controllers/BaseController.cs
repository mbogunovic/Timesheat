using System;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Web.Membership;
using TimeshEAT.Web.Navigation;
using TimeshEAT.Web.Models.View;
using System.Web.Helpers;

namespace TimeshEAT.Web.Controllers
{
	public class BaseController : Controller
	{
		protected readonly ILogger _log;
		protected readonly IApiClient _api;
		[Import]
		protected INavigationContext Navigation { get; set; }

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

		//protected override void OnException(ExceptionContext filterContext)
		//{
		//	if (filterContext.ExceptionHandled)
		//	{
		//		return;
		//	}

		//	_log.WriteErrorLog($"Unhandled exception occured for user {User.Identity.Name}", filterContext.Exception);
		//	filterContext.ExceptionHandled = true;

		//	if(filterContext.Exception is UnauthorizedAccessException)
		//	{
		//		_member.Logout();
		//		filterContext.Controller.TempData[Constants.ERROR_MODEL] = new ErrorViewModel("Error401", filterContext.Exception.Message);
		//	}
		//	else
		//	{
		//		filterContext.Controller.TempData[Constants.ERROR_MODEL] = new ErrorViewModel("Error 500", "Nešto je se skrmljalo :/");
		//	}
		//		filterContext.Controller.TempData[Constants.ERROR_MODEL] = filterContext.Exception is UnauthorizedAccessException 
		//		? new ErrorViewModel("Error 401", filterContext.Exception.Message)
		//		: new ErrorViewModel("Error 500", "Something went wrong.");

		//	filterContext.Result = RedirectToAction("Index", "Error");
		//}
	}
}