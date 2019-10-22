using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.View
{
    public class ReportViewModel : NavigationViewModel
    {
        public ReportViewModel()
        {
            // TODO: obtain available stuff via API and filter results properly
            Categories = _api.GetAllCategories<CategoryModel>().Data.Select(x => new SelectListItem
            {
                Value =  x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Companies = _api.GetAllCompanies<CompanyModel>().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Meals = _api.GetAllMeals<MealModel>().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Portions = _api.GetAllPortions<PortionModel>().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Users = _api.GetAllUsers<UserModel>().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            }).ToList();
        }

        public IList<SelectListItem> Categories { get; }
        public IList<SelectListItem> Companies { get; }
        public IList<SelectListItem> Meals { get; }
        public IList<SelectListItem> Portions { get; }
        public IList<SelectListItem> Users { get; }

        public int? PortionId { get; set; }
        public int? CategoryId { get; set; }
        public int? MealId { get; set; }
        public int? CompanyId { get; set; }
        public int? UserId { get; set; }
        public override string PageIcon => "reports";
        public override string PageTitle => "Izveštaji";
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}