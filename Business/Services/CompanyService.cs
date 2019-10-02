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
	public class CompanyService : BaseService, ICompanyService
	{
		public CompanyService(IRepositoryContext context) : base(context) { }

		public IEnumerable<CompanyModel> Get()
		{
			var result = _context.CompanyRepository.GetAll()
				.Select(x => (CompanyModel)x).ToList();

            foreach (var company in result)
            {
                company.Meals = new MealService(_context).GetBy(company).ToList();
            }

			return result;
		}

		public CompanyModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			var result = (CompanyModel)_context.CompanyRepository.GetById(id);
            result.Meals = new MealService(_context).GetBy(result).ToList();

			return result;
		}

		public CompanyModel Add(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

			var result = _context.CompanyRepository.Insert(company);

            if (company.SelectedMeals.HasValue())
            {
                foreach (var mealId in company.SelectedMeals)
                {
                    _context.MealRepository.AddMealForCompany(new Meal() { Id = mealId }, result);
                }
            }

			return result;
		}

		public CompanyModel Save(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

			var result = _context.CompanyRepository.Update(company);
            var existingMeals = _context.MealRepository.GetMealsForCompany(company).Select(p => p.Id);

			foreach (var removedPortionId in existingMeals.Except(company.SelectedMeals))
			{
				_context.MealRepository.DeleteMealForCompany(new Meal() { Id = removedPortionId }, company);
			}

			foreach (var addedMealId in company.SelectedMeals.Except(existingMeals))
			{
				_context.MealRepository.AddMealForCompany(new Meal() { Id = addedMealId }, result);
			}

            return result;
		}

		public void Remove(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

            foreach (var meal in _context.MealRepository.GetMealsForCompany(company))
            {
                _context.MealRepository.DeleteMealForCompany(meal, company);
            }
            _context.CompanyRepository.Delete(company);
		}
	}
}
