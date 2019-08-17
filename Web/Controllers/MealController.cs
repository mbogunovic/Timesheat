using System.Linq;
using System.Net;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class MealController : BaseController, INavigationController
	{
		public ActionResult Index(int page = 1, string letter = null, string query = null)
		{
			var model = Navigation.GetPageViewModel<MealViewModel>();

			model.Page = page;
			model.Filter = new MealFilter(letter, query);

			return View(model);
		}


		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(MealDetailsRenderModel model)
		{
			if (!ModelState.IsValid)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(ModelState.ToDictionary(x => x.Key, x => x.Value.Errors.FirstOrDefault()));
			}

			if (model.Id == 0)
			{
				Business.API.Models.ApiResponseModel<MealDetailsRenderModel> result = _api.AddMeal<MealDetailsRenderModel>(model);
			}
			else
			{
				_api.UpdateMeal<MealDetailsRenderModel>(model);
			}

			return RedirectToAction("Index");
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(MealDetailsRenderModel model)
		{
			if (model == null)
			{
				return RedirectToAction("Index");
			}

            _api.DeleteMeal(model);

			return RedirectToAction("Index");
		}
	}
}