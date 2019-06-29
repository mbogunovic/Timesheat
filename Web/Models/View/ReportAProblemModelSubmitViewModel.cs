using System.ComponentModel.DataAnnotations;

namespace TimeshEAT.Web.Models.View
{
	public class ReportAProblemModelSubmitViewModel
    {
        [Required(ErrorMessage = "Tema ne moze biti prazna!")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Poruka ne moze biti prazna!")]
        public string Message { get; set; }
    }
}