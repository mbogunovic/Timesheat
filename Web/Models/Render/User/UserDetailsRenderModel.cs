using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.Render
{
	public class UserDetailsRenderModel : IForm
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Puno ime je obavezno polje.")]
		[Display(Name = "Puno ime")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Email je obavezno polje.")]
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Aktivnost je obavezno polje.")]
		public bool IsActive { get; set; }
		[Required(ErrorMessage = "Kompanija je obavezno polje.")]
		public int CompanyId { get; set; }
		[Required]
		public long Version { get; set; }
		[Required]
		public string Password { get; set; }

		public IList<SelectListItem> CompanyList { get; set; }


		public static implicit operator UserModel(UserDetailsRenderModel user)
		{
			if (user == null)
				return null;

			return new UserModel(user.FullName, user.Email, user.Password, user.IsActive, user.CompanyId, user.Id, user.Version);
		}
	}
}