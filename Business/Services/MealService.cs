using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Business.Services
{
	public class MealService : BaseService, IMealService
	{
		public MealService(IRepositoryContext context) : base(context) { }

		public IEnumerable<MealModel> Get()
		{
			var result = _context.MealRepository.GetAll()
				.Select(x => (MealModel)x);

			return result;
		}

		public MealModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			var result = _context.MealRepository.GetById(id);

			return result;
		}

		public MealModel Add(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			var result = _context.MealRepository.Insert(meal);

			return result;
		}

		public MealModel Save(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			var result = _context.MealRepository.Update(meal);

			return result;
		}

		public void Remove(MealModel meal)
		{
			if (meal == null) throw new ArgumentNullException(nameof(meal), "Meal cannot be null!");

			_context.MealRepository.Delete(meal);
		}
	}
}
