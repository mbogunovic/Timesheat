using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
    public interface IPortionRepository : IRepository<Portion>
    {
        IEnumerable<Portion> GetPortionsForMeal(Meal meal, ITransaction transaction = null);
        void AddPortionForMeal(Meal meal, Portion portion,ITransaction transaction = null);
        void DeletePortionForMeal(Meal meal, Portion portion, ITransaction transaction = null);
    }
}
