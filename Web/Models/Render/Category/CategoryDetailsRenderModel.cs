using System.ComponentModel.DataAnnotations;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Render
{
	public class CategoryDetailsRenderModel : IForm
	{
		public CategoryDetailsRenderModel()
		{
			ApplicableDailyDiscount = true;
		}

		public int Id { get; set; }
		public long Version { get; set; }

		[Required(ErrorMessage = "Naziv kategorije je obavezno polje.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Primenjiv dnevni popust je obavezno polje.")]
		[Display(Name = "Primenjiv dnevni popust")]
		public bool ApplicableDailyDiscount { get; set; }

		public static implicit operator CategoryModel(CategoryDetailsRenderModel meal)
		{
			if (meal == null)
				return null;

			return new CategoryModel(meal.Name, meal.ApplicableDailyDiscount, meal.Id, meal.Version);
		}
	}
}