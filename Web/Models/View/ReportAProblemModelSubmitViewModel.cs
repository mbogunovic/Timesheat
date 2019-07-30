using System.ComponentModel.DataAnnotations;
using TimeshEAT.Web.Interfaces;

namespace TimeshEAT.Web.Models.View
{
	public class ReportAProblemModelSubmitViewModel : IForm
    {
	    [Display(Name = "Tema")]
	    [Required(ErrorMessage = "Tema ne može biti prazna!")]
        public string Subject { get; set; }
        [Display(Name = "Poruka")]
        [Required(ErrorMessage = "Poruka ne može biti prazna!")]
        public string Message { get; set; }
    }
}