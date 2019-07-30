using System;
using System.Web.Mvc;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Common;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "User")]
	public class ReportAProblemController : BaseController
	{
		public ActionResult Index() =>
         View(new ReportAProblemModelViewModel());
        
        public ActionResult Submit(ReportAProblemModelSubmitViewModel model)
        {
	        if (ModelState.IsValid)
            {
                try
                {
                    EmailSender sender = new EmailSender(_log);
                    sender.Send(AppSettings.DefaultEmail, AppSettings.DefaultEmail, model.Subject,
                        model.Message);
                    return PartialView("_Message", "Hvala vam što ste prijavili problem, pokušaćemo da rešimo problem u najkraćem roku!");
                }
				catch(Exception e)
                {
					return PartialView("_Message", e.Message);
				}
			}

			return PartialView("_ReportAProblemForm", model);
        }
    }
}