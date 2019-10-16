using System.Collections.Generic;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Web.Models.View
{
    public class ReportListingViewModel
    {
        public ReportListingViewModel(List<ReportModel> reports)
        {
            Reports = reports;
        }
        public List<ReportModel> Reports { get; set; }
    }
}