using System;
using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Domain.Interfaces.Repositories
{
	public interface IOrderRepository : IRepository<Order> {
		IEnumerable<Order> GetByUserIdAndDate(int userId, DateTime date, ITransaction transaction = null);
	}
}
