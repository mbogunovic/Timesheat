using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ICategoryRepository _provider = new CategoryProvider();

		public IEnumerable<Category> GetAll(ITransaction transaction = null) =>
			_provider.GetAll(transaction).ToList();

		public Category GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public Category Insert(Category category, ITransaction transaction = null) =>
			_provider.Insert(category, transaction);

		public Category Update(Category category, ITransaction transaction = null) =>
			_provider.Update(category, transaction);

		public void Delete(Category category, ITransaction transaction = null) =>
			_provider.Delete(category, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
