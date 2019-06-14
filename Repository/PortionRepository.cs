using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class PortionRepository : IPortionRepository
	{
		private readonly IPortionRepository _provider = new PortionProvider();

		public IEnumerable<Portion> GetAll(ITransaction transaction = null) =>
			_provider.GetAll(transaction).ToList();

		public Portion GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public Portion Insert(Portion portion, ITransaction transaction = null) =>
			_provider.Insert(portion, transaction);

		public Portion Update(Portion portion, ITransaction transaction = null) =>
			_provider.Update(portion, transaction);

		public void Delete(Portion portion, ITransaction transaction = null) =>
			_provider.Delete(portion, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
