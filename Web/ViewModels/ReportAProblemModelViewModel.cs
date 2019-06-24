namespace TimeshEAT.Web.ViewModels
{
    public class ReportAProblemModelViewModel : BaseViewModel
    {
        public override string PageTitle => "Prijavi problem";
        public ReportAProblemModelSubmitViewModel FormModel { get; set; }
    }
}