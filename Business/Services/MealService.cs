using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.EqualityComparers;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Common.Extensions;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Services
{
	public class MealService : BaseService, IMealService
	{
		public MealService(IRepositoryContext context) : base(context) { }

		public IEnumerable<MealModel> Get()
		{
			var result = _context.MealRepository.GetAll()
				.Select(x => (MealModel)x).ToList();

            foreach (var meal in result)
            {
	            meal.Category = _context.CategoryRepository.GetById(meal.CategoryId);
                meal.Portions = _context.PortionRepository.GetPortionsForMeal(meal).Select(p => (PortionModel)p);
            }

			return result;
		}

		public IEnumerable<MealModel> GetBy(CompanyModel company)
		{
			var result = _context.MealRepository.GetMealsForCompany(company)
				.Select(x => (MealModel) x).ToList();

			foreach (var meal in result)
			{
				meal.Category = _context.CategoryRepository.GetById(meal.CategoryId);
				meal.Portions = _context.PortionRepository.GetPortionsForMeal(meal).Select(p => (PortionModel)p);
			}

			return result;
		}

		public MealModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			var result = (MealModel)_context.MealRepository.GetById(id);
            result.Portions = _context.PortionRepository.GetPortionsForMeal(result).Select(p => (PortionModel) p);
			return result;
		}

		public MealModel Add(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			var result = _context.MealRepository.Insert(meal);
            if (meal.Portions.HasValue())
            {
                foreach (var portion in meal.Portions)
                {
                    _context.PortionRepository.AddPortionForMeal(meal, portion);
                }
            }

			return result;
		}

		public MealModel Save(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			var result = _context.MealRepository.Update(meal);

            var existingPortions = _context.PortionRepository.GetPortionsForMeal(meal).Select(p => (PortionModel)p).ToList();

            foreach (var addedPortion in meal.Portions.Except(existingPortions, new PortionEqualityComparer()))
            {
                _context.PortionRepository.AddPortionForMeal(meal, addedPortion);
            }

            foreach (var removedPortion in existingPortions.Except(meal.Portions, new PortionEqualityComparer()))
            {
                _context.PortionRepository.DeletePortionForMeal(meal, removedPortion);
            }

			return result;
		}

		public void Remove(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

            foreach (var portion in _context.PortionRepository.GetPortionsForMeal(meal))
            {
                _context.PortionRepository.DeletePortionForMeal(meal, portion);
            }
			_context.MealRepository.Delete(meal);
        }
	}
}
