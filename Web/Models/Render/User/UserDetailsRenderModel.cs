using System.Collections.Generic;
using System.Web.Mvc;

namespace TimeshEAT.Web.Models.Render
{
	public class UserDetailsRenderModel
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public bool IsActive { get; set; }
		public int CompanyId { get; set; }

		public IList<SelectListItem> Companies { get; set; }
	}
}