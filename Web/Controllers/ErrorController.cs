using System.Web.Mvc;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	[AllowAnonymous]
	public class ErrorController : BaseController
    {
		public ActionResult Index() =>
			View(TempData[Constants.ERROR_MODEL]);

		public ActionResult NotFound()
		{
			TempData[Constants.ERROR_MODEL] = new ErrorViewModel("Error 404", "Not found.");
			return RedirectToAction("Index");
		}
    }
}