using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Web.Models.View
{
	public class ReportListingViewModel
	{
		public ReportListingViewModel(List<ReportModel> reports)
		{
			Reports = reports;
			Total = reports.Sum(x => x.Price);
			TotalDiscounted = reports.Sum(x => x.DiscountedPrice);
		}
		public List<ReportModel> Reports { get; set; }

		public int Total { get; set; }
		public int TotalDiscounted { get; set; }
	}
}