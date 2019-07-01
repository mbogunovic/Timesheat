using System.Web.Mvc;
using TimeshEAT.Web.Attributes;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.Filtering;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.View;

namespace TimeshEAT.Web.Controllers
{
	[RoleAuthorize(Roles = "Administrator")]
	public class CategoryController : BaseController, INavigationController
	{
		public ActionResult Index(int page = 1, string letter = null, string query = null)
		{
			var model = Navigation.GetPageViewModel<CategoryViewModel>();

			model.Page = page;
			model.Filter = new CategoryFilter(letter, query);

			return View(model);
		}


		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Save(CategoryDetailsRenderModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}

			if (model.Id == 0)
			{
				Business.API.Models.ApiResponseModel<CategoryDetailsRenderModel> result = _api.AddCategory<CategoryDetailsRenderModel>(model);
			}
			else
			{
				_api.UpdateCategory<CategoryDetailsRenderModel>(model);
			}

			return RedirectToAction("Index");
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public ActionResult Delete(CategoryDetailsRenderModel model)
		{
			if (model == null)
			{
				return RedirectToAction("Index");
			}

			_api.DeleteCategory(model);

			return RedirectToAction("Index");
		}
	}
}