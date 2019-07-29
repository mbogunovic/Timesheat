using System.Web.Mvc;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Common;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "User")]
	public class ReportAProblemController : BaseController
	{
        private readonly ILogger _logger;

        public ReportAProblemController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ReportAProblemModelViewModel model = new ReportAProblemModelViewModel();
            model.FormModel = new ReportAProblemModelSubmitViewModel();
            return View(model);
        }

        public ActionResult Submit(ReportAProblemModelSubmitViewModel formModel)
        {
			ReportAProblemModelViewModel model = new ReportAProblemModelViewModel();
			model.FormModel = formModel;

			if (ModelState.IsValid)
            {
                try
                {
                    EmailSender sender = new EmailSender(_logger);
                    sender.Send(AppSettings.DefaultEmail, AppSettings.DefaultEmail, formModel.Subject,
                        formModel.Message);
					return View("Index", model);
				}
				catch
                {
					return View("Index", model);
				}
			}

			return View("Index", model);
        }
    }
}