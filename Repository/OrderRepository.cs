using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly IOrderRepository _provider = new OrderProvider();

		public IEnumerable<Order> GetAll(ITransaction transaction = null) =>
			_provider.GetAll(transaction).ToList();

		public IEnumerable<Order> GetByUserIdAndDate(int userId, DateTime date, ITransaction transaction = null) =>
			_provider.GetByUserIdAndDate(userId, date, transaction = null);

		public Order GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public Order Insert(Order order, ITransaction transaction = null) =>
			_provider.Insert(order, transaction);

		public Order Update(Order order, ITransaction transaction = null) =>
			_provider.Update(order, transaction);

		public void Delete(Order order, ITransaction transaction = null) =>
			_provider.Delete(order, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
