namespace TimeshEAT.Web.Models.View
{
	public class ReportAProblemModelViewModel : NavigationViewModel
    {
        public override string PageIcon => "bug";
        public override string PageTitle => "Prijavi problem";
        public ReportAProblemModelSubmitViewModel FormModel { get; set; }
    }
}