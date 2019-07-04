using System;
using System.Collections.Generic;
using System.Linq;
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

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(OrderDetailsRenderModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index", new { date = model.OrderDate });
			}

			if (model.Id == 0)
			{
				Business.API.Models.ApiResponseModel<OrderDetailsRenderModel> result = _api.AddOrder<OrderDetailsRenderModel>(model);
			}
			else
			{
				_api.UpdateOrder<OrderDetailsRenderModel>(model);
			}

			return RedirectToAction("Index", new { date = model.OrderDate });
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(OrderDetailsRenderModel model)
		{
			if (model == null)
			{
				return RedirectToAction("Index");
			}

			_api.DeleteOrder(model);

			return RedirectToAction("Index", new { date = model.OrderDate });
		}

		[HttpGet]
		public JsonResult GetMealList(int? categoryId)
		{
			if (categoryId == null) return null;

			var result = _member.Company?.Meals?
				.Where(x => x.CategoryId.Equals(categoryId))
				.Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name}) ?? new List<SelectListItem>();

			return Json(result, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public JsonResult GetPortionList(int? mealId)
		{
			if (mealId == null) return null;

			var result = _member.Company?.Meals?
				             .First(x => x.Id.Equals(mealId))?.Portions
				             .Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name}) ?? new List<SelectListItem>();

			return Json(result, JsonRequestBehavior.AllowGet);
		}
    }
}