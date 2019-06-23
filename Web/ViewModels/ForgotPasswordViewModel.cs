using System.ComponentModel.DataAnnotations;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.ViewModels
{
	public class ForgotPasswordViewModel : IForm
	{
		[Required(ErrorMessage = "Email adresa je obavezno polje.")]
		[EmailAddress(ErrorMessage = "Email adresa mora biti važećeg formata.")]
		[Display(Name = "Email adresa")]
		public string Email { get; set; }
	}
}