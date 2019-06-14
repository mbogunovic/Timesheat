using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly ICompanyRepository _provider = new CompanyProvider();

		public IEnumerable<Company> GetAll(ITransaction transaction = null) =>
			_provider.GetAll(transaction).ToList();

		public Company GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public Company Insert(Company company, ITransaction transaction = null) =>
			_provider.Insert(company, transaction);

		public Company Update(Company company, ITransaction transaction = null) =>
			_provider.Update(company, transaction);

		public void Delete(Company company, ITransaction transaction = null) =>
			_provider.Delete(company, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
