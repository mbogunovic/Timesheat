using System.Collections.Generic;
using System.Linq;
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
				return RedirectToAction("Index");
			}

            var selectedMeals = model.MealPortionsIds?.Split(',');
            if (selectedMeals == null)
            {
                model.Portions = new List<PortionModel>();
            }
            else
            {
                model.Portions = _api.GetAllPortions<PortionModel>()?.Data.Where(m => selectedMeals.Contains(m.Id.ToString()))
                    .ToList();
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

            var selectedPortions = model.MealPortionsIds?.Split(',');
            if (selectedPortions == null)
            {
                model.Portions = new List<PortionModel>();
            }
            else
            {
                model.Portions = _api.GetAllPortions<PortionModel>()?.Data
                    .Where(m => selectedPortions.Contains(m.Id.ToString())).ToList();
            }

            _api.DeleteMeal(model);

			return RedirectToAction("Index");
		}
	}
}