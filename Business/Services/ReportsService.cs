using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;

namespace TimeshEAT.Business.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IRepositoryContext _repositoryContext;

        public ReportsService(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IEnumerable<ReportModel> Get(int? userId, int? categoryId, int? companyId, int? mealId, int? portionId, DateTime? startDate, DateTime? endDate) 
            => _repositoryContext.ReportsRepository.Get(userId, categoryId, companyId, mealId, portionId, startDate, endDate)
                .Select(x => (ReportModel)x);
    }
}
