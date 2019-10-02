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
                meal.MealPortions = _context.PortionRepository.GetPortionsForMeal(meal).Select(p => new MealPortionModel
                {
                    Meal = meal,
                    Portion = (PortionModel)_context.PortionRepository.GetById(p.PortionId),
                    Price = p.Price
                });
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
				meal.MealPortions = _context.PortionRepository.GetPortionsForMeal(meal).Select(p => new MealPortionModel
                {
                    Meal = meal,
                    Portion = _context.PortionRepository.GetById(p.PortionId),
                    Price = p.Price
                });
			}

			return result;
		}

		public MealModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			var result = (MealModel)_context.MealRepository.GetById(id);
            result.MealPortions = _context.PortionRepository.GetPortionsForMeal(result).Select(p => new MealPortionModel
            {
                Meal = result,
                Portion = _context.PortionRepository.GetById(p.PortionId),
                Price = p.Price
            });
            return result;
		}

		public MealModel Add(MealModel meal)
		{
			//TODO: ADD TRANSACTION
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			var result = _context.MealRepository.Insert(meal);
            if (meal.SelectedMealPortions.HasValue())
            {
                foreach (var portion in meal.SelectedMealPortions)
                {
                    _context.PortionRepository.AddPortionForMeal(new MealPortion
                    {
                        MealId = result.Id,
                        PortionId = portion.Key,
                        Price = portion.Value
                    });
                }
            }

			return result;
		}

		public MealModel Save(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			var result = _context.MealRepository.Update(meal);

			var existingPortions = _context.PortionRepository.GetPortionsForMeal(meal).Select(p => new KeyValuePair<int,int>(p.PortionId, p.Price));

			foreach (var removedPortion in existingPortions.Except(meal.SelectedMealPortions))
			{
				_context.PortionRepository.DeletePortionForMeal(new MealPortion
				{
					MealId = meal.Id,
					PortionId = removedPortion.Key,
					Price = removedPortion.Value
				});
			}

			foreach (var addedPortion in meal.SelectedMealPortions.Except(existingPortions))
            {
                _context.PortionRepository.AddPortionForMeal(new MealPortion
                {
                    MealId = meal.Id,
                    PortionId = addedPortion.Key,
                    Price = addedPortion.Value
                });
            }

			return result;
		}

		public void Remove(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

            foreach (var portion in _context.PortionRepository.GetPortionsForMeal(meal))
            {
                _context.PortionRepository.DeletePortionForMeal(portion);
            }
			_context.MealRepository.Delete(meal);
        }
	}
}
