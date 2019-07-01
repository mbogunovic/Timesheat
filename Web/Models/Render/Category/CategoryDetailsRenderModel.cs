using System.ComponentModel.DataAnnotations;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Render
{
	public class CategoryDetailsRenderModel : IForm
	{
		public int Id { get; set; }
		public long Version { get; set; }

		[Required(ErrorMessage = "Naziv kategorije je obavezno polje.")]
		[Display(Name = "Naziv kategorije")]
		public string Name { get; set; }

		public static implicit operator CategoryModel(CategoryDetailsRenderModel meal)
		{
			if (meal == null)
				return null;

			return new CategoryModel(meal.Name, meal.Id, meal.Version);
		}
	}
}