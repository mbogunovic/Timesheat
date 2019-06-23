using System.Web.Mvc;

namespace TimeshEAT.Web.Controllers
{
	[AllowAnonymous]
	public class ErrorController : BaseController
    {
		public ActionResult Index() =>
			View(TempData["errorModel"]);
    }
}