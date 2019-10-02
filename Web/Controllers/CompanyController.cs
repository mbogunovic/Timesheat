﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render.Company;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class CompanyController : BaseController, INavigationController
	{
		public ActionResult Index(int page = 1, string letter = null, string query = null)
		{
			var model = Navigation.GetPageViewModel<CompanyViewModel>();
			model.Page = page;
			model.Filter = new CompanyFilter(letter, query);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(CompanyDetailsRenderModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			if (model.Id == 0)
			{
				Business.API.Models.ApiResponseModel<CompanyDetailsRenderModel> result = _api.AddCompany<CompanyDetailsRenderModel>(model);
			}
			else
			{
				_api.UpdateCompany<CompanyDetailsRenderModel>(model);
			}

			return RedirectToAction("Index");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(CompanyDetailsRenderModel model)
		{
			if (model == null)
			{
				return RedirectToAction("Index");
			}

			_api.DeleteCompany(model);

			return RedirectToAction("Index");
		}
	}
}