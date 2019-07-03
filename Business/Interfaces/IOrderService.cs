using System;
using System.Collections.Generic;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.Interfaces
{
	public interface IOrderService : IService<OrderModel>
	{
		IEnumerable<OrderModel> GetBy(int userId, DateTime date);
	}
}
