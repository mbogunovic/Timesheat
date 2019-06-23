using System.Web.Mvc;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Logging.Interfaces;

namespace TimeshEAT.Web.Controllers
{
	[AllowAnonymous]
	public class ErrorController : BaseController
    {
		public ErrorController(ILogger log, IServiceContext services) : base(log, services)
		{
		}

		public ActionResult Error401()
        {
            return View();
        }
    }
}