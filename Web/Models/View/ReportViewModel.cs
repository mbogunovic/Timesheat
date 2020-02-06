using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeshEAT.Business.Models;
using TimeshEAT.Web.Membership;
using TimeshEAT.Web.Models.Render;
using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.View
{
    public class ReportViewModel : NavigationViewModel
    {
        public ReportViewModel()
        {
            var user = HttpContext.Current.User as MemberPrincipal;
            var isUserAdmin = user.IsInRole("Administrator");
            var categories = _api.GetAllCategories<CategoryModel>().Data;
            var companies = _api.GetAllCompanies<CompanyModel>().Data
                .Where(x => isUserAdmin || x.Id == user.Company.Id)
                .ToList();
            var meals = _api.GetAllMeals<MealModel>().Data
                .Where(x => isUserAdmin || (user.Company.Meals?.Any(m => m.Id == x.Id)?? false))
                .ToList();
            var portions = _api.GetAllPortions<PortionModel>().Data;

            Companies = companies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Meals = meals.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            Portions = isUserAdmin ?
                meals.SelectMany(x => x.MealPortions.Select(c => new SelectListItem
                {
                    Text = c.Portion.Name,
                    Value = c.Portion.Id.ToString()
                })).ToList()
                : portions
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
            Users = isUserAdmin ?
                _api.GetAllUsers<UserModel>().Data.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.FullName
                }).ToList()
                : new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = user.FullName,
                        Value = user.Id.ToString()
                    }
                };
            Categories = isUserAdmin ?
                categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
                : meals.Select(x => new SelectListItem
                {
                    Text = x.Category.Name,
                    Value = x.Category.Id.ToString()
                }).ToList();
        }

        public IList<SelectListItem> Categories { get; }
        public IList<SelectListItem> Companies { get; }
        public IList<SelectListItem> Meals { get; }
        public IList<SelectListItem> Portions { get; }
        public IList<SelectListItem> Users { get; }

		[Display(Name = "Porcija:")]
        public int? PortionId { get; set; }
		[Display(Name = "Kategorija:")]
        public int? CategoryId { get; set; }
		[Display(Name = "Obrok:")]
        public int? MealId { get; set; }
		[Display(Name = "Kompanija:")]
        public int? CompanyId { get; set; }
		[Display(Name = "Korisnik:")]
        public int? UserId { get; set; }
        public override string PageIcon => "reports";
        public override string PageTitle => "Izveštaji";
		[Display(Name = "Od:")]
        public DateTime? StartDate { get; set; }
		[Display(Name = "Do:")]
        public DateTime? EndDate { get; set; }
    }
}