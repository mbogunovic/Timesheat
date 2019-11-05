using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
    [RoleAuthorize(Roles = "User,Administrator")]
    public class ReportController : BaseController, INavigationController
    {
        // GET: Report
        public ActionResult Index()
        {
            var model = Navigation.GetPageViewModel<ReportViewModel>();
            return View(model);
        }

        public ActionResult Filter(int? userId, int? categoryId, int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate)
        {
            var reports = _api.GetReports<ReportModel>(userId, categoryId, companyId, mealId, portionId, startDate, endDate).Data;
            var vm = new ReportListingViewModel(reports);
            return PartialView("~/Views/Report/_ReportListing.cshtml", vm);
        }
    }
}