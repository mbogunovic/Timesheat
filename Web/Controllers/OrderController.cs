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
				return View("DayOrder", new DayOrderViewModel(date.Value));
			}
		}
    }
}