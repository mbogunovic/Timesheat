using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize]
	public class HomeController : BaseController
    {
		public ActionResult Index()
        {
            return View(new HomeViewModel());
        }
    }
}