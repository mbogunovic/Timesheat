using System.ComponentModel.DataAnnotations;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.ViewModels
{
	public class LoginViewModel : BaseViewModel, IForm
	{
		[Required(ErrorMessage = "Email adresa je obavezno polje.")]
		[EmailAddress(ErrorMessage = "Email adresa mora biti važećeg formata.")]
		[Display(Name = "Email adresa")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Lozinka je obavezno polje.")]
		[Display(Name = "Lozinka")]
		public string Password { get; set; }

		public override string PageTitle => "Uloguj se";
	}
}