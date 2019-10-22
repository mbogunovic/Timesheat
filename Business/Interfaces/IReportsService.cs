using System;
using System.Collections.Generic;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.Interfaces
{
    public interface IReportsService
    {
        IEnumerable<ReportModel> Get(int? userId, int? categoryId, int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate);
    }
}
