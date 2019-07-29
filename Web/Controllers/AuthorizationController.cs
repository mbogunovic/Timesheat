using System;
using System.Web.Helpers;
using System.Web.Mvc;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[AllowAnonymous]
	public class AuthorizationController : BaseController
	{
		#region [Login]

		public ActionResult Index()
		{
			if (WebCache.Get(HttpContext.Request.UserHostAddress) ?? false)
			{
				TempData[Constants.ERROR_MODEL] = new ErrorViewModel("Error 403", "Zabranjen pristup zbog previše pokušaja logovanja.");
				return RedirectToAction("Index", "Error");
			}

			return _member.Identity.IsAuthenticated
				? RedirectToAction("Index", "Order", new { month = (Constants.Months)DateTime.Now.Month})
				: (ActionResult)View(new LoginViewModel());
		}


		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Index(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			System.Tuple<bool, string> loginResult = _member.Login(model.Email, StringHasher.GenerateHash(model.Password));
			if (loginResult.Item1)
			{
				return RedirectToAction("Index", "Order", new { month = (Constants.Months)DateTime.Now.Month});
			}

			TempData[Constants.RESPONSE_MESSAGE] = loginResult.Item2;

			return View(model);
		}

		#endregion

		#region [ForgotPassword]

		public ActionResult ForgotPassword()
		 => View(new ForgotPasswordViewModel());

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult ForgotPassword(ForgotPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			_member.ForgotPassword(model.Email);
			TempData[Constants.RESPONSE_MESSAGE] = "Ako email adresa postoji, link za kreaciju nove šifre je poslat na adresu.";

			return View(model);
		}

		#endregion

		#region [ResetPassword]

		public ActionResult ResetPassword(string token)
		{
			if (WebCache.Get(token) == null)
			{
				TempData[Constants.ERROR_MODEL] = new ErrorViewModel("401", "Token nije više važeć");

				return RedirectToAction("Index", "Error");
			}

			return View(new ResetPasswordViewModel(token));
		}

		[HttpGet]
		[Authorize(Roles = "Administrator")]
		public ActionResult ResetPasswordForUser(string email)
		{
			_member.ForgotPassword(email);

			//TODO: JSON RESPONSE MESSAGE MODEL
			return Redirect("/");
		}

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult ResetMyPassword()
        {
            _member.ForgotPassword();

            //TODO: JSON RESPONSE MESSAGE MODEL
            return Redirect("/");
        }

        [ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult ResetPassword(ResetPasswordViewModel model)
		{
			if (!model.NewPassword.Equals(model.RepeatPassword))
			{
				TempData[Constants.RESPONSE_MESSAGE] = "Šifre se ne poklapaju.";
				return View(model);
			}

			if (!(model.NewPassword.Length > 8))
			{
				TempData[Constants.RESPONSE_MESSAGE] = "Šifra mora biti duža od 8 karaktera";
				return View(model);
			}

			if (!ModelState.IsValid)
				return View(model);

			_member.ResetPassword(StringHasher.GenerateHash(model.NewPassword), model.Token);

			return RedirectToAction("Index");
		}

		#endregion

		public ActionResult Logout()
		{
			_member.Logout();
			return RedirectToAction("Index", "Authorization");
		}
	}
}