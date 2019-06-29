using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class UserController : BaseController, INavigationController
    {
		public ActionResult Index()
        {
            return View(this.Navigation.GetPageViewModel<UserViewModel>());
        }


		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(UserDetailsRenderModel model)
		{
			if (!ModelState.IsValid)
				return PartialView("_UserDetails", model);

			_api.UpdateUser<UserDetailsRenderModel>(model);

			return RedirectToAction("Index");
		}

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(UserDetailsRenderModel model)
        {
            if (!ModelState.IsValid)
            {
                return new EmptyResult();
            }

            _api.DeleteUser(new UserModel(model.FullName, model.Email, model.Password, model.IsActive, model.CompanyId, model.Id, model.Version));


            return RedirectToAction("Index");
        }
    }
}