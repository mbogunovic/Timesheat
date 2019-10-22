using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeshEAT.API.Attributes;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;

namespace TimeshEAT.API.Controllers
{
    /// <summary>
    /// Endpoints for reports, requires token authorization
    /// </summary>
    [TokenAuthorize]
    public class ReportsController : ApiController
    {
        private readonly IServiceContext _serviceContext;

        public ReportsController(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        /// <summary>
        /// Endpoint for obtaining reports
        /// </summary>
        /// <param name="userId">Id of the user used for filtering the report</param>
        /// <param name="companyId">Id of the company used for filtering the report</param>
        /// <param name="mealId">Id of the meal used for filtering the report</param>
        /// <param name="portionId">Id of the portion used for filtering the report</param>
        /// <param name="startDate">Start date filter for the report (inclusive)</param>
        /// <param name="endDate">End date filter for the report (inclusive)</param>
        /// <returns>All reports if no parameter has value, otherwise filtered report</returns>
        public IEnumerable<ReportModel> Get(int? userId, int? categoryId,int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate)
            => _serviceContext.Reports.Get(userId, categoryId, companyId, mealId, portionId, startDate, endDate);
    }
}
