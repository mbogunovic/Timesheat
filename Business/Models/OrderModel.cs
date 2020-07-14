﻿using System;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class OrderModel : Entity
	{
		private int _quantity;
		private int _userId;
		private int _mealId;
		private int _portionId;

		public OrderModel()
		{

		}

		public OrderModel(int quantity, TimeSpan lunchTime, DateTime orderDate, int userId, int mealId, int portionId, int price = 0, bool applicableDailyDiscount = false, string comment = null, int id = 0, long version = 0) : base(id, version)
		{
			Id = id;
			Quantity = quantity;
			LunchTime = lunchTime;
			OrderDate = orderDate;
			UserId = userId;
			MealId = mealId;
			PortionId = portionId;
			Price = price;
			ApplicableDailyDiscount = applicableDailyDiscount;
			Comment = comment;
			Version = version;
		}

		public PortionModel Portion { get; set; }
		public MealModel Meal { get; set; }
		public UserModel User { get; set; }

		public int Quantity
		{
			get
			{
				Debug.Assert(_quantity > 0);

				return _quantity;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentNullException(nameof(Quantity), "Valid quantity is mandatory!");
				}

				_quantity = value;
			}
		}
		public TimeSpan LunchTime { get; set; }
		public DateTime OrderDate { get; set; }
		public int UserId
		{
			get
			{
				Debug.Assert(_userId > 0);

				return _userId;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentNullException(nameof(UserId), "Valid user id is mandatory!");
				}

				_userId = value;
			}
		}
		public int MealId
		{
			get
			{
				Debug.Assert(_mealId > 0);

				return _mealId;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentNullException(nameof(MealId), "Valid meal id is mandatory!");
				}

				_mealId = value;
			}
		}
		public int PortionId
		{
			get
			{
				Debug.Assert(_portionId > 0);

				return _portionId;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentNullException(nameof(PortionId), "Valid portion id is mandatory!");
				}

				_portionId = value;
			}
		}

		public int Price { get; set; }
		public bool ApplicableDailyDiscount { get; set; }
		public string Comment { get; set; }

		#region [Implicit Operators]

		public static implicit operator Order(OrderModel orderModel)
		{
			if (orderModel == null)
			{
				throw new NullReferenceException("Order cannot be null!");
			}

			return new Order(orderModel.Id, orderModel.Quantity, orderModel.LunchTime, orderModel.OrderDate, orderModel.UserId, orderModel.MealId, orderModel.PortionId, orderModel.Version, comment: orderModel.Comment);
		}

		public static implicit operator OrderModel(Order dbOrder)
		{
			if (dbOrder == null)
			{
				throw new NullReferenceException("Portion cannot be null!");
			}

			return new OrderModel(dbOrder.Quantity, dbOrder.LunchTime, dbOrder.OrderDate, dbOrder.UserId, dbOrder.MealId, dbOrder.PortionId, dbOrder.Price, dbOrder.ApplicableDailyDiscount, dbOrder.Comment, dbOrder.Id, dbOrder.Version);
		}

		#endregion
	}
}
