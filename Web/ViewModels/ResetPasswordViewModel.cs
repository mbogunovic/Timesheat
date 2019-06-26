using System.ComponentModel.DataAnnotations;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.ViewModels
{
	public class ResetPasswordViewModel : BaseViewModel, IForm
	{
		public override string PageTitle => "Resetuj šifru";

		public ResetPasswordViewModel() { }

		public ResetPasswordViewModel(string token)
		{
			Token = token;
		}

		[Required(ErrorMessage = "Nova lozinka je obavezno polje.")]
		[Display(Name = "Nova lozinka")]
		public string NewPassword { get; set; }
		[Required(ErrorMessage = "Ponovljena nova lozinka je obavezno polje.")]
		[Display(Name = "Ponovljena nova lozinka")]
		public string RepeatPassword { get; set; }
		[Required]
		public string Token { get; set; }
	}
}