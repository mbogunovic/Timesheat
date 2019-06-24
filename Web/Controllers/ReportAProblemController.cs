using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Common;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
    public class ReportAProblemController : Controller
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

        public string Submit(ReportAProblemModelSubmitViewModel formModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmailSender sender = new EmailSender(_logger);
                    sender.Send(AppSettings.ReportAProblemReceiver, AppSettings.ReportAProblemSender, formModel.Subject,
                        formModel.Message);
                    return "Hvala Vam na prijavi problema.";
                }
                catch
                {
                    return "Doslo je do greske, molimo Vas da pokusate ponovo kasnije.";
                }
            }

            return "Morate popuniti formu.";
        }
    }
}