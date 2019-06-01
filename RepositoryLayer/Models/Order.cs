using System;

namespace TimeshEAT.RepositoryLayer.Models
{
	public class Order : Entity
	{
		public Order() { }
		public Order(int id, int quantity, DateTime lunchTime, DateTime orderDate, int userId, int mealId, int portionId, string comment = null) : base(id)
		{
			Quantity = quantity;
			LunchTime = lunchTime;
			OrderDate = orderDate;
			UserId = userId;
			MealId = mealId;
			PortionId = portionId;
			Comment = comment;
		}

		public int Quantity { get; set; }
		public DateTime LunchTime { get; set; }
		public DateTime OrderDate { get; set; }
		public int UserId { get; set; }
		public int MealId { get; set; }
		public int PortionId { get; set; }
		public string Comment { get; set; }
	}
}
