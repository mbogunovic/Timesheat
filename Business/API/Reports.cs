using System;
using System.Collections.Generic;
using RestSharp;
using TimeshEAT.Business.API.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient
    {
        public ApiResponseModel<List<T>> GetReports<T>(int? userId = null, int? categoryId = null, int? companyId = null, int? mealId = null, int? portionId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            RestRequest request = new RestRequest("api/reports");
            request.AddParameter("userId", userId);
            request.AddParameter("categoryId", categoryId);
            request.AddParameter("companyId", companyId);
            request.AddParameter("mealId", mealId);
            request.AddParameter("portionId", portionId);
            request.AddParameter("startDate", startDate);
            request.AddParameter("endDate", endDate);

            return ExecuteList<List<T>>(request);
        }
    }
}
