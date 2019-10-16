using System;
using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
    public interface IReportsRepository
    {
        IEnumerable<Report> Get(int? userId, int? categoryId, int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate);
    }
}
