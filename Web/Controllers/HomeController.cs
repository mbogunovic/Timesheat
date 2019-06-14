using System.Web.Mvc;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Logging.Interfaces;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize]
	public class HomeController : BaseController
    {
		public HomeController(ILogger log, IServiceContext services) : base(log, services)
		{
		}

		public ActionResult Index()
        {
            return View();
        }
    }
}