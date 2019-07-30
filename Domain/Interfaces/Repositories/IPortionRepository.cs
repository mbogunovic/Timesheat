using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
    public interface IPortionRepository : IRepository<Portion>
    {
        IEnumerable<MealPortion> GetPortionsForMeal(Meal meal, ITransaction transaction = null);
        void AddPortionForMeal(MealPortion mealPortion,ITransaction transaction = null);
        void DeletePortionForMeal(MealPortion mealPortion, ITransaction transaction = null);
    }
}
