using System;

namespace TimeshEAT.DataAccessLayer.Models
{
	public class Order
	{
		public Order() { }
		public Order(int id, int quantity, DateTime lunchTime, DateTime orderDate, int userId, int mealId, int portionId, string comment = null)
		{
			Id = id;
			Quantity = quantity;
			LunchTime = lunchTime;
			OrderDate = orderDate;
			UserId = userId;
			MealId = mealId;
			PortionId = portionId;
			Comment = comment;
		}

		public int Id { get; set; }
		public int Quantity { get; set; }
		public DateTime LunchTime { get; set; }
		public DateTime OrderDate { get; set; }
		public int UserId { get; set; }
		public int MealId { get; set; }
		public int PortionId { get; set; }
		public string Comment { get; set; }
	}
}
