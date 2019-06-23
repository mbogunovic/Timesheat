using System.Web.Mvc;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	[AllowAnonymous]
	public class AuthorizationController : BaseController
	{
		public ActionResult Index() =>
			_member.Identity.IsAuthenticated 
				? RedirectToAction("Index", "Home")
				: (ActionResult)View(new LoginViewModel());

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Index(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var loginResult = _member.Login(model.Email, StringHasher.GenerateHash(model.Password));
			if (loginResult.Item1)
				return RedirectToAction("Index", "Home");

			TempData[Constants.RESPONSE_MESSAGE] = loginResult.Item2;

			return View(model);
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
			return RedirectToAction("Index", "Authorization");
		}
	}
}