using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.EqualityComparers;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Common.Extensions;

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

            if (company.Meals.HasValue())
            {
                foreach (var companyMeal in company.Meals)
                {
                    _context.MealRepository.AddMealForCompany(companyMeal, result);
                }
            }

			return result;
		}

		public CompanyModel Save(CompanyModel company)
		{
			if (company == null) throw new ArgumentNullException(nameof(company), "Company cannot be null!");

			var result = _context.CompanyRepository.Update(company);
            var existingMeals = _context.MealRepository.GetMealsForCompany(company).Select(m => (MealModel)m).ToList();

            foreach (var addedMeal in company.Meals.Except(existingMeals, new MealEqualityComparer()))
            {
                _context.MealRepository.AddMealForCompany(addedMeal, company);
            }

            foreach (var removedMeal in existingMeals.Except(company.Meals, new MealEqualityComparer()))
            {
                _context.MealRepository.DeleteMealForCompany(removedMeal, company);
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
