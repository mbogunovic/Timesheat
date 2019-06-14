using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly IRoleRepository _provider = new RoleProvider();

		public IEnumerable<Role> GetAll(ITransaction transaction = null) =>
			_provider.GetAll(transaction).ToList();

		public Role GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public Role Insert(Role role, ITransaction transaction = null) =>
			_provider.Insert(role, transaction);

		public Role Update(Role role, ITransaction transaction = null) =>
			_provider.Update(role, transaction);

		public void Delete(Role role, ITransaction transaction = null) =>
			_provider.Delete(role, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
