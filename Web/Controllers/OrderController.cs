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
		public ActionResult Index(Constants.Months month)
		{
			var model = this.Navigation.GetPageViewModel<OrderViewModel>();
			model.Date = new DateTime(DateTime.Now.Year, (int) month, 1);

			return View(model);
        }
    }
}