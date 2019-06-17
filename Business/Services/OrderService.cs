using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Business.Interfaces;

namespace TimeshEAT.Business.Services
{
	public class OrderService : BaseService, IOrderService
	{
		public OrderService(IRepositoryContext context) : base(context) { }

		public IEnumerable<OrderModel> Get()
		{
			var result = _context.OrderRepository.GetAll()
				.Select(x => (OrderModel)x);

			return result;
		}

		public OrderModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			var result = _context.OrderRepository.GetById(id);

			return result;
		}

		public OrderModel Add(OrderModel order)
		{
			if (order == null) throw new ArgumentNullException(nameof(order), "Order cannot be null!");

			var result = _context.OrderRepository.Insert(order);

			return result;
		}

		public OrderModel Save(OrderModel order)
		{
			if (order == null) throw new ArgumentNullException(nameof(order), "Order cannot be null!");

			var result = _context.OrderRepository.Update(order);

			return result;
		}

		public void Remove(OrderModel order)
		{
			if (order == null) throw new ArgumentNullException(nameof(order), "Order cannot be null!");

			_context.OrderRepository.Delete(order);
		}
	}
}
