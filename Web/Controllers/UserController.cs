using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class UserController : BaseController, INavigationController
	{
		public ActionResult Index(int page = 1)
		{
			var model = Navigation.GetPageViewModel<UserViewModel>();

			model.Page = page;

			return View(model);
		}


		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(UserDetailsRenderModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			if (model.Id == 0)
			{
				model.Password = "unset";
				Business.API.Models.ApiResponseModel<UserDetailsRenderModel> result = _api.AddUser<UserDetailsRenderModel>(model);
				if (result != null)
				{
					_member.ForgotPassword(model.Email);
				}
			}
			else
			{
				_api.UpdateUser<UserDetailsRenderModel>(model);
			}

			return RedirectToAction("Index");
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(UserDetailsRenderModel model)
		{
			if (model == null)
			{
				return RedirectToAction("Index");
			}

			_api.DeleteUser(model);

			return RedirectToAction("Index");
		}
	}
}