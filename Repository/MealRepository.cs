using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class MealRepository : IMealRepository
	{
		private readonly IMealRepository _provider = new MealProvider();

		public IEnumerable<Meal> GetAll(ITransaction transaction = null) =>
			_provider.GetAll(transaction).ToList();

		public Meal GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public Meal Insert(Meal meal, ITransaction transaction = null) =>
			_provider.Insert(meal, transaction);

		public Meal Update(Meal meal, ITransaction transaction = null) =>
			_provider.Update(meal, transaction);

		public void Delete(Meal meal, ITransaction transaction = null) =>
			_provider.Delete(meal, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
