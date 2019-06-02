using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
	public interface IRepository<T> where T : Entity
	{
		T GetById(int id, ITransaction transaction = null);
		IEnumerable<T> GetAll(ITransaction transaction = null);
		T Insert(T item, ITransaction transaction = null);
		T Update(T item, ITransaction transaction = null);
		void Delete(T item, ITransaction transaction = null);

		ITransaction CreateNewTransaction();
	}
}
