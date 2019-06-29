using System.ComponentModel.DataAnnotations;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.View
{
	public class ForgotPasswordViewModel : BaseViewModel, IForm
	{
		[Required(ErrorMessage = "Email adresa je obavezno polje.")]
		[EmailAddress(ErrorMessage = "Email adresa mora biti važećeg formata.")]
		[Display(Name = "Email adresa")]
		public string Email { get; set; }

		public override string PageTitle => "Resetuj šifru";
	}
}