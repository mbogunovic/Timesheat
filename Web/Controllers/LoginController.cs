using System.Web.Mvc;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	[AllowAnonymous]
	public class LoginController : BaseController
	{
		public LoginController(ILogger log, IServiceContext services) : base(log, services)
		{
		}

		public ActionResult Index()
		{
			if (_member.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(new LoginViewModel());
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Index(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			switch (_member.Login(model.Email, StringHasher.GenerateHash(model.Password)))
			{
				case Membership.MemberPrincipal.LoginStatus.Successfull:
					return RedirectToAction("Index", "Home");
				case Membership.MemberPrincipal.LoginStatus.Unsuccessfull:
					return View(model);
				case Membership.MemberPrincipal.LoginStatus.LockedOut:
					return View(model);
				default:
					return View(model);
			};
		}

		public ActionResult ForgotPassword()
		 => View(new ForgotPasswordViewModel());

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult ForgotPassword(ForgotPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			_member.ResetPassword(model.Email);

			return View();
		}

		public ActionResult Logout()
		{
			_member.Logout();
			return RedirectToAction("Index", "Login");
		}
	}
}