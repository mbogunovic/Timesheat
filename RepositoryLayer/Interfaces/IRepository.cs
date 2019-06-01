using System.Collections.Generic;
using TimeshEAT.RepositoryLayer.Models;

namespace TimeshEAT.RepositoryLayer.Interfaces
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
