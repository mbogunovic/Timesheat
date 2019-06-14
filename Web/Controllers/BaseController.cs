using System;
using System.Web.Mvc;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Web.Logging.Interfaces;

namespace TimeshEAT.Web.Controllers
{
	public class BaseController : Controller
    {
		protected readonly ILogger _log;
		protected readonly IServiceContext _services;
		
		public BaseController(ILogger log, IServiceContext services)
		{
			_log = log;
			_services = services ?? throw new ArgumentNullException(nameof(services));
		}
	}
}