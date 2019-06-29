using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Render
{
	public class UserDetailsRenderModel : IForm
	{
		[Required(ErrorMessage = "Puno ime je obavezno polje.")]
		[Display(Name = "Puno ime")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Email je obavezno polje.")]
		[Display(Name = "Email")]
		public string Email { get; set; }
		public bool IsActive { get; set; }
		public int CompanyId { get; set; }

		public IList<SelectListItem> CompanyList { get; set; }
	}
}