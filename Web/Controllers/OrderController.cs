using System;
using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "User, Administrator")]
	public class OrderController : BaseController, INavigationController
    {
		public ActionResult Index(Constants.Months? month = null)
		{
			var model = this.Navigation.GetPageViewModel<OrderViewModel>();
			model.Date = month != null ? new DateTime(DateTime.Now.Year, (int)month, 1) : model.Date;

			return View(model);
        }
    }
}