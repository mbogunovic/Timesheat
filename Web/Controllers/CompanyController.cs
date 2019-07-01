using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class CompanyController : BaseController, INavigationController
    {
		public ActionResult Index(int page = 1)
        {
            var model = Navigation.GetPageViewModel<CompanyViewModel>();
            model.Page = page;
            return View(model);
        }
    }
}