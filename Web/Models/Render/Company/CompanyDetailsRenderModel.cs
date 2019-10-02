using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Render.Company
{
	public class CompanyDetailsRenderModel : IForm
	{
		public int Id { get; set; }
		public long Version { get; set; }

		[Required(ErrorMessage = "Ime je obavezno polje.")]
		[Display(Name = "Ime kompanije:")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Email je obavezno polje.")]
		[Display(Name = "Email:")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Dnevni popust je obavezno polje.")]
		[Display(Name = "Dnevni popust:")]
		public int DailyDiscount { get; set; }
		[Display(Name = "Obroci:")]
		public IList<SelectListItem> MealList { get; set; }
		[Display(Name = "Izabrani obroci:")]
		[Required(ErrorMessage = "Morate dodati obroke.")]
		public IEnumerable<int> SelectedMeals { get; set; }
		public IList<MealModel> Meals { get; set; }

		public static implicit operator CompanyModel(CompanyDetailsRenderModel company)
		{
			if (company == null)
				return null;

			var companyModel = new CompanyModel(company.Name, company.Email, company.DailyDiscount, company.Id, company.Version);
			companyModel.SelectedMeals = company.SelectedMeals;

			return companyModel;
		}
	}
}