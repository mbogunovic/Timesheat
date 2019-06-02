using System.Collections.Generic;
using TimeshEAT.Domain.Interfaces;

namespace TimeshEAT.Business.Interfaces
{
	public interface IService<T> where T : IEntity
	{
		T GetBy(int id);
		IEnumerable<T> Get();
		T Add(T item);
		T Save(T item);
		void Remove(T item);
	}
}
