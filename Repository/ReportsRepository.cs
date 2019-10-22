using System;
using System.Collections.Generic;
using TimeshEAT.DataAccess.SQLAccess;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly IReportsRepository _provider = new ReportsProvider();
        public IEnumerable<Report> Get(int? userId, int? categoryId, int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate)
            => _provider.Get(userId, categoryId, companyId, mealId, portionId, startDate, endDate);
    }
}
