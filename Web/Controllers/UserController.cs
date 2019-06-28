using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class UserController : BaseController, INavigationController
    {
		public ActionResult Index()
        {
            return View(this.Navigation.GetPageViewModel<UserViewModel>());
        }
    }
}