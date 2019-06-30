using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeshEAT.Web.Interfaces;
using TimeshEAT.Web.Models.Render.Company;

namespace TimeshEAT.Web.Models.Filtering
{
    public class CompanyFilter : IFilter<CompanyDetailsRenderModel>
    {
        public string Letter { get; set; }
        public string Query { get; set; }

        public IReadOnlyList<CompanyDetailsRenderModel> Apply(IReadOnlyList<CompanyDetailsRenderModel> items) =>
            items.Where(x => LetterFiltering(x) && QueryFiltering(x))
                .ToList()
                .AsReadOnly();

        private bool LetterFiltering(CompanyDetailsRenderModel user) => true;
        private bool QueryFiltering(CompanyDetailsRenderModel user) => true;
    }
}