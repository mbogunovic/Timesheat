﻿using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.ViewModels;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize]
	public class OrderController : BaseController, INavigationController
    {
		public ActionResult Index()
        {
            return View(this.Navigation.GetPageViewModel<OrderViewModel>());
        }
    }
}