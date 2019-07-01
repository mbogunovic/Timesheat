using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
    public interface IMealRepository : IRepository<Meal>
    {
        IEnumerable<Meal> GetMealsForCompany(Company company, ITransaction transaction = null);
        void AddMealForCompany(Meal meal, Company company, ITransaction transaction = null);
        void DeleteMealForCompany(Meal meal, Company company, ITransaction transaction = null);
    }
}
