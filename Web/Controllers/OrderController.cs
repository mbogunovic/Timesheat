using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Models;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Membership;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "User, Administrator")]
	public class OrderController : BaseController, INavigationController
    {
		public ActionResult Index(Constants.Months? month = null, DateTime? date = null)
		{
			if (date == null)
			{
				var model = this.Navigation.GetPageViewModel<OrderViewModel>();
				model.Date = new DateTime(DateTime.Now.Year, month != null ? (int)month : DateTime.Now.Month, 1);

				return View(model);
			}
			else
			{
				var model = new DayOrderViewModel(date.Value);

				return View("DayOrder", model);
			}
		}
    }
}