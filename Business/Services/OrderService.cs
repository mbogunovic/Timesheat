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
				.Select(x => (OrderModel)x)
				.ToList();

			foreach (var item in result)
			{
				item.User = _context.UserRepository.GetById(item.UserId);
				item.Meal = new MealService(_context).GetBy(item.MealId);
				item.Portion = _context.PortionRepository.GetById(item.PortionId);
			}

			return result;
		}

		public IEnumerable<OrderModel> GetBy(int userId, DateTime date)
		{
			if (userId <= 0) throw new ArgumentNullException(nameof(userId), "Id cannot be null!");
			if (date.Equals(default(DateTime))) throw new ArgumentNullException(nameof(date), "Date cannot be default!");

			var result = _context.OrderRepository.GetByUserIdAndDate(userId, date)
				.Select(x => (OrderModel)x)
				.ToList();

			foreach (var item in result)
			{
				item.User = _context.UserRepository.GetById(item.UserId);
				item.Meal = new MealService(_context).GetBy(item.MealId);
				item.Portion = _context.PortionRepository.GetById(item.PortionId);
			}

			return result;
		}

		public OrderModel GetBy(int id)
		{
			if (id <= 0) throw new ArgumentNullException(nameof(id), "Id cannot be null!");

			OrderModel result = _context.OrderRepository.GetById(id);

			result.User = _context.UserRepository.GetById(result.UserId);
			result.Meal = _context.MealRepository.GetById(result.MealId);
			result.Portion = _context.PortionRepository.GetById(result.PortionId);

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
